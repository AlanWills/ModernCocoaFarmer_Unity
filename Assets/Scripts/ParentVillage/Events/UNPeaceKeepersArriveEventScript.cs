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

    public override bool NoDataImplemented { get { return true; } }
    public override string HealthDeltaNoText { get { return "No change"; } }
    public override string SafetyDeltaNoText { get { return "+80% for all children"; } }
    public override string EducationDeltaNoText { get { return "No change"; } }
    public override string HappinessDeltaNoText { get { return "No change"; } }

    protected override void OnNo()
    {
        base.OnNo();

        ChildManager.ApplyEventToAllChildren(new DataPacket(0, 80, 0, 0));
    }
}