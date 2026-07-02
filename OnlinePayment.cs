namespace PaymentPlus
{
    public abstract class OnlinePayment : Payment
    {
        public string PaymentGateway { get; set; }

        public OnlinePayment(decimal paymentAmount, CurrencyType currency, string paymentGateway) : base(paymentAmount, currency)
        {
            PaymentGateway = paymentGateway;
        }

        public abstract void Authorize();

        public override void ProcessPayment()
        {
            Console.WriteLine($"This was an online payment of {PaymentAmount} {Currency}.");
        }

        public override bool ValidatePayment()
        {
            base.ValidatePayment();
            if (PaymentAmount <= 5.00m)
            {
                throw new Exception("Transaction must be greater than 5.00");
            }
            return true;
        }

        public override void LogPayment()
        {
            base.LogPayment();
            Console.WriteLine($"Processed via Online Gateway: {PaymentGateway}");
        }
    }
}
