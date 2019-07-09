using Prog3.Common.Contracts;
using Prog3.Common.Counters;
using Prog3.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog3.WinFormsClient
{
    public partial class Form1 : Form
    {
        private CounterManager counterManager;
        private UIHandler uIHandler;

        public Form1()
        {
            InitializeComponent();
            BindCounterTypesComboBox();
            uIHandler = new UIHandler(ListBoxCounters, PanelControls);
            counterManager = new CounterManager(uIHandler.NotifyCompleted, uIHandler.UpdateStatus);
        }

        private void BindCounterTypesComboBox()
        {
            List<KeyValuePair<CounterType, string>> counterTypes = new List<KeyValuePair<CounterType, string>>();
            Array values = Enum.GetValues(typeof(CounterType));

            foreach (int val in values)
            {
                CounterType temp = (CounterType)val;
                counterTypes.Add(new KeyValuePair<CounterType, string>(temp, temp.GetLabel()));
            }
            ComboBoxCounterType.DataSource = counterTypes;
            ComboBoxCounterType.DisplayMember = "Value";
        }

        private void ButtonAddCounter_Click(object sender, EventArgs e)
        {
            try
            {
                CounterType selectedCounterType = ((KeyValuePair<CounterType, string>)ComboBoxCounterType.SelectedItem).Key;
                ICounter counter = counterManager.AddNewCounter(selectedCounterType, TextBoxIterations.Text, TextBoxDelay.Text);
                ListBoxCounters.Items.Add(new CounterViewItem(counter, false));
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            PanelControls.Enabled = false;
            counterManager.StartAllCounters();
            uIHandler.RunUpdater();
        }
    }
}
