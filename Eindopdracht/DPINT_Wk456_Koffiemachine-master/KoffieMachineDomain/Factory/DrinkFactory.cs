using System.Collections.Generic;
using System.IO;
using KoffieMachineDomain.Adapter;
using KoffieMachineDomain.Decorators;
using KoffieMachineDomain.Enumerations;
using KoffieMachineDomain.Interfaces;
using KoffieMachineDomain.Models;
using Newtonsoft.Json;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Factory
{
    public class DrinkFactory
    {
        private readonly ConfigurationManager _config;
        private readonly TeaBlendRepository _teaBlendRepository;
        private string _blendString;
        public IEnumerable<string> TeaBlendOptions;

        public DrinkFactory()
        {
            var jsonString = File.ReadAllText("./config/config.json");
            _config = JsonConvert.DeserializeObject<ConfigurationManager>(jsonString);
            _teaBlendRepository = new TeaBlendRepository();
            TeaBlendOptions = _teaBlendRepository.BlendNames;
        }

        private TeaBlend GetTeaBlend(string name)
        {
            return _teaBlendRepository.GetTeaBlend(name);
        }

        private IBeverage GetBaseBeverage(string name, Strength strength)
        {
            IBeverage beverage;
            if (name.Contains("Tea"))
            {
                beverage = new TeaAdapter(GetTeaBlend(_blendString));
            }
            else if (name.Contains("Choco"))
            {
                if (name.Contains("Deluxe"))
                    beverage = new HotChocoladeAdapter(true);
                else
                    beverage = new HotChocoladeAdapter(false);
            }
            else
            {
                beverage = new Coffee(name, strength, Amount.Normal);
            }

            return DecorateBaseBeverage(beverage, name);
        }

        private IBeverage DecorateBaseBeverage(IBeverage beverage, string name)
        {
            if (_config.Coffees.TryGetValue(name, out var recepeStrings))
                foreach (var recepeString in recepeStrings)
                    switch (recepeString)
                    {
                        case "milk":
                            beverage = new MilkBeverageDecorator(beverage);
                            continue;
                        case "sugar":
                            beverage = new SugarBeverageDecorator(beverage) {SugarAmount = Amount.Normal};
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

            return beverage;
        }

        public IBeverage GetCoffeeWithSugar(string name, Strength strength, Amount sugarAmount)
        {
            var coffee = GetBaseBeverage(name, strength);
            if (coffee == null) return null;
            return new SugarBeverageDecorator(coffee) {SugarAmount = sugarAmount};
        }

        public IBeverage GetCoffeeWithMilkAndSugar(string name, Strength strength, Amount sugarAmount,
            Amount milkAmount)
        {
            var coffee = GetBaseBeverage(name, strength);
            if (coffee == null) return null;
            return new MilkBeverageDecorator(new SugarBeverageDecorator(coffee) {SugarAmount = sugarAmount})
                {MilkAmount = milkAmount};
        }

        public IBeverage GetCoffeeWithMilk(string name, Strength strength, Amount milkAmount)
        {
            var coffee = GetBaseBeverage(name, strength);
            if (coffee == null) return null;
            return new MilkBeverageDecorator(coffee) {MilkAmount = milkAmount};
        }

        public IBeverage GetBeverage(string name, Strength strength, string blendString)
        {
            _blendString = blendString;
            return GetBaseBeverage(name, strength);
        }
    }
}