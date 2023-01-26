
namespace OverleyEnhanced
{
    partial class SettingsForm
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
            this.textBoxSaturation = new System.Windows.Forms.TextBox();
            this.textBoxCriterion = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelSaturation = new System.Windows.Forms.Label();
            this.labelCriterion = new System.Windows.Forms.Label();
            this.checkBoxParameters = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxSaturation
            // 
            this.textBoxSaturation.Location = new System.Drawing.Point(146, 26);
            this.textBoxSaturation.Name = "textBoxSaturation";
            this.textBoxSaturation.Size = new System.Drawing.Size(100, 20);
            this.textBoxSaturation.TabIndex = 0;
            this.textBoxSaturation.Text = "0,5";
            this.textBoxSaturation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSaturation_KeyPress);
            // 
            // textBoxCriterion
            // 
            this.textBoxCriterion.Location = new System.Drawing.Point(146, 65);
            this.textBoxCriterion.Name = "textBoxCriterion";
            this.textBoxCriterion.Size = new System.Drawing.Size(100, 20);
            this.textBoxCriterion.TabIndex = 1;
            this.textBoxCriterion.Text = "0";
            this.textBoxCriterion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCriterion_KeyPress);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(54, 136);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(146, 136);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelSaturation
            // 
            this.labelSaturation.AutoSize = true;
            this.labelSaturation.Location = new System.Drawing.Point(44, 29);
            this.labelSaturation.Name = "labelSaturation";
            this.labelSaturation.Size = new System.Drawing.Size(85, 13);
            this.labelSaturation.TabIndex = 4;
            this.labelSaturation.Text = "Насыщенность";
            // 
            // labelCriterion
            // 
            this.labelCriterion.AutoSize = true;
            this.labelCriterion.Location = new System.Drawing.Point(12, 68);
            this.labelCriterion.Name = "labelCriterion";
            this.labelCriterion.Size = new System.Drawing.Size(117, 13);
            this.labelCriterion.TabIndex = 5;
            this.labelCriterion.Text = "Критерий насыщения";
            // 
            // checkBoxParameters
            // 
            this.checkBoxParameters.AutoSize = true;
            this.checkBoxParameters.Location = new System.Drawing.Point(12, 101);
            this.checkBoxParameters.Name = "checkBoxParameters";
            this.checkBoxParameters.Size = new System.Drawing.Size(262, 17);
            this.checkBoxParameters.TabIndex = 6;
            this.checkBoxParameters.Text = "Не использовать дополнительные параметры";
            this.checkBoxParameters.UseVisualStyleBackColor = true;
            this.checkBoxParameters.CheckedChanged += new System.EventHandler(this.checkBoxParameters_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 180);
            this.Controls.Add(this.checkBoxParameters);
            this.Controls.Add(this.labelCriterion);
            this.Controls.Add(this.labelSaturation);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxCriterion);
            this.Controls.Add(this.textBoxSaturation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSaturation;
        private System.Windows.Forms.TextBox textBoxCriterion;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelSaturation;
        private System.Windows.Forms.Label labelCriterion;
        private System.Windows.Forms.CheckBox checkBoxParameters;
    }
}