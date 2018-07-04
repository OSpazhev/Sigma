using System;

namespace MyList
{
    class Program
    {
        public static void WriteElement(int value)
        {
            Console.Write($"{value} ");
        }
        public static void OutputMyList(MyList<int> myList)
        {
            Console.WriteLine($"myList size: {myList.Count}");
            Action<int> myDelegate = WriteElement;
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
        }
    }
}
