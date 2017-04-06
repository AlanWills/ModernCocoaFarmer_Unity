using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SendChildToSchoolEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Do you wish to send your child to school so they will be more likely to earn money in the future? ( CFA " + Math.Abs(IncomeYes).ToString() + " for books, equipment and uniform )";
        }
    }

    // $50 per child per year for equipment. ~ 7% of income of parent
    // Paid at beginning of year
    // Child locked in for an entire year
    // 70 children in class per average

    public override float EducationYes { get { return 10; } }
    public override float IncomeYes { get { return -3075; } }
    public override float HealthYes { get { return 10; } }
    public override float SafetyYes { get { return 50; } }
    public override float HappinessYes { get { return 25; } }

    public override float EducationNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return 0; } }
    public override float HealthNo { get { return 0; } }
    public override float HappinessNo { get { return 0; } }
}