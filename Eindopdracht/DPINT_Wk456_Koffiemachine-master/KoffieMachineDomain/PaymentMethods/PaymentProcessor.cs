using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.PaymentMethods
{
    public class PaymentProcessor : IPaymentProcessor
    {
        public PaymentProcessor(PaymentLog loggingservice, ICardPaymentProcessor cardPaymentService, ICashPaymentProcessor cashPaymentService)
        {
            Loggingservice = loggingservice;
            CardPaymentService = cardPaymentService;
            CashPaymentService = cashPaymentService;
        }

        public PaymentLog Loggingservice { get; }

        public ObservableCollection<string> AccountNames => CardPaymentService.AccountNames;

        public ICardPaymentProcessor CardPaymentService { get; }
        private ICashPaymentProcessor CashPaymentService { get; }

        public bool Pay(double amount, string accountName)
        {
            if (!CardPaymentService.Pay(amount, accountName, out double amountDue))
            {
                Loggingservice.Add($"Not enough balance, missing: {amountDue}");
                return false;
            }
            return true;
        }

        public double GetAccountBalance(string AccountName) => CardPaymentService.GetAccountBalance(AccountName);

        public bool PayInCash(double amount) => CashPaymentService.Pay(amount);

        public void InsertCoin(double amount) => CashPaymentService.InsertCoin(amount);
    }
}
