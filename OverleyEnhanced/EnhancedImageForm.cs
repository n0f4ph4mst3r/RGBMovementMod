using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OverleyEnhanced
{
    public partial class EnhancedImageForm : OverleyEnhanced.ImageForm
    {
        public EnhancedImageForm()
        {
            InitializeComponent();
        }

        virtual protected void Form_Load(object sender, System.EventArgs e) { }

        override protected void UpdateImage(object sender, EventArgs e)
        {
            if (((EnhancedImageBox)m_source).UpdateFlag)
            {
                UpdateImageList();
                ((EnhancedImageBox)m_source).Update();
            }
            UpdateImage();
        }

        virtual protected void UpdateImageList()
        {
            UpdateImage();
        }

        virtual protected void buttonRun_Click(object sender, EventArgs e)
        {
            UpdateImageList();
            ((EnhancedImageBox)m_source).Update();
            UpdateImage();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(m_source as EnhancedImageBox);
            form.ShowDialog(this);
        }
    }
}
