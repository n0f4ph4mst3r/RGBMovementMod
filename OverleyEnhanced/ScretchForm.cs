using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OverleyEnhanced
{
    public partial class ScretchForm : OverleyEnhanced.EnhancedImageForm
    {
        public ScretchForm()
        {
            InitializeComponent();
        }

        private void textBoxQ_KeyPress(object sender, KeyPressEventArgs e)
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
            ((ScretchImageBox)m_source).Q = Convert.ToDouble(textBoxQ.Text);
            base.buttonRun_Click(sender, e);
        }

        override protected void UpdateImageList() 
        {
            for (int i = 1; i < Buffer.imageList.Count; i++)
            {
                ((EnhancedImageBox)Buffer.imageList[i]).UpdateFlag = true;
            }
        }

        override protected void Form_Load(object sender, System.EventArgs e)
        {
            base.Form_Load(sender, e);
            if (this.Site == null || !this.Site.DesignMode) textBoxQ.Text = Convert.ToString(((ScretchImageBox)m_source).Q);
        }
    }
}
