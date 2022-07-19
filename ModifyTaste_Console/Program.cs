using System;
using System.Collections.Generic;
using System.IO;

namespace ModifyTaste
{
    public class Program
    {
        public const string quote = "\"";
        public const string doubleQuote = quote + quote;
        public const string comma = ",";
        public const string end = "\r\n";

        public const string argCountErrorMessage = "输入的参数个数有误！";

        static void Main(string[] args)
        {
            if (args is null || args.Length != 2)
            {
                args = new string[2];
            }

#if DEBUG
            args[0] = @"G:\Documents\TetraProject\Database\zerOne_TURN.xlsx";
            args[1] = @"G:\Documents\TetraProject\Database\";
#endif

            if (args[0] is null || args[1] is null)
            {
                Console.Write("输入完整的 Database 文件路径：");
                args[0] = Console.ReadLine();
                Console.Write("输入完整的目标文件夹路径（包括末尾的反斜杠）：");
                args[1] = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Database 文件路径：" + args[0]);
                Console.WriteLine("目标文件夹路径：" + args[1]);
            }

            Function.ToCsv(args);

        Start:

            Console.WriteLine("\n请输入指令。（请参见根目录下的 GUIDE.txt 文件。）");
            string[] commandInfo = Console.ReadLine().Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (commandInfo is null || commandInfo.Length <= 0)
            {
                commandInfo = new string[]{string.Empty};
            }
            switch (commandInfo[0].ToLower())
            {
                case "pc":
                case "printcard":
                    if (commandInfo.Length < 2)
                    {
                        Console.WriteLine(argCountErrorMessage);
                        break;
                    }
                    Console.WriteLine("生成卡牌：" + commandInfo[1]);
                    Function.SendMessage(args[0], "Card", commandInfo[1]);
                    Function.ShowGameWindow();
                    break;

                case "sc":
                case "spawncharacter":
                    if (commandInfo.Length < 2)
                    {
                        Console.WriteLine(argCountErrorMessage);
                        break;
                    }
                    Console.WriteLine("生成角色：" + commandInfo[1]);
                    Function.SendMessage(args[0], "Character", commandInfo[1]);
                    Function.ShowGameWindow();
                    break;

                case "ts":
                case "teleportstage":
                    if (commandInfo.Length < 2)
                    {
                        Console.WriteLine(argCountErrorMessage);
                        break;
                    }
                    Console.WriteLine("传送房间：" + commandInfo[1]);
                    Function.SendMessage(args[0], "Stage", commandInfo[1]);
                    Function.ShowGameWindow();
                    break;

                case "tl":
                case "teleportlevel":
                    if (commandInfo.Length < 2)
                    {
                        Console.WriteLine(argCountErrorMessage);
                        break;
                    }
                    Console.WriteLine("传送楼层：" + commandInfo[1]);
                    Function.SendMessage(args[0], "Level", commandInfo[1]);
                    Function.ShowGameWindow();
                    break;

                case "test":
                    if (commandInfo.Length < 2)
                    {
                        Console.WriteLine(argCountErrorMessage);
                        break;
                    }
                    Console.WriteLine("测试者：" + commandInfo[1]);
                    Function.SendMessage(args[0], "Tester", commandInfo[1]);
                    Function.ShowGameWindow();
                    break;

                case "?":
                case "h":
                case "help":
                    Console.WriteLine("请参见根目录下的 GUIDE.txt 文件……");
                    break;

                case "exit":
                    return;

                case "csv":
                case "tocsv":
                case "":
                    Function.ToCsv(args);
                    break;
                default:
                    break;
            }

            goto Start;

        }
    }
}
