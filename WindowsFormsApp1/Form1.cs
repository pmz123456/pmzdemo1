using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static Thread t1;
        private void button1_Click(object sender, EventArgs e)
        {
            #region
            //t1 = new Thread(() =>
            //{
            //    try
            //    {
            //        while (true)
            //        {
            //            MessageBox.Show("ok");
            //            Thread.Sleep(1000);

            //        }
            //    }
            //    catch (ThreadAbortException ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //});
            //t1.Start();

            //System.Threading.ThreadPool.QueueUserWorkItem((statte) =>
            //{
            //    System.Net.WebClient cl = new System.Net.WebClient();
            //    string s = cl.DownloadString("http://www.rupeng.com");
            //    this.BeginInvoke(new Action(() =>
            //    {

            //        textBox1.Text = s;

            //    }));
            //});

            #endregion

            //FileStream fs = File.OpenRead(@"C:\Users\Administrator\Desktop\1.txt");

            //byte[] buffer = new byte[16];
            //Task<int> len = fs.ReadAsync(buffer, 0, buffer.Length);
            //len.Wait();

            //MessageBox.Show(Encoding.Default.GetString(buffer));

            //WebClient wc = new WebClient();
            //Task<string> html = wc.DownloadStringTaskAsync("http://www.rupeng.com");
            //html.Wait();
            //MessageBox.Show(html.Result);

            HttpClient cl = new HttpClient();



            Task<string> html = cl.GetStringAsync("http://www.rupeng.com");
            MessageBox.Show(html.Result);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //t1.Abort();
        }
    }
}
