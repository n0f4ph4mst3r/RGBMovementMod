using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OverleyEnhanced
{
    public partial class OverleyForm : OverleyEnhanced.EnhancedImageForm
    {
        public OverleyForm()
        {
            InitializeComponent();
        }

        override protected void UpdateImage(object sender, EventArgs e)
        {
            if (((OverleyImageBox)m_source).UpdateFlag) ((OverleyImageBox)m_source).Update();
            UpdateImage();
        }

        private void textBoxK_KeyPress(object sender, KeyPressEventArgs e)
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
             ((OverleyImageBox)m_source).K = Convert.ToDouble(textBoxK.Text);
             base.buttonRun_Click(sender, e);
        }

        override protected void UpdateImageList()
        {
            ((EnhancedImageBox)Buffer.imageList[3]).UpdateFlag = true;
        }

        override protected void Form_Load(object sender, System.EventArgs e)
        {
            base.Form_Load(sender, e);
            if (this.Site == null || !this.Site.DesignMode)
            {
                textBoxK.Text = Convert.ToString(((OverleyImageBox)m_source).K);
            }
        }
    }
}
