using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace UrlTool
{
    public partial class Form1 : Form
    {
        private System.Web.HttpServerUtility oHttpServerUtility = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tbAim.Text = HttpUtility.UrlEncode(tbSource.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDeCode_Click(object sender, EventArgs e)
        {
            try
            {
                tbSource.Text = HttpUtility.UrlDecode(tbAim.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}