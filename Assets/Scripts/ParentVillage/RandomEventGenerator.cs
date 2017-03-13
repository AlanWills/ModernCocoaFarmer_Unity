using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventGenerator : MonoBehaviour {

    public GameObject Dialog;

    private List<RandomEventScript> events = new List<RandomEventScript>()
    {
        new ChildTraffickedScript()
    };

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!Dialog.activeSelf && Random.Range(0.0f, 1.0f) > 0.0f)
        {
            CreateEventDialog();
        }
	}

    private void CreateEventDialog()
    {
        int eventIndex = Random.Range(0, events.Count);
        Dialog.SetActive(true);
        Dialog.GetComponent<RandomEventDialogScript>().SetEvent(events[eventIndex]);
    }
}
