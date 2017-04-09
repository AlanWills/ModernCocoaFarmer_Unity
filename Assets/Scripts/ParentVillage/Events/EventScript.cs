using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventScript
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public virtual string YesButtonText { get { return "OK"; } }
    public virtual string NoButtonText { get { return "No"; } }
    public virtual bool YesButtonEnabled { get { return true; } }
    public virtual bool NoButtonEnabled { get { return false; } }

    public void Yes()
    {
        OnYes();
        
    }

    protected virtual void OnYes() { }

    public void No()
    {
        OnNo();
    }

    protected virtual void OnNo() { }
}
