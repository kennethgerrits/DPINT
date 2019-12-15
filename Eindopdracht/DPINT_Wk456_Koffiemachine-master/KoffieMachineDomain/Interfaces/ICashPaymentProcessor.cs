namespace KoffieMachineDomain.Interfaces
{
    public interface ICashPaymentProcessor
    {
        bool Pay(double amount);
        void InsertCoin(double amount);
    }
}