﻿using System;
using UnityEngine;

public class ChildTraffickedEventScript : EventScript
{
    public override string Name
    {
        get { return "Child Trafficked"; }
    }

    public override string Description
    {
        get
        {
            if (IncomeManager.Money < Cost)
            {
                return childThatWillBeTaken.Name + " has been taken by an illegal trafficker.  You will never see him again.";
            }
            return childThatWillBeTaken.Name + " has been taken by an illegal trafficker.  Do you want to inform the Police? ( CFA " + Cost.ToString() + " )";
        }
    }

    public override bool YesButtonEnabled { get { return IncomeManager.Money >= Cost; } }
    public override string NoButtonText { get { return IncomeManager.Money >= Cost ? "No" : "OK"; } }
    protected override string OnShowAudioClipPath { get { return "Audio/ChildTrafficked"; } }
    protected override string OnYesAudioClipPath { get { return "Audio/Money"; } }
    protected override string OnNoAudioClipPath { get { return "Audio/Death"; } }

    private const int Cost = 615000;
    private Child childThatWillBeTaken;

    private static int childrenTrafficked = 0;

    // Yes = pay income for die-roll chance of recovering child; mention income cost in description
    // No = no-op

    public ChildTraffickedEventScript(Child child)
    {
        childThatWillBeTaken = child;
    }

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.AddMoney(-Cost);

        if (UnityEngine.Random.Range(0.0f, 1.0f) >= 0.2)
        {
            TrafficChild(childThatWillBeTaken);
        }
    }

    protected override void OnNo()
    {
        base.OnNo();

        TrafficChild(childThatWillBeTaken);
    }

    private void TrafficChild(Child child)
    {
        childrenTrafficked++;
        ChildManager.RemoveChild(childThatWillBeTaken);

        if (childrenTrafficked == 3)
        {
            GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>().QueueEvent(new UNPeaceKeepersArriveEventScript());
        }
    }
}