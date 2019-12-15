using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorators;
using KoffieMachineDomain.Enumerations;
using KoffieMachineDomain.Interfaces;
using KoffieMachineDomain.Models;
using Newtonsoft.Json;

namespace KoffieMachineDomain.Factory
{
    public class DrinkFactory
    {
        private ConfigurationManager config;

        public DrinkFactory()
        {
            var jsonString = File.ReadAllText("./config/config.json");
            config = JsonConvert.DeserializeObject<ConfigurationManager>(jsonString);

        }

        private IBeverage GetBaseBeverage(string name, Strength strength)
        {
            IBeverage beverage = null;
            if (name.Contains("tea"))
            {
                return null; // TODO: add tea
            } else if (name.Contains("choco"))
            {
                return null; // TODO: add choco
            } else
            {
                beverage = new Coffee(name, strength, Amount.Normal);
            }

            return decorateBaseBeverage(beverage, name);
        }

        private IBeverage decorateBaseBeverage(IBeverage beverage, String name)
        {
            // find beverage in config
            if (config.Coffees.TryGetValue(name, out String[] recepeStrings))
            {
                foreach (string recepeString in recepeStrings)
                {
                    switch (recepeString)
                    {
                        case "milk":
                            beverage = new MilkBeverageDecorator(beverage);
                            continue;
                        case "sugar":
                            beverage = new SugarBeverageDecorator(beverage){SugarAmount = Amount.Normal};
                            continue;
                        case "amaretto":
                            beverage = new AmarettoDecorator(beverage);
                            continue;
                        case "whippedcream":
                            beverage = new WhippedCreamDecorator(beverage);
                            continue;
                        case "whisky":
                            beverage = new WhiskyDecorator(beverage);
                            continue;
                        default:
                            continue;
                    }
                }
            }

            return beverage;

        }

        public IBeverage GetCoffeeWithSugar(string name, Strength strength, Amount sugarAmount)
        {
            var coffee = GetBaseBeverage(name, strength);
            if (coffee == null)
            {
                return null;
            }
            return new SugarBeverageDecorator(coffee) { SugarAmount = sugarAmount };
        }

        public IBeverage GetCoffeeWithMilkAndSugar(string name, Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            var coffee = GetBaseBeverage(name, strength);
            if (coffee == null)
            {
                return null;
            }
            return new MilkBeverageDecorator(new SugarBeverageDecorator(coffee) { SugarAmount = sugarAmount }) { MilkAmount = milkAmount };
        }
        public IBeverage GetCoffeeWithMilk(string name, Strength strength, Amount milkAmount)
        {
            var coffee = GetBaseBeverage(name, strength);
            if (coffee == null)
            {
                return null;
            }
            return new MilkBeverageDecorator(coffee) { MilkAmount = milkAmount };
        }
        public IBeverage GetCoffee(string name, Strength strength)
        {
            return GetBaseBeverage(name, strength);
        }

    }
}
