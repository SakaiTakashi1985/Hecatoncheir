using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipSupporter.Panel;
using System.Reflection;
using CommonLibrary;
using CommonLibrary.Limited;

namespace ClipSupporter
{
    public partial class ClipSupporterForm : Form
    {
        public bool DisplayTopMost { get; set; }
        public string DesignColor { get; set; }
        public string ApplicationBasePath { get; set; }

        public LimitedState MyLimitedState { get; set; }

        /// <summary>
        /// constructor
        /// ・Settingsの読込
        /// ・Configからパネルの設定
        /// </summary>
        public ClipSupporterForm()
        {
            InitializeComponent();
            //MyLimitedState = LicenseLimited.CanUsed();
            //if (MyLimitedState == LimitedState.Limited)
            //{
            //    MessageBox.Show($"使用期限日({LicenseLimited.LimitedUseDate.ToShortDateString()})を越えました。使用不可となります。すまぬ・・・すまぬ・・・");
            //    Application.Exit();
            //    return;
            //}

            // 設定の取り込み
            LoadProperty();

            // config読み出し
            this.Text = ConfigurationManager.AppSettings["ApplicationTitle"];

            // Panel共有オブジェクトの生成
            ShareCompornent.NotifyControl = notifyIcon1;
            ShareCompornent.ConfigBasePath = Path.Combine(Application.StartupPath, "Conf");
            ShareCompornent.TemplateBasePath = ConfigurationManager.AppSettings["ApplicationBasePath"];
            ShareCompornent.LimitedSts = MyLimitedState;
        }

        private void LoadProperty()
        {
            // DisplayTopMost
            DisplayTopMost = Boolean.Parse(Properties.Settings.Default["TopMost"].ToString());
            this.TopMost = DisplayTopMost;
            //if (DisplayTopMost) this.Activate();
            topMostToolStripMenuItem.Checked = DisplayTopMost;

            // DesignColor
            DesignColor = (string)Properties.Settings.Default["DesignColor"];
            SetDesignColor(DesignColor);

        }

        private void SaveProperty()
        {
            Properties.Settings.Default.Save();
        }

        private void SetDesignColor(string color)
        {
            switch (color)
            {
                case "GrayText":
                    this.BackColor = SystemColors.GrayText;
                    GrayToolStripMenuItem.Checked = true;
                    break;
                case "ActiveCaption":
                    this.BackColor = SystemColors.ActiveCaption;
                    BlueToolStripMenuItem.Checked = true;
                    break;
                case "White":
                    this.BackColor = Color.White;
                    WhiteToolStripMenuItem.Checked = true;
                    break;
                case "PaleGreen":
                    this.BackColor = Color.PaleGreen;
                    GreenToolStripMenuItem.Checked = true;
                    break;
                case "LightPink":
                    this.BackColor = Color.LightPink;
                    RedToolStripMenuItem.Checked = true;
                    break;
                default:
                    MessageBox.Show($"起動に失敗しました。DesignColor={color}");
                    break;
            }
        }

        private void TopMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = this.TopMost = DisplayTopMost = !DisplayTopMost;

            Properties.Settings.Default["TopMost"] = this.TopMost.ToString();
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayToolStripMenuItem.Checked = BlueToolStripMenuItem.Checked = WhiteToolStripMenuItem.Checked
                = GreenToolStripMenuItem.Checked = RedToolStripMenuItem.Checked = false;
            string controlName = ((ToolStripMenuItem)sender).AccessibleName;

            SetDesignColor(controlName);

            Properties.Settings.Default["DesignColor"] = this.BackColor.Name.ToString();

        }

        private void ClipSupporterForm_Load(object sender, EventArgs e)
        {
            // SamplePanelの削除
            for (int tp = tabControl1.TabPages.Count - 1; tp >= 0; tp--)
            {
                int cntCount = tabControl1.TabPages[tp].Controls.Count;
                for (int i = cntCount - 1; i >= 0; i--)
                {
                    tabControl1.TabPages[tp].Controls.RemoveAt(i);
                }
            }

            // Tabコントロールの生成
            Config.PanelSection cfgSection = (Config.PanelSection)Config.PanelSection.GetConfigs();
            int topPos = 3;
            foreach (var cfg in cfgSection.Panels)
            {
                if (cfg is Config.PanelConfigElement)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        ButtonPanel pnl = new ButtonPanel((Config.PanelConfigElement)cfg);
                        pnl.Top = topPos;
                        pnl.Left = 3;
                        tabControl1.TabPages[0].Controls.Add(pnl);
                        topPos += pnl.Height;
                    }
                }
            }

            // Formの高さを縮める
            //for (int tp = tabControl1.TabPages.Count - 1; tp >= 0; tp--)
            //{
            tabControl1.Height = topPos + 30;
            //}
            this.Height = topPos + 105;

            tabControl1.SelectedIndex = 0;
        }

        private void ClipSupporterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void ClipSupporterForm_FormClosed(object sender, EventArgs e)
        {
        }

        private void ClipSupporterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            SaveProperty();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }
    }
}
