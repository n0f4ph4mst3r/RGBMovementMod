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
        List<Form> m_listForm;

        public MainForm()
        {
            InitializeComponent();

            Buffer.imageList = new List<ImageBox>(4);
            m_listForm = new List<Form>(4);
            m_listForm.Add(new ImageForm());
            m_listForm.Add(new ScretchForm());
            m_listForm.Add(new TeleForm());
            m_listForm.Add(new OverleyForm());
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Buffer.source = new Bitmap(openFileDialog.FileName);
                Buffer.imageList.Clear();

                SourceWrapper sourceImageJPEG = new SourceWrapper(Buffer.source, new PerceptionCoffs(0.299, 0.587, 0.114));
                SourceWrapper sourceImageSRGB = new SourceWrapper(Buffer.source, new PerceptionCoffs(0.2126, 0.7152, 0.0722));
                ImageBox sourceBox = new ImageBox(sourceImageJPEG, sourceImageSRGB);
                Buffer.imageList.Add(sourceBox);

                ScretchWrapper scretchImageJPEG = new ScretchWrapper(sourceImageJPEG);
                ScretchWrapper scretchImageSRGB = new ScretchWrapper(sourceImageSRGB);
                ScretchImageBox scretchBox = new ScretchImageBox(scretchImageJPEG, scretchImageSRGB);
                Buffer.imageList.Add(scretchBox);

                TeleWrapper teleImageJPEG = new TeleWrapper(sourceImageJPEG, scretchImageJPEG);
                TeleWrapper teleImageSRGB = new TeleWrapper(sourceImageSRGB, scretchImageSRGB);
                TeleImageBox teleBox = new TeleImageBox(teleImageJPEG, teleImageSRGB);
                Buffer.imageList.Add(teleBox);

                OverleyWrapper overleyImageJPEG = new OverleyWrapper(sourceImageJPEG, scretchImageJPEG, teleImageJPEG);
                OverleyWrapper overleyImageSRGB = new OverleyWrapper(sourceImageSRGB, scretchImageSRGB, teleImageSRGB);
                OverleyImageBox overleyBox = new OverleyImageBox(overleyImageJPEG, overleyImageSRGB);
                Buffer.imageList.Add(overleyBox);

                окнаToolStripMenuItem.Enabled = true;
                m_listForm[0] = new ImageForm();
                ((ImageForm)m_listForm[0]).InitImage(Buffer.imageList[0]);
                m_listForm[0].FormClosed += new FormClosedEventHandler(SourceFormClosed);
                m_listForm[0].MdiParent = this;
                m_listForm[0].Show();
            }
            else return;
        }

        private void исходноеИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (srcToolStripMenuItem.Checked)
            {
                m_listForm[0] = new ImageForm();
                ((ImageForm)m_listForm[0]).InitImage(Buffer.imageList[0]);
                m_listForm[0].FormClosed += new FormClosedEventHandler(SourceFormClosed);
                m_listForm[0].MdiParent = this;
                m_listForm[0].Show();
            }
            else m_listForm[0].Close();
        }

        private void растяжениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scretchToolStripMenuItem.Checked)
            {
                m_listForm[1] = new ScretchForm();
                ((ScretchForm)m_listForm[1]).InitImage(Buffer.imageList[1]);
                m_listForm[1].FormClosed += new FormClosedEventHandler(ScrethFormClosed);
                m_listForm[1].MdiParent = this;
                m_listForm[1].Show();
            }
            else m_listForm[1].Close();
        }

        private void teleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (teleToolStripMenuItem.Checked)
            {
                m_listForm[2] = new TeleForm();
                ((TeleForm)m_listForm[2]).InitImage(Buffer.imageList[2]);
                m_listForm[2].FormClosed += new FormClosedEventHandler(TeleFormClosed);
                m_listForm[2].MdiParent = this;
                m_listForm[2].Show();
            }
            else m_listForm[2].Close();
        }

        private void overleyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (overleyToolStripMenuItem.Checked)
            {
                m_listForm[3] = new OverleyForm();
                ((OverleyForm)m_listForm[3]).InitImage(Buffer.imageList[3]);
                m_listForm[3].FormClosed += new FormClosedEventHandler(OverleyFormClosed);
                m_listForm[3].MdiParent = this;
                m_listForm[3].Show();
            }
            else m_listForm[3].Close();
        }

        private void SourceFormClosed(object sender, EventArgs e)
        {
            srcToolStripMenuItem.Checked = false;
        }

        private void ScrethFormClosed(object sender, EventArgs e)
        {
            scretchToolStripMenuItem.Checked = false;
        }

        private void TeleFormClosed(object sender, EventArgs e)
        {
            teleToolStripMenuItem.Checked = false;
        }

        private void OverleyFormClosed(object sender, EventArgs e)
        {
            overleyToolStripMenuItem.Checked = false;
        }
    }
}
