using ModifyTaste;

namespace ModifyTaste_Scape
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            //Data.DbConvertToCsv(@"D:\Project\ModifyTaste\test\Database.xlsx", @"D:\Project\ModifyTaste\test\");
            Data.DbConvertToCsv(textBox1.Text, textBox2.Text);
        }
    }
}