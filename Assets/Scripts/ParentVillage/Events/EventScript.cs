using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventScript
{
    public abstract string Description { get; }

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

    public void Yes()
    {
        ChildManager.ApplyEvent(
            new DataPacket(EducationYes, IncomeYes, HealthYes, SafetyYes, HappinessYes));
    }

    public void No()
    {
        ChildManager.ApplyEvent(
            new DataPacket(EducationNo, IncomeNo, HealthNo, SafetyNo, HappinessNo));
    }
}
