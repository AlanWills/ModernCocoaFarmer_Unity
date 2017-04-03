using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SendChildToHospitalEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Your child is ill.";
        }
    }

    // If you have money, your child's health gets fully restored: "Your child is ill.  Do you wish to pay for treatment?"
    // If you do not have money, your child will not be treated.  "Your child is ill."  & no yes option
    // This event fires if you click on the hospital
    // It will also fire once if a child's health moves below a critical value, but ONLY if you have money to pay for it

    // $20 to visit doctor
    // $200 to get treated

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