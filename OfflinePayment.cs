namespace PaymentPlus
{
    public abstract class OfflinePayment : Payment
    {
        public OfflinePayment(decimal paymentAmount, CurrencyType currency) : base(paymentAmount, currency) { }

        public abstract void RecordPayment();

        public override void ProcessPayment()
        {
            Console.WriteLine($"This was an offline payment of {PaymentAmount} {Currency}.");
        }

        public override bool ValidatePayment()
        {
            if (Currency == CurrencyType.EUR)
            {
                throw new Exception("Euro transactions are not allowed.");
            }

            return base.ValidatePayment();
        }

        public override void LogPayment()
        {
            base.LogPayment();
            Console.WriteLine($"Processed an offline payment.");
        }
    }
}
