using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortLibrary;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size : ");
            int size = int.Parse(Console.ReadLine());

            // Generate array with random elements
            int[] arr =Generator(size);

            // Array for sorting
            int[] changedArr = new int[arr.Length];

            // Array for calculating time
            TimeSpan[] delta = new TimeSpan[5];

            Print(arr);

            Console.Write("Select which algorithm you want to perform :\n1-Insertion sort\n" +
                "2-Bubble sort\n3-Quicksort\n4-Heap sort\n5-Merge sort\n6-All\nEnter number(s) : ");

            string n = Console.ReadLine();
            string[] num;

            // Exploration of input string
            if (n.Contains(','))
                num = n.Split(',');
            else if (n.Contains('-'))
            {
                num = new string[int.Parse((n[n.Length - 1]).ToString()) - int.Parse(n[0].ToString())+1];
                int t = 0;
                for (int i = int.Parse(n[0].ToString()); i <= int.Parse((n[n.Length - 1]).ToString()); i++)
                    num[t++]= i.ToString();
            }
            else
                num = new string[] { n };

            // Call needed function or functions
            for(int i=0;i<num.Length;i++)
            {
                switch (num[i])
                {
                    case "1": changedArr = InsertionSort.Sort(arr); Print(changedArr); Console.WriteLine("Memory = " + InsertionSort.MemoryAllocation() + " byte"); break;
                    case "2": changedArr = BubbleSort.Sort(arr); Print(changedArr); Console.WriteLine("Memory = " + BubbleSort.MemoryAllocation() + " byte"); break;
                    case "3": changedArr = QuickSort.Sort(arr); Print(changedArr); Console.WriteLine("Memory = " + QuickSort.MemoryAllocation() + " byte"); break;
                    case "4": changedArr = HeapSort.Sort(arr); Print(changedArr); Console.WriteLine("Memory = " + HeapSort.MemoryAllocation() + " byte"); break;
                    case "5": changedArr = MergeSort.Sort(arr); Print(changedArr); Console.WriteLine("Memory = " + MergeSort.MemoryAllocation() + " byte"); break;
                    case "6":
                        DateTime inT1 = DateTime.Now;
                        changedArr = InsertionSort.Sort(arr); Print(changedArr);
                        DateTime inT2 = DateTime.Now;  delta[0] = inT2 - inT1;
                        Console.WriteLine("Memory = " + InsertionSort.MemoryAllocation() + " byte");

                        DateTime buT1 = DateTime.Now;
                        changedArr = BubbleSort.Sort(arr); Print(changedArr);
                        DateTime buT2 = DateTime.Now;  delta[1] = buT2 - buT1;
                        Console.WriteLine("Memory = " + BubbleSort.MemoryAllocation() + " byte");

                        DateTime quT1 = DateTime.Now;
                        changedArr = QuickSort.Sort(arr); Print(changedArr);
                        DateTime quT2 = DateTime.Now;  delta[2] = quT2 - quT1;
                        Console.WriteLine("Memory = " + QuickSort.MemoryAllocation() + " byte");

                        DateTime heT1 = DateTime.Now;
                        changedArr = HeapSort.Sort(arr); Print(changedArr);
                        DateTime heT2 = DateTime.Now;  delta[3] = heT2 - heT1;
                        Console.WriteLine("Memory = " + HeapSort.MemoryAllocation() + " byte");

                        DateTime meT1 = DateTime.Now;
                        changedArr = MergeSort.Sort(arr); Print(changedArr);
                        DateTime meT2 = DateTime.Now;  delta[4] = meT2 - meT1;
                        Console.WriteLine("Memory = " + MergeSort.MemoryAllocation() + " byte");

                        for (int j = 0; j < delta.Length; j++)
                            if (delta[j] == delta.Min())
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(delta[j]);
                                Console.ResetColor();
                            }
                            else
                                Console.WriteLine(delta[j]);

                        break;
                    default: Console.WriteLine("Incorrect number!"); break;
                }
            }
        }
        /// <summary>
        /// Generate array with random numbers.
        /// </summary>
        /// <param name="s">Size of array</param>
        /// <returns></returns>
        static int[] Generator(int s)
        {
            Random r = new Random();
            int[] arr = new int[s];
            for (int i = 0; i < s; i++)
                arr[i] = r.Next() % 100;
            return arr;
        }

        /// <summary>
        /// Print array.
        /// </summary>
        /// <param name="arr"></param>
        static void Print(int[] arr)
        {
            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
