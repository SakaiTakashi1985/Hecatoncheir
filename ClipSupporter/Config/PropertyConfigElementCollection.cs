using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;

namespace ClipSupporter.Config
{
    public class PropertyConfigElementCollection : ConfigurationElementCollection
    {
        public PropertyConfigElementCollection()
        {

        }

        protected override ConfigurationElement CreateNewElement()
        {
             return new PropertyConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            PropertyConfigElement elm = element as PropertyConfigElement;
            if (null == elm) return null;
            return elm.Name;
        }

        private static readonly string X_POSITION = "XPos";
        private static readonly string Y_POSITION = "YPos";

        protected override void BaseAdd(ConfigurationElement element)
        {
            PropertyConfigElement propElement = element as PropertyConfigElement;
            // left, top, width, heightの設定
            if (propElement.Name == X_POSITION)
            {
                int XPosS = int.Parse(propElement.Value.Split('-')[0]);
                int XPosE = int.Parse(propElement.Value.Split('-')[1]);

                //// Left (暫定で設定、画面描画時に補正する）
                PropertyConfigElement leftElemnt = new PropertyConfigElement()
                {
                    Name = "Left",
                    //Value = (DesignConst.PanelAreaLeft + (PanelConfigElement.cellXSize * XPosS)).ToString(),
                    Value = XPosS.ToString(),
                };
                base.BaseAdd(leftElemnt);
                //SetProperty(control, "Left", AreaLeft + (AreaCellWidth * (int)hashtable[X_SIZE_START]));

                //// Width (暫定で設定、画面描画時に補正する）
                PropertyConfigElement widthElemnt = new PropertyConfigElement()
                {
                    Name = "Width",
                    //Value = (PanelConfigElement.cellXSize * (XPosE - XPosS)).ToString(),
                    Value = (XPosE - XPosS).ToString(),
                };
                base.BaseAdd(widthElemnt);
                //SetProperty(control, "Width", AreaCellWidth * ((int)hashtable[X_SIZE_END] - (int)hashtable[X_SIZE_START]));
                return;
            }
            else if (propElement.Name == Y_POSITION)
            {
                int YPosS = int.Parse(propElement.Value.Split('-')[0]);
                int YPosE = int.Parse(propElement.Value.Split('-')[1]);

                //// Top (暫定で設定、画面描画時に補正する）
                PropertyConfigElement topElemnt = new PropertyConfigElement()
                {
                    Name = "Top",
                    //Value = (DesignConst.PanelAreaTop + (PanelConfigElement.cellYSize * YPosS)).ToString(),
                    Value = YPosS.ToString(),
                };
                base.BaseAdd(topElemnt);
                //SetProperty(control, "Top", AreaTop + (AreaCellHeight * (int)hashtable[Y_SIZE_START]));

                //// Height (暫定で設定、画面描画時に補正する）
                PropertyConfigElement heightElemnt = new PropertyConfigElement()
                {
                    Name = "Height",
                    //Value = (PanelConfigElement.cellYSize * (YPosE - YPosS)).ToString(),
                    Value = (YPosE - YPosS).ToString(),
                };
                base.BaseAdd(heightElemnt);
                //SetProperty(control, "Heght", AreaCellHeight * ((int)hashtable[Y_SIZE_END] - (int)hashtable[Y_SIZE_START]));
                return;
            }
            base.BaseAdd(element);
        }
    }
}
