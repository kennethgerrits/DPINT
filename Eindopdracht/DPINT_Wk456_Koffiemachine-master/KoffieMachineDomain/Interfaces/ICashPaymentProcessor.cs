using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Interfaces
{
    public interface ICashPaymentProcessor
    {
        bool Pay(double amount);
        void InsertCoin(double amount);
    }
}
