public class ReceiveIncomeEventScript : EventScript
{
    public override string Name
    {
        get { return "Income Received"; }
    }

    public override string Description
    {
        get
        {
            string income = "Your annual salary of CFA " + IncomeManager.CurrentIncome.ToString() + " has been paid.";
            if (ChildManager.ChildrenGraduated > 0)
            {
                income += "  Your children send you back CFA " + IncomeManager.IncomeFromChildren.ToString();
            }

            return income;
        }
    }

    public override bool NoButtonEnabled { get { return false; } }

    public override float TimeOut { get { return 4; } }

    protected override string OnShowAudioClipPath { get { return "Audio/Money"; } }

    protected override void OnNo()
    {
        base.OnNo();

        // It's weird I know, but No is used for OK
        IncomeManager.AddMoney(IncomeManager.CurrentIncome + IncomeManager.IncomeFromChildren);
    }
}