using System;

namespace NumericIntgeration
{
    internal class Program
    {
        private delegate double Func(double x);

        private static void Main()
        {
            const int n = 10000;
            double result = SimpsonMethod(2, 3, n, x => x * (Math.Log10(x)));
            Console.WriteLine("x = {0}", -1 * result);

            Console.ReadKey();
        }
        private static double SimpsonMethod(double a, double b, int n, Func func)
        {
            double h = (b - a) / n;
            double s = (func(a) + func(b)) * 0.5;
            for (int i = 1; i <= n - 1; i++)
            {
                double xk = a + h * i; //xk
                double xk1 = a + h * (i - 1); //Xk-1
                s += func(xk) + 2 * func((xk1 + xk) / 2);
            }
            var x = a + h * n; //xk
            var x1 = a + h * (n - 1); //Xk-1
            s += 2 * func((x1 + x) / 2);

            return s * h / 3.0;
        }
    }
