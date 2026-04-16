using System.ComponentModel;

class ArrList
{
    private int[] arr;
    private int size;
    private int capasity = 2;

    public ArrList()
    {
        arr = new int[capasity];
    }

    public void add(int i)
    {
            if (size == capasity)
            {
                capasity *= 2;
                int[] newArr = new int[capasity];

                for (int j = 0; j < size; j++)
                {
                    newArr[j] = arr[j];
                }

                arr = newArr;
            }

            arr[size] = i;
            size++;

    }

    public void remove(int i)
    {
        if(size == 0 || i >= size)
        {
            Console.WriteLine("You can't remove element, because array is too short");
        }
        else
        {
            for(int j = i; j < size; j ++)
            {
                arr[j] = arr[++j];
            }
            size--;
        }
        
    }

    public int this[int index]
    {
        get
        {
            return arr[index];
        }
        set
        {
            arr[index] = value;
        }
    }


    public int Size()
    {
        return size;
    }

    public int Get(int index)
    {
        return arr[index];
    }

}

class Program
{
    static void Main(string[] args)
    {
        ArrList arr = new ArrList();
        arr.add(1);
        arr.add(2);
        arr.add(3);
        arr.add(4);
        arr.add(5);

        arr.remove(3);
        arr.remove(2);

        for (int i = 0; i < arr.Size(); i ++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}