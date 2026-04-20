using System;

class Program
{
    static double f(double x)
    {
        return x * Math.Sqrt(2 * x + 1);
    }

    static void Main()
    {
        double a = 0;
        double b = 2;
        double h = 1.0;
        int n = (int)((b - a) / h);

        double[] x = new double[n + 1];
        double[] y = new double[n + 1];

        for (int i = 0; i <= n; i++)
        {
            x[i] = a + i * h;
            y[i] = f(x[i]);
        }

        //Метод прямокутників
        double rect = 0;
        for (int i = 0; i < n; i++) rect += y[i];
        rect *= h;

        //Метод трапецій
        double trap = h * ((y[0] + y[n]) / 2);
        for (int i = 1; i < n; i++) trap += h * y[i];

        //Метод Сімпсона
        double simp = (h / 3) * (y[0] + 4 * y[1] + y[2]);

        Console.WriteLine($"Rectangles: {rect:F5}");
        Console.WriteLine($"Trapezoids: {trap:F5}");
        Console.WriteLine($"Simpson: {simp:F5}");

        Console.ReadKey();
    }
}