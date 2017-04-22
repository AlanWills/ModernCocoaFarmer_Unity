using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlagueOfBlackPodEventScript : EventScript
{
    private string description;
    public override string Description { get { return description; } }

    public override string Name { get { return "Plague of Black Pod"; } }

    private Child childAtFarm;

    public PlagueOfBlackPodEventScript(Child child)
    {
        childAtFarm = child;
        description = "Ripe pods fall to the ground, withered and useless.  Crop harvest has been halved and " + child.Name + " must stay at the farm another year";
    }

    protected override void OnNo()
    {
        base.OnNo();

        Child oldSelectedChild = ChildManager.SelectedChild;
        if (oldSelectedChild != null)
        {
            oldSelectedChild.IsSelected = false;
        }

        childAtFarm.IsSelected = true;

        new SendChildToWorkEventScript().Yes();

        childAtFarm.IsSelected = false;

        if (oldSelectedChild != null)
        {
            oldSelectedChild.IsSelected = true;
        }
    }
}