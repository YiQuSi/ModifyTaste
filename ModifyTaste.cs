using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// xls 文件使用 NPOI
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

// xlsx 及 xlsm 文件使用 MiniExcel
using MiniExcelLibs;

namespace ModifyTaste
{
    public static class Data
    {
        public static void DbConvertToCsv(string dbPath, string csvPath, ConvertMode mode = ConvertMode.Fast)
        {
            FileStream dbStream = new(dbPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            List<string> sheetNames = MiniExcel.GetSheetNames(dbStream);
            foreach (string sheetName in sheetNames)
            {
                FileStream csvStream = new(Path.Join(csvPath, sheetName + ".csv"), FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                object value = dbStream.Query(useHeaderRow: false, sheetName);
                csvStream.SaveAs(value, printHeader: false, sheetName, ExcelType.CSV);
                csvStream.Close();
            }
            Game.ShowGameWindow();
            return;
        }

        // TODO: 双模式选择，普通开发追求速度，正式发布减少空间
        [Flags]
        public enum ConvertMode
        {
            Fast = 0,
            Small = 1,
        }
    }


    public static class Game
    {
        public static void ShowGameWindow()
        {
            [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int flag);
            [DllImport("user32.dll")] static extern bool IsIconic(IntPtr hWnd);
            [DllImport("user32.dll")] static extern int SetForegroundWindow(int hWnd);
            Process[] games = Process.GetProcessesByName("TetraProject");
            if (games is null)
                return;
            //if (games.Length > 1)
            //    Console.WriteLine("开这么多游戏进程有意思？");
            for (int i = 0; i < games.Length; i++)
            {
                Process game = games[i];
                IntPtr hWnd = game.MainWindowHandle;
                if (IsIconic(hWnd))
                    ShowWindow(hWnd, 9);
                SetForegroundWindow((int)hWnd);
            }
            return;
        }
    }
}
