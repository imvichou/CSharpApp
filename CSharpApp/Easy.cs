using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpApp
{
    public class Easy
    {
        //1. Two Sum
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

        //7. Reverse Integer
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

        //9. Palindrome Number
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

        //13. Roman to Integer
        public int RomanToInt(string s)
        {
            s = s.Replace("IV", "IIII");
            s = s.Replace("IX", "VIIII");
            s = s.Replace("XL", "XXXX");
            s = s.Replace("XC", "LXXXX");
            s = s.Replace("CD", "CCCC");
            s = s.Replace("CM", "DCCCC");

            var inputs = s.ToCharArray().ToList();

            var transferedInputs = new List<int>();

            var result = 0;

            foreach (var input in inputs)
            {
                result +=TransferToInteger(input.ToString());
            }

            return result;
        }
        private int TransferToInteger(string romanNumeral)
        {
            switch (romanNumeral)
            {
                case "I":    
                    {
                        return 1;
                    }

                case "V":
                    {
                        return 5;
                    }

                case "X":
                    {
                        return 10;
                    }

                case "L":
                    {
                        return 50;
                    }

                case "C":
                    {
                        return 100;
                    }

                case "D":
                    {
                        return 500;
                    }

                case "M":
                    {
                        return 1000;
                    }
            }

            throw new Exception("Unrecognizable");
        }

        //14.Longest Common Prefix
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Count() == 0)
            {
                return string.Empty;
            }
            else if(strs.Count() == 1)
            {
                return strs[0];
            }

            var splitStrs = new List<List<char>>();

            foreach (var str in strs)
            {
                splitStrs.Add(str.ToCharArray().ToList());
            }

            var sameChars = new List<string>();

            var firstSplitStr = splitStrs[0];

            for (int i = 0; i < firstSplitStr.Count; i++)
            {
                var sameChar = string.Empty;

                foreach (var splitStr in splitStrs)
                {
                    if (splitStr == firstSplitStr)
                    {
                        continue;
                    }

                    if (firstSplitStr.Count > splitStr.Count && i + 1 > splitStr.Count)
                    {
                        sameChar = null;

                        break;
                    }

                    if (firstSplitStr[i] == splitStr[i])
                    {
                        sameChar = firstSplitStr[i].ToString();
                    }
                    else
                    {
                        sameChar = null;

                        break;
                    }
                }

                if (sameChar != null)
                {
                    sameChars.Add(sameChar);
                }
                else
                {
                    break;
                }
            }

            var result = string.Empty;

            foreach (var sameChar in sameChars)
            {
                result += sameChar;
            }

            return result;
        }
    }
}
