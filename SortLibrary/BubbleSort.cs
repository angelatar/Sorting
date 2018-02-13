using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    /// <summary>
    /// Class for Bubble Sort algorithm.
    /// </summary>
    public static class BubbleSort
    {
        /// <summary>
        /// Field for memory size.
        /// </summary>
        private static int sizeOfMemory = 0;

        /// <summary>
        /// Bubble sort implementation.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Sort(int[]  inputArr )
        {
            // Copy given array
            int[] arr = new int[inputArr.Length];
            for (int i = 0; i < inputArr.Length; i++)
                arr[i] = inputArr[i];

            // Calculate memory
            sizeOfMemory = arr.Length * sizeof(int);

            Console.WriteLine("Bubble");

            for (int i = 0; i < arr.Length-1; i++)
                for(int j=i+1;j<arr.Length;j++)
                    if(arr[i]>arr[j]) // Compare 2 elemnts
                    {
                        // Swap 2 elements
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }

            // Return sorted array
            return arr;
        }

        /// <summary>
        /// Returns the allocated memory size of the function.
        /// </summary>
        /// <returns></returns>
        public static int MemoryAllocation()
        {
            return sizeOfMemory;
        }
    }
}
