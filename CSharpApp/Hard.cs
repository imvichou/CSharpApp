using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpApp
{
    public class Hard
    {
        //10. Regular Expression Matching
        public bool IsMatch(string s, string p)
        {
            var charArray1 = s.ToCharArray();
            var charArray2 = p.ToCharArray();

            var starCount = 0;

            for (int i = 0; i < charArray1.Length; i++)
            {
                var pNewIndex = i + starCount * 2;

                //longer than array's length
                if (pNewIndex > charArray2.Length - 1)
                {
                    return false;
                }

                if (charArray2[pNewIndex] == charArray1[i])
                {
                    if (i == charArray1.Length - 1 && pNewIndex != charArray2.Length - 1)
                    {
                        return false;
                    }
                    
                    continue;
                }
                else if (charArray2[pNewIndex] == '.')
                {
                    if (i == charArray1.Length - 1 && pNewIndex != charArray2.Length - 1)
                    {
                        return false;
                    }

                    continue;
                }
                
                if (pNewIndex + 2 <= charArray2.Length - 1)
                {
                    if (charArray2[pNewIndex + 1] == '*' && charArray2[pNewIndex + 2] == charArray1[i])
                    {
                        starCount++;

                        if (i == charArray1.Length - 1 && pNewIndex + 2 != charArray2.Length - 1)
                        {
                            return false;
                        }

                        continue;
                    }
                }
                
                if (pNewIndex - 1 >= 0) //左邊還有
                {
                    if (charArray2[pNewIndex] == '*' && charArray2[pNewIndex - 1] == charArray1[i])
                    {
                        if (i == charArray1.Length - 1 && pNewIndex != charArray2.Length - 1)
                        {
                            return false;
                        }

                        continue;
                    }
                    else if (charArray2[pNewIndex] == '*' && charArray2[pNewIndex - 1] == '.')
                    {
                        if (i == charArray1.Length - 1 && pNewIndex != charArray2.Length - 1)
                        {
                            return false;
                        }

                        continue;
                    }
                }

                return false;
            }

            return true;
        }
    }
}
