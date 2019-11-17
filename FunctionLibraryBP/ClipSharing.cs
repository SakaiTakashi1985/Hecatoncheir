using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLibrary;

namespace FunctionLibraryBP
{
    public class ClipSharing : BaseFunctionClass
    {
        public Timer CopyPollingTimer;
        const string DATATYPE_TEXT = "String";
        const string DATATYPE_BIN = "MemoryStream";
        const string DATATYPE_BMP = "Bitmap";
        const string DATATYPE_STR_ARRAY = "stringA";

        public DateTime LastLoadTime { get; set; }

        public ClipSharing(string panelName) 
            : base(nameof(ClipSharing), panelName)
        {
            Directory.CreateDirectory(TemporaryPath);
            // clear folder and children files
            FileControler.ClearDataDirectory(TemporaryPath);

            //CopyPollingTimer = new Timer();
            //CopyPollingTimer.Interval = 10000;
            //CopyPollingTimer.Tick += new EventHandler(LoadClipBoard);
            //CopyPollingTimer.Enabled = true;

            LastLoadTime = DateTime.Now;
        }

        public void LoadClipBoard(object sender, EventArgs e)
        {
            // Saveファイルの有無チェック
            var inputFileList = Directory.EnumerateFileSystemEntries(TemporaryPath).ToArray();
            if (inputFileList.Length <= 0) return;

            // 99_ENDファイルが無い場合はSave中
            if (!inputFileList.Any(f => Path.GetFileName(f) == "END")) return;

            var saveFileCreateTime = inputFileList.Max(f => File.GetLastWriteTime(f));
            if (DateTime.Compare(LastLoadTime, saveFileCreateTime) >= 0) return;
            

            DataObject dataObject = new DataObject();
            // ファイルコピー
            if (inputFileList.Any(f => Directory.Exists(f)))
            {
                string outputFilePath = inputFileList.Where(f => Directory.Exists(f)).First();
                dataObject.SetData(DataFormats.FileDrop,Directory.EnumerateFileSystemEntries(outputFilePath).ToArray());
            }
            else
            {

                for (int fNo = 0; fNo < inputFileList.Count(); fNo++)
                {
                    string fileName = inputFileList[fNo];
                    string outputFilePath = Path.Combine(TemporaryPath, fileName);

                    // START, ENDファイルは対象外
                    if (fileName.EndsWith("START") || fileName.EndsWith("END")) continue;

                    string format = Path.GetFileNameWithoutExtension(fileName);
                    string extName = Path.GetExtension(fileName).Substring(1);

                    Debug.WriteLine($"load {fileName}");

                    switch (extName)
                    {
                        case DATATYPE_BIN:
                            byte[] data = File.ReadAllBytes(outputFilePath);
                            dataObject.SetData(format, new MemoryStream(data));
                            break;

                        case DATATYPE_BMP:
                            using (var ms = new MemoryStream(File.ReadAllBytes(outputFilePath)))
                            {
                                Bitmap bmp = new Bitmap(ms);
                                dataObject.SetData(format, bmp);
                            }
                            break;
                        case DATATYPE_STR_ARRAY:
                            using (var sr = new StreamReader(outputFilePath))
                            {
                                dataObject.SetData(format, sr.ReadToEnd().Split(new string[] { "\r\n" }
                                , StringSplitOptions.None));
                            }
                            break;
                        case DATATYPE_TEXT:
                            using (var sr = new StreamReader(outputFilePath))
                            {
                                dataObject.SetData(format, sr.ReadToEnd());
                            }
                            break;
                        default:
#warning 想定外のフォーマット：ログ出力処理
                            Debug.WriteLine(outputFilePath);
                            break;
                    }
                }
            }
            Clipboard.Clear();
            Clipboard.SetDataObject(dataObject);

            ShareCompornent.NotifyControl.ShowBalloonTip(3000, "ClipBord共有", "ClipBord同期完了", ToolTipIcon.Info);
            LastLoadTime = DateTime.Now;

            // 確認
            /*
            string backUpPath = BasePath;
            BasePath = BasePath.Substring(0, BasePath.Length - 1);
            // clear folder amd children files
            FileControler.ClearDataDirectory(BasePath);
            SaveClipBoard(sender, e);
            BasePath = backUpPath;
            */
        }

        public void SaveClipBoard(object sender, EventArgs e)
        {
            var dataObj = Clipboard.GetDataObject();
            if (dataObj == null || dataObj.GetFormats().Length <= 0) return;

            // 現在Save中の場合は強制実行するか確認する
            var inputFileList = Directory.EnumerateFileSystemEntries(TemporaryPath).ToArray();
            if (inputFileList.Any(f => Path.GetFileName(f) == "START")
             && !inputFileList.Any(f => Path.GetFileName(f) == "END"))
            {
                var dialogResult = MessageBox.Show("コピー中のファイルが存在します。\r\n強制的にセーブしますか？"
                                                 , "強制セーブ確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            // clear folder amd children files
            FileControler.ClearDataDirectory(TemporaryPath);

            File.Create(Path.Combine(TemporaryPath, "START")).Close();

            string[] formats = dataObj.GetFormats();
            for (int fNo = 0; fNo < formats.Length; fNo++)
            {
                string dataFormat = formats[fNo];
                string outputFilePath = Path.Combine(TemporaryPath, $"{dataFormat}");
                var clipData = dataObj.GetData(dataFormat);
                if (clipData == null) continue;

                // Formatに合わせて保存
                switch (clipData.GetType().Name)
                {
                    case DATATYPE_BMP:
                        var img = Clipboard.GetImage();
                        img.Save($"{outputFilePath}.{DATATYPE_BMP}");
                        break;
                    case DATATYPE_BIN:
                        var ms = (MemoryStream)dataObj.GetData(dataFormat);
                        File.WriteAllBytes($"{outputFilePath}.{DATATYPE_BIN}", ms.ToArray());
                        break;
                    case "String[]":
                        string[] outputData = (string[])dataObj.GetData(dataFormat);
                        if (dataFormat == "FileDrop")
                        {
                            Directory.CreateDirectory(outputFilePath);
                            for (int i = 0; i < outputData.Length; i++)
                            {
                                FileControler.CopyAndReplace(outputData[i], outputFilePath);
                                //outputData[i] = Path.Combine(outputFilePath, Path.GetFileName(outputData[i]));
                            }
                        }
                        using (var sw = new StreamWriter($"{outputFilePath}.{DATATYPE_STR_ARRAY}"))
                        {
                            sw.Write(String.Join("\r\n", outputData));
                        }
                        break;
                    case DATATYPE_TEXT:
                        using (var sw = new StreamWriter($"{outputFilePath}.{DATATYPE_TEXT}"))
                        {
                            sw.Write(dataObj.GetData(dataFormat));
                        }
                        break;
                    default:
#warning 想定外のフォーマット：ログ出力処理
                        Debug.WriteLine($"{fNo}__{dataFormat}__{clipData.GetType().Name}");
                        break;
                }
            }

            File.Create(Path.Combine(TemporaryPath, "END")).Close();

            ShareCompornent.NotifyControl.ShowBalloonTip(3000, "ClipBord共有", "ClipBordセーブ完了", ToolTipIcon.Info);
            LastLoadTime = DateTime.Now;
        }

        public override void ShowDegugInfo(object sender, EventArgs e)
        {
            MessageBox.Show("aaaa");
            throw new NotImplementedException();
        }
    }
}
