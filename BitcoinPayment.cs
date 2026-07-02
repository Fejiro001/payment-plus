namespace PaymentPlus
{
    public class BitcoinPayment : OnlinePayment
    {
        public string WalletID { get; set; }

        public BitcoinPayment(decimal paymentAmount, CurrencyType currency, string paymentGateway, string walletID) : base(paymentAmount, currency, paymentGateway)
        {
            WalletID = walletID;
        }

        public override void Authorize()
        {
            Console.WriteLine($"Verifying wallet ID on the blockchain...");
        }

        public override bool ValidatePayment()
        {
            base.ValidatePayment();

            if (WalletID.Length < 4)
            {
                throw new Exception("Bitcoin wallet ID must be at least 4 characters long.");
            }

            return true;
        }

        public override void LogPayment()
        {
            string lastFour = StringHelper.GetLastFour(WalletID);

            base.LogPayment();
            Console.WriteLine($"Paid using bitcoin with wallet ID ending in {lastFour}");
        }
    }
}
