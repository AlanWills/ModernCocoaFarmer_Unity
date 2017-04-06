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
            return "Your bills are due.  Do you wish to pay them? ( $" + IncomeYes.ToString() + " )";
        }
    }

    // Average house size is 32 m2
    // $700 a year for 32 m2 apartment
    // $52 a year for food per person
    // $170 a month for 85 m2 apartment

    public override float EducationYes { get { return 0; } }
    public override float IncomeYes { get { return -(430500 + 31980 * ChildManager.ChildCount); } }
    public override float HealthYes { get { return 40; } }
    public override float SafetyYes { get { return 35; } }
    public override float HappinessYes { get { return 15; } }

    public override float EducationNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return -60; } }
    public override float HealthNo { get { return -50; } }
    public override float HappinessNo { get { return -75; } }
}