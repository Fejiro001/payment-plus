namespace PaymentPlus
{
    // Utility class to get last four alphanumeric/numeric characters in a string
    public static class StringHelper
    {
        public static string GetLastFour(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            // If input is shorter than or equal to 4 characters return it as-is.
            if (input.Length <= 4)
            {
                return input;
            }

            return input.Substring(input.Length - 4);
        }
    }
}
