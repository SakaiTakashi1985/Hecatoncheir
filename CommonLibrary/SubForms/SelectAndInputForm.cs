using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLibrary;

namespace CommonLibrary.SubForms
{
    public partial class SelectAndInputForm : Form
    {
        public string returnInput { get; set; }

        public SelectAndInputForm()
        {
            InitializeComponent();

            // ダイアログボックス用の設定
            this.MaximizeBox = false;         // 最大化ボタン
            this.MinimizeBox = false;         // 最小化ボタン
            this.ControlBox = !this.ControlBox;
            this.ShowInTaskbar = false;       // タスクバー上に表示
            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;  // 境界のスタイル
            this.StartPosition =
                FormStartPosition.CenterParent;  // 親フォームの中央に配置
            this.TopMost = true;
            this.Activate();
        }


        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (ensureClose())
                {
                    this.Close();
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ensureClose())
            {
                this.Close();
            }
        }

        private bool ensureClose()
        {
            bool ret = true;
            if (inputBox.Text.Trim() == "")
            {
                ShareCompornent.NotifyControl.ShowBalloonTip(5000, "エラー", "空白以外の文字を入力してください。", ToolTipIcon.Warning);
                ret = false;
            }
            return ret;
        }

        public static string ShowDialog(string title, string explain, string[] selects)
        {
            SelectAndInputForm frm = new SelectAndInputForm();
            frm.titleLabel.Text = explain;
            frm.Text = title;
            frm.inputBox.Items.AddRange(selects);
            frm.inputBox.SelectedIndex = 0;

            frm.ShowDialog();

            return frm.returnInput;
        }

        private void SelectAndInputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            returnInput = this.inputBox.Text;
        }
    }
}
