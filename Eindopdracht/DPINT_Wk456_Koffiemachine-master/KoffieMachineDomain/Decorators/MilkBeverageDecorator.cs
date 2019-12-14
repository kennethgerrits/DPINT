using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Enumerations;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.Decorators
{
    class MilkBeverageDecorator : CondimentDecorator
    {
        private const double MILKPRICE = 0.5;

        public Amount MilkAmount { get; set; }

        public MilkBeverageDecorator(IBeverage decoratedBeverage) : base(decoratedBeverage)
        {
        }

        public override double GetPrice()
        {
            var newPrice = base.GetPrice() + MILKPRICE;
            return newPrice;
        }

        public override List<string> GetBeverageMakingLog()
        {
            var log = base.GetBeverageMakingLog();
            log.Add($"Adding {MilkAmount} milk.");
            return log;
        }
    }
}
