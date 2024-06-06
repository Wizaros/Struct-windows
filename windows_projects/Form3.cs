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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Class1.Vvod(textBox1);
            double b = Class1.Vvod(textBox2);
            double c = Class1.Raschet(a, b);
            Class1.Vivod(textBox3, c);
            Class1.Raschet_2(a, b, out double rez);
            Class1.Vivod(textBox4, rez);
            double d = 0;
            Class1.Raschet_3(a, b, ref d);
            Class1.Vivod(textBox5, d);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
        }
    }
}
