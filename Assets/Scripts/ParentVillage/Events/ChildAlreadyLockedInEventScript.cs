using System;

public class ChildAlreadyLockedInEventScript : EventScript
{
    public override string Description
    {
        get { return "The child you currently have selected is busy elsewhere."; }
    }
}