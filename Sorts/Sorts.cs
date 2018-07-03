using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public static class Sorts
    {
        public enum AvailableSorts { BubbleSort, InsertionSort, SelectionSort, MergeSort }

        public static void Sort<T>(T[] array, AvailableSorts availableSorts) where T : IComparable
        {
            Console.WriteLine($"{availableSorts}:");

            Tools.OutputArray(array, ArrayStatus.Unsorted);

            switch (availableSorts)
            {
                case AvailableSorts.BubbleSort:
                    BubbleSort(array);
                    break;
                case AvailableSorts.InsertionSort:
                    InsertionSort(array);
                    break;
                case AvailableSorts.SelectionSort:
                    SelectionSort(array);
                    break;
                case AvailableSorts.MergeSort:
                    MergeSort(array);
                    break;
                default:
                    Console.WriteLine("Array wasn't sorted");
                    return;
            }

            Tools.OutputArray(array, ArrayStatus.Sorted);
            Console.WriteLine();
        }

        #region BubbleSort
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
        #endregion

        #region InsertionSort
        public static void InsertionSort<T>(T[] array) where T : IComparable
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
        #endregion

        #region SelectionSort
        public static void SelectionSort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                var minimalElement = new { Value = array[i], Index = i };
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minimalElement.Value) < 0)
                    {
                        minimalElement = new { Value = array[j], Index = j };
                    }
                }

                Tools.Swap(ref array[i], ref array[minimalElement.Index]);
            }
        } 
        #endregion

        #region MergeSort
        private static void MergeArrays<T>(T[] leftArray, T[] rightArray, T[] resultArray) where T : IComparable
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int resultIndex = 0;

            while (leftIndex < leftArray.Length || rightIndex < rightArray.Length)
            {
                if (leftIndex >= leftArray.Length)
                {
                    resultArray[resultIndex++] = rightArray[rightIndex++];
                }
                else if (rightIndex >= rightArray.Length)
                {
                    resultArray[resultIndex++] = leftArray[leftIndex++];
                }
                else
                {
                    if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) < 0)
                    {
                        resultArray[resultIndex++] = leftArray[leftIndex++];
                    }
                    else
                    {
                        resultArray[resultIndex++] = rightArray[rightIndex++];
                    }
                }
            }
        }

        public static void MergeSort<T>(T[] array) where T : IComparable
        {
            if (array.Length <= 1)
                return;

            int arrayMiddle = array.Length / 2;

            T[] leftArray = new T[arrayMiddle];
            T[] rightArray = new T[array.Length - arrayMiddle];

            Array.Copy(array, 0, leftArray, 0, arrayMiddle);
            Array.Copy(array, arrayMiddle, rightArray, 0, array.Length - arrayMiddle);

            MergeSort(leftArray);
            MergeSort(rightArray);

            MergeArrays(leftArray, rightArray, array);
        }
        #endregion
    }
}
