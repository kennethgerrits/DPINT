using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DPINT_Wk1_Strategies
{
    public class ValueConverterViewModel : ViewModelBase
    {
        private string _fromText;
        public INumberConverter _fromConverter { get; set; }
        public INumberConverter _toConverter { get; set; }

        public string FromText
        {
            get { return _fromText; }
            set
            {
                _fromText = value;
                RaisePropertyChanged("FromText");
                this.ConvertNumbers();
            }
        }

        private string _toText;
        public string ToText
        {
            get { return _toText; }
            set
            {
                _toText = value;
                RaisePropertyChanged("ToText");
            }
        }

        private string _fromConverterName;
        public string FromConverterName
        {
            get { return _fromConverterName; }
            set
            {
                _fromConverterName = value;
                RaisePropertyChanged("FromConverterName");
                _fromConverter = _converterFactory.GetConverter(FromConverterName);

                this.ConvertNumbers();
            }
        }

        private string _toConverterName;
        public string ToConverterName
        {
            get { return _toConverterName; }
            set
            {
                _toConverterName = value;
                RaisePropertyChanged("ToConverterName");
                _toConverter = _converterFactory.GetConverter(ToConverterName);
                this.ConvertNumbers();
            }
        }

        public ObservableCollection<string> ConverterNames { get; set; }
        public ICommand ConvertCommand { get; set; }
        private NumberConverterFactory _converterFactory;

        public ValueConverterViewModel()
        {
            _converterFactory = new NumberConverterFactory();
            ConverterNames = new ObservableCollection<string>(_converterFactory.ConverterNames);

            _fromConverter = _converterFactory.GetConverter(ConverterNames[0]);
            _toConverter = _converterFactory.GetConverter(ConverterNames[0]);

            FromText = "0";
            ToText = "0";
            FromConverterName = ConverterNames[0];
            ToConverterName = ConverterNames[0];

            ConvertCommand = new RelayCommand(ConvertNumbers);
        }

        private void ConvertNumbers()
        {
            int number = _fromConverter.ToNumerical(FromText);
            ToText = _toConverter.ToLocalString(number);
        }


    }
}
