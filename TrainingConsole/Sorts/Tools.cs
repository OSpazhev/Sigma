using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public enum ArrayStatus { Unsorted, Sorted }
    public static class Tools
    {
        public static void Swap<T>(ref T leftElement, ref T rightElement)
        {
            T tempElement = leftElement;
            leftElement = rightElement;
            rightElement = tempElement;
        }

        public static int[] CreateUnsortedArray(int size)
        {
            int[] array = new int[size];

            // more random
            // Random random = new Random(DateTime.Now.Millisecond);
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(size);
            }
            return array;
        }

        public static void OutputArray<T>(T[] array, ArrayStatus arrayStatus)
        {
            Console.Write($"{arrayStatus} array: ");
            for(int i = 0; i < array.Length - 1; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine(array[array.Length - 1]);
        }
    }
}
