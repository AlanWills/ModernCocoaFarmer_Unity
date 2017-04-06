using System;

public class ChildTraffickedEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "One of your children has been taken by an illegal trafficker.  Do you want to inform the Police? ( CFA " + Cost.ToString() + " )";
        }
    }

    public override string YesButtonText { get { return "Yes"; } }
    public override bool NoButtonEnabled { get { return true; } }

    private const float Cost = 615000;

    // Yes = pay income for die-roll chance of recovering child; mention income cost in description
    // No = no-op

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.AddMoney(-Cost);

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