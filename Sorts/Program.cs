using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            int arraySize = 20;

            // Bubble Sort
            array = Tools.CreateUnsortedArray(arraySize);
            Sorts.Sort(array, Sorts.AvailableSorts.BubbleSort);

            // Insertion Sort
            array = Tools.CreateUnsortedArray(arraySize);
            Sorts.Sort(array, Sorts.AvailableSorts.InsertionSort);

            // Selection Sort
            array = Tools.CreateUnsortedArray(arraySize);
            Sorts.Sort(array, Sorts.AvailableSorts.SelectionSort);

            // Merge Sort
            array = Tools.CreateUnsortedArray(arraySize);
            Sorts.Sort(array, Sorts.AvailableSorts.MergeSort);

            // Quick Sort
            array = Tools.CreateUnsortedArray(arraySize);
            Sorts.Sort(array, Sorts.AvailableSorts.QuickSort);
        }
    }
}
