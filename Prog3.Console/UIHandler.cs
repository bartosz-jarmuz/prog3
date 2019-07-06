using Prog3.Contracts;

namespace Prog3.Console
{
    class UIHandler : IUIHandler
    {
        public void NotifyCompleted(CounterManager taskManager)
        {
            System.Console.WriteLine("All tasks completed");
        }

        public void UpdateStatus(CounterManager taskManager)
        {
            System.Console.Clear();
            foreach (ICounter task in taskManager.ActiveCounters)
            {
                string prefix = " ";
                if (task == taskManager.LastActiveCounter)
                {
                    prefix = ">";
                }

                System.Console.WriteLine($"{prefix}{task.Name}: iteration #{task.Iteration}");
            }
        }
    }
}
