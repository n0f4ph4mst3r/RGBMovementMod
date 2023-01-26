using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OverleyEnhanced
{
    public partial class SettingsForm : Form
    {
        protected EnhancedImageBox m_source;
        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(EnhancedImageBox source)
        {
            InitializeComponent();
            m_source = source;
        }

        private void textBoxSaturation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxCriterion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!checkBoxParameters.Checked)
            {
                m_source.Saturation = Convert.ToDouble(textBoxSaturation.Text);
                m_source.Criterion = Convert.ToByte(textBoxCriterion.Text);
            }
            m_source.ParametersFlag = !checkBoxParameters.Checked;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxParameters_CheckedChanged(object sender, EventArgs e)
        {
            labelCriterion.Enabled = labelSaturation.Enabled = textBoxCriterion.Enabled = textBoxSaturation.Enabled = !checkBoxParameters.Checked;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBoxSaturation.Text = Convert.ToString(m_source.Saturation);
            textBoxCriterion.Text = Convert.ToString(m_source.Criterion);
            checkBoxParameters.Checked = !m_source.ParametersFlag;
            labelCriterion.Enabled = labelSaturation.Enabled = textBoxCriterion.Enabled = textBoxSaturation.Enabled = !checkBoxParameters.Checked;
        }
    }
}
