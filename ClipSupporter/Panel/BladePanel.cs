using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipSupporter.Panel;

namespace ClipSupporter
{
    public partial class BladePanel : UserControl
    {
        public object MainInstance { get; set; }

        public string PanelBasePath { get; set; }

        public Timer MainTimer = null;

        public BladePanel()
        {

        }

        public BladePanel(Config.PanelConfigElement cfg)
        {
            InitializeComponent();
            //this.TitleLabel.Text = cfg.TitleName;
            this.PanelBasePath = cfg.FolderName;
#if DEBUG
            //TitleLabel.Click += new EventHandler(TiktleLabel_Click);
#endif
        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void BladePanel_Load(object sender, EventArgs e)
        {

        }
    }
}
