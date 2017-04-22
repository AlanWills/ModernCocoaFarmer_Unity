using System;

public class ChildLeftHomeEventScript : EventScript
{
    public override string Name
    {
        get { return "Child Left Home"; }
    }

    public override string Description
    {
        get
        {
            return "Your home has become overcrowded and so " + childThatWillLeave.Name + " has left for another village to make room.";
        }
    }

    public override float TimeOut { get { return 4; } }

    private Child childThatWillLeave;

    public ChildLeftHomeEventScript()
    {
        // Since this event is fired when a child cap is reached from a new child, we do not include the last child
        Random random = new Random();
        childThatWillLeave = ChildManager.GetChild(random.Next(0, ChildManager.MaxChildCount - 1));
    }

    protected override void OnNo()
    {
        base.OnNo();

        ChildManager.RemoveChild(childThatWillLeave);
    }
}