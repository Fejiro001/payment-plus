namespace PaymentPlus
{
    // Defined outside the class for easier access
    public enum CurrencyType { CAD, USD, EUR }
    public abstract class Payment
    {
        // decimal data type is better used for financial/monetary values
        public decimal PaymentAmount { get; set; }
        public CurrencyType Currency { get; set; }

        public Payment(decimal paymentAmount, CurrencyType currency)
        {
            PaymentAmount = paymentAmount;
            Currency = currency;
        }

        public abstract void ProcessPayment();

        public virtual bool ValidatePayment()
        {
            if (PaymentAmount <= 0)
            {
                throw new Exception("Payments must be greater than zero.");
            }

            bool endsWith99 = (PaymentAmount % 1.00m) == 0.99m;

            if (endsWith99)
            {
                throw new Exception("Cannot accept payments ending with .99.");
            }
            return true;
        }
        public virtual void LogPayment()
        {
            Console.WriteLine($"\n[Transaction: {PaymentAmount} {Currency}]");
        }
    }
}
