using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    /// <summary>
    /// Class for Merge Sort algorithm.
    /// </summary>
    public static class MergeSort
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
        /// Merge sort implementation.
        /// </summary>
        /// <returns></returns>
        public static int[] Sort(int[] inputArr)
        {
            // Copy given array
            int[] arr = new int[inputArr.Length];
            for (int i = 0; i < inputArr.Length; i++)
                arr[i] = inputArr[i];

            // Calculate memory
            sizeOfMemory = arr.Length * sizeof(int);

            Console.WriteLine("Merge");

            // Call main function and return sorted array
            return Sort(arr, 0, arr.Length);
        }

        /// <summary>
        /// Merge sort implementation (main function0).
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int[] Sort(int[] arr, int left, int right)
        {
            if (right - left < 2)
            {
                // Calculate memory
                sizeOfMemory += sizeof(int);

                // Return array with 1 element
                return new int[] { arr[left] }; 
            }

            // Index of middle element
            int middle = left + ((right - left) / 2); 

            // Function's recursive call, with sharing array
            int[] l = Sort(arr, left, middle);
            // Calculate memory
            sizeOfMemory += l.Length * sizeof(int);

            // Function's recursive call, with sharing array
            int[] r = Sort(arr, middle, right);
            // Calculate memory
            sizeOfMemory += r.Length * sizeof(int);

            // Create new array for return
            int[] result = new int[l.Length + r.Length];
            // Calculate memory
            sizeOfMemory += result.Length * sizeof(int);

            int iL = 0, iR = 0, i = 0;
            // Loop for merging shared parts
            for (; iL < l.Length && iR < r.Length; i++)
            {
                if (l[iL] < r[iR])
                {
                    result[i] = l[iL];
                    iL++;
                }
                else
                {
                    result[i] = r[iR];
                    iR++;
                }                
            }

            // If one of arrays is bigger, then add its elements
            while (iL < l.Length)
                result[i++] = l[iL++];
            while (iR < r.Length)
                result[i++] = r[iR++];

            // Return result
            return result;
        }

    }
}
