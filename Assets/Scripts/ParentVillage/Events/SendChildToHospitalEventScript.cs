using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SendChildToHospitalEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "Hospital"; }
    }

    public override string Description
    {
        get
        {
            if (IncomeManager.Money >= Cost)
            {
                return ChildManager.SelectedChild.Name + " is ill.  Do you wish to pay for treatment? ( CFA " + Math.Abs(CostToPerform).ToString() + " )";
            }

            return ChildManager.SelectedChild.Name + " is ill.";
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
    public override float CostToPerform { get { return IncomeManager.Money >= Cost ? Cost : 0; } }
    protected override float LockTime { get { return 40; } }
    public override BuildingType BuildingType { get { return BuildingType.Hospital; } }
    protected override string OnShowAudioClipPath { get { return "Audio/Hospital"; } }

    protected override void OnYes()
    {
        if (IncomeManager.Money >= CostToPerform)
        {
            base.OnYes();
        }
    }

    public override string GetOnCompleteDescription(Child child)
    {
        return child.Name + " has been completely cured.";
    }

    protected override void OnTimeComplete(Child child)
    {
        // Heal child which was critical
        child.Apply(new DataPacket(0, Child.MaxHealth - child.Health, 0, 0));
    }
}