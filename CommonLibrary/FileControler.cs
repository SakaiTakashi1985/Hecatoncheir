using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    static public class FileControler
    {
        static public void ClearDataDirectory(string strPath)
        {
            foreach (var item in Directory.EnumerateFiles(strPath))
            {
                File.Delete(item);
            }

            foreach (var dir in Directory.EnumerateDirectories(strPath))
            {
                ClearDataDirectory(dir);
                Directory.Delete(dir, true);
            }
        }

        /// <summary>
        /// ディレクトリとその中身を上書きコピー
        /// </summary>
        static public void CopyAndReplace(string sourcePath, string copyPath)
        {
            // ファイルのコピー
            if (File.Exists(sourcePath))
            {
                File.Copy(sourcePath, Path.Combine(copyPath, Path.GetFileName(sourcePath)));
            }
            else
            {
                // ディレクトリ内エントリのコピー
                string targetPath = Path.Combine(copyPath, Path.GetFileName(sourcePath));
                Directory.CreateDirectory(targetPath);
                foreach (var path in Directory.EnumerateFileSystemEntries(sourcePath))
                {
                    CopyAndReplace(Path.Combine(sourcePath, path), targetPath);
                }
            }
        }

    }
}
