using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Interfaces;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Adapter
{
    public class TeaAdapter : Tea, IBeverage
    {
        private List<string> _productionLog;

        public TeaAdapter(TeaBlend blend)
        {
            _productionLog = new List<string>()
            {
                "Making tea",
                "Adding hot water"
            };

            base.Blend = blend;
            _productionLog.Add($"Adding {Blend.Name} into the hot water");
        }

        public string GetName()
        {
            return "Tea with " + base.Blend.Name;
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
