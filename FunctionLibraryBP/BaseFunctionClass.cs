using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;

namespace FunctionLibraryBP
{
    public abstract class BaseFunctionClass
    {
        public string TemporaryPath { get; set; }
        public string ConfigPath { get; set; }

        public abstract void ShowDegugInfo(object sender, EventArgs e);

        public BaseFunctionClass(string instanceClassName, string panelName)
        {
            TemporaryPath = Path.Combine(ShareCompornent.TemplateBasePath, panelName);
            ConfigPath = Path.Combine(ShareCompornent.ConfigBasePath, instanceClassName);
        }
    }
}
