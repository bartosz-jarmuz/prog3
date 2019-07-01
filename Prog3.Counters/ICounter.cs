using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Counters
{
    public interface ICounter
    {
        string Name { get; set; }
        void StartCounter();

        event Action<string> OnTick;
    }
}
