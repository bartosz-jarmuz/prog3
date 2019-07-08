using Prog3.Common.Contracts;
using Prog3.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.ConsoleClient
{
    class Program
    {
        static CounterManager counters;
        static readonly UIHandler uIHandler = new UIHandler();

        static void Main(string[] args)
        {
            counters = new CounterManager(uIHandler.NotifyCompleted, uIHandler.UpdateStatus);

            foreach (ICounter counter in uIHandler.CollectCountersInfo())
            {
                counters.AddCounter(counter);
            }

            if (counters.ActiveCounters.Count == 0)
            {
                Console.WriteLine("No counter created");
            }
            else
            {
                Console.WriteLine($"Created {counters.ActiveCounters.Count} counter(s):");
                foreach (ICounter counter in counters.ActiveCounters)
                {
                    Console.WriteLine(counter);
                }
                Console.WriteLine($"Press any key to start");
                Console.ReadKey(true);
                counters.StartAllCounters();
            }

            Console.ReadKey(true);
        }
    }
}
