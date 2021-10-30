using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_22
{
    class Program
    {
        static int[] array;
        static int Sum()
        {
            int a = 0;
            for (int i = 0; i < array.Length; i++)
            {
                a += array[i];
            }
            return a;
        }
        static int Max(Task t)
        {
            int b = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (b < array[i])
                {
                    b = array[i];
                }
            }
            return b;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива (X элементов) - ");
            int x = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            array = new int[x];
            for (int i = 0; i < array.Length; i++)
            {
                array [i] = random.Next(0, 10);
                Console.Write($"{array[i]} ");
                Thread.Sleep(100);
            }
            Console.WriteLine();

            Func<int> func = new Func<int>(Sum);
            Task<int> task1 = new Task<int>(func);

            Func<Task, int> funcTask = new Func<Task, int>(Max);
            Task<int> task2 = task1.ContinueWith(funcTask);

            task1.Start();
            Console.WriteLine(task1.Result);
            Console.WriteLine(task2.Result);

            Console.ReadKey();
        }
    }
}
