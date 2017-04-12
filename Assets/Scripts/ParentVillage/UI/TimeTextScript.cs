using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextScript : MonoBehaviour
{
    private TimeManager timeManager;
    private Text monthText;
    private List<string> months = new List<string>()
    {
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "November",
        "December"
    };

	// Use this for initialization
	void Start () {
        timeManager = GetComponent<TimeManager>();
        monthText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        monthText.text = months[(int)(timeManager.CurrentTimeInYear / 12)];
	}
}
