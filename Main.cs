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
using System.Threading;

using System.Diagnostics;

namespace LEDSegmentDisplay_Remote
{
    public partial class Main : Form
    {
        Socket PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
                PublicRemote.Close();
                
                PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建套接字，参数具体定义参考MSD;
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);//定义目标主机的IP,与端口
                PublicRemote.Connect(ipp);//连接目标主机（服务器）
                Upload(CommandBox.Text, PublicRemote);
                PublicRemote.Close();
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
                Thread thread = new Thread(new ThreadStart(CPUProcess));
                thread.Start();
            }
            else if (comboBox1.SelectedIndex == 1)//已用内存
            {
                Thread thread = new Thread(new ThreadStart(RAMProcess));
                thread.Start();
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

        //public PerformanceCounter CpuOccupied = new PerformanceCounter();

        public void CPUProcess()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                PerformanceCounter ramCounter;
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");


                Console.WriteLine("电脑可使用内存：" + ramCounter.NextValue() + "MB");
                Console.WriteLine();

            }
        }
        public void RAMProcess()
        {
            PublicRemote.Close();
            try
            {
                //创建套接字，参数具体定义参考MSD;
                PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);//定义目标主机的IP,与端口
                PublicRemote.Connect(ipp);//连接目标主机（服务器）
                
                while (true)
                {
                    System.Threading.Thread.Sleep(50);
                    PerformanceCounter ramCounter;
                    ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                    
                    int ram = (int)ramCounter.NextValue() / 1;
                    Console.WriteLine(ram);
                    Upload(ToCode(ram), PublicRemote);
                }
            }
            catch
            {
                PublicRemote.Close();
            }
        }

        public string ToCode(int number)
        {
            string numberstr = number.ToString();
            string result = "8-8-8-8-0-0-0-0";
            //Console.WriteLine(numberstr.Substring(0, 1));
            if (numberstr.Length == 1)
            {
                result = "0-0-0-" + numberstr + "-0-0-0-0";
            }
            else if (numberstr.Length == 2)
            {
                result = "0-0-"+ numberstr.Substring(0, 1)+"-" 
                    + numberstr.Substring(1, 1) + "-0-0-0-0";
            }
            else if (numberstr.Length == 3)
            {
                result = "0-"+ numberstr.Substring(0, 1) + "-"
                    + numberstr.Substring(1, 1) + "-"
                    + numberstr.Substring(2,1) + "-0-0-0-0";
            }
            else if (numberstr.Length == 4)
            {
                result = numberstr.Substring(0, 1)+ "-"
                    + numberstr.Substring(1, 1) + "-"
                    + numberstr.Substring(2, 1) + "-"
                    + numberstr.Substring(3, 1) + "-0-0-0-0";
            }
            return result;
        }

        private void AutoStop_Click(object sender, EventArgs e)
        {
            AutoStart.Enabled = true;
            AutoStop.Enabled = false;
            PublicRemote.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
