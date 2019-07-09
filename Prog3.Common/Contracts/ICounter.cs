using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Common.Contracts
{
    public interface ICounter
    {
        string Name { get; set; }
        CounterStatus Status { get; }
        int Iteration { get; }

        void StartCounter();
        void ResetCounter();

        event Action<ICounter> OnTick;
        event Action<ICounter> OnComplete;
    }
}
