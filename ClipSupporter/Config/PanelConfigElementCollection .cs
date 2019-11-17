using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipSupporter.Config
{
    public sealed class PanelConfigElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            var elm = new PanelConfigElement();
            elm.PanelName = $"Panel{Count + 1}";
            return elm;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            PanelConfigElement elm = element as PanelConfigElement;
            if (null == elm) return null;
            return elm.PanelName;
        }
    }
}
