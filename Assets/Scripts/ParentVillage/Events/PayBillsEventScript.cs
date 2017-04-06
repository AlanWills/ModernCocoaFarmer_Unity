using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PayBillsEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Your bills are due.  Do you wish to pay them? ( CFA " + Cost.ToString() + " )";
        }
    }

    // Average house size is 32 m2
    // $700 a year for 32 m2 apartment
    // $52 a year for food per person
    // $170 a month for 85 m2 apartment

    public override string YesButtonText { get { return "Yes"; } }
    public override bool NoButtonEnabled { get { return true; } }

    public float Cost { get { return 430500 + 31980 * ChildManager.ChildCount; } }

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.AddMoney(-Cost);
    }

    protected override void OnNo()
    {
        base.OnNo();

        ChildManager.ApplyEventToAllChildren(new DataPacket(0, -30, -20, -50));
    }
}