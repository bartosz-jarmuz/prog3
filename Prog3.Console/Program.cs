using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog3.Counters;
using Prog3.Contracts;

namespace Prog3.Console
{
    class Program
    {
        static CounterManager counters;
        static readonly IUIHandler uIHandler = new UIHandler();

        static void Main(string[] args)
        {
            counters = new CounterManager(uIHandler.NotifyCompleted, uIHandler.UpdateStatus);

            counters.AddCounter(CreateNumericCounter(2, 1000));
            counters.AddCounter(CreateNumericCounter(3, 850));
            counters.AddCounter(CreateNumericCounter(1, 800));
            counters.AddCounter(CreateTextCounter("2", "1000"));
            counters.AddCounter(CreateTextCounter("3", "850"));
            counters.AddCounter(CreateTextCounter("1", "800"));

            counters.StartAllTasks();

            System.Console.ReadKey(true);
        }

        private static ICounter CreateNumericCounter(int iterations, int delay)
        {
            ICounter counter = new NumericCounter(iterations, delay, $"Numeric counter {counters.ActiveCounters.Count + 1}");
            return counter;
        }

        private static ICounter CreateTextCounter(string iterations, string delay)
        {
            ICounter counter = new TextCounter(iterations, delay, $"Text counter {counters.ActiveCounters.Count + 1}");
            return counter;
        }
    }
}
