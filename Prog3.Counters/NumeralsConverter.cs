using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Counters
{
    public class NumeralsConverter
    {
        public static int NumeralToNumber(string numeral)
        {
            //todo: make it accept numerals instead of numeric litrals
            return int.Parse(numeral);
        }

        public static bool IsNumber(string numeral)
        {
            //todo: ...
            return true;
        }
    }
}
