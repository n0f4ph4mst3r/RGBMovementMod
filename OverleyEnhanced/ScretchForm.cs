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
    public partial class ScretchForm : Form
    {
        public ScretchForm()
        {
            InitializeComponent();
        }

        private void ScretchForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateImage()
        {
            pictureBox.Image = Buffer.source;
            SetFrequencys();
        }

        private void SetFrequencys()
        {
            List<double> frequencyScale = JPEGButton.Checked ? Buffer.JPEGConatiner.ImageList[1].FrequencyScale : Buffer.sRGBConatiner.ImageList[1].FrequencyScale;
            chart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                chart.Series[0].Points.AddY(frequencyScale[i]);
            }
        }
    }
}
