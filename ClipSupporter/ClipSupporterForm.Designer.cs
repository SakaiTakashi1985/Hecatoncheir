namespace ClipSupporter
{
    partial class ClipSupporterForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClipSupporterForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageKC = new System.Windows.Forms.TabPage();
            this.PanelArea = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.背景色変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StripMenuVersionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuPositionReset = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPageKC.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "a";
            this.notifyIcon.BalloonTipTitle = "b";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageKC);
            this.tabControl1.Location = new System.Drawing.Point(5, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(219, 333);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageKC
            // 
            this.tabPageKC.Controls.Add(this.PanelArea);
            this.tabPageKC.Location = new System.Drawing.Point(4, 22);
            this.tabPageKC.Name = "tabPageKC";
            this.tabPageKC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKC.Size = new System.Drawing.Size(211, 307);
            this.tabPageKC.TabIndex = 0;
            this.tabPageKC.Text = "業務";
            this.tabPageKC.UseVisualStyleBackColor = true;
            // 
            // PanelArea
            // 
            this.PanelArea.Location = new System.Drawing.Point(5, 3);
            this.PanelArea.Name = "PanelArea";
            this.PanelArea.Size = new System.Drawing.Size(200, 300);
            this.PanelArea.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.表示ToolStripMenuItem,
            this.設定ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(231, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 表示ToolStripMenuItem
            // 
            this.表示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMostToolStripMenuItem});
            this.表示ToolStripMenuItem.Name = "表示ToolStripMenuItem";
            this.表示ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.表示ToolStripMenuItem.Text = "表示";
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.topMostToolStripMenuItem.Text = "常に前面";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.TopMostToolStripMenuItem_Click);
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.背景色変更ToolStripMenuItem});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // 背景色変更ToolStripMenuItem
            // 
            this.背景色変更ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrayToolStripMenuItem,
            this.BlueToolStripMenuItem,
            this.WhiteToolStripMenuItem,
            this.RedToolStripMenuItem,
            this.GreenToolStripMenuItem});
            this.背景色変更ToolStripMenuItem.Name = "背景色変更ToolStripMenuItem";
            this.背景色変更ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.背景色変更ToolStripMenuItem.Text = "背景色変更";
            // 
            // GrayToolStripMenuItem
            // 
            this.GrayToolStripMenuItem.AccessibleName = "GrayText";
            this.GrayToolStripMenuItem.Name = "GrayToolStripMenuItem";
            this.GrayToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.GrayToolStripMenuItem.Text = "グレー";
            this.GrayToolStripMenuItem.Click += new System.EventHandler(this.ColorToolStripMenuItem_Click);
            // 
            // BlueToolStripMenuItem
            // 
            this.BlueToolStripMenuItem.AccessibleName = "ActiveCaption";
            this.BlueToolStripMenuItem.Name = "BlueToolStripMenuItem";
            this.BlueToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.BlueToolStripMenuItem.Text = "ブルー";
            this.BlueToolStripMenuItem.Click += new System.EventHandler(this.ColorToolStripMenuItem_Click);
            // 
            // WhiteToolStripMenuItem
            // 
            this.WhiteToolStripMenuItem.AccessibleName = "White";
            this.WhiteToolStripMenuItem.Name = "WhiteToolStripMenuItem";
            this.WhiteToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.WhiteToolStripMenuItem.Text = "ホワイト";
            this.WhiteToolStripMenuItem.Click += new System.EventHandler(this.ColorToolStripMenuItem_Click);
            // 
            // RedToolStripMenuItem
            // 
            this.RedToolStripMenuItem.AccessibleName = "LightPink";
            this.RedToolStripMenuItem.Name = "RedToolStripMenuItem";
            this.RedToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.RedToolStripMenuItem.Text = "レッド";
            this.RedToolStripMenuItem.Click += new System.EventHandler(this.ColorToolStripMenuItem_Click);
            // 
            // GreenToolStripMenuItem
            // 
            this.GreenToolStripMenuItem.AccessibleName = "PaleGreen";
            this.GreenToolStripMenuItem.Name = "GreenToolStripMenuItem";
            this.GreenToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.GreenToolStripMenuItem.Text = "グリーン";
            this.GreenToolStripMenuItem.Click += new System.EventHandler(this.ColorToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuPositionReset,
            this.StripMenuVersionInfo,
            this.StripMenuEnd});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // StripMenuVersionInfo
            // 
            this.StripMenuVersionInfo.AccessibleName = "VersionInfo";
            this.StripMenuVersionInfo.Name = "StripMenuVersionInfo";
            this.StripMenuVersionInfo.Size = new System.Drawing.Size(180, 22);
            this.StripMenuVersionInfo.Text = "バージョン情報";
            this.StripMenuVersionInfo.Click += new System.EventHandler(this.StripMenuVersionInfo_Click);
            // 
            // StripMenuEnd
            // 
            this.StripMenuEnd.AccessibleName = "ApplicationExit";
            this.StripMenuEnd.Name = "StripMenuEnd";
            this.StripMenuEnd.Size = new System.Drawing.Size(180, 22);
            this.StripMenuEnd.Text = "終了";
            this.StripMenuEnd.Click += new System.EventHandler(this.StripMenuEnd_Click);
            // 
            // StripMenuPositionReset
            // 
            this.StripMenuPositionReset.AccessibleName = "PositionReset";
            this.StripMenuPositionReset.Name = "StripMenuPositionReset";
            this.StripMenuPositionReset.Size = new System.Drawing.Size(180, 22);
            this.StripMenuPositionReset.Text = "左上に表示";
            this.StripMenuPositionReset.Click += new System.EventHandler(this.StripMenuPositionReset_Click);
            // 
            // ClipSupporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(231, 371);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ClipSupporterForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ClipSupporter";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClipSupporterForm_FormClosing);
            this.Load += new System.EventHandler(this.ClipSupporterForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageKC.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageKC;
        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel PanelArea;
        private System.Windows.Forms.ToolStripMenuItem 表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 背景色変更ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem StripMenuPositionReset;
        private System.Windows.Forms.ToolStripMenuItem StripMenuVersionInfo;
        private System.Windows.Forms.ToolStripMenuItem StripMenuEnd;
    }
}

