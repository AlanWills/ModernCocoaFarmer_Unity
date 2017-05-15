using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBirthToSecondChildScript : MonoBehaviour
{
    private EventDialogScript eventDialog;
    private float timeSinceEnabled = 0;

	// Use this for initialization
	void Start ()
    {
        eventDialog = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceEnabled += TimeManager.DeltaTime;
        
        if (timeSinceEnabled > 3)
        {
            eventDialog.QueueEvent(new GiveBirthToChildEvent());
        }
	}
}
