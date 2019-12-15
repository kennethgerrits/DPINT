using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Interfaces
{
    public interface ICardPaymentProcessor
    {
        ObservableCollection<string> AccountNames { get; }
        bool Pay(double amount, string accountName, out double RemainingAmount);
        double GetAccountBalance(string AccountName);

    }
}
