using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    public class RomanNumberConverter : INumberConverter
    {
        private static Dictionary<char, int> _romanMap = new Dictionary<char, int>
        {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };

        public string ToLocalString(int toString)
        {
            if (toString < 1) return string.Empty;
            if (toString >= 1000) return "M" + ToLocalString(toString - 1000);
            if (toString >= 900) return "CM" + ToLocalString(toString - 900); //EDIT: i've typed 400 instead 900
            if (toString >= 500) return "D" + ToLocalString(toString - 500);
            if (toString >= 400) return "CD" + ToLocalString(toString - 400);
            if (toString >= 100) return "C" + ToLocalString(toString - 100);
            if (toString >= 90) return "XC" + ToLocalString(toString - 90);
            if (toString >= 50) return "L" + ToLocalString(toString - 50);
            if (toString >= 40) return "XL" + ToLocalString(toString - 40);
            if (toString >= 10) return "X" + ToLocalString(toString - 10);
            if (toString >= 9) return "IX" + ToLocalString(toString - 9);
            if (toString >= 5) return "V" + ToLocalString(toString - 5);
            if (toString >= 4) return "IV" + ToLocalString(toString - 4);
            if (toString >= 1) return "I" + ToLocalString(toString - 1);

            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public int ToNumerical(string toInt)
        {
            int totalValue = 0, prevValue = 0;
            foreach (var c in toInt)
            {
                if (!_romanMap.ContainsKey(c))
                    return 0;
                var crtValue = _romanMap[c];
                totalValue += crtValue;
                if (prevValue != 0 && prevValue < crtValue)
                {
                    if (prevValue == 1 && (crtValue == 5 || crtValue == 10)
                        || prevValue == 10 && (crtValue == 50 || crtValue == 100)
                        || prevValue == 100 && (crtValue == 500 || crtValue == 1000))
                        totalValue -= 2 * prevValue;
                    else
                        return 0;
                }
                prevValue = crtValue;
            }
            return totalValue;
        }
    }
}
