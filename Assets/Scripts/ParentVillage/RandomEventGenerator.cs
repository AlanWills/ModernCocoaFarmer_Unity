using UnityEngine;

public class RandomEventGenerator : MonoBehaviour {

    private static EventDialogScript dialog;
    public static bool EventsEnabled { get; set; }
    public float TimeUntilEventsStart = TimeManager.SecondsPerYear;
    
	// Use this for initialization
	void Awake ()
    {
        EventsEnabled = false;
        dialog = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (TimeManager.TotalGameTimePassed > TimeUntilEventsStart)
        //{
        //    // Turn on events after a year has passed
        //    EventsEnabled = true;
        //}

		if (EventsEnabled && !dialog.DialogOpen)
        {
            float value = Random.Range(0.0f, 10.0f);

            // Only trial income random events if no dialog is open
            if (IncomeManager.CurrentIncomeLevel != IncomeManager.IncomeLevel.kExcellent)
            {
                if (value > 9.998f)
                {
                    dialog.QueueEvent(new SalaryIncreasedEventScript());
                    return;
                }
            }
            else if (IncomeManager.CurrentIncomeLevel != IncomeManager.IncomeLevel.kLow)
            {
                if (value > 9.998f)
                {
                    dialog.QueueEvent(new SalaryDecreasedEventScript());
                    return;
                }
            }

            if (value > 9.999f)
            {
                dialog.QueueEvent(new FightingBreaksOutEventScript());
                return;
            }
        }
	}
    
    public static bool IsChildTrafficked(Child child)
    {
        float value = Random.Range(0.0f, 150.0f);
        if (child.Safety + child.Happiness < value)
        {
            dialog.QueueEvent(new ChildTraffickedEventScript(child));
            return true;
        }

        return false;
    }
}
