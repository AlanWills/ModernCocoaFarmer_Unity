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

    protected override void OnNo()
    {
        base.OnNo();

        ChildManager.ApplyEventToAllChildren(new DataPacket(0, 0, 80, 0));
    }
}