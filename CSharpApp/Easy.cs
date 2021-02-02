using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpApp
{
    public class Easy
    {
        //Easy01
        public int[] TwoSum(int[] nums, int target)
        {
            var answers = new List<Array>();
            int num1;
            int num2;

            for (int i = 0; i < nums.Count(); i++)
            {
                num1 = nums[i];

                for (int j = i + 1; j < nums.Count(); j++)
                {
                    num2 = nums[j];

                    if (i > j)
                    {
                        break;
                    }

                    if ((num1 + num2) == target)
                    {
                        var array = new int[2] { i, j };

                        answers.Add(array);
                    }
                }
            }

            return (int[])answers[0];
        }

        //Easy02
        public int ReverseInteger(int x)
        {
            if (x > Int32.MaxValue || x < Int32.MinValue)
            {
                return 0;
            }

            if(!Int32.TryParse(Math.Abs((double)x).ToString(), out int none1))
            {
                return 0;
            }

            var absX = Math.Abs(x);

            var exp = Math.Log10(absX);

            var ceilingExp = (int)Math.Floor(exp);

            var celingExpDictionary = new Dictionary<int, int>();

            for (int i = ceilingExp; i >= 0; i--)
            {
                var remainder = 0;

                var quotient = 0;

                var substractAmount = 0;

                if (celingExpDictionary.Count == 0)
                {
                    quotient = Math.DivRem(absX, (int)Math.Pow(10, i), out remainder);
                }
                else
                {
                    for (int j = ceilingExp; j > i; j--)
                    {
                        substractAmount += celingExpDictionary[j] * (int)Math.Pow(10, j);
                    }
                    
                    quotient = Math.DivRem(absX - substractAmount, (int)Math.Pow(10, i), out remainder);
                }

                celingExpDictionary.Add(i, quotient);
            }

            var keys = celingExpDictionary.Keys.ToList();

            var reverseKeys = celingExpDictionary.Keys.ToList();

            reverseKeys.Reverse();

            var result = 0;

            var testResult = 0.0;

            for (int i = 0; i < celingExpDictionary.Keys.Count; i++)
            {
                testResult += Math.Pow(10, keys[i]) * celingExpDictionary[reverseKeys[i]];

                if (!Int32.TryParse(testResult.ToString(), out int none2))
                {
                    return 0;
                }

                result += (int)Math.Pow(10, keys[i]) * celingExpDictionary[reverseKeys[i]];
            }

            if (x < 0)
            {
                result = result * (-1);
            }

            return result;        
        }

        //Easy03
        public bool IsPalindrome(int x)
        {
            var stringList = new List<string>();

            foreach (var item in x.ToString().ToList())
            {
                stringList.Add(item.ToString());
            }

            var reverseStringList = new List<string>();

            foreach (var item in stringList)
            {
                reverseStringList.Add(item);
            }

            reverseStringList.Reverse();

            for (int i = 0; i < stringList.Count; i++)
            {
                if(stringList[i] != reverseStringList[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
