using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SendChildToWorkEventScript : InteractableBuildingEventScript
{
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
    
    public override float CostToPerform { get { return 0; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear; } }
    public override string OnCompleteDescription
    {
        get
        {
            return "Your child completes a hard year at the cocoa farm.";
        }
    }

    protected override void OnTimeComplete(Child child)
    {
        child.Apply(new DataPacket(0, -50, -50, -50));

        Random random = new Random();
        if (random.NextDouble() >= 0.95f)
        {
            IncomeManager.AddMoney(Salary);
        }
    }
}