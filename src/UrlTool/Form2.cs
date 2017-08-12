using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace UrlTool
{
    public partial class Form2 : Form
    {
        private Process p = null;
        private ProcessStartInfo info = null;

        #region DllImport
        //定义设置活动窗口API（SetActiveWindow），设置前台窗口API（SetForegroundWindow）
        [DllImport("user32.dll")]
        private static extern IntPtr SetActiveWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private IntPtr hander = IntPtr.Zero;
        private int lParam = -1;

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
            int hwnd,
            int wMsg,
            int wParam,
            ref int lParam
        );

        [DllImport("user32.dll", EntryPoint = "GetFocus")]
        public static extern int GetFocus();
        #endregion

        #region keybd_event
        private const int KEYEVENTF_EXTENDEDKEY = 0x1;
        private const int KEYEVENTF_KEYUP = 0x2;
        private const int KEYEVENTF_KEYDOWN = 0x00;

        private const int KEY_A = 0x41;
        private const int KEY_S = 0x53;
        private const int KEY_D = 0x44;
        private const int KEY_W = 0x57;

        private const int KEY_J = 0x4A;
        private const int KEY_K = 0x4B;
        private const int KEY_L = 0x4C;

        private const int KEY_U = 0x55;
        private const int KEY_I = 0x49;
        private const int KEY_O = 0x4F;
        // ...................//   You   can   get   these   predefine   parameteres   from   MSDN   

        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(
        byte bVk,
        byte bScan,
        int dwFlags,
        int dwExtraInfo
        );
        #endregion

        #region mouse_event
        const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;// 模拟鼠标左键按下
        const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下
        const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;// 模拟鼠标中键按下
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        [DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        #endregion

        #region 鼠标
        // 移动鼠标
        const int WM_LBUTTONDOWN = 0x0201;
        //按下鼠标左键
        const int WM_LBUTTONUP = 0x0202;
        const int MK_LBUTTON = 0x1;

        #endregion

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //open
            info = new ProcessStartInfo();
            info.FileName = tbFileName.Text.Trim();
            info.Arguments = tbArguments.Text.Trim();
            p = new Process();
            p.StartInfo = info;
            bool bResult = p.Start();
            if (!bResult)
            {
                MessageBox.Show("打开失败");
                return;
            }

            p.WaitForInputIdle();
            hander = p.MainWindowHandle;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbArguments.Text = openFileDialog1.FileName;
            }
        }

        private void btnSendKeys_Click(object sender, EventArgs e)
        {
            //SendKeys--C#
            SetActiveWindow(hander);
            SetForegroundWindow(hander);
            System.Threading.Thread.Sleep(100);
            
            SendKeys.SendWait(tbKeys.Text.Trim());
            SendKeys.Flush();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            p.CloseMainWindow();
            p.Close();

        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            // MouseButtons.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SendKeys--API方式
            SetActiveWindow(hander);
            SetForegroundWindow(hander);
            System.Threading.Thread.Sleep(100);

            keybd_event(KEY_U, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(KEY_U, 0, KEYEVENTF_KEYUP, 0);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Mouse--API方式
            SetActiveWindow(hander);
            SetForegroundWindow(hander);
            System.Threading.Thread.Sleep(100);

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            //Mouse--SendMessage
            SetActiveWindow(hander);
            SetForegroundWindow(hander);
            System.Threading.Thread.Sleep(100);

            int hd = Convert.ToInt32(tbHander.Text.Trim(), 16);
            lParam = 0;
            int iResult = SendMessage(hd, WM_LBUTTONDOWN, MK_LBUTTON, ref lParam);
            SendMessage(hd, WM_LBUTTONUP, 0, ref lParam);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetActiveWindow(hander);
            SetForegroundWindow(hander);
            System.Threading.Thread.Sleep(100);

            int hd = GetFocus();

        }


    }
}