using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SendChildToMosqueEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Wealth is not from abundance of possessions.  Wealth is but from wealth of spirit.  - Quran";
        }
    }

    // Randomly the possibility that all your children will get a small safety, happiness and slight education boost (but nowhere near as much as school).
    // When one child completes some time here
    // Hopefully inspires the player to keep sending a child here to keep getting benefits to the family.

    public override float EducationYes { get { return 2; } }
    public override float IncomeYes { get { return 0; } }
    public override float HealthYes { get { return 0; } }
    public override float SafetyYes { get { return 3; } }
    public override float HappinessYes { get { return 5; } }

    public override float EducationNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return 0; } }
    public override float HealthNo { get { return 0; } }
    public override float HappinessNo { get { return 0; } }
}