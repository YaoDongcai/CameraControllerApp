using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CameraControllerApp
{
    class CameraManager
    {
        private string WebHttpUrl = "http://127.0.0.1:7003/respberry/";
        public string CamerType
        {
            get;
            set;
        }
        public SerialPort serialPort
        {
            get; set;
        }
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

            }
            return "";
        }
        public void SendStatus(string status)
        {
            // 发送这个类型 需要知道是什么字段已经开头即可
            if(this.CamerType == "webHttp") // webHttp 网络请求 or serialPort 端口发送
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
                        
                        break;
                    case "off":
                        
                        break;
                    case "photo":
                        
                        break;
                    case "menuOn":
                        
                        break;
                    case "menuOff":
                        
                        break;
                    case "menuUp":
                        
                        break;
                    case "menuDown":
                        
                        break;

                    case "menuLeft":
                        
                        break;
                    case "menuRight":
                        
                        break;
                    case "menuOk":
                        
                        break;
                    case "P":
                        
                        break;
                    case "AUTO":
                        
                        break;
                    case "TV":
                        
                        break;
                    case "AV":
                        
                        break;
                }
                // var jsonString = JsonConvert.SerializeObject(map, Formatting.Indented);// jss.Deserialize<Dictionary<string, object>>(map);
                // Console.WriteLine("jsonString" +jsonString);
                // 表示为网络请求
                var result = HttpRequest.SendPost(WebHttpUrl + subUrl, map);
                Console.WriteLine("result"+ result);
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
                    case "TV":
                        SerialPortSendData("AA75550202008A");
                        break;
                    case "AV":
                        SerialPortSendData("AA75550207008F");
                        break;

                }
            }
            // 每次发送请求完成后需要写入当前是否为成功的日志放在一个数据数组list 里面

        }
    }
}
