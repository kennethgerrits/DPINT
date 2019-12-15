using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Enumerations;
using KoffieMachineDomain.Interfaces;

namespace KoffieMachineDomain.Models
{
    public class Coffee : IBeverage
    {
        public string Name { get; set; }
        public Strength CoffeeStrength { get; set; }
        public Amount CoffeeAmount { get; set; }
        
        public Coffee(string name, Strength coffeeStrength, Amount coffeeAmount)
        {
            Name = name;
            CoffeeStrength = coffeeStrength;
            CoffeeAmount = coffeeAmount;
        }

        public double GetPrice() => 1.0;

        public string GetName() => Name;

        public List<string> GetBeverageMakingLog()
        {
            var log = new List<string>
            {
                $"Setting coffee strength to {CoffeeStrength}.",
                $"Filling mug up to 1/{(int) CoffeeAmount} with coffee...",
                $"Finished filling the cup with {Name}"
            };

            return log;
        }
    }
}
