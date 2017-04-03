using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GiveBirthToChildEvent : EventScript
{
    public override string Description
    {
        get
        {
            return "You've had a baby lol.";
        }
    }

    // Up to five children inclusive (out of a max of seven), it's "Congratulations, you've had a new baby." with no options.
    // After that, it's "You have become pregnant, do you wish to keep the child?"
    // When they reach the cap, the same text appears as for after 5, but then if they hit yes a popup appears and says "Another of your children has realised that you cannot support them all and has left for another village to make room".

    public override float EducationYes { get { return 0; } }
    public override float HappinessYes { get { return 0; } }
    public override float SafetyYes { get { return 0; } }
    public override float HealthYes { get { return 0; } }
    public override float IncomeYes { get { return 0; } }
    
    public override float EducationNo { get { return 0; } }
    public override float HappinessNo { get { return 0; } }
    public override float HealthNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return 0; } }
    
    protected override void OnYes()
    {
        ChildManager.AddChild();
    }
}