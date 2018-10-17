using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 计算器
{
    public partial class Form1 : Form
    {
        Datamanipulation data;
        private void Inputinarr(string str)//按运算符键后
        {
            if (label1.Text == "" || data.Temp=="" )
            {
                MessageBox.Show("输入有误，请重新输入！","错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                label1.Text = "";
                return;
            }
            else
            {
                data.Insertarray();
            }
            label1.Text += str;
            data.Ysf += str;
        }

        private void Showtext(string str)//按数字键后
        {
            label1.Text += str;
            data.Temp += str;
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            data = Datamanipulation.GetDatamanipulation;//单例模式
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Showtext("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Showtext("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Showtext("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Showtext("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Showtext("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Showtext("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Showtext("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Showtext("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Showtext("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Showtext("0");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Showtext(".");
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Inputinarr("+");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Inputinarr("-");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Inputinarr("*");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Inputinarr("/");
        }
        private void button11_Click(object sender, EventArgs e)//%
        {
            label1.Text += "%";
            if (data.Temp != "")
            {
                data.Temp = (Convert.ToDouble(data.Temp) / 100).ToString();
            }
            else
            {
                return;
            }
        }

        private void button19_Click(object sender, EventArgs e)//=操作
        {
            if (label1.Text == "")
            {
                return;
            }
            label1.Text += "=";
            if (data.Temp != "")
            {
                data.Insertarray();
            }
            label1.Text += data.GetRes();
            data.ClearArrayAndYsf();//清空运算符和数组
        }
        private void button18_Click(object sender, EventArgs e)//删除键
        {
            if(label1.Text.IndexOf('=')!=-1)
            {
                label1.Text = "";
                data.Clear();
                return;
            }
            if (data.Temp != "")
            {
                data.Temp = data.Temp.Remove(data.Temp.Length - 1, 1);
                label1.Text = label1.Text.Remove(label1.Text.Length - 1, 1);
            }
            else if(data.Ysf!="")
            {
                data.Ysf = data.Ysf.Remove(data.Ysf.Length - 1, 1);
                label1.Text = label1.Text.Remove(label1.Text.Length - 1, 1);
                data.Temp = data.Removearr();
            }
            else if(label1.Text!="" && data.Ysf == "")
            {
                data.Temp = data.Removearr();
                data.Temp = data.Temp.Remove(data.Temp.Length - 1, 1);
                label1.Text = label1.Text.Remove(label1.Text.Length - 1, 1);
            }
            else
            {
                return;
            }
        }

        private void button17_Click(object sender, EventArgs e)//清屏CE操作
        {
            label1.Text = "";
            data.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出本软件吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.StartPosition = FormStartPosition.CenterScreen;
            abt.Show();
        }
    }
}
