using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTimeStateScript : MonoBehaviour
{
    public void ToggleTimeState()
    {
        TimeManager.Paused = !TimeManager.Paused;
    }
}
