using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UpgradeHouseEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "Home"; }
    }

    protected override string BuildingDescription
    {
        get { return "No place like it."; }
    }

    protected override string ChildSelectedDescription
    {
        get
        {
            return "Would you like to upgrade your house? ( CFA " + Math.Abs(CostToPerform).ToString() + " )";
        }
    }

    // Different upgrades for your house in unlockable tiers - electricity, well, toilet
    // Child health deteriorates every year based on current health
    // These upgrades provide a passive health bonus (and maybe safety) every year and will eventually negate deterioration and even surpass it

    // House upgrade = $75?

    protected override bool YesButtonEnabledImpl { get { return true; } }
    protected override string NoButtonTextImpl { get { return "No"; } }
    public override float CostToPerform { get { return 46125; } }
    protected override float LockTime { get { return 40; } }
    protected override string OnShowAudioClipPath { get { return "Audio/Home"; } }

    public override BuildingType BuildingType { get { return BuildingType.Home; } }
    protected override Vector3 BuildingLocation { get { return GameObject.Find("Home").transform.position; } }

    public override string GetOnCompleteDescription(Child child)
    {
        return "The upgrade to your house has been completed.";
    }

    protected override DataPacket GetDataPacketPerSecond(Child child)
    {
        return new DataPacket(0, 0, 0, 0);
    }

    protected override void OnTimeComplete(Child child)
    {
        // Upgrade house somehow?
    }
}