using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SendChildToWorkEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Do you wish to send your child to work to earn money for the family.";
        }
    }

    // Child gets money at the end, but also chance of injury = serious health impact and slim change of trafficking

    public override float EducationYes { get { return -10; } }
    public override float IncomeYes { get { return 7; } }
    public override float HealthYes { get { return -15; } }
    public override float SafetyYes { get { return -50; } }
    public override float HappinessYes { get { return -25; } }

    public override float EducationNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return 0; } }
    public override float HealthNo { get { return 0; } }
    public override float HappinessNo { get { return 0; } }
}