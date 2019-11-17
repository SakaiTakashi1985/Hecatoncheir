using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Limited
{
    public class LicenseLimited
    {
        public static readonly DateTime WarningUseDate = new DateTime(2020, 4, 1);
        public static readonly DateTime LimitedUseDate = new DateTime(2020, 7, 1);

        public static LimitedState CanUsed()
        {
            LimitedState retCd = LimitedState.Available;
            DateTime nowDate = GetNewestDataTime();
            if (nowDate.CompareTo(WarningUseDate) > 0)
            {
                retCd = LimitedState.Warning;
            }
            if (nowDate.CompareTo(LimitedUseDate) > 0)
            {
                retCd = LimitedState.Limited;
            }
            return retCd;
        }

        private static DateTime GetNewestDataTime()
        {
            DateTime NewestDate = DateTime.Now;

            // Cookies
            NewestDate = GetNewestDataTime(Environment.GetFolderPath(Environment.SpecialFolder.Cookies), NewestDate);

            // 履歴
            NewestDate = GetNewestDataTime(Environment.GetFolderPath(Environment.SpecialFolder.History), NewestDate);

            // DeskTop
            NewestDate = GetNewestDataTime(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), NewestDate);

            // 最近使ったファイル
            NewestDate = GetNewestDataTime(Environment.GetFolderPath(Environment.SpecialFolder.Recent), NewestDate);

            return NewestDate;
        }

        private static DateTime GetNewestDataTime(string path, DateTime compareDate)
        {
            DateTime retCd = DateTime.Now;
            try
            {
                var inputFileList = Directory.EnumerateFileSystemEntries(path).ToArray();
                retCd = inputFileList.Max(f => File.GetLastWriteTime(f));
            }
            catch (Exception)
            {
            }
            return compareDate.CompareTo(retCd) < 0 ? retCd : compareDate;
        }
    }
    public enum LimitedState
    {
        Available,
        Warning,
        Limited,
    }
}
