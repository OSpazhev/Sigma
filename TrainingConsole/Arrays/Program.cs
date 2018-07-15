using Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        private const int Size = 20;
        private static Random Random { get; } = new Random();

        private static void Task4_1(int[] array)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": ");

            Dictionary<int, int> numberOfUsage = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.Next(array.Length);
                if (numberOfUsage.ContainsKey(array[i]))
                {
                    numberOfUsage[array[i]]++;
                }
                else
                {
                    numberOfUsage.Add(array[i], 1);
                }
            }

            List<int> resultArray = new List<int>();
            foreach (int element in array)
            {
                if (numberOfUsage[element] < 3)
                {
                    resultArray.Add(element);
                }
            }

            Console.Write("Result array: ");
            Tools.OutputArray(resultArray.ToArray());
            Console.WriteLine();
        }

        private static void Task4_2(int[] array)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": ");

            int[] resultArray = new int[array.Length];
            array.CopyTo(resultArray, 0); 
            int maxElement = Int32.MinValue;
            int maxElementIndex = -1;
            for(int i = 0; i < resultArray.Length; i++)
            {
                if (resultArray[i] % 2 == 1 && maxElement < resultArray[i])
                {
                    maxElement = resultArray[i];
                    maxElementIndex = i;
                }
            }
            if (maxElement == Int32.MinValue)
            {
                Console.WriteLine("There are no odd elements");
                Console.WriteLine();
                return;
            }
            for (int i = 0; i < 3; i++)
            {
                if (maxElementIndex == resultArray.Length - 1)
                    break;
                int temp = resultArray[maxElementIndex + 1];
                for (int j = maxElementIndex + 1; j < resultArray.Length - 1; j++)
                {
                    resultArray[j] = resultArray[j + 1];
                }
                resultArray[resultArray.Length - 1] = temp;
            }
            if (maxElementIndex != 0)
            {
                int temp = resultArray[maxElementIndex - 1];
                for (int j = maxElementIndex - 1; j > 0; j--)
                {
                    resultArray[j] = resultArray[j - 1];
                }
                resultArray[0] = temp;
            }
            Console.WriteLine("Max element: " + maxElement + ", Its index: " + maxElementIndex);
            Console.Write("Result array: ");
            Tools.OutputArray(resultArray.ToArray());
            Console.WriteLine();
        }

        private static void Task4_3(int[] array)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": ");

            int sum = 0; 
            foreach(int item in array)
            {
                if (item < 0)
                {
                    sum += item;
                }
            }
            Console.WriteLine("Sum of negative items: " + sum);
            Console.WriteLine();
        }

        private static void Task4_4(int[] array)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": ");

            long product = 1;
            for (int i = 0; i < array.Length; i += 2)
            {
                product *= array[i];
            }
            Console.WriteLine("Product of items at the odd possitions: " + product);
            Console.WriteLine();
        }

        private static void Task4_5(int[] array)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": ");

            int sum = 0;
            bool flag = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    if (flag)
                    {
                        Console.WriteLine("Sum between two zeros: " + sum);
                        Console.WriteLine();
                        return;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    sum += Convert.ToInt32(flag) * array[i];
                }
            }
            Console.WriteLine(0);
            Console.WriteLine();
        }

        private static void Task4_6(int[] array)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": ");
            var resultArray = array;
            int maxItem = Int32.MinValue;
            for (int i = 0; i < resultArray.Length; i++)
            {
                maxItem = Math.Max(maxItem, array[i]);
            }
            Console.WriteLine("Max item: " + maxItem);
            Console.WriteLine();
        }

        private static void Task4_7(int[] array)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": ");

            var resultArray = array;
            int minEvenItem = Int32.MaxValue;
            for (int i = 0; i < resultArray.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    minEvenItem = Math.Min(minEvenItem, array[i]);
                }
            }

            if (minEvenItem == Int32.MaxValue)
            {
                minEvenItem = array[0];
            }

            Console.WriteLine("Min even or first item: " + minEvenItem);
            Console.WriteLine();
        }

        private static void Task4_8(int[] array)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": ");

            Console.Write("Result array: ");
            foreach(int item in array)
            {
                if (item == 0)
                {
                    Console.Write("0, ");
                }
            }

            foreach (int item in array)
            {
                if (item != 0)
                {
                    Console.Write(item + ", ");
                }
            }
            Console.WriteLine();
        }

        private static void Task4_9(int[] array)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": ");

            int maxItem = Int32.MinValue;
            int maxItemIndex = -1;
            int minItem = Int32.MaxValue;
            int minItemIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (maxItem <= array[i])
                {
                    maxItem = array[i];
                    maxItemIndex = i;
                }
                if (minItem >= array[i])
                {
                    minItem = array[i];
                    minItemIndex = i;
                }
            }

            Console.WriteLine("Max item index + min item index = " + (maxItemIndex + minItemIndex));
            Console.WriteLine();
        }

        private static List<int> GetSubsequence(int[] array, Dictionary<int, int>[] possibleSums, int curIndex, int curSum)
        {
            int sum = new Random().Next(array.Length);
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": needed sum: " + sum);

            if (possibleSums[curIndex][curSum] == int.MinValue)
                return new List<int> { array[curIndex - 1] };
            else
            {
                var result = GetSubsequence(array, possibleSums, Math.Abs(possibleSums[curIndex][curSum]), curSum - array[curIndex - 1]);
                result.Add(array[curIndex - 1]);
                return result;
            }
        }

        public static void Task4_10(int[] array)
        {
            int sum = new Random().Next(array.Length * 5);
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": needed sum: " + sum);

            Dictionary<int, int>[] possibleSums = new Dictionary<int, int>[array.Length + 1];
            for (int i = 0; i <= array.Length; i++)
                possibleSums[i] = new Dictionary<int, int>();
            possibleSums[1][array[0]] = int.MinValue;
            for (int i = 2; i <= array.Length; i++)
            {
                possibleSums[i][array[i - 1]] = int.MinValue;
                foreach (var possibleSum in possibleSums[i - 1])
                {
                    if (possibleSum.Value < 0)
                    {
                        possibleSums[i][possibleSum.Key] = i - 1;
                    }
                    else
                    {
                        possibleSums[i][possibleSum.Key] = possibleSum.Value;
                    }
                    if (possibleSum.Value < 0)
                        possibleSums[i][possibleSum.Key + array[i - 1]] = -i + 1;
                    else
                        possibleSums[i][possibleSum.Key + array[i - 1]] = -possibleSum.Value;

                }
                if (possibleSums[i].ContainsKey(sum))
                {
                    Console.Write($"Subsequence with sum {sum}: ");
                    Tools.OutputArray(GetSubsequence(array, possibleSums, i, sum).ToArray());
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine("There is no a subsequence with such sum.");
            Console.WriteLine();
        }

        private static int BinarySearch(int[] array, int left, int right, int aim)
        {
            if (left == right)
            {
                if (aim == array[left])
                    return left;
                else
                    return -1;
            }
            else if (right < left)
            {
                return -1;
            }

            int middle = (left + right) / 2;
            if (aim <= array[middle])
            {
                return BinarySearch(array, left, middle, aim);
            }
            else
            {
                return BinarySearch(array, middle + 1, right, aim);
            }
        }

        public static void Task4_11(int[] array)
        {
            int aim = new Random().Next(array.Length);
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ": aim number: " + aim);

            var result = BinarySearch(array, 0, array.Length - 1, aim);
            if (result == -1)
            {
                Console.WriteLine("There is no such number.");
            }
            else
            {
                Console.WriteLine($"Possition of the aim: {result}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            
            int[] array = Tools.CreateUnsortedArray(Size);

            Console.Write("Initial array: ");
            Tools.OutputArray(array);

            Task4_1(array);
            Task4_2(array);
            Task4_3(array);
            Task4_4(array);
            Task4_5(array);
            Task4_6(array);
            Task4_7(array);
            Task4_8(array);
            Task4_9(array);
            Task4_10(array);
            Sorts.Sorts.MergeSort(array);
            Console.Write("Sorted array: ");
            Tools.OutputArray(array);
            Task4_11(array);
        }
    }
}
