using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour
{
    private float levelCost = 0;
    Text costText;
    // Start is called before the first frame update
    void Start()
    {
        costText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            GameObject selectReference = GameObject.Find("SelectedTowerHandler");
            SelectedTowerHandler selectScript = (SelectedTowerHandler)selectReference.GetComponent(typeof(SelectedTowerHandler));
            Pedestal selectedPedestal = selectScript.GetSelectedPedestal();
            Pedestal pedestalScript = (Pedestal)selectedPedestal.GetComponent(typeof(Pedestal));
            GameObject tower = pedestalScript.GetTower();
            TowerScript towerScript = (TowerScript)tower.GetComponent(typeof(TowerScript));

            if (towerScript.GetLevel() <= 3)
            {
                levelCost = towerScript.GetTotalCost() / 2;
                costText.text = levelCost.ToString();
            }
            else
            {
                levelCost = 0f;
                costText.text = "MAX";
            }
        }
        catch
        {
            costText.text = "0";
        }
    }

    void OnMouseDown()
    {
        GameObject moneyReference = GameObject.Find("Money");
        MoneyHandler moneyScript = (MoneyHandler)moneyReference.GetComponent(typeof(MoneyHandler));

        if (moneyScript.GetMoney() >= levelCost && levelCost > 0f)
        {
            moneyScript.LoseMoney(levelCost);

            GameObject selectReference = GameObject.Find("SelectedTowerHandler");
            SelectedTowerHandler selectScript = (SelectedTowerHandler)selectReference.GetComponent(typeof(SelectedTowerHandler));
            Pedestal selectedPedestal = selectScript.GetSelectedPedestal();
            Pedestal pedestalScript = (Pedestal)selectedPedestal.GetComponent(typeof(Pedestal));
            GameObject tower = pedestalScript.GetTower();
            TowerScript towerScript = (TowerScript)tower.GetComponent(typeof(TowerScript));

            towerScript.LevelUp();
            towerScript.AddCost(levelCost);
        }
    }
}
