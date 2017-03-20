using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {

    public int StartingMoney = 100;
    public int Money { get; set; }

    private Text moneyText;

	// Use this for initialization
	void Start () {
        Money = StartingMoney;

        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
        moneyText.text = "$ " + Money.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
