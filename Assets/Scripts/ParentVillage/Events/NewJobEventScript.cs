using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NewJobEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Your husband has been promoted have gained a new job.";
        }
    }

    // 4 tiers of salary - start on third highest and new job and lost job just makes you go up and down these tiers.
    // Will need enum and strings for different enum
    // 750 dollars = tier 3.

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
}