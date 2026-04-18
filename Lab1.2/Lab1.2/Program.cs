using System.Collections;
using System.Net.Sockets;

    class Rhombus
    {
        private int[] coordinates;

        public Rhombus(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            coordinates = new int[] { x1, y1, x2, y2, x3, y3, x4, y4 };
        }

        private double LengthCoords(int x1, int y1, int x2, int y2)
        {
            double lenght = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            return lenght;
        }

        public double GetPerimeter()
        {
            double firstSide = LengthCoords(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
            double secondSide = LengthCoords(coordinates[2], coordinates[3], coordinates[4], coordinates[5]);

            double perimeter = (firstSide + secondSide) * 2;

            return perimeter;
        }

        public double GetArea()
        {
            double diagonal1 = LengthCoords(coordinates[0], coordinates[1], coordinates[4], coordinates[5]);
            double diagonal2 = LengthCoords(coordinates[2], coordinates[3], coordinates[6], coordinates[7]);

            return (diagonal1 * diagonal2) / 2;
        }

        public void GetRhombus()
        {
            Console.WriteLine("Coordinates: ");
            int pointNumber = 1;
            for (int i = 0; i < coordinates.Length; i += 2)
                {
                    Console.WriteLine($"Point {pointNumber++}: X = {coordinates[i]}, Y = {coordinates[i + 1]}");
                }

            Console.WriteLine("Perimeter: " + GetPerimeter());
            Console.WriteLine("Area: " + GetArea());
        }
    }
class HashTable
{
    private Rhombus[] table;
    private int size;

    public HashTable(int size)
    {
        this.size = size;
        this.table = new Rhombus[size];
    }

    private int GetIndex(double perimeter)
    {
        int key = (int)Math.Round(perimeter);
        return key % size;
    }

    public void Insert(Rhombus rhombus)
    {
        double p = rhombus.GetPerimeter();

        int index = GetIndex(p);

        table[index] = rhombus;

        Console.WriteLine($"Rhombus with P: {p:F2} added to index [{index}]");
    }

    public void PrintTable()
    {
        Console.WriteLine("Hash Table Content");
        for (int i = 0; i < size; i++)
        {
            if (table[i] != null)
            {
                Console.Write($"Index {i}: ");
                table[i].GetRhombus();
            }
            else
            {
                Console.WriteLine($"Index {i}: [Empty]");
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        HashTable myTable = new HashTable(5);

        Rhombus r1 = new Rhombus(0, 5, 3, 0, 0, -5, -3, 0); 
        Rhombus r2 = new Rhombus(0, 2, 1, 0, 0, -2, -1, 0); 

        myTable.Insert(r1);
        myTable.Insert(r2);

        myTable.PrintTable();

        Console.ReadLine();
    }
}
     


