using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    public class HexadecimalNumberConverter : INumberConverter
    {
        public string ToLocalString(int toString)
        {
            return Convert.ToString(toString, 16);

        }

        public int ToNumerical(string toInt)
        {
            return Convert.ToInt32(toInt, 16);
        }
    }
}
