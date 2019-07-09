using Prog3.Common.Contracts;
using Prog3.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog3.WinFormsClient
{
    class UIHandler: IUIHandler
    {
        private readonly ListBox listBoxCounters;
        private readonly Panel panelControls;

        private List<CounterViewItem> viewBuffer = new List<CounterViewItem>();
        private bool updateNeeded = false;
        private bool workFinished = false;

        public UIHandler(ListBox listBoxCounters, Panel panelControls)
        {
            this.listBoxCounters = listBoxCounters;
            this.panelControls = panelControls;
            this.listBoxCounters.DrawItem += new DrawItemEventHandler(this.ListBoxCounters_DrawItem);
        }

        public void NotifyCompleted(CounterManager counterManager)
        {
            UpdateViewBuffer(counterManager);
            workFinished = true;
        }

        public void UpdateStatus(CounterManager counterManager)
        {
            UpdateViewBuffer(counterManager);
            updateNeeded = true;
        }

        private void UpdateViewBuffer(CounterManager counterManager)
        {
            lock (viewBuffer)
            {
                viewBuffer.Clear();
                foreach (ICounter counter in counterManager.ActiveCounters)
                {
                    viewBuffer.Add(new CounterViewItem(counter, counter == counterManager.LastActiveCounter));
                }
            }
        }

        public void RunUpdater()
        {
            while (!workFinished)
            {
                if (updateNeeded)
                {
                    updateNeeded = false;
                    UpdateCounterList();
                }
                Application.DoEvents();
            }

            panelControls.Enabled = true;
            UpdateCounterList();
        }

        private void UpdateCounterList()
        {
            lock (viewBuffer)
            {
                listBoxCounters.Items.Clear();
                foreach (CounterViewItem viewItem in viewBuffer)
                {
                    listBoxCounters.Items.Add(viewItem);
                }
            }
        }

        public void ListBoxCounters_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            KnownColor background = e.State.HasFlag(DrawItemState.Selected)? KnownColor.ActiveCaption : KnownColor.Window;

            g.FillRectangle(new SolidBrush(Color.FromKnownColor(background)), e.Bounds);

            if (e.Index >= 0)
            {
                CounterViewItem counter = (sender as ListBox).Items[e.Index] as CounterViewItem;
                string prefix = counter.Marked ? " >\t" : "\t";
                Color textColor;
                switch (counter.Status)
                {
                    case CounterStatus.Ready:
                        textColor = Color.Black;
                        break;
                    case CounterStatus.Working:
                        textColor = Color.Blue;
                        break;
                    case CounterStatus.Done:
                        textColor = Color.Gray;
                        break;
                    default:
                        throw new Exception("Unknown status");
                }
                g.DrawString($"{prefix}{counter.Text}", e.Font, new SolidBrush(textColor), new PointF(e.Bounds.X, e.Bounds.Y));
            }

            e.DrawFocusRectangle();
        }
    }
}
