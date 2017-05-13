using UnityEngine;

public class ReceiveIncomeNotificationScript : NotificationScript
{
    public override string Title
    {
        get { return "Income Received"; }
    }

    public override string Description
    {
        get
        {
            string income = "Your husband's annual salary of CFA " + IncomeManager.CurrentIncome.ToString() + " has been paid.";
            if (ChildManager.ChildrenGraduated > 0)
            {
                income += "  Your children send you back CFA " + IncomeManager.IncomeFromChildren.ToString();
            }

            return income;
        }
    }

    public override AudioClip OnShowAudioClip { get { return Resources.Load<AudioClip>("Audio/Money"); } }

    protected override void OnShow()
    {
        base.OnShow();

        IncomeManager.AddMoney(IncomeManager.CurrentIncome + IncomeManager.IncomeFromChildren);
    }
}