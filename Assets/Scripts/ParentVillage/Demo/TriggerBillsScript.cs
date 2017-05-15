using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBillsScript : MonoBehaviour
{
    private EventDialogScript eventDialog;
    private float timeSinceEnabled = 0;
    private const float TimeToWait = 15;

    // Use this for initialization
    void Start()
    {
        eventDialog = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceEnabled += TimeManager.DeltaTime;

        if (timeSinceEnabled > TimeToWait)
        {
            eventDialog.QueueEvent(new PayBillsEventScript());
            enabled = false;
        }
    }
}
