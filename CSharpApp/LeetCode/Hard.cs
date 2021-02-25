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
            
            
            return false;
        }
        public StarResult GetStarResult(string input, int index)
        {
            var charArray = input.ToCharArray();
     
            var zeroResult = "";
            var oneResult = "";
            var repeatResult = "";

            for (int i = 0; i < charArray.Length; i++)
            {
                if (i == index || i == index - 1)
                {
                    continue;
                }
                
                zeroResult += charArray[i].ToString();
            }

            for (int i = 0; i < charArray.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }

                oneResult += charArray[i].ToString();
            }

            for (int i = 0; i < charArray.Length; i++)
            {
                if (i == index)
                {
                    charArray[i] = charArray[i - 1];
                }

                repeatResult += charArray[i].ToString();
            }

            return new StarResult { ZeroResult = zeroResult, OneResult = oneResult, RepeatResult = repeatResult };
        }

        public class StarResult
        {
            public string ZeroResult { get; set; }
            public string OneResult { get; set; }
            public string RepeatResult { get; set; }
        }
    }
}
