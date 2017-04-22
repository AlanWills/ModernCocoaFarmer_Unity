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

    protected override string BuildingDescription
    {
        get
        {
            return "A place of healing if you can pay.";
        }
    }

    protected override string ChildSelectedDescription
    {
        get
        {
            Child selectedChild = ChildManager.SelectedChild;

            if (selectedChild.Health == Child.MaxHealth)
            {
                return selectedChild.Name + " is perfectly healthy";
            }
            else if (IncomeManager.Money >= Cost)
            {
                return selectedChild.Name + " is ill.  Do you wish to pay for treatment? ( CFA " + Math.Abs(CostToPerform).ToString() + " )";
            }

            return selectedChild.Name + " is ill.";
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

    public override float TimeOut { get { return (ChildManager.SelectedChild.Health != Child.MaxHealth && IncomeManager.Money >= Cost) ? float.MaxValue : 4; } }

    protected override string NoButtonTextImpl
    {
        get
        {
            return (ChildManager.SelectedChild.Health != Child.MaxHealth && IncomeManager.Money >= Cost) ? "No" : "OK";
        }
    }
    protected override bool YesButtonEnabledImpl { get { return ChildManager.SelectedChild.Health != Child.MaxHealth && IncomeManager.Money >= Cost; } }
    public override float CostToPerform { get { return ChildManager.SelectedChild.Health != Child.MaxHealth && IncomeManager.Money >= Cost ? Cost : 0; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear / 3; } }
    protected override string OnShowAudioClipPath { get { return "Audio/Hospital"; } }

    public override BuildingType BuildingType { get { return BuildingType.Hospital; } }
    protected override Vector3 BuildingLocation { get { return GameObject.Find("Hospital").transform.position; } }
    
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