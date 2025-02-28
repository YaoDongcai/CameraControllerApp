namespace CameraControllerApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCameraModeOK = new System.Windows.Forms.Button();
            this.cbBoxCameraMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBoxTimeMode = new System.Windows.Forms.ComboBox();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStopInterval = new System.Windows.Forms.Button();
            this.btnIntervalPlayPhoto = new System.Windows.Forms.Button();
            this.btnPlayPhoto = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnOn = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnFresh = new System.Windows.Forms.Button();
            this.cbBox5 = new System.Windows.Forms.ComboBox();
            this.cbBox4 = new System.Windows.Forms.ComboBox();
            this.cbBox3 = new System.Windows.Forms.ComboBox();
            this.cbBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnHttpInit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.focusBtnSub = new System.Windows.Forms.Button();
            this.focusBtnAdd = new System.Windows.Forms.Button();
            this.LogListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDownEnd = new System.Windows.Forms.Button();
            this.btnDownStart = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnMenuOk = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btnCameraModeOK);
            this.groupBox1.Controls.Add(this.cbBoxCameraMode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbBoxTimeMode);
            this.groupBox1.Controls.Add(this.tbTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnStopInterval);
            this.groupBox1.Controls.Add(this.btnIntervalPlayPhoto);
            this.groupBox1.Controls.Add(this.btnPlayPhoto);
            this.groupBox1.Controls.Add(this.btnOff);
            this.groupBox1.Controls.Add(this.btnOn);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(281, 613);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机控制";
            // 
            // btnCameraModeOK
            // 
            this.btnCameraModeOK.AutoSize = true;
            this.btnCameraModeOK.Location = new System.Drawing.Point(126, 328);
            this.btnCameraModeOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCameraModeOK.Name = "btnCameraModeOK";
            this.btnCameraModeOK.Size = new System.Drawing.Size(123, 44);
            this.btnCameraModeOK.TabIndex = 12;
            this.btnCameraModeOK.Text = "确定";
            this.btnCameraModeOK.UseVisualStyleBackColor = true;
            this.btnCameraModeOK.Click += new System.EventHandler(this.btnCameraModeOK_Click);
            // 
            // cbBoxCameraMode
            // 
            this.cbBoxCameraMode.FormattingEnabled = true;
            this.cbBoxCameraMode.Location = new System.Drawing.Point(124, 278);
            this.cbBoxCameraMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBoxCameraMode.Name = "cbBoxCameraMode";
            this.cbBoxCameraMode.Size = new System.Drawing.Size(122, 28);
            this.cbBoxCameraMode.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "相机模式";
            // 
            // cbBoxTimeMode
            // 
            this.cbBoxTimeMode.FormattingEnabled = true;
            this.cbBoxTimeMode.Location = new System.Drawing.Point(186, 204);
            this.cbBoxTimeMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBoxTimeMode.Name = "cbBoxTimeMode";
            this.cbBoxTimeMode.Size = new System.Drawing.Size(61, 28);
            this.cbBoxTimeMode.TabIndex = 0;
            this.cbBoxTimeMode.SelectedIndexChanged += new System.EventHandler(this.cbBoxTimeMode_SelectedIndexChanged);
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(124, 200);
            this.tbTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(54, 30);
            this.tbTime.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "拍照间隔";
            // 
            // btnStopInterval
            // 
            this.btnStopInterval.AutoSize = true;
            this.btnStopInterval.Location = new System.Drawing.Point(126, 378);
            this.btnStopInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStopInterval.Name = "btnStopInterval";
            this.btnStopInterval.Size = new System.Drawing.Size(120, 44);
            this.btnStopInterval.TabIndex = 6;
            this.btnStopInterval.Text = "停止拍照";
            this.btnStopInterval.UseVisualStyleBackColor = true;
            this.btnStopInterval.Click += new System.EventHandler(this.btnStopInterval_Click);
            // 
            // btnIntervalPlayPhoto
            // 
            this.btnIntervalPlayPhoto.AutoSize = true;
            this.btnIntervalPlayPhoto.Location = new System.Drawing.Point(2, 378);
            this.btnIntervalPlayPhoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIntervalPlayPhoto.Name = "btnIntervalPlayPhoto";
            this.btnIntervalPlayPhoto.Size = new System.Drawing.Size(122, 44);
            this.btnIntervalPlayPhoto.TabIndex = 5;
            this.btnIntervalPlayPhoto.Text = "定时拍照";
            this.btnIntervalPlayPhoto.UseVisualStyleBackColor = true;
            this.btnIntervalPlayPhoto.Click += new System.EventHandler(this.btnIntervalPlayPhoto_Click);
            // 
            // btnPlayPhoto
            // 
            this.btnPlayPhoto.AutoSize = true;
            this.btnPlayPhoto.Location = new System.Drawing.Point(28, 106);
            this.btnPlayPhoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPlayPhoto.Name = "btnPlayPhoto";
            this.btnPlayPhoto.Size = new System.Drawing.Size(220, 44);
            this.btnPlayPhoto.TabIndex = 2;
            this.btnPlayPhoto.Text = "手动拍照";
            this.btnPlayPhoto.UseVisualStyleBackColor = true;
            this.btnPlayPhoto.Click += new System.EventHandler(this.btnPlayPhoto_Click);
            // 
            // btnOff
            // 
            this.btnOff.AutoSize = true;
            this.btnOff.Location = new System.Drawing.Point(159, 28);
            this.btnOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(90, 44);
            this.btnOff.TabIndex = 1;
            this.btnOff.Text = "关机";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnOn
            // 
            this.btnOn.AutoSize = true;
            this.btnOn.Location = new System.Drawing.Point(28, 28);
            this.btnOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(96, 44);
            this.btnOn.TabIndex = 0;
            this.btnOn.Text = "开机";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1213, 626);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.btnOpen);
            this.groupBox5.Controls.Add(this.btnFresh);
            this.groupBox5.Controls.Add(this.cbBox5);
            this.groupBox5.Controls.Add(this.cbBox4);
            this.groupBox5.Controls.Add(this.cbBox3);
            this.groupBox5.Controls.Add(this.cbBox2);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.cbBox1);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(675, 6);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(236, 616);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "串口控制";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "停止位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "校验位";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "数据位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "波特率";
            // 
            // btnOpen
            // 
            this.btnOpen.AutoSize = true;
            this.btnOpen.Location = new System.Drawing.Point(124, 328);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(111, 44);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "打开端口";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnFresh
            // 
            this.btnFresh.AutoSize = true;
            this.btnFresh.Location = new System.Drawing.Point(16, 328);
            this.btnFresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFresh.Name = "btnFresh";
            this.btnFresh.Size = new System.Drawing.Size(111, 44);
            this.btnFresh.TabIndex = 6;
            this.btnFresh.Text = "刷新端口";
            this.btnFresh.UseVisualStyleBackColor = true;
            this.btnFresh.Click += new System.EventHandler(this.btnFresh_Click);
            // 
            // cbBox5
            // 
            this.cbBox5.FormattingEnabled = true;
            this.cbBox5.Location = new System.Drawing.Point(82, 182);
            this.cbBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbBox5.Name = "cbBox5";
            this.cbBox5.Size = new System.Drawing.Size(136, 28);
            this.cbBox5.TabIndex = 5;
            // 
            // cbBox4
            // 
            this.cbBox4.FormattingEnabled = true;
            this.cbBox4.Location = new System.Drawing.Point(82, 146);
            this.cbBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbBox4.Name = "cbBox4";
            this.cbBox4.Size = new System.Drawing.Size(136, 28);
            this.cbBox4.TabIndex = 4;
            // 
            // cbBox3
            // 
            this.cbBox3.FormattingEnabled = true;
            this.cbBox3.Location = new System.Drawing.Point(82, 108);
            this.cbBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbBox3.Name = "cbBox3";
            this.cbBox3.Size = new System.Drawing.Size(136, 28);
            this.cbBox3.TabIndex = 3;
            // 
            // cbBox2
            // 
            this.cbBox2.FormattingEnabled = true;
            this.cbBox2.Location = new System.Drawing.Point(82, 72);
            this.cbBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbBox2.Name = "cbBox2";
            this.cbBox2.Size = new System.Drawing.Size(136, 28);
            this.cbBox2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "串口";
            // 
            // cbBox1
            // 
            this.cbBox1.FormattingEnabled = true;
            this.cbBox1.Location = new System.Drawing.Point(82, 34);
            this.cbBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbBox1.Name = "cbBox1";
            this.cbBox1.Size = new System.Drawing.Size(136, 28);
            this.cbBox1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnHttpInit);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(364, 114);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(305, 94);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "网络连接";
            // 
            // btnHttpInit
            // 
            this.btnHttpInit.AutoSize = true;
            this.btnHttpInit.Location = new System.Drawing.Point(8, 28);
            this.btnHttpInit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHttpInit.Name = "btnHttpInit";
            this.btnHttpInit.Size = new System.Drawing.Size(291, 44);
            this.btnHttpInit.TabIndex = 13;
            this.btnHttpInit.Text = "连接相机";
            this.btnHttpInit.UseVisualStyleBackColor = true;
            this.btnHttpInit.Click += new System.EventHandler(this.btnHttpInit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.focusBtnSub);
            this.groupBox2.Controls.Add(this.focusBtnAdd);
            this.groupBox2.Controls.Add(this.LogListView);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnClearLog);
            this.groupBox2.Controls.Add(this.btnMenuOk);
            this.groupBox2.Controls.Add(this.btnDown);
            this.groupBox2.Controls.Add(this.btnRight);
            this.groupBox2.Controls.Add(this.btnLeft);
            this.groupBox2.Controls.Add(this.btnMenu);
            this.groupBox2.Controls.Add(this.btnUp);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(673, 653);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "相机设置";
            // 
            // focusBtnSub
            // 
            this.focusBtnSub.AutoSize = true;
            this.focusBtnSub.Location = new System.Drawing.Point(208, 176);
            this.focusBtnSub.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.focusBtnSub.Name = "focusBtnSub";
            this.focusBtnSub.Size = new System.Drawing.Size(102, 38);
            this.focusBtnSub.TabIndex = 10;
            this.focusBtnSub.Text = "变焦(-)";
            this.focusBtnSub.UseVisualStyleBackColor = true;
            this.focusBtnSub.Visible = false;
            this.focusBtnSub.Click += new System.EventHandler(this.focusBtnSub_Click);
            this.focusBtnSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.focusBtnSub_MouseDown);
            this.focusBtnSub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.focusBtnSub_MouseUp);
            // 
            // focusBtnAdd
            // 
            this.focusBtnAdd.AutoSize = true;
            this.focusBtnAdd.Location = new System.Drawing.Point(55, 176);
            this.focusBtnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.focusBtnAdd.Name = "focusBtnAdd";
            this.focusBtnAdd.Size = new System.Drawing.Size(102, 38);
            this.focusBtnAdd.TabIndex = 9;
            this.focusBtnAdd.Text = "变焦(+)";
            this.focusBtnAdd.UseVisualStyleBackColor = true;
            this.focusBtnAdd.Visible = false;
            this.focusBtnAdd.Click += new System.EventHandler(this.focusBtnAdd_Click);
            this.focusBtnAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.focusBtnAdd_MouseDown);
            this.focusBtnAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.focusBtnAdd_MouseUp);
            // 
            // LogListView
            // 
            this.LogListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LogListView.HideSelection = false;
            this.LogListView.Location = new System.Drawing.Point(0, 336);
            this.LogListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogListView.Name = "LogListView";
            this.LogListView.Size = new System.Drawing.Size(666, 282);
            this.LogListView.TabIndex = 8;
            this.LogListView.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "日志显示";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDownEnd);
            this.groupBox3.Controls.Add(this.btnDownStart);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(361, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(305, 84);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据控制";
            // 
            // btnDownEnd
            // 
            this.btnDownEnd.AutoSize = true;
            this.btnDownEnd.Location = new System.Drawing.Point(158, 28);
            this.btnDownEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDownEnd.Name = "btnDownEnd";
            this.btnDownEnd.Size = new System.Drawing.Size(148, 44);
            this.btnDownEnd.TabIndex = 14;
            this.btnDownEnd.Text = "下载结束";
            this.btnDownEnd.UseVisualStyleBackColor = true;
            this.btnDownEnd.Click += new System.EventHandler(this.btnDownEnd_Click);
            // 
            // btnDownStart
            // 
            this.btnDownStart.AutoSize = true;
            this.btnDownStart.Location = new System.Drawing.Point(8, 28);
            this.btnDownStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDownStart.Name = "btnDownStart";
            this.btnDownStart.Size = new System.Drawing.Size(148, 44);
            this.btnDownStart.TabIndex = 13;
            this.btnDownStart.Text = "下载开始";
            this.btnDownStart.UseVisualStyleBackColor = true;
            this.btnDownStart.Click += new System.EventHandler(this.btnDownStart_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.AutoSize = true;
            this.btnClearLog.Location = new System.Drawing.Point(518, 284);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(148, 44);
            this.btnClearLog.TabIndex = 6;
            this.btnClearLog.Text = "清空日志";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnMenuOk
            // 
            this.btnMenuOk.AutoSize = true;
            this.btnMenuOk.Location = new System.Drawing.Point(55, 226);
            this.btnMenuOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenuOk.Name = "btnMenuOk";
            this.btnMenuOk.Size = new System.Drawing.Size(255, 44);
            this.btnMenuOk.TabIndex = 5;
            this.btnMenuOk.Text = "菜单确定";
            this.btnMenuOk.UseVisualStyleBackColor = true;
            this.btnMenuOk.Click += new System.EventHandler(this.btnMenuOk_Click);
            // 
            // btnDown
            // 
            this.btnDown.AutoSize = true;
            this.btnDown.Location = new System.Drawing.Point(142, 128);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(81, 44);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRight
            // 
            this.btnRight.AutoSize = true;
            this.btnRight.Location = new System.Drawing.Point(230, 74);
            this.btnRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(81, 44);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = "右";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.AutoSize = true;
            this.btnLeft.Location = new System.Drawing.Point(55, 74);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(81, 44);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "左";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.AutoSize = true;
            this.btnMenu.Location = new System.Drawing.Point(142, 74);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(81, 44);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "菜单";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnUp
            // 
            this.btnUp.AutoSize = true;
            this.btnUp.Location = new System.Drawing.Point(142, 22);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(81, 44);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "上";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1238, 649);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "CameraController";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbBoxTimeMode;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStopInterval;
        private System.Windows.Forms.Button btnIntervalPlayPhoto;
        private System.Windows.Forms.Button btnPlayPhoto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnMenuOk;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnCameraModeOK;
        private System.Windows.Forms.ComboBox cbBoxCameraMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnHttpInit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDownEnd;
        private System.Windows.Forms.Button btnDownStart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnFresh;
        private System.Windows.Forms.ComboBox cbBox5;
        private System.Windows.Forms.ComboBox cbBox4;
        private System.Windows.Forms.ComboBox cbBox3;
        private System.Windows.Forms.ComboBox cbBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView LogListView;
        private System.Windows.Forms.Button focusBtnSub;
        private System.Windows.Forms.Button focusBtnAdd;
    }
}

