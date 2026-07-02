namespace PaymentPlus
{
    public static class ValidationHelper
    {
        public static bool IsNumeric(string input)
        {
            return long.TryParse(input, out _);
        }
    }
}
