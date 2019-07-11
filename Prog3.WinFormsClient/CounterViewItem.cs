using Prog3.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3.WinFormsClient
{
    class CounterViewItem
    {
        public string Text { get => counter.ToString(); } //interesting notation:)
        public CounterStatus Status { get => counter.Status; }
        public bool Marked { get; }

        private readonly ICounter counter;

        public CounterViewItem(ICounter counter, bool marked)
        {
            this.counter = counter;
            this.Marked = marked;
        }

        public override string ToString()
        {
            return counter.ToString();
        }
    }
}
