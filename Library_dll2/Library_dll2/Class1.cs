using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace Library_dll2
{
    public class Class1
    {
        public static int InputInt(TextBox t)
        {
            return Convert.ToInt32(t.Text);
        }
        public static void Vivod(TextBox t, double g)
        {
            t.Text = Convert.ToString(g);
        }
        public static int[] Set_mas(int[] mas, int k, ref int[] rezmas, out int j) // метод для создания нового массива на основе старого
        {
            j = 0;
            for (int i = 0; i < mas.GetLength(0) - 1; i++)
            {
                if (mas[i] % 5 == 0 && mas[i + 1] % 5 == 0)
                {
                    rezmas[j] = mas[i] * mas[i + 1];
                    j++;
                }
            }
            return rezmas;
        }
        public static int[] Enter_mas(ref int[] mas, int lenght, int a, int b) // метод для заполнения массива случайными числами
        {
            Random rnd = new Random();
            for (int i = 0; i < lenght; i++)
            {
                mas[i] = rnd.Next(a, b);
            }
            return mas;
        }
        public static void Output_mas(int[] mas, int lenght, DataGridView grid) // метод для вывода массива в таблицу
        {
            grid.ColumnCount = lenght;
            grid.RowCount = 2;
            for (int i = 0; i < lenght; i++)
            {
                grid.Rows[0].Cells[i].Value = "[" + i + "]";
                grid.Rows[1].Cells[i].Value = mas[i];
            }
        }
        public static int Kol(int[] mas, int lenght) // метод для подсчёта количества элементов в массиве
        {
            int count = 0;
            for (int i = 0; i < lenght-1; i++)
            {
                if (mas[i] % 5 == 0 && mas[i+1] % 5 == 0)
                {
                    count++;
                }
            }
            return count;
        }
        public static int Alg2 (int[] a, int n) // метод удаления элемента из одномерного массива
        {
            int k = 1; 
            for (int i = 2; i < n; i++) 
            {
                if (a[i] > a[k]) 
                {
                    k = i; 
                }
            }
            for (int i = k; i < n - 1; i++) 
            {
                a[i] = a[i + 1]; 
            }
            n = n - 1;
            return k;
        }
        public static int Alg6(int[] a) // метод нахождения первого нечётного элемента
        {
            int i = 0;
            int Flag = 0;
            int n = a.Length;
            while (i < n && Flag == 0)
            {
                if (a[i] % 2 != 0)
                {
                    Flag = 1;
                }
                else
                {
                    i++;
                }
            }
            if (Flag == 1)
            {
                return a[i];
            }
            return -1;
        }
        public static int Alg7(int[] a) // метод нахождения первого положительного элемента
        {
            int i = 0;
            int Flag = 0;
            int n = a.Length;
            while (i < n && Flag == 0)
            {
                if (a[i] > 0)
                {
                    Flag = 1;
                }
                else
                {
                    i++;
                }
            }
            if (Flag == 1)
            {
                return a[i];
            }
            return -1;
        }
        public static void Alg9(int[] a, int length) // метод сортировки простой вставкой
        {
            for (int i = 1; i < length; i++) 
            {
                int x = a[i]; 
                int j = i - 1;
                while (j >= 0 && a[j] > x)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = x;
            }
        }
        public static void Alg11(int[] a, int length) // метод сортировки простым выбором
        {
            for (int i = 0; i < length; i++) 
            {
                int k = i;   
                for (int j = i + 1; j < length; j++) 
                {
                    if (a[j] < a[k]) 
                    {
                        k = j; 
                    }
                }
                int x = a[i];
                a[i] = a[k]; 
                a[k] = x;  
            }
        }
        public static void Add1() // метод для создания базы данных
        {
            var k = new ADOX.Catalog();
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            try
            {
                k.Create("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path.ToString().Replace("\\", "\\\\") + "\\Results.mdb");
            }
            catch (System.Runtime.InteropServices.COMException exp)
            {
                MessageBox.Show(exp.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                k = null;
            }
        }
        public static void Add_Struct1() // метод создания новой таблицы с указанными полями в базе данныхм
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            var p = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + path.ToString().Replace("\\", "\\\\") + "\\Results.mdb");
            p.Open();
            var c = new OleDbCommand("Create Table [results]([№ Индекса] counter, [Результат] char(20))", p);
            try
            {
                c.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            p.Close();
        }
        public static void Add_Zap1(int[] mas, int len) // метод для добавления новых записей в базу данных
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            for (int i = 0; i < len; i++)
            {
                var p = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + path.ToString().Replace("\\", "\\\\") + "\\Results.mdb");
                p.Open();
                var c = new OleDbCommand("INSERT INTO [results](" + " [Результат]) VALUES('" + mas[i] + "')");
                c.Connection = p;
                c.ExecuteNonQuery();
                p.Close();
            }
            MessageBox.Show("База данных создана", "Создание БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ZapisWordIsx(int[] mas) // метод для создания таблицы Word и заполнения её значениями из массива
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            var Wrd = new Microsoft.Office.Interop.Word.Application
            {
                Visible = true
            };
            var inf = Type.Missing;
            string str;
            var Doc = Wrd.Documents.Add(inf);
            Wrd.Selection.TypeText("Массив ответов");
            object t1 = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            object t2 = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            Microsoft.Office.Interop.Word.Table tbl = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, 2, mas.Length, t1, t2);
            for (int i = 0; i < mas.Length; i++)
            {
                tbl.Cell(1, i + 1).Range.Text = "[" + Convert.ToString(i) + "]";
                str = String.Format("{0:f0}", mas[i]);
                tbl.Cell(2, i + 1).Range.InsertAfter(str);
            }
        }
        public static void Zap_Excel_Double(int[] mas, int[] rezmas, int g) // метод для записи данных из двух массивов в Excel-таблицу
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            workSheet.Name = "Массив исходный";
            workSheet.Cells[1, 1] = "Массив ответов";
            for (int i = 0; i < mas.Length; i++)
            {
                workSheet.Cells[2, i + 1] = "[" + i + "]";
                workSheet.Cells[3, i + 1] = mas[i];
            }
            Excel.Range range1 = workSheet.Range[workSheet.Cells[2, 1], workSheet.Cells[3, mas.Length]];
            workSheet.Cells[9, 1] = "Результирующий массив";
            int column = 1;
            for (int i = 0; i < g; i++)
            {
                if (rezmas[i] != 0)
                {
                    workSheet.Cells[10, i + 1] = "[" + i + "]";
                    workSheet.Cells[11, i + 1] = rezmas[i];
                    column++;
                }

            }
            Excel.Range range2 = workSheet.Range[workSheet.Cells[10, 1], workSheet.Cells[11, column - 1]];
            workSheet.Range[("A7")].Select();
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
    }
}
