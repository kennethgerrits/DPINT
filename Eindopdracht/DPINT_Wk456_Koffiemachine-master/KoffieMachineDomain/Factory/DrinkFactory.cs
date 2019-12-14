using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Decorators;
using KoffieMachineDomain.Enumerations;
using KoffieMachineDomain.Interfaces;
using KoffieMachineDomain.Models;

namespace KoffieMachineDomain.Factory
{
    public abstract class DrinkFactory
    {
        private static IBeverage GetBaseBeverage(string name, Strength strength)
        {
            switch (name)
            {
                case "Coffee":
                    return new Coffee("Coffee", strength, Amount.Normal);
                case "Wiener Melange":
                    return new MilkBeverageDecorator(new Coffee("Wiener Melange", Strength.Weak, Amount.Extra));
                case "Cafe au Lait":
                    return new MilkBeverageDecorator(new Coffee("Cafe au Lait", Strength.Normal, Amount.Extra));
                case "Espresso":
                    return new Coffee("Espresso", Strength.Strong, Amount.Few);
                default:
                    return null;
            }
        }

        public static IBeverage GetCoffeeWithSugar(string name, Strength strength, Amount sugarAmount)
        {
            var coffee = GetBaseBeverage(name, strength);
            if (coffee == null)
            {
                return null;
            }
            return new SugarBeverageDecorator(coffee) { SugarAmount = sugarAmount };
        }

        public static IBeverage GetCoffeeWithMilkAndSugar(string name, Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            var coffee = GetBaseBeverage(name, strength);
            if (coffee == null)
            {
                return null;
            }
            return new MilkBeverageDecorator(new SugarBeverageDecorator(coffee) { SugarAmount = sugarAmount }) { MilkAmount = milkAmount };
        }
        public static IBeverage GetCoffeeWithMilk(string name, Strength strength, Amount milkAmount)
        {
            var coffee = GetBaseBeverage(name, strength);
            if (coffee == null)
            {
                return null;
            }
            return new MilkBeverageDecorator(coffee) { MilkAmount = milkAmount };
        }
        public static IBeverage GetCoffee(string name, Strength strength)
        {
            return GetBaseBeverage(name, strength);
        }

    }
}
