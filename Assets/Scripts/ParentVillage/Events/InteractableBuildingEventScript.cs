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
    Market,
    Well
}

public abstract class InteractableBuildingEventScript : EventScript
{
    public sealed override string Description
    {
        get
        {
            return ChildManager.SelectedChild == null ? BuildingDescription + "\n\nSelect a child using the icons at the top and click on this building to send them here."
                : ChildSelectedDescription;
        }
    }

    protected abstract string ChildSelectedDescription { get; }
    protected abstract string BuildingDescription { get; }

    public sealed override bool YesButtonEnabled
    {
        get
        {
            return ChildManager.SelectedChild == null ? false : YesButtonEnabledImpl;
        }
    }

    protected abstract bool YesButtonEnabledImpl { get; }

    public sealed override string NoButtonText
    {
        get
        {
            return ChildManager.SelectedChild == null ? "OK" : NoButtonTextImpl;
        }
    }

    protected abstract string NoButtonTextImpl { get; }

    public abstract int CostToPerform { get; }
    public abstract BuildingType BuildingType { get; }
    protected abstract Vector3 BuildingLocation { get; }

    protected abstract float LockTime { get; }
    protected List<Child> LockedInChildren = new List<Child>();
    protected List<float> Timers = new List<float>();
    protected List<float> Tickers = new List<float>();

    public abstract string GetOnCompleteDescription(Child child);
    protected abstract DataPacket GetDataPacketPerSecond(Child child);
    protected virtual void OnTimeComplete(Child child) { }

    public virtual bool ConfirmEventQueued(Child selectedChild)
    {
        return true;
    }

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.AddMoney(-CostToPerform);

        Child child = ChildManager.SelectedChild;
        child.LockIn(BuildingType);

        LockedInChildren.Add(child);
        Timers.Add(0);
        Tickers.Add(0);

        GameObject.Find("Home").GetComponent<ChildVillagerCreatorScript>().CreateChildVillager(BuildingLocation);
    }
    
    public void Update()
    {
        List<int> childrenToRemoveIndexes = new List<int>();
        
        // Go through and update children locked in time
        for (int i = 0; i < Timers.Count; ++i)
        {
            Timers[i] += TimeManager.DeltaTime;
            Tickers[i] += TimeManager.DeltaTime;

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