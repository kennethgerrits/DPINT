using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.PaymentMethods
{
    public class CardPaymentProcessor : ICardPaymentProcessor
    {
        private PaymentLog _loggingService;
        public ObservableCollection<string> AccountNames { get; private set; }
        private IDictionary<string, double> _accountData;
        private IDictionary<string, double> AccountData
        {
            get
            {
                return _accountData;
            }
            set
            {
                _accountData = value;
                if (AccountNames == null)
                    AccountNames = new ObservableCollection<string>();
                foreach (var item in AccountNames) { AccountNames.Remove(item); }
                foreach (var item in _accountData.Keys) { AccountNames.Add(item); }
            }
        }

        public CardPaymentProcessor(PaymentLog loggingservice)
        {
            _loggingService = loggingservice;
            AccountData = new Dictionary<string, double>
            {
                ["Arjen"] = 5.0,
                ["Bert"] = 3.5,
                ["Chris"] = 7.0,
                ["Daan"] = 6.0,
                ["Martijn"] = 0.5,
            };

        }

        public bool Pay(double amount, string accountName, out double remaingAmount)
        {
            remaingAmount = 0;
            if (AccountExists(accountName))
            {
                double NewAccountValue = AccountData.First(account => account.Key == accountName).Value - amount;
                if (NewAccountValue < 0)
                {
                    remaingAmount = -NewAccountValue;
                    return false;
                }
                AccountData[accountName] = NewAccountValue;
                _loggingService.Add($"Account value left: {NewAccountValue.ToString("C", CultureInfo.CurrentCulture)}");
            }
            return true;
        }
        private bool AccountExists(string accountName)
        {
            return AccountData.ContainsKey(accountName ?? "");
        }
        public double GetAccountBalance(string AccountName)
        {
            if (AccountExists(AccountName))
            {
                return AccountData.First(account => account.Key == AccountName).Value;
            }
            return 0;
        }

    }

}
