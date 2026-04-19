
using System.Runtime.ExceptionServices;

class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Group { get; set; }
    public string Sex { get; set; }
    public double AvgMark { get; set; }

    public Student (string firstName, string lastName, string group, string sex, double avgmark)
    {
        FirstName = firstName;
        LastName = lastName;
        Group = group;
        Sex = sex;
        AvgMark = avgmark;
    }

    public void PrintStudent ()
    {
        Console.WriteLine($"Name: {FirstName}| Lastname: {LastName}| Group: {Group}| Sex: {Sex}| Average mark: {AvgMark}|");
    }



}

class Program
{
    static int findStudent(Student[] students, string group)
    {
        int count = 0;
        for(int i = 0; i < students.Length; i++)
        {
            if (students[i].AvgMark > 4.5 && students[i].Sex == "Female" && students[i].Group == group)
            {
                count++;
            }
        }

        return count;
    }
    static void Main(string[] args)
    {
        Student[] students = new Student[20]
        {
        new Student("Anna", "Ivanova", "IPZ-21", "Female", 4.8),
        new Student("Maria", "Bondar", "IPZ-21", "Female", 4.6),
        new Student("Olena", "Moroz", "IPZ-21", "Female", 4.7),
        new Student("Svitlana", "Kravets", "IPZ-21", "Female", 4.9),
        new Student("Daria", "Tkachenko", "IPZ-21", "Female", 4.3),
        new Student("Yulia", "Shevchenko", "IPZ-21", "Female", 4.1),
        new Student("Kateryna", "Lytvyn", "IPZ-21", "Female", 5.0),
        new Student("Anastasia", "Boyko", "IPZ-21", "Female", 4.55),
        new Student("Viktoria", "Hontar", "IPZ-21", "Female", 3.7),
        new Student("Natalia", "Savchenko", "IPZ-21", "Female", 4.6),
        new Student("Ivan", "Petrov", "IPZ-21", "Male", 4.2),
        new Student("Maxim", "Bilyi", "IPZ-21", "Male", 4.6),
        new Student("Dmytro", "Rudenko", "IPZ-21", "Male", 3.2),
        new Student("Roman", "Kuzmenko", "IPZ-21", "Male", 4.9),

        new Student("Denis", "Tveritinov", "IPZ-22", "Male", 4.9),
        new Student("Oleg", "Koval", "IPZ-22", "Male", 3.5),
        new Student("Igor", "Sidorov", "IPZ-22", "Male", 3.8),
        new Student("Andriy", "Pavlov", "IPZ-22", "Male", 4.8),
        new Student("Serhiy", "Melnyk", "IPZ-22", "Male", 4.4),
        new Student("Yaroslav", "Lysenko", "IPZ-22", "Male", 4.1)
        };

        Console.WriteLine("--- Вміст масиву студентів (упорядковано за групами) ---");
        Console.WriteLine($"{"Group",-8} | {"Name",-10} | {"Lastname",-12} | {"Sex",-7} | {"Mark"}");
        Console.WriteLine(new string('-', 55));

        foreach (var s in students)
        {
            Console.WriteLine($"{s.Group,-8} | {s.FirstName,-10} | {s.LastName,-12} | {s.Sex,-7} | {s.AvgMark}");
        }

        string targetGroup = "IPZ-21";
        int resultCount = findStudent(students, targetGroup);

        Console.WriteLine("--- Результат пошуку ---");
        Console.WriteLine($"Кількість дівчат групи {targetGroup} із балом > 4.5: {resultCount}");

        Console.ReadKey();
    }
}


