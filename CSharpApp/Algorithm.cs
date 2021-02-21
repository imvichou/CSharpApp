using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpApp
{
    public class Algorithm
    {
        //Maximum and minimum of an array using minimum number of comparisons
        class Pair
        {
            public int Min;
            public int Max;
        }

        //Find max and min-- 最大或最小為n-1次，找出後再找the other則不同，逐一比較最差

        //(Simple Linear Search) 簡單線性搜尋/逐一比較
        //Initialize values of min and max as minimum and maximum of the first two elements respectively.Starting from 3rd, 
        //compare each element with max and min, and change max and min accordingly
        //(i.e., if the element is smaller than min then change min, else if the element is greater than max then change max, else ignore the element)
        static Pair getMinMaxBySimpleLinearSearch(int[] array)
        {
            Pair minMax = new Pair();
            int i;

            int lengthOfArray = array.Length;

            /* If there is only one element 
            then return it as min and max both*/
            if (lengthOfArray == 1)
            {
                minMax.Max = array[0];
                minMax.Min = array[0];
                return minMax;
            }

            /* If there are more than one elements,
            then initialize min and max*/
            if (array[0] > array[1])
            {
                minMax.Max = array[0];
                minMax.Min = array[1];
            }
            else
            {
                minMax.Max = array[1];
                minMax.Min = array[0];
            }

            for (i = 2; i < lengthOfArray; i++)
            {
                if (array[i] > minMax.Max)
                {
                    minMax.Max = array[i];
                }
                else if (array[i] < minMax.Min)
                {
                    minMax.Min = array[i];
                }
            }

            return minMax;
        }
        public static void MainBySimpleLinearSearch(int[] array)
        {
            Pair minmax = getMinMaxBySimpleLinearSearch(array);
            Debug.WriteLine(string.Format("Minimum element is {0}", minmax.Min));
            Debug.WriteLine(string.Format("Maximum element is {0}", minmax.Max));
        }

        //METHOD 2 (Tournament Method) 對半比較
        //Divide the array into two parts and compare the maximums and minimums of the two parts to get the maximum and the minimum of the whole array.
        static Pair getMinMaxByTournamentMethod(int[] array, int startIndex, int endIndex)
        {
            Pair minMax = new Pair();
            Pair minMaxLeft = new Pair();
            Pair minMaxRight = new Pair();
            int mid;

            // If there is only one element 
            if (startIndex == endIndex)
            {
                minMax.Max = array[startIndex];
                minMax.Min = array[startIndex];
                
                return minMax;
            }

            /* If there are two elements */
            if (startIndex == endIndex + 1)
            {
                if (array[startIndex] > array[endIndex])
                {
                    minMax.Max = array[startIndex];
                    minMax.Min = array[endIndex];
                }
                else
                {
                    minMax.Max = array[endIndex];
                    minMax.Min = array[startIndex];
                }
                
                return minMax;
            }

            /* If there are more than 2 elements */
            mid = (startIndex + endIndex) / 2;
            minMaxLeft = getMinMaxByTournamentMethod(array, startIndex, mid);
            minMaxRight = getMinMaxByTournamentMethod(array, mid + 1, endIndex);

            /* compare minimums of two parts*/
            if (minMaxLeft.Min < minMaxRight.Min)
            {
                minMax.Min = minMaxLeft.Min;
            }
            else
            {
                minMax.Min = minMaxRight.Min;
            }

            /* compare maximums of two parts*/
            if (minMaxLeft.Max > minMaxRight.Max)
            {
                minMax.Max = minMaxLeft.Max;
            }
            else
            {
                minMax.Max = minMaxRight.Max;
            }

            return minMax;
        }
        public static void MainByTournamentMethod(int[] array)
        {
            Pair minmax = getMinMaxByTournamentMethod(array, 0, array.Length - 1);
            Debug.WriteLine(string.Format("Minimum element is {0}", minmax.Min));
            Debug.WriteLine(string.Format("Maximum element is {0}", minmax.Max));
        }

        //METHOD 3 (Compare in Pairs) 兩兩比較
        //If n is odd then initialize min and max as first element.
        //If n is even then initialize min and max as minimum and maximum of the first two elements respectively.
        //For rest of the elements, pick them in pairs and compare their
        //maximum and minimum with max and min respectively. 
        static Pair getMinMaxByCompareinPairs(int[] array)
        {
            Pair minmax = new Pair();
            var length = array.Length;
            int startIndex;

            /* If array has even number of elements 
            then initialize the first two elements 
            as minimum and maximum */
            if (length % 2 == 0)
            {
                if (array[0] > array[1])
                {
                    minmax.Max = array[0];
                    minmax.Min = array[1];
                }
                else
                {
                    minmax.Min = array[0];
                    minmax.Max = array[1];
                }

                startIndex = 2;
            }

            /* set the starting index for loop */
            /* If array has odd number of elements then 
            initialize the first element as minimum and 
            maximum */
            else
            {
                minmax.Min = array[0];
                minmax.Max = array[0];
                startIndex = 1;
                /* set the starting index for loop */
            }

            /* In the while loop, pick elements in pair and 
            compare the pair with max and min so far */
            while (startIndex < length - 1)
            {
                if (array[startIndex] > array[startIndex + 1])
                {
                    if (array[startIndex] > minmax.Max)
                    {
                        minmax.Max = array[startIndex];
                    }
                    if (array[startIndex + 1] < minmax.Min)
                    {
                        minmax.Min = array[startIndex + 1];
                    }
                }
                else
                {
                    if (array[startIndex + 1] > minmax.Max)
                    {
                        minmax.Max = array[startIndex + 1];
                    }
                    if (array[startIndex] < minmax.Min)
                    {
                        minmax.Min = array[startIndex];
                    }
                }

                startIndex += 2;

                /* Increment the index by 2 as two 
                elements are processed in loop */
            }
            return minmax;
        }
        public static void MainByCompareinPairs(int[] array)
        {
            Pair minmax = getMinMaxByCompareinPairs(array);
            Debug.WriteLine("Minimum element is {0}", minmax.Min);
            Debug.WriteLine("Maximum element is {0}", minmax.Max);
        }


        //sort--

        //selection sort

        //insertion sort

        //bubble sort

        //quick sort

        //search--

        //sequential search
        //binary search

        //dynamic programming
    }
}

