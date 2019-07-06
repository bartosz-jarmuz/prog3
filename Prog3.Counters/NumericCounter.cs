using System;
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

        public int Iterations { get; protected set; }
        public int Iteration { get; protected set; }
        public int Delay { get; protected set; }


        public NumericCounter(int iterations, int delay, string name)
        {
            this.Iterations = iterations;
            this.Delay = delay;
            this.Name = name;
            this.Working = true;
        }

        public void StartCounter()
        {
            Task task = Task.Factory.StartNew(() => DoWork(this.Iterations, this.Delay));
            task.ContinueWith(t => FlagCompleted());
        }

        protected void FlagCompleted()
        {
            OnComplete(this);
        }

        protected void DoWork(int iterations, int delay)
        {
            if (iterations < 1)
            {
                return;
            }
            this.Iteration = 1;
            bool end = false;
            while (!end)
            {
                Thread.Sleep(delay);
                OnTick(this);
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

        public override string ToString()
        {
            return $"{Name} [n = {Iterations}, t = {Delay}]";
        }
    }
}
