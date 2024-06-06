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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Class1.Vvod(textBox1);
            double y1 = Class1.Vvod(textBox2);
            double z = Class1.Vvod(textBox3);
            double g = Class1.Razv(0, x, y1, z);
            Class1.Vivod(textBox4, g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
        }
    }
}
