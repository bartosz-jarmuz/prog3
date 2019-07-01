using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prog3.Counters;

namespace Prog3.Counters
{
    public class NumericCounter: ICounter
    {
        public int Iterations { get; private set; }
        public int Delay { get; private set; }

        public string Name { get; set; }

        public event Action<string> OnTick;

        public NumericCounter(int iterations, int delay, string name)
        {
            this.Iterations = iterations;
            this.Delay = delay;
            this.Name = name;
        }

        public void StartCounter()
        {
            int counter = 0;
            while (counter++ < this.Iterations)
            {
                OnTick($"{Name}: iteration {counter}");
                Thread.Sleep(Delay);
            }
        }
    }
}
