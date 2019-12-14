using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.Models
{
    public abstract class Beverage : IBeverage
    {
        protected const double BaseDrinkPrice = 1.0;

        public abstract double GetPrice();

        public abstract string GetName();

        public List<string> GetBeverageMakingLog()
        {
            var log = new List<string>
            {
                $"Making {GetName()}...",
                $"Heating up..."
            };

            return log;
        }
    }
}
