using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Common.Counters
{
    public enum CounterType
    {
        [Description("Numeric counter")]
        NumericCounter = 1,

        [Description("Text counter")]
        TextCounter
    }
}
