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

    public override float TimeOut { get { return 4; } }

    protected override void OnNo()
    {
        base.OnNo();

        IncomeManager.DecreaseIncomeLevel();
    }
}