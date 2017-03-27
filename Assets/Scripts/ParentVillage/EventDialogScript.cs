using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventDialogScript : MonoBehaviour
{
    public const string EventDialogName = "EventDialog";
    
    private Text description;
    private EventScript CurrentEvent { get; set; }

    private Queue<EventScript> events;

    public void Start()
    {
        events = new Queue<EventScript>();
        Hide();
    }

    public void Awake()
    {
        description = GameObject.Find("Description").GetComponent<Text>();
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

            description.text = CurrentEvent.Description;
            gameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
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
