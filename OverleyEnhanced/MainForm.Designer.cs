
namespace OverleyEnhanced
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исходноеИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.растяжениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.телевизионныйАлгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наложениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.окнаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // окнаToolStripMenuItem
            // 
            this.окнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.исходноеИзображениеToolStripMenuItem,
            this.растяжениеToolStripMenuItem,
            this.телевизионныйАлгоритмToolStripMenuItem,
            this.наложениеToolStripMenuItem});
            this.окнаToolStripMenuItem.Enabled = false;
            this.окнаToolStripMenuItem.Name = "окнаToolStripMenuItem";
            this.окнаToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.окнаToolStripMenuItem.Text = "Окна";
            // 
            // исходноеИзображениеToolStripMenuItem
            // 
            this.исходноеИзображениеToolStripMenuItem.CheckOnClick = true;
            this.исходноеИзображениеToolStripMenuItem.Name = "исходноеИзображениеToolStripMenuItem";
            this.исходноеИзображениеToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.исходноеИзображениеToolStripMenuItem.Text = "Исходное изображение";
            // 
            // растяжениеToolStripMenuItem
            // 
            this.растяжениеToolStripMenuItem.CheckOnClick = true;
            this.растяжениеToolStripMenuItem.Name = "растяжениеToolStripMenuItem";
            this.растяжениеToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.растяжениеToolStripMenuItem.Text = "Растяжение";
            // 
            // телевизионныйАлгоритмToolStripMenuItem
            // 
            this.телевизионныйАлгоритмToolStripMenuItem.CheckOnClick = true;
            this.телевизионныйАлгоритмToolStripMenuItem.Name = "телевизионныйАлгоритмToolStripMenuItem";
            this.телевизионныйАлгоритмToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.телевизионныйАлгоритмToolStripMenuItem.Text = "Телевизионный алгоритм";
            // 
            // наложениеToolStripMenuItem
            // 
            this.наложениеToolStripMenuItem.CheckOnClick = true;
            this.наложениеToolStripMenuItem.Name = "наложениеToolStripMenuItem";
            this.наложениеToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.наложениеToolStripMenuItem.Text = "Наложение";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.jpg";
            this.openFileDialog.Filter = "Image Files(*.jpg)|*.jpg";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem окнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исходноеИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem растяжениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem телевизионныйАлгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наложениеToolStripMenuItem;
    }
}