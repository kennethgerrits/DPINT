using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.PaymentMethods
{
    public class CardPaymentProcessor : ICardPaymentProcessor
    {
        private IDictionary<string, double> _accountData;
        private readonly PaymentLog _loggingService;

        public CardPaymentProcessor(PaymentLog loggingservice)
        {
            _loggingService = loggingservice;
            AccountData = new Dictionary<string, double>
            {
                ["Arjen"] = 5.0,
                ["Bert"] = 3.5,
                ["Chris"] = 7.0,
                ["Daan"] = 6.0,
                ["Kenneth"] = 0.5
            };
        }

        private IDictionary<string, double> AccountData
        {
            get => _accountData;
            set
            {
                _accountData = value;
                if (AccountNames == null)
                    AccountNames = new ObservableCollection<string>();
                foreach (var item in AccountNames) AccountNames.Remove(item);
                foreach (var item in _accountData.Keys) AccountNames.Add(item);
            }
        }

        public ObservableCollection<string> AccountNames { get; private set; }

        public bool Pay(double amount, string accountName, out double remaingAmount)
        {
            remaingAmount = 0;
            if (AccountExists(accountName))
            {
                var newAccountValue = AccountData.First(account => account.Key == accountName).Value - amount;
                if (newAccountValue < 0)
                {
                    remaingAmount = -newAccountValue;
                    return false;
                }

                AccountData[accountName] = newAccountValue;
                _loggingService.Add($"Account value left: {newAccountValue.ToString("C", CultureInfo.CurrentCulture)}");
            }

            return true;
        }

        public double GetAccountBalance(string accountName)
        {
            if (AccountExists(accountName)) return AccountData.First(account => account.Key == accountName).Value;
            return 0;
        }

        private bool AccountExists(string accountName)
        {
            return AccountData.ContainsKey(accountName ?? "");
        }
    }
}