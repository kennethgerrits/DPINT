using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    public class NumberConverterFactory
    {
        public IEnumerable<string> ConverterNames
        {
            get { return _converters.Keys; }
        }

        private Dictionary<string, INumberConverter> _converters;

        public NumberConverterFactory()
        {
            _converters = new Dictionary<string, INumberConverter>
            {

                ["Numerical"] = new NumericalNumberConverter(),
                ["Binary"] = new BinaryNumberConverter(),
                ["Hexadecimal"] = new HexadecimalNumberConverter(),
                ["Roman"] = new RomanNumberConverter(),
                ["Octal"] = new OctalNumberConverter()

            };
        }

        public INumberConverter GetConverter(string name)
        {
            return _converters[name];
        }
    }
}
