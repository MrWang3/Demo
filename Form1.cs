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
        MysqlConnector mc = new MysqlConnector(); // 实例化连接对象

        public Form1()
        {
            InitializeComponent();

            // 设置数据库连接参数
            mc.SetServer("127.0.0.1")
                .SetDataBase("success_rate")
                .SetUserID("root")
                .SetPassword("wangzijian")
                .SetPort("3306")
                .SetCharset("utf-8");
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

        private void Button3_Click(object sender, EventArgs e)
        {
            //String str = "insert into DongBa(request,para_error,getsecure_rq,nofind_plate,notypeIC_card,ICblack,IClowmoney,pay_fail,trade_timeout,trade_success,success_rate) values(1,2,3,4,5,6,7,8,9,10,90.0)";
            string newTableCMD = "CREATE TABLE bases(id INT(11), basename INT(11), category INT(11))";

            mc.MySql_operating(newTableCMD);
        }

        // 统计按钮监听事件
        private void Button1_Click_1(object sender, EventArgs e)
        {
            String InputString; // 存储输入字符串
            int count = 0; // 计算参数在文件中出现的次数
            String str1; // 存储文件中的数据
            int index = 0;

            StreamReader Str = new StreamReader(fName, Encoding.Default); // 创建一个StreamReader 的实例来读取文件
            InputString = textBox2.Text; // 获取输入字符串
            str1 = Str.ReadToEnd(); // 读取文件中数据

            String[] sArray = InputString.Split(new string[] { "\r\n" }, StringSplitOptions.None); // 分割查询参数

            int[] para_count = new int[sArray.Length]; // 存储查询参数个数

            foreach (string i in sArray)
            {
                count = CalauteStringShowCount_For(str1, @i.ToString()); // 计算字符串出现次数
                para_count[index++] = count;
                richTextBox1.AppendText(i.ToString() + ":" + count.ToString() + "\r\n"); // 显示数据
            }
                     
            String str = "insert into DongBa(request,para_error,getsecure_rq,nofind_plate,notypeIC_card,ICblack," +
                "IClowmoney,pay_fail,trade_timeout,trade_success,success_rate) " +
                "values("+para_count[0]+ "," + para_count[1] + ", " + para_count[2] + "," +
                " " + para_count[3] + ", " + para_count[4] + ", " + para_count[5] + "," + 
                para_count[6] + ", " + para_count[7] + ", " + para_count[8] + ", " + 
                para_count[9] + ", " + para_count[10] + ")";


            mc.MySql_operating(str);
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

    }
}
