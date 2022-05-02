using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace LEDSegmentDisplay_Remote
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            //跨线程调用窗体组件无视警告
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ButtonSend));
            thread.Start();
        }

        public void ButtonSend()
        {
            try
            {
                button1.Enabled = false;
                button1.Text = "处理中...";
                Socket Remote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建套接字，参数具体定义参考MSD;
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);//定义目标主机的IP,与端口
                Remote.Connect(ipp);//连接目标主机（服务器）
                Upload(CommandBox.Text, Remote);
                Remote.Close();
            }
            catch {
                button1.Text = "失败";
                System.Threading.Thread.Sleep(1000);
            }
            button1.Enabled = true;
            button1.Text = "发送";
        }

        public void Upload(string message,Socket Remote)
        {
            Remote.Send(Tobt(message));//向目标机发送消息
        }

        static byte[] Tobt(string mgs)
        {
            byte[] cmgs = Encoding.UTF8.GetBytes(mgs);
            return cmgs;
        }

        private void PortBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Variables.Port = int.Parse(PortBox.Text);
            }
            catch { }
        }

        private void PortBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void IPBox_TextChanged(object sender, EventArgs e)
        {
            Variables.IP = IPBox.Text;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AutoStart.Enabled = false;
            AutoStop.Enabled = true;
            if(comboBox1.SelectedIndex==0)//CPU占用
            { 
                
            }
            else if (comboBox1.SelectedIndex == 1)//已用内存
            {

            }
            else if (comboBox1.SelectedIndex == 2)//剩余内存
            {

            }
            else if (comboBox1.SelectedIndex == 3)//GPU占用
            {

            }
            else if (comboBox1.SelectedIndex == 4)//时间
            {

            }
        }



    }
}
