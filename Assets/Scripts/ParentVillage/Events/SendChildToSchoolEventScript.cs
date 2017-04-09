using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SendChildToSchoolEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "School"; }
    }

    public override string Description
    {
        get
        {
            if (IncomeManager.Money < CostToPerform)
            {
                return "You do not have enough money to send your child to school.";
            }

            return "Do you wish to send your child to school so they will be more likely to earn money in the future? ( CFA " + CostToPerform.ToString() + " for books, equipment and uniform )";
        }
    }

    // $50 per child per year for equipment. ~ 7% of income of parent
    // Paid at beginning of year
    // Child locked in for an entire year
    // 70 children in class per average

    public override string YesButtonText { get { return IncomeManager.Money >= CostToPerform ? "Yes" : "OK"; } }
    public override bool NoButtonEnabled { get { return IncomeManager.Money >= CostToPerform; } }

    public override float CostToPerform { get { return 3075; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear; } }
    public override string OnCompleteDescription
    {
        get
        {
            return "Your child has studied hard all year.";
        }
    }

    protected override void OnTimeComplete(Child child)
    {
        child.Apply(new DataPacket(10, 10, 50, 25));
    }
}