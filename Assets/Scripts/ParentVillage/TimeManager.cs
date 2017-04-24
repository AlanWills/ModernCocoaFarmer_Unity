using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const float SecondsPerYear = 60;

    public static float CurrentTimeInYear { get; private set; }
    public static float DeltaTime { get; private set; }
    public static bool Paused { get; set; }

    bool midYearReached = false;
    private EventDialogScript dialogScript;

	// Use this for initialization
	void Start ()
    {
        dialogScript = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
        CurrentTimeInYear = SecondsPerYear;
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

        CurrentTimeInYear += DeltaTime;

        if (CurrentTimeInYear > SecondsPerYear)
        {
            CurrentTimeInYear = 0;
            NewYear();
        }
        else if (!midYearReached && CurrentTimeInYear > SecondsPerYear * 0.5f)
        {
            MidYear();
        }
	}

    private void NewYear()
    {
        dialogScript.QueueEvent(new ReceiveIncomeEventScript());
        dialogScript.QueueEvent(new GiveBirthToChildEvent());
        midYearReached = false;
    }

    private void MidYear()
    {
        dialogScript.QueueEvent(new PayBillsEventScript());
        midYearReached = true;
    }
}
