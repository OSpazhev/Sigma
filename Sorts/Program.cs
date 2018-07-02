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
            Tools.OutputArray(array, ArrayStatus.Unsorted);
            Sorts.BubbleSort(array);
            Tools.OutputArray(array, ArrayStatus.Sorted);
        }
    }
}
