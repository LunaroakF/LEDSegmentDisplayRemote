using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDSegmentDisplay_Remote
{
    internal class Variables
    {
        public static string IP = "192.168.0.121";
        public static int Port = 2000;
        public static bool AutoFillZero = true;

        public static String Data_OverStep = "B-B-F-1-0-0-0-0";

        public static String Text_PleaseWait = "处理中...";
        public static String Text_Begin = "开始";
        public static String Text_Title = "4位共阴数码管";
        public static String Text_Done = "完成";
        public static String Text_Fail = "失败";
        public static String Text_Sent = "发送";
    }
}
