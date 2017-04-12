public static class IncomeManager
{
    public enum IncomeLevel
    {
        kLow,
        kMedium,
        kHigh,
        kExcellent
    }

    public const float StartingMoney = 61500;
    public static float Money { get; private set; }
    public static IncomeLevel CurrentIncomeLevel { get; private set; }
    public static float CurrentIncome
    {
        get
        {
            switch (CurrentIncomeLevel)
            {
                case IncomeLevel.kExcellent:
                    return 615000;

                case IncomeLevel.kHigh:
                    return 461250;

                case IncomeLevel.kMedium:
                    return 307500;

                case IncomeLevel.kLow:
                    return 153750;

                default:
                    return 0;
            }

        }
    }
    public static float IncomeFromChildren { get { return 615000 * ChildManager.ChildrenGraduated; } }

    static IncomeManager()
    {
        Money = StartingMoney;
    }

    public static void AddMoney(float money)
    {
        Money += money;
    }

    public static void IncreaseIncomeLevel()
    {
        switch (CurrentIncomeLevel)
        {
            case IncomeLevel.kExcellent:
                CurrentIncomeLevel = IncomeLevel.kHigh;
                break;

            case IncomeLevel.kHigh:
                CurrentIncomeLevel = IncomeLevel.kMedium;
                break;

            case IncomeLevel.kMedium:
                CurrentIncomeLevel = IncomeLevel.kLow;
                break;

            case IncomeLevel.kLow:
                break;

            default:
                break;
        }
    }

    public static void DecreaseIncomeLevel()
    {
        switch (CurrentIncomeLevel)
        {
            case IncomeLevel.kExcellent:
                CurrentIncomeLevel = IncomeLevel.kHigh;
                break;

            case IncomeLevel.kHigh:
                CurrentIncomeLevel = IncomeLevel.kMedium;
                break;

            case IncomeLevel.kMedium:
                CurrentIncomeLevel = IncomeLevel.kLow;
                break;

            case IncomeLevel.kLow:
                break;

            default:
                break;
        }
    }
}