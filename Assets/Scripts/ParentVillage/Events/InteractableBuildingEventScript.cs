using System;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    Idle,
    Home,
    Mosque,
    Work,
    School,
    Hospital,
    Market
}

public abstract class InteractableBuildingEventScript : EventScript
{
    public override string YesButtonText { get { return "Yes"; } }
    public override bool NoButtonEnabled { get { return true; } }

    public abstract float CostToPerform { get; }
    public abstract BuildingType BuildingType { get; }

    protected abstract float LockTime { get; }
    protected List<Child> LockedInChildren = new List<Child>();
    protected List<float> Timers = new List<float>();
    protected List<float> Tickers = new List<float>();

    public abstract string GetOnCompleteDescription(Child child);
    protected abstract DataPacket GetDataPacketPerSecond(Child child);
    protected virtual void OnTimeComplete(Child child) { }

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.AddMoney(-CostToPerform);

        Child child = ChildManager.SelectedChild;
        child.LockIn(BuildingType);

        LockedInChildren.Add(child);
        Timers.Add(0);
        Tickers.Add(0);
    }
    
    public void Update()
    {
        List<int> childrenToRemoveIndexes = new List<int>();
        
        // Go through and update children locked in time
        for (int i = 0; i < Timers.Count; ++i)
        {
            Timers[i] += Time.deltaTime;
            Tickers[i] += Time.deltaTime;

            if (Tickers[i] >= 1)
            {
                Tickers[i] = 0;
                LockedInChildren[i].Apply(GetDataPacketPerSecond(LockedInChildren[i]));
            }

            if (Timers[i] > LockTime)
            {
                LockedInChildren[i].LockIn(BuildingType.Idle);
                childrenToRemoveIndexes.Add(i);
            }
        }
        
        foreach (int childIndex in childrenToRemoveIndexes)
        {
            Child child = LockedInChildren[childIndex];
            LockedInChildren.RemoveAt(childIndex);
            Timers.RemoveAt(childIndex);
            Tickers.RemoveAt(childIndex);

            if (child.Health > 0)
            {
                // If they are still alive, we should trigger the on complete behaviour
                OnTimeComplete(child);
                GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>().QueueEvent(new TaskCompleteScript(GetOnCompleteDescription(child)));
            }
        }
    }
}