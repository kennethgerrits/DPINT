using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Enumerations;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.Decorators
{
    public class SugarBeverageDecorator : CondimentDecorator
    {
        private const double SUGARPRICE = 0.2;

        public SugarBeverageDecorator(IBeverage decoratedBeverage) : base(decoratedBeverage)
        {
        }

        public Amount SugarAmount { get; set; }

        public override double GetPrice()
        {
            var newPrice = base.GetPrice() + SUGARPRICE;
            return newPrice;
        }

        public override List<string> GetBeverageMakingLog()
        {
            var log = base.GetBeverageMakingLog();
            log.Add($"Adding {SugarAmount} suggar.");
            return log;
        }
    }
}
