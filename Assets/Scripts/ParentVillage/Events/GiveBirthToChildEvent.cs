using UnityEngine;

public class GiveBirthToChildEvent : EventScript
{
    private const int Threshold = 3;

    public override string Name
    {
        get { return ChildManager.ChildCount <= Threshold ? "Birth" : "Pregnancy"; }
    }

    public override string Description
    {
        get
        {
            if (ChildManager.ChildCount <= Threshold)
            {
                return "You've had a baby.";
            }

            return "You have become pregnant again, do you wish to keep the child?";
        }
    }

    public override float TimeOut { get { return ChildManager.ChildCount > Threshold ? float.MaxValue : 4; } }
    public override bool YesButtonEnabled { get { return ChildManager.ChildCount > Threshold; } }
    public override string NoButtonText { get { return ChildManager.ChildCount > Threshold ? "No" : "OK"; } }
    protected override string OnShowAudioClipPath { get { return ChildManager.ChildCount <= Threshold ? "Audio/Birth" : null; } }
    protected override string OnYesAudioClipPath { get { return "Audio/Birth"; } }
    protected override string OnNoAudioClipPath { get { return ChildManager.ChildCount > Threshold ? "Audio/Death" : null; } }

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