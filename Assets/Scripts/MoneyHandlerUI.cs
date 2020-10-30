using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandlerUI : MonoBehaviour
{
    public float currMoney = 0;
    Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject moneyReference = GameObject.Find("Money");
        MoneyHandler moneyScript = (MoneyHandler)moneyReference.GetComponent(typeof(MoneyHandler));
        currMoney = moneyScript.GetMoney();
        moneyText.text = currMoney.ToString();

    }
}
