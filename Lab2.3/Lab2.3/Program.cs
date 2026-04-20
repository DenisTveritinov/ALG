using System;

class Program
{
    static long CalculateArrangements(int n, int k)
    {
        long result = 1;

        for (int i = 0; i < k; i++)
        {
            result *= (n - i);
        }

        return result;
    }

    static void Main(string[] args)
    {
        int n = 11;
        int k = 4;

        long result = CalculateArrangements(n, k);

        Console.WriteLine($"{"Кількість учасників",-20} | {n}");
        Console.WriteLine($"{"Кількість у команді",-20} | {k}");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine($"{"Варіантів складу",-20} | {result}");

        Console.ReadKey();
    }
}