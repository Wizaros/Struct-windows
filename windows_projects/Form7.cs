using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_dll2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace windows_projects
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public int length;
        public int[] rezmas;
        public int[] arr;
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 0;
            dataGridView2.ColumnCount = 0;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели значение", "Вывод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            length = Class1.InputInt(textBox1);
            arr = new int[length];
            int A = Class1.InputInt(textBox2);
            int B = Class1.InputInt(textBox3);
            Class1.Enter_mas(ref arr, length, A, B);
            Class1.Output_mas(arr, length, dataGridView1);
            int k = Class1.Kol(arr, length);
            MessageBox.Show(
                            "Количество пар = " + k,
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            int[] rezarr = new int[length];
            Class1.Set_mas(arr, k, ref rezarr, out int j);
            Class1.Output_mas(rezarr, j, dataGridView2);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
        }
    }
}
