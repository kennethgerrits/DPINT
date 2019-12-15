using System.Collections.ObjectModel;

namespace KoffieMachineDomain.Interfaces
{
    public interface ICardPaymentProcessor
    {
        ObservableCollection<string> AccountNames { get; }
        bool Pay(double amount, string accountName, out double remainingAmount);
        double GetAccountBalance(string accountName);
    }
}