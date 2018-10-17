using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 计算器
{
    class Calculation1:Icalculation
    {
        private string ysf;
        private double[] array;
        public Calculation1(string ysf_, double[] array_)
        {
            this.ysf = ysf_;
            this.array = array_;
        }
        public double Result()
        {
            var res = new System.Data.DataTable().Compute(Merge(this.ysf, this.array), " ");
            return Convert.ToDouble(res);
        }
        private static string Merge(string ysf, double[] arrays)//将运算符和数据合并为字符串
        {
            string merge_res = "";
            for (int i = 0; i < ysf.Length; i++)
            {
                if (i == ysf.Length - 1)
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
