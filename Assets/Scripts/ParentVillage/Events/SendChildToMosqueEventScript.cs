using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SendChildToMosqueEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "Mosque"; }
    }

    public override string Description
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
    public override string NoButtonText { get { return "Leave"; } }
    public override float CostToPerform { get { return 0; } }
    protected override float LockTime { get { return 30; } }
    public override string OnCompleteDescription
    {
        get
        {
            return "Your child leaves the mosque and spreads happiness and wisdom to your family.";
        }
    }

    protected override void OnTimeComplete(Child child)
    {
        ChildManager.ApplyEventToAllChildren(new DataPacket(2, 0, 3, 5));
    }
}