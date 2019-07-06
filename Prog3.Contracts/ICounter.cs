using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Contracts
{
    public interface ICounter
    {
        string Name { get; set; }
        bool Working { get; set; }
        int Iteration { get; }

        void StartCounter();

        event Action<ICounter> OnTick;
        event Action<ICounter> OnComplete;
    }
}
