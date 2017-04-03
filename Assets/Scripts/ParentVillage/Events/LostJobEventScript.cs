using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LostJobEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "You have lost your job.";
        }
    }

    // No Yes/No with this, but two flavours - 1)  Your husband goes down to part time (salary halves)  2)  Your husband loses the company money and they boot you out (salary lost entirely)
    // See new job event 

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