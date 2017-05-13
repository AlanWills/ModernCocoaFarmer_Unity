using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTimeStateScript : MonoBehaviour
{
    private Image imageUI;

	// Use this for initialization
	void Start ()
    {
        imageUI = GetComponent<Image>();
	}

    public void ToggleTimeState()
    {
        TimeManager.Paused = !TimeManager.Paused;
    }
}
