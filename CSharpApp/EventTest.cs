using System;
using System.Collections.Generic;
using System.Text;
using static CSharpApp.Form1;

namespace CSharpApp
{
    public class EventTest
    {
        public void button1_Click(object sender, MyEventArgs e)
        {
            var arg = e.Arg1;
            
            return;
        }

        public void button2_Click(object sender, MyEventArgs e)
        {
            var arg = e.Arg1;

            return;
        }
    }
}
