using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Adapter;
using KoffieMachineDomain.Decorators;
using KoffieMachineDomain.Enumerations;
using KoffieMachineDomain.Interfaces;
using KoffieMachineDomain.Models;
using Newtonsoft.Json;
using TeaAndChocoLibrary;
using System.Drawing;

namespace KoffieMachineDomain.Factory
{
    public class DrinkFactory
    {
        private string _blendString;
        private ConfigurationManager config;
        private TeaBlendRepository teaBlendRepository;
        public IEnumerable<string> TeaBlendOptions;

        public DrinkFactory()
        {
            var jsonString = File.ReadAllText("./config/config.json");
            config = JsonConvert.DeserializeObject<ConfigurationManager>(jsonString);
            teaBlendRepository = new TeaBlendRepository();
            TeaBlendOptions = teaBlendRepository.BlendNames;
        }

        private TeaBlend getTeaBlend(String name)
        {
            return teaBlendRepository.GetTeaBlend(name);
        }

        private IBeverage GetBaseBeverage(string name, Strength strength)
        {
            IBeverage beverage = null;
            if (name.Contains("Tea"))
            {
                beverage = new TeaAdapter(getTeaBlend(_blendString));
            }
            else if (name.Contains("Choco"))
            {
                if (name.Contains("Deluxe"))
                {
                    beverage = new HotChocoladeAdapter(true);
                }
                else
                {
                    beverage = new HotChocoladeAdapter(false);
                }
            }
            else
            {
                beverage = new Coffee(name, strength, Amount.Normal);
            }

            return decorateBaseBeverage(beverage, name);
        }

        private IBeverage decorateBaseBeverage(IBeverage beverage, string name)
        {
            if (config.Coffees.TryGetValue(name, out string[] recepeStrings))
            {
                foreach (string recepeString in recepeStrings)
                {
                    switch (recepeString)
                    {
                        case "milk":
                            beverage = new MilkBeverageDecorator(beverage);
                            continue;
                        case "sugar":
                            beverage = new SugarBeverageDecorator(beverage) { SugarAmount = Amount.Normal };
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
        public IBeverage GetCoffee(string name, Strength strength, string blendString)
        {
            _blendString = blendString;
            return GetBaseBeverage(name, strength);
        }
    }
}
