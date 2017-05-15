using System;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class ShowEventDialogScript : MonoBehaviour {

    public string EventName;

    private InteractableBuildingEventScript eventScript;
    private GameObject dialog;
    private AudioSource click;

    void Awake()
    {
        dialog = GameObject.Find(EventDialogScript.EventDialogName);        
    }

    // Use this for initialization
    void Start ()
    {
        click = GetComponent<AudioSource>();

        Type type = Assembly.GetExecutingAssembly().GetType(EventName);
        eventScript = Activator.CreateInstance(type) as InteractableBuildingEventScript;
	}
	
	// Update is called once per frame
	void Update ()
    {
        eventScript.Update();
	}

    private void OnMouseDown()
    {
        // Only do this if there isn't a dialog open already
        if (!dialog.GetComponent<EventDialogScript>().DialogOpen)
        {
            click.Play();

            Child selectedChild = ChildManager.SelectedChild;
            if (selectedChild != null)
            {
                if (selectedChild.BuildingType != BuildingType.Idle)
                {
                    dialog.GetComponent<EventDialogScript>().QueueEvent(new ChildAlreadyLockedInEventScript(selectedChild.BuildingType));
                }
                else if(eventScript.ConfirmEventQueued(selectedChild))
                {
                    dialog.GetComponent<EventDialogScript>().QueueEvent(eventScript);
                }
            }
            else
            {
                dialog.GetComponent<EventDialogScript>().QueueEvent(eventScript);
            }
        }
    }
}
