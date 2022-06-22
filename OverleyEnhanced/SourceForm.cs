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
    public partial class SourceForm : Form
    {
        public SourceForm()
        {
            InitializeComponent();
        }

        private void SourceForm_Load(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void UpdateImage()
        {
            pictureBox.Image = Buffer.source;
            SetFrequencys();
        }

        private void SetFrequencys()
        {
            List<double> frequencyScale = JPEGButton.Checked ? Buffer.JPEGConatiner.ImageList[0].FrequencyScale : Buffer.sRGBConatiner.ImageList[0].FrequencyScale;
            chart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                chart.Series[0].Points.AddY(frequencyScale[i]);
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            SetFrequencys();
        }
    }
}
