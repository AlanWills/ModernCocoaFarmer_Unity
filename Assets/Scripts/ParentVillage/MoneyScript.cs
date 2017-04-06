using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    private Text moneyText;

	// Use this for initialization
	void Start ()
    {
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
        moneyText.text = "CFA " + IncomeManager.Money.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moneyText.text = "CFA " + IncomeManager.Money.ToString();
    }
}
