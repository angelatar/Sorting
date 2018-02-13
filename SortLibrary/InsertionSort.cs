using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    /// <summary>
    /// Class for Insertion Sort algorithm.
    /// </summary>
    public static class InsertionSort
    {
        /// <summary>
        /// Field for memory size.
        /// </summary>
        private static int sizeOfMemory = 0;

        /// <summary>
        /// Insertion sort implementation.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Sort( int[] inputArr)
        {
            // Copy given array
            int[] arr = new int[inputArr.Length];
            for (int i = 0; i < inputArr.Length; i++)
                arr[i] = inputArr[i];

            // Calculate memory
            sizeOfMemory = arr.Length * sizeof(int);

            Console.WriteLine("Insertion");

            for(int i=0;i<arr.Length-1;i++)
                for(int j=i+1;j>0;j--)
                    if(arr[j-1]>arr[j]) // Compare 2 elements
                    {
                        // Swap 2 elements
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
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
