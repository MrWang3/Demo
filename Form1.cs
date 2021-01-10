using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Demo
{
    public partial class Form1 : Form
    {
        String fName; // 存储打开文件路径
        public Form1()
        {
            InitializeComponent();
        }

        //
        //                       _oo0oo_
        //                      o8888888o
        //                      88" . "88
        //                      (| -_- |)
        //                      0\  =  /0
        //                    ___/`---'\___
        //                  .' \\|     |// '.
        //                 / \\|||  :  |||// \
        //                / _||||| -:- |||||- \
        //               |   | \\\  -  /// |   |
        //               | \_|  ''\---/''  |_/ |
        //               \  .-\__  '-'  ___/-. /
        //             ___'. .'  /--.--\  `. .'___
        //          ."" '<  `.___\_<|>_/___.' >' "".
        //         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
        //         \  \ `_.   \_ __\ /__ _/   .-` /  /
        //     =====`-.____`.___ \_____/___.-`___.-'=====
        //                       `=---='
        //
        //
        //     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //
        //               佛祖保佑         永无BUG
        //
        //
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 转UTF-8
        public static string get_uft8(string unicodeString)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            String decodedString = utf8.GetString(encodedBytes);
            return decodedString;
        }

        // 循环统计文本字符串中某一字符出现的次数
        public int CalauteCharShowCount_For(char c, string text)
        {
            int count = 0; // 定义一个计数器

            // 循环统计
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == c)
                    count++;
            }
            return count;
        }

        // 循环统计文本字符串中某一字符串出现的次数
        // Inputstr：需输入查询字符串
        // text:正则表达式
        public int CalauteStringShowCount_For(string Inputstr, string text)
        {
            int count = 0; // 定义一个计数器
            MatchCollection mc = Regex.Matches(Inputstr, text);

            // 循环统计
            foreach (Match m in mc)
            {
                count++;
            }

            return count;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog(); // 选择文件
            //FolderBrowserDialog fbd = new FolderBrowserDialog(); // 选择文件夹
            //fbd.ShowDialog(); // 选择文件夹
            //textBox1.Text = fbd.SelectedPath;

            openDialog.ShowDialog(); // 选择文件
            textBox1.Text = openDialog.FileName;

            fName = openDialog.FileName;
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // 统计按钮监听事件
        private void Button1_Click_1(object sender, EventArgs e)
        {
            String InputString; // 存储输入字符串
            int count = 0;
            String str1;
            StreamReader Str;

            if (checkBox1.Checked == true)
            {
                Str = new StreamReader(fName, Encoding.UTF8); // 创建一个StreamReader 的实例来读取文件
            }
            else
            {
                Str = new StreamReader(fName, Encoding.Default); // 创建一个StreamReader 的实例来读取文件
            }
                
            InputString = textBox2.Text; // 获取输入字符串

            str1 = Str.ReadToEnd(); // 读取文件中数据


            String[] sArray = InputString.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (string i in sArray)
            {
                count = CalauteStringShowCount_For(str1, @i.ToString()); // 计算字符串出现次数
                richTextBox1.AppendText(i.ToString() + ":" + count.ToString() + "\r\n"); // 显示数据
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            String InputStr = textBox3.Text;
            Byte[] buff = System.Text.Encoding.Default.GetBytes(InputStr);
            String OutputStr = "";

            for (int i= 0; i < buff.Length; i++)
            {
                OutputStr += buff[i].ToString("X2");
            }

            richTextBox1.AppendText(OutputStr + "\r\n"); // 显示数据
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String Inputstr;
            Inputstr = textBox3.Text;
            byte[] buff = new byte[Inputstr.Length / 2];
            int index = 0;

            for (int i = 0; i < Inputstr.Length; i += 2)
            {
                buff[index] = Convert.ToByte(Inputstr.Substring(i, 2), 16);
                index++;
            }

            String OutputStr = Encoding.Default.GetString(buff);

            richTextBox1.AppendText(OutputStr + "\r\n"); // 显示数据
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String Inputstr = textBox3.Text;
            int index = Inputstr.Length/2;

            richTextBox1.AppendText(index + "\r\n"); // 显示数据
        }
    }
}
