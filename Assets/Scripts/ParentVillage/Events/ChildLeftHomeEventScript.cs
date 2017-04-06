using System;

public class ChildLeftHomeEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Your home has become overcrowded and so one of your children has left for another village to make room.";
        }
    }

    public override string YesButtonText { get { return "OK"; } }
    public override bool NoButtonEnabled { get { return false; } }

    public override float EducationNo { get { return 0; } }
    public override float HappinessNo { get { return 0; } }
    public override float HealthNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return 0; } }

    public override float EducationYes { get { return 0; } }
    public override float HappinessYes { get { return 0; } }
    public override float HealthYes { get { return 0; } }
    public override float IncomeYes { get { return 0; } }
    public override float SafetyYes { get { return 0; } }

    protected override void OnYes()
    {
        base.OnYes();

        // Since this event is fired when a child cap is reached from a new child, we do not include the last child
        Random random = new Random();
        ChildManager.RemoveChild(random.Next(0, ChildManager.MaxChildCount - 1));
    }
}