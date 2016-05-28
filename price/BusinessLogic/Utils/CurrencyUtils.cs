namespace BusinessLogic.Utils
{
    public static class CurrencyUtils
    {
        public static readonly decimal EurToLtl = 3.4528m;
        public static readonly decimal LtlToEur = 0.2896m;

        public static decimal ConvertToEur(decimal amountInLtl)
        {
            return amountInLtl * LtlToEur;
        }
    }
}
