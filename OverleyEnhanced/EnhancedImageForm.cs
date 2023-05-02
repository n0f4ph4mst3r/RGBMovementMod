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
            if (((EnhancedImagePair)m_source).UpdateFlag)
            {
                ((EnhancedImagePair)m_source).Update();
                UpdateImage();
            }
        }

        protected void UpdateImageList()
        {
            for (int i = 0; m_dependencies != null && i < m_dependencies.Length; i++)
            {
                ((EnhancedImagePair)m_dependencies[i]).UpdateFlag = true;
            }     
        }

        virtual protected void buttonRun_Click(object sender, EventArgs e)
        {
            ((EnhancedImagePair)m_source).Update();
            UpdateImage();
            UpdateImageList();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(m_source as EnhancedImagePair);
            form.ShowDialog(this);
        }
    }
}
