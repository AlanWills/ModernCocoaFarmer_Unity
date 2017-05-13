using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FightingBreaksOutEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Fighting has broken out amongst local militia.  No-one in the village is safe.";
        }
    }

    public override string Name { get { return "Fighting Breaks Out"; } }

    protected override void OnNo()
    {
        base.OnNo();

        ChildManager.ApplyEventToAllChildren(new DataPacket(0, -40, 0, 0));
    }
}