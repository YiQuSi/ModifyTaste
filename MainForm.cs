namespace ModifyTaste
{
    public partial class MainForm : Form
    {
        public MainForm(string[] args)
        {
            InitializeComponent();
            InitializeData(args);
        }

        private void InitializeData(string[] args)
        {
            if (args is null || args.Length < 2)
            {
                this.textBox1.Text = Config.Default.dbPath;
                this.textBox2.Text = Config.Default.csvPath;
            }
            else
            {
                this.textBox1.Text = args[0];
                this.textBox2.Text = args[1];
            }
        }

        // TODO: 按键后等待时间，防止有人闲着没事用连点器
        private void TestButton_Click(object sender, EventArgs e)
        {
            //Data.DbConvertToCsv(@"D:\Project\ModifyTaste\test\Database.xlsx", @"D:\Project\ModifyTaste\test\");
            Data.DbConvertToCsv(textBox1.Text, textBox2.Text);
        }
    }
}