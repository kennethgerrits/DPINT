using System.Collections.Generic;
using KoffieMachineDomain.Enumerations;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.Decorators
{
    public class MilkBeverageDecorator : CondimentDecorator
    {
        private const double MILKPRICE = 0.5;

        public MilkBeverageDecorator(IBeverage decoratedBeverage) : base(decoratedBeverage)
        {
        }

        public Amount MilkAmount { get; set; }

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