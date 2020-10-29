using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerTypeOneUIScript : MonoBehaviour
{
    public float price = 10f;
    public GameObject towerPrefab;

    void OnMouseDown()
    {
        GameObject moneyReference = GameObject.Find("Money");
        MoneyHandler moneyScript = (MoneyHandler)moneyReference.GetComponent(typeof(MoneyHandler));

        GameObject hudReference = GameObject.Find("TowerHUD");
        TowerHUDHandler hudScript = (TowerHUDHandler)hudReference.GetComponent(typeof(TowerHUDHandler));

        GameObject newTowerReference = hudScript.GetSelectedPedestal();
        Tower towerScript = (Tower)newTowerReference.GetComponent(typeof(Tower));

        if (moneyScript.GetMoney() >= price && !towerScript.TowerExists())
        {
            moneyScript.LoseMoney(price);
            towerScript.CreateTower(towerPrefab);
        }
    }

}
