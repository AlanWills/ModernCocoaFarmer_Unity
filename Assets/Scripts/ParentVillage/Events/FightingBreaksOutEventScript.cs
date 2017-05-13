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

    public override bool NoDataImplemented { get { return true; } }
    public override string HealthDeltaNoText { get { return "No change"; } }
    public override string SafetyDeltaNoText { get { return "-40% for all children"; } }
    public override string EducationDeltaNoText { get { return "No change"; } }
    public override string HappinessDeltaNoText { get { return "No change"; } }

    protected override void OnNo()
    {
        base.OnNo();

        ChildManager.ApplyEventToAllChildren(new DataPacket(0, -40, 0, 0));
    }
}