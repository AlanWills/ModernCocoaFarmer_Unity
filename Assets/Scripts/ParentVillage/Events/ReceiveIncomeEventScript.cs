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
            return "Your annual salary of CFA " + IncomeManager.CurrentIncome.ToString() + " has been paid";
        }
    }

    protected override string OnShowAudioClipPath { get { return "Audio/Money"; } }

    protected override void OnNo()
    {
        base.OnNo();

        // It's weird I know, but No is used for OK
        IncomeManager.AddMoney(IncomeManager.CurrentIncome);
    }
}