using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PayBillsEventScript : EventScript
{
    public override string Name
    {
        get { return "Bills"; }
    }

    public override string Description
    {
        get
        {
            if (IncomeManager.Money < Cost)
            {
                return "Your bills are due ( CFA " + Cost.ToString() + " ).  You do not have enough money to pay them.";
            }

            return "Your bills are due ( CFA " + Cost.ToString() + " ).  Do you wish to pay them?";
        }
    }

    // Average house size is 32 m2
    // $700 a year for 32 m2 apartment
    // $52 a year for food per person
    // $170 a month for 85 m2 apartment

    public override float TimeOut { get { return IncomeManager.Money < Cost ? 4 : float.MaxValue; } }
    public override bool YesButtonEnabled { get { return IncomeManager.Money >= Cost; } }
    public override string NoButtonText { get { return IncomeManager.Money >= Cost ? "No" : "OK"; } }
    protected override string OnYesAudioClipPath { get { return "Audio/Money"; } }

    public int Cost { get { return 430500 + 31980 * ChildManager.ChildCount; } }

    public override bool NoDataImplemented { get { return true; } }
    public override string HealthDeltaNoText { get { return "-30% for all children"; } }
    public override string SafetyDeltaNoText { get { return "-20% for all children"; } }
    public override string EducationDeltaNoText { get { return "No change"; } }
    public override string HappinessDeltaNoText { get { return "-50% for all children"; } }

    protected override void OnYes()
    {
        base.OnYes();

        if (IncomeManager.Money >= Cost)
        {
            IncomeManager.AddMoney(-Cost);
        }
    }

    protected override void OnNo()
    {
        base.OnNo();

        ChildManager.ApplyEventToAllChildren(new DataPacket(-30, -20, 0, -50));
    }
}