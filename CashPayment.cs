namespace PaymentPlus
{
    public class CashPayment : OfflinePayment
    {
        public CashPayment(decimal paymentAmount, CurrencyType currency) : base(paymentAmount, currency) { }

        public override void RecordPayment()
        {
            Console.WriteLine($"Recording cash payment of {PaymentAmount} {Currency}");
        }

        public override bool ValidatePayment()
        {
            if (Currency == CurrencyType.EUR)
            {
                throw new Exception("Euro transactions are not allowed.");
            }

            return true;
        }

        public override void LogPayment()
        {
            base.LogPayment();
            Console.WriteLine($"Paid using cash.");
        }
    }
}
