namespace PaymentPlus
{
    public class PaymentManager
    {
        private readonly List<Payment> _payments = new List<Payment>();

        public PaymentManager() { }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }

        public void ValidatePayments()
        {
            if (_payments.Count == 0)
            {
                Console.WriteLine("Currently no payments to validate.");
                return;
            }

            for (int i = _payments.Count - 1; i >= 0; i--)
            {
                try
                {
                    _payments[i].ValidatePayment();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n--- Invalid Payment Detected ---");
                    _payments[i].LogPayment();
                    Console.WriteLine($"Error: {e.Message}\n");

                    _payments.RemoveAt(i);
                }
            }
        }

        public void AuthorizePayments()
        {
            foreach (Payment payment in _payments)
            {
                if (payment is OnlinePayment online) // Type checking and casting
                {
                    Console.WriteLine($"\nAuthorizing {payment.PaymentAmount} {payment.Currency}...");
                    online.Authorize();
                }
            }
        }

        public void RecordOffline()
        {
            foreach (Payment payment in _payments)
            {
                if (payment is OfflinePayment offline) // Type checking and casting
                {
                    Console.WriteLine($"\nAuthorizing {payment.PaymentAmount} {payment.Currency}...");
                    offline.RecordPayment();
                }
            }
        }

        public void ProcessPayments()
        {
            if (_payments.Count == 0)
            {

                Console.WriteLine("Currently no payments to process.");
                return;
            }

            foreach (Payment payment in _payments)
            {
                payment.LogPayment();
                payment.ProcessPayment();
            }
        }
    }
}
