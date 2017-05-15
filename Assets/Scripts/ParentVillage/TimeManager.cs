using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const float SecondsPerYear = 30;

    public static int CurrentYearNumber { get { return (int)(TotalGameTimePassed / SecondsPerYear) + 1; } }
    public static float TotalGameTimePassed { get; private set; }
    public static float CurrentTimeInYear { get; private set; }
    public static float DeltaTime { get; private set; }
    public static bool Paused { get; set; }

    private bool midYearReached = false;
    private bool quarterYearReached = false;
    private EventDialogScript dialogScript;
    private NotificationDialogScript notificationScript;

	// Use this for initialization
	void Start ()
    {
        dialogScript = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
        dialogScript.QueueEvent(new InstructionEventScript());
        notificationScript = GameObject.Find(NotificationDialogScript.NotificationDialogName).GetComponent<NotificationDialogScript>();
        CurrentTimeInYear = 0;
        Paused = false; // Instruction event will keep game paused otherwise when it launches on startup
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!Paused)
        {
            DeltaTime = Time.deltaTime;
        }
        else
        {
            DeltaTime = 0;
        }

        TotalGameTimePassed += DeltaTime;
        CurrentTimeInYear += DeltaTime;

        if (CurrentTimeInYear > SecondsPerYear)
        {
            CurrentTimeInYear = 0;
            NewYear();
        }
        else if (!quarterYearReached && CurrentTimeInYear > SecondsPerYear * 0.25f)
        {
            QuarterYear();
        }
        else if (!midYearReached && CurrentTimeInYear > SecondsPerYear * 0.5f)
        {
            MidYear();
        }
	}

    public void NewYear()
    {
        //notificationScript.QueueNotification(new ReceiveIncomeNotificationScript());
        midYearReached = false;
        quarterYearReached = false;
    }

    public void QuarterYear()
    {
        //dialogScript.QueueEvent(new GiveBirthToChildEvent());
        quarterYearReached = true;
    }

    public void MidYear()
    {
        //dialogScript.QueueEvent(new PayBillsEventScript());
        midYearReached = true;
    }
}
