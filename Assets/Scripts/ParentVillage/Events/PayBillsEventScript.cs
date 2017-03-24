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
            return "You pay bills.";
        }
    }

    public override float EducationYes { get { return 0; } }
    public override float IncomeYes { get { return -3.5f; } }
    public override float HealthYes { get { return 40; } }
    public override float SafetyYes { get { return 35; } }
    public override float HappinessYes { get { return 15; } }

    public override float EducationNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return -60; } }
    public override float HealthNo { get { return -50; } }
    public override float HappinessNo { get { return -75; } }
}