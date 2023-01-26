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
    public partial class ImageForm : Form
    {
        protected ImageBox m_source;

        public ImageForm()
        {
            InitializeComponent();
        }

        public void InitImage (ImageBox source)
        {
            m_source = source;
        }

        protected void UpdateImage()
        {
            pictureBox.Image = m_source.Img.Bit;
            chart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                chart.Series[0].Points.AddY(m_source.Img.FrequencyScale[i]);
            }
        }

        virtual protected void UpdateImage(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                m_source.SwitchImage();
                UpdateImage();
            }
        }
    }
}
