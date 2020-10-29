using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    public float money = 50f;
    // Start is called before the first frame update
    public float GetMoney()
    {
        return money;
    }
    public void SetMoney(float newMoney)
    {
        money = newMoney;
    }
    public void GainMoney(float moneyGained)
    {
        money += moneyGained;
    }
    public void LoseMoney(float moneyLost)
    {
        money -= moneyLost;
    }
}
