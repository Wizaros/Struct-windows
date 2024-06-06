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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            this.Hide();
            f.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            this.Hide();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            this.Hide();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            this.Hide();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            this.Hide();
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            this.Hide();
            f.ShowDialog();
        }
    }
}
