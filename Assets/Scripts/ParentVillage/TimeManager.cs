using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const float SecondsPerYear = 120;

    private float currentTimeInYear = 0;
    bool midYearReached = false;
    private EventDialogScript dialogScript;

	// Use this for initialization
	void Start ()
    {
        dialogScript = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
        currentTimeInYear = SecondsPerYear;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentTimeInYear += Time.deltaTime;
        if (currentTimeInYear > SecondsPerYear)
        {
            currentTimeInYear = 0;
            NewYear();
        }
        else if (!midYearReached && currentTimeInYear > SecondsPerYear * 0.5f)
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
