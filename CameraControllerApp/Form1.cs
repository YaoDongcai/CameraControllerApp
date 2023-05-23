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

                    //打开串口
                    serialPort.Open();

                    //打开串口后设置将不再有效
                    cbBox1.Enabled = false;
                    cbBox2.Enabled = false;
                    cbBox3.Enabled = false;
                    cbBox4.Enabled = false;
                    cbBox5.Enabled = false;


                    btnOpen.Text = "关闭串口";

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    return;
                }
            }
            else //串口处于打开状态
            {

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
            initPortConfs();
            Control.CheckForIllegalCrossThreadCalls = false;
            // 设置接受事件
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            // serialPort.DataReceived += SerialPort_DataReceived;

            serialPort.RtsEnable = true;
            serialPort.DtrEnable = true;
            serialPort.ReadTimeout = 1000;
            // serialPort.WriteTimeout = 1000;
            serialPort.Close();
            
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 端口接受到的数据都会在这里开始比较了
            // 这个里面实际上就是数字即可

        }
    }
}
