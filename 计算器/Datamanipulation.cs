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
        private Datamanipulation()//私有构造函数
        {
            Count = 0;
            Ysf = "";
            Temp = "";
            this.arrays = new double[200];
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
        public string GetRes()
        {
            var res = new System.Data.DataTable().Compute(Merge(this.ysf, this.arrays), "");
            //取消下面这行注释可使用小源自己写的计算类
            //var res = new Calculation(this.ysf, this.arrays).Result().ToString();
            Temp = Convert.ToString(string.Format("{0:F2}", res));
            count = 0;
            return Temp;
        }
        public string Removearr()
        {
            string rem_res =Convert.ToString(arrays[count]);
            arrays[count] = 0.0;
            count--;
            return rem_res;
        }
        private string Merge(string ysf,double [] arrays)//将运算符和数据合并为字符串，用于Data.DataTable
        {
            string merge_res="";
            for(int i=0;i<ysf.Length;i++)
            {
                if (i == ysf.Length-1)
                {
                    merge_res += Convert.ToString(arrays[i]) + ysf[i] + Convert.ToString(arrays[i + 1]);
                }
                else
                {
                    merge_res += Convert.ToString(arrays[i]) + ysf[i];
                }
            }
            return merge_res;
        }

    }
}
