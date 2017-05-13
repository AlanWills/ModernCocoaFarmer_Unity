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

    public override bool DataImplemented { get { return true; } }
    public override DataType EventDataType { get { return DataType.kNo; } }
    public override string HealthDeltaText { get { return "No change"; } }
    public override string SafetyDeltaText { get { return "-40% for all children"; } }
    public override string EducationDeltaText { get { return "No change"; } }
    public override string HappinessDeltaText { get { return "No change"; } }

    protected override void OnNo()
    {
        base.OnNo();

        ChildManager.ApplyEventToAllChildren(new DataPacket(0, -40, 0, 0));
    }
}