using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SendChildToHospitalEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "Hospital"; }
    }

    protected override string BuildingDescription { get { return "A place of healing if you can pay."; } }

    protected override string ChildSelectedDescription
    {
        get
        {
            Child selectedChild = ChildManager.SelectedChild;

            if (selectedChild.Health > HealthThreshold)
            {
                return selectedChild.Name + " is not seriously ill.";
            }
            else if (IncomeManager.Money >= Cost)
            {
                return selectedChild.Name + " is seriously ill.  Do you wish to pay for treatment? ( CFA " + Math.Abs(CostToPerform).ToString() + " )";
            }

            return selectedChild.Name + " is seriously ill, but can cannot afford to get them treated ( CFA " + Math.Abs(CostToPerform).ToString() + " ).";
        }
    }

    // If you have money, your child's health gets fully restored: "Your child is ill.  Do you wish to pay for treatment?"
    // If you do not have money, your child will not be treated.  "Your child is ill."  & no yes option
    // This event fires if you click on the hospital
    // It will also fire once if a child's health moves below a critical value, but ONLY if you have money to pay for it

    // $20 to visit doctor
    // $200 to get treated

    private const int Cost = 135300;
    public const float HealthThreshold = 0.5f * Child.MaxHealth;

    public override float TimeOut { get { return (ChildManager.SelectedChild != null && ChildManager.SelectedChild.Health <= HealthThreshold && IncomeManager.Money >= Cost) ? float.MaxValue : 4; } }

    protected override string NoButtonTextImpl
    {
        get
        {
            return (ChildManager.SelectedChild.Health <= HealthThreshold && IncomeManager.Money >= Cost) ? "No" : "OK";
        }
    }
    protected override bool YesButtonEnabledImpl { get { return ChildManager.SelectedChild.Health <= HealthThreshold && IncomeManager.Money >= Cost; } }
    public override int CostToPerform { get { return ChildManager.SelectedChild.Health <= HealthThreshold && IncomeManager.Money >= Cost ? Cost : 0; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear / 3; } }
    protected override string OnShowAudioClipPath { get { return "Audio/Hospital"; } }

    public override BuildingType BuildingType { get { return BuildingType.Hospital; } }
    protected override Vector3 BuildingLocation { get { return GameObject.Find("HospitalDestination").transform.position; } }

    public override bool DataImplemented { get { return true; } }
    public override string HealthDeltaText { get { return "No change"; } }
    public override string SafetyDeltaText { get { return "Restored to 100%"; } }
    public override string EducationDeltaText { get { return "No change"; } }
    public override string HappinessDeltaText { get { return "No change"; } }

    public override string GetOnCompleteDescription(Child child)
    {
        return child.Name + " has been completely cured.";
    }

    protected override DataPacket GetDataPacketPerSecond(Child child)
    {
        return new DataPacket(
            0,
            Child.MaxHealth - child.Health / LockTime,
            0,
            0);
    }
}