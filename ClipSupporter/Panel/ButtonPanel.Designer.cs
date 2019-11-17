namespace ClipSupporter.Panel
{
    partial class ButtonPanel
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonArea = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ButtonArea
            // 
            this.ButtonArea.Location = new System.Drawing.Point(3, 15);
            this.ButtonArea.Name = "ButtonArea";
            this.ButtonArea.Size = new System.Drawing.Size(190, 25);
            this.ButtonArea.TabIndex = 1;
            // 
            // ButtonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.ButtonArea);
            this.Name = "ButtonPanel";
            this.Size = new System.Drawing.Size(200, 50);
            this.Load += new System.EventHandler(this.ButtonPanel_Load);
            this.Controls.SetChildIndex(this.TitleLabel, 0);
            this.Controls.SetChildIndex(this.ButtonArea, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ButtonArea;
    }
}
