using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventDialogScript : MonoBehaviour
{
    public const string EventDialogName = "EventDialog";
    
    public Text DescriptionUI;
    private EventScript CurrentEvent { get; set; }

    private Queue<EventScript> events;

    public void Start()
    {
        events = new Queue<EventScript>();
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

            DescriptionUI.text = CurrentEvent.Description;
            gameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        CurrentEvent = null;
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
