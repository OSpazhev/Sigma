using Sorts;
using System;
using System.ComponentModel;

namespace MyList
{
    class Program
    {
        public static void WriteElement<T>(T value)
        {
            Console.Write($"{value} ");
        }
        public static void OutputMyList<T>(MyList<T> myList)
        {
            Console.WriteLine($"myList size: {myList.Count}");
            Action<T> myDelegate = WriteElement;
            myList.ForEach(myDelegate);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var myList1 = new MyList<int>();
            OutputMyList(myList1);

            var myList2 = new MyList<int>(10);
            OutputMyList(myList2);

            var myList3 = new MyList<int>(10, 9);
            OutputMyList(myList3);

            myList1.Add(10);
            OutputMyList(myList1);

            myList2.AddRange(new int[] { 20, 20, 20 });
            OutputMyList(myList2);

            myList1.Clear();
            OutputMyList(myList1);

            Console.WriteLine(myList3.Contains(9));
            OutputMyList(myList3);

            var array = Tools.CreateUnsortedArray(20);
            Sorts.Sorts.MergeSort(array);
            myList1.AddRange(array);
            var aim = (new Random()).Next(20);
            Console.WriteLine($"Aim: {aim}");
            OutputMyList(myList1);
            Console.WriteLine(myList1.BinarySearch(aim));

            OutputMyList(myList1.ConvertAll(value => (char)value));

            array = new int[20];
            myList1.CopyTo(array);
            myList1.AddRange(array);
            OutputMyList(myList1);

            Console.WriteLine("Exists: " + myList1.Exists(x => x == 10));
            Console.WriteLine("Find: " + myList1.Find(x => x == 10));
            Console.WriteLine("FindLast: " + myList1.FindLast(x => x == 10));
            Console.WriteLine("FindAll.Count: " + myList1.FindAll(x => x == 10)?.Count);
            Console.WriteLine("FindIndex: " + myList1.FindIndex(x => x == 10));
            Console.WriteLine("FindLastIndex: " + myList1.FindLastIndex(x => x == 10));
            Console.WriteLine("IndexOf: " + myList1.IndexOf(10));
            Console.WriteLine("LastIndexOf: " + myList1.LastIndexOf(10));

            OutputMyList(myList1.GetRange(3, 4));
            myList1.Insert(2, -1);
            OutputMyList(myList1);

            myList1.Remove(-1);
            myList1.RemoveRange(37, 2);
            myList1.RemoveAt(0);
            myList1.RemoveAll(x => x == 8);
            OutputMyList(myList1);
        }
    }
}
