using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SalaryIncreasedEventScript : EventScript
{
    public override string Name
    {
        get { return "Pay Increase"; }
    }

    public override string Description
    {
        get
        {
            return "Your husband's pay has been increased.";
        }
    }

    public override float TimeOut { get { return 4; } }

    protected override void OnNo()
    {
        base.OnNo();

        IncomeManager.IncreaseIncomeLevel();
    }
}