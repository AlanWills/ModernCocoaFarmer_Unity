using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SalaryDecreasedEventScript : EventScript
{
    public override string Name
    {
        get { return "Pay Cut"; }
    }

    public override string Description
    {
        get
        {
            return "Your husband's pay has been decreased.";
        }
    }

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.DecreaseIncomeLevel();
    }
}