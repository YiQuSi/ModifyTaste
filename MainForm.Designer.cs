namespace ModifyTaste_Scape
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConvertBeginButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConvertBeginButton
            // 
            this.ConvertBeginButton.Location = new System.Drawing.Point(343, 12);
            this.ConvertBeginButton.Name = "ConvertBeginButton";
            this.ConvertBeginButton.Size = new System.Drawing.Size(134, 206);
            this.ConvertBeginButton.TabIndex = 0;
            this.ConvertBeginButton.Text = "转换";
            this.ConvertBeginButton.UseVisualStyleBackColor = true;
            this.ConvertBeginButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 30);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "D:\\Project\\ModifyTaste\\test\\Database.xlsx";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(325, 30);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "D:\\Project\\ModifyTaste\\test\\";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "输入Database路径和目标目录路径";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 230);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ConvertBeginButton);
            this.Name = "MainForm";
            this.Text = "ModifyTaste";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ConvertBeginButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
    }
}