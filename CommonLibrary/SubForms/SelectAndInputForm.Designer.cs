namespace CommonLibrary.SubForms
{
    partial class SelectAndInputForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.ComboBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(306, 32);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // inputBox
            // 
            this.inputBox.FormattingEnabled = true;
            this.inputBox.Location = new System.Drawing.Point(12, 32);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(273, 20);
            this.inputBox.TabIndex = 1;
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyDown);
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(12, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(369, 23);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "sampleTitle";
            // 
            // SelectAndInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 67);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.okButton);
            this.Name = "SelectAndInputForm";
            this.Text = "SelectAndInputForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectAndInputForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox inputBox;
        private System.Windows.Forms.Label titleLabel;
    }
}