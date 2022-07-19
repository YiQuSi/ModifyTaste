using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace ModifyTaste
{
    public static class Data
    {
        public const string quote = "\"";
        public const string doubleQuote = quote + quote;
        public const string comma = ",";
        public const string end = "\r\n";

        public static void DbToCsv(string dbPath) { }

        public static void DbToCsv(FileStream db) { }

        public static void DbToCsv(string dbPath, string tgtPath)
        {
            FileStream dbStream = new(dbPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IWorkbook workbook = Path.GetExtension(dbStream.Name) switch
            {
                ".xls" => new HSSFWorkbook(dbStream),
                ".xlsx" or ".xlsm" => new XSSFWorkbook(dbStream),
                _ => throw new Exception() // 报错
            };
            DataSet db = new();
            foreach (ISheet sheet in workbook) // 工作表遍历
            {
                if (sheet.SheetName.StartsWith("~")) // 跳过对应工作表
                    continue;
                DataTable dataTable = new(sheet.SheetName);
                db.Tables.Add(dataTable);
                List<int> ignoreConlumnNums = new();
                int idConlumnNum = 0;
                foreach (ICell cell in sheet.GetRow(sheet.FirstRowNum)) // 表头遍历
                {
                    string cellValue = cell.StringCellValue;
                    if (cellValue.StartsWith("//")) // 跳过忽略表头并记录位置
                    {
                        ignoreConlumnNums.Add(cell.ColumnIndex);
                        continue;
                    }
                    if (cellValue == "id") // 记录ID表头位置
                        idConlumnNum = cell.ColumnIndex;
                    dataTable.Columns.Add(cellValue, Type.GetType("String"));
                }
                foreach (IRow row in sheet) // 列遍历
                {
                    string idValue = row.GetCell(idConlumnNum).StringCellValue;
                    if (idValue.StartsWith("//")) // 跳过忽略行
                        continue;
                    DataRow dataRow = dataTable.Rows.Add(idValue, Type.GetType("String"));
                    foreach (ICell cell in row) // 单元格遍历
                    {
                        int columnIndex = cell.ColumnIndex;
                        if (ignoreConlumnNums.Contains(columnIndex)) // 跳过忽略列
                            continue;
                        dataRow[columnIndex] = cell.StringCellValue;
                    }
                }
            }
            Console.WriteLine(db);
        }

        public static void DbToCsv(FileStream db, string tgtPath) { }

    }

    public static class Game
    {

    }
}
