using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagerUIScript : MonoBehaviour
{
    public Sprite PlayTexture;
    public Sprite PausedTexture;

    private Text monthText;
    private Text yearText;
    private Image timeStateImage;
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
        "October",
        "November",
        "December"
    };

	// Use this for initialization
	void Start ()
    {
        monthText = transform.Find("MonthText").GetComponent<Text>();
        yearText = transform.Find("YearText").GetComponent<Text>();
        timeStateImage = GetComponentInChildren<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (TimeManager.Paused)
        {
            timeStateImage.sprite = PausedTexture;
        }
        else
        {
            timeStateImage.sprite = PlayTexture;
        }

        yearText.text = "Year  " + TimeManager.CurrentYearNumber;
        monthText.text = months[(int)(months.Count * TimeManager.CurrentTimeInYear / TimeManager.SecondsPerYear)];
	}
} 