using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string expression = textBox1.Text;
            textBox2.Text = Convert.ToString(Calculator.Result(expression));
        }
        int amount_lines = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("test.txt");
            if (amount_lines >= lines.Length)
            {
                label2.Text = "В файле больше нет строк!";
                label2.ForeColor = Color.Red;
                return;
            }
            textBox1.Text = lines[amount_lines];
            textBox2.Text = Convert.ToString(Calculator.Result(lines[amount_lines]));
            amount_lines++;   

        }

    }
}
