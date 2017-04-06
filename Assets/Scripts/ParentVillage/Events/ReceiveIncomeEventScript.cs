public class ReceiveIncomeEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Your annual salary of CFA " + IncomeManager.CurrentIncome.ToString() + " has been paid";
        }
    }

    protected override void OnYes()
    {
        base.OnYes();

        IncomeManager.AddMoney(IncomeManager.CurrentIncome);
    }
}