using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static OverleyEnhanced.EnhancedImage;

namespace OverleyEnhanced
{
    public partial class MainForm : Form
    {
        ImageForm m_sourceForm;
        List<Form> m_listForm;
        List<Form> m_listForm2;

        public MainForm()
        {
            InitializeComponent();

            Buffer.imageList = new List<ImagePair>(3);
            Buffer.imageList2 = new List<ImagePair>(3);

            m_sourceForm = new ImageForm();
            m_listForm = new List<Form>(3);
            m_listForm2 = new List<Form>(3);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (Form frm in MdiChildren)
                {
                   frm.Dispose();
                   frm.Close();
                }

                dScretchToolStripMenuItem.Checked = false;
                eScretchToolStripMenuItem.Checked = false;
                dTeleToolStripMenuItem.Checked = false;
                eTeleToolStripMenuItem.Checked = false;
                dOverleyToolStripMenuItem.Checked = false;
                eOverleyToolStripMenuItem.Checked = false;

                Bitmap source = new Bitmap(openFileDialog.FileName);
                Buffer.imageList.Clear();
                Buffer.imageList2.Clear();

                SourceWrapper sourceImageJPEG = new SourceWrapper(source, new PerceptionCoffs(0.299, 0.587, 0.114));
                SourceWrapper sourceImageSRGB = new SourceWrapper(source, new PerceptionCoffs(0.2126, 0.7152, 0.0722));
                Buffer.source = new ImagePair(sourceImageJPEG, sourceImageSRGB);

                ScretchWrapper scretchImageJPEG = new ScretchWrapper(sourceImageJPEG);
                ScretchWrapper scretchImageSRGB = new ScretchWrapper(sourceImageSRGB);
                ScretchImagePair scretchBox = new ScretchImagePair(scretchImageJPEG, scretchImageSRGB);
                Buffer.imageList.Add(scretchBox);

                ScretchWrapper scretchImageJPEG2 = new ScretchWrapper(sourceImageJPEG, MovementType.ENHANCED);
                ScretchWrapper scretchImageSRGB2 = new ScretchWrapper(sourceImageSRGB, MovementType.ENHANCED);
                ScretchImagePair scretchBox2 = new ScretchImagePair(scretchImageJPEG2, scretchImageSRGB2);
                Buffer.imageList2.Add(scretchBox2);

                TeleWrapper teleImageJPEG = new TeleWrapper(sourceImageJPEG, scretchImageJPEG);
                TeleWrapper teleImageSRGB = new TeleWrapper(sourceImageSRGB, scretchImageSRGB);
                TeleImagePair teleBox = new TeleImagePair(teleImageJPEG, teleImageSRGB);
                Buffer.imageList.Add(teleBox);

                TeleWrapper teleImageJPEG2 = new TeleWrapper(sourceImageJPEG, scretchImageJPEG2, MovementType.ENHANCED);
                TeleWrapper teleImageSRGB2 = new TeleWrapper(sourceImageSRGB, scretchImageSRGB2, MovementType.ENHANCED);
                TeleImagePair teleBox2 = new TeleImagePair(teleImageJPEG2, teleImageSRGB2);
                Buffer.imageList2.Add(teleBox2);

                OverleyWrapper overleyImageJPEG = new OverleyWrapper(sourceImageJPEG, scretchImageJPEG, teleImageJPEG);
                OverleyWrapper overleyImageSRGB = new OverleyWrapper(sourceImageSRGB, scretchImageSRGB, teleImageSRGB);
                OverleyImagePair overleyBox = new OverleyImagePair(overleyImageJPEG, overleyImageSRGB);
                Buffer.imageList.Add(overleyBox);

                OverleyWrapper overleyImageJPEG2 = new OverleyWrapper(sourceImageJPEG, scretchImageJPEG2, teleImageJPEG2, MovementType.ENHANCED);
                OverleyWrapper overleyImageSRGB2 = new OverleyWrapper(sourceImageSRGB, scretchImageSRGB2, teleImageSRGB2, MovementType.ENHANCED);
                OverleyImagePair overleyBox2 = new OverleyImagePair(overleyImageJPEG2, overleyImageSRGB2);
                Buffer.imageList2.Add(overleyBox2);

                m_listForm.Add(default(ScretchForm));
                m_listForm.Add(default(TeleForm));
                m_listForm.Add(default(OverleyForm));

                m_listForm2.Add(default(ScretchForm));
                m_listForm2.Add(default(TeleForm));
                m_listForm2.Add(default(OverleyForm));

                окнаToolStripMenuItem.Enabled = true;
                m_sourceForm = new ImageForm();
                m_sourceForm.InitImage(Buffer.source);
                m_sourceForm.FormClosed += new FormClosedEventHandler(SourceFormClosed);
                m_sourceForm.MdiParent = this;
                m_sourceForm.Show();
                srcToolStripMenuItem.Checked = true;
            }
            else return;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e, Form form, FormClosedEventHandler handler)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Checked)
            {
                form.FormClosed += new FormClosedEventHandler(handler);
                form.MdiParent = this;
                form.Show();
                item.Checked = true;
            }
            else form.Close();
        }

        private void SourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (srcToolStripMenuItem.Checked)
            {
                if (m_sourceForm == null) m_sourceForm = new ImageForm();
                m_sourceForm.InitImage(Buffer.source);
            }
            ToolStripMenuItem_Click(sender, e, m_sourceForm, SourceFormClosed);
        }

        private void SourceFormClosed(object sender, EventArgs e)
        {
            srcToolStripMenuItem.Checked = false;
        }

        private void dScretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dScretchToolStripMenuItem.Checked)
            {
                m_listForm[0] = new ScretchForm();
                ((ScretchForm)m_listForm[0]).InitImage(Buffer.imageList[0], new ImagePair[] { Buffer.imageList[1], Buffer.imageList[2] });
            }
            ToolStripMenuItem_Click(sender, e, m_listForm[0], dScrethFormClosed);
        }

        private void dScrethFormClosed(object sender, EventArgs e)
        {
            dScretchToolStripMenuItem.Checked = false;
        }

        private void eScretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eScretchToolStripMenuItem.Checked)
            {
                m_listForm2[0] = new ScretchForm();
                ((ScretchForm)m_listForm2[0]).InitImage(Buffer.imageList2[0], new ImagePair[] { Buffer.imageList2[1], Buffer.imageList2[2] });
            }
            ToolStripMenuItem_Click(sender, e, m_listForm2[0], eScrethFormClosed);
        }

        private void eScrethFormClosed(object sender, EventArgs e)
        {
            eScretchToolStripMenuItem.Checked = false;
        }

        private void dTeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dTeleToolStripMenuItem.Checked)
            {
                 m_listForm[1] = new TeleForm();
                ((TeleForm)m_listForm[1]).InitImage(Buffer.imageList[1], new ImagePair[] { Buffer.imageList[2] });
                ToolStripMenuItem_Click(sender, e, m_listForm[1], dTeleFormClosed);
            }
        }

        private void dTeleFormClosed(object sender, EventArgs e)
        {
            dTeleToolStripMenuItem.Checked = false;
        }

        private void eTeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eTeleToolStripMenuItem.Checked)
            {
                m_listForm2[1] = new TeleForm();
                ((TeleForm)m_listForm2[1]).InitImage(Buffer.imageList2[1], new ImagePair[] { Buffer.imageList2[2] });
                ToolStripMenuItem_Click(sender, e, m_listForm2[1], eTeleFormClosed);
            }
        }

        private void eTeleFormClosed(object sender, EventArgs e)
        {
            eTeleToolStripMenuItem.Checked = false;
        }

        private void dOverleyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dOverleyToolStripMenuItem.Checked)
            {
                 m_listForm[2] = new OverleyForm();
                ((OverleyForm)m_listForm[2]).InitImage(Buffer.imageList[2]);
            }
            ToolStripMenuItem_Click(sender, e, m_listForm[2], dOverleyFormClosed);
        }

        private void dOverleyFormClosed(object sender, EventArgs e)
        {
            dOverleyToolStripMenuItem.Checked = false;
        }

        private void eOverleyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eOverleyToolStripMenuItem.Checked)
            {
                m_listForm2[2] = new OverleyForm();
                ((OverleyForm)m_listForm2[2]).InitImage(Buffer.imageList2[2]);
            }
            ToolStripMenuItem_Click(sender, e, m_listForm2[2], eOverleyFormClosed);
        }

        private void eOverleyFormClosed(object sender, EventArgs e)
        {
            eOverleyToolStripMenuItem.Checked = false;
        }
    }
}
