namespace PaymentPlus
{
    public class CreditCardPayment : OnlinePayment
    {
        // String to not miss the leading zeroes
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }

        public CreditCardPayment(decimal paymentAmount, CurrencyType currency, string paymentGateway, string cardNumber, string expiryDate, string cVV) : base(paymentAmount, currency, paymentGateway)
        {
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            CVV = cVV;
        }

        public override void Authorize()
        {
            try
            {
                string lastFourDigits = StringHelper.GetLastFour(CardNumber.Trim());

                Console.WriteLine($"Authorizing credit card ending in {lastFourDigits} with {PaymentGateway}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public override bool ValidatePayment()
        {
            if (CardNumber.Trim().Length < 14)
            {
                throw new Exception("Card number is not valid. Must be at least 14 digits.");
            }

            // Used "_" to ignore/discard the output value of out
            if (!ValidationHelper.IsNumeric(CardNumber.Trim()))
            {
                throw new Exception("Card number must contain numbers only.");
            }

            if (!ValidationHelper.IsNumeric(CVV) || (CVV.Length != 3 && CVV.Length != 4))
            {
                throw new Exception("CVV must be 3 or 4 digits.");
            }

            base.ValidatePayment();
            if (PaymentAmount < 10.00m && Currency == CurrencyType.EUR)
            {
                throw new Exception($"Euro transactions must be at least 10.00");
            }
            return true;
        }

        public override void LogPayment()
        {
            string lastFourDigits = StringHelper.GetLastFour(CardNumber.Trim());

            base.LogPayment();
            Console.WriteLine($"Paid with card ending in {lastFourDigits}");
        }
    }
}
