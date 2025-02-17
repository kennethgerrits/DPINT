﻿using System.Collections.Generic;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.Decorators
{
    public abstract class CondimentDecorator : IBeverage
    {
        protected IBeverage DecoratedBeverage;

        public CondimentDecorator(IBeverage decoratedBeverage)
        {
            DecoratedBeverage = decoratedBeverage;
        }

        public virtual string GetName()
        {
            return DecoratedBeverage.GetName();
        }

        public virtual double GetPrice()
        {
            return DecoratedBeverage.GetPrice();
        }

        public virtual List<string> GetBeverageMakingLog()
        {
            return DecoratedBeverage.GetBeverageMakingLog();
        }
    }
}