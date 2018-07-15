using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTasks
{
    public static class Utils
    {
        public static void OutputResult(string methodName, params object[] args)
        {
            Console.Write($"{methodName} answer: ");
            OutputArray(args);
        }

        public static void OutputResult(string methodName, int[] args)
        {
            Console.Write($"{methodName} answer: ");
            OutputArray(args);
        }
        public static void OutputArray(Array array)
        {
            foreach(var element in array)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        public static bool IsSuchDigitNumber(int value, int DigitsNumber)
        {
            if (ParseDigits(value).Length == DigitsNumber)
            {
                return true;
            }
            else
            {
                Console.WriteLine("It's not necessary number");
                return false;
            }
        }

        public static bool IsAllDigitsDifferent(int value)
        {
            return IsAllDigitsDifferent(ParseDigits(value));
        }

        public static bool IsAllDigitsDifferent(byte[] digits)
        {
            return digits.Distinct().Count() == digits.Length;
        }

        public static int[] GenerateAllPermutations(int value)
        {
            return GenerateAllPermutations(ParseDigits(value));
        }

        public static int[] GenerateAllPermutations(byte[] digits)
        {
            var result = new List<int>();
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] < 10)
                {
                    byte temp = digits[i];
                    digits[i] = 10;
                    var tempResult = GenerateAllPermutations(digits).ToList();
                    digits[i] = temp;
                    if (tempResult.Count == 0)
                    {
                        tempResult.Add(temp);
                    }
                    else
                    {
                        for (int j = 0; j < tempResult.Count; j++)
                        {
                            tempResult[j] = tempResult[j] * 10 + temp;
                        }
                    }
                    result.AddRange(tempResult);
                }
            }
            return result.ToArray<int>();
        }

        public static byte[] ParseDigits(int value)
        {
            List<byte> digits = new List<byte>();
            while (value > 0)
            {
                digits.Add((byte)(value % 10));
                value /= 10;
            }
            return digits.ToArray<byte>();
        }

        public static int GetSum(int value)
        {
            return GetSum(ParseDigits(value));
        }

        public static int GetMult(int value)
        {
            return GetMult(ParseDigits(value));
        }

        public static int GetSum(byte[] digits)
        {
            int result = 0;
            foreach(var digit in digits)
            {
                result += digit;
            }
            return result;
        }

        public static int GetMult(byte[] digits)
        {
            int result = 1;
            foreach (var digit in digits)
            {
                result *= digit;
            }
            return result;
        }

        public static int GetDigitsPermutation(int value, params byte[] newOrder)
        {
            return GetDigitsPermutation(ParseDigits(value), newOrder);
        }

        public static int GetDigitsPermutation(byte[] digits, params byte[] newOrder)
        {
            int result = 0;
            foreach(byte possition in newOrder)
            {
                result *= 10;
                result += digits[possition];
            }
            return result;
        }
    }
}
