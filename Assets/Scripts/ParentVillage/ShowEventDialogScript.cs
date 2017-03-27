using System;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ShowEventDialogScript : MonoBehaviour {

    public string EventName;

    private EventScript eventScript;
    private GameObject dialog;

    void Awake()
    {
        dialog = GameObject.Find(EventDialogScript.EventDialogName);
    }

    // Use this for initialization
    void Start ()
    {
        Type type = Assembly.GetExecutingAssembly().GetType(EventName);
        eventScript = Activator.CreateInstance(type) as EventScript;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        dialog.GetComponent<EventDialogScript>().QueueEvent(eventScript);
    }
}
