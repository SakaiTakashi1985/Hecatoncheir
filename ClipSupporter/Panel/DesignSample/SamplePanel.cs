using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClipSupporter.Panel.DesignSample
{
    public partial class SamplePanel : UserControl
    {
        public SamplePanel() : base()
        {

        }
        public SamplePanel(Config.PanelConfigElement cfg)
        {
            InitializeComponent();
        }
    }
}
