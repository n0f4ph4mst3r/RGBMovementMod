
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
            this.srcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scretchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dScretchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eScretchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dTeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eTeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overleyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dOverleyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eOverleyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // окнаToolStripMenuItem
            // 
            this.окнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.srcToolStripMenuItem,
            this.scretchToolStripMenuItem,
            this.teleToolStripMenuItem,
            this.overleyToolStripMenuItem});
            this.окнаToolStripMenuItem.Enabled = false;
            this.окнаToolStripMenuItem.Name = "окнаToolStripMenuItem";
            this.окнаToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.окнаToolStripMenuItem.Text = "Окна";
            // 
            // srcToolStripMenuItem
            // 
            this.srcToolStripMenuItem.Checked = true;
            this.srcToolStripMenuItem.CheckOnClick = true;
            this.srcToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.srcToolStripMenuItem.Name = "srcToolStripMenuItem";
            this.srcToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.srcToolStripMenuItem.Text = "Исходное изображение";
            this.srcToolStripMenuItem.Click += new System.EventHandler(this.SourceToolStripMenuItem_Click);
            // 
            // scretchToolStripMenuItem
            // 
            this.scretchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dScretchToolStripMenuItem,
            this.eScretchToolStripMenuItem});
            this.scretchToolStripMenuItem.Name = "scretchToolStripMenuItem";
            this.scretchToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.scretchToolStripMenuItem.Text = "Растяжение";
            // 
            // dScretchToolStripMenuItem
            // 
            this.dScretchToolStripMenuItem.CheckOnClick = true;
            this.dScretchToolStripMenuItem.Name = "dScretchToolStripMenuItem";
            this.dScretchToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.dScretchToolStripMenuItem.Text = "Стандартный алгоритм";
            this.dScretchToolStripMenuItem.Click += new System.EventHandler(this.dScretchToolStripMenuItem_Click);
            // 
            // eScretchToolStripMenuItem
            // 
            this.eScretchToolStripMenuItem.CheckOnClick = true;
            this.eScretchToolStripMenuItem.Name = "eScretchToolStripMenuItem";
            this.eScretchToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.eScretchToolStripMenuItem.Text = "Изменённый алгоритм";
            this.eScretchToolStripMenuItem.Click += new System.EventHandler(this.eScretchToolStripMenuItem_Click);
            // 
            // teleToolStripMenuItem
            // 
            this.teleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dTeleToolStripMenuItem,
            this.eTeleToolStripMenuItem});
            this.teleToolStripMenuItem.Name = "teleToolStripMenuItem";
            this.teleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.teleToolStripMenuItem.Text = "Телевизионный алгоритм";
            // 
            // dTeleToolStripMenuItem
            // 
            this.dTeleToolStripMenuItem.CheckOnClick = true;
            this.dTeleToolStripMenuItem.Name = "dTeleToolStripMenuItem";
            this.dTeleToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.dTeleToolStripMenuItem.Text = "Стандартный алгоритм";
            this.dTeleToolStripMenuItem.Click += new System.EventHandler(this.dTeleToolStripMenuItem_Click);
            // 
            // eTeleToolStripMenuItem
            // 
            this.eTeleToolStripMenuItem.CheckOnClick = true;
            this.eTeleToolStripMenuItem.Name = "eTeleToolStripMenuItem";
            this.eTeleToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.eTeleToolStripMenuItem.Text = "Изменённый алгоритм";
            this.eTeleToolStripMenuItem.Click += new System.EventHandler(this.eTeleToolStripMenuItem_Click);
            // 
            // overleyToolStripMenuItem
            // 
            this.overleyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dOverleyToolStripMenuItem,
            this.eOverleyToolStripMenuItem});
            this.overleyToolStripMenuItem.Name = "overleyToolStripMenuItem";
            this.overleyToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.overleyToolStripMenuItem.Text = "Наложение";
            // 
            // dOverleyToolStripMenuItem
            // 
            this.dOverleyToolStripMenuItem.CheckOnClick = true;
            this.dOverleyToolStripMenuItem.Name = "dOverleyToolStripMenuItem";
            this.dOverleyToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.dOverleyToolStripMenuItem.Text = "Стандартный алгоритм";
            this.dOverleyToolStripMenuItem.Click += new System.EventHandler(this.dOverleyToolStripMenuItem_Click);
            // 
            // eOverleyToolStripMenuItem
            // 
            this.eOverleyToolStripMenuItem.CheckOnClick = true;
            this.eOverleyToolStripMenuItem.Name = "eOverleyToolStripMenuItem";
            this.eOverleyToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.eOverleyToolStripMenuItem.Text = "Изменённый алгоритм";
            this.eOverleyToolStripMenuItem.Click += new System.EventHandler(this.eOverleyToolStripMenuItem_Click);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ToolStripMenuItem srcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scretchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overleyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dScretchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eScretchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eTeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dOverleyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eOverleyToolStripMenuItem;
    }
}