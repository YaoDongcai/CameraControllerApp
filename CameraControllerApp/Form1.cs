using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;	// 用于构建JSON对象

namespace CameraControllerApp
{
    public partial class MainForm : Form
    {
        private CameraManager Camera = new CameraManager();
        SerialPort serialPort = new SerialPort();
        public MainForm()
        {
            InitializeComponent();
        }
        private void initPortConfs()
        {
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口", "Error");
                return;
            }

            // 开始添加串口
            foreach (string s in str)
            {
                this.cbBox1.Items.Add(s);
            }
            // 设置默认串口位第一个
            cbBox1.SelectedIndex = 0;

            string[] baudRate =
            {
                "9600", "19200", "38400", "57600","115200"
            };
            foreach (string item in baudRate)
            {
                cbBox2.Items.Add(item);
            }
            cbBox2.SelectedIndex = 0;

            /*------数据位设置-------*/
            string[] dataBit = { "5", "6", "7", "8" };
            foreach (string s in dataBit)
            {
                cbBox3.Items.Add(s);
            }
            cbBox3.SelectedIndex = 3;


            /*------校验位设置-------*/
            string[] checkBit = { "None", "Even", "Odd", "Mask", "Space" };
            foreach (string s in checkBit)
            {
                cbBox4.Items.Add(s);
            }
            cbBox4.SelectedIndex = 0;


            /*------停止位设置-------*/
            string[] stopBit = { "1", "1.5", "2" };
            foreach (string s in stopBit)
            {
                cbBox5.Items.Add(s);
            }
            cbBox5.SelectedIndex = 0;

        }
        // 初始化一些网络信息
        private void initHttpConfs()
        {
            cbBoxTimeMode.Items.Clear();
            cbBoxTimeMode.Items.Add("秒"); // 默认就是秒即可
            cbBoxTimeMode.SelectedIndex = 0; // 默认就是选择即可

            cbBoxCameraMode.Items.Clear();

            string[] modes = {
                "P", "AV", "TV", "AUTO"
            };
            foreach(string s in modes)
            {
                cbBoxCameraMode.Items.Add(s);
            }
            cbBoxCameraMode.SelectedIndex = 0; // 默认也是第一个即可
        }
        private void btnOn_Click(object sender, EventArgs e)
        {
            Camera.SendStatus("on");
        }
        // 刷新端口
        private void btnFresh_Click(object sender, EventArgs e)
        {
            // 刷新的时候 应该先要判断是否当前的端口正在工作 ;
            if (serialPort.IsOpen)
            {
                MessageBox.Show("请先关闭串口", "Error");
                return;
            }
            cbBox1.Text = "";
            cbBox1.Items.Clear();

            // 重新获取
            string[] arrs = SerialPort.GetPortNames();
            if (arrs == null)
            {
                MessageBox.Show("本机没有串口", "Error");
                return;
            }
            // 重新开始添加
            foreach (string item in arrs)
            {
                cbBox1.Items.Add(item);
            }
            // 只是更新当前的串口默认值即可;
            cbBox1.SelectedIndex = 0;
        }
        // 打开或者关闭端口
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // 打开端口
            if (!serialPort.IsOpen)//串口处于关闭状态
            {

                try
                {

                    if (cbBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Error: 无效的端口,请重新选择", "Error");
                        return;
                    }
                    string strSerialName = cbBox1.SelectedItem.ToString();
                    string strBaudRate = cbBox2.SelectedItem.ToString();
                    string strDataBit = cbBox3.SelectedItem.ToString();
                    string strCheckBit = cbBox4.SelectedItem.ToString();
                    string strStopBit = cbBox5.SelectedItem.ToString();

                    Int32 iBaudRate = Convert.ToInt32(strBaudRate);
                    Int32 iDataBit = Convert.ToInt32(strDataBit);

                    serialPort.PortName = strSerialName;//串口号
                    serialPort.BaudRate = iBaudRate;//波特率
                    serialPort.DataBits = iDataBit;//数据位



                    switch (strStopBit)            //停止位
                    {
                        case "1":
                            serialPort.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            serialPort.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            serialPort.StopBits = StopBits.Two;
                            break;
                        default:
                            MessageBox.Show("Error：停止位参数不正确!", "Error");
                            break;
                    }
                    switch (strCheckBit)             //校验位
                    {
                        case "None":
                            serialPort.Parity = Parity.None;
                            break;
                        case "Odd":
                            serialPort.Parity = Parity.Odd;
                            break;
                        case "Even":
                            serialPort.Parity = Parity.Even;
                            break;
                        default:
                            MessageBox.Show("Error：校验位参数不正确!", "Error");
                            break;
                    }


                    /**
                     * 
                    if (saveDataFile != null)
                    {
                        saveDataFS = File.Create(saveDataFile);
                    }*/

                    try
                    {
                        //打开串口
                        serialPort.Open();
                    }catch(IOException msg)
                    {
                        MessageBox.Show("当前的端口不可用", "Error");
                        return;
                    }

                    //打开串口后设置将不再有效
                    cbBox1.Enabled = false;
                    cbBox2.Enabled = false;
                    cbBox3.Enabled = false;
                    cbBox4.Enabled = false;
                    cbBox5.Enabled = false;

                    btnFresh.Enabled = false;
                    btnOpen.Text = "关闭串口";
                    Camera.CamerType = "serialPort";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    return;
                }
            }
            else //串口处于打开状态
            {
                Camera.CamerType = "webHttp";
                serialPort.Close();//关闭串口
                //串口关闭时设置有效
                cbBox1.Enabled = true;
                cbBox2.Enabled = true;
                cbBox3.Enabled = true;
                cbBox4.Enabled = true;
                cbBox5.Enabled = true;
                
                btnFresh.Enabled = true;

                btnOpen.Text = "打开串口";
                /**
                 * 
                if (saveDataFS != null)
                {
                    saveDataFS.Close(); // 关闭文件
                    saveDataFS = null;//释放文件句柄
                }*/

            }
        }
        
        // 串口load 的时候开始设置的函数
        private void MainForm_Load(object sender, EventArgs e)
        {
            initHttpConfs();
            initPortConfs();
            Control.CheckForIllegalCrossThreadCalls = false;
            // 设置接受事件
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            // serialPort.DataReceived += SerialPort_DataReceived;

            serialPort.RtsEnable = true;
            serialPort.DtrEnable = true;
            serialPort.ReadTimeout = 2000;
            // serialPort.WriteTimeout = 1000;
            serialPort.Close();
            // 缓存这个变量到manager 里面去
            Camera.serialPort = serialPort;
            // 设置模式为webHttp
            Camera.CamerType = "webHttp";
                 
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 端口接受到的数据都会在这里开始比较了
            // 这个里面实际上就是数字即可

        }
        // 相机初始化
        private void btnHttpInit_Click(object sender, EventArgs e)
        {
            // 需要判断是否为网络请求还是端口请求的初始化
            if(serialPort.IsOpen) 
            {
                // 如果是端口打开了 那么就是端口初始化
                Camera.CamerType = "serialPort"; // 表示为端口
            }else
            {
                Camera.CamerType = "webHttp";
            }
            // 后面其实就是Camera 来发送就可以了 把这个逻辑放在CamerManager 里面即可
           var result =  Camera.SendStatus("init");
            if (!result.Contains("Error"))
            {
                var ResJson
                    = JsonConvert.DeserializeObject<ResponseResult>(result);
                // 获取对应的数据设置即可
                var workType = ResJson.data.workType;
                var isSetTime = ResJson.data.isSetTime;
                var unit = ResJson.data.unit; // 只会是秒
                var defineTime = ResJson.data.defineTime;
                // 开始设置界面上的数据类型为这个即可
                tbTime.Text = "" + defineTime;
                switch(workType)
                {
                    case "P":
                        cbBoxCameraMode.SelectedIndex = 0;
                        break;
                    case "AV":
                        cbBoxCameraMode.SelectedIndex = 1;
                        break;
                    case "TV":
                        cbBoxCameraMode.SelectedIndex = 2;
                        break;
                    case "AUTO":
                        cbBoxCameraMode.SelectedIndex = 3;
                        break;
                    default:
                        break;
                }
                // 是否为定时 如果是定时 那么就不能再设置定时了
                // isSetTime 
            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("off");
            if (!result.Contains("Error"))
            {
                
            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnPlayPhoto_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("photo");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnCameraModeOK_Click(object sender, EventArgs e)
        {
            // 相机模式的话 需要获取选择的相机模式即可
            string mode = cbBoxCameraMode.SelectedItem.ToString();
            var result = Camera.SendStatus(mode);
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnIntervalPlayPhoto_Click(object sender, EventArgs e)
        {
            // 定时拍照需要先获取时间 然后时间模式
            var tData = tbTime.Text.ToString();
            if(tData == "")
            {
                MessageBox.Show("请输入数字", "Error");
                return;
            }
            // 开始设置即可
            try
            {
                int time = Convert.ToInt16(tData);
            }
            catch(FormatException exception)
            {
                MessageBox.Show(exception.Message + "");
            }
            // 获取到这个时间后 需要自己组装str;

            var result = Camera.SendStatus("off");

            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnStopInterval_Click(object sender, EventArgs e)
        {
            // 停止时间拍照
            var result =  Camera.SendStatus("off");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuUp");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuOn");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuLeft");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuRight");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuDown");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnMenuOk_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuOk");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDownStart_Click(object sender, EventArgs e)
        {
            // 开始下载
            var result = Camera.SendStatus("off");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }

        private void btnDownEnd_Click(object sender, EventArgs e)
        {
            // 下载结束
            var result = Camera.SendStatus("off");
            if (!result.Contains("Error"))
            {

            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }
    }
}
