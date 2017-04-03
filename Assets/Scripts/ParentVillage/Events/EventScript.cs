using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventScript
{
    public abstract string Description { get; }
    public virtual string YesButtonText { get { return "Yes"; } }
    public virtual string NoButtonText { get { return "No"; } }
    public virtual bool YesButtonEnabled { get { return true; } }
    public virtual bool NoButtonEnabled { get { return true; } }

    public abstract float EducationYes { get; }
    public abstract float IncomeYes { get; }
    public abstract float HealthYes { get; }
    public abstract float SafetyYes { get; }
    public abstract float HappinessYes { get; }

    public abstract float EducationNo { get; }
    public abstract float IncomeNo { get; }
    public abstract float HealthNo { get; }
    public abstract float SafetyNo { get; }
    public abstract float HappinessNo { get; }

    // Each building event will 'lock' in the child you send for a set amount of time
    // Once this time elapses, you will be free to send the child elsewhere, or maybe instead they automatically return home
    // I also want the values to be applied at the end of the time, but is this appropriate for all the events?  I think so.
    // You can also send any number of children anywhere - i.e. send all your children to the mosque.

    // Yes No button enabled flags (some events will not need both or either)
    // 614.79 CFA francs = 1 US.

    public void Yes()
    {
        OnYes();

        ChildManager.ApplyEvent(
            new DataPacket(EducationYes, IncomeYes, HealthYes, SafetyYes, HappinessYes));
    }

    protected virtual void OnYes()
    {

    }

    public void No()
    {
        OnNo();

        ChildManager.ApplyEvent(
            new DataPacket(EducationNo, IncomeNo, HealthNo, SafetyNo, HappinessNo));
    }

    protected virtual void OnNo()
    {

    }
}
