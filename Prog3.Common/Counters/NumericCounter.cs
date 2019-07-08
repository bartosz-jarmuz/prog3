﻿using Prog3.Common.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prog3.Common.Counters
{
    public class NumericCounter: ICounter
    {
        public string Name { get; set; }
        public bool Working { get; set; }

        public event Action<ICounter> OnTick;
        public event Action<ICounter> OnComplete;

        public int Iterations { get; protected set; }
        public int Iteration { get; protected set; }
        public int Delay { get; protected set; }


        public NumericCounter(int iterations, int delay, string name)
        {
            this.Iterations = iterations;
            this.Delay = delay;
            this.Name = name;
        }

        public void StartCounter()
        {
            if (this.Iterations < 1)
            {
                return;
            }
            Task task = Task.Factory.StartNew(() => DoWork(this.Iterations, this.Delay));
            task.ContinueWith(t => FlagCompleted());
        }

        protected void FlagCompleted()
        {
            this.Working = false;
            OnComplete(this);
        }

        protected void DoWork(int iterations, int delay)
        {
            this.Working = true;
            this.Iteration = 1;
            bool end = false;
            while (!end)
            {
                Thread.Sleep(delay);
                OnTick(this);
                if (this.Iteration < iterations)
                {
                    this.Iteration++;
                } 
                else
                {
                    end = true;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} [n = {Iterations}, t = {Delay}]";
        }
    }
}