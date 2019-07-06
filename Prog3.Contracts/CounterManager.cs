using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Contracts
{
    public class CounterManager
    {
        public List<ICounter> ActiveCounters { get; set; } = new List<ICounter>();
        public ICounter LastActiveCounter { get; private set; }

        private readonly Action<CounterManager> onCompleted;
        private readonly Action<CounterManager> onUpdated;

        public CounterManager(Action<CounterManager> onCompleted, Action<CounterManager> onUpdated)
        {
            this.onCompleted = onCompleted;
            this.onUpdated = onUpdated;
        }

        public ICounter AddCounter(ICounter counter)
        {
            counter.OnTick += this.UpdateStatus;
            counter.OnComplete += this.FinalizeTask;
            ActiveCounters.Add(counter);
            return counter;
        }

        public void StartAllCounters()
        {
            lock (this)
            {
                foreach (ICounter counter in this.ActiveCounters)
                {
                    counter.StartCounter();
                }
            }
        }

        private void FinalizeTask(ICounter counter)
        {
            lock (this)
            {
                counter.Working = false;
                if (!this.ActiveCounters.Any(c => c.Working))
                {
                    onCompleted(this);
                }
            }
        }

        private void UpdateStatus(ICounter counter)
        {
            lock (this)
            {
                this.LastActiveCounter = counter;
                onUpdated(this);
            }
        }
    }
}
