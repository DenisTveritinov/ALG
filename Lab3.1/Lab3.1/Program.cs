using System;
using System.Collections.Generic;

public class Student
{
    private string LastName;
    public int ID;
    private double AvgMark;
    private bool HasConferenceParticipation;

    public Student(string LastName, int ID, double AvgMark, bool HasConferenceParticipation)
    {
        this.LastName = LastName;
        this.ID = ID;
        this.AvgMark = AvgMark;
        this.HasConferenceParticipation = HasConferenceParticipation;
    }

    // Геттеры, чтобы дерево могло "прочитать" данные для таблицы
    public string GetLastName()
    {
        return LastName;
    }

    public double GetAvgMark()
    {
        return AvgMark;
    }

    public bool GetParticipation()
    {
        return HasConferenceParticipation;
    }
}

public class BinaryTree
{
    public Node Root;

    public class Node
    {
        public Student Data;
        public Node LeftNode;
        public Node RightNode;

        public Node(Student student)
        {
            Data = student;
            LeftNode = null;
            RightNode = null;
        }
    }

    public void Add(Student student)
    {
        if (Root == null)
        {
            Root = new Node(student);
        }
        else
        {
            AddTo(Root, student);
        }
    }

    public void AddTo(Node node, Student student)
    {
        if (student.ID < node.Data.ID)
        {
            if (node.LeftNode == null)
            {
                node.LeftNode = new Node(student);
            }
            else
            {
                AddTo(node.LeftNode, student);
            }
        }
        else
        {
            if (node.RightNode == null)
            {
                node.RightNode = new Node(student);
            }
            else
            {
                AddTo(node.RightNode, student);
            }
        }
    }

    public void PrintParallel()
    {
        if (Root == null)
        {
            return;
        }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(Root);

        Console.WriteLine($"{"ID",-7} | {"LastName",-15} | {"Mark",-6} | {"Conf",-5}");
        Console.WriteLine(new string('-', 45));

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            string confStatus;
            if (current.Data.GetParticipation() == true)
            {
                confStatus = "Yes";
            }
            else
            {
                confStatus = "No";
            }

            Console.WriteLine($"{current.Data.ID,-7} | {current.Data.GetLastName(),-15} | {current.Data.GetAvgMark(),-6} | {confStatus,-5}");

            if (current.LeftNode != null)
            {
                queue.Enqueue(current.LeftNode);
            }

            if (current.RightNode != null)
            {
                queue.Enqueue(current.RightNode);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        tree.Add(new Student("Tveritinov", 50, 4.5, true));
        tree.Add(new Student("Ivanov", 30, 3.8, false));
        tree.Add(new Student("Sidorov", 70, 4.9, true));
        tree.Add(new Student("Bondar", 40, 4.2, false));
        tree.Add(new Student("Moroz", 60, 4.0, false));

        tree.PrintParallel();

        Console.ReadKey();
    }
}