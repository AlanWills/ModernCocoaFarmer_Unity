using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class NotificationScript
{
    public abstract string Title { get; }
    public abstract string Description { get; }
    public virtual AudioClip OnShowAudioClip { get { return null; } }

    protected virtual void OnShow() { }

    public void Show()
    {
    }
}