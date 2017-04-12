using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const float SecondsPerYear = 120;

    public float CurrentTimeInYear { get; private set; }
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
        CurrentTimeInYear += Time.deltaTime;
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
