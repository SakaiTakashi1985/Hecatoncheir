using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipSupporter.Config
{
    public class PropertyConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("Name", DefaultValue = "defaultName", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["Name"];
            }
            set
            {
                this["Name"] = value;
            }
        }

        [ConfigurationProperty("Value", DefaultValue = "defaultValue", IsRequired = true)]
        public string Value
        {
            get
            {
                return (string)this["Value"];
            }
            set
            {
                this["Value"] = value;
            }
        }
    }
}
