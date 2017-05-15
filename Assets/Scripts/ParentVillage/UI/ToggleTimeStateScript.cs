using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTimeStateScript : MonoBehaviour
{
    private bool audioPausedOnToggle;

    public void ToggleTimeState()
    {
        TimeManager.Paused = !TimeManager.Paused;
        if (TimeManager.Paused)
        {
            audioPausedOnToggle = AudioListener.pause;
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = audioPausedOnToggle;
        }
    }
}
