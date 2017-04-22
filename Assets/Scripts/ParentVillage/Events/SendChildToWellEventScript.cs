using System;
using UnityEngine;

public class SendChildToWellEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "Well"; }
    }

    protected override string BuildingDescription
    {
        get { return "The well is a rare source of water."; }
    }

    protected override string ChildSelectedDescription
    {
        get
        {
            return "Do you wish to send " + ChildManager.SelectedChild.Name + " to the well to collect water?";
        }
    }
    
    protected override bool YesButtonEnabledImpl { get { return true; } }
    protected override string NoButtonTextImpl { get { return "No"; } }
    public override float CostToPerform { get { return 0; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear / 6.0f; } }

    public override BuildingType BuildingType { get { return BuildingType.Well; } }
    protected override Vector3 BuildingLocation { get { return GameObject.Find("Well").transform.position; } }

    public override bool ConfirmEventQueued()
    {
        // Always perform a trafficking check here
        if (RandomEventGenerator.IsChildTrafficked(ChildManager.SelectedChild))
        {
            return false;
        }

        return base.ConfirmEventQueued();
    }

    public override string GetOnCompleteDescription(Child child)
    {
        return child.Name + " collects water for your family.";
    }

    protected override DataPacket GetDataPacketPerSecond(Child child)
    {
        return new DataPacket(0, 0, 0, 0);
    }

    protected override void OnTimeComplete(Child child)
    {
        base.OnTimeComplete(child);

        ChildManager.ApplyEventToAllChildren(new DataPacket(0, 10, 0, 10));
    }
}