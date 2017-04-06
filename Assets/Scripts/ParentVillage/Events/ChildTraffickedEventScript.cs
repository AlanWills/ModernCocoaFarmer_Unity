using System;

public class ChildTraffickedEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "One of your children has been taken by an illegal trafficker.  Do you want to inform the Police? ( CFA " + IncomeYes.ToString() + " )";
        }
    }

    public override float EducationYes { get { return 0; } }
    public override float IncomeYes { get { return 0; } }
    public override float HealthYes { get { return 0; } }
    public override float SafetyYes { get { return 0; } }
    public override float HappinessYes { get { return 0; } }

    public override float EducationNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return 0; } }
    public override float HealthNo { get { return 0; } }
    public override float HappinessNo { get { return 0; } }

    // Yes = pay income for die-roll chance of recovering child; mention income cost in description
    // No = no-op

    protected override void OnYes()
    {
        base.OnYes();

        Random random = new Random();
        if (random.NextDouble() >= 0.2)
        {
            ChildManager.RemoveChild(random.Next(0, ChildManager.ChildCount));
        }
    }

    protected override void OnNo()
    {
        base.OnNo();

        Random random = new Random();
        ChildManager.RemoveChild(random.Next(0, ChildManager.ChildCount));
    }
}