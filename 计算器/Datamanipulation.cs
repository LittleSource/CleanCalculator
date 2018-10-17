using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 计算器
{
    class Datamanipulation
    {
        private static Datamanipulation data = new Datamanipulation();
        private static int count;
        private string ysf;
        private string temp;
        private double[] arrays;
        public int Count { get { return count; } set { count = value; } }
        public string Ysf { get { return ysf; } set { ysf = value; } }
        public string Temp { get { return temp; } set { temp = value; } }
        private Datamanipulation()//私有构造函数->单例模式
        {
            Count = 0;
            Ysf = "";
            Temp = "";
            this.arrays = new double[200];//此处可修改最大运算数个数
        }
        public static Datamanipulation GetDatamanipulation
        {
            get { return data; }
        }
        public void Insertarray()/*将之前输入的数字存入数组*/
        {
            arrays[count] = Convert.ToDouble(Temp);
            count++;
            this.temp = "";
        }
        public void ClearArrayAndYsf()//清空运算符和数组
        {
            ysf = "";
            Array.Clear(arrays, 0, arrays.Length);
        }
        public void Clear()
        {
            this.Temp = "";
            this.Count = 0;
            this.ClearArrayAndYsf();
        }
        public string Removearr()
        {
            string rem_res =Convert.ToString(arrays[count]);
            arrays[count] = 0.0;
            count--;
            return rem_res;
        }
        public string GetRes()
        {
            Icalculation cal1 = new Calculation1(this.ysf, this.arrays);
            //也可使用小源自己写的计算类Calculation2
            //Icalculation cal2 = new Calculation2(this.ysf, this.arrays);
            double res = new Context(cal1).Result();
            Temp = Convert.ToString(string.Format("{0:F2}", res));
            count = 0;
            return Temp;
        }
    }
}
