using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableBuildingEventScript : EventScript
{
    public override string YesButtonText { get { return "Yes"; } }
    public override bool NoButtonEnabled { get { return true; } }

    public abstract float CostToPerform { get; }
    public abstract string OnCompleteDescription { get; }

    protected abstract float LockTime { get; }
    protected List<Child> LockedInChildren = new List<Child>();
    protected List<float> Timers = new List<float>();

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.AddMoney(-CostToPerform);

        Child child = ChildManager.FindChild(x => x.IsSelected);
        child.IsLocked = true;

        LockedInChildren.Add(ChildManager.FindChild(x => x.IsSelected));
        Timers.Add(0);
    }
    
    public void Update()
    {
        List<int> childrenToRemoveIndexes = new List<int>();
        
        // Go through and update children locked in time
        for (int i = 0; i < Timers.Count; ++i)
        {
            Timers[i] += Time.deltaTime;

            if (Timers[i] > LockTime)
            {
                LockedInChildren[i].IsLocked = false;
                childrenToRemoveIndexes.Add(i);
            }
        }
        
        foreach (int childIndex in childrenToRemoveIndexes)
        {
            Child child = LockedInChildren[childIndex];
            LockedInChildren.RemoveAt(childIndex);
            Timers.RemoveAt(childIndex);

            OnTimeComplete(child);
            GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>().QueueEvent(new TaskCompleteScript(OnCompleteDescription));
        }
    }

    protected abstract void OnTimeComplete(Child child);
}