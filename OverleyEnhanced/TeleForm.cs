using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OverleyEnhanced
{
    public partial class TeleForm : OverleyEnhanced.EnhancedImageForm
    {
        public TeleForm()
        {
            InitializeComponent();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
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

        override protected void buttonRun_Click(object sender, EventArgs e)
        {
            ((TeleImageBox)m_source).Qt = Convert.ToDouble(textBoxQt.Text);
            ((TeleImageBox)m_source).Qomega = Convert.ToDouble(textBoxQomega.Text);
            base.buttonRun_Click(sender, e);
        }

        override protected void UpdateImageList()
        {
            for (int i = 2; i < Buffer.imageList.Count; i++)
            {
                ((EnhancedImageBox)Buffer.imageList[i]).UpdateFlag = true;
            }
        }

        override protected void Form_Load(object sender, System.EventArgs e)
        {
            base.Form_Load(sender, e);
            if (this.Site == null || !this.Site.DesignMode) {
                textBoxQomega.Text = Convert.ToString(((TeleImageBox)m_source).Qomega);
                textBoxQt.Text = Convert.ToString(((TeleImageBox)m_source).Qt);
            } 
        }
    }
}
