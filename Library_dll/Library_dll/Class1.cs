using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_dll
{
    public class Class1
    {
        public static double Vvod(TextBox t)
        {
            return Convert.ToDouble(t.Text);
        }
        public static void Vivod(TextBox t, double g)
        {
            t.Text = Convert.ToString(g);
        }
        public static double Raschet(double x, double y)
        {
            double g = Math.Cos(y) + Math.Sin(x) / Math.Log(y) * Math.Pow(Math.Cos(x), 2);
            return g;
        }
        public static void Raschet_2(double x, double y, out double g)
        {
            g = Math.Cos(y) + Math.Sin(x) / Math.Log(y) * Math.Pow(Math.Cos(x), 2);
        }

        public static void Raschet_3(double x, double y, ref double g)
        {
            g = Math.Cos(y) + Math.Sin(x) / Math.Log(y) * Math.Pow(Math.Cos(x), 2);
        }
        public static double Razv(double g, double x, double y1, double z)
        {
            double max;
            if ((x < 0) && (z > 0))
            {
                g = y1 * (Math.Sqrt(4 + (Math.Pow((x * z), 3))));
            }
            if ((x > 0) && (y1 > 0) && (z < 0))
            {
                max = (Math.Pow(x, 2));
                if (Math.Log10(Math.Pow(x, 2) + (Math.Pow(y1, 2) + (Math.Pow(z, 2)))) > max)
                    max = (Math.Log10(Math.Pow(x, 2) + (Math.Pow(y1, 2) + (Math.Pow(z, 2)))));
                if (Math.Pow(y1, 2) > max)
                    max = (Math.Pow(y1, 2));
                g = max;
            }
            else
            {
                g = Math.Pow(Math.E, y1 * x + z);
            }
            return g;
            {
            }
        }
        public static void VivodDGV(double x, double y, DataGridView DGV)
        {
            DGV.Rows.Add(x.ToString("F1"), y.ToString("F3"));
        }
        public static void Tabul(double a, double b, double h, double y1, double z, double g, out double sum, out double srarifm, DataGridView d)
        {
            double x = a;
            sum = 0;
            srarifm = 0;
            int n = Convert.ToInt32(Math.Round((b - a) / h + 1));
            for (double i = 1; i <= n; i++)
            {
                double y = Class1.Razv(g, x, y1, z);
                if (y > 0)
                {
                    sum += y;
                    srarifm = sum / n;
                }
                Class1.VivodDGV(x, y, d);
                x += h;
            }
        }
        public static void VivodDGV2(double x, double y, DataGridView DGV)
        {
            DGV.Rows.Add(x.ToString("F1"), y.ToString("F7"));
        }
        public static double Funct(double x, double eps, int Nmax, DataGridView DGV)
        {
            int n = 0;
            double a = x;
            double s = 0;
            do
            {
                s += 4 * a;
                VivodDGV(n, a, DGV);
                a = -a * (Math.Pow(x, 2) * (2 * n + 1) / (2 * n + 3));
                n++;
            }
            while (Math.Abs(a) > eps && n < Nmax);
            return s;
        }
        public static double ChPi()
        {
            double ChPi = 4 * Math.Atan(1);
            return ChPi;
        }
    }
}