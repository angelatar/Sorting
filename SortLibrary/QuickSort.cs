using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    /// <summary>
    /// Class for Quick Sort algorithm.
    /// </summary>
    public static class QuickSort
    {
        /// <summary>
        /// Field for memory size.
        /// </summary>
        private static int sizeOfMemory = 0;

        /// <summary>
        /// Returns the allocated memory size of the function.
        /// </summary>
        /// <returns></returns>
        public static int MemoryAllocation()
        {
            return sizeOfMemory;
        }

        /// <summary>
        /// Quick sort implementation.
        /// </summary>
        /// <returns></returns>
        public static int[] Sort(int[] inputArr)
        {
            // Copy given array
            int[] arr = new int[inputArr.Length];
            for (int i = 0; i < inputArr.Length; i++)
                arr[i] = inputArr[i];

            // Calculate memory
            sizeOfMemory += arr.Length * sizeof(int);

            Console.WriteLine("Quick");

            // Call main function
            Sort(arr, 0, arr.Length - 1);

            // Return sorted array
            return arr;
        }

        /// <summary>
        /// Quick sort implementation (main function).
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void Sort(int[] arr,int left,int right)
        {
            int i = left, j = right;
            int mid = arr[(left + right) / 2];

            while(i<=j)
            {
                // Get bigger element then mid in first part
                while (arr[i] < mid)
                    i++;

                // Get smaller element then mid in second part 
                while (arr[j] > mid)
                    j--;

                if(i<=j)
                {
                    // Swap elements
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    // Change indexes
                    i++;
                    j--;
                }
            }

            // Function's recursive call, with sharing
            if (left < j)
                Sort(arr, left, j);

            // Function's recursive call, with sharing
            if (i < right)
                Sort(arr, i, right);
        }
    }
}
