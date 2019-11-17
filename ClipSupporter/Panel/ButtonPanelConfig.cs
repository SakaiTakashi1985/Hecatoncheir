using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipSupporter.Panel
{
    public class ButtonPanelConfig : PanelConfig
    {
        // 7まで
        public int ControlCntX { get; set; }
        // 1のみ
        public int ControlCntY { get; set; }

        public string InstanceName { get; set; }

        public List<PanelControl> Controls { get; set; }

        public ButtonPanelConfig()
        {
            Controls = new List<PanelControl>();
        }

        public class PanelControl
        {
            public string ControlName { get; set; }

            public int ControlWidth { get; set; }

            public int ControlHeight { get; set; }

            public List<PanelEventHandle> PanelEventHandles { get; set; }

            public PanelControl()
            {
                PanelEventHandles = new List<PanelEventHandle>();
            }
        }

        public class PanelEventHandle
        {
            public string EventHandleActionName { get; set; }

            public string EventHandleMethodName { get; set; }
        }
    }
}
