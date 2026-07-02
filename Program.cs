namespace PaymentPlus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PaymentManager manager = new PaymentManager();

            CreditCardPayment validCredit = new CreditCardPayment(10.00m, CurrencyType.CAD, "Stripe", "123456789101112", "12/30", "321");
            CreditCardPayment validCreditTwo = new CreditCardPayment(15.00m, CurrencyType.EUR, "Stripe", "123456789101112", "12/30", "321");
            CreditCardPayment invalidCredit = new CreditCardPayment(1.00m, CurrencyType.USD, "Stripe", "123456789101112", "12/30", "321");
            CreditCardPayment invalidCreditTwo = new CreditCardPayment(7.00m, CurrencyType.EUR, "Stripe", "123456789101112", "12/30", "321");

            BitcoinPayment validBitcoin = new BitcoinPayment(12.00m, CurrencyType.USD, "Paypal", "PRY132RT5610");
            BitcoinPayment invalidBitcoin = new BitcoinPayment(17.00m, CurrencyType.USD, "Paypal", "P8Y");

            CashPayment validCash = new CashPayment(100.99m, CurrencyType.CAD);
            CashPayment invalidCash = new CashPayment(100.99m, CurrencyType.EUR);

            ChequePayment validCheque = new ChequePayment(100.00m, CurrencyType.USD, "45789", "Scotiabank");
            ChequePayment invalidCheque = new ChequePayment(100.78m, CurrencyType.USD, "45789", "Scotiabank");

            // Add payments to payment manager
            manager.AddPayment(validCredit);
            manager.AddPayment(validCreditTwo);
            manager.AddPayment(invalidCredit);
            manager.AddPayment(invalidCreditTwo);
            manager.AddPayment(validBitcoin);
            manager.AddPayment(invalidBitcoin);
            manager.AddPayment(validCash);
            manager.AddPayment(invalidCash);
            manager.AddPayment(validCheque);
            manager.AddPayment(invalidCheque);

            Console.WriteLine("\n=== PHASE 1: VALIDATION ===");
            manager.ValidatePayments();

            Console.WriteLine("\n=== PHASE 2: ONLINE AUTHORIZATION ===");
            manager.AuthorizePayments();

            Console.WriteLine("\n=== PHASE 3: OFFLINE RECORD ===");
            manager.RecordOffline();

            Console.WriteLine("\n=== PHASE 4: PROCESSING ===");
            manager.ProcessPayments();
        }
    }
}
