using System;
using System.Diagnostics;

class Program
{
    static void CountingSort(int[] arr)
    {
        if (arr.Length == 0) return;

        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] > max) max = arr[i];

        int[] count = new int[max + 1];
        int[] output = new int[arr.Length];

        for (int i = 0; i < arr.Length; i++)
            count[arr[i]]++;

        for (int i = 1; i <= max; i++)
            count[i] += count[i - 1];

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            output[count[arr[i]] - 1] = arr[i];
            count[arr[i]]--;
        }

        for (int i = 0; i < arr.Length; i++)
            arr[i] = output[i];
    }

    static void Main(string[] args)
    {
        int[] testSizes = { 100, 10000, 1000000 };
        Random rnd = new Random();

        Console.WriteLine($"{"Кількість",-15} | {"Час",-15}");
        Console.WriteLine(new string('-', 35));

        foreach (int n in testSizes)
        {
            int[] data = new int[n];
            for (int i = 0; i < n; i++)
                data[i] = rnd.Next(0, 1001);

            Stopwatch sw = Stopwatch.StartNew();
            CountingSort(data);
            sw.Stop();

            Console.WriteLine($"{n,-15} | {sw.Elapsed.TotalMilliseconds:F3} ms");
        }
        Console.ReadKey();
    }
}