using System;
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


        //11. Container With Most Water (Time Limit Exceeded)
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

                    if(maxLength < length)
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
    }
}
