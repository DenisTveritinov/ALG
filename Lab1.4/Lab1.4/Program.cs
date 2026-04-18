using System;

namespace SortingApp
{
    public class Student
    {
        private string LastName;
        private string FirstName;
        private double AvgMark;
        private string Gender;

        public Student(string LastName, string FirstName, double AvgMark, string Gender)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.AvgMark = AvgMark;
            this.Gender = Gender;
        }

        public string GetLastName() { return LastName; }
        public string GetFirstName() { return FirstName; }
        public double GetAvgMark() { return AvgMark; }
        public string GetGender() { return Gender; }
    }

    public class SortMachine
    {
        public void InsertionSort(Student[] students)
        {
            for (int i = 1; i < students.Length; i++)
            {
                Student key = students[i];
                int j = i - 1;

                while (j >= 0 && students[j].GetAvgMark() > key.GetAvgMark())
                {
                    students[j + 1] = students[j];
                    j = j - 1;
                }
                students[j + 1] = key;
            }
        }

        public void PrintArray(Student[] students, string message)
        {
            Console.WriteLine($"--- {message} ---");
            Console.WriteLine($"{"LastName",-12} | {"FirstName",-10} | {"Mark",-5} | {"Sex",-5}");
            Console.WriteLine(new string('-', 45));

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"{students[i].GetLastName(),-12} | {students[i].GetFirstName(),-10} | {students[i].GetAvgMark(),-5} | {students[i].GetGender(),-5}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
                new Student("Tveritinov", "Denis", 4.8, "Male"),
                new Student("Ivanov", "Ivan", 3.5, "Male"),
                new Student("Sidorova", "Anna", 5.0, "Female"),
                new Student("Bondar", "Oleg", 4.2, "Male"),
                new Student("Moroz", "Elena", 3.9, "Female")
            };

            SortMachine sorter = new SortMachine();

            sorter.PrintArray(students, "Масив до сортування");

            sorter.InsertionSort(students);

            sorter.PrintArray(students, "Масив після сортування");

            Console.ReadKey();
        }
    }
}