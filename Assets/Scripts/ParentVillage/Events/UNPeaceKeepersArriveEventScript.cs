using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class UNPeaceKeepersArriveEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "UN Peace Keepers arrive in the village to assist with ensuring everyone's safety.";
        }
    }

    public override string Name { get { return "UN Peace Keepers Arrive"; } }

    public override bool DataImplemented { get { return true; } }
    public override DataType EventDataType { get { return DataType.kNo; } }
    public override string HealthDeltaText { get { return "No change"; } }
    public override string SafetyDeltaText { get { return "+80% for all children"; } }
    public override string EducationDeltaText { get { return "No change"; } }
    public override string HappinessDeltaText { get { return "No change"; } }

    protected override void OnNo()
    {
        base.OnNo();

        ChildManager.ApplyEventToAllChildren(new DataPacket(0, 80, 0, 0));
    }
}