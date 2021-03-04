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

            var result = Medium.GenerateParenthesis(3);

            return;
        }
        #endregion

        #region Hard
        Hard Hard;
        private void button_LeetCodeHard_Click(object sender, EventArgs e)
        {
            Hard = new Hard();

            var result = Hard.GetStarResult(new string("a*b*c"), 3);

            return;
        }
        #endregion

        #region Nullable
        private void button_Nullable_Click(object sender, EventArgs e)
        {
            Nullable.GetVariableType();
        }
        #endregion

        #region Algorithm
        Algorithm Algorithm;
        private void button_Alogorithm_Click(object sender, EventArgs e)
        {
            Algorithm = new Algorithm();

            int[] array = { 1000, 11, 445, 1, 330, 3000 };

            Algorithm.MainByCompareinPairs(array);

            return;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var FirstPoint = new Point(100, -100);
            var SecondPoint = new Point(0, 0);

            var CenterPoint = new Point();

            //底邊長度
            var a = Math.Sqrt(Math.Pow((SecondPoint.X - FirstPoint.X), 2) + Math.Pow((SecondPoint.Y - FirstPoint.Y), 2));

            //斜邊長度
            var cosValue = Math.Cos(((double)45/ 180) * Math.PI);

            var b = (a / 2) / cosValue;

            //底邊向量
            var aX = SecondPoint.X - FirstPoint.X;
            var aY = SecondPoint.Y - FirstPoint.Y;

            var m = (double)aY / aX;
            var pM = -1 / m;

            //底邊中點
            var middleX = (SecondPoint.X + FirstPoint.X) / 2;
            var middleY = (SecondPoint.Y + FirstPoint.Y) / 2;

            var constant = middleY - pM * middleX;

            if (FirstPoint.X >= SecondPoint.X && FirstPoint.Y >= SecondPoint.Y)
            {
                for (int i = middleY; i > -9999; i--)
                {
                    var x = (i - constant) / pM;

                    var rSquare = Math.Pow(FirstPoint.X - x, 2) + Math.Pow(FirstPoint.Y - i, 2);

                    if ((rSquare >= Math.Pow(b, 2)))
                    {
                        CenterPoint.X = (int)Math.Round(x);
                        CenterPoint.Y = i;

                        break;
                    }
                }
            }
            else if (FirstPoint.X >= SecondPoint.X && FirstPoint.Y < SecondPoint.Y)
            {
                for (int i = middleY; i > -9999; i--)
                {
                    var x = (i - constant) / pM;

                    var rSquare = Math.Pow(FirstPoint.X - x, 2) + Math.Pow(FirstPoint.Y - i, 2);

                    if ((rSquare >= Math.Pow(b, 2)))
                    {
                        CenterPoint.X = (int)Math.Round(x);
                        CenterPoint.Y = i;

                        break;
                    }
                }
            }
            else if (FirstPoint.X < SecondPoint.X && FirstPoint.Y >= SecondPoint.Y)
            {
                for (int i = middleY; i > 9999; i++)
                {
                    var x = (i - constant) / pM;

                    var rSquare = Math.Pow(FirstPoint.X - x, 2) + Math.Pow(FirstPoint.Y - i, 2);

                    if ((rSquare >= Math.Pow(b, 2)))
                    {
                        CenterPoint.X = (int)Math.Round(x);
                        CenterPoint.Y = i;

                        break;
                    }
                }
            }
            else if (FirstPoint.X < SecondPoint.X && FirstPoint.Y < SecondPoint.Y)
            {
                for (int i = middleY; i > 9999; i++)
                {
                    var x = (i - constant) / pM;

                    var rSquare = Math.Pow(FirstPoint.X - x, 2) + Math.Pow(FirstPoint.Y - i, 2);

                    if ((rSquare >= Math.Pow(b, 2)))
                    {
                        CenterPoint.X = (int)Math.Round(x);
                        CenterPoint.Y = i;

                        break;
                    }
                }
            }

            var angle = CalculateAngle(FirstPoint, SecondPoint, CenterPoint, new Point(100, -99));

            return;
        }
        private double CalculateAngle(Point FirstPoint, Point SecondPoint, Point CenterPoint, Point ThirdPoint)
        {
            //第一條向量
            var aX = FirstPoint.X - CenterPoint.X;
            var aY = FirstPoint.Y - CenterPoint.Y;

            //第二條向量
            var bX = ThirdPoint.X - CenterPoint.X;
            var bY = ThirdPoint.Y - CenterPoint.Y;

            //InnerProduct
            var innerProduct = aX * bX + aY * bY;

            var aLength = Math.Sqrt((Math.Pow(aX, 2) + Math.Pow(aY, 2)));

            var bLength = Math.Sqrt((Math.Pow(bX, 2) + Math.Pow(bY, 2)));

            var cosTheta = innerProduct / (aLength * bLength);

            var intersectionPoint = ClosestIntersection(CenterPoint.X, CenterPoint.Y, (float)aLength, ThirdPoint, CenterPoint);

            //第三條向量
            var cX = intersectionPoint.X - FirstPoint.X;
            var cY = intersectionPoint.Y - FirstPoint.Y;

            //第四條向量
            var dX = SecondPoint.X - intersectionPoint.X;
            var dY = SecondPoint.Y - intersectionPoint.Y;

            return (cX * dX + cY * dY >= 0) ? Math.Acos(cosTheta) * 180 / Math.PI : -1 * Math.Acos(cosTheta) * 180 / Math.PI;
        }

        //cx,cy is center point of the circle 
        public PointF ClosestIntersection(float cx, float cy, float radius, PointF lineStart, PointF lineEnd)
        {
            PointF intersection1;
            PointF intersection2;
            int intersections = FindLineCircleIntersections(cx, cy, radius, lineStart, lineEnd, out intersection1, out intersection2);

            if (intersections == 1)
                return intersection1; // one intersection

            if (intersections == 2)
            {
                double dist1 = Distance(intersection1, lineStart);
                double dist2 = Distance(intersection2, lineStart);

                if (dist1 < dist2)
                    return intersection1;
                else
                    return intersection2;
            }

            return PointF.Empty; // no intersections at all
        }
        private double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
        // Find the points of intersection.
        private int FindLineCircleIntersections(float cx, float cy, float radius, PointF point1, PointF point2, out PointF intersection1, out PointF intersection2)
        {
            float dx, dy, A, B, C, det, t;

            dx = point2.X - point1.X;
            dy = point2.Y - point1.Y;

            A = dx * dx + dy * dy;
            B = 2 * (dx * (point1.X - cx) + dy * (point1.Y - cy));
            C = (point1.X - cx) * (point1.X - cx) + (point1.Y - cy) * (point1.Y - cy) - radius * radius;

            det = B * B - 4 * A * C;
            if ((A <= 0.0000001) || (det < 0))
            {
                // No real solutions.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if (det == 0)
            {
                // One solution.
                t = -B / (2 * A);
                intersection1 = new PointF(point1.X + t * dx, point1.Y + t * dy);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 1;
            }
            else
            {
                // Two solutions.
                t = (float)((-B + Math.Sqrt(det)) / (2 * A));
                intersection1 = new PointF(point1.X + t * dx, point1.Y + t * dy);
                t = (float)((-B - Math.Sqrt(det)) / (2 * A));
                intersection2 = new PointF(point1.X + t * dx, point1.Y + t * dy);
                return 2;
            }
        }
    }
}
