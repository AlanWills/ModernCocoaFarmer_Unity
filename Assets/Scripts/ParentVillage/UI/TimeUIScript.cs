using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUIScript : MonoBehaviour
{
    public Sprite PlayTexture;
    public Sprite PausedTexture;

    private Text monthText;
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
        monthText = GetComponent<Text>();
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

        monthText.text = months[(int)(months.Count * TimeManager.CurrentTimeInYear / TimeManager.SecondsPerYear)];
	}
} 