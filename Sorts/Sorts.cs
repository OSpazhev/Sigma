using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public static class Sorts
    {
        public enum AvailableSorts { BubbleSort, SelectionSort }

        public static void Sort<T>(T[] array, AvailableSorts availableSorts) where T : IComparable
        {
            Console.WriteLine($"{availableSorts}:");

            Tools.OutputArray(array, ArrayStatus.Unsorted);

            switch (availableSorts)
            {
                case AvailableSorts.BubbleSort:
                    BubbleSort(array);
                    break;
                case AvailableSorts.SelectionSort:
                    SelectionSort(array);
                    break;
                default:
                    Console.WriteLine("Array wasn't sorted");
                    return;
            }

            Tools.OutputArray(array, ArrayStatus.Sorted);
        }

        public static void BubbleSort<T>(T[] array) where T : IComparable
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) >= 0)
                    {
                        Tools.Swap<T>(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        public static void SelectionSort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                T bufferElement = array[i];
                int indexForInsert = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[j].CompareTo(bufferElement) <= 0)
                    {
                        indexForInsert = j + 1;
                        break;
                    }
                }
                for (int j = i; j > indexForInsert; j--)
                {
                    array[j] = array[j - 1];
                }
                array[indexForInsert] = bufferElement;
            }
        }
    }
}
