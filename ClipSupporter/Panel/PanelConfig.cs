using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipSupporter.Panel
{
    public class PanelConfig
    {
        /// <summary>
        /// 見出し名
        /// </summary>
        public string TitleName { get; set; }

        //public string PanelBasePath { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PanelConfig()
        {
        }

        /// <summary>
        /// Constructor(string titleName)
        /// </summary>
        public PanelConfig(string titleName)
        {
            TitleName = titleName;
        }

        public void CreatePosition()
        {

        }
    }
}
