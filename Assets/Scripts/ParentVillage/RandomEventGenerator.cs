using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventGenerator : MonoBehaviour {

    private GameObject dialog;

    private List<EventScript> events = new List<EventScript>()
    {
        new ChildTraffickedEventScript(),
        new LostJobEventScript(),
        new NewJobEventScript(),
        new PayBillsEventScript(),
    };

	// Use this for initialization
	void Awake ()
    {
        dialog = GameObject.Find(EventDialogScript.EventDialogName);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!dialog.activeSelf && Random.Range(0.0f, 1.0f) > 1)
        {
            CreateEventDialog();
        }
	}

    private void CreateEventDialog()
    {
        int eventIndex = Random.Range(0, events.Count);
        dialog.GetComponent<EventDialogScript>().QueueEvent(events[eventIndex]);
    }
}
