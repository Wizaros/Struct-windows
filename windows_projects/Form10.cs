using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_dll3;

namespace windows_projects
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        public int[,] arr;
        public int[] rezarr;
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Вы не ввели значение", "Вывод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                textBox2.Focus();
                return;
            }
            int A = Class1.InputInt(textBox1);
            int B = Class1.InputInt(textBox2);
            if (A <= 0 || B <= 0)
            {
                MessageBox.Show("Матрица не может быть отрицательной", "Вывод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (A != B)
            {
                MessageBox.Show("Матрица не может быть создана", "Вывод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            arr = new int[A, B];
            Class1.ArrayGenerate(arr, A, B);
            Class1.Output_mas(arr, A, B, dataGridView1);
            int k = Class1.Kol(arr, A, B);
            MessageBox.Show("Кол.во отрицательных столбцов = " + k,
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            rezarr = new int[A*B];
            Class1.Set_rezmas(arr, ref rezarr, A, B);
            Class1.Output_mas1(rezarr, rezarr.Length, dataGridView2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Class1.Add1();
            Class1.CreateStructBD(arr.GetLength(1));
            Class1.AddToBD(arr); 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.mdb; *.mdb";
            otkr.Filter = "Microsoft Acces (*mdb*)|*.mdb*";
            otkr.Title = "Выберите документ Acces";
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.ZapisBloknot(arr);
            MessageBox.Show("Данные успешно записаны в блокнот", "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.txt; *.txt";
            otkr.Filter = "Microsoft Acces (*txt*)|*.txt*";
            otkr.Title = "Выберите файл блокнот";
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.ZapisWord(arr, rezarr);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.docx; *.docx";
            otkr.Filter = "Microsoft Word (*docx*)|*.docx*";
            otkr.Title = "Выберите документ Word";
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Class1.Zap_Excel(arr, rezarr);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.xlsm; *.xlsx";
            otkr.Filter = "Microsoft Excel (*xlsm*)|*.xls*";
            otkr.Title = "Выберите документ Excel";
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbooks books = app.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook book = null;
            book = books.Open(@"C:\Users\Дмитрий\source\repos\windows_projects\windows_projects\bin\Debug\Массив результатов.xlsm");
            app.Run((object)"Macros_1");
            app.Run((object)"Macros_2");
            app.ScreenUpdating = true;
        }
    }
}
