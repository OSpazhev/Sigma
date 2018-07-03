using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public static class Sorts
    {
        public enum AvailableSorts { BubbleSort, InsertionSort, SelectionSort, MergeSort, QuickSort, BinarySort }

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
                case AvailableSorts.QuickSort:
                    QuickSort(array);
                    break;
                case AvailableSorts.BinarySort:
                    BinarySort(array);
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

        #region QuickSort
        public static void QuickSort<T>(T[] array) where T : IComparable
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public static void QuickSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex >= rightIndex)
                return;
            int mediumIndex = (new Random()).Next(rightIndex - leftIndex + 1) + leftIndex;

            Tools.Swap(ref array[mediumIndex], ref array[rightIndex]);

            int left = leftIndex;
            int right = rightIndex - 1;
            while (left < right)
            {
                if (array[right].CompareTo(array[rightIndex]) < 0 && array[left].CompareTo(array[rightIndex]) >= 0)
                {
                    Tools.Swap(ref array[left++], ref array[right--]);
                }
                if (array[left].CompareTo(array[rightIndex]) < 0)
                {
                    left++;
                }
                if (array[right].CompareTo(array[rightIndex]) >= 0)
                {
                    right--;
                }
            }
            
            if (left == right)
            {
                if (array[left].CompareTo(array[rightIndex]) < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            Tools.Swap(ref array[left++], ref array[rightIndex]);

            QuickSort(array, left, rightIndex);
            QuickSort(array, leftIndex, right);
        }
        #endregion

        private class Node<T> where T : IComparable
        {
            public Node<T> LeftSon { get; set; } = null;
            public Node<T> RightSon { get; set; } = null;
            public T Value { get; set; }
            public void AddValueToTheTree(T newValue)
            {
                if (newValue.CompareTo(Value) <= 0)
                {
                    if (LeftSon != null)
                    {
                        LeftSon.AddValueToTheTree(newValue);
                    }
                    else
                    {
                        LeftSon = new Node<T>();
                        LeftSon.Value = newValue;
                    }
                }
                else
                {
                    if (RightSon != null)
                    {
                        RightSon.AddValueToTheTree(newValue);
                    }
                    else
                    {
                        RightSon = new Node<T>();
                        RightSon.Value = newValue;
                    }
                }
            }
            public void GetSortedArray(List<T> currentArray)
            {
                LeftSon?.GetSortedArray(currentArray);
                currentArray.Add(Value);
                RightSon?.GetSortedArray(currentArray);
            }
        }
        
        #region BinarySort
        public static void BinarySort<T>(T[] array) where T : IComparable
        {
            Node<T> root = new Node<T>();
            root.Value = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                root.AddValueToTheTree(array[i]);
            }
            List<T> sortedArray = new List<T>();
            root.GetSortedArray(sortedArray);
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = sortedArray[i];
            }
        }
        #endregion
    }
}
