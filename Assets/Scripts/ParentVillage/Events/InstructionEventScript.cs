using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InstructionEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Click on the icons to find out more about the buildings in Zeguoa.";
        }
    }

    public override string Name { get { return "Tip"; } }
    public override float TimeOut { get { return 4; } }
}