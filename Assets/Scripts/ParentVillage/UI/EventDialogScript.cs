using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventDialogScript : MonoBehaviour
{
    public const string EventDialogName = "EventDialog";

    private GameObject eventDialogUI;
    private Text descriptionUI;
    private EventScript CurrentEvent { get; set; }

    private Queue<EventScript> events = new Queue<EventScript>();

    public void Awake()
    {
        eventDialogUI = GameObject.Find("EventDialogUI");
        descriptionUI = GameObject.Find("Description").GetComponent<Text>();
    }

    public void Start()
    {
        eventDialogUI.SetActive(false);
        Hide();
    }
    
    public void Update()
    {
        if (CurrentEvent == null && events.Count > 0)
        {
            ShowEvent();
        }
    }

    public void QueueEvent(EventScript eventScript)
    {
        events.Enqueue(eventScript);
    }

    private void ShowEvent()
    {
        if (events.Count > 0)
        {
            CurrentEvent = events.Dequeue();

            descriptionUI.text = CurrentEvent.Description;
            eventDialogUI.SetActive(true);
        }
    }

    private void Hide()
    {
        CurrentEvent = null;
        eventDialogUI.SetActive(false);
    }

    public void Yes()
    {
        CurrentEvent.Yes();
        Hide();
    }

    public void No()
    {
        CurrentEvent.No();
        Hide();
    }
}
