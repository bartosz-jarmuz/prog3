using Prog3.Common.Contracts;
using Prog3.Common.Counters;
using Prog3.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Common.Helpers
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

        public ICounter AddNewCounter(CounterType type, string iterations, string delay)
        {
            ICounter counter;
            switch (type)
            {
                case CounterType.NumericCounter:
                    counter = CreateNumericCounter(iterations, delay);
                    break;
                case CounterType.TextCounter:
                    counter = CreateTextCounter(iterations, delay);
                    break;
                default:
                    throw new Exception("Unknown counter type");
            }

            return AddCounter(counter);
        }

        private ICounter CreateNumericCounter(string iterations, string delay)
        {
            if (!int.TryParse(iterations, out int iterationsInt) || (iterationsInt < 1))
            {
                throw new Exception("Iterations must be integer greater or equal to 1");
            }

            if (!int.TryParse(delay, out int delayInt) || (delayInt < 1))
            {
                throw new Exception("Delay must be integer greater or equal to 0");
            }

            return new NumericCounter(iterationsInt, delayInt, GetNewName(CounterType.NumericCounter));
        }

        private ICounter CreateTextCounter(string iterations, string delay)
        {
            if (!NumeralsConverter.IsValidNumber(iterations, 1))
            {
                throw new Exception("Iterations must be numeral of integer greater or equal to 1");
            }

            if (!NumeralsConverter.IsValidNumber(delay, 1))
            {
                throw new Exception("Delay must be numeral of integer greater or equal to 0");
            }

            return new TextCounter(iterations, delay, GetNewName(CounterType.TextCounter));
        }

        private string GetNewName(CounterType type)
        {
            return $"Counter #{ActiveCounters.Count + 1} ({type.GetLabel()})";
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
                if (!this.ActiveCounters.Any(c => c.Status == CounterStatus.Working))
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

        public void ResetCounters()
        {
            lock (this)
            {
                foreach (ICounter counter in this.ActiveCounters)
                {
                    counter.ResetCounter();
                }
            }
        }

    }
}
