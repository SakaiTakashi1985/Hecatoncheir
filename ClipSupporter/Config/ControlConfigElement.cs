using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipSupporter.Config
{
    public sealed class ControlConfigElement : ConfigurationElement
    {
        public string ControlName { get; set; }

        /// <summary>
        /// コントロールのクラス名
        /// Blankの場合はSkipする
        /// </summary>
        [ConfigurationProperty("ControlClassName", DefaultValue = "ControlClassName", IsRequired = true)]
        public string ControlClassName
        {
            get
            {
                return (string)this["ControlClassName"];
            }
            set
            {
                this["ControlClassName"] = value;
            }
        }

        /// <summary>
        /// コントロールの処理を割り当てるイベント名
        /// </summary>
        [ConfigurationProperty("EventName", DefaultValue = "EventName", IsRequired = true)]
        public string EventName
        {
            get
            {
                return (string)this["EventName"];
            }
            set
            {
                this["EventName"] = value;
            }
        }

        /// <summary>
        /// コントロールの処理名
        /// </summary>
        [ConfigurationProperty("EventMethodName", DefaultValue = "EventMethodName", IsRequired = true)]
        public string EventMethodName
        {
            get
            {
                return (string)this["EventMethodName"];
            }
            set
            {
                this["EventMethodName"] = value;
            }
        }

        /// <summary>
        /// コントロールのToolTip
        /// </summary>
        [ConfigurationProperty("ToolTip", DefaultValue = "", IsRequired = false)]
        public string ToolTip
        {
            get
            {
                return (string)this["ToolTip"];
            }
            set
            {
                this["ToolTip"] = value;
            }
        }

        [ConfigurationProperty("Properties")]
        [ConfigurationCollection(typeof(PropertyConfigElementCollection), AddItemName = "Property")]
        public PropertyConfigElementCollection MyProperties
        {
            get { return base["Properties"] as PropertyConfigElementCollection; }
        }
    }
}
