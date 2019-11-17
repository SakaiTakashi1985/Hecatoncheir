using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClipSupporter.Panel.DesignSample
{
    public partial class SamplePanel : ClipSupporter.BladePanel
    {
        public SamplePanel() : base()
        {

        }
        public SamplePanel(Config.PanelConfigElement cfg) : base(cfg)
        {
            InitializeComponent();
        }
    }
}
