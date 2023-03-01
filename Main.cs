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
            AutoStart.Enabled = true;
            AutoStop.Enabled = false;
            this.Text = "4位共阴数码管";
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
                System.Threading.Thread.Sleep(100);
                PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建套接字，参数具体定义参考MSD;
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);//定义目标主机的IP,与端口
                PublicRemote.Connect(ipp);//连接目标主机（服务器）
                Upload(CommandBox.Text, PublicRemote);
                PublicRemote.Close();
            }
            catch {
                button1.Text = "失败";
                System.Threading.Thread.Sleep(500);
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
                Thread thread = new Thread(new ThreadStart(CPUCountProcess));
                thread.Start();
            }
            else if (comboBox1.SelectedIndex == 1)//剩余内存
            {
                Thread thread = new Thread(new ThreadStart(RAMRemainProcess));
                thread.Start();
            }
            else if (comboBox1.SelectedIndex == 2)//已用内存
            {
                Thread thread = new Thread(new ThreadStart(RAMUsedProcess));
                //thread.Start();
            }
            else if (comboBox1.SelectedIndex == 3)//GPU占用
            {

            }
            else if (comboBox1.SelectedIndex == 4)//时间
            {
                Thread thread = new Thread(new ThreadStart(SystemTime));
                thread.Start();
            }
        }

        //public PerformanceCounter CpuOccupied = new PerformanceCounter();
        public void SystemTime()
        {
            PublicRemote.Close();
            try
            {
                //连接目标
                PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);
                PublicRemote.Connect(ipp);

                int dottime=0;
                int dot = 0;

                while (true)
                {
                    System.Threading.Thread.Sleep(50);
                    dottime = dottime + 50;
                    string date = DateTime.Now.ToLocalTime().ToString("HH:mm");
                    string[] a = date.Split(':');
                    int time= int.Parse(a[0]+a[1]);
                    if (dottime >= 500)
                    {
                        dottime = 0;
                        if (dot == 0)
                            dot = 2;
                        else
                            dot = 0;
                    }
                    Upload(ToCode(time,dot, true), PublicRemote);
                }

            }
            catch
            {
                PublicRemote.Close();
                this.Text = "4位共阴数码管";
            }
        }


            public void CPUCountProcess()
        {
            PublicRemote.Close();
            try
            {
                //连接目标
                PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);
                PublicRemote.Connect(ipp);

                //初始化CPU计数器
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                while (true)
                {
                    System.Threading.Thread.Sleep(500);
                    int cpu = (int)cpuCounter.NextValue();
                    Console.WriteLine(cpu);
                    Upload(ToCode(cpu, 0, Variables.AutoFillZero), PublicRemote);
                }
            }
            catch
            {
                PublicRemote.Close();
                this.Text = "4位共阴数码管";
            }
        }
        public void RAMRemainProcess()
        {
            PublicRemote.Close();
            try
            {
                //连接目标
                PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);
                PublicRemote.Connect(ipp);

                //初始化内存计数器
                PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

                while (true)
                {
                    System.Threading.Thread.Sleep(50);
                    int ram = (int)ramCounter.NextValue() / 1;
                    Console.WriteLine(ram);
                    Upload(ToCode(ram,0, Variables.AutoFillZero), PublicRemote);
                }
            }
            catch
            {
                PublicRemote.Close();
                this.Text = "4位共阴数码管";
            }
        }

        public void RAMUsedProcess()
        {
            PublicRemote.Close();
            try
            {
                //连接目标
                PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);
                PublicRemote.Connect(ipp);

                //初始化内存计数器
                PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Committed MBytes");

                while (true)
                {
                    System.Threading.Thread.Sleep(50);
                    int ram = (int)ramCounter.NextValue() / 1;
                    Console.WriteLine(ram);
                    Upload(ToCode(ram, 0, Variables.AutoFillZero), PublicRemote);
                }
            }
            catch
            {
                PublicRemote.Close();
                this.Text = "4位共阴数码管";
            }
        }

        public string ToCode(int number,int dot,bool autofill)
        {
            string tail="0-0-0-0";
            if (dot == 1) tail = "1-0-0-0";
            else if (dot == 2) tail = "0-1-0-0";
            else if (dot == 3) tail = "0-0-1-0";
            else if (dot == 4) tail = "0-0-0-1";
            else if (dot == 12) tail = "1-1-0-0";
            else if (dot == 13) tail = "1-0-1-0";
            else if (dot == 14) tail = "1-0-0-1";
            else if (dot == 23) tail = "0-1-1-0";
            else if (dot == 24) tail = "0-1-0-1";
            else if (dot == 34) tail = "0-0-1-1";
            else if (dot == 123) tail = "1-1-1-0";
            else if (dot == 124) tail = "1-1-0-1";
            else if (dot == 134) tail = "1-0-1-1";
            else if (dot == 1234) tail = "1-1-1-1";

                string numberstr = number.ToString();
            string result = "8-8-8-8-0-0-0-0";
            //Console.WriteLine(numberstr.Substring(0, 1));

            if (autofill)
            {
                if (numberstr.Length == 1)
                {
                    result = "0-0-0-" + numberstr + "-" + tail;
                }
                else if (numberstr.Length == 2)
                {
                    result = "0-0-" + numberstr.Substring(0, 1) + "-"
                        + numberstr.Substring(1, 1) + "-" + tail;
                }
                else if (numberstr.Length == 3)
                {
                    result = "0-" + numberstr.Substring(0, 1) + "-"
                        + numberstr.Substring(1, 1) + "-"
                        + numberstr.Substring(2, 1) + "-" + tail;
                }
                else if (numberstr.Length == 4)
                {
                    result = numberstr.Substring(0, 1) + "-"
                        + numberstr.Substring(1, 1) + "-"
                        + numberstr.Substring(2, 1) + "-"
                        + numberstr.Substring(3, 1) + "-" + tail;
                }
            }
            else 
            {
                if (numberstr.Length == 1)
                {
                    result = "B-B-B-" + numberstr + "-" + tail;
                }
                else if (numberstr.Length == 2)
                {
                    result = "B-B-" + numberstr.Substring(0, 1) + "-"
                        + numberstr.Substring(1, 1) + "-" + tail;
                }
                else if (numberstr.Length == 3)
                {
                    result = "B-" + numberstr.Substring(0, 1) + "-"
                        + numberstr.Substring(1, 1) + "-"
                        + numberstr.Substring(2, 1) + "-" + tail;
                }
                else if (numberstr.Length == 4)
                {
                    result = numberstr.Substring(0, 1) + "-"
                        + numberstr.Substring(1, 1) + "-"
                        + numberstr.Substring(2, 1) + "-"
                        + numberstr.Substring(3, 1) + "-" + tail;
                }
            }

            this.Text = "4位共阴数码管" + " " + result;
            return result;
        }

        private void AutoStop_Click(object sender, EventArgs e)
        {
            AutoStart.Enabled = true;
            AutoStop.Enabled = false;
            PublicRemote.Close();
            this.Text = "4位共阴数码管";
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                Variables.AutoFillZero = true;
            else
                Variables.AutoFillZero = false;
        }
    }
}
