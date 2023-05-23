using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CameraControllerApp
{
    class CameraManager
    {
        private string WebHttpUrl = "http://192.168.0.10:7001/respberry/GPIOController";
        private string CamerType
        {
            get;
            set;
        }
        
        // 初始化网络或者端口是否可用
        public bool InitWebHttp()
        {
            return true;
        }
        //

        public void SendStatus(string status)
        {
            this.CamerType = "webHttp";
            // 发送这个类型 需要知道是什么字段已经开头即可
            if(this.CamerType == "webHttp") // webHttp 网络请求 or serialPort 端口发送
            {
                Dictionary<string, string> map = new Dictionary<string, string>();
                map.Add("send", status);
                var jsonString = map.ToString();
                // 表示为网络请求
                HttpRequest.SendPost(this.WebHttpUrl + "", jsonString);
            } else
            {
                // 表示为端口请求 端口类来实现即可
                // SerialPort.Send()
            }
            // 每次发送请求完成后需要写入当前是否为成功的日志放在一个数据数组list 里面

        }
    }
}
