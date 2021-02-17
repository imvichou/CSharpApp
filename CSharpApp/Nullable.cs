using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpApp
{
    public static class Nullable
    {
        static int? a = 10;
        static int b
        {
            get
            {
                //若a為null則b return 1，若a不為null則 return 10 (a為null賦予新值)
                return a ?? 1;
            }
        }


        public static void GetVariableType()
        {
            var result = a.GetType();

            return;
        }
    }
}
