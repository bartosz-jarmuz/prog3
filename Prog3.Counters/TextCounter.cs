using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog3.Contracts;

namespace Prog3.Counters
{
    public class TextCounter : NumericCounter, ICounter
    {
        private bool areParametersConvrted = false;

        private readonly string stringIterations;
        private readonly string stringDelay;

        public TextCounter(string iterations, string delay, string name) : base(0, 0, name)
        {
            this.stringIterations = iterations;
            this.stringDelay = delay;
            this.Name = name;
        }

        public new void StartCounter()
        {
            if (!areParametersConvrted)
            {
                ConvertParams();
                areParametersConvrted = true;
            }
            base.StartCounter();
        }

        private void ConvertParams()
        {
            this.Iterations = NumeralsConverter.NumeralToNumber(this.stringIterations);
            this.Delay = NumeralsConverter.NumeralToNumber(this.stringDelay);
        }
    }
}
