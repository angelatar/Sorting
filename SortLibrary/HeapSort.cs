using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    /// <summary>
    /// Class for Heap Sort algorithm.
    /// </summary>
    public static class HeapSort
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
        /// Heap sort implementation.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Sort(int[] inputArr)
        {
            // Copy given array
            int[] arr = new int[inputArr.Length];
            for (int i = 0; i < inputArr.Length; i++)
                arr[i] = inputArr[i];

            // Calculate memory
            sizeOfMemory += arr.Length * sizeof(int);

            Console.WriteLine("Heap");

            int size = arr.Length;

            // Call main function , with sharing array
            for (int i = (size - 1) / 2; i >= 0; --i)
                Sort(arr,size, i); 

            for (int i=arr.Length-1;i>0;--i)
            {
                // Swap current element with 0 element
                int temp = arr[i]; 
                arr[i] = arr[0];
                arr[0] = temp;
                size--;

                // Call main function
                Sort(arr,size, 0);
            }

            // Return sorted array
            return arr;
        }

        /// <summary>
        /// Heap sort implementation (main function).
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="size"></param>
        /// <param name="i"></param>
        private static void Sort(int[] arr,int size,int i)
        {
            int left = (i + 1) * 2 - 1; 
            int right = (i + 1) * 2; 
            int large = 0;

            if (left < size && arr[left] > arr[i])
                large = left;
            else
                large = i;

            if (right < size && arr[right] > arr[large])
                large = right;

            if(large!=i)
            {
                // Swap 2 elements
                int temp = arr[i];
                arr[i] = arr[large];
                arr[large] = temp;

                // Recursive call
                Sort(arr, size, large);
            }
        }
    }
}
