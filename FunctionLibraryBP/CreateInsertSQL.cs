using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLibrary;
using CommonLibrary.FileAccess;
using CommonLibrary.SubForms;

namespace FunctionLibraryBP
{
    public class CreateInsertSQL : BaseFunctionClass
    {
        static char[] WhiteSpaceDelimiters = new char[] {
        '\u0009',  // CHARACTER TABULATION
        '\u000A',  // LINE FEED
        '\u000B',  // LINE TABULATION
        '\u000C',  // FORM FEED
        '\u000D',  // CARRIAGE RETURN
        '\u0020',  // SPACE
        '\u00A0',  // NO-BREAK SPACE
        '\u2000',  // EN QUAD
        '\u2001',  // EM QUAD
        '\u2002',  // EN SPACE
        '\u2003',  // EM SPACE
        '\u2004',  // THREE-PER-EM SPACE
        '\u2005',  // FOUR-PER-EM SPACE
        '\u2006',  // SIX-PER-EM SPACE
        '\u2007',  // FIGURE SPACE
        '\u2008',  // PUNCTUATION SPACE
        '\u2009',  // THIN SPACE
        '\u200A',  // HAIR SPACE
        '\u200B',  // ZERO WIDTH SPACE
//      '\u3000',  // IDEOGRAPHIC SPACE -- これが所謂全角スペース
        '\uFEFF' // ZERO WIDTH NO-BREAK SPACE
    };

        static readonly string DICTIONARY_FILE = @"TableNameDef.json";

        static readonly string DEFAULT_TABLE_NAME = "てーぶるめい";
        public Dictionary<string, string> DicTableNamDef { get; set; }

        public string TableNameDefPath { get; set; }

        public CreateInsertSQL(string panelName) 
            : base(nameof(CreateInsertSQL), panelName)
        {
            TableNameDefPath = Path.Combine(ConfigPath, DICTIONARY_FILE);
            DicTableNamDef = JsonManager.ReadJson<Dictionary<string, string>>(TableNameDefPath);
        }

        /// <summary>
        /// Recordデータのトリム実施有無
        /// </summary>
        public bool IsTrim { get; set; }
        /// <summary>
        /// NULL割り当て文字
        /// </summary>
        public string NullString { get; set; }

        public void CreateInsertSQLString(object sender, EventArgs e)
        {
            #region 暫定設定処理
            IsTrim = true;
            NullString = "NULL";
            #endregion

            string inputData = Clipboard.GetText();

            // INSERT文の場合実行しない(2度押し想定)
            if (inputData.Contains("INSERT INTO") && inputData.Contains("VALUES")) return;

            // 表形式であるか確認(カンマ・タブ文字、改行コード)
            if (String.IsNullOrEmpty(inputData.Trim())) return;

            string separateLine = inputData.Split(new string[] { "\r\n" }, StringSplitOptions.None).Length > 1 ? "\r\n" : "\r";
            string separateCell = inputData.Split(new string[] { "\t" }, StringSplitOptions.None).Length > 1 ? "\t" : ",";

            if (!inputData.Contains(separateCell) || !inputData.Contains(separateLine)) return;

            List<List<String>> tableData = inputData.Split(new string[] { separateLine }, StringSplitOptions.None)
                                           .Where(l => l.Contains(separateCell))    
                                           .Select(l => l.Split(new string[] { separateCell }, StringSplitOptions.None).ToList()).ToList();
            // title & record無し
            if (tableData[0].Any(c => String.IsNullOrEmpty(c))) return;
            if (tableData.Count() <= 1) return;

            // tableName Get
            string colsKey = String.Join(",", tableData[0]).Replace(" ", "").ToUpper();
            string tableList = DicTableNamDef.ContainsKey(colsKey) ? DicTableNamDef[colsKey] : "";

            // selected TableName
            string inputTableName = SelectAndInputForm.ShowDialog("テーブル名入力"
                , "テーブル名を選択、もしくは入力してください。"
                , !String.IsNullOrEmpty(tableList) 
                  ? tableList.Split(new char[] { ',' })
                  : new string[] { DEFAULT_TABLE_NAME }
                );

            // tableName Set
            if (!tableList.Contains(inputTableName) || inputTableName == DEFAULT_TABLE_NAME )
            {
                tableList = String.IsNullOrEmpty(tableList) ? inputTableName : $"{tableList},{inputTableName}";
                DicTableNamDef[colsKey] = tableList;
                Task.Run(() => JsonManager.WriteJson(TableNameDefPath, DicTableNamDef));
            }

            StringBuilder sbFormat = new StringBuilder();
            // header
            sbFormat.Append("INSERT INTO ");
            sbFormat.Append($"{inputTableName} ");
            sbFormat.Append("(" + String.Join(",", tableData[0]) + ") ");
            sbFormat.Append("VALUES {0}");

            StringBuilder sbRecord = new StringBuilder();
            // record
            for (int y = 1; y < tableData.Count(); y++)
            {
                string recordData = string.Empty;
                for (int x = 0; x < tableData[y].Count(); x++)
                {
                    bool isNumber = false;
                    bool isNull = false;
                    string cellData = tableData[y][x];
                    if (cellData == NullString)
                    {
                        isNull = true;
                    }
                    else
                    {
                        if (IsTrim)
                        {
                            // 全て空白はトリムしない
                            if (!cellData.All(c => c == ' '))
                            {
                                cellData = cellData.TrimEnd(WhiteSpaceDelimiters);
                            }
                        }
                        if (cellData == tableData[y][x])
                        {
                            decimal tmpData = new decimal();
                            if (Decimal.TryParse(cellData, out tmpData))
                            {
                                if (cellData == tmpData.ToString())
                                {
                                    isNumber = true;
                                }
                            }
                        }
                    }
                    if (isNull)
                    {
                        recordData += ",Null";
                    }
                    else if (isNumber)
                    {
                        recordData += "," + cellData;
                    }
                    else
                    {
                        recordData += $",'{cellData}'";
                    }
                }
                sbRecord.AppendLine(String.Format(sbFormat.ToString(), "(" + recordData.Substring(1) + ");"));
            }

            Clipboard.Clear();
            Clipboard.SetText(sbRecord.ToString());
        }

        public override void ShowDegugInfo(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
