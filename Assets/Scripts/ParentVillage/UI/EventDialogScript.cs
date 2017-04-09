using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventDialogScript : MonoBehaviour
{
    public const string EventDialogName = "EventDialog";

    private GameObject eventDialogUI;
    private Text nameUI;
    private Text descriptionUI;
    private GameObject yesButton;
    private GameObject noButton;
    private Text yesText;
    private Text noText;
    private EventScript CurrentEvent { get; set; }

    private Queue<EventScript> events = new Queue<EventScript>();

    public void Awake()
    {
        eventDialogUI = GameObject.Find("EventDialogUI");
        nameUI = GameObject.Find("Name").GetComponent<Text>();
        descriptionUI = GameObject.Find("Description").GetComponent<Text>();
        yesButton = GameObject.Find("YesButton");
        noButton = GameObject.Find("NoButton");
        yesText = GameObject.Find("YesText").GetComponent<Text>();
        noText = GameObject.Find("NoText").GetComponent<Text>();
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

            nameUI.text = CurrentEvent.Name;
            descriptionUI.text = CurrentEvent.Description;
            yesText.text = CurrentEvent.YesButtonText;
            noText.text = CurrentEvent.NoButtonText;
            eventDialogUI.SetActive(true);
            yesButton.SetActive(CurrentEvent.YesButtonEnabled);
            noButton.SetActive(CurrentEvent.NoButtonEnabled);
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
