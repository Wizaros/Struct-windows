using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Library_dll3
{
    public class Class1
    {
        public static int InputInt(TextBox t) // метод для ввода и обработки числовых данных
        {
            return Convert.ToInt32(t.Text);
        }
        public static void ArrayGenerate(int[,] mas,int n,int m) // метод заполнения массива случайными числами
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    mas[i, j] = Convert.ToInt16(rnd.Next(-50, 100));
        }
        public static void Output_mas(int[,] mas,int n,int m, DataGridView dgv) // метод для вывода двумерного массива в таблицу
        {
            dgv.ColumnCount = m + 1;
            dgv.RowCount = n + 1;
            dgv.Rows[0].Cells[0].Value = "[" + n + "]" + "[" + m + "]";

            for (int i = 0; i < n; i++)
                dgv.Rows[i + 1].Cells[0].Value = "[" + i + "]";
            for (int j = 0; j < n; j++)
                dgv.Rows[0].Cells[j + 1].Value = "[" + j + "]";
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    dgv.Rows[i + 1].Cells[j + 1].Value = mas[i, j];
        }
        public static void Output_mas1(int[] mas, int lenght, DataGridView grid) // метод для вывода одномерного массива в таблицу
        {
            grid.ColumnCount = lenght;
            grid.RowCount = 2;
            for (int i = 0; i < lenght; i++)
            {
                grid.Rows[0].Cells[i].Value = "[" + i + "]";
                grid.Rows[1].Cells[i].Value = mas[i];
            }
        }
        public static int Kol(int[,] mas,int n,int m) // метод для подсчёта кол-ва отр. столбцов
        {
            int count = 0;
            int Flag = 0;
            for (int j = 0; j < m; j++)
            {
                Flag = 0;
                for (int i = 0; i < n; i++)
                {
                    if (mas[i, j] < 0)
                    {
                        Flag = 1;
                        break;
                    }
                }
                if (Flag == 1)
                {
                    count++;
                }
            }
            return count;
        }
        public static void Set_rezmas(int[,] mas, ref int[] rezmas, int n, int m) // метод формирования нового массива из элементов исходной матрицы
        {
            int k = Kol(mas, n, m);
            int g = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mas[i, j] > k)
                    {
                        if (g < rezmas.Length)
                        {
                            rezmas[g++] = mas[i, j];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Array.Resize(ref rezmas, g);
        }
        public static void Add1() // метод для создания базы данных
        {
            var k = new ADOX.Catalog();
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            try
            {
                k.Create("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path.ToString().Replace("\\", "\\\\") + "\\Results1.mdb");
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
        public static void CreateStructBD(int cols) // метод создание структуры базы данных
        {
            var Connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Results1.mdb");
            Connect.Open();
            String Col = "CREATE TABLE [Matrix] ([Rows] counter";
            for (int i = 0; i < cols; i++)
            {
                Col = Col + ", [" + "Col" + Convert.ToString(i + 1) + "] char(5)";
            }
            var Command = new OleDbCommand(Col + ")", Connect);
            try
            {
                Command.ExecuteNonQuery();
                MessageBox.Show("Таблица создана успешно",
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (System.Runtime.InteropServices.COMException exp)
            {
                MessageBox.Show(exp.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Connect.Close();
        }
        public static void CommBD(String commandString) // метод для выполнения SQL-запроса к базе данных
        {
            var Connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Results1.mdb");
            Connection.Open();
            var Command = new OleDbCommand("" + commandString);
            Command.Connection = Connection;
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        public static void AddToBD(int[,] mas) // метод для добавления данных в базу данных
        {
            String cmdString;
            String cmdString2;
            var Connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Results1.mdb");
            Connect.Open();
            int rows = mas.GetLength(0); 
            int cols = mas.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                cmdString = "INSERT INTO [Matrix] ([Rows]";
                cmdString2 = ") VALUES (" + "'" + Convert.ToString(i + 1) + "'";
                for (int j = 0; j < cols; j++)
                {
                    cmdString = cmdString + ", [Col" + Convert.ToString(j + 1) + "]";
                    cmdString2 = cmdString2 + ", '" + Convert.ToString(mas[i,j]) + "'";
                }
                cmdString2 = cmdString2 + ")";
                CommBD(cmdString + cmdString2);
            }
            Connect.Close();
            MessageBox.Show("Данные успешно добавлены в базу данных", "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        public static void ZapisBloknot(int[,] mas) // метод для записи данных в блокнот
        {
            StreamWriter rez = new StreamWriter("Results1.txt");
            int cols = mas.GetLength(0);
            int rows = mas.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    rez.Write(mas[i, j] + "\t");
                }
                rez.WriteLine("\n");
            }
            rez.Close();
        }
        public static void ZapisWord(int[,] mas, int[] rezmas) // метод для записи данных в Microsoft Word
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            var Wrd = new Microsoft.Office.Interop.Word.Application
            {
                Visible = true
            };
            var inf = Type.Missing;
            string str;
            var Doc = Wrd.Documents.Add(inf);
            Wrd.Selection.TypeText("Исходный массив");
            Object t1 = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object t2 = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            Microsoft.Office.Interop.Word.Table tbl = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, mas.GetLength(0) + 1, mas.GetLength(1) + 1, t1, t2);
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                tbl.Cell(i + 2, 1).Range.InsertAfter("[" + Convert.ToString(i) + "]");
            }
            for (int j = 0; j < mas.GetLength(1); j++)
            {
                tbl.Cell(1, j + 2).Range.InsertAfter("[" + Convert.ToString(j) + "]");
            }
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    str = String.Format("{0:f2}", mas[i, j]);
                    tbl.Cell(i + 2, j + 2).Range.InsertAfter(str);
                }
            }
            Object t3 = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            Object add_str = mas.GetLength(0) + 2;
            Wrd.Selection.MoveDown(t3, add_str, inf);
            Wrd.Selection.TypeText("Количество элементов больших по значению найденных столбцов: " + rezmas.Length + "\n Результирующий массив");
            tbl = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, 2, rezmas.Length, t1, t2);
            for (int i = 0; i < rezmas.Length; i++)
            {
                tbl.Cell(1, i + 1).Range.InsertAfter("[" + Convert.ToString(i) + "]");
                str = String.Format("{0:f2}", rezmas[i]);
                tbl.Cell(2, i + 1).Range.InsertAfter(str);
            }
        }
        public static void Zap_Excel(int[,] mas, int[] rezmas) // метод для записи данных в Excel-таблицу
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            workSheet.Name = "Массив исходный";
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                    workSheet.Cells[j + 1, i + 1] = mas[i, j];
            }
            workSheet.Cells[9, 1] = "Результирующий массив";
            for (int i = 0; i < rezmas.Length; i++)
            {
                workSheet.Cells[10, i + 1] = "[" + i + "]";
                workSheet.Cells[11, i + 1] = rezmas[i];

            }
            workSheet.Range["A15"].Select();
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
    }
}