using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellHandler : MonoBehaviour
{
    private float sellValue = 0;
    Text valueText;
    // Start is called before the first frame update
    void Start()
    {
        valueText = gameObject.GetComponent<Text>();
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

            sellValue = (int)(towerScript.GetTotalCost() / 3f * 2f);
            valueText.text = sellValue.ToString();
        }
        catch
        {
            valueText.text = "0";
        }
    }

    void OnMouseDown()
    {
        GameObject moneyReference = GameObject.Find("Money");
        MoneyHandler moneyScript = (MoneyHandler)moneyReference.GetComponent(typeof(MoneyHandler));

        moneyScript.GainMoney(sellValue);

        GameObject selectReference = GameObject.Find("SelectedTowerHandler");
        SelectedTowerHandler selectScript = (SelectedTowerHandler)selectReference.GetComponent(typeof(SelectedTowerHandler));
        Pedestal selectedPedestal = selectScript.GetSelectedPedestal();
        Pedestal pedestalScript = (Pedestal)selectedPedestal.GetComponent(typeof(Pedestal));
        pedestalScript.DestroyTower();

        sellValue = 0;
        valueText.text = "0";
    }
}
