using System.Collections.ObjectModel;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.PaymentMethods
{
    public class PaymentProcessor : IPaymentProcessor
    {
        public PaymentProcessor(PaymentLog loggingservice, ICardPaymentProcessor cardPaymentService,
            ICashPaymentProcessor cashPaymentService)
        {
            Loggingservice = loggingservice;
            CardPaymentService = cardPaymentService;
            CashPaymentService = cashPaymentService;
        }

        public PaymentLog Loggingservice { get; }

        public ICardPaymentProcessor CardPaymentService { get; }
        private ICashPaymentProcessor CashPaymentService { get; }

        public ObservableCollection<string> AccountNames => CardPaymentService.AccountNames;

        public bool Pay(double amount, string accountName)
        {
            if (!CardPaymentService.Pay(amount, accountName, out var amountDue))
            {
                Loggingservice.Add($"Not enough balance, missing: {amountDue}");
                return false;
            }

            return true;
        }

        public double GetAccountBalance(string accountName)
        {
            return CardPaymentService.GetAccountBalance(accountName);
        }

        public bool PayInCash(double amount)
        {
            return CashPaymentService.Pay(amount);
        }

        public void InsertCoin(double amount)
        {
            CashPaymentService.InsertCoin(amount);
        }
    }
}