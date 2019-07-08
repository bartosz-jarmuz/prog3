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
        public string Text { get; private set; }
        public bool Marked { get; private set; }
        public bool Active { get; private set; }

        public CounterViewItem(ICounter counter, bool marked, bool active, bool showSettings = false)
        {
            this.Text = showSettings ? counter.ToString() : $"{counter.ToString()}: iteration #{counter.Iteration}";
            this.Marked = marked;
            this.Active = active;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
