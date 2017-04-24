using System;
using UnityEngine;

public class SendChildToWorkEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "Cocoa Farm"; }
    }

    protected override string BuildingDescription
    {
        get { return "The fields stretch for miles under the burning sun."; }
    }

    protected override string ChildSelectedDescription
    {
        get
        {
            return "Do you wish to send " + ChildManager.SelectedChild.Name + " to work to earn money for the family?";
        }
    }

    // Child gets money at the end, but also always happiness cost, always health cost and slim chance of trafficking
    // Child earns $190 per year
    // 5% are actually paid - see how this fits with the game
    // Child locked in for a year

    private const int Salary = 116850;

    // Every 20 times, the player is guaranteed a pay out
    private static int numberOfTimesSent = 0;
    private static bool childPaid = false;

    protected override bool YesButtonEnabledImpl { get { return true; } }
    protected override string NoButtonTextImpl { get { return "No"; } }
    public override int CostToPerform { get { return 0; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear; } }
    protected override string OnShowAudioClipPath { get { return "Audio/Work"; } }

    public override BuildingType BuildingType { get { return BuildingType.Work; } }
    protected override Vector3 BuildingLocation { get { return GameObject.Find("Farm").transform.position; } }

    public override bool ConfirmEventQueued(Child selectedChild)
    {
        // 1 in 4 chance to perform a trafficking check
        if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.75f && RandomEventGenerator.IsChildTrafficked(selectedChild))
        {
            return false;
        }

        return base.ConfirmEventQueued(selectedChild);
    }

    public override string GetOnCompleteDescription(Child child)
    {
        if (childPaid)
        {
            return child.Name + " completes a hard year at the cocoa farm and is paid CFA " + ((int)(Salary * (1 + (child.Education * 0.01f)))).ToString() + ".";
        }
        return child.Name + " completes a hard year at the cocoa farm, but receives no money.  Not all children get paid.";
    }

    protected override DataPacket GetDataPacketPerSecond(Child child)
    {
        return new DataPacket(
            0, 
            -50 / LockTime, 
            -50 / LockTime, 
            -50 / LockTime);
    }

    protected override void OnTimeComplete(Child child)
    {
        base.OnTimeComplete(child);

        if (UnityEngine.Random.Range(0.0f, 1.0f) >= 0.9f)
        {
            // Dont increment number of times sent, and don't pay the child
            childPaid = false;
            GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>().QueueEvent(new PlagueOfBlackPodEventScript(child));
            return;
        }

        numberOfTimesSent++;

        childPaid = UnityEngine.Random.Range(0.0f, 1.0f) >= 0.95f;

        if (numberOfTimesSent == 20)
        {
            childPaid = true;
            numberOfTimesSent = 0;
        }

        if (childPaid)
        {
            IncomeManager.AddMoney((int)(Salary * (1 + (child.Education * 0.01f))));
        }
    }
}