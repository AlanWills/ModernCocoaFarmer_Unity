using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDonateDialogScript : MonoBehaviour {

    private GameObject donateDialogUI;

    void Start()
    {
        donateDialogUI = GameObject.Find("DonateDialogUI");
        donateDialogUI.SetActive(false);
    }

	public void ShowDialog()
    {
        TimeManager.Paused = true;
        donateDialogUI.SetActive(true);
    }
}
