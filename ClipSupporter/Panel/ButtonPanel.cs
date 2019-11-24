using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CommonLibrary.Limited;
using FunctionLibraryBP;
using System.Linq;

namespace ClipSupporter.Panel
{
    public partial class ButtonPanel : ClipSupporter.BladePanel
    {
        public int AreaWidth { get; set; }
        public int AreaHeight { get; set; }

        public int CellWidth { get; set; }
        public int CellHeight { get; set; }


        public ButtonPanel(Config.PanelConfigElement cfg) : base(cfg)
        {
            InitializeComponent();

            try
            {
                this.TitleLabel.Text = cfg.TitleName;
                this.PanelBasePath = cfg.FolderName;

                // サイズの定数化
                ButtonArea.Width = CommonLibrary.DesignConst.PanelAreaXSize;
                ButtonArea.Height = CommonLibrary.DesignConst.PanelAreaYSize;

                // 横の分割
                AreaWidth = ButtonArea.Width;
                CellWidth = AreaWidth / cfg.DividedXSize;

                // 縦の拡張
                CellHeight = ButtonArea.Height;
                AreaHeight = ButtonArea.Height * cfg.ExpansionYSize;

                // 拡張した分パネルを高くする
                if (cfg.ExpansionYSize > 1) Height += (CellHeight * (cfg.ExpansionYSize - 1));

                // アセンブラとインスタンス生成
                Assembly assembly = Assembly.LoadFrom($"{cfg.AssemblyName}.dll");
                Type myType = assembly.GetType(cfg.ClassName);
                ConstructorInfo constructor = myType.GetConstructor(new Type[] { typeof(string) });
                MainInstance = constructor.Invoke(new object[] { cfg.FolderName });

                // コントロール生成
                foreach (Config.ControlConfigElement cfgCtrl in cfg.Controls)
                {
                    object ctrl = CreateContorl(cfgCtrl);
                    if (ctrl is Control)
                    {
                        this.Controls.Add((Control)ctrl);
                    }
                    else if (ctrl is Timer)
                    {
                        MainTimer = (Timer)ctrl;
                    }
                }
                // サイズ・位置を決めるエリアのコントロールを削除する
                this.Controls.Remove(ButtonArea);
            }
            catch (Exception ex)
            {


            }
        }

        private object CreateContorl(Config.ControlConfigElement cfg)
        {
            var asm = typeof(Form).Assembly;
            Type myType = asm.GetType(cfg.ControlClassName);
            object control = Activator.CreateInstance(myType);
            Type tp = control.GetType();

            SetProperties(control, cfg.MyProperties);

            // ToolTip
            if (!String.IsNullOrEmpty(cfg.ToolTip))
            {
                ToolTip ttp = new ToolTip();
                ttp.SetToolTip((Control)control, cfg.ToolTip);
            }

            // EventHandler
            EventInfo eInfo = tp.GetEvent(cfg.EventName);
            Type tpClick = eInfo.EventHandlerType;

            MethodInfo mInfo = MainInstance.GetType().GetMethod(cfg.EventMethodName);

            Delegate d = Delegate.CreateDelegate(tpClick, MainInstance, mInfo);
            MethodInfo minfo2 = eInfo.GetAddMethod();

            minfo2.Invoke(control, new Object[] { d });

            return control;
        }

        private void SetProperties(object control, Config.PropertyConfigElementCollection collection)
        {
            // set properties
            foreach (Config.PropertyConfigElement p in collection)
            {
                string setValue = p.Value;
                switch (p.Name)
                {
                    case "Left":
                        setValue = (ButtonArea.Left + (int.Parse(setValue) * CellWidth)).ToString();
                        SetProperty(control, p.Name, int.Parse(setValue));
                        break;
                    case "Top":
                        setValue = (ButtonArea.Top + (int.Parse(setValue) * CellHeight)).ToString();
                        SetProperty(control, p.Name, int.Parse(setValue));
                        break;
                    case "Width":
                        setValue = (int.Parse(setValue) * CellWidth).ToString();
                        SetProperty(control, p.Name, int.Parse(setValue));
                        break;
                    case "Height":
                        setValue = (int.Parse(setValue) * CellHeight).ToString();
                        SetProperty(control, p.Name, int.Parse(setValue));
                        break;
                    default:
                        SetProperty(control, p.Name, p.Value);
                        break;
                }
            }
        }

        private void SetProperty(object control, string propName, object setValue)
        {
            Type tp = control.GetType();
            PropertyInfo pInfo = tp.GetProperty(propName);
            if (pInfo != null)
            {
                if (pInfo.PropertyType.IsEnum)
                {

                    pInfo.SetValue(control, Enum.Parse(pInfo.PropertyType, (string)setValue));
                }
                else if (pInfo.PropertyType == typeof(string)
                      || pInfo.PropertyType == typeof(bool)
                      || pInfo.PropertyType == typeof(int)
                      || pInfo.PropertyType == typeof(double)
                      || pInfo.PropertyType == typeof(short)
                      || pInfo.PropertyType == typeof(decimal)
                      )
                {
                    pInfo.SetValue(control, Convert.ChangeType(setValue, pInfo.PropertyType));
                }
                else
                {
#warning 今のところcolor限定
                    pInfo.SetValue(control, new ColorConverter().ConvertFromString((string)setValue));

                }


            }
        }

        private void ButtonPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
