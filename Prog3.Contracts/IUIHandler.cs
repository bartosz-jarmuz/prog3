using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.Contracts
{
    public interface IUIHandler
    {
        void UpdateStatus(CounterManager taskManager);
        void NotifyCompleted(CounterManager taskManager);
    }
}
