using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using KoffieMachineDomain.Enumerations;
using KoffieMachineDomain.Factory;
using KoffieMachineDomain.Interfaces;
using KoffieMachineDomain.Models;
using KoffieMachineDomain.PaymentMethods;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public PaymentLog Loggingservice { get; private set; }
        private IPaymentProcessor PaymentService { get; }
        private DrinkFactory DrinksFactory { get; }
        public MainViewModel()
        {
            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;

            Loggingservice = new PaymentLog();
            Loggingservice.Add(new string[]
            {
                "Starting up...",
                "Done, what would you like to drink?"
            });
            PaymentService = new PaymentProcessor
                (
                Loggingservice,
                new CardPaymentProcessor(Loggingservice),
                new CashPaymentProcessor(Loggingservice)
                );

            SelectedPaymentCardUsername = PaymentService.AccountNames[0];
          //  SelectedTeaBlend = TeaBlends.First();
            DrinksFactory = new DrinkFactory();
        }

        #region Drink properties to bind to
        private IBeverage _selectedDrink;
        public string SelectedDrinkName
        {
            get { return _selectedDrink?.GetName(); }
        }

        public double? SelectedDrinkPrice
        {
            get { return _selectedDrink?.GetPrice(); }
        }
        #endregion Drink properties to bind to

        #region Payment
        public RelayCommand PayByCardCommand => new RelayCommand(() =>
        {
            if (_selectedDrink != null)
            {
                if (PaymentService.Pay(RemainingPriceToPay, SelectedPaymentCardUsername))
                {
                    StartMakingDrink();
                }
            }
            RaisePropertyChanged(() => PaymentCardRemainingAmount);
            
        });

        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            PaymentService.InsertCoin(coinValue);
            if (_selectedDrink == null) return;
            if (PaymentService.PayInCash(RemainingPriceToPay))
            {
                StartMakingDrink();
            }
        });
        private void StartMakingDrink()
        {
            _selectedDrink.GetBeverageMakingLog().ForEach(s => Loggingservice.Log.Add(s));
            Loggingservice.Add("------------------");
            _selectedDrink = null;
        }
        public double PaymentCardRemainingAmount => PaymentService.GetAccountBalance(SelectedPaymentCardUsername);

        public ObservableCollection<string> PaymentCardUsernames => PaymentService.AccountNames;
        private string _selectedPaymentCardUsername;
        public string SelectedPaymentCardUsername
        {
            get { return _selectedPaymentCardUsername; }
            set
            {
                _selectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        private double _remainingPriceToPay;
        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }
        #endregion Payment

        #region Coffee buttons
        private Strength _coffeeStrength;
        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }

        private Amount _sugarAmount;
        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }

        private Amount _milkAmount;
        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }
        //public IEnumerable<string> TeaBlends => TeaAndChocoFactory.TeaBlendOptions;
        public string SelectedTeaBlend { get; set; }
        public ICommand DrinkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = null;
/*            if (TeaAndChocoFactory.GetDrinkAvailability(drinkName))
            {
                _selectedDrink = TeaAndChocoFactory.GetDrink(drinkName, false, SelectedTeaBlend);
            }*/
           // else
         //   {
                _selectedDrink = DrinksFactory.GetCoffee(drinkName, CoffeeStrength);
         //   }
            CheckDrink(drinkName);
            StartDrinkPayment("");
        });

        public ICommand DrinkWithSugarCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = null;
/*            if (TeaAndChocoFactory.GetDrinkAvailability(drinkName))
            {
                _selectedDrink = TeaAndChocoFactory.GetDrink(drinkName, true, SelectedTeaBlend);
            }
            else
            {*/
                _selectedDrink = DrinksFactory.GetCoffeeWithSugar(drinkName, CoffeeStrength, SugarAmount);
    //        }
            CheckDrink(drinkName);
            StartDrinkPayment("sugar");
        });

        public ICommand DrinkWithMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = null;
            _selectedDrink = DrinksFactory.GetCoffeeWithMilk(drinkName, CoffeeStrength, MilkAmount);
            CheckDrink(drinkName);
            StartDrinkPayment("milk");
        });

        public ICommand DrinkWithSugarAndMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = null;
            _selectedDrink = DrinksFactory.GetCoffeeWithMilkAndSugar(drinkName, CoffeeStrength, SugarAmount, MilkAmount);
            CheckDrink(drinkName);
            StartDrinkPayment("milk and sugar");
        });
        private void StartDrinkPayment(string DrinkWithWhat)
        {
            RemainingPriceToPay = 0;
            if (_selectedDrink == null) return;
            var postfix = DrinkWithWhat == "" ? " with " + DrinkWithWhat : "";
            RemainingPriceToPay = _selectedDrink.GetPrice();
            Loggingservice.Add($"Selected {_selectedDrink.GetName()}{postfix}, price: {RemainingPriceToPay}");
            RaisePropertyChanged(() => RemainingPriceToPay);
            RaisePropertyChanged(() => SelectedDrinkName);
            RaisePropertyChanged(() => SelectedDrinkPrice);
        }
        private void CheckDrink(string drinkName)
        {
            if (_selectedDrink == null)
            {
                Loggingservice.Add($"Could not make {drinkName}, recipe not found.");
            }
        }

        #endregion Coffee buttons
    }
}