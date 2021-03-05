using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSharpApp
{
    public class Medium
    {
        //2. Add Two Numbers
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode GetListNode(int[] input)
        {
            var listNodeList = new List<ListNode>();

            for (int i = 0; i < input.Length; i++)
            {
                var listNode = new ListNode();

                listNodeList.Add(listNode);

                listNodeList[i].val = input[i];

                if (i != 0)
                {
                    listNodeList[i - 1].next = listNodeList[i];
                }
            }

            return listNodeList[0];
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var reverseInt1 = GetReverseInt(GetIntByLinkedList(l1));

            var reverseInt2 = GetReverseInt(GetIntByLinkedList(l2));

            var result = GetLinkedListByString(GetReverseInt(GetNumberAddedByString(reverseInt1, reverseInt2)));

            return result;
        }
        public ListNode GetLinkedListByString(string value)
        {
            var stringList = new List<string>();

            foreach (var charItem in value.ToString().ToCharArray())
            {
                stringList.Add(charItem.ToString());
            }

            var listNodeList = new List<ListNode>();

            for (int i = 0; i < stringList.Count; i++)
            {
                var listNode = new ListNode();

                listNodeList.Add(listNode);

                listNodeList[i].val = int.Parse(stringList[i]);

                if (i != 0)
                {
                    listNodeList[i - 1].next = listNodeList[i];
                }
            }

            return listNodeList[0];
        }
        public string GetIntByLinkedList(ListNode listNode)
        {
            var stringItem = "";

            while (1 != 0)
            {
                stringItem += listNode.val.ToString();

                listNode = listNode.next;

                if (listNode == null)
                {
                    break;
                }
                else if (listNode.next == null)
                {
                    stringItem += listNode.val.ToString();

                    break;
                }
            }

            return stringItem;
        }
        public string GetReverseInt(string value)
        {
            var stringList = new List<string>();

            foreach (var charItem in value.ToString().ToCharArray())
            {
                stringList.Add(charItem.ToString());
            }

            stringList.Reverse();

            var reverseString = "";

            foreach (var stringItem in stringList)
            {
                reverseString += stringItem;
            }

            return reverseString;
        }
        public string GetNumberAddedByString(string string1, string string2)
        {
            var splitList1 = new List<char>();

            var splitList2 = new List<char>();

            foreach (var charItem in string1.ToCharArray())
            {
                splitList1.Add(charItem);
            }

            foreach (var charItem in string2.ToCharArray())
            {
                splitList2.Add(charItem);
            }

            splitList1.Reverse();

            splitList2.Reverse();

            var string3 = "";

            if (splitList1.Count >= splitList2.Count)
            {
                for (int i = 0; i < splitList2.Count; i++)
                {
                    var int2 = int.Parse(splitList2[i].ToString());

                    var int1 = int.Parse(splitList1[i].ToString());

                    if (int2 + int1 >= 10)
                    {
                        splitList1[i] = ((int2 + int1) % 10).ToString().ToCharArray()[0];

                        var j = i + 1;

                        var nextInt2 = 0;

                        if (splitList1.Count <= j)
                        {
                            splitList1.Add('1');
                        }
                        else
                        {
                            while (splitList1.Count > j)
                            {
                                nextInt2 = int.Parse(splitList1[j].ToString());

                                nextInt2++;

                                if (nextInt2 < 10)
                                {
                                    splitList1[j] = nextInt2.ToString().ToCharArray()[0];

                                    break;
                                }
                                else
                                {
                                    splitList1[j] = '0';
                                }

                                j++;
                            }

                            if (splitList1[splitList1.Count - 1] == '0')
                            {
                                splitList1.Add('1');
                            }
                        }
                    }
                    else
                    {
                        splitList1[i] = (int2 + int1).ToString().ToCharArray()[0];
                    }
                }

                splitList1.Reverse();

                foreach (var charItem in splitList1)
                {
                    string3 += charItem.ToString();
                }
            }
            else
            {
                for (int i = 0; i < splitList1.Count; i++)
                {
                    var int2 = int.Parse(splitList2[i].ToString());

                    var int1 = int.Parse(splitList1[i].ToString());

                    if (int2 + int1 >= 10)
                    {
                        splitList2[i] = ((int2 + int1) % 10).ToString().ToCharArray()[0];

                        var j = i + 1;

                        var nextInt2 = 0;

                        if (splitList2.Count <= j)
                        {
                            splitList2.Add('1');
                        }
                        else
                        {
                            while (splitList2.Count > j)
                            {
                                nextInt2 = int.Parse(splitList2[j].ToString());

                                nextInt2++;

                                if (nextInt2 < 10)
                                {
                                    splitList2[j] = nextInt2.ToString().ToCharArray()[0];

                                    break;
                                }
                                else
                                {
                                    splitList2[j] = '0';
                                }

                                j++;
                            }

                            if (splitList2[splitList2.Count - 1] == '0')
                            {
                                splitList2.Add('1');
                            }
                        }
                    }
                    else
                    {
                        splitList2[i] = (int2 + int1).ToString().ToCharArray()[0];
                    }
                }

                splitList2.Reverse();

                foreach (var charItem in splitList2)
                {
                    string3 += charItem.ToString();
                }
            }

            return string3;
        }

        //6. ZigZag Conversion
        public string Convert(string s, int numRows)
        {
            var zigzagSize = GetZigzagSize(s, numRows);

            if (numRows == 1)
            {
                return s;
            }

            return GetZigzag(s, zigzagSize);
        }
        public ZigzagSize GetZigzagSize(string s, int numRows)
        {
            var stringLength = s.ToCharArray().Length;

            //a set of zigzag is one vertical line with the slanted line before another vertical line
            var memberOfset = numRows * 2 - 2;

            var remainderOfZigzag = 0;

            var quotientOfZigzag = Math.DivRem(stringLength, memberOfset, out remainderOfZigzag);

            var remainderOfRest = 0;

            var quotientOfRest = Math.DivRem(remainderOfZigzag, numRows, out remainderOfRest);

            if (quotientOfRest == 0)
            {
                return new ZigzagSize() { LengthOfX = quotientOfZigzag * (numRows - 1) + 1, LengthOfY = numRows };
            }

            return new ZigzagSize() { LengthOfX = quotientOfZigzag * (numRows - 1) + 1 + remainderOfRest, LengthOfY = numRows };
        }
        public string GetZigzag(string s, ZigzagSize zigzagSize)
        {
            var charArray = s.ToCharArray();

            var zigzagMap = new Dictionary<int, Dictionary<int, string>>();

            var memberOfset = zigzagSize.LengthOfY * 2 - 2;

            var insertCount = 0;

            for (int i = 0; i < zigzagSize.LengthOfX; i++)
            {
                for (int j = 0; j < zigzagSize.LengthOfY; j++)
                {
                    if (!zigzagMap.ContainsKey(i))
                    {
                        zigzagMap.Add(i, new Dictionary<int, string>());
                    }

                    zigzagMap[i].Add(j, null);

                    var currentRow = 0;

                    var currentColumn = Math.DivRem(insertCount, zigzagSize.LengthOfY, out currentRow);

                    var restOfSet = 0;

                    var currentSet = Math.DivRem(currentColumn, (zigzagSize.LengthOfY - 1), out restOfSet);

                    var indexOfS = 0;

                    if (restOfSet == 0)
                    {
                        indexOfS = (currentSet * memberOfset - 1) + (currentRow + 1);
                    }
                    else
                    {
                        indexOfS = (currentSet * memberOfset - 1) + zigzagSize.LengthOfY + restOfSet;
                    }

                    if (indexOfS > charArray.Length - 1)
                    {
                        continue;
                    }

                    if (restOfSet == 0)
                    {
                        zigzagMap[i][j] = charArray[indexOfS].ToString();
                    }
                    else if (currentRow == zigzagSize.LengthOfY - restOfSet - 1)
                    {
                        zigzagMap[i][j] = charArray[indexOfS].ToString();
                    }

                    insertCount++;
                }
            }

            var result = "";

            for (int j = 0; j < zigzagSize.LengthOfY; j++)
            {
                for (int i = 0; i < zigzagSize.LengthOfX; i++)
                {
                    if (zigzagMap[i][j] == null)
                    {
                        continue;
                    }

                    result += zigzagMap[i][j].ToString();
                }
            }

            return result;
        }
        public class ZigzagSize
        {
            public int LengthOfX { get; set; }
            public int LengthOfY { get; set; }
        }

        //11. Container With Most Water
        public int MaxArea(int[] height)
        {
            var runTimes = 0;

            var h = height;
            int i = 0, j = h.Length - 1, result = 0;

            while (i < j)
            {
                result = Math.Max(result, Math.Min(h[i], h[j]) * (j - i));

                //從最寬開始思考，每次往內移一格，移動的那一格只能是短邊，此為唯一邏輯
                if (h[i] < h[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }

                runTimes++;
            }

            return result;
        }

        //3. Longest Substring Without Repeating Characters
        public int LengthOfLongestSubstring(string s)
        {
            var charArray = s.ToCharArray();

            var maxLength = 0;

            var length = 0;

            var chekcHashSet = new Dictionary<char, List<int>>();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (!chekcHashSet.ContainsKey(charArray[i]))
                {
                    chekcHashSet[charArray[i]] = new List<int>();

                    chekcHashSet[charArray[i]].Add(i);

                    length++;

                    if (maxLength < length)
                    {
                        maxLength = length;
                    }
                }
                else
                {
                    var index = chekcHashSet[charArray[i]];

                    length = 0;

                    chekcHashSet.Clear();

                    for (int j = index.Last() + 1; j < i + 1; j++)
                    {
                        chekcHashSet.Add(charArray[j], new List<int>());

                        chekcHashSet[charArray[j]].Add(j);

                        length++;
                    }
                }
            }

            return maxLength;
        }

        //29. Divide Two Integers (Time Limit Exceeded)
        public int Divide(int dividend, int divisor)
        {
            //要拆成二進位來處理
            var quotient = 0;
            var dividendIsNegative = false;
            var divisorIsNegative = false;

            if (dividend < 0)
            {
                dividendIsNegative = true;

                if (dividend == int.MinValue && divisor == -1)
                {
                    return int.MaxValue;
                }
            }

            if (divisor < 0)
            {
                divisorIsNegative = true;
            }

            if (!dividendIsNegative && !divisorIsNegative)
            {
                while (dividend > 0 && dividend - divisor >= 0)
                {
                    dividend = dividend - divisor;

                    quotient++;
                }
            }

            if (dividendIsNegative && !divisorIsNegative)
            {
                while (dividend < 0 && dividend + divisor <= 0)
                {
                    dividend = dividend + divisor;

                    quotient--;
                }
            }

            if (!dividendIsNegative && divisorIsNegative)
            {
                while (dividend > 0 && dividend + divisor >= 0)
                {
                    dividend = dividend + divisor;

                    quotient--;
                }
            }

            if (dividendIsNegative && divisorIsNegative)
            {
                while (dividend < 0 && dividend - divisor <= 0)
                {
                    dividend = dividend - divisor;

                    quotient++;
                }
            }

            return quotient;
        }

        //4. Median of Two Sorted Arrays
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //O = logm* logn

            //leftm < midm < rightm leftn < midn < rightn

            //if(midn > midm) rightn > midm, if(midn < midm) leftn < midm

            //new array leftm < midim  < midn < rightn 

            //(m+n)/2 new median position

            //odd 
            return 0;
        }

        //5. Longest Palindromic Substring
        public string LongestPalindrome(string s)
        {
            var originCharArray = s.ToCharArray();

            var modifiedCharArray = new List<char>();

            var modifiedString = "";

            foreach (var charItem in originCharArray)
            {
                modifiedString += "*";

                modifiedString += charItem;

                modifiedCharArray.Add('*');

                modifiedCharArray.Add(charItem);
            }

            modifiedString += "*";

            modifiedCharArray.Add('*');

            var oddSeedList = new Dictionary<int, int>();

            for (int i = 0; i < modifiedCharArray.Count; i++)
            {
                oddSeedList.Add(i, 0);
            }

            var bestIndex = new List<int>() { 0, 0 };

            var wingLength = 0;

            var deleteList = new List<int>();

            var indexes = oddSeedList.Keys.ToList();

            while (wingLength <= modifiedCharArray.Count / 2)
            {
                foreach (var index in indexes)
                {
                    if (index - wingLength < 0)
                    {
                        deleteList.Add(index);

                        continue;
                    }

                    if (index + wingLength > modifiedCharArray.Count - 1)
                    {
                        deleteList.Add(index);

                        continue;
                    }

                    if (modifiedCharArray[index - wingLength] != modifiedCharArray[index + wingLength])
                    {
                        deleteList.Add(index);

                        continue;
                    }

                    oddSeedList[index] = wingLength;

                    if (wingLength > bestIndex[1])
                    {
                        bestIndex[1] = wingLength;
                        bestIndex[0] = index;
                    }
                }

                foreach (var deleteIndex in deleteList)
                {
                    indexes.Remove(deleteIndex);
                }

                deleteList.Clear();

                wingLength++;
            }

            var subString = modifiedString.Substring(bestIndex[0] - bestIndex[1], bestIndex[1] * 2 + 1);

            return subString.Replace("*", "");
        }

        //15. 3Sum (Time Limit Exceeded)
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int target = -nums[i], low = i + 1, high = nums.Length - 1;

                while (low < high)
                {
                    if (nums[low] + nums[high] == target)
                    {
                        res.Add(new List<int>() { nums[i], nums[low], nums[high] });
                        low++;
                        high--;

                        while (low < high && nums[low] == nums[low - 1])
                            low++;
                        while (low < high && nums[high] == nums[high + 1])
                            high--;
                    }
                    else if (nums[low] + nums[high] > target)
                        high--;
                    else
                        low++;
                }
            }

            return res;
        }

        //17. Letter Combinations of a Phone Number
        public IList<string> LetterCombinations(string digits)
        {
            if (digits == null || digits.Length == 0)
                return new List<string>();

            Hashtable hash = new Hashtable();
            char[][] graph = new char[digits.Length][];
            string temp = string.Empty;
            List<string> result = new List<string>();

            hash.Add('2', "abc");
            hash.Add('3', "def");
            hash.Add('4', "ghi");
            hash.Add('5', "jkl");
            hash.Add('6', "mno");
            hash.Add('7', "pqrs");
            hash.Add('8', "tuv");
            hash.Add('9', "wxyz");

            for (int i = 0; i < digits.Length; i++)
            {
                temp = (string)hash[digits[i]];

                graph[i] = new char[temp.Length];

                for (int j = 0; j < temp.Length; j++)
                    graph[i][j] = temp[j];
            }

            DFS(graph, 0, string.Empty, result);

            return result;
        }
        public void DFS(char[][] graph, int currentLayer, string previousCombination, List<string> result)
        {
            string currentCombination = string.Empty;

            if (graph.Length - 1 < currentLayer)
            {
                result.Add(previousCombination);
                return;
            }

            foreach (var item in graph[currentLayer])
            {
                currentCombination = previousCombination;

                DFS(graph, currentLayer + 1, currentCombination += item, result);
            }
        }

        //19. Remove Nth Node From End of List
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var listNodeList = new List<ListNode>();

            listNodeList.Add(head);

            if (head.next == null)
            {
                return null;
            }

            while (head.next != null)
            {
                head = head.next;

                listNodeList.Add(head);
            }

            listNodeList.Reverse();

            for (int i = 0; i < listNodeList.Count; i++)
            {
                if (i == n - 1)
                {
                    listNodeList[i] = null;
                }

                if (i >= 1 && listNodeList[i - 1] == null)
                {
                    if (i >= 2)
                    {
                        listNodeList[i].next = listNodeList[i - 2];

                        break;
                    }
                    else
                    {
                        listNodeList[i].next = null;

                        break;
                    }
                }
            }

            for (int i = listNodeList.Count - 1; i >= 0; i--)
            {
                if (listNodeList[i] != null)
                {
                    return listNodeList[i];
                }
            }

            return listNodeList[listNodeList.Count - 1];
        }

        //20. Valid Parentheses
        public bool IsValid(string s)
        {
            var cleanPatten = new List<string>() { "{}", "[]", "()" };

            var previousS = "";

            while (s != "")
            {
                previousS = s;

                foreach (var item in cleanPatten)
                {
                    s = s.Replace(item, "");
                }

                if (previousS == s)
                {
                    return false;
                }
            }

            return true;
        }

        //21. Merge Two Sorted Lists
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }

            var linkedList1 = new List<ListNode>();
            var linkedList2 = new List<ListNode>();

            while (l1.next != null)
            {
                linkedList1.Add(l1);

                l1 = l1.next;
            }

            linkedList1.Add(l1);

            while (l2.next != null)
            {
                linkedList2.Add(l2);

                l2 = l2.next;
            }

            linkedList2.Add(l2);

            var linkedList3 = new List<ListNode>();

            var index1 = 0;
            var index2 = 0;

            while ((index1 < linkedList1.Count || index2 < linkedList2.Count))
            {
                if (index1 == linkedList1.Count)
                {
                    linkedList3.Add(linkedList2[index2]);
                    index2++;
                }
                else if (index2 == linkedList2.Count)
                {
                    linkedList3.Add(linkedList1[index1]);
                    index1++;
                }
                else if (linkedList1[index1].val <= linkedList2[index2].val)
                {
                    linkedList3.Add(linkedList1[index1]);
                    index1++;
                }
                else
                {
                    linkedList3.Add(linkedList2[index2]);
                    index2++;
                }
            }

            for (int i = 0; i < linkedList3.Count; i++)
            {
                if (i < linkedList3.Count - 1)
                {
                    linkedList3[i].next = linkedList3[i + 1];
                }
                else
                {
                    linkedList3[i].next = null;
                }
            }

            return linkedList3[0];
        }

        //22. Generate Parentheses
        public IList<string> GenerateParenthesis(int n)
        {
            var meta = new Dictionary<int, List<string>>();

            meta.Add(0, new List<string>());
            meta[0].Add("(");
            meta[0].Add(")");

            for (int i = 1; i < n * 2; i++)
            {
                meta.Add(i, new List<string>());

                foreach (var item in meta[i - 1])
                {
                    meta[i].Add(item + "(");
                    meta[i].Add(item + ")");
                }
            }

            var result = new List<string>();

            foreach (var item in meta[n * 2 - 1])
            {
                if (IsValid(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        //33. Search in Rotated Sorted Array
        public int Search(int[] nums, int target)
        {
            return nums.ToList().IndexOf(target);
        }

        //34. Find First and Last Position of Element in Sorted Array
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return new int[] { -1, -1 };
            }
            
            var list = nums.ToList();

            var i = 0;
            var j = nums.Length - 1;

            while (i <= j && !(nums[i] == target && nums[j] == target))
            {
                if (nums[i] != target)
                {
                    i++;
                }

                if (nums[j] != target)
                {
                    j--;
                }
            }

            if ((i > nums.Length - 1 || j < 0) || (nums[i] != target && nums[j] != target))
            {
                return new int[] { -1, -1 };
            }
            else
            {
                return new int[] { i, j };
            }
        }

        //39. Combination Sum
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            List<int> combination = new List<int>();

            Array.Sort(candidates);

            List<List<int>> record = new List<List<int>>();

            CombinationSum(result, candidates, combination, target, 0, record);

            return result;
        }
        private void CombinationSum(IList<IList<int>> result, int[] candidates, IList<int> combination, int target, int start, List<List<int>> record)
        {
            if (target == 0)
            {
                result.Add(new List<int>(combination));

                return;
            }

            for (int i = start; i != candidates.Length && target >= candidates[i]; ++i)
            {
                combination.Add(candidates[i]);

                CombinationSum(result, candidates, combination, target - candidates[i], i, record);

                record.Add(new List<int>(combination));

                combination.Remove(combination.Last());
            }
        }

        //46. Permutations
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();

            var meta = new List<int>();

            Selection(result, meta, nums);

            return result;
        }
        private void Selection(IList<IList<int>> result, IList<int> meta, int[] nums)
        {
            if (meta.Count == nums.Length)
            {
                result.Add(new List<int>(meta));

                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (meta.Contains(nums[i]))
                {
                    continue;
                }
                
                meta.Add(nums[i]);

                Selection(result, meta, nums);

                meta.Remove(meta.Last());
            }
        }

        //49. Group Anagrams
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dictionaryByKey = new Dictionary<string, List<string>>();
            
            foreach (var str in strs)
            {
                var charArray = str.ToCharArray().ToList();

                charArray.Sort();

                var key = "";

                foreach (var item in charArray)
                {
                    key += item;
                }

                if(!dictionaryByKey.ContainsKey(key))
                {
                    dictionaryByKey.Add(key, new List<string>());
                }

                dictionaryByKey[key].Add(str);
            }

            var result = new List<IList<string>>();

            foreach (var key in dictionaryByKey.Keys)
            {
                result.Add(dictionaryByKey[key]);
            }

            return result;
        }

        //53. Maximum Subarray
        public int MaxSubArray(int[] nums)
        {
            int sum = 0;
            int maxSum = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                //如果這個元素本先前的總和還大，那直接把先前捨棄，改從此元素開始
                if (nums[i] > sum)
                {
                    sum = nums[i];
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            return maxSum;
        }

        //55. Jump Game
        public bool CanJump(int[] nums)
        {
            //找尋自身可以移動的範圍內，有沒有人移動得比我更遠
            
            //greedy
            int farthest = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > farthest)
                    return false;

                farthest = Math.Max(farthest, i + nums[i]);

                if (farthest > nums.Length)
                    return true;
            }

            return true;
        }
        public bool CanJumpByDp(int[] nums)
        {
            //檢查每一格是否可以到達
            
            // dp[i] means whether index i be reached or not
            bool[] dp = new bool[nums.Length];
            dp[0] = true;

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // check whether we jump from index j to index i?
                    if (dp[j] && j + nums[j] >= i)
                    {
                        dp[i] = true;

                        break;
                    }
                }
            }

            return dp[nums.Length - 1];
        }
    }
}
