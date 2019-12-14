using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    public class NumericalNumberConverter : INumberConverter
    {
        public string ToLocalString(int toString)
        {
            return toString.ToString();

        }

        public int ToNumerical(string toInt)
        {
            return Int32.Parse(toInt);

        }
    }
}
