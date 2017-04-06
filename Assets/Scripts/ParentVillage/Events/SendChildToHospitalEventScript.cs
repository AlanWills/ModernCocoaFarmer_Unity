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
            if (IncomeManager.Money >= Cost)
            {
                return "Your child is ill.  Do you wish to pay for treatment?";
            }

            return "Your child is ill.";
        }
    }

    // If you have money, your child's health gets fully restored: "Your child is ill.  Do you wish to pay for treatment?"
    // If you do not have money, your child will not be treated.  "Your child is ill."  & no yes option
    // This event fires if you click on the hospital
    // It will also fire once if a child's health moves below a critical value, but ONLY if you have money to pay for it

    // $20 to visit doctor
    // $200 to get treated

    private const float Cost = 135300;
    public const float HealthThreshold = 10;

    public override string YesButtonText
    {
        get
        {
            return IncomeManager.Money >= Cost ? "Yes" : "OK";
        }
    }
    public override bool NoButtonEnabled { get { return IncomeManager.Money >= Cost; } }

    public override float EducationYes { get { return 0; } }
    public override float IncomeYes { get { return IncomeManager.Money >= Cost ? Cost : 0; } }
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

        if (IncomeManager.Money >= IncomeYes)
        {
            // Heal child which was critical
            Child child = ChildManager.FindChild(x => x.Health < HealthThreshold);
            child.Apply(new DataPacket(0, Child.MaxHealth - child.Health, 0, 0));
        }
    }
}