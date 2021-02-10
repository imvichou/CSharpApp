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
        public MyDelegate MyDelegateObject;
        public delegate string MyDelegate(int argument);
        
        private void button_Delegate_Click(object sender, EventArgs e)
        {
            DelegateTest = new DelegateTest();
            MyDelegateObject = DelegateTest.Method1;

            var result = MyDelegateObject.Invoke(123);

            return;
        }
        #endregion

        #region LeetCodeEasy
        Easy Easy;
        
        private void button_LeetCodeEasy_Click(object sender, EventArgs e)
        {
            var result = Easy.IsPalindrome(12321);

            return;
        }


        #endregion

        private void button_Nullable_Click(object sender, EventArgs e)
        {

        }
    }
}
