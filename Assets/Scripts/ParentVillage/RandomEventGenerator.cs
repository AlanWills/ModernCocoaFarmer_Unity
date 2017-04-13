using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventGenerator : MonoBehaviour {

    private EventDialogScript dialog;

    private List<Type> events = new List<Type>()
    {
        typeof(ChildTraffickedEventScript),
        typeof(SalaryDecreasedEventScript),
        typeof(SalaryIncreasedEventScript),
    };

	// Use this for initialization
	void Awake ()
    {
        dialog = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!dialog.DialogOpen && UnityEngine.Random.Range(0.0f, 1.0f) > 1)
        {
            CreateEventDialog();
        }
	}

    private void CreateEventDialog()
    {
        int eventIndex = UnityEngine.Random.Range(0, events.Count);
        dialog.QueueEvent(Activator.CreateInstance(events[eventIndex]) as EventScript);
    }
}
