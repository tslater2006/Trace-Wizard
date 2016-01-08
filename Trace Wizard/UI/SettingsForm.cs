using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraceWizard.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            longCallValue.Text = Properties.Settings.Default.LongCall.ToString();

        }

        private void longCallValue_TextChanged(object sender, EventArgs e)
        {
            double val = 0;
            if (double.TryParse(longCallValue.Text,out val))
            {
                Properties.Settings.Default.LongCall = val;
                Properties.Settings.Default.Save();
                longCallValue.BackColor = Color.White;
            } else
            {
                longCallValue.BackColor = Color.PaleVioletRed;
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            double val = 0;
            if (!double.TryParse(longCallValue.Text, out val))
            {
                MessageBox.Show("Long Call value must be a number. Please fix before exiting Settings.");
                e.Cancel = true;
            }
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
