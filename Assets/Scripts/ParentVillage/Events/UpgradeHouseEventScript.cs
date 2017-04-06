using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class UpgradeHouseEventScript : InteractableBuildingEventScript
{
    public override string Description
    {
        get
        {
            return "Do you wish for your child to build an upgrade on your house? ( CFA " + Math.Abs(CostToPerform).ToString() + " )";
        }
    }

    // Different upgrades for your house in unlockable tiers - electricity, well, toilet
    // Child health deteriorates every year based on current health
    // These upgrades provide a passive health bonus (and maybe safety) every year and will eventually negate deterioration and even surpass it

    // House upgrade = $75?

    public override float CostToPerform { get { return 46125; } }
    protected override float LockTime { get { return 40; } }
    public override string OnCompleteDescription
    {
        get
        {
            return "Your child has finished upgrading your house with some cool stuff.";
        }
    }

    protected override void OnTimeComplete(Child child)
    {
        // Upgrade house somehow?
    }
}