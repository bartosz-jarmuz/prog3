using System;
using System.Collections.Generic;
using Prog3.Contracts;
using Prog3.Counters;

namespace Prog3.ConsoleClient
{
    class UIHandler : IUIHandler
    {
        readonly string msgAnotherCounter = "Add another counter? [Y/N]";
        readonly string[] answYesNo = new string[] {"y", "n"};

        readonly string msgCounterType = "What kind of counter do you need?" + Environment.NewLine +
                                         "[1] - Numeric counter" + Environment.NewLine +
                                         "[2] - Text counter" + Environment.NewLine +
                                         "---" + Environment.NewLine +
                                         "[C] - Cancel";
        readonly string[] answCounterType = new string[] { "1", "2" };

        readonly string msgIterations = "How many iterations?";
        readonly string msgDelayMs = "What delay (in miliseconds)?";
        readonly string msgDelayS = "What delay (in seconds)?";
        readonly string msgWrongInput = "Don't understand, try again...";


        int countersCreated = 0;


        public void NotifyCompleted(CounterManager taskManager)
        {
            Console.WriteLine();
            Console.WriteLine("All tasks completed");
        }

        public void UpdateStatus(CounterManager taskManager)
        {
            Console.Clear();
            foreach (ICounter task in taskManager.ActiveCounters)
            {
                string prefix = " ";
                if (task == taskManager.LastActiveCounter)
                {
                    prefix = ">";
                }

                Console.WriteLine($"{prefix}{task.Name}:\titeration #{task.Iteration}");
            }
        }


        public IEnumerable<ICounter> CollectCountersInfo()
        {
            do
            {
                ICounter newCounter = CreateCounter();
                if (newCounter == null)
                {
                    break;
                }
                else
                {
                    yield return newCounter;

                    Console.Clear();
                    Console.WriteLine($"Created new counter: {newCounter}");

                    if (OfferAnotherCounter() == "n")
                    {
                        break;
                    }
                }

            } while (true);

            Console.Clear();
        }

        private ICounter CreateCounter()
        {
            switch (OfferCounterTypes())
            {
                case "1":
                    return CreateNumericCounter();
                case "2":
                    return CreateTextCounter();
            }
            return null;
        }

        private ICounter CreateNumericCounter()
        {
            string iterations = AskIterationsInt();
            if (iterations == "c")
            {
                return null;
            }

            string delay = AskDelayInt();
            if (delay== "c")
            {
                return null;
            }

            return new NumericCounter(int.Parse(iterations), int.Parse(delay), $"Counter #{++countersCreated} (numeric)");
        }

        private ICounter CreateTextCounter()
        {
            string iterations = AskIterationsText();
            if (iterations == "c")
            {
                return null;
            }

            string delay = AskDelayTetx();
            if (delay == "c")
            {
                return null;
            }

            return new TextCounter(iterations, delay, $"Counter #{++countersCreated} (text)");
        }

        private string GetUserInput(string message, object possibleAnswers)
        {
            bool answerOk = false;
            string input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine().ToLower();

                if (possibleAnswers is Array)
                {
                    foreach (string a in possibleAnswers as Array)
                    {
                        if (a == input)
                        {
                            answerOk = true;
                            break;
                        }
                    }
                }
                else if (possibleAnswers is int)
                {
                    answerOk = int.TryParse(input, out int t);
                }
                else if (possibleAnswers is string)
                {
                    answerOk = NumeralsConverter.IsValidNumber(input);
                }

                if (input == "c")
                {
                    answerOk = true;
                }

                if (!answerOk)
                {
                    WrongAnswer();
                }

            } while (!answerOk);

            return input;
        }

        private string AskIterationsInt()
        {
            Console.WriteLine();
            return GetUserInput(msgIterations, 0);
        }

        private string AskIterationsText()
        {
            Console.WriteLine();
            return GetUserInput(msgIterations, "");
        }

        private string AskDelayInt()
        {
            Console.WriteLine();
            return GetUserInput(msgDelayMs, 0);
        }

        private string AskDelayTetx()
        {
            Console.WriteLine();
            return GetUserInput(msgDelayS, "");
        }

        private string OfferAnotherCounter()
        {
            Console.WriteLine();
            return GetUserInput(msgAnotherCounter, answYesNo);
        }

        private string OfferCounterTypes()
        {
            Console.Clear();
            return GetUserInput(msgCounterType, answCounterType);
        }

        private void WrongAnswer()
        {
            Console.WriteLine(msgWrongInput);
        }
    }
}
