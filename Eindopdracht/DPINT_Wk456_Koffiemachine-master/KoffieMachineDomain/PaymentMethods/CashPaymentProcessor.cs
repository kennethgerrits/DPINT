using System.Globalization;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.PaymentMethods
{
    public class CashPaymentProcessor : ICashPaymentProcessor
    {
        private readonly PaymentLog _loggingService;

        public CashPaymentProcessor(PaymentLog loggingservice)
        {
            _loggingService = loggingservice;
        }

        public double AmountInserted { get; set; }
        public double RemainingPriceToPay { get; set; }

        public bool Pay(double amount)
        {
            RemainingPriceToPay = amount;
            if (AmountInserted >= RemainingPriceToPay)
            {
                AmountInserted -= RemainingPriceToPay;
                return true;
            }

            _loggingService.Add(
                $"Amount Remaining: {(RemainingPriceToPay - AmountInserted).ToString("C", CultureInfo.CurrentCulture)}.");
            return false;
        }

        public void InsertCoin(double amount)
        {
            AmountInserted += amount;
            _loggingService.Add($"Inserted {amount.ToString("C", CultureInfo.CurrentCulture)}");
        }
    }
}