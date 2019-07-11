using Prog3.Common.Contracts;
using Prog3.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Common.Counters
{
    public class TextCounter : NumericCounter, ICounter
    {
        private bool areParametersConverted = false;

        private int iterationsValue;
        public new int Iterations //why 'new'?
        {
            get {
                ConvertParams();
                return iterationsValue;
            }
            protected set {
                iterationsValue = value;
                base.Iterations = value;
            }
        }

        private int delayValue;
        public new int Delay //why 'new'?
        {
            get
            {
                ConvertParams();
                return delayValue;
            }
            protected set
            {
                delayValue = value;
                base.Delay = value;
            }
        }

        private readonly string stringIterations;
        private readonly string stringDelay;

        public TextCounter(string iterations, string delay, string name) : base(0, 0, name)
        {
            this.stringIterations = iterations;
            this.stringDelay = delay;
            this.Name = name;
        }

        public new void StartCounter() //why 'new'? also, what is the point of this method?
        {
            base.StartCounter();
        }

        private void ConvertParams()
        {
            if (!areParametersConverted)
            {
                this.Iterations = NumeralsConverter.NumeralToNumber(this.stringIterations);
                this.Delay = NumeralsConverter.NumeralToNumber(this.stringDelay) * 1000;
                areParametersConverted = true;
            }
        }

        public override string ToString()
        {
            string iterationInfo = "";
            if (this.Status != CounterStatus.Ready)
            {
                iterationInfo = $": iteration #{Iteration}";
            }
            return $"{Name} [n = {Iterations}, t = {Delay/1000}s]{iterationInfo}";
        }
    }
}
