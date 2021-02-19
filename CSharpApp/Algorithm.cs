using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpApp
{
    public class Algorithm
    {
        //Maximum and minimum of an array using minimum number of comparisons
        class Pair
        {
            public int min;
            public int max;
        }

        //(Simple Linear Search) 簡單線性搜尋/逐一比較
        //Initialize values of min and max as minimum and maximum of the first two elements respectively.Starting from 3rd, 
        //compare each element with max and min, and change max and min accordingly
        //(i.e., if the element is smaller than min then change min, else if the element is greater than max then change max, else ignore the element)
        static Pair getMinMax(int[] arr, int n)
        {
            Pair minmax = new Pair();
            int i;

            /* If there is only one element 
            then return it as min and max both*/
            if (n == 1)
            {
                minmax.max = arr[0];
                minmax.min = arr[0];
                return minmax;
            }

            /* If there are more than one elements,
            then initialize min and max*/
            if (arr[0] > arr[1])
            {
                minmax.max = arr[0];
                minmax.min = arr[1];
            }
            else
            {
                minmax.max = arr[1];
                minmax.min = arr[0];
            }

            for (i = 2; i < n; i++)
            {
                if (arr[i] > minmax.max)
                {
                    minmax.max = arr[i];
                }
                else if (arr[i] < minmax.min)
                {
                    minmax.min = arr[i];
                }
            }
            return minmax;
        }
        // Driver Code
        public static void Main(String[] args)
        {
            int[] arr = { 1000, 11, 445, 1, 330, 3000 };
            int arr_size = 6;
            Pair minmax = getMinMax(arr, arr_size);
            Console.Write("Minimum element is {0}",
                                       minmax.min);
            Console.Write("\nMaximum element is {0}",
                                         minmax.max);
        }

        //METHOD 2 (Tournament Method)
        //Divide the array into two parts and compare the maximums and minimums of the two parts to get the maximum and the minimum of the whole array.
        static Pair getMinMaxByTournamentMethod(int[] arr, int low, int high)
        {
            Pair minmax = new Pair();
            Pair mml = new Pair();
            Pair mmr = new Pair();
            int mid;

            // If there is only one element 
            if (low == high)
            {
                minmax.max = arr[low];
                minmax.min = arr[low];
                return minmax;
            }

            /* If there are two elements */
            if (high == low + 1)
            {
                if (arr[low] > arr[high])
                {
                    minmax.max = arr[low];
                    minmax.min = arr[high];
                }
                else
                {
                    minmax.max = arr[high];
                    minmax.min = arr[low];
                }
                return minmax;
            }

            /* If there are more than 2 elements */
            mid = (low + high) / 2;
            mml = getMinMaxByTournamentMethod(arr, low, mid);
            mmr = getMinMaxByTournamentMethod(arr, mid + 1, high);

            /* compare minimums of two parts*/
            if (mml.min < mmr.min)
            {
                minmax.min = mml.min;
            }
            else
            {
                minmax.min = mmr.min;
            }

            /* compare maximums of two parts*/
            if (mml.max > mmr.max)
            {
                minmax.max = mml.max;
            }
            else
            {
                minmax.max = mmr.max;
            }

            return minmax;
        }

        /* Driver program to test above function */
        public static void MainByTournamentMethod(String[] args)
        {
            int[] arr = { 1000, 11, 445, 1, 330, 3000 };
            int arr_size = 6;
            Pair minmax = getMinMaxByTournamentMethod(arr, 0, arr_size - 1);
            Console.Write("\nMinimum element is {0}", minmax.min);
            Console.Write("\nMaximum element is {0}", minmax.max);

        }

        //METHOD 3 (Compare in Pairs) 
        //If n is odd then initialize min and max as first element.
        //If n is even then initialize min and max as minimum and maximum of the first two elements respectively.
        //For rest of the elements, pick them in pairs and compare their
        //maximum and minimum with max and min respectively. 
        static Pair getMinMaxByCompareinPairs(int[] arr, int n)
        {
            Pair minmax = new Pair();
            int i;

            /* If array has even number of elements 
            then initialize the first two elements 
            as minimum and maximum */
            if (n % 2 == 0)
            {
                if (arr[0] > arr[1])
                {
                    minmax.max = arr[0];
                    minmax.min = arr[1];
                }
                else
                {
                    minmax.min = arr[0];
                    minmax.max = arr[1];
                }
                i = 2;
            }

            /* set the starting index for loop */
            /* If array has odd number of elements then 
            initialize the first element as minimum and 
            maximum */
            else
            {
                minmax.min = arr[0];
                minmax.max = arr[0];
                i = 1;
                /* set the starting index for loop */
            }

            /* In the while loop, pick elements in pair and 
            compare the pair with max and min so far */
            while (i < n - 1)
            {
                if (arr[i] > arr[i + 1])
                {
                    if (arr[i] > minmax.max)
                    {
                        minmax.max = arr[i];
                    }
                    if (arr[i + 1] < minmax.min)
                    {
                        minmax.min = arr[i + 1];
                    }
                }
                else
                {
                    if (arr[i + 1] > minmax.max)
                    {
                        minmax.max = arr[i + 1];
                    }
                    if (arr[i] < minmax.min)
                    {
                        minmax.min = arr[i];
                    }
                }
                i += 2;

                /* Increment the index by 2 as two 
                elements are processed in loop */
            }
            return minmax;
        }
        // Driver Code
        public static void MainByCompareinPairs(String[] args)
        {
            int[] arr = { 1000, 11, 445, 1, 330, 3000 };
            int arr_size = 6;
            Pair minmax = getMinMaxByCompareinPairs(arr, arr_size);
            Console.Write("Minimum element is {0}",
                                       minmax.min);
            Console.Write("\nMaximum element is {0}",
                                         minmax.max);
        }
    }
}

