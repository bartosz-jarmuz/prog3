using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prog3.Contracts;

namespace Prog3.Counters
{
    public class NumericCounter: ICounter
    {
        public string Name { get; set; }
        public bool Working { get; set; }

        public event Action<ICounter> OnTick;
        public event Action<ICounter> OnComplete;

        public int Iterations { get; private set; }
        public int Iteration { get; private set; }
        public int Delay { get; private set; }


        public NumericCounter(int iterations, int delay, string name)
        {
            this.Iterations = iterations;
            this.Delay = delay;
            this.Name = name;
            this.Working = true;
        }

        public void StartCounter()
        {
            Task task = Task.Factory.StartNew(() => DoWork(this.Name, this.Iterations, this.Delay));
            task.ContinueWith(t => FlagCompleted());
        }

        protected void FlagCompleted()
        {
            OnComplete(this);
        }

        protected void DoWork(string name, int iterations, int delay)
        {
            this.Iteration = 1;
            bool end = false;
            while (!end)
            {
                OnTick(this);
                Thread.Sleep(delay);
                if (this.Iteration < iterations)
                {
                    this.Iteration++;
                } 
                else
                {
                    end = true;
                }
            }
        }
    }
}
