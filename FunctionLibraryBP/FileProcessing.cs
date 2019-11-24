using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using CommonLibrary;
using CommonLibrary.FileAccess;
using CommonLibrary.SubForms;

namespace FunctionLibraryBP
{
    public class FileProcessing : BaseFunctionClass
    {
        public string SelectedFunction { get; set; }

        public string BackUpNamePath { get; set; }
        public List<string> BackUpNames { get; set; }

        public FileProcessing(string panelName)
            : base(nameof(FileProcessing), panelName)
        {
            BackUpNamePath = Path.Combine(ConfigPath, "BackUpModeDefName.json");
            BackUpNames = JsonManager.ReadJson<List<string>>(BackUpNamePath);
        }
        public void SetDragDrop(object sender, PaintEventArgs e)
        {
            ((Control)sender).DragEnter += new DragEventHandler(Drag);
            ((Control)sender).DragDrop += new DragEventHandler(Drop);
            ((Control)sender).Paint -= new PaintEventHandler(SetDragDrop);
        }

        private static readonly List<string> CommandList = new List<string>()
        {
            { "BackUp" },
            { "ExcelNeutral" },
        };

        public void SetMenuList(object sender, EventArgs e)
        {
            ComboBox ctrl = sender as ComboBox;
            ctrl.Items.AddRange(CommandList.ToArray());
            ctrl.DropDownStyle = ComboBoxStyle.DropDownList;

            ctrl.VisibleChanged -= new EventHandler(SetMenuList);
            ctrl.SelectedIndex = 0;
            SelectedFunction = CommandList[0];
            ctrl.SelectedIndexChanged += new EventHandler(SelectComboBox);
        }

        public override void ShowDegugInfo(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SelectComboBox(object sender, EventArgs e)
        {
            SelectedFunction = ((ComboBox)sender).Text;
        }
        static readonly string DEFAULT_BACKUP_NAME = "指定なし";

        private void Drop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            // とりあえずメッセージウィンドウに表示
            switch (SelectedFunction)
            {
                case "BackUp":
                    // tableName Get
                    string colsKey = DateTime.Now.ToString("yyyyMMddhhmmss");

                    // selected TableName
                    string inputName = SelectAndInputForm.ShowDialog("用件入力"
                        , "バックアップに関する名称が有ったら選択、もしくは入力してください。"
                        , !(BackUpNames.Count <= 0)
                          ? BackUpNames.ToArray()
                          : new string[] { DEFAULT_BACKUP_NAME }
                        );

                    // tableName Set
                    if (!BackUpNames.Contains(inputName) && inputName != DEFAULT_BACKUP_NAME)
                    {
                        BackUpNames.Add(inputName);
                        Task.Run(() => JsonManager.WriteJson(BackUpNamePath, BackUpNames));
                    }
                    if (inputName == DEFAULT_BACKUP_NAME) inputName = "";
                    string backupDir = Path.Combine(Directory.GetParent(fileName[0]).FullName, $"bkup{inputName}_{DateTime.Now:yyyyMMddhhmmss}");
                    MakeBackUpFile(fileName, backupDir);
                    break;
                case "ExcelNeutral":
                    ExcelNeutral(fileName);
                    break;
                default:
                    break;
            }
        }

        private void Drag(object sender, DragEventArgs e)
        {
            // ドラッグされモノがファイル以外は何もしない
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MakeBackUpFile(string[] filePath, string backupDirectory)
        {
            // make folder
            Directory.CreateDirectory(backupDirectory);
            // copy files
            foreach (var file in filePath)
            {
                FileControler.CopyAndReplace(file, backupDirectory);
            }
        }

        private void ExcelNeutral(string[] filePath)
        {
            #region 動作保証出来るまでの暫定処置

            // make backup
            string backupDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                          , $"ExcelNeutralBackup_{DateTime.Now:yyyyMMddhhmmss}");
            MakeBackUpFile(filePath, backupDir);

            #endregion

            // excel nautral
            foreach (var p in filePath)
            {
                if (Path.GetExtension(p) != ".xlsx") { continue; }

                if (!SetExcelNeutral(p))
                {
                    ShareCompornent.NotifyControl.ShowBalloonTip(3000, "Excel Neutral", "エクセル初期表示状態に設定失敗", ToolTipIcon.Error);
                }
            }
        }

        public bool SetExcelNeutral(string excelPath)
        {
            bool retCd = false;

            // Excelファイルを開く
            using (var workbook = new XLWorkbook(excelPath))
            {
                foreach (var sheet in workbook.Worksheets)
                {
                    //sheet.Cell("Z3").SetActive().Select();
                    //IXLCell ac = sheet.ActiveCell;
                    //ac.CellRight().CellRight().CellRight().CellRight().CellRight().CellRight().Select();
                    sheet.SheetView.ZoomScale = 100;
                    sheet.SheetView.SetView(XLSheetViewOptions.Normal);

                }
                workbook.Worksheet(1).Select();
                //                workbook.Save();
                string outputPath = Path.Combine(Directory.GetParent(excelPath).FullName
                                    , $"ExcelNeutralBackup_{DateTime.Now:yyyyMMddhhmmss}");
                workbook.SaveAs(outputPath);

                retCd = true;
            }

            return retCd;
        }

        public void Test(object sender, EventArgs e)
        {
            if (!SetExcelNeutral(((Label)sender).Text))
            {
                ShareCompornent.NotifyControl.ShowBalloonTip(3000, "Excel Neutral", "エクセル初期表示状態に設定失敗", ToolTipIcon.Error);
            }

        }


    }
}
