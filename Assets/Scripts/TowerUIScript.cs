using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUIScript : MonoBehaviour
{
    public float price;
    public GameObject towerPrefab;

    void OnMouseDown()
    {
        GameObject moneyReference = GameObject.Find("Money");
        MoneyHandler moneyScript = (MoneyHandler)moneyReference.GetComponent(typeof(MoneyHandler));

        GameObject hudReference = GameObject.Find("TowerHUD");
        TowerHUDHandler hudScript = (TowerHUDHandler)hudReference.GetComponent(typeof(TowerHUDHandler));

        GameObject newPedestalReference = hudScript.GetSelectedPedestal();
        Pedestal pedestalScript = (Pedestal)newPedestalReference.GetComponent(typeof(Pedestal));

        if (moneyScript.GetMoney() >= price && !pedestalScript.TowerExists())
        {
            moneyScript.LoseMoney(price);
            pedestalScript.CreateTower(towerPrefab, price);
            SoundManagerScript.PlaySound("upgrade");
        }
    }

}
