namespace PaymentPlus
{
    public class ChequePayment : OfflinePayment
    {
        public string ChequeNumber { get; set; }
        public string BankName { get; set; }

        public ChequePayment(decimal paymentAmount, CurrencyType currency, string chequeNumber, string bankName) : base(paymentAmount, currency)
        {
            ChequeNumber = chequeNumber;
            BankName = bankName;
        }

        public override void RecordPayment()
        {
            Console.WriteLine($"Recording cheque #{ChequeNumber} from {BankName}.\n");
        }

        public override bool ValidatePayment()
        {
            base.ValidatePayment();

            // Whole number meaning be divisible by 1 with no remainder
            if (Currency == CurrencyType.USD && (PaymentAmount % 1.00m) != 0)
            {
                throw new Exception("USD cheque payments must be in whole-dollar amounts.");
            }

            return true;
        }

        public override void LogPayment()
        {
            base.LogPayment();
            Console.WriteLine($"Paid with cheque #{ChequeNumber} via {BankName}.");
        }
    }
}
