using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "words.txt";

        string[] initialWords = {
            "{123}",
            "{ABC}",
            "{5X9}",
            "123",      
            "{abc}",
            "{A1B2}",
            "{?#!}",
            "{}"
        };

        File.WriteAllLines(fileName, initialWords);

        string pattern = @"^\{[0-9A-Z]+\}$";
        Regex regex = new Regex(pattern);

        Console.WriteLine($"{"Слово",-15} | {"Результат",-10}");
        Console.WriteLine(new string('-', 30));

        string[] lines = File.ReadAllLines(fileName);

        foreach (string word in lines)
        {
            if (regex.IsMatch(word))
            {
                Console.WriteLine($"{word,-15} | Знайдено");
            }
            else
            {
                Console.WriteLine($"{word,-15} | Не підходить");
            }
        }

        Console.ReadKey();
    }
}