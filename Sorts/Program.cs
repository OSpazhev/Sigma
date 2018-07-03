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

            // Bubble Sort
            array = Tools.CreateUnsortedArray(10);
            Sorts.Sort(array, Sorts.AvailableSorts.BubbleSort);

            // Insertion Sort
            array = Tools.CreateUnsortedArray(10);
            Sorts.Sort(array, Sorts.AvailableSorts.InsertionSort);

            // Selection Sort
            array = Tools.CreateUnsortedArray(10);
            Sorts.Sort(array, Sorts.AvailableSorts.SelectionSort);
        }
    }
}
