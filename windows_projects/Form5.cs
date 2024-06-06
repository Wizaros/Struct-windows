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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Class1.Vvod(textBox1);
            double b = Class1.Vvod(textBox2);
            double h = Class1.Vvod(textBox3);
            double y1 = Class1.Vvod(textBox4);
            double z = Class1.Vvod(textBox5);
            double g = Class1.Vvod(textBox6);
            Class1.Tabul(a, b, h, y1, z, g, out double sum, out double srarifm, dataGridView1);
            Class1.Vivod(textBox7, sum);
            Class1.Vivod(textBox8, srarifm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
        }
    }
}
