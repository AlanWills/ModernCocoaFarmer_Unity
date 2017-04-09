using System;

public class TaskCompleteScript : EventScript
{
    public override string Name
    {
        get { return ""; }
    }

    private string description;
    public override string Description { get { return description; } }

    public TaskCompleteScript(string taskCompletedDescription)
    {
        description = taskCompletedDescription;
    }
}