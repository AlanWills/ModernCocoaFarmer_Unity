using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class NotificationScript
{
    public abstract string Title { get; }
    public abstract string Description { get; }
    public virtual void OnShow() { }
}