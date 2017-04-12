using UnityEngine;

public class GiveBirthToChildEvent : EventScript
{
    public override string Name
    {
        get { return ChildManager.ChildCount <= 5 ? "Birth" : "Pregnancy"; }
    }

    public override string Description
    {
        get
        {
            if (ChildManager.ChildCount <= 5)
            {
                return "You've had a baby.";
            }

            return "You have become pregnant, do you wish to keep the child?";
        }
    }

    public override bool YesButtonEnabled { get { return ChildManager.ChildCount > 5; } }
    public override string NoButtonText { get { return ChildManager.ChildCount > 5 ? "No" : "OK"; } }
    protected override string OnShowAudioClipPath { get { return ChildManager.ChildCount <= 5 ? "Audio/Birth" : null; } }
    protected override string OnYesAudioClipPath { get { return "Audio/Birth"; } }
    protected override string OnNoAudioClipPath { get { return ChildManager.ChildCount > 5 ? "Audio/Death" : null; } }

    protected override void OnYes()
    {
        ChildManager.AddChild();

        if (ChildManager.ChildCount > ChildManager.MaxChildCount)
        {
            // If this child brings us over the max, we queue an event about the child leaving home
            GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>().QueueEvent(new ChildLeftHomeEventScript());
        }
    }

    protected override void OnNo()
    {
        if (!YesButtonEnabled)
        {
            OnYes();
        }
        else
        {
            base.OnNo();

            GameObject.Find("Graves").GetComponent<GraveCreatorScript>().CreateGrave();
        }
    }
}