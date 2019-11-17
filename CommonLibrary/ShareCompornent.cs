using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLibrary.Limited;

namespace CommonLibrary
{
    /// <summary>
    /// パネルからアクセスするフォームオブジェクト
    /// </summary>
    public class ShareCompornent
    {
        /// <summary>
        /// Applicationの作業ディレクトリ
        /// </summary>
        public static string TemplateBasePath { get; set; }

        /// <summary>
        /// 通知バルーン
        /// </summary>
        public static NotifyIcon NotifyControl { get; set; }


        public static string ConfigBasePath { get; set; }

        public static LimitedState LimitedSts { get; set; }
    }
}
