using System.Collections.Generic;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.Decorators
{
    public class WhippedCreamDecorator : CondimentDecorator
    {
        private const double WHIPPEDCREAMPRICE = 0.5;

        public WhippedCreamDecorator(IBeverage decoratedBeverage) : base(decoratedBeverage)
        {
        }

        public override double GetPrice()
        {
            var newPrice = base.GetPrice() + WHIPPEDCREAMPRICE;
            return newPrice;
        }

        public override List<string> GetBeverageMakingLog()
        {
            var log = base.GetBeverageMakingLog();
            log.Add("Adding whipped cream.");
            return log;
        }
    }
}