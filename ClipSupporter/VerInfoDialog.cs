using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipSupporter
{
    public partial class VerInfoDialog : Form
    {
        public VerInfoDialog()
        {
            InitializeComponent();
        }

        private void VerInfoDialog_Load(object sender, System.EventArgs e)
        {
            // ***** Applicationクラスのプロパティにより取得 *****
            // バージョン名（AssemblyInformationalVersionAttribute属性）を取得
            string appVersion = Application.ProductVersion;
            // 製品名（AssemblyProductAttribute属性）を取得
            string appProductName = Application.ProductName;
            // 会社名（AssemblyCompanyAttribute属性）を取得
            string appCompanyName = Application.CompanyName;

            // ***** アセンブリから直接取得 *****
            Assembly mainAssembly = Assembly.GetEntryAssembly();

            // コピーライト情報を取得
            string appCopyright = "-";
            object[] CopyrightArray = mainAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if ((CopyrightArray != null) && (CopyrightArray.Length > 0))
            {
                appCopyright = ((AssemblyCopyrightAttribute)CopyrightArray[0]).Copyright;
            }

            // 詳細情報を取得
            string appDescription = "-";
            object[] DescriptionArray = mainAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if ((DescriptionArray != null) && (DescriptionArray.Length > 0))
            {
                appDescription = ((AssemblyDescriptionAttribute)DescriptionArray[0]).Description;
            }

            // ***** EXEファイルから直接取得（Win32API使用） *****

            // アプリケーション・アイコンを取得
            Icon appIcon;
            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hSuccess = SHGetFileInfo(mainAssembly.Location, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
            if (hSuccess != IntPtr.Zero)
            {
                appIcon = Icon.FromHandle(shinfo.hIcon);
            }
            else
            {
                appIcon = SystemIcons.Application;
            }

            // ラベルなどにバージョン情報をセット
            pictureBox1.Image = appIcon.ToBitmap();
            Text = appProductName + " のバージョン情報";
            label1.Text = appCompanyName + " " + appProductName;
            label2.Text = "Version " + appVersion;
            label3.Text = appCopyright;
            label4.Text = appDescription;

            // バージョン情報を取得（別バージョン）
            //AssemblyName mainAssemName = mainAssembly.GetName();
            //Version appVersion2 = mainAssemName.Version;
            //MessageBox.Show(appVersion2.ToString());
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #region アイコン取得用のWin32API

        // SHGetFileInfo関数
        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        // SHGetFileInfo関数で使用するフラグ
        private const uint SHGFI_ICON = 0x100; // アイコン・リソースの取得
        private const uint SHGFI_LARGEICON = 0x0; // 大きいアイコン
        private const uint SHGFI_SMALLICON = 0x1; // 小さいアイコン

        // SHGetFileInfo関数で使用する構造体
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }
        #endregion
    }
}
