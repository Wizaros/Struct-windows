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
using Microsoft.VisualBasic;

namespace windows_projects
{
    public partial class Form8 : Form
    {
        public Form8()
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
            rezmas = new int[length];
            int A = Class1.InputInt(textBox2);
            int B = Class1.InputInt(textBox3);
            Class1.Enter_mas(ref arr, length, A, B);
            Class1.Output_mas(arr, length, dataGridView1);
            int k = Class1.Kol(arr, length);
            Class1.Set_mas(arr, k, ref rezmas, out int j);
            Class1.Output_mas(rezmas, j, dataGridView2);
            MessageBox.Show(
                            "Результатирующий массив = " + k,
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int indexToDelete = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox(("Введите индекс элемента, который нужно удалить:")));
            int length = rezmas.Length;
            if (indexToDelete < length)
            {
                int deletedIndex = Class1.Alg2(rezmas, length);
                MessageBox.Show($"Элемент с индексом {deletedIndex} был удалён из массива", "Удаление элемента");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int k = Class1.Alg6(rezmas);
            if (k != -1)
            {
                MessageBox.Show(
                            "Первый нечётный элемент = " + k,
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                                "В массиве нет нечетных элементов",
                                "",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int k = Class1.Alg7(rezmas);
            if (k != -1)
            {
                MessageBox.Show(
                            "Первый положительный элемент = " + k,
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                                "В массиве нет положительных элементов",
                                "",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1.Alg9(rezmas, length);
            Class1.Output_mas(rezmas, length, dataGridView3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Class1.Alg11(rezmas, length);
            Class1.Output_mas(rezmas, length, dataGridView4);
        }
    }
}
