using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonateDialogScript : MonoBehaviour {

    private GameObject donateDialogUI;
    private int amountToPay;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAmountToPay()
    {
        amountToPay = GameObject.Find("AmountDropdown").GetComponent<Dropdown>().value;
    }

    public void CloseAndPay()
    {
        // 770 CFA to 1 pound
        int actualAmount = amountToPay == 0 ? 770 : 5 * 770 * amountToPay;
        IncomeManager.AddMoney(actualAmount);
        ChildManager.ApplyEventToAllChildren(new DataPacket(0, 100, 0, 100));
        GameObject.Find("MoneyText").GetComponent<Text>().color = new Color(34.0f / 255, 139.0f / 255, 34.0f / 255, 1.0f);

        Close();
    }

    public void Close()
    {
        GameObject.Find("DonateDialogUI").SetActive(false);
        TimeManager.Paused = false;
    }
}
