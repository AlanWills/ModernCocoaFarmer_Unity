using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStateButtonUIScript : MonoBehaviour
{
    public Sprite PlayingSprite;
    public Sprite PausedSprite;

    private Image imageUI;

	// Use this for initialization
	void Start ()
    {
        imageUI = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        imageUI.sprite = TimeManager.Paused ? PausedSprite : PlayingSprite;
    }

    public void ToggleTimeState()
    {
        TimeManager.Paused = !TimeManager.Paused;
    }
}
