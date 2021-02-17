using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Delegate
        DelegateTest DelegateTest;
        public delegate string MyDelegate(int argument);
        public MyDelegate MyDelegateObject;

        private void button_Delegate_Click(object sender, EventArgs e)
        {
            //委派兩個函式

            DelegateTest = new DelegateTest();
            MyDelegateObject += DelegateTest.Method1;
            MyDelegateObject += DelegateTest.Method2;

            var result = MyDelegateObject.Invoke(123);

            return;
        }
        #endregion

        #region Event
        EventTest EventTest;
        public delegate void ClickEventHandler(object sender, MyEventArgs e);
        public event ClickEventHandler ClickEvent;
        private void button_EventTest_Click(object sender, EventArgs e)
        {
            EventTest = new EventTest();
            ClickEvent += EventTest.button1_Click;
            ClickEvent += EventTest.button2_Click;

            var myEventArgs = new MyEventArgs("ABC");

            ClickEvent(this, myEventArgs);

            return;
        }
        public class MyEventArgs : EventArgs
        {
            private string arg1;
            public MyEventArgs(string arg1) : base()
            {
                this.arg1 = arg1;
            }
          
            public string Arg1
            {
                get 
                { 
                    return arg1; 
                }
            }
        }   

        #endregion

        #region Easy
        Easy Easy;
        
        private void button_LeetCodeEasy_Click(object sender, EventArgs e)
        {
            Easy = new Easy();

            var strs = new List<string>();

            strs.Add("c");
            strs.Add("acc");
            strs.Add("ccc");

            var result = Easy.LongestCommonPrefix(strs.ToArray());

            return;
        }


        #endregion

        #region Medium
        Medium Medium;

        private void button_LeetCodeMedium_Click(object sender, EventArgs e)
        {
            Medium = new Medium();

            var array = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            var maxArea = Medium.MaxArea(array);

            return;
        }
        #endregion

        #region Nullable
        private void button_Nullable_Click(object sender, EventArgs e)
        {
            Nullable.GetVariableType();
        }
        #endregion
    }
}
