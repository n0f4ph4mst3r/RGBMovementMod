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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Buffer.source = new Bitmap(openFileDialog.FileName);
                Buffer.JPEGConatiner.Update(Buffer.source);
                Buffer.sRGBConatiner.Update(Buffer.source);
                SourceForm srcForm = new SourceForm();
                srcForm.MdiParent = this;
                srcForm.Show();
                окнаToolStripMenuItem.Enabled = true;
            }
            else return;
        }
    }
}
