using System.Collections.Generic;
using System.Linq;
using KoffieMachineDomain.Interfaces;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Adapter
{
    public class HotChocoladeAdapter : HotChocolate, IBeverage
    {
        public HotChocoladeAdapter(bool isDeluxe)
        {
            if (isDeluxe) MakeDeluxe();
        }

        public string GetName()
        {
            return GetNameOfDrink();
        }

        public double GetPrice()
        {
            return Cost();
        }

        public List<string> GetBeverageMakingLog()
        {
            return GetBuildSteps().ToList();
        }
    }
}