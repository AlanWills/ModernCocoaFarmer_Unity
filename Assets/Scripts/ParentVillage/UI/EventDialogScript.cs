using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class EventDialogScript : MonoBehaviour
{
    public const string EventDialogName = "EventDialog";

    public bool DialogOpen { get { return eventDialogUI.activeSelf; } }

    private bool timePausedOnEventShow;
    private AudioSource audioSource;
    private GameObject eventDialogUI;
    private Text nameUI;
    private Text descriptionUI;
    private GameObject yesButton;
    private GameObject noButton;
    private Text yesText;
    private Text noText;
    private EventScript CurrentEvent { get; set; }

    #region Data UI

    private GameObject yesData;
    private Text healthDeltaYesText;
    private Text safetyDeltaYesText;
    private Text educationDeltaYesText;
    private Text happinessDeltaYesText;

    private GameObject noData;
    private Text healthDeltaNoText;
    private Text safetyDeltaNoText;
    private Text educationDeltaNoText;
    private Text happinessDeltaNoText;

    #endregion

    private Queue<EventScript> events = new Queue<EventScript>();

    private float currentTimer = 0;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        eventDialogUI = GameObject.Find("EventDialogUI");
        nameUI = GameObject.Find("EventName").GetComponent<Text>();
        descriptionUI = GameObject.Find("EventDescription").GetComponent<Text>();
        yesButton = GameObject.Find("YesButton");
        noButton = GameObject.Find("NoButton");
        yesText = GameObject.Find("YesText").GetComponent<Text>();
        noText = GameObject.Find("NoText").GetComponent<Text>();

        yesData = GameObject.Find("YesButtonEffects");
        healthDeltaYesText = GameObject.Find("HealthDeltaYesText").GetComponent<Text>();
        safetyDeltaYesText = GameObject.Find("SafetyDeltaYesText").GetComponent<Text>();
        educationDeltaYesText = GameObject.Find("EducationDeltaYesText").GetComponent<Text>();
        happinessDeltaYesText = GameObject.Find("HappinessDeltaYesText").GetComponent<Text>();

        noData = GameObject.Find("NoButtonEffects");
        healthDeltaNoText = GameObject.Find("HealthDeltaNoText").GetComponent<Text>();
        safetyDeltaNoText = GameObject.Find("SafetyDeltaNoText").GetComponent<Text>();
        educationDeltaNoText = GameObject.Find("EducationDeltaNoText").GetComponent<Text>();
        happinessDeltaNoText = GameObject.Find("HappinessDeltaNoText").GetComponent<Text>();
    }

    public void Start()
    {
        eventDialogUI.SetActive(false);
        Hide();
    }
    
    public void Update()
    {
        if (CurrentEvent == null)
        {
            ShowEvent();
        }
        else
        {
            // Dont use time manager as it will be paused
            currentTimer += Time.deltaTime;
            if (currentTimer > CurrentEvent.TimeOut)
            {
                CurrentEvent.No();
                Hide();
            }
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
            timePausedOnEventShow = TimeManager.Paused;
            TimeManager.Paused = true;
            CurrentEvent = events.Dequeue();
            Child selectedChild = ChildManager.SelectedChild;

            if (CurrentEvent.OnShowAudioClip != null)
            {
                audioSource.clip = CurrentEvent.OnShowAudioClip;
                audioSource.Play();
            }

            bool yesButtonEnabled = CurrentEvent.YesButtonEnabled;
            bool noButtonEnabled = CurrentEvent.NoButtonEnabled;

            nameUI.text = CurrentEvent.Name;
            descriptionUI.text = CurrentEvent.Description;
            yesButton.SetActive(yesButtonEnabled);
            noButton.SetActive(noButtonEnabled);
            yesText.text = yesButtonEnabled ? CurrentEvent.YesButtonText : "";
            noText.text = noButtonEnabled ? CurrentEvent.NoButtonText : "";
            yesData.SetActive(selectedChild != null && CurrentEvent.YesDataImplemented);
            noData.SetActive(selectedChild != null && CurrentEvent.NoDataImplemented);

            if (selectedChild != null && CurrentEvent.YesDataImplemented)
            {
                healthDeltaYesText.text = CurrentEvent.HealthDeltaYesText;
                safetyDeltaYesText.text = CurrentEvent.SafetyDeltaYesText;
                educationDeltaYesText.text = CurrentEvent.EducationDeltaYesText;
                happinessDeltaYesText.text = CurrentEvent.HappinessDeltaYesText;
            }

            if (selectedChild!= null && CurrentEvent.NoDataImplemented)
            {
                healthDeltaNoText.text = CurrentEvent.HealthDeltaNoText;
                safetyDeltaNoText.text = CurrentEvent.SafetyDeltaNoText;
                educationDeltaNoText.text = CurrentEvent.EducationDeltaNoText;
                happinessDeltaNoText.text = CurrentEvent.HappinessDeltaNoText;
            }

            eventDialogUI.SetActive(true);

            currentTimer = 0;
        }
    }

    private void Hide()
    {
        currentTimer = 0;
        CurrentEvent = null;
        eventDialogUI.SetActive(false);
        TimeManager.Paused = timePausedOnEventShow;
    }

    public void Yes()
    {
        CurrentEvent.Yes();

        if (CurrentEvent.OnYesAudioClip != null)
        {
            audioSource.clip = CurrentEvent.OnYesAudioClip;
            audioSource.Play();
        }

        Hide();
    }

    public void No()
    {
        CurrentEvent.No();

        if (CurrentEvent.OnNoAudioClip != null)
        {
            audioSource.clip = CurrentEvent.OnNoAudioClip;
            audioSource.Play();
        }

        Hide();
    }
}
