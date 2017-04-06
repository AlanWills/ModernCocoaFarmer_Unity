using System;

public class TaskCompleteScript : EventScript
{
    private string description;
    public override string Description { get { return description; } }

    public TaskCompleteScript(string taskCompletedDescription)
    {
        description = taskCompletedDescription;
    }
}