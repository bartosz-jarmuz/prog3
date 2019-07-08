using Prog3.Common.Helpers;

namespace Prog3.Common.Contracts
{
    public interface IUIHandler
    {
        void UpdateStatus(CounterManager counterManager);
        void NotifyCompleted(CounterManager counterManager);
    }
}
