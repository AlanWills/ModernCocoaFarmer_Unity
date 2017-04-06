public class ReceiveIncomeEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Your annual salary of CFA " + IncomeYes.ToString() + " has been paid";
        }
    }

    public override string YesButtonText { get { return "OK"; } }
    public override bool NoButtonEnabled { get { return false; } }

    public override float EducationYes { get { return 0; } }
    public override float IncomeYes { get { return IncomeManager.CurrentIncome; } }
    public override float HealthYes { get { return 0; } }
    public override float SafetyYes { get { return 0; } }
    public override float HappinessYes { get { return 0; } }

    public override float EducationNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return 0; } }
    public override float HealthNo { get { return 0; } }
    public override float HappinessNo { get { return 0; } }
}