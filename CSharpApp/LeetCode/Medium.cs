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
        //Linked List
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //作法一 轉換為數字相加後，轉換為字串，轉換為LinkedList
            var reverseInt1 = GetReverseInt(GetIntByLinkedList(l1));

            var reverseInt2 = GetReverseInt(GetIntByLinkedList(l2));

            var result = GetLinkedListByString(GetReverseInt(GetNumberAddedByString(reverseInt1, reverseInt2)));

            return result;

            //作法二 將LinkedList彼此對齊相加，超過10則進位
        }
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
        //Array, Two Pointer
        public int MaxArea(int[] height)
        {
            var h = height; //原陣列
            int i = 0; // 左邊起始
            int j = h.Length - 1; // 右邊起始
            int result = 0; //面積

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
            }

            return result;
        }

        //3. Longest Substring Without Repeating Characters
        //Hash Table, Two Pointer, String, Sliding Window
        //解法二的 Two Pointer較優
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
                    //判斷到重覆之後清除(在此之前的最長長度已記錄)
                    var index = chekcHashSet[charArray[i]];

                    length = 0;

                    chekcHashSet.Clear();

                    //被重複的下一個元素開始重新判斷是否有重複，將checkHashSet補齊資料直到索引為i
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
        public int LengthOfLongestSubstring2(string s)
        {
            if (s == null || s == string.Empty)
            {
                return 0;
            }

            HashSet<char> set = new HashSet<char>();
            int currentMax = 0;
            int i = 0;
            int j = 0;

            while (j < s.Length)
            {
                if (!set.Contains(s[j]))
                {
                    currentMax = Math.Max(currentMax, j - i + 1);
                    set.Add(s[j]);

                    j++;
                }
                else
                {
                    set.Remove(s[i]);

                    i++;
                }
            }

            return currentMax;
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
        //String, Dynamic programming
        //方法二較好，利用之前運算過的結果繼續向下延伸(DP解法)
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

            //衛冕者
            var bestIndex = new List<int>() { 0, 0 };
            //翅膀長度
            var wingLength = 0;
            //淘汰名單
            var deleteList = new List<int>();
            //種子位置
            var indexes = oddSeedList.Keys.ToList();

            while (wingLength <= modifiedCharArray.Count / 2)
            {
                foreach (var index in indexes)
                {
                    //左邊太短
                    if (index - wingLength < 0)
                    {
                        deleteList.Add(index);

                        continue;
                    }

                    //右邊太短
                    if (index + wingLength > modifiedCharArray.Count - 1)
                    {
                        deleteList.Add(index);

                        continue;
                    }

                    //兩對稱位置的字符不一樣
                    if (modifiedCharArray[index - wingLength] != modifiedCharArray[index + wingLength])
                    {
                        deleteList.Add(index);

                        continue;
                    }

                    //該種子目前的翅膀長度(記錄沒意義)
                    oddSeedList[index] = wingLength;

                    //若贏過衛冕者則衛冕
                    if (wingLength > bestIndex[1])
                    {
                        bestIndex[1] = wingLength;
                        bestIndex[0] = index;
                    }
                }

                //按照淘汰名單淘汰
                foreach (var deleteIndex in deleteList)
                {
                    indexes.Remove(deleteIndex);
                }

                deleteList.Clear();

                //翅膀+1繼續測試有沒有合適的種子
                wingLength++;
            }

            var subString = modifiedString.Substring(bestIndex[0] - bestIndex[1], bestIndex[1] * 2 + 1);

            return subString.Replace("*", "");
        }
        public string LongestPalindrome2(string s)
        {
            //當record為true，表示兩位置的字符相等
            var record = new bool[s.Length, s.Length];
            int maxlength = 0;
            string result = "";

            //長度為1的狀況
            for (int i = 0; i < s.Length; i++)
            {
                record[i, i] = true;
            }

            //長度為2的狀況
            for (int i = 0; i + 1 < s.Length; i++)
            {
                if (s[i] == s[i + 1])
                {
                    record[i, i + 1] = true;

                    maxlength = 2;
                    result = s.Substring(i, 2);
                }
                else
                {
                    record[i, i + 1] = false;
                }
            }

            //長度為3以上的狀況
            for (int j = 0; j < s.Length; j++)
            {
                for (int i = 0; i <= j; i++)
                {
                    //內縮這格存在且字符相等
                    if (i + 1 < s.Length && j - 1 >= 0 && record[i + 1, j - 1])
                    {
                        if (s[i] == s[j])
                        {
                            record[i, j] = true;
                        }
                    }

                    if (record[i, j] && j - i + 1 > maxlength)
                    {
                        maxlength = j - i + 1;

                        result = s.Substring(i, j - i + 1);
                    }
                }
            }

            return result;
        }

        //15. 3Sum
        //Array, Two Pointer
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            //由小到大排列
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                //在 i - 1 時已計算過
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                //找出能抵銷的值
                int target = -nums[i];
                //Pointer1 (不用考慮 i 以前，因為已經被計算過)
                int low = i + 1;
                //Pointer2
                int high = nums.Length - 1;

                while (low < high)
                {
                    if (nums[low] + nums[high] == target)
                    {
                        result.Add(new List<int>() { nums[i], nums[low], nums[high] });

                        low++;
                        high--;

                        //若發現同值則繼續往右搜尋
                        while (low < high && nums[low] == nums[low - 1])
                        {
                            low++;
                        }

                        //若發現同值則繼續往左搜尋
                        while (low < high && nums[high] == nums[high + 1])
                        {
                            high--;
                        }
                    }
                    else if (nums[low] + nums[high] > target)
                    {
                        //太大，Pointer2往左
                        high--;
                    }
                    else
                    {
                        //太小，Pointer1往右
                        low++;
                    }
                }
            }

            return result;
        }

        //17. Letter Combinations of a Phone Number
        //String, Backtracking, Depth-first search, Recursion
        public IList<string> LetterCombinations(string digits)
        {
            if (digits == null || digits.Length == 0)
            {
                return new List<string>();
            }

            Hashtable hash = new Hashtable();
            hash.Add('2', "abc");
            hash.Add('3', "def");
            hash.Add('4', "ghi");
            hash.Add('5', "jkl");
            hash.Add('6', "mno");
            hash.Add('7', "pqrs");
            hash.Add('8', "tuv");
            hash.Add('9', "wxyz");

            //對應hash table後的所有資料
            char[][] graph = new char[digits.Length][];
            string temp = string.Empty;

            List<string> result = new List<string>();

            for (int i = 0; i < digits.Length; i++)
            {
                temp = (string)hash[digits[i]];

                graph[i] = new char[temp.Length];

                for (int j = 0; j < temp.Length; j++)
                {
                    graph[i][j] = temp[j];
                }
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
        //Linked List, Two Pointer
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
        //String, Stack
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
        public bool IsValid2(string s)
        {
            //1. 凡是 ([{ 就push )]} 到Stack中，接下來遇到 )]} 就逐一pop出來，若不為0則false
            Stack<char> sign = new Stack<char>();

            foreach (var item in s.ToCharArray())
            {
                if (item == '(')
                {
                    sign.Push(')');
                }
                else if (item == '[')
                {
                    sign.Push(']');
                }
                else if (item == '{')
                {
                    sign.Push('}');
                }
                else if (sign.Count == 0 || sign.Pop() != item)
                {
                    return false;
                }
            }

            return sign.Count == 0;
        }

        //21. Merge Two Sorted Lists
        //Linked List, Recursion
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
        //String, Backtracking
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
        public IList<string> GenerateParenthesis2(int n)
        {
            List<string> result = new List<string>();

            GenerateAndCheck("", 0, 0, n, result);
            return result;
        }
        private void GenerateAndCheck(string str, int opened, int closed, int pairCount, List<string> result)
        {
            //左右括號數量相等，且等於pair數
            if (opened == closed && opened == pairCount)
            {
                result.Add(str);
                return;
            }

            //Recursion
            if (opened < pairCount)
            {
                GenerateAndCheck(str + "(", opened + 1, closed, pairCount, result);
            }

            if (closed < opened)
            {
                GenerateAndCheck(str + ")", opened, closed + 1, pairCount, result);
            }
        }

        //33. Search in Rotated Sorted Array
        //Array, Binary Search
        public int Search(int[] nums, int target)
        {
            return nums.ToList().IndexOf(target);
        }
        public int Search2(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                //return唯一的條件為當所選取mid為target
                if (nums[mid] == target)
                {
                    return mid;
                }

                //low小於mid ex 3 4 5 6 0 1 2
                if (nums[low] <= nums[mid])
                {
                    //target在low與mid之間
                    if (target >= nums[low] && target <= nums[mid])
                    {
                        high = mid;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                else //low大於mid ex 5 6 0 1 2 3 4
                {
                    //target 在mid與high之間
                    if (target >= nums[mid] && target <= nums[high])
                    {
                        low = mid;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }

            return -1;
        }

        //34. Find First and Last Position of Element in Sorted Array
        //Array, Binary Search
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return new int[] { -1, -1 };
            }

            var i = 0;
            var j = nums.Length - 1;

            //i從左側開始搜尋 j從右側開始搜尋 直到各自找到target
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

            //若i或j超過邊界 或是 並沒有等於target 則失敗
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
        //Array, Backtracking, Recursion
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            List<int> combination = new List<int>();

            Array.Sort(candidates);

            List<List<int>> record = new List<List<int>>();

            CombinationSum(result, candidates, combination, target, 0);

            return result;
        }
        private void CombinationSum(IList<IList<int>> result, int[] candidates, IList<int> combination, int target, int start)
        {
            if (target == 0)
            {
                result.Add(new List<int>(combination));

                return;
            }

            //迴圈條件中包含Backtracking資訊
            for (int i = start; i != candidates.Length && target >= candidates[i]; i++)
            {
                combination.Add(candidates[i]);

                CombinationSum(result, candidates, combination, target - candidates[i], i);

                //如果有成功return拔除該元素繼續下一個，直到因條件不符跳出迴圈回上一層，也需將最後一個元素移除才能繼續迴圈
                combination.Remove(combination.Last());
            }
        }

        //45. Jump Game II
        //Array, Greedy
        public int Jump(int[] nums)
        {
            int step = 0;
            int currMaxPos = 0;
            int nextMaxPos = 0;

            //The for loop logic checks whether we need to jump back (to certain previous position) in order to jump further when we are at position i .
            //We don't need to check whether we need to jump further when we already at the last position A.Length-1.
            for (int i = 0; i < nums.Length - 1; i++)
            {
                // nextMaxPos indicates the next longest ladder to be selected
                nextMaxPos = Math.Max(nextMaxPos, i + nums[i]);

                // i == currMaxPos indicates the current longest ladder has reached the end
                if (i == currMaxPos)
                {
                    step++;
                    currMaxPos = nextMaxPos;
                }
            }

            return step;
        }

        //46. Permutations
        //backtracking
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

        //48. Rotate Image
        //Array
        public void Rotate(int[][] matrix)
        {
            int n = matrix.GetLength(0);

            int half_n = n / 2;

            for (int i = 0; i < half_n; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    int t = matrix[i][j];

                    // anti-clockwise
                    //matrix[i,j] = matrix[j,n-i-1];
                    //matrix[j,n-i-1] = matrix[n-i-1,n-j-1];
                    //matrix[n-i-1,n-j-1] = matrix[n-j-1,i];
                    //matrix[n-j-1,i] = t;

                    // clockwise
                    matrix[i][j] = matrix[n - j - 1][i];

                    matrix[n - j - 1][i] = matrix[n - i - 1][n - j - 1];

                    matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];

                    matrix[j][n - i - 1] = t;
                }
            }
        }

        //49. Group Anagrams
        //Hash Table, String
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

                if (!dictionaryByKey.ContainsKey(key))
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

        //55. Jump Game
        //Array, Greedy, Dynamic Programming
        public bool CanJump(int[] nums)
        {
            //找尋自身可以移動的範圍內，有沒有人移動得比我更遠

            //greedy
            int farthest = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > farthest)
                {
                    return false;
                }

                farthest = Math.Max(farthest, i + nums[i]);

                if (farthest > nums.Length)
                {
                    return true;
                }
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

        //56. Merge Intervals
        //Array, Sort, Recursion
        public int[][] Merge(int[][] intervals)
        {
            var meta1 = intervals.ToList();

            var meta2 = new List<List<int>>();

            for (int i = 0; i < meta1.Count; i++)
            {
                meta2.Add(meta1[i].ToList());
            }

            var input = new List<List<int>>();

            MergeSubMethod(meta2, input);

            int[][] result = new int[input.ToArray().Length][];

            for (int i = 0; i < input.ToArray().Length; i++)
            {
                result[i] = input.ToArray()[i].ToArray();
            }

            return result;
        }
        private void MergeSubMethod(List<List<int>> intervals, List<List<int>> result)
        {
            result.Clear();

            for (int i = 0; i < intervals.Count; i++)
            {
                var involved = false;
                var nothing = true;

                for (int j = 0; j < result.Count; j++)
                {
                    //後段相交
                    if (intervals[i][0] <= result[j][0] && (intervals[i][1] >= result[j][0] && intervals[i][1] <= result[j][1]))
                    {
                        result[j][0] = intervals[i][0];

                        nothing = false;

                        break;
                    }
                    //大於
                    else if (intervals[i][0] <= result[j][0] && (intervals[i][1] >= result[j][1]))
                    {
                        result[j][0] = intervals[i][0];
                        result[j][1] = intervals[i][1];

                        nothing = false;

                        break;
                    }
                    //前段相交
                    else if (intervals[i][1] >= result[j][1] && (intervals[i][0] >= result[j][0] && intervals[i][0] <= result[j][1]))
                    {
                        result[j][1] = intervals[i][1];

                        nothing = false;

                        break;
                    }
                    //小於
                    else if (intervals[i][0] >= result[j][0] && intervals[i][1] <= result[j][1])
                    {
                        involved = true;
                    }
                }

                if (nothing && !involved)
                {
                    result.Add(new List<int>() { intervals[i][0], intervals[i][1] });
                }
            }

            //完全沒變化 結束
            if (result.Count == intervals.Count)
            {
                return;
            }
            else
            {
                MergeSubMethod(new List<List<int>>(result), result);
            }
        }

        //62. Unique Paths
        //Array, Dynamic Programming
        public int UniquePaths(int m, int n)
        {
            var result = new int[m, n];

            result[0, 0] = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        result[i, j] = 1;
                    }
                    else
                    {
                        result[i, j] = result[i - 1, j] + result[i, j - 1];
                    }
                }
            }

            return result[m - 1, n - 1];
        }

        //64. Minimum Path Sum
        //Array, Dynamic Programming, backtracking, Recursion
        //Recursion搜尋每個區塊(暴力解 但 Time Limit Exceeded)
        public int MinPathSum(int[][] grid)
        {
            if(grid.Length == 0)
            {
                return 0;
            }

            var result = new List<int>();

            Move(grid, result, 0, 0, 0);

            return result.Min();
        }
        private void Move(int[][] grid, List<int> result, int currentValue, int i, int j)
        {
            //如果跑出界外就停止
            if (i > grid.Length - 1 || j > grid[0].Length - 1)
            {
                return;
            }

            //增加當前的值
            currentValue += grid[i][j];

            //如果發現已經比目前最小的值還要大就不算了
            if (result.Count != 0)
            {
                if (currentValue > result.Min())
                {
                    return;
                }
            }

            //確實到達右下角則記錄起來
            if (i == grid.Length - 1 && j == grid[0].Length - 1)
            {
                result.Add(currentValue);
            }

            //如果下一步還在界內的話
            if (i + 1 <= grid.Length - 1 && j + 1 <= grid[0].Length - 1)
            {
                //如果往下比較小先往下
                if (grid[i + 1][j] < grid[i][j + 1])
                {
                    //試著往下移動一格
                    Move(grid, result, currentValue, i + 1, j);
                    //試著往右移動一格
                    Move(grid, result, currentValue, i, j + 1);
                }
                else
                {
                    //試著往右移動一格
                    Move(grid, result, currentValue, i, j + 1);
                    //試著往下移動一格
                    Move(grid, result, currentValue, i + 1, j);
                }
            }
            else
            {
                //試著往下移動一格
                Move(grid, result, currentValue, i + 1, j);
                //試著往右移動一格
                Move(grid, result, currentValue, i, j + 1);
            }
        }
        //DP解法較好
        public int MinPathSum2(int[][] grid)
        {
            int column = grid.Length;
            int row = grid[0].Length;

            int[][] dp = new int[column][];

            //建立一個DP來使用
            for (int i = 0; i < column; i++)
            {
                dp[i] = new int[row];
            }

            //起點
            dp[0][0] = grid[0][0];

            //橫排先計算
            for (int i = 1; i < column; i++)
            {
                dp[i][0] = dp[i - 1][0] + grid[i][0];
            }

            //縱排先計算
            for (int i = 1; i < row; i++)
            {
                dp[0][i] = dp[0][i - 1] + grid[0][i];
            }

            for (int i = 1; i < column; i++)
            {
                for (int j = 1; j < row; j++)
                {
                    int current = grid[i][j];

                    //該值只應該來自較小的那格
                    dp[i][j] = Math.Min(dp[i - 1][j] + current, dp[i][j - 1] + current);
                }
            }

            return dp[column - 1][row - 1];
        }

        //70. Climbing Stairs
        //Dynamic Programming
        public int ClimbStairs(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            int[] dp = new int[n];

            dp[0] = 1;

            dp[1] = 2;

            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n - 1];
        }

        //75. Sort Colors
        //Array, Two Pointers, Sort
        public void SortColors(int[] nums)
        {
            var n = nums.Length;

            var left = 0;
            var right = n - 1;

            for (int i = 0; i <= right; i++)
            {
                if (nums[i] == 2)
                {
                    //與最右邊交換 (不一定換到2)
                    var temp = nums[right];
                    nums[right] = nums[i];
                    nums[i] = temp;

                    //最右邊確定是2 因此right往左一格
                    right--;

                    //再跑一次 ( 因為可能換到不是2，而且下次要換的對象也可能不是2)
                    i--;
                }
                else if (nums[i] == 0)
                {
                    //與最左邊交換 (一定不是2 可能是0或1 0放左 2放右 1不動)
                    var temp = nums[left];
                    nums[left] = nums[i];
                    nums[i] = temp;

                    left++;
                }
            }
        }

        //78. Subsets
        //Array, Backtracking, Bit manipulation, Recursion
        public IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();

            FindSubsets(nums, result, new List<int>(), 0);

            return result;
        }

        private void FindSubsets(int[] nums, List<IList<int>> result, List<int> currentSet, int index)
        {
            result.Add(new List<int>(currentSet));

            for (int i = index; i < nums.Length; i++)
            {
                currentSet.Add(nums[i]);
                FindSubsets(nums, result, currentSet, i + 1);
                currentSet.RemoveAt(currentSet.Count - 1);
            }
        }

        //79. Word Search
        //Array, Backtracking, Recursion
        public bool Exist(char[][] board, string word)
        {
            if (board.Length == 0)
            {
                return false;
            }

            var isVisited = new bool[board.Length, board[0].Length];

            var result = false;

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    result = DFS(board, isVisited, i, j, word, 0);

                    if (result)
                    {
                        return true;
                    }
                }
            }

            return result;
        }
        private bool DFS(char[][] board, bool[,] isVisited, int i, int j, string word, int wordIndex)
        {
            //相符
            if (wordIndex == word.Length)
            {
                return true;
            }

            //超過邊界
            if (i >= board.Length || i < 0 || j >= board[0].Length || j < 0)
            {
                return false;
            }

            //字符不符
            if (word[wordIndex] != board[i][j])
            {
                return false;
            }

            //已經確認過
            if (isVisited[i, j])
            {
                return false;
            }

            isVisited[i, j] = true;

            var directions = new (int, int)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

            foreach (var direction in directions)
            {
                var oneResult = DFS(board, isVisited, i + direction.Item1, j + direction.Item2, word, wordIndex + 1);

                if (oneResult)
                {
                    return true;
                }
            }

            //復原 (同一次DFS中才有考慮)
            isVisited[i, j] = false;

            return false;
        }

        //94. Binary Tree Inorder Traversal
        //Hash Table, Stack , Tree
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public TreeNode GetTreeNode1()
        {
            var root = new TreeNode();

            root.val = 5;
            root.left = new TreeNode(4, null, null);
            root.right = new TreeNode(6, new TreeNode(3, null, null), new TreeNode(7, null, null));

            return root;
        }
        public TreeNode GetTreeNode2()
        {
            var root = new TreeNode();

            root.val = 2;
            root.left = new TreeNode(1, null, null);
            root.right = new TreeNode(3, null, null);

            return root;
        }
        public TreeNode GetTreeNode3()
        {
            var root = new TreeNode();

            root.val = 3;
            root.left = new TreeNode(1, new TreeNode(0, null, null), new TreeNode(2, null, null));
            root.right = new TreeNode(5, new TreeNode(4, null, null), new TreeNode(6, null, null));

            return root;
        }
        public TreeNode GetTreeNode4()
        {
            var root = new TreeNode();

            root.val = 0;

            return root;
        }
        public TreeNode GetTreeNode5()
        {
            var root = new TreeNode();

            root.val = 1;
            root.left = new TreeNode(2, null, new TreeNode(3, null, null));
            root.right = new TreeNode(2, null, new TreeNode(3, null, null));

            return root;
        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode currentNode = root;

            while (currentNode != null || stack.Count != 0)
            {
                //非null的 TreeNode都放入Stack中 沿著left
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                //沿著right依序拿出寫入result
                if (stack.Count != 0)
                {
                    currentNode = stack.Pop();
                    result.Add(currentNode.val);
                    currentNode = currentNode.right;
                }
            }

            return result;
        }

        //96. Unique Binary Search Trees
        //Dynamic Programming, Tree
        public int NumTrees(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            var dp = new int[n + 1];

            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                //1就是中間那顆 n-1再分到兩側
                //e.g. dp(1) = dp(0)
                //e.g. dp(2) = dp(1) * dp(1) + dp(1) * dp(1)
                //e.g. dp(3) = dp(2) * dp(0) + dp(1) * dp(1) + dp(0) * dp(2)
                //e.g. dp(4) = dp(3) * dp(0) + dp(2) * dp(1) + dp(1) + dp(2) + dp(0) * dp(3)
                //e.g. dp(5) = dp(4) * dp(0) + dp(3) * dp(1) + dp(2) * dp(2) + dp(1) * dp(3) + dp(0) * dp(4)
                var local = 0;

                for (int j = 0; j < i; j++)
                {
                    local += dp[j] * dp[i - j - 1];
                }

                dp[i] = local;
            }

            return dp[n];
        }

        //98. Validate Binary Search Tree
        //Tree, Depth-first Search, Recursion
        public bool IsValidBST(TreeNode root)
        {
            return DFS(root, long.MinValue, long.MaxValue);
        }
        private bool DFS(TreeNode root, long min, long max)
        {
            if (root == null)
            {
                return true;
            }
            
            //從root一路下來僅僅代表著上下限不斷的改變
            if (min < root.val && root.val < max)
            {
                var leftResult = DFS(root.left, min, root.val);

                var rightResult = DFS(root.right, root.val, max);

                if (leftResult && rightResult)
                {
                    return true;
                }
            }

            return false;
        }

        //101. Symmetric Tree
        //Tree, Depth-first Search, Breadth-first Search
        public bool IsSymmetric(TreeNode root)
        {
            var leftResult = new List<string>();
            var rightResult = new List<string>();
            
            CheckLeftDFS(root.left, leftResult);
            CheckRight2DFS(root.right, rightResult);

            if (leftResult.Count != rightResult.Count)
            {
                return false;
            }

            for (int i = 0; i < leftResult.Count; i++)
            {
                if (leftResult[i] != rightResult[i])
                {
                    return false;
                }
            }

            return true;
        }
        private void CheckLeftDFS(TreeNode root, List<string> result)
        {
            if (root == null)
            {
                result.Add(null);

                return;
            }

            result.Add(root.val.ToString());

            CheckLeftDFS(root.left, result);

            CheckLeftDFS(root.right, result);
        }
        private void CheckRight2DFS(TreeNode root, List<string> result)
        {
            if (root == null)
            {
                result.Add(null);

                return;
            }

            result.Add(root.val.ToString());

            CheckRight2DFS(root.right, result);

            CheckRight2DFS(root.left, result);
        }

        //102. Binary Tree Level Order Traversal
        //Tree, Breadth-first Search
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            IList<IList<int>> results = new List<IList<int>>();
            Queue<TreeNode> nodes = new Queue<TreeNode>();

            nodes.Enqueue(root);

            while (nodes.Count != 0)
            {
                //同一層的node數
                int nodesInSameLevel = nodes.Count;
                IList<int> subResult = new List<int>();

                while (nodesInSameLevel != 0)
                {
                    TreeNode currentNode = nodes.Dequeue();

                    //依序加入，但因是queue所以目前不會處理到
                    if (currentNode.left != null)
                    {
                        nodes.Enqueue(currentNode.left);
                    }

                    if (currentNode.right != null)
                    {
                        nodes.Enqueue(currentNode.right);
                    }

                    subResult.Add(currentNode.val);

                    nodesInSameLevel--;
                }

                results.Add(subResult);
            }

            return results;
        }

        //104. Maximum Depth of Binary Tree
        //Tree, Depth-first Search, Recursion, Breadth-first Search
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var level = 0;
            Queue<TreeNode> nodes = new Queue<TreeNode>();

            nodes.Enqueue(root);

            while (nodes.Count != 0)
            {
                //同一層的node數
                int nodesInSameLevel = nodes.Count;
                IList<int> subResult = new List<int>();

                while (nodesInSameLevel != 0)
                {
                    TreeNode currentNode = nodes.Dequeue();

                    //依序加入，但因是queue所以目前不會處理到
                    if (currentNode.left != null)
                    {
                        nodes.Enqueue(currentNode.left);
                    }

                    if (currentNode.right != null)
                    {
                        nodes.Enqueue(currentNode.right);
                    }

                    subResult.Add(currentNode.val);

                    nodesInSameLevel--;
                }

                level++;
            }

            return level;
        }
        public int MaxDepth2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var result = Math.Max(MaxDepth2(root.left), MaxDepth2(root.right)) + 1;

            return result;
        }

        //105. Construct Binary Tree from Preorder and Inorder Traversal
        //Arrau, Tree, Depth-first Search
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var n = preorder.Length;

            if (n == 0)
            {
                return null;
            }

            return DFS(preorder, 0, n - 1, inorder, 0, n - 1);
        }
        private TreeNode DFS(int[] preorder, int preLeft, int preRight, int[] inorder, int inLeft, int inRight)
        {
            if (preLeft > preRight)
            {
                return null;
            }

            var rootValue = preorder[preLeft];
            var rootInIndex = -1;

            for (int i = inLeft; i <= inRight; i++)
            {
                if (inorder[i] == rootValue)
                {
                    rootInIndex = i;
                    break;
                }
            }

            var count = rootInIndex - inLeft;

            var root = new TreeNode(rootValue);

            root.left = DFS(preorder, preLeft + 1, preLeft + count, inorder, inLeft, rootInIndex - 1);
            root.right = DFS(preorder, preLeft + count + 1, preRight, inorder, rootInIndex + 1, inRight);

            return root;
        }

        //114. Flatten Binary Tree to Linked List
        //Tree, Depth-first Search
        public void Flatten(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode tempNode = null;
            TreeNode lastNode = null;

            Flatten(root.left);
            Flatten(root.right);

            if (root.left != null)
            {
                tempNode = root.right;
                root.right = root.left;
                root.left = null;
                lastNode = root.right;

                while (lastNode.right != null)
                {
                    lastNode = lastNode.right;
                }

                lastNode.right = tempNode;
            }
        }

        //121. Best Time to Buy and Sell Stock
        //Array, Dynamic Programming
        public int MaxProfit(int[] prices)
        {
            var n = prices.Length;

            if (n == 0)
            {
                return 0;
            }

            var globalMaxProfit = 0;
            var globalMin = prices[0];

            for (int i = 1; i < n; i++)
            {
                var currentPrice = prices[i];

                //如果當前的價格比最低的價格還要低則沒有利潤
                var localMaxProfit = Math.Max(0, currentPrice - globalMin);

                //若利潤比當前最大利潤還大則取代
                globalMaxProfit = Math.Max(localMaxProfit, globalMaxProfit);

                //若比最低價還低則記錄此最低價
                globalMin = Math.Min(globalMin, currentPrice);
            }

            return globalMaxProfit;
        }

        //136. Single Number
        //Hash Table, Bit Manipulation
        public int SingleNumber(int[] nums)
        {
            var singleNumber = 0;

            //XOR 聯集後去除交集 對同一物件連續兩次XOR 即可得到自身
            foreach (var num in nums)
            {
                singleNumber ^= num;
            }

            return singleNumber;
        }

        //138. Copy List with Random Pointer
        //Hash Table, Linked List
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
        public Node GetNodes()
        {
            Node node1 = new Node(7);
            Node node2 = new Node(13);
            Node node3 = new Node(11);
            Node node4 = new Node(10);
            Node node5 = new Node(1);

            node1.next = node2;
            node1.random = null;
            node2.next = node3;
            node2.random = node1;
            node3.next = node4;
            node3.random = node5;
            node4.next = node5;
            node4.random = node3;
            node5.next = null;
            node5.random = node1;

            return node1;
        }
        public Node CopyRandomList(Node head)
        {
            Dictionary<Node, Node> dict = new Dictionary<Node, Node>();

            Node dummy = new Node(Int32.MinValue);
            Node current = dummy;
            Node original = head;

            while (original != null)
            {
                Node temp = new Node(original.val);

                dict.Add(original, temp);

                original = original.next;
                current.next = temp;
                current = current.next;
            }

            original = head;

            while (original != null)
            {
                dict[original].random = original.random == null ? null : dict[original.random];

                original = original.next;
            }

            return dummy.next;
        }
    }
}