using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipSupporter.Config
{
    public sealed class ControlConfigElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            var elm = new ControlConfigElement();
            elm.ControlName = $"Control{Count + 1}";
            return elm;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            ControlConfigElement elm = element as ControlConfigElement;
            if (null == elm) return null;
            return elm.ControlName;
        }
    }
}
