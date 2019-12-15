using System.Collections.Generic;

namespace KoffieMachineDomain.Interfaces
{
    public interface IBeverage
    {
        string GetName();
        double GetPrice();
        List<string> GetBeverageMakingLog();
    }
}