using ModifyTaste;

namespace ModifyTaste
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        // TODO: �����д���������
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // TODO: ��ʵ����ֹ
            Application.Run(new MainForm(args));
        }
    }
}