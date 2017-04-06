using System;

public class ChildLeftHomeEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Your home has become overcrowded and so one of your children has left for another village to make room.";
        }
    }

    protected override void OnYes()
    {
        base.OnYes();

        // Since this event is fired when a child cap is reached from a new child, we do not include the last child
        Random random = new Random();
        ChildManager.RemoveChild(random.Next(0, ChildManager.MaxChildCount - 1));
    }
}