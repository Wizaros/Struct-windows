using Library_dll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windows_projects
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Class1.Vvod(textBox1);
            double eps = Class1.Vvod(textBox2);
            double Result = Class1.Funct(x, eps, 45500, dataGridView1);
            double ChPi = Class1.ChPi();
            Class1.Vivod(textBox3, Result);
            Class1.Vivod(textBox5, ChPi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
        }
    }
}
