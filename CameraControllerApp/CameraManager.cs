using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Runtime.Serialization;
using Common;

namespace CameraControllerApp
{
    class CameraManager
    {
        
        public int time;
        public string uatUnit;
        public string CamerType
        {
            get;
            set;
        }
        public SerialPort serialPort
        {
            get; set;
        }

        public string ConfigUrl = "127.0.0.1";

        public string WebHttpUrl = "http://127.0.0.1:7003/respberry/"; // "http://" +ConfigUrl  + ":7003/respberry/";
        // 初始化网络或者端口是否可用
        public bool InitWebHttp()
        {
            return true;
        }
        //
        public String SerialPortSendData(String strSend)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("串口没有打开", "Error");
                return "";
            }
            // 获取我们输入的数据
            // String strSend = "AA75CE020000C3";
            // 应该是利用bytes 来发送数据
            NLogger.Default.Debug("port send:" + strSend);
            Console.WriteLine(strSend);
            byte[] decBytes = new byte[strSend.Length/2];
            for (int i=0; i<strSend.Length; i+=2)
            {
                var s = strSend.Substring(i, 2);
                decBytes[i/2] = Convert.ToByte(s, 16);
            }
            
            Console.WriteLine("decBytes", decBytes);
            // 发送16进制的数据即可
            
            serialPort.Write(decBytes, 0, decBytes.Length);
            /**
            char[] values = strSend.ToCharArray();
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter); // 变成int 类型
                string hexInput
                    = String.Format("{0:X}", value);
                // string hexInput = Convert.ToString((int)letter, 16);
                try
                {
                    serialPort.Write(hexInput);
                }
                catch (TimeoutException ex)
                {
                    MessageBox.Show(ex.Message + "", "Error");
                }

            }**/
            return "";
        }
        public string SendStatus(string status)
        {
            NLogger.Default.Debug("send status:" + status);
            // 发送这个类型 需要知道是什么字段已经开头即可
            if (this.CamerType == "webHttp") // webHttp 网络请求 or serialPort 端口发送
            {
                Dictionary<string, string> map = new Dictionary<string, string>();
                string subUrl = "";
                Console.WriteLine("init");
                switch(status)
                {
                    case "init":
                        // 表示为查询
                        // hex 发送
                        // dateYMD //年月日
                        // 时分秒
                        var dateYMD = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                        var dateHMS = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                        map.Add("dateYMD", dateYMD);
                        map.Add("dateHMS", dateHMS);
                        subUrl = "initGPIOController";
                        break;
                    case "on":
                        subUrl = "GPIOController";
                        map.Add("send", "on");
                        break;
                    case "off":
                        subUrl = "GPIOController";
                        map.Add("send", "off");
                        break;
                    case "photo":
                        subUrl = "GPIOController";
                        map.Add("send", "photo");
                        break;
                    case "menuOn":
                        subUrl = "GPIOController";
                        map.Add("send", "menuOn");
                        break;
                    case "menuOff":
                        subUrl = "GPIOController";
                        map.Add("send", "menuOff");
                        break;
                    case "menuUp":
                        subUrl = "GPIOController";
                        map.Add("send", "menuUp");
                        break;
                    case "menuDown":
                        subUrl = "GPIOController";
                        map.Add("send", "menuDown");
                        break;

                    case "menuLeft":
                        subUrl = "GPIOController";
                        map.Add("send", "menuLeft");
                        break;
                    case "menuRight":
                        subUrl = "GPIOController";
                        map.Add("send", "menuRight");
                        break;
                    case "menuOk":
                        subUrl = "GPIOController";
                        map.Add("send", "menuOk");
                        break;
                    case "focusSub":
                        subUrl = "GPIOController";
                        map.Add("send", "focusSub");
                        break;
                    case "focusAdd":
                        subUrl = "GPIOController";
                        map.Add("send", "focusAdd");
                        break;
                    case "P":
                        subUrl = "GPIOControllerByModel";
                        map.Add("send", "P");
                        break;
                    case "AUTO":
                        subUrl = "GPIOControllerByModel";
                        map.Add("send", "AUTO");
                        break;
                    case "TV":
                        subUrl = "GPIOControllerByModel";
                        map.Add("send", "TV");
                        break;
                    case "AV":
                        subUrl = "GPIOControllerByModel";
                        map.Add("send", "AV");
                        break;
                    case "NoPhoto":// 取消定时
                        subUrl = "GPIOControllerIntertime";
                        map.Add("send", "noPhoto");
                        break;
                    case "Interval": // 定时
                        subUrl = "GPIOControllerIntertime";
                        map.Add("send", "photo");
                        map.Add("defineTime", this.time + "");
                        map.Add("unit", "s");
                        map.Add("timeOut", (this.time * 1000) + "");
                        // map.Add("");
                        break;
                    // 下载开始
                    case "downloadStart":
                        subUrl = "GPIOController";
                        map.Add("send", "downloadStart");
                        break;
                    // 下载结束
                    case "downloadEnd":
                        subUrl = "GPIOController";
                        map.Add("send", "downloadEnd");
                        break;
                }
                var result = HttpRequest.SendPost(WebHttpUrl + subUrl, map);

                return result;
                // var jsonString = JsonConvert.SerializeObject(map, Formatting.Indented);// jss.Deserialize<Dictionary<string, object>>(map);
                // Console.WriteLine("jsonString" +jsonString);
                // 表示为网络请求

            } else
            {
                // 表示为端口请求 端口类来实现即可
                // SerialPort.Send()
                // 表示为查询
                switch(status)
                {
                    case "init":
                        // 表示为查询
                        // hex 发送
                        SerialPortSendData("AA75CE020000C3");
                        break;
                    case "on":
                        SerialPortSendData("AA7522020000FF");
                        break;
                    case "off":
                        SerialPortSendData("AA7522020000FF");
                        break;
                    case "photo":
                        SerialPortSendData("AA7533020000EE");
                        break;
                    case "menuOn":
                        SerialPortSendData("AA7577020000AA");
                        break;
                    case "menuOff":
                        SerialPortSendData("AA758802000055");
                        break;
                    case "menuUp":
                        SerialPortSendData("AA759902000044");
                        break;
                    case "menuDown":
                        SerialPortSendData("AA75AA02000077");
                        break;

                    case "menuLeft":
                        SerialPortSendData("AA75BB02000066");
                        break;
                    case "menuRight":
                        SerialPortSendData("AA75CC02000011");
                        break;
                    case "menuOk":
                        SerialPortSendData("AA75DD02000000");
                        break;
                    case "P":
                        SerialPortSendData("AA7555020A0082");
                        break;
                    case "AUTO":
                        SerialPortSendData("AA755502010089");
                        break;
                    case "AV":
                        SerialPortSendData("AA75550202008A");
                        break;
                    case "TV":
                        SerialPortSendData("AA75550207008F");
                        break;
                    // AA756602000000
                    case "NoPhoto":// 取消定时
                        SerialPortSendData("AA756602000000");
                        break;
                    case "Interval": // 定时
                        var intHex = time.ToString("X");
                        if(intHex.Length == 1)
                        {
                            intHex = "0" + intHex; 
                        }
                        var str = "AA754402" + intHex + "01" + "20";
                        SerialPortSendData(str);
                        break;

                    case "focusSub":
                        SerialPortSendData("AA753E020000E3");
                        break;
                    case "focusAdd":
                        SerialPortSendData("AA754E02000093");
                        break;
                }
                return "success";
            }
            // 每次发送请求完成后需要写入当前是否为成功的日志放在一个数据数组list 里面

        }
    }
}
