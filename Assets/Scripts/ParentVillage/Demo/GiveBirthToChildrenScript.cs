using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBirthToChildrenScript : MonoBehaviour
{
    private EventDialogScript eventDialog;
    private TriggerBillsScript billsScript;
    private float timeSinceEnabled = 0;
    private const float TimeToWait = 3;
    private int numberOfChildren = 0;

	// Use this for initialization
	void Start ()
    {
        eventDialog = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
        billsScript = GetComponent<TriggerBillsScript>();
        billsScript.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceEnabled += TimeManager.DeltaTime;
        
        if (timeSinceEnabled > TimeToWait)
        {
            eventDialog.QueueEvent(new GiveBirthToChildEvent());
            billsScript.enabled = numberOfChildren == 2;
            enabled = !billsScript.enabled;
            numberOfChildren++;
        }
	}
}
