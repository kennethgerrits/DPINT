using System.Collections.Generic;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.Decorators
{
    public class WhiskyDecorator : CondimentDecorator
    {
        private const double WHISKYPRICE = 0.5;

        public WhiskyDecorator(IBeverage decoratedBeverage) : base(decoratedBeverage)
        {
        }

        public override double GetPrice()
        {
            var newPrice = base.GetPrice() + WHISKYPRICE;
            return newPrice;
        }

        public override List<string> GetBeverageMakingLog()
        {
            var log = base.GetBeverageMakingLog();
            log.Add("Adding whisky.");
            return log;
        }
    }
}