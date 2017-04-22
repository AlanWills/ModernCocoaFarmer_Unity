using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SendChildToMosqueEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "Mosque"; }
    }

    protected override string BuildingDescription
    {
        get
        {
            return "A spiritual place.";
        }
    }

    protected override string ChildSelectedDescription
    {
        get
        {
            return "Wealth is not from abundance of possessions.  Wealth is but from wealth of spirit.  - Quran";
        }
    }

    // Randomly the possibility that all your children will get a small safety, happiness and slight education boost (but nowhere near as much as school).
    // When one child completes some time here
    // Hopefully inspires the player to keep sending a child here to keep getting benefits to the family.

    public override string YesButtonText { get { return "Send Child"; } }
    protected override bool YesButtonEnabledImpl { get { return true; } }
    protected override string NoButtonTextImpl { get { return "Leave"; } }

    public override int CostToPerform { get { return 0; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear * 0.25f; } }
    protected override string OnShowAudioClipPath { get { return "Audio/Mosque"; } }

    public override BuildingType BuildingType { get { return BuildingType.Mosque; } }
    protected override Vector3 BuildingLocation { get { return GameObject.Find("Mosque").transform.position; } }

    public override string GetOnCompleteDescription(Child child)
    {
        return child.Name + " leaves the mosque and spreads happiness and wisdom to your family.";
    }

    protected override DataPacket GetDataPacketPerSecond(Child child)
    {
        return new DataPacket(
            2 / LockTime,
            0,
            3 / LockTime,
            5 / LockTime);
    }

    protected override void OnTimeComplete(Child child)
    {
        // Undo the incremental changes on this child
        child.Apply(new DataPacket(-2, 0, -3, -5));
        ChildManager.ApplyEventToAllChildren(new DataPacket(2, 0, 3, 5));
    }
}