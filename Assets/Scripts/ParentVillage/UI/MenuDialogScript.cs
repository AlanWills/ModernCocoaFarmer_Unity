using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDialogScript : MonoBehaviour
{
    private GameObject menuDialogUI;

	// Use this for initialization
	void Start ()
    {
        menuDialogUI = GameObject.Find("MenuDialogUI");
        menuDialogUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Show()
    {
        TimeManager.Paused = true;
        menuDialogUI.SetActive(true);
    }

    public void Hide()
    {
        TimeManager.Paused = false;
        menuDialogUI.SetActive(false);
    }
}
