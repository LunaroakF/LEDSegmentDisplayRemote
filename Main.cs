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
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace LEDSegmentDisplay_Remote
{
    public partial class Main : Form
    {
        Socket PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Main()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//跨线程调用窗体组件无视警告
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AutoStart.Enabled = true;
            AutoStop.Enabled = false;
            this.Text = Variables.Text_Title;
            Thread thread = new Thread(new ThreadStart(ButtonSend));
            thread.Start();
        }
        public void ButtonSend()
        {
            try
            {
                button1.Enabled = false;
                button1.Text = Variables.Text_PleaseWait;
                System.Threading.Thread.Sleep(100);
                ConnectItem();
                Upload(CommandBox.Text, PublicRemote);
                button1.Text = Variables.Text_Done;
                System.Threading.Thread.Sleep(2000);
                PublicRemote.Close();
            }
            catch {
                button1.Text = Variables.Text_Fail;
                System.Threading.Thread.Sleep(500);
            }
            button1.Enabled = true;
            button1.Text = Variables.Text_Sent;
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
            AutoStart.Text = Variables.Text_PleaseWait;
            AutoStop.Enabled = true;
            if (comboBox1.SelectedIndex == 0)//CPU占用
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
                thread.Start();
            }
            else if (comboBox1.SelectedIndex == 3)//GPU内存
            {
                Thread thread = new Thread(new ThreadStart(GPURAMRemainProcess));
                thread.Start();
            }
            else if (comboBox1.SelectedIndex == 4)//时间
            {
                Thread thread = new Thread(new ThreadStart(SystemTime));
                thread.Start();
            }
            else if (comboBox1.SelectedIndex == 5)//下行网速
            {
                Thread thread = new Thread(new ThreadStart(DownloadSpeedProcess));
                thread.Start();
            }
        }
        public void SystemTime()
        {
            try
            {
                ConnectItem();

                int dottime=0;
                int dot = 0;
                AutoStart.Text = Variables.Text_Begin;

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
                this.Text = Variables.Text_Title;
            }
        }
        public void CPUCountProcess()
        {
            try
            {
                ConnectItem();

                //初始化CPU计数器
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                AutoStart.Text = Variables.Text_Begin;

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
                this.Text = Variables.Text_Title;
            }
        }
        public void RAMRemainProcess()
        {
            try
            {
                ConnectItem();

                //初始化内存计数器
                PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

                AutoStart.Text = Variables.Text_Begin;

                while (true)
                {
                    System.Threading.Thread.Sleep(50);
                    int ram = (int)ramCounter.NextValue();
                    Console.WriteLine(ram);
                    Upload(ToCode(ram,0, Variables.AutoFillZero), PublicRemote);
                }
            }
            catch
            {
                PublicRemote.Close();
                this.Text = Variables.Text_Title;
            }
        }
        public void RAMUsedProcess()
        {
            try
            {
                ConnectItem();

                //初始化内存计数器
                PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                int TotalRAM = (int)PerformanceInfo.GetTotalMemoryInMiB();
                AutoStart.Text = Variables.Text_Begin;

                while (true)
                {
                    System.Threading.Thread.Sleep(50);
                    int ram = TotalRAM- (int)ramCounter.NextValue();
                    Console.WriteLine(ram);
                    Upload(ToCode(ram, 0, Variables.AutoFillZero), PublicRemote);
                }
            }
            catch
            {
                PublicRemote.Close();
                this.Text = Variables.Text_Title;
            }
        }
        public void GPURAMRemainProcess()
        {
            try
            {
                ConnectItem();

                //

                while (true)
                {
                    System.Threading.Thread.Sleep(50);
                    //
                    //Console.WriteLine(GPURAM);
                    //Upload(ToCode(GPURAM, 0, Variables.AutoFillZero), PublicRemote);
                }
            }
            catch
            {
                PublicRemote.Close();
                this.Text = Variables.Text_Title;
            }
        }
        public void DownloadSpeedProcess()
        {
            Console.WriteLine("1");
            PublicRemote.Close();
            try
            {
                //连接目标
                PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);
                PublicRemote.Connect(ipp);
                Console.WriteLine("2");
                //初始化下行网速计数器
                PerformanceCounter downloadCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec");
                PerformanceCounter NetworkDownSpe = new PerformanceCounter("Network Interface", "Bytes Received/sec");
                //PerformanceCounter pc2 = new PerformanceCounter("Network Interface", "Bytes Sent/sec");
                Console.WriteLine("3");
                while (true)
                {
                    System.Threading.Thread.Sleep(500);
                    Console.WriteLine(downloadCounter.NextValue().ToString());
                    int down = (int)downloadCounter.NextValue();
                    Console.WriteLine(down);
                    Upload(ToCode(down, 0, Variables.AutoFillZero), PublicRemote);
                }
            }
            catch
            {
                PublicRemote.Close();
                this.Text = Variables.Text_Title;
            }
        }
        public void ConnectItem()//连接目标
        {
            PublicRemote.Close();
            PublicRemote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(Variables.IP), Variables.Port);
            PublicRemote.Connect(ipp);
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
            string result = Variables.Data_OverStep;
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

            this.Text = Variables.Text_Title + " " + result;
            return result;
        }
        private void AutoStop_Click(object sender, EventArgs e)
        {
            AutoStart.Enabled = true;
            AutoStop.Enabled = false;
            PublicRemote.Close();
            this.Text = Variables.Text_Title;
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
    public static class PerformanceInfo
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }

        public static Int64 GetTotalMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }
    }
}
