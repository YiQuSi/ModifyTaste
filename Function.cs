using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ModifyTaste
{
    public class Function : Program
    {
        public static void ToCsv(string[] dbInfo)
        {
#if DEBUG
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
#endif

            FileStream xlsxFileStream = null;

            try
            {
                xlsxFileStream = new FileStream(dbInfo[0], FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("路径参数不合法！");
                return;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("文件未找到！");
                return;
            }

            IWorkbook workbook = new XSSFWorkbook(xlsxFileStream);

            Console.WriteLine("\n\n开始转换！");
            Console.WriteLine("\n读取数据库内容：");

            List<string> title = new List<string>();
            List<List<List<string>>> table = new List<List<List<string>>>();

            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                table.Add(new List<List<string>>());// 添加新表
                if (workbook.GetSheetAt(i).SheetName.StartsWith("~"))// 若为临时，跳过
                    continue;
                title.Add(workbook.GetSheetAt(i).SheetName);
                int handCellCount = 0;
                bool isHand = true;
                for (int j = 0; j < workbook.GetSheetAt(i).LastRowNum + 1; j++)
                {
                    table[i].Add(new List<string>());// 添加新行
                    if (workbook.GetSheetAt(i).GetRow(j) is null)// 若为空，跳过
                        continue;
                    if (isHand)// 所有行参照表头
                    {
                        isHand = false;
                        handCellCount = workbook.GetSheetAt(i).GetRow(j).LastCellNum;
                    }
                    for (int k = 0; k < handCellCount; k++)
                    {
                        if (workbook.GetSheetAt(i).GetRow(j).GetCell(k) is null || workbook.GetSheetAt(i).GetRow(j).GetCell(k).CellType is CellType.Formula)// 若为空或公式，写入
                            table[i][j].Add(string.Empty);
                        else
                            table[i][j].Add(workbook.GetSheetAt(i).GetRow(j).GetCell(k).ToString());// 添加元素
                    }
                }
                Console.WriteLine("    " + workbook.GetSheetAt(i).SheetName + " 已读取；");
            }

            Console.WriteLine("  读取完成。");
            Console.WriteLine("\n将 xlsx 转换为 csv 格式：");

            List<string> csvs = new List<string>();

            for (int i = 0; i < table.Count; i++)// 遍历表
            {
                if (workbook.GetSheetAt(i).SheetName.StartsWith("~"))// 若为临时，跳过
                    continue;
                string csv = string.Empty;
                for (int j = 0; j < table[i].Count; j++)// 遍历行
                {
                    string row = string.Empty;
                    bool first = true;
                    for (int k = 0; k < table[i][j].Count; k++)// 遍历元素
                    {
                        string cell = table[i][j][k];
                        if (cell.Contains(quote) | cell.Contains(comma) | cell.Contains("\n"))// 若存在引号、逗号或换行符
                            cell = quote + cell.Replace(quote, doubleQuote) + quote;
                        if (first)
                            first = false;
                        else
                            cell = comma + cell;
                        row += cell;
                    }
                    if (!(row == string.Empty))
                        csv += row + end;
                }
                csvs.Add(csv);
                Console.WriteLine("    " + workbook.GetSheetAt(i).SheetName + " 已转换；");
            }

            Console.WriteLine("  转换完成。");
            Console.WriteLine("\n将字符串写入 csv 文件：");

            for (int i = 0; i < csvs.Count; i++)
                File.WriteAllText(dbInfo[1] + title[i] + ".csv", csvs[i], Encoding.UTF8);

            Console.WriteLine("  " + dbInfo[1] + " 写入完成。");
            Console.WriteLine("\n成功！");

#if DEBUG
            watch.Stop();
            TimeSpan timeSpan = watch.Elapsed;
            System.Diagnostics.Debug.WriteLine("代码执行时间：" + timeSpan.TotalMilliseconds);
#endif

            return;
        }

        public static void SendMessage(string path, string type, string id)
        {
            try
            {
                File.WriteAllText(Path.GetTempPath() + @"TetraProject\Message.txt", type + ":'" + id + "','ModifyTaste','" + Path.GetFullPath(path) + "'");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("路径参数不合法！");
                return;
            }
        }

        public static void ShowGameWindow()
        {
            [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int flag);
            [DllImport("user32.dll")] static extern bool IsIconic(IntPtr hWnd);
            [DllImport("user32.dll")] static extern int SetForegroundWindow(int hWnd);
            Process[] games = Process.GetProcessesByName("TetraProject");
            if (games is null)
                return;
            if (games.Length > 1)
                Console.WriteLine("开这么多游戏进程有意思？");
            for (int i = 0; i < games.Length; i++)
            {
                Process game = games[i];
                IntPtr hWnd = game.MainWindowHandle;
                if (IsIconic(hWnd))
                    ShowWindow(hWnd, 9);
                SetForegroundWindow((int)hWnd);
            }

        }

    }
}
