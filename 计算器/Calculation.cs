using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//用这行代码就可以实现混合四则运算
//var a = new System.Data.DataTable().Compute("1+2*3/5", "");
//俺这个小白零零散散写了一百多行
//且此代码有多处bug
//见笑啦
//小源QQ 444168950
namespace 计算器
{
    class Calculation
    {
        private string ysf;
        private double[] array = new double[200];
        public Calculation(string ysf_, double[] array_)
        {
            this.ysf = ysf_;
            this.array = array_;
        }
        public double Result()
        {
            double res=0.0;
            if (this.ysf.Length == 1)//若只有两个数运算
            {
                switch (ysf[0])
                {
                    case '*':
                        res = this.array[0] * this.array[1];
                        break;
                    case '/':
                        res = this.array[0] / this.array[1];
                        break;
                    case '+':
                        res = this.array[0] + this.array[1];
                        break;
                    case '-':
                        res = this.array[0] - this.array[1];
                        break;
                }
            }
            else
            {
                if (Ishasysf('*',this.ysf)) //若运算符里是否含有乘除
                {
                    if (Ishasysf('+',this.ysf)) //若运算符里有加减
                    {
                        this.array = Chenchu(this.ysf, this.array);
                        this.ysf = Quchenchu(this.ysf);
                        res = Result();//递归
                    }
                    else//若运算符里只有乘除
                    {
                        res = Onlyysf(this.ysf, this.array);
                    }
                }
                else//运算符只有加减
                {
                    res = Onlyysf(this.ysf, this.array);
                }
            }
            return res;
        }
        /* 传入ysf为*判断是否含有乘除
         * 传入ysf为+判断是否含有加减
         */
        public bool Ishasysf(char ysf,string ysfs)//判断运算符里是否含有乘除或加减
        {
            char ysf1 = '+';
            char ysf2 = '-';
            if(ysf=='*')
            {
                ysf1 = '*';
                ysf2 = '/';
            }
            foreach(char c in ysfs)
            {
                if (c == ysf1 || c == ysf2)
                {
                    return true;
                }
            }
            return false;
        }
        private double Onlyysf(string ysfs, double[] array)
        {
            for (int i = 0; i < ysfs.Length; i++)
            {
                switch (ysfs[i])
                {
                    case '*':
                        array[0] = array[0] * array[1];
                        array[1] = 0;
                        array = Qu0(array);
                        break;
                    case '/':
                        array[0] = array[0] / array[1];
                        array[1] = 0;
                        array = Qu0(array);
                        break;
                    case '+':
                        array[0] = array[0] + array[1];
                        array[1] = 0;
                        array = Qu0(array);
                        break;
                    case '-':
                        array[0] = array[0] - array[1];
                        array[1] = 0;
                        array = Qu0(array);
                        break;
                }
            }
            return array[0];
        }
        private double [] Chenchu(string ysf,double[]array)//先算乘除
        {
            for (int i = 0; i < ysf.Length; i++)
            {
                if (ysf[i] == '*' || ysf[i] == '/')
                {
                    switch (ysf[i])
                    {
                        case '*':
                            array[i] = array[i] * array[i + 1];
                            array[i + 1] = 0;
                            array = Qu0(array);
                            break;
                        case '/':
                            array[i] = array[i] / array[i + 1];
                            array[i + 1] = 0;
                            array = Qu0(array);
                            break;
                    }
                }
            }
            return array;
        }
        private double[] Jiajian(string ysf, double[] array)//后算加减
        {
            for (int i = 0; i < ysf.Length; i++)
            {
                switch (ysf[i])
                {
                    case '+':
                        array[i] = array[i] + array[i + 1];
                        array[i + 1] = 0;
                        array = Qu0(array);
                        break;
                    case '-':
                        array[i] = array[i] - array[i + 1];
                        array[i + 1] = 0.0;
                        array = Qu0(array);
                        break;
                }
            }
            return array;
        }
        private static double[] Qu0(double [] array)//去除数组中的0
        {
            int h = 0;
            double[] newarray = new double[array.Length];
            foreach (double n in array)
            {
                if (n != 0.0)
                {
                    newarray[h++] = n;
                }
            }
            return newarray;
        }
        private static string Quchenchu(string ysf)//去运算符中的*/
        {
            string newysf = "";
            foreach (char c in ysf)
            {
                if (c != '*' && c != '/')
                {
                    newysf += c;
                }
            }
            return newysf;
        }
    }
}
