using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NewJobEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Your husband's pay has been increased.";
        }
    }

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.IncreaseIncomeLevel();
    }
}