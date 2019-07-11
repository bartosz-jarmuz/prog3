using Prog3.Common.Contracts;
using Prog3.Common.Counters;
using Prog3.Common.Helpers;
using Prog3.Common.Utils;
using System;
using System.Collections.Generic;

namespace Prog3.ConsoleClient
{
    class UIHandler : IUIHandler //nicely done
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


        public void NotifyCompleted(CounterManager counterManager)
        {
            Console.WriteLine();
            Console.WriteLine("All tasks completed");
        }

        public void UpdateStatus(CounterManager counterManager)
        {
            Console.Clear();
            foreach (ICounter counter in counterManager.ActiveCounters)
            {
                string prefix = " ";
                if (counter == counterManager.LastActiveCounter)
                {
                    prefix = ">";
                }

                Console.WriteLine($"{prefix}{counter.ToString()}");
            }
        }


        public IEnumerable<ICounter> CollectCountersInfo()
        {
            do
            {
                ICounter newCounter = null;
                try
                {
                    newCounter = CreateCounter();
                }
                catch
                {
                    //swallow Cancel exception
                    //why swallow?
                }

                Console.Clear();
                if (newCounter != null)
                {
                    yield return newCounter;
                    Console.WriteLine($"Created new counter: {newCounter}");
                }

            } while (OfferAnotherCounter() != "n");

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
            string delay = AskDelayInt();

            return new NumericCounter(int.Parse(iterations), int.Parse(delay), $"Counter #{++countersCreated} (numeric)");
        }

        private ICounter CreateTextCounter()
        {
            string iterations = AskIterationsText();
            string delay = AskDelayTetx();

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

                if (possibleAnswers is Array) //have a look at 'Pattern matching' syntactic sugar (it's not wrong though)
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
                    answerOk = int.TryParse(input, out int t) && (t >= (int)possibleAnswers);
                }
                else if (possibleAnswers is string)
                {
                    answerOk = NumeralsConverter.IsValidNumber(input, int.Parse((string)possibleAnswers));
                }

                if (input == "c")
                {
                    throw new Exception("Canceled");
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
            return GetUserInput(msgIterations, 1);
        }

        private string AskIterationsText()
        {
            Console.WriteLine();
            return GetUserInput(msgIterations, "1");
        }

        private string AskDelayInt()
        {
            Console.WriteLine();
            return GetUserInput(msgDelayMs, 0);
        }

        private string AskDelayTetx()
        {
            Console.WriteLine();
            return GetUserInput(msgDelayS, "0");
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
