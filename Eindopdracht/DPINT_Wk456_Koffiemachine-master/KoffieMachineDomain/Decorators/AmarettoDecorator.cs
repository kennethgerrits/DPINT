using System.Collections.Generic;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.Decorators
{
    public class AmarettoDecorator : CondimentDecorator
    {
        private const double AMARETTOPRICE = 0.5;

        public AmarettoDecorator(IBeverage decoratedBeverage) : base(decoratedBeverage)
        {
        }

        public override double GetPrice()
        {
            var newPrice = base.GetPrice() + AMARETTOPRICE;
            return newPrice;
        }

        public override List<string> GetBeverageMakingLog()
        {
            var log = base.GetBeverageMakingLog();
            log.Add("Adding amaretto.");
            return log;
        }
    }
}