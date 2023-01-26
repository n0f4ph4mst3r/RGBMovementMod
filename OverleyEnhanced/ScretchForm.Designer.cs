
namespace OverleyEnhanced
{
    partial class ScretchForm
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
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxQ);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.SetChildIndex(this.label6, 0);
            this.panel3.Controls.SetChildIndex(this.textBoxQ, 0);
            this.panel3.Controls.SetChildIndex(this.buttonRun, 0);
            this.panel3.Controls.SetChildIndex(this.buttonSettings, 0);
            // 
            // textBoxQ
            // 
            this.textBoxQ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxQ.Location = new System.Drawing.Point(181, 29);
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.Size = new System.Drawing.Size(85, 20);
            this.textBoxQ.TabIndex = 13;
            this.textBoxQ.Text = "0";
            this.textBoxQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQ_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Q";
            // 
            // ScretchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(937, 515);
            this.Name = "ScretchForm";
            this.Text = "Частотно-пропорциональное растяжение";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQ;
        private System.Windows.Forms.Label label6;
    }
}
