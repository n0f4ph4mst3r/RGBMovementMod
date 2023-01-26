
namespace OverleyEnhanced
{
    partial class TeleForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxQomega = new System.Windows.Forms.TextBox();
            this.textBoxQt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxQomega);
            this.panel3.Controls.Add(this.textBoxQt);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.SetChildIndex(this.buttonRun, 0);
            this.panel3.Controls.SetChildIndex(this.buttonSettings, 0);
            this.panel3.Controls.SetChildIndex(this.label4, 0);
            this.panel3.Controls.SetChildIndex(this.label5, 0);
            this.panel3.Controls.SetChildIndex(this.textBoxQt, 0);
            this.panel3.Controls.SetChildIndex(this.textBoxQomega, 0);
            // 
            // textBoxQomega
            // 
            this.textBoxQomega.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxQomega.Location = new System.Drawing.Point(244, 26);
            this.textBoxQomega.Name = "textBoxQomega";
            this.textBoxQomega.Size = new System.Drawing.Size(87, 20);
            this.textBoxQomega.TabIndex = 15;
            this.textBoxQomega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBoxQt
            // 
            this.textBoxQt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxQt.Location = new System.Drawing.Point(116, 26);
            this.textBoxQt.Name = "textBoxQt";
            this.textBoxQt.Size = new System.Drawing.Size(87, 20);
            this.textBoxQt.TabIndex = 14;
            this.textBoxQt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "qk";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "qя";
            // 
            // TeleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(937, 515);
            this.Name = "TeleForm";
            this.Text = "Телевизионный алгоритм";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQomega;
        private System.Windows.Forms.TextBox textBoxQt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
