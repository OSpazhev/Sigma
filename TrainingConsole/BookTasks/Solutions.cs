using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTasks
{
    public static class Solutions
    {
        public enum TaskPart { а, б, в, г, д, е, ж, з }

        public static void Task1_24(double value, TaskPart taskPart)
        {
            Func<double, double>[] funcArray = new Func<double, double>[2];
            funcArray[(int)TaskPart.а] = a => Math.Sqrt((2 * a + Math.Sin(Math.Abs(3 * a))) / 3.56);
            funcArray[(int)TaskPart.б] = x => Math.Sin((3.2 + Math.Sqrt(1 + x)) / Math.Abs(5 * x));

            switch(taskPart)
            {
                case TaskPart.а:
                case TaskPart.б:
                    Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name + taskPart, funcArray[(int)taskPart](value));
                    break;
                default:
                    Console.WriteLine("Task has no such part");
                    return;
            }
        }

        public static void Task2_12(int value, TaskPart taskPart)
        {
            if (Utils.IsSuchDigitNumber(value, 3))
            {
                Func<int, int>[] funcArray = new Func<int, int>[4];
                funcArray[(int)TaskPart.а] = n => Utils.GetDigitsPermutation(n, 0);
                funcArray[(int)TaskPart.б] = n => Utils.GetDigitsPermutation(n, 1);
                funcArray[(int)TaskPart.в] = n => Utils.GetSum(n);
                funcArray[(int)TaskPart.г] = n => Utils.GetMult(n);

                switch (taskPart)
                {
                    case TaskPart.а:
                    case TaskPart.б:
                    case TaskPart.в:
                    case TaskPart.г:
                        Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name + taskPart, funcArray[(int)taskPart](value));
                        break;
                    default:
                        Console.WriteLine("Task has no such part");
                        break;
                }
            }
        }

        public static void Task2_13(int value)
        {
            if (Utils.IsSuchDigitNumber(value, 3))
            {
                Func<int, int> func = n => Utils.GetDigitsPermutation(n, 0, 1, 2); 
                Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name, func(value));
            }
        }

        public static void Task2_14(int value)
        {
            if (Utils.IsSuchDigitNumber(value, 3))
            {
                Func<int, int> func = n => Utils.GetDigitsPermutation(n, 1, 0, 2);
                Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name, func(value));
            }
        }

        public static void Task2_15(int value)
        {
            if (Utils.IsSuchDigitNumber(value, 3))
            {
                Func<int, int> func = n => Utils.GetDigitsPermutation(n, 0, 2, 1);
                Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name, func(value));
            }
        }

        public static void Task2_16(int value)
        {
            if (Utils.IsSuchDigitNumber(value, 3))
            {
                Func<int, int> func = n => Utils.GetDigitsPermutation(n, 1, 2, 0);
                Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name, func(value));
            }
        }

        public static void Task2_17(int value)
        {
            if (Utils.IsSuchDigitNumber(value, 3))
            {
                Func<int, int> func = n => Utils.GetDigitsPermutation(n, 2, 0, 1);
                Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name, func(value));
            }
        }

        public static void Task2_18(int value)
        {
            if (Utils.IsSuchDigitNumber(value, 3))
            {
                if (Utils.IsAllDigitsDifferent(value))
                {
                    Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name, Utils.GenerateAllVariants(value));
                }
            }
        }

        public static void Task2_19(int value, TaskPart taskPart)
        {
            if (Utils.IsSuchDigitNumber(value, 4))
            {
                Func<int, int>[] funcArray = new Func<int, int>[2];
                funcArray[(int)TaskPart.а] = n => Utils.GetSum(n);
                funcArray[(int)TaskPart.б] = n => Utils.GetMult(n);

                switch (taskPart)
                {
                    case TaskPart.а:
                    case TaskPart.б:
                        Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name + taskPart, funcArray[(int)taskPart](value));
                        break;
                    default:
                        Console.WriteLine("Task has no such part");
                        return;
                }
            }
        }

        public static void Task2_20(int value, TaskPart taskPart)
        {
            if (Utils.IsSuchDigitNumber(value, 4))
            {
                var digits = Utils.ParseDigits(value);
                Func<int, int>[] funcArray = new Func<int, int>[4];
                funcArray[(int)TaskPart.а] = n => Utils.GetDigitsPermutation(n, 0, 1, 2, 3);
                funcArray[(int)TaskPart.б] = n => Utils.GetDigitsPermutation(n, 2, 3, 0, 1);
                funcArray[(int)TaskPart.в] = n => Utils.GetDigitsPermutation(n, 3, 1, 2, 0);
                funcArray[(int)TaskPart.г] = n => Utils.GetDigitsPermutation(n, 1, 0, 3, 2);

                switch (taskPart)
                {
                    case TaskPart.а:
                    case TaskPart.б:
                    case TaskPart.в:
                    case TaskPart.г:
                        Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name + taskPart, funcArray[(int)taskPart](value));
                        break;
                    default:
                        Console.WriteLine("Task has no such part");
                        break;
                }
            }
        }

        public static void Task2_21(int value, TaskPart taskPart)
        {
            if (value > 9)
            {
                Func<int, int>[] funcArray = new Func<int, int>[4];
                funcArray[(int)TaskPart.а] = n => Utils.GetDigitsPermutation(n, 0);
                funcArray[(int)TaskPart.б] = n => Utils.GetDigitsPermutation(n, 1);

                switch (taskPart)
                {
                    case TaskPart.а:
                    case TaskPart.б:
                        Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name + taskPart, funcArray[(int)taskPart](value));
                        break;
                    default:
                        Console.WriteLine("Task has no such part");
                        return;
                }
            }
        }

        public static void Task2_22(int value, TaskPart taskPart)
        {
            if (value > 9)
            {
                Func<int, int>[] funcArray = new Func<int, int>[4];
                funcArray[(int)TaskPart.а] = n => Utils.GetDigitsPermutation(n, 1);
                funcArray[(int)TaskPart.б] = n => Utils.GetDigitsPermutation(n, 2);

                switch (taskPart)
                {
                    case TaskPart.а:
                    case TaskPart.б:
                        Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name + taskPart, funcArray[(int)taskPart](value));
                        break;
                    default:
                        Console.WriteLine("Task has no such part");
                        return;
                }
            }
        }

        public static void Task2_23(int value, TaskPart taskPart)
        {
            if (value > 9)
            {
                Func<int, int>[] funcArray = new Func<int, int>[4];
                funcArray[(int)TaskPart.а] = n => Utils.GetDigitsPermutation(n, 2);
                funcArray[(int)TaskPart.б] = n => Utils.GetDigitsPermutation(n, 3);

                switch (taskPart)
                {
                    case TaskPart.а:
                    case TaskPart.б:
                        Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name + taskPart, funcArray[(int)taskPart](value));
                        break;
                    default:
                        Console.WriteLine("Task has no such part");
                        return;
                }
            }
        }

        public static void Task3_32(double x, double y, TaskPart taskPart)
        {
            Func<double, double, bool>[] funcArray = new Func<double, double, bool>[8];
            funcArray[(int)TaskPart.а] = (x1, y1) => (x1 <= -2 && 1 <= y1);
            funcArray[(int)TaskPart.б] = (x1, y1) => (-2 <= y1 && y1 <= 1.5);
            funcArray[(int)TaskPart.в] = (x1, y1) => (1 <= x1 && x1 <= 2 && y1 <= 4);
            funcArray[(int)TaskPart.г] = (x1, y1) => (1 <= x1 && 2 <= y1 && y1 <= 4);
            funcArray[(int)TaskPart.д] = (x1, y1) => (2 <= x1 && 0 <= y1 || 1 <= x1 && y1 <= -1);
            funcArray[(int)TaskPart.е] = (x1, y1) => (2 <= x1 && (1 <= y1 || y1 <= -1.5));
            funcArray[(int)TaskPart.ж] = (x1, y1) => (1 <= x1 && x1 <= 3 && -2 <= y1 && y1 <= -1);
            funcArray[(int)TaskPart.з] = (x1, y1) => (x >= 2 || 0.5 <= y1 && y1 <= 1.5);

            switch (taskPart)
            {
                case TaskPart.а:
                case TaskPart.б:
                case TaskPart.в:
                case TaskPart.г:
                case TaskPart.д:
                case TaskPart.е:
                case TaskPart.ж:
                case TaskPart.з:
                    Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name + taskPart, funcArray[(int)taskPart](x, y));
                    break;
                default:
                    Console.WriteLine("Task has no such part");
                    return;
            }
        }

        public static void Task8_3г()
        {
            for(int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 6 - i; j++)
                {
                    Console.Write($"{(i * 5),-2} ");
                }
                Console.WriteLine();
            }
        }

        public static void Task8_8()
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    Console.Write($"{j} x {i} = {(i * j),-5}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public static void Task8_36()
        {
            List<int> answer = new List<int>();
            for (int i = 1; i < 100000; i++)
            {
                int curSum = 1;
                for (int j = 2; j <= Math.Floor(Math.Sqrt(i)) + 1; j++)
                {
                    if (i % j == 0 && j <= i / j)
                    {
                        curSum += j;
                        if (i / j != j)
                        {
                            curSum += i / j;
                        }
                    }
                }
                if (curSum == i)
                {
                    answer.Add(i);
                }
            }
            Utils.OutputResult(System.Reflection.MethodBase.GetCurrentMethod().Name, answer.ToArray());
        }
    }
}
