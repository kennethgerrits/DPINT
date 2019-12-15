using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Interfaces
{
    public interface IPaymentProcessor
    {
        ObservableCollection<string> AccountNames { get; }
        bool Pay(double amount, string accountName);
        double GetAccountBalance(string AccountName);
        bool PayInCash(double amount);
        void InsertCoin(double amount);
    }
}
