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
using Newtonsoft.Json.Linq; // 用于构建JSON对象
using System.Threading;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace CameraControllerApp
{
    public partial class MainForm : Form
    {
        private CameraManager Camera = new CameraManager();
        SerialPort serialPort = new SerialPort();
        private string GlobalStr = ""; // 是为了获取当前的所有的数据即可
        private int GlobalLength = 0;
        // 增加一个定时器的功能
        private Timer timer;
        public MainForm()
        {
            InitializeComponent();
            // 开始定义这个timer 定时器即可
            timer = new System.Windows.Forms.Timer();
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
            if(cbBox1.Items.Count >= 1)
            {
                // 设置默认串口位第一个
                cbBox1.SelectedIndex = 0;
            }
            

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
            // listView 的设置
            this.LogListView.FullRowSelect = false;
            ColumnHeader HeaderLoger = new ColumnHeader();
            
            HeaderLoger.Text = "操作日志";
            HeaderLoger.Width = LogListView.Width;
            HeaderLoger.TextAlign = HorizontalAlignment.Left;
            LogListView.Columns.AddRange(new ColumnHeader[] { HeaderLoger });
            
            LogListView.View = View.Details;
        }
        private void btnOn_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("on");
            OutLog(result, "开机");
        }
        public void OutLog(String result, String Name)
        {
            if (!result.Contains("Error"))
            {
                LogListView.Items.Add(new ListViewItem(DateTime.Now.ToString() + "  " + Name + "操作,操作成功"));
            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
                LogListView.Items.Add(new ListViewItem(DateTime.Now.ToString() + "  " + Name + "操作失败，出现异常了。" + result));
            }
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
            if (cbBox1.Items.Count >= 1)
            {
                // 设置默认串口位第一个
                cbBox1.SelectedIndex = 0;
            }
            //cbBox1.SelectedIndex = 0;
            
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
            // 获取ini 文件
            var url = INIhelp.GetValue("URL");
            var isROV = INIhelp.GetValue("ROV");
            if(isROV == "1")
            {
                // 表示为ROV 那么就可以用变焦的功能 否则是不可以的
                focusBtnAdd.Visible = true;
                focusBtnSub.Visible = true;
            }
            Camera.ConfigUrl = url;
            Camera.WebHttpUrl = "http://" + Camera.ConfigUrl + ":7001/respberry/";

            initHttpConfs();
            initPortConfs();
            Control.CheckForIllegalCrossThreadCalls = false;
            // 设置接受事件
            serialPort.ReadBufferSize = 4096 * 2; //接收缓冲区大小
            serialPort.WriteBufferSize = 4096 * 2;
            serialPort.RtsEnable = true;
            serialPort.DtrEnable = true;
            serialPort.ReadTimeout = 8000;
            serialPort.WriteTimeout = 8000;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            // serialPort.DataReceived += SerialPort_DataReceived;

            
            
            // serialPort.Encoding = Encoding.BigEndianUnicode;
            // serialPort.WriteTimeout = 1000;
            serialPort.Close();
            // 缓存这个变量到manager 里面去
            Camera.serialPort = serialPort;
            // 设置模式为webHttp
            Camera.CamerType = "webHttp";      
            // 将文字或者空间都变大一点
            /**
            foreach(Control c in this.Controls)
            {
                int size = (int) c.Font.Size;
                c.Font = new Font("Microsoft Sans Serif", size * 1.2f);
                // 空间的宽度都要增加
                c.Width = c.Width + 20;
                c.Height = c.Height + 10;
            }**/
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 端口接受到的数据都会在这里开始比较了
            // 这个里面实际上就是数字即可
            if(serialPort.IsOpen)
            {
                // 设置日志信息即可
                Console.WriteLine("---dataReceived");
                //dateTimeNow.GetDateTimeFormats();
                // 显示数据的方框
                //textBoxReceive.Text += string.Format("{0}\r\n", dateTimeNow);
                //dateTimeNow.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                //textBoxReceive.ForeColor = Color.Red;    //改变字体的颜色
                int len = serialPort.BytesToRead;
                int buffersize = len;   //十六进制数的大小（假设为6byte）
                byte[] buffer = new byte[buffersize];   //创建缓冲区
                if (len != 0)
                {
                    // 延迟一秒
                    serialPort.Read(buffer, 0, buffersize);    //从com1读取
                    string str = byteToHexStr(buffer);
                    // 这个str 就是我们需要的;
                    if(str.Length > 4 && str.Substring(0, 4) == "AA75")
                    {
                        // 这个时候获取当前的模式或者
                        var hexString
                            = str.Substring(6,2);
                        GlobalLength = Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber); 
                    }

                    if(GlobalStr.Length <GlobalLength * 2 + 10)
                    {
                        GlobalStr += str;
                    }
                    if(GlobalStr.Length == GlobalLength * 2 + 10)
                    {
                        Console.WriteLine("开始初始化了" + GlobalStr);
                        LogHelper.WriteInfoLog("port received:" + GlobalStr);
                        GlobalLength = 0;
                        // 开始处理这个数据即可
                        // 这里的数据需要开始处理
                        switch(GlobalStr.Substring(4,2))
                        {
                            case "2E":
                                // 开始初始化里面的数据即可
                                // 获取时间
                                var isSetTimeStr = GlobalStr.Substring(8, 2);
                                string LogStr = "";
                                // 是否为定时
                               if(isSetTimeStr == "01")
                                {
                                    // 非定时
                                    LogStr += "手动拍照";
                                }else
                                {
                                    // 表示为定时
                                    LogStr += "定时拍照";
                                }
                                var unitStr = GlobalStr.Substring(10, 2);
                                var defineTimeHexStr = GlobalStr.Substring(12, 2);
                                var workType = GlobalStr.Substring(14, 2);

                                // 开始设置数据即可
                                // 需要将hexStr 的数据变成10进制的即可
                                var defineTime = Int32.Parse(defineTimeHexStr, System.Globalization.NumberStyles.HexNumber);
                                // 还需要设置单位即可  
                                
                                tbTime.Text = "" + defineTime;
                                LogStr += "时间为:" + defineTime;
                                // 还需要设置工作模式即可
                                switch (workType)
                                {
                                    case "0A":
                                        // P 模式
                                        LogStr += ",模式为:" + "P模式";
                                        cbBoxCameraMode.SelectedIndex = 0;
                                        break;
                                    case "01":
                                        LogStr += ",模式为:" + "AUTO模式";
                                        cbBoxCameraMode.SelectedIndex = 3;
                                        //str += "AUTO";
                                        break;
                                    case "07":// TV
                                        LogStr += ",模式为:" + "TV模式";
                                        cbBoxCameraMode.SelectedIndex = 2;
                                        //str += "07";
                                        break;
                                    case "02":
                                        LogStr += ",模式为:" + "AV模式";
                                        cbBoxCameraMode.SelectedIndex = 1;
                                        //str += "02"; AV
                                        break;
                                }
                                
                                break;
                        }

                        // 处理完 需要干掉这个buffer;
                        GlobalStr = "";
                    }

                    if(GlobalStr.Length > GlobalLength * 2 + 10)
                    {
                        GlobalLength = 0;
                        GlobalStr = "";
                    }
                }

            }
        }
        public string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X").PadLeft(2, '0');
                }
            }
            return returnStr;
        }
        // 相机初始化
        private void btnHttpInit_Click(object sender, EventArgs e)
        {
            // 需要判断是否为网络请求还是端口请求的初始化
            if(serialPort.IsOpen) 
            {
                // 如果是端口打开了 那么就是端口初始化
                Camera.CamerType = "serialPort"; // 表示为端口
                var result = Camera.SendStatus("init");                             // 后面其实就是Camera 来发送就可以了 把这个逻辑放在CamerManager 里面即可

                OutLog(result, "初始化");
            }
            else
            {
                Camera.CamerType = "webHttp";
                var result = Camera.SendStatus("init");
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
                    switch (workType)
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
                    OutLog(result, "初始化");
                }else
                {
                    OutLog(result, "连接失败");
                }
                // 是否为定时 如果是定时 那么就不能再设置定时了
                // isSetTime 
            }
           
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("off");
            OutLog(result, "关机");
        }

        private void btnPlayPhoto_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("photo");
            OutLog(result, "拍照");
        }

        private void btnCameraModeOK_Click(object sender, EventArgs e)
        {
            // 相机模式的话 需要获取选择的相机模式即可
            string mode = cbBoxCameraMode.SelectedItem.ToString();
            var result = Camera.SendStatus(mode);
            OutLog(result, "设置模式");
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
            var time = 0;
            // 开始设置即可
            try
            {
                 time = Convert.ToInt16(tData);// 设置为毫秒
            }
            catch(FormatException exception)
            {
                MessageBox.Show(exception.Message + "");
            }
            // 获取到这个时间后 需要自己组装str;
            Camera.uatUnit = "01";
            Camera.time = time;
            var result = Camera.SendStatus("Interval");

            OutLog(result, "定时拍照");
        }

        private void btnStopInterval_Click(object sender, EventArgs e)
        {
            // 停止时间拍照
            var result =  Camera.SendStatus("NoPhoto");
            // 其实是需要设置一下当前的数据即可
            OutLog(result, "停止拍照");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuUp");
            OutLog(result, "菜单向上");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuOn");
            OutLog(result, "菜单");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuLeft");
            OutLog(result, "菜单向左");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuRight");
            OutLog(result, "菜单向右");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuDown");
            OutLog(result, "菜单向下");
        }

        private void btnMenuOk_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("menuOk");
            OutLog(result, "菜单确定");
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            // 清除日志
            LogListView.Items.Clear();
            OutLog("", "清除日志");
        }

        private void btnDownStart_Click(object sender, EventArgs e)
        {
            // 开始下载
            // 先关机
            Camera.SendStatus("off");
            // 关机之后 然后再下载开始
            var result = Camera.SendStatus("downloadStart");

            // 需要让开机 关机 定时拍照 拍照的按钮都要禁用
            btnOn.Enabled = false;
            btnOff.Enabled = false;

            btnPlayPhoto.Enabled = false;
            btnIntervalPlayPhoto.Enabled = false;
            if (!result.Contains("Error"))
            {
                OutLog(result, "下载开始");
                Thread thr = new Thread(() =>
                {
                    //这里还可以处理些比较耗时的事情。
                    Thread.Sleep(4000);//休眠时间
                    var url = "ftp://pi:raspberry@" + Camera.ConfigUrl;
                    Console.WriteLine(url);
                    // string url = "https://www.yesdotnet.com";
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.UseShellExecute = false;    //不使用shell启动
                    p.StartInfo.RedirectStandardInput = true;//喊cmd接受标准输入
                    p.StartInfo.RedirectStandardOutput = false;//不想听cmd讲话所以不要他输出
                    p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                    p.StartInfo.CreateNoWindow = true;//不显示窗口
                    p.Start();//向cmd窗口发送输入信息 后面的&exit告诉cmd运行好之后就退出
                    p.StandardInput.WriteLine("explorer.exe " + url + "&exit");
                    p.StandardInput.AutoFlush = true;
                    p.WaitForExit();//等待程序执行完退出进程
                    p.Close();
                    // 然后过个3秒钟 打开ftp
                    //System.Diagnostics.Process.Start(url);
                });
                thr.Start();
            }
            else
            {
                // 包含了Error 那么就是不正常的了
                // 输出日志即可
            }
        }
        private void btnDownEnd_Click(object sender, EventArgs e)
        {
            

            var result = Camera.SendStatus("downloadEnd");
            OutLog(result, "下载结束");
            // 下载结束后才可以开机 延时5秒 因为4秒是持续继电器的时间

            Thread thr = new Thread(() =>
            {
                //这里还可以处理些比较耗时的事情。
                Thread.Sleep(5000);//休眠时间
                                   // 开始开机
                Camera.SendStatus("on");
                // 下载结束
                btnOn.Enabled = true;
                btnOff.Enabled = true;

                btnPlayPhoto.Enabled = true;
                btnIntervalPlayPhoto.Enabled = true;
            });
            thr.Start();
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            // 关闭串口即可
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
        // 变焦+和- 是对于当前的图像设置为对应的属性即可

        private void timerAddTick(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("focusAdd");
            OutLog(result, "变焦+");
        }

        private void timerSubTick(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("focusSub");
            OutLog(result, "变焦-");
        }
        // 变焦+
        private void focusBtnAdd_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("focusAdd");
            OutLog(result, "变焦+");

        }
        // 变焦-
        private void focusBtnSub_Click(object sender, EventArgs e)
        {
            var result = Camera.SendStatus("focusSub");
            OutLog(result, "变焦-");
        }

        private void focusBtnAdd_MouseDown(object sender, MouseEventArgs e)
        {
            // 网络发这个即可 "focusAdd"
            timer.Tick += new EventHandler(timerAddTick);//事件处理
            timer.Enabled = true;//设置启用定时器
            timer.Interval = 200;//执行时间
            timer.Start();//开启定时器
            // 如果是http的请求才可以使用这个 否则端口就不让他使用即可
        }

        private void focusBtnAdd_MouseUp(object sender, MouseEventArgs e)
        {
            // 释放了
            timer.Stop();//停止定时器
            timer.Tick -= new EventHandler(timerAddTick);//取消事件
            timer.Enabled = false;//设置禁用定时器
        }

        private void focusBtnSub_MouseDown(object sender, MouseEventArgs e)
        {
            // 网络发这个即可 "focusAdd"
            timer.Tick += new EventHandler(timerSubTick);//事件处理
            timer.Enabled = true;//设置启用定时器
            timer.Interval = 200;//执行时间
            timer.Start();//开启定时器
        }

        private void focusBtnSub_MouseUp(object sender, MouseEventArgs e)
        {
            // 释放了
            timer.Stop();//停止定时器
            timer.Tick -= new EventHandler(timerSubTick);//取消事件
            timer.Enabled = false;//设置禁用定时器
        }
    }
}
