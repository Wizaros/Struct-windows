using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_dll2;
using Microsoft.Office.Interop.Word;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace windows_projects
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public int length;
        public int[] rezmas;
        public int[] arr;

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Zap_Excel_Double(arr, rezmas, length);
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.ZapisWordIsx(arr);
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

        private void button10_Click(object sender, EventArgs e)
        {
            Class1.Add1();
            Class1.Add_Struct1();
            Class1.Add_Zap1(arr, length);
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

        private void button7_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbooks books = app.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook book = null;
            book = books.Open(@"C:\Users\Дмитрий\source\repos\windows_projects\windows_projects\bin\Debug\Массив ответов.xlsm");
            app.Run((object)"Macros_1");
            app.Run((object)"Macros_2");
            app.ScreenUpdating = true;
        }
    }
}
