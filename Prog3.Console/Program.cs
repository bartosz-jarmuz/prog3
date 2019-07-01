using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog3.Counters;

namespace Prog3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ICounter counter = new NumericCounter(2, 2, "Numeric counter 1");
            counter.OnTick += Print;
            counter.StartCounter();
            System.Console.WriteLine("done");
            System.Console.ReadKey();
        }

        static void Print(string msg)
        {
            System.Console.WriteLine(msg);
        }
    }
}
