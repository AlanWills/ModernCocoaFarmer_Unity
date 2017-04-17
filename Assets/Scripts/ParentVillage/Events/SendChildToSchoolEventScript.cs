using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SendChildToSchoolEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "School"; }
    }

    public override string Description
    {
        get
        {
            if (IncomeManager.Money < CostToPerform)
            {
                return "You do not have enough money to send " + ChildManager.SelectedChild.Name + " to school.";
            }

            return "Do you wish to send " + ChildManager.SelectedChild.Name + " to school so they will be more likely to earn money in the future? ( CFA " + CostToPerform.ToString() + " for books, equipment and uniform )";
        }
    }

    // $50 per child per year for equipment. ~ 7% of income of parent
    // Paid at beginning of year
    // Child locked in for an entire year
    // 70 children in class per average

    public override bool YesButtonEnabled { get { return IncomeManager.Money >= CostToPerform; } }
    public override string NoButtonText { get { return IncomeManager.Money >= CostToPerform ? "No" : "OK"; } }

    public override float CostToPerform { get { return 3075; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear; } }
    protected override string OnShowAudioClipPath { get { return "Audio/School"; } }

    public override BuildingType BuildingType { get { return BuildingType.School; } }
    protected override Vector3 BuildingLocation { get { return GameObject.Find("School").transform.position; } }

    public override string GetOnCompleteDescription(Child child)
    {
        if (child.Education == Child.MaxEducation)
        {
            return child.Name + " has completed education and left for a new a job in the city.  Money will be sent back to help out your family.";
        }
        return child.Name + " has studied hard all year and is closer towards a full education.";
    }

    protected override DataPacket GetDataPacketPerSecond(Child child)
    {
        return new DataPacket(
            Math.Min(50, Child.MaxEducation - child.Education) / LockTime,
            Math.Min(10, child.Health) / LockTime,
            Math.Min(10, child.Safety) / LockTime,
            Math.Min(25, child.Happiness) / LockTime);
    }
}