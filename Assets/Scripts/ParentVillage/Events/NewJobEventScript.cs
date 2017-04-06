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
            return "Your husband's pay has been increased.";
        }
    }

    public override string YesButtonText { get { return "OK"; } }
    public override bool NoButtonEnabled { get { return false; } }

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

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.IncreaseIncomeLevel();
    }
}