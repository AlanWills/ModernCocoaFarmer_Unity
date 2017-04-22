using UnityEngine;

public class RandomEventGenerator : MonoBehaviour {

    private static EventDialogScript dialog;
    
	// Use this for initialization
	void Awake ()
    {
        dialog = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!dialog.DialogOpen)
        {
            // Only trial income random events if no dialog is open
            if (IncomeManager.CurrentIncomeLevel == IncomeManager.IncomeLevel.kExcellent)
            {
                if (Random.Range(0, 1) > 0.995f)
                {
                    dialog.QueueEvent(new SalaryDecreasedEventScript());
                }
            }
            else if (IncomeManager.CurrentIncomeLevel == IncomeManager.IncomeLevel.kLow)
            {
                if (Random.Range(0, 1) > 0.995f)
                {
                    dialog.QueueEvent(new SalaryIncreasedEventScript());
                }
            }
        }
	}
    
    public static bool IsChildTrafficked(Child child)
    {
        float value = Random.Range(0, 100);
        if (child.Safety + child.Happiness < value)
        {
            dialog.QueueEvent(new ChildTraffickedEventScript(child));
            return true;
        }

        return false;
    }
}
