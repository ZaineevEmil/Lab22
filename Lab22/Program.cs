using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22
{

    class Program
    {
        static void Main(string[] args)
        {
            //задача продолжения
            Console.WriteLine("Введите размерность массива");
            int n = Convert.ToInt32(Console.ReadLine());

            Task<int[]> task1 = new Task<int[]>(() => Array(n));
            Task task2 = task1.ContinueWith(Array => SumMas(Array.Result));
            Task task3 = task1.ContinueWith(Array => MaxMas(Array.Result));

            task1.Start();

            Console.ReadKey();  
        }
        static int[] Array(int n)
        {
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;
        }
        static void SumMas(int[] Array)
        {
            int sumMas = 0;
            foreach (int value in Array)
            {
                sumMas += value;
            }
            Console.WriteLine("Сумма всех чисел равна - {0}", sumMas); ;
        }
        static void MaxMas(int[] Array)
        {
            int maxMas = 0;
            foreach (int value in Array)
            {
                if (value >= maxMas)
                {
                    maxMas = value;
                }
            }
            Console.WriteLine("Максимальное число в массиве - {0}", maxMas); ;
        }
    }




    /* 2 вариант
    class Program
    {
        static void Main(string[] args)
        {
            //задача продолжения

            Console.WriteLine("Введите размерность массива");
            int n = Convert.ToInt32(Console.ReadLine());
            ArrayClass arrayClass = new ArrayClass(n);

            //Action action1 = new Action(arrayClass.SumMas);
            //Task task1 = new Task(action1);

            //Action action2 = new Action(arrayClass.MaxMas);
            //Task task2 = new Task(action2);


            Task task1 = new Task(() => arrayClass.SumMas());

            Action action2 = new Action(arrayClass.MaxMas);
            Task task2 = task1.ContinueWith(action2);
            task1.Start();


            Console.ReadKey();
        }
    }
    public class ArrayClass
    {
        int[] array;
        int n;
        public int N
        {
            set
            {
                n = value;
            }
            get
            {
                return n;
            }
        }
        public int[] Array
        {
            set
            {
                Random random = new Random();
                for (int i = 0; i < N; i++)
                {
                    array[i] = random.Next(0, 100);
                }
            }
            get
            {
                return array;
            }
        }
        public ArrayClass (int n=0)
        {
            int N = n;
        }
        public void SumMas()
        {
            int sumMas = 0;
            for (int i = 0; i < N; i++)
            {
                sumMas += Array[i];
            }
            Console.WriteLine("Сумма всех чисел равна - {0}", sumMas); ;
        }
        public void MaxMas()
        {
            int maxMas = 0;
            for (int i = 0; i < N; i++)
            {
                if (Array [i] >= maxMas)
                {
                    maxMas = Array[i];
                }
            } 
            Console.WriteLine("Максимальное число в массиве - {0}", maxMas);
        }
    }
    */






    /*3 вариант
    class Program
    {

        public static void SumMas(object[] Array)
        {
            int sumMas = 0;
            foreach (object value in Array)
            {
                int array = Convert.ToInt32(value);
                sumMas += array;
            }
            Console.WriteLine("Сумма всех чисел равна - {0}", sumMas); ;
        }
        public static void MaxMas(Task task, object[] Array)
        {
            int maxMas = 0;
            foreach     (object value in Array)
            {
                int array = Convert.ToInt32(value);
                if (array >= maxMas)
                {
                    maxMas = array;
                }
            }
            Console.WriteLine("Максимальное число в массиве - {0}", maxMas);
        }

        static void Main(string[] args)
        {
            //задача продолжения
            Console.WriteLine("Введите размерность массива");
            int n = Convert.ToInt32(Console.ReadLine());
            object[] array = new object[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }
            Task task1 = new Task(() => SumMas(array));

            Action<Task, object[]> actionTask = new Action<Task, object[]>(MaxMas);
            Task task2 = task1.ContinueWith(actionTask, array);
            task1.Start();

            Console.ReadKey();
        }
    }
    */
}
