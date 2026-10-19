using System;

namespace ConsoleApp1.ss2
{
    public class DynamicArray<T>
    {
        private T[] items;
        public int Count { get; private set; }
        public int Capacity => items.Length;

        public DynamicArray(int capacity = 4)
        {
            if (capacity < 1)
            {
                capacity = 1;
            }
            items = new T[capacity];
            Count = 0;
        }

        public void Add(T item)
        {
            EnsureCapacity();
            items[Count] = item;
            Count++;
        }

        private void EnsureCapacity()
        {
            if (Count < items.Length)
            {
                return;
            }
            T[] newItems = new T[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                items[index] = value;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            DynamicArray<int> arr = new DynamicArray<int>();

            Console.WriteLine("--- Them tu 1 den 10 ---");
            for (int i = 1; i <= 10; i++)
            {
                int oldCap = arr.Capacity;
                arr.Add(i);
                Console.WriteLine("Add " + i + ": Count = " + arr.Count + ", Capacity = " + arr.Capacity);

                if (arr.Capacity != oldCap)
                {
                    Console.WriteLine("  Capacity tang " + oldCap + " -> " + arr.Capacity);
                    Console.Write("  Cac phan tu: ");
                    for (int j = 0; j < arr.Count; j++)
                    {
                        Console.Write(arr[j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("--- Doc va cap nhat ---");
            Console.WriteLine("arr[2] = " + arr[2]);
            arr[2] = 99;
            Console.WriteLine("Sau khi gan, arr[2] = " + arr[2]);

            Console.WriteLine("--- Kiem tra ngoai le ---");
            try
            {
                Console.WriteLine(arr[-1]);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("arr[-1]: bi tu choi");
            }

            try
            {
                Console.WriteLine(arr[arr.Count]);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("arr[Count]: bi tu choi");
            }
        }
    }
}