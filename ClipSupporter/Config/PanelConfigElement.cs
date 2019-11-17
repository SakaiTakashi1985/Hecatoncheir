using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipSupporter.Config
{
    public sealed class PanelConfigElement : ConfigurationElement
    {

        public static int cellXSize = 0;
        public static int cellYSize = 0;

        public string PanelName { get; set; }

        /// <summary>
        /// 見出し名
        /// </summary>
        [ConfigurationProperty("TitleName", DefaultValue = "TitleName", IsRequired = false)]
        public string TitleName
        {
            get
            {
                return (string)this["TitleName"];
            }
            set
            {
                this["TitleName"] = value;
            }
        }

        /// <summary>
        /// パネルのベースフォルダ名
        /// </summary>
        [ConfigurationProperty("FolderName", DefaultValue = "FolderName", IsRequired = true)]
        public string FolderName
        {
            get
            {
                return (string)this["FolderName"];
            }
            set
            {
                this["FolderName"] = value;
            }
        }

        /// <summary>
        /// パネルに割り当てる機能のアセンブリ名
        /// </summary>
        [ConfigurationProperty("AssemblyName", DefaultValue = "AssemblyName", IsRequired = true)]
        public string AssemblyName
        {
            get
            {
                return (string)this["AssemblyName"];
            }
            set
            {
                this["AssemblyName"] = value;
            }
        }

        /// <summary>
        /// パネルに割り当てる機能のクラス名
        /// </summary>
        [ConfigurationProperty("ClassName", DefaultValue = "ClassName", IsRequired = true)]
        public string ClassName
        {
            get
            {
                return (string)this["ClassName"];
            }
            set
            {
                this["ClassName"] = value;
            }
        }

        /// <summary>
        /// パネルのXサイズ（分割列数　※拡張不可）
        /// </summary>
        [ConfigurationProperty("DividedXSize", DefaultValue = 4, IsRequired = true)]
        public int DividedXSize
        {
            get
            {
                return (int)this["DividedXSize"];
            }
            set
            {
                //cellXSize = CommonLibrary.DesignConst.PanelAreaXSize / value;
                this["DividedXSize"] = value;
            }
        }

        /// <summary>
        /// パネルのYサイズ（拡張行数　※分割不可）
        /// </summary>
        [ConfigurationProperty("ExpansionYSize", DefaultValue = 1, IsRequired = true)]
        public int ExpansionYSize
        {
            get
            {
                return (int)this["ExpansionYSize"];
            }
            set
            {
                //cellYSize = CommonLibrary.DesignConst.PanelAreaYSize;
                this["ExpansionYSize"] = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PanelConfigElement()
        {
        }

        [ConfigurationProperty("Controls")]
        [ConfigurationCollection(typeof(ControlConfigElementCollection), AddItemName = "Control")]
        public ControlConfigElementCollection Controls
        {
            get { return base["Controls"] as ControlConfigElementCollection; }
        }
    }
}
