using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SendChildToWorkEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "Farm"; }
    }

    public override string Description
    {
        get
        {
            return "Do you wish to send your child to work to earn money for the family.";
        }
    }

    // Child gets money at the end, but also always happiness cost, always health cost and slim chance of trafficking
    // Child earns $190 per year
    // 5% are actually paid - see how this fits with the game
    // Child locked in for a year

    private const float Salary = 116850;

    // Every 20 times, the player is guaranteed a pay out
    private static int numberOfTimesSent = 0;
    private static bool childPaid = false;
    
    public override float CostToPerform { get { return 0; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear; } }
    public override string OnCompleteDescription
    {
        get
        {
            if (childPaid)
            {
                return "Your child completes a hard year at the cocoa farm and is paid CFA " + Salary.ToString() + ".";
            }
            return "Your child completes a hard year at the cocoa farm, but receives no money.  Not all children get paid.";
        }
    }

    protected override void OnTimeComplete(Child child)
    {
        numberOfTimesSent++;
        child.Apply(new DataPacket(0, -50, -50, -50));

        Random random = new Random();
        childPaid = random.NextDouble() >= 0.95f;

        if (numberOfTimesSent == 20)
        {
            childPaid = true;
            numberOfTimesSent = 0;
        }

        if (childPaid)
        {
            IncomeManager.AddMoney(Salary);
        }
    }
}