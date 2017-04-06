using UnityEngine;

public class GiveBirthToChildEvent : EventScript
{
    public override string Description
    {
        get
        {
            if (ChildManager.ChildCount <= 5)
            {
                return "You've had a baby lol.";
            }

            return "You have become pregnant, do you wish to keep the child?";
        }
    }

    public override string YesButtonText { get { return "OK"; } }
    public override bool NoButtonEnabled { get { return false; } }

    public override float EducationYes { get { return 0; } }
    public override float HappinessYes { get { return 0; } }
    public override float SafetyYes { get { return 0; } }
    public override float HealthYes { get { return 0; } }
    public override float IncomeYes { get { return 0; } }

    public override float EducationNo { get { return 0; } }
    public override float HappinessNo { get { return 0; } }
    public override float HealthNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return 0; } }
    
    protected override void OnYes()
    {
        ChildManager.AddChild();

        if (ChildManager.ChildCount > ChildManager.MaxChildCount)
        {
            // If this child brings us over the max, we queue an event about the child leaving home
            GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>().QueueEvent(new ChildLeftHomeEventScript());
        }
    }
}