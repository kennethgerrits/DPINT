using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Interfaces;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Adapter
{
    public class HotChocoladeAdapter : HotChocolate, IBeverage
    {

        public HotChocoladeAdapter(bool isDeluxe)
        {
            if (isDeluxe)
            {
                base.MakeDeluxe();
            }
        }
        public string GetName()
        {
            return base.GetNameOfDrink();
        }

        public double GetPrice()
        {
           return base.Cost();
        }

        public List<string> GetBeverageMakingLog()
        {
            return base.GetBuildSteps().ToList();
        }
    }
}
