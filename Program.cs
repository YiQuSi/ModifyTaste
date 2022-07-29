using ModifyTaste;

namespace ModifyTaste
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        // TODO: 命令行传入参数填充
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // TODO: 多实例禁止
            Application.Run(new MainForm(args));
        }
    }
}