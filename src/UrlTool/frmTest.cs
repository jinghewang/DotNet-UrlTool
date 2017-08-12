using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UrlTool
{
    public unsafe partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        private void frmTest_Load(object sender, EventArgs e)
        {

            #region 指针
            int* ip;
            int ii = 2;
            ip = &ii;
            //MessageBox.Show((*ip).ToString());

            //分配p1一个100的大小
            int* p1 = stackalloc int[100];
            //赋值操作
            for (int i = 0; i < 100; i++)
            {
                p1[i] = i;
            }
            //测试内容
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(p1[i]);
                Console.WriteLine(*(p1 + i));
            }

            RECT* rect;
            RECT r = new RECT();
            r.left = 1;
            r.right = 2;

            rect = &r;

            int l = rect->left;
            (*rect).left = 10;
            int ll = (*rect).left;
            #endregion

            //llll----1819044972----0x6c6c6c6c
            //wjh王景鹤

            int i10 = 1819044972;
            string iStr = "wjh王景鹤";


            string rx = Encode("王");

            //string sre = Int2String(i10);
            //string sre2 = Int2String2(i10);

            //int iRe = this.String2Int(sre);
            //int iiRe = this.String2Int2(sre);
            //string oStr = string.Empty;

            //char ch = 'a'; 
            //short iic = 65;


            //Console.WriteLine("The ASCII code of \'" + ch + "\' is: " + (short)ch + "\n");
            //Console.WriteLine("ASCII is " + iic.ToString() + ", the char is: " + (char)iic + "\n"); 

            //char cn = '中'; 
            //short uc = 22478;
            //Console.WriteLine("The Unicode of \'" + cn + "\' is: " + (short)cn + "\n");
            //Console.WriteLine("Unicode is " + uc.ToString() + ", the char is: " + (char)uc + "\n");

        }

        #region Byte[]方式
        /// <summary>
        /// 10进制数转换为字符串
        /// </summary>
        /// <param name="i10"></param>
        /// <returns></returns>
        private string Int2String(int i10)
        {
            //llll----1819044972----0x6c6c6c6c
            string s16 = Convert.ToString(i10, 16);

            Byte[] bytes = new Byte[s16.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (Byte)Convert.ToInt32(s16.Substring(i * 2, 2), 16);
            }

            return Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 字符串转换为10进制整数
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns></returns>
        private int String2Int(string sIn)
        {
            //llll----1819044972----0x6c6c6c6c
            Byte[] bytes = Encoding.Default.GetBytes(sIn);
            string re = string.Empty;
            for (int i = 0; i < bytes.Length; i++)
            {
                re += Convert.ToString((int)bytes[i], 16);
            }

            return Convert.ToInt32(re, 16);
        }
        #endregion

        #region Char方式
        /// <summary>
        /// 10进制数转换为字符串
        /// </summary>
        /// <param name="i10"></param>
        /// <returns></returns>
        private string Int2String2(int i10)
        {
            //llll----1819044972----0x6c6c6c6c
            string s16 = Convert.ToString(i10, 16);

            Char[] chars = null;
            string sRe = string.Empty;

            //取得字符数组长度
            int iCharLength = 0;
            for (int i = 0; i < s16.Length / 2; i++)
            {
                int iInt = Convert.ToInt32(s16.Substring(i * 2, 2), 16);
                iCharLength++;
                if (iInt > 127)
                {
                    i++;
                }
            }

            //生成字符数组
            chars = new Char[iCharLength];
            for (int i = 0, j = 0; i < s16.Length / 2; i++, j++)
            {
                int iInt = Convert.ToInt32(s16.Substring(i * 2, 2), 16);

                if (iInt > 127)
                {
                    iInt = Convert.ToInt32(s16.Substring(i * 2, 4), 16);
                    i++;
                }

                chars[j] = (Char)iInt;
                sRe += chars[j].ToString();
            }

            return sRe;
        }

        /// <summary>
        /// 字符串转换为10进制整数
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns></returns>
        private int String2Int2(string sIn)
        {
            //llll----1819044972----0x6c6c6c6c
            Char[] chars = sIn.ToCharArray();
            string re = string.Empty;
            for (int i = 0; i < chars.Length; i++)
            {
                re += Convert.ToString((int)chars[i], 16);
            }

            //byte[] bs = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, Encoding.Unicode.GetBytes(re));
            return Convert.ToInt32(re, 16);
        }
        #endregion

        #region Unicode方式
        /// <summary>
        /// 作用：将字符串内容转化为16进制数据编码，其逆过程是Decode
        /// 参数说明：
        /// strEncode 需要转化的原始字符串
        /// 转换的过程是直接把字符转换成Unicode字符,比如数字"3"-->0033,汉字"我"-->U+6211
        /// 函数decode的过程是encode的逆过程.
        /// </summary>
        /// <param name="strEncode"></param>
        /// <returns></returns>
        public static string Encode(string strEncode)
        {
            string strReturn = "";//  存储转换后的编码
            foreach (short shortx in strEncode.ToCharArray())
            {
                strReturn += shortx.ToString("X4");
            }
            return strReturn;
        }

        /// <summary>
        ///作用：将16进制数据编码转化为字符串，是Encode的逆过程
        /// </summary>
        /// <param name="strDecode"></param>
        /// <returns></returns>
        public static string Decode(string strDecode)
        {
            string sResult = "";
            for (int i = 0; i < strDecode.Length / 4; i++)
            {
                sResult += (char)short.Parse(strDecode.Substring(i * 4, 4), global::System.Globalization.NumberStyles.HexNumber);
            }
            return sResult;
        }
        #endregion


        private void button3_Click(object sender, EventArgs e)
        {
            tbString.Text = this.Int2String(Convert.ToInt32(tbInt.Text.Trim()));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbString2.Text = this.Int2String2(Convert.ToInt32(tbInt2.Text.Trim()));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbInt.Text = this.String2Int(tbString.Text).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbInt2.Text = this.String2Int2(tbString2.Text).ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void frmTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form_Click");
        }

    }
}