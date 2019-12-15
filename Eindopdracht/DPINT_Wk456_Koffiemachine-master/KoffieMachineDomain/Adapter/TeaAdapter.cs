using System.Collections.Generic;
using KoffieMachineDomain.Interfaces;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Adapter
{
    public class TeaAdapter : Tea, IBeverage
    {
        private readonly List<string> _productionLog;

        public TeaAdapter(TeaBlend blend)
        {
            _productionLog = new List<string>
            {
                "Making tea",
                "Adding hot water"
            };

            Blend = blend;
            _productionLog.Add($"Adding {Blend.Name} into the hot water");
        }

        public string GetName()
        {
            return "Tea with " + Blend.Name;
        }

        public double GetPrice()
        {
            return Price;
        }

        public List<string> GetBeverageMakingLog()
        {
            return _productionLog;
        }
    }
}