using System.Collections.ObjectModel;

namespace KoffieMachineDomain.Interfaces
{
    public interface IPaymentProcessor
    {
        ObservableCollection<string> AccountNames { get; }
        bool Pay(double amount, string accountName);
        double GetAccountBalance(string accountName);
        bool PayInCash(double amount);
        void InsertCoin(double amount);
    }
}