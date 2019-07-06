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
            var atomic = numeral.Trim().Split(new char[] { ' ', '-' });
            int part1 = Lookup(atomic[0]);
            int part2;
            switch (part1)
            {
                case int n when (n >= 0 && n <= 99) && (atomic.Length == 1):
                    return part1;

                case 1 when (atomic.Length == 2):
                    part2 = Lookup(atomic[1]);
                    if (part2 == 100)
                    {
                        return part2;
                    }
                    break;

                case int n when (n >= 20 && n <= 90) && (atomic.Length == 2):
                    part2 = Lookup(atomic[1]);
                    if (part2 >= 1 && part2 <= 9)
                    {
                        return part1 + part2;
                    }
                    break;
            }
            throw new Exception("Invalid number");
        }

        public static bool IsValidNumber(string numeral, int minimum)
        {
            try
            {
                return NumeralToNumber(numeral) >= minimum;
            } 
            catch
            {
                return false;
            }
        }

        private static int Lookup(string atom)
        {
            switch (atom)
            {
                case "zero":      return 0;
                case "one":       return 1;
                case "two":       return 2;
                case "three":     return 3;
                case "four":      return 4;
                case "five":      return 5;
                case "six":       return 6;
                case "seven":     return 7;
                case "eight":     return 8;
                case "nine":      return 9;
                case "ten":       return 10;
                case "eleven":    return 11;
                case "twelve":    return 12;
                case "thirteen":  return 13;
                case "fourteen":  return 14;
                case "fifteen":   return 15;
                case "sixteen":   return 16;
                case "seventeen": return 17;
                case "eighteen":  return 18;
                case "nineteen":  return 19;
                case "twenty":    return 20;
                case "thirty":    return 30;
                case "forty":     return 40;
                case "fifty":     return 50;
                case "sixty":     return 60;
                case "seventy":   return 70;
                case "eighty":    return 80;
                case "ninety":    return 90;
                case "hundred":   return 100;
            }
            return -1;
        }
    }
}
