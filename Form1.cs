using ModifyTaste;

namespace ModifyTaste_Scape
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            Data.DbToCsv(@"D:\Project\ModifyTaste_Scape\test\Database.xlsm", "");
        }
    }
}