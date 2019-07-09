using Prog3.Common.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prog3.Common.Counters
{
    public class NumericCounter: ICounter
    {
        public string Name { get; set; }
        public CounterStatus Status { get; protected set; } = CounterStatus.Ready;

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
        }

        public void StartCounter()
        {
            if (this.Iterations < 1)
            {
                return;
            }
            Task task = Task.Factory.StartNew(() => DoWork(this.Iterations, this.Delay));
            task.ContinueWith(t => FlagCompleted());
        }

        protected void FlagCompleted()
        {
            //this.Working = false;
            this.Status = CounterStatus.Done;
            OnComplete(this);
        }

        protected void DoWork(int iterations, int delay)
        {
            //this.Working = true;
            this.Status = CounterStatus.Working;
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

        public void ResetCounter()
        {
            this.Status = CounterStatus.Ready;
            this.Iteration = 0;
        }

        public override string ToString()
        {
            string iterationInfo = "";
            if (this.Status != CounterStatus.Ready)
            {
                iterationInfo = $": iteration #{Iteration}";
            }
            return $"{Name} [n = {Iterations}, t = {Delay}ms]{iterationInfo}";
        }
    }
}
