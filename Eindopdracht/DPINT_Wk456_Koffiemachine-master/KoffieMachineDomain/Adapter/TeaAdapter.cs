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

        public TeaAdapter(TeaBlend blend, bool hasSugar)
        {
            _productionLog = new List<string>()
            {
                "Making tea",
                "Adding hot water"
            };
            if (hasSugar)
            {
                _productionLog.Add("Adding sugar");
                AddSugar();
            }
            base.Blend = blend;
            _productionLog.Add($"Adding {blend.Name} into the hot water");
        }

        public string GetName()
        {
            return "Tea with " + base.Blend;
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
