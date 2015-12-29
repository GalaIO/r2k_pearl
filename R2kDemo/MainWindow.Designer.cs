namespace R2kDemo
{
    partial class MainWindow
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelTagCount = new System.Windows.Forms.Label();
            this.labReadCount = new System.Windows.Forms.Label();
            this.labTagCount = new System.Windows.Forms.Label();
            this.gbCommMode = new System.Windows.Forms.GroupBox();
            this.rbNet = new System.Windows.Forms.RadioButton();
            this.rbSerialPort = new System.Windows.Forms.RadioButton();
            this.comboBoxSerialCommPort = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labCommPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.comboBoxIP = new System.Windows.Forms.ComboBox();
            this.rbDesc = new System.Windows.Forms.RadioButton();
            this.rbAsc = new System.Windows.Forms.RadioButton();
            this.labelVersion = new System.Windows.Forms.Label();
            this.gbAntParams = new System.Windows.Forms.GroupBox();
            this.labAntUnit = new System.Windows.Forms.Label();
            this.btnSetAnts = new System.Windows.Forms.Button();
            this.btnGetAnts = new System.Windows.Forms.Button();
            this.comboBoxWT4 = new System.Windows.Forms.ComboBox();
            this.comboBoxPower4 = new System.Windows.Forms.ComboBox();
            this.comboBoxWT3 = new System.Windows.Forms.ComboBox();
            this.comboBoxPower3 = new System.Windows.Forms.ComboBox();
            this.comboBoxWT2 = new System.Windows.Forms.ComboBox();
            this.comboBoxPower2 = new System.Windows.Forms.ComboBox();
            this.comboBoxWT1 = new System.Windows.Forms.ComboBox();
            this.comboBoxPower1 = new System.Windows.Forms.ComboBox();
            this.cbAnt4 = new System.Windows.Forms.CheckBox();
            this.cbAnt3 = new System.Windows.Forms.CheckBox();
            this.cbAnt2 = new System.Windows.Forms.CheckBox();
            this.cbAnt1 = new System.Windows.Forms.CheckBox();
            this.btnClearListView = new System.Windows.Forms.Button();
            this.btnStopReadData = new System.Windows.Forms.Button();
            this.btnStartReadData = new System.Windows.Forms.Button();
            this.btnReadOnce = new System.Windows.Forms.Button();
            this.listView = new R2kDemo.ListViewNF();
            this.TagAccess = new System.Windows.Forms.TabPage();
            this.labResult = new System.Windows.Forms.Label();
            this.gbDestroyTag = new System.Windows.Forms.GroupBox();
            this.btnKillTag = new System.Windows.Forms.Button();
            this.labDestroyPwd = new System.Windows.Forms.Label();
            this.tbKillKillPwd = new System.Windows.Forms.TextBox();
            this.labDesAccessPwd = new System.Windows.Forms.Label();
            this.tbKillAccessPwd = new System.Windows.Forms.TextBox();
            this.gbLockTag = new System.Windows.Forms.GroupBox();
            this.btnLockTag = new System.Windows.Forms.Button();
            this.labLockType = new System.Windows.Forms.Label();
            this.labLockBank = new System.Windows.Forms.Label();
            this.labLockAccessPwd = new System.Windows.Forms.Label();
            this.tbLockAccessPwd = new System.Windows.Forms.TextBox();
            this.cbbLockType = new System.Windows.Forms.ComboBox();
            this.cbbLockBank = new System.Windows.Forms.ComboBox();
            this.gbRWData = new System.Windows.Forms.GroupBox();
            this.labRWAccessPwd = new System.Windows.Forms.Label();
            this.labData = new System.Windows.Forms.Label();
            this.labLength = new System.Windows.Forms.Label();
            this.labStartAdd = new System.Windows.Forms.Label();
            this.labOprBank = new System.Windows.Forms.Label();
            this.tbRWAccessPwd = new System.Windows.Forms.TextBox();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.btnReadData = new System.Windows.Forms.Button();
            this.tbRWData = new System.Windows.Forms.TextBox();
            this.cbbLength = new System.Windows.Forms.ComboBox();
            this.cbbStartAdd = new System.Windows.Forms.ComboBox();
            this.cbbRWBank = new System.Windows.Forms.ComboBox();
            this.SetCommParam = new System.Windows.Forms.TabPage();
            this.gbSPParams = new System.Windows.Forms.GroupBox();
            this.labDataBits = new System.Windows.Forms.Label();
            this.labCheckBits = new System.Windows.Forms.Label();
            this.labBaudRate = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxCheckBits = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.gbNetParams = new System.Windows.Forms.GroupBox();
            this.labPromotion = new System.Windows.Forms.Label();
            this.labDestPort = new System.Windows.Forms.Label();
            this.labDestIP = new System.Windows.Forms.Label();
            this.labGateway = new System.Windows.Forms.Label();
            this.labPort = new System.Windows.Forms.Label();
            this.labMask = new System.Windows.Forms.Label();
            this.labIPAdd = new System.Windows.Forms.Label();
            this.labIPMode = new System.Windows.Forms.Label();
            this.labNetMode = new System.Windows.Forms.Label();
            this.textBoxDestPort = new System.Windows.Forms.TextBox();
            this.textBoxDestIP = new System.Windows.Forms.TextBox();
            this.textBoxGateway = new System.Windows.Forms.TextBox();
            this.textBoxPortNo = new System.Windows.Forms.TextBox();
            this.textBoxNetMask = new System.Windows.Forms.TextBox();
            this.textBoxIPAdd = new System.Windows.Forms.TextBox();
            this.comboBoxIPMode = new System.Windows.Forms.ComboBox();
            this.comboBoxNetMode = new System.Windows.Forms.ComboBox();
            this.btnSetParams = new System.Windows.Forms.Button();
            this.btnDefaultParams = new System.Windows.Forms.Button();
            this.btnModifyDev = new System.Windows.Forms.Button();
            this.btnSearchDev = new System.Windows.Forms.Button();
            this.lvZl = new System.Windows.Forms.ListView();
            this.columnHeaderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIPAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SetReaderParam = new System.Windows.Forms.TabPage();
            this.labSetParam = new System.Windows.Forms.Label();
            this.gbDevParams = new System.Windows.Forms.GroupBox();
            this.btnSetHeartTime = new System.Windows.Forms.Button();
            this.btnSetNeighJudge = new System.Windows.Forms.Button();
            this.btnSetDevNo = new System.Windows.Forms.Button();
            this.labDevNo = new System.Windows.Forms.Label();
            this.labNeightJudge = new System.Windows.Forms.Label();
            this.labAlive = new System.Windows.Forms.Label();
            this.tbHeartTime = new System.Windows.Forms.TextBox();
            this.tbNeighJudge = new System.Windows.Forms.TextBox();
            this.tbDevNo = new System.Windows.Forms.TextBox();
            this.gbIOOpr = new System.Windows.Forms.GroupBox();
            this.btnSetOutPort = new System.Windows.Forms.Button();
            this.btnGetDI = new System.Windows.Forms.Button();
            this.cbOut2 = new System.Windows.Forms.CheckBox();
            this.cbOut1 = new System.Windows.Forms.CheckBox();
            this.cbIn2 = new System.Windows.Forms.CheckBox();
            this.cbIn1 = new System.Windows.Forms.CheckBox();
            this.timerConnect = new System.Windows.Forms.Timer(this.components);
            this.cbbLangSwitch = new System.Windows.Forms.ComboBox();
            this.cbSaveFile = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.General.SuspendLayout();
            this.gbCommMode.SuspendLayout();
            this.gbAntParams.SuspendLayout();
            this.TagAccess.SuspendLayout();
            this.gbDestroyTag.SuspendLayout();
            this.gbLockTag.SuspendLayout();
            this.gbRWData.SuspendLayout();
            this.SetCommParam.SuspendLayout();
            this.gbSPParams.SuspendLayout();
            this.gbNetParams.SuspendLayout();
            this.SetReaderParam.SuspendLayout();
            this.gbDevParams.SuspendLayout();
            this.gbIOOpr.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.General);
            this.tabControl.Controls.Add(this.TagAccess);
            this.tabControl.Controls.Add(this.SetCommParam);
            this.tabControl.Controls.Add(this.SetReaderParam);
            this.tabControl.Location = new System.Drawing.Point(4, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(854, 469);
            this.tabControl.TabIndex = 0;
            // 
            // General
            // 
            this.General.Controls.Add(this.cbSaveFile);
            this.General.Controls.Add(this.labelCount);
            this.General.Controls.Add(this.labelTagCount);
            this.General.Controls.Add(this.labReadCount);
            this.General.Controls.Add(this.labTagCount);
            this.General.Controls.Add(this.gbCommMode);
            this.General.Controls.Add(this.rbDesc);
            this.General.Controls.Add(this.rbAsc);
            this.General.Controls.Add(this.labelVersion);
            this.General.Controls.Add(this.gbAntParams);
            this.General.Controls.Add(this.btnClearListView);
            this.General.Controls.Add(this.btnStopReadData);
            this.General.Controls.Add(this.btnStartReadData);
            this.General.Controls.Add(this.btnReadOnce);
            this.General.Controls.Add(this.listView);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(846, 443);
            this.General.TabIndex = 0;
            this.General.Text = "基本操作";
            this.General.UseVisualStyleBackColor = true;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(691, 19);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(11, 12);
            this.labelCount.TabIndex = 37;
            this.labelCount.Text = "0";
            // 
            // labelTagCount
            // 
            this.labelTagCount.AutoSize = true;
            this.labelTagCount.Location = new System.Drawing.Point(423, 19);
            this.labelTagCount.Name = "labelTagCount";
            this.labelTagCount.Size = new System.Drawing.Size(11, 12);
            this.labelTagCount.TabIndex = 36;
            this.labelTagCount.Text = "0";
            // 
            // labReadCount
            // 
            this.labReadCount.AutoSize = true;
            this.labReadCount.Location = new System.Drawing.Point(626, 19);
            this.labReadCount.Name = "labReadCount";
            this.labReadCount.Size = new System.Drawing.Size(59, 12);
            this.labReadCount.TabIndex = 35;
            this.labReadCount.Text = "读取次数:";
            // 
            // labTagCount
            // 
            this.labTagCount.AutoSize = true;
            this.labTagCount.Location = new System.Drawing.Point(350, 19);
            this.labTagCount.Name = "labTagCount";
            this.labTagCount.Size = new System.Drawing.Size(47, 12);
            this.labTagCount.TabIndex = 34;
            this.labTagCount.Text = "标签数:";
            // 
            // gbCommMode
            // 
            this.gbCommMode.Controls.Add(this.rbNet);
            this.gbCommMode.Controls.Add(this.rbSerialPort);
            this.gbCommMode.Controls.Add(this.comboBoxSerialCommPort);
            this.gbCommMode.Controls.Add(this.btnUpdate);
            this.gbCommMode.Controls.Add(this.btnDisconnect);
            this.gbCommMode.Controls.Add(this.btnConnect);
            this.gbCommMode.Controls.Add(this.labCommPort);
            this.gbCommMode.Controls.Add(this.textBoxPort);
            this.gbCommMode.Controls.Add(this.comboBoxIP);
            this.gbCommMode.Location = new System.Drawing.Point(23, 23);
            this.gbCommMode.Name = "gbCommMode";
            this.gbCommMode.Size = new System.Drawing.Size(228, 161);
            this.gbCommMode.TabIndex = 33;
            this.gbCommMode.TabStop = false;
            this.gbCommMode.Text = "通信方式";
            // 
            // rbNet
            // 
            this.rbNet.AutoSize = true;
            this.rbNet.Location = new System.Drawing.Point(139, 26);
            this.rbNet.Name = "rbNet";
            this.rbNet.Size = new System.Drawing.Size(47, 16);
            this.rbNet.TabIndex = 29;
            this.rbNet.TabStop = true;
            this.rbNet.Text = "网络";
            this.rbNet.UseVisualStyleBackColor = true;
            this.rbNet.CheckedChanged += new System.EventHandler(this.radioButtonNet_CheckedChanged);
            // 
            // rbSerialPort
            // 
            this.rbSerialPort.AutoSize = true;
            this.rbSerialPort.Location = new System.Drawing.Point(26, 26);
            this.rbSerialPort.Name = "rbSerialPort";
            this.rbSerialPort.Size = new System.Drawing.Size(47, 16);
            this.rbSerialPort.TabIndex = 28;
            this.rbSerialPort.TabStop = true;
            this.rbSerialPort.Text = "串口";
            this.rbSerialPort.UseVisualStyleBackColor = true;
            this.rbSerialPort.CheckedChanged += new System.EventHandler(this.radioButtonSP_CheckedChanged);
            // 
            // comboBoxSerialCommPort
            // 
            this.comboBoxSerialCommPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialCommPort.FormattingEnabled = true;
            this.comboBoxSerialCommPort.Location = new System.Drawing.Point(26, 67);
            this.comboBoxSerialCommPort.Name = "comboBoxSerialCommPort";
            this.comboBoxSerialCommPort.Size = new System.Drawing.Size(112, 20);
            this.comboBoxSerialCommPort.TabIndex = 24;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(149, 62);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 29);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Text = "刷新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(118, 119);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(85, 29);
            this.btnDisconnect.TabIndex = 9;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(9, 119);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 29);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labCommPort
            // 
            this.labCommPort.AutoSize = true;
            this.labCommPort.Location = new System.Drawing.Point(32, 88);
            this.labCommPort.Name = "labCommPort";
            this.labCommPort.Size = new System.Drawing.Size(41, 12);
            this.labCommPort.TabIndex = 7;
            this.labCommPort.Text = "端口号";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(75, 84);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(66, 21);
            this.textBoxPort.TabIndex = 6;
            // 
            // comboBoxIP
            // 
            this.comboBoxIP.FormattingEnabled = true;
            this.comboBoxIP.Location = new System.Drawing.Point(29, 54);
            this.comboBoxIP.Name = "comboBoxIP";
            this.comboBoxIP.Size = new System.Drawing.Size(112, 20);
            this.comboBoxIP.TabIndex = 5;
            // 
            // rbDesc
            // 
            this.rbDesc.AutoSize = true;
            this.rbDesc.Location = new System.Drawing.Point(452, 358);
            this.rbDesc.Name = "rbDesc";
            this.rbDesc.Size = new System.Drawing.Size(95, 16);
            this.rbDesc.TabIndex = 32;
            this.rbDesc.TabStop = true;
            this.rbDesc.Text = "数据降序排列";
            this.rbDesc.UseVisualStyleBackColor = true;
            this.rbDesc.CheckedChanged += new System.EventHandler(this.radioButtonDesc_CheckedChanged);
            // 
            // rbAsc
            // 
            this.rbAsc.AutoSize = true;
            this.rbAsc.Location = new System.Drawing.Point(296, 358);
            this.rbAsc.Name = "rbAsc";
            this.rbAsc.Size = new System.Drawing.Size(95, 16);
            this.rbAsc.TabIndex = 31;
            this.rbAsc.TabStop = true;
            this.rbAsc.Text = "数据升序排列";
            this.rbAsc.UseVisualStyleBackColor = true;
            this.rbAsc.CheckedChanged += new System.EventHandler(this.radioButtonＡsc_CheckedChanged);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(41, 408);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(0, 12);
            this.labelVersion.TabIndex = 30;
            // 
            // gbAntParams
            // 
            this.gbAntParams.Controls.Add(this.labAntUnit);
            this.gbAntParams.Controls.Add(this.btnSetAnts);
            this.gbAntParams.Controls.Add(this.btnGetAnts);
            this.gbAntParams.Controls.Add(this.comboBoxWT4);
            this.gbAntParams.Controls.Add(this.comboBoxPower4);
            this.gbAntParams.Controls.Add(this.comboBoxWT3);
            this.gbAntParams.Controls.Add(this.comboBoxPower3);
            this.gbAntParams.Controls.Add(this.comboBoxWT2);
            this.gbAntParams.Controls.Add(this.comboBoxPower2);
            this.gbAntParams.Controls.Add(this.comboBoxWT1);
            this.gbAntParams.Controls.Add(this.comboBoxPower1);
            this.gbAntParams.Controls.Add(this.cbAnt4);
            this.gbAntParams.Controls.Add(this.cbAnt3);
            this.gbAntParams.Controls.Add(this.cbAnt2);
            this.gbAntParams.Controls.Add(this.cbAnt1);
            this.gbAntParams.Location = new System.Drawing.Point(23, 190);
            this.gbAntParams.Name = "gbAntParams";
            this.gbAntParams.Size = new System.Drawing.Size(228, 215);
            this.gbAntParams.TabIndex = 27;
            this.gbAntParams.TabStop = false;
            this.gbAntParams.Text = "天线参数";
            // 
            // labAntUnit
            // 
            this.labAntUnit.AutoSize = true;
            this.labAntUnit.Location = new System.Drawing.Point(84, 21);
            this.labAntUnit.Name = "labAntUnit";
            this.labAntUnit.Size = new System.Drawing.Size(107, 12);
            this.labAntUnit.TabIndex = 27;
            this.labAntUnit.Text = "毫秒      1/10dbm";
            // 
            // btnSetAnts
            // 
            this.btnSetAnts.Location = new System.Drawing.Point(118, 174);
            this.btnSetAnts.Name = "btnSetAnts";
            this.btnSetAnts.Size = new System.Drawing.Size(54, 27);
            this.btnSetAnts.TabIndex = 26;
            this.btnSetAnts.Text = "设置";
            this.btnSetAnts.UseVisualStyleBackColor = true;
            this.btnSetAnts.Click += new System.EventHandler(this.btnSetAnts_Click);
            // 
            // btnGetAnts
            // 
            this.btnGetAnts.Location = new System.Drawing.Point(34, 174);
            this.btnGetAnts.Name = "btnGetAnts";
            this.btnGetAnts.Size = new System.Drawing.Size(54, 27);
            this.btnGetAnts.TabIndex = 25;
            this.btnGetAnts.Text = "读取";
            this.btnGetAnts.UseVisualStyleBackColor = true;
            this.btnGetAnts.Click += new System.EventHandler(this.btnGetAnts_Click);
            // 
            // comboBoxWT4
            // 
            this.comboBoxWT4.FormattingEnabled = true;
            this.comboBoxWT4.Location = new System.Drawing.Point(69, 142);
            this.comboBoxWT4.Name = "comboBoxWT4";
            this.comboBoxWT4.Size = new System.Drawing.Size(61, 20);
            this.comboBoxWT4.TabIndex = 22;
            // 
            // comboBoxPower4
            // 
            this.comboBoxPower4.FormattingEnabled = true;
            this.comboBoxPower4.Location = new System.Drawing.Point(136, 142);
            this.comboBoxPower4.Name = "comboBoxPower4";
            this.comboBoxPower4.Size = new System.Drawing.Size(50, 20);
            this.comboBoxPower4.TabIndex = 21;
            // 
            // comboBoxWT3
            // 
            this.comboBoxWT3.FormattingEnabled = true;
            this.comboBoxWT3.Location = new System.Drawing.Point(69, 107);
            this.comboBoxWT3.Name = "comboBoxWT3";
            this.comboBoxWT3.Size = new System.Drawing.Size(61, 20);
            this.comboBoxWT3.TabIndex = 20;
            // 
            // comboBoxPower3
            // 
            this.comboBoxPower3.FormattingEnabled = true;
            this.comboBoxPower3.Location = new System.Drawing.Point(136, 107);
            this.comboBoxPower3.Name = "comboBoxPower3";
            this.comboBoxPower3.Size = new System.Drawing.Size(50, 20);
            this.comboBoxPower3.TabIndex = 19;
            // 
            // comboBoxWT2
            // 
            this.comboBoxWT2.FormattingEnabled = true;
            this.comboBoxWT2.Location = new System.Drawing.Point(69, 76);
            this.comboBoxWT2.Name = "comboBoxWT2";
            this.comboBoxWT2.Size = new System.Drawing.Size(61, 20);
            this.comboBoxWT2.TabIndex = 18;
            // 
            // comboBoxPower2
            // 
            this.comboBoxPower2.FormattingEnabled = true;
            this.comboBoxPower2.Location = new System.Drawing.Point(136, 76);
            this.comboBoxPower2.Name = "comboBoxPower2";
            this.comboBoxPower2.Size = new System.Drawing.Size(50, 20);
            this.comboBoxPower2.TabIndex = 17;
            // 
            // comboBoxWT1
            // 
            this.comboBoxWT1.FormattingEnabled = true;
            this.comboBoxWT1.Location = new System.Drawing.Point(69, 40);
            this.comboBoxWT1.Name = "comboBoxWT1";
            this.comboBoxWT1.Size = new System.Drawing.Size(61, 20);
            this.comboBoxWT1.TabIndex = 16;
            // 
            // comboBoxPower1
            // 
            this.comboBoxPower1.FormattingEnabled = true;
            this.comboBoxPower1.Location = new System.Drawing.Point(136, 39);
            this.comboBoxPower1.Name = "comboBoxPower1";
            this.comboBoxPower1.Size = new System.Drawing.Size(50, 20);
            this.comboBoxPower1.TabIndex = 15;
            // 
            // cbAnt4
            // 
            this.cbAnt4.AutoSize = true;
            this.cbAnt4.Location = new System.Drawing.Point(21, 145);
            this.cbAnt4.Name = "cbAnt4";
            this.cbAnt4.Size = new System.Drawing.Size(42, 16);
            this.cbAnt4.TabIndex = 13;
            this.cbAnt4.Text = "4号";
            this.cbAnt4.UseVisualStyleBackColor = true;
            // 
            // cbAnt3
            // 
            this.cbAnt3.AutoSize = true;
            this.cbAnt3.Location = new System.Drawing.Point(21, 112);
            this.cbAnt3.Name = "cbAnt3";
            this.cbAnt3.Size = new System.Drawing.Size(42, 16);
            this.cbAnt3.TabIndex = 12;
            this.cbAnt3.Text = "3号";
            this.cbAnt3.UseVisualStyleBackColor = true;
            // 
            // cbAnt2
            // 
            this.cbAnt2.AutoSize = true;
            this.cbAnt2.Location = new System.Drawing.Point(21, 77);
            this.cbAnt2.Name = "cbAnt2";
            this.cbAnt2.Size = new System.Drawing.Size(42, 16);
            this.cbAnt2.TabIndex = 11;
            this.cbAnt2.Text = "2号";
            this.cbAnt2.UseVisualStyleBackColor = true;
            // 
            // cbAnt1
            // 
            this.cbAnt1.AutoSize = true;
            this.cbAnt1.Location = new System.Drawing.Point(21, 44);
            this.cbAnt1.Name = "cbAnt1";
            this.cbAnt1.Size = new System.Drawing.Size(42, 16);
            this.cbAnt1.TabIndex = 10;
            this.cbAnt1.Text = "1号";
            this.cbAnt1.UseVisualStyleBackColor = true;
            // 
            // btnClearListView
            // 
            this.btnClearListView.Location = new System.Drawing.Point(680, 380);
            this.btnClearListView.Name = "btnClearListView";
            this.btnClearListView.Size = new System.Drawing.Size(93, 38);
            this.btnClearListView.TabIndex = 4;
            this.btnClearListView.Text = "清空";
            this.btnClearListView.UseVisualStyleBackColor = true;
            this.btnClearListView.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStopReadData
            // 
            this.btnStopReadData.Location = new System.Drawing.Point(569, 380);
            this.btnStopReadData.Name = "btnStopReadData";
            this.btnStopReadData.Size = new System.Drawing.Size(93, 38);
            this.btnStopReadData.TabIndex = 3;
            this.btnStopReadData.Text = "停止连续寻卡";
            this.btnStopReadData.UseVisualStyleBackColor = true;
            this.btnStopReadData.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStartReadData
            // 
            this.btnStartReadData.Location = new System.Drawing.Point(458, 380);
            this.btnStartReadData.Name = "btnStartReadData";
            this.btnStartReadData.Size = new System.Drawing.Size(93, 38);
            this.btnStartReadData.TabIndex = 2;
            this.btnStartReadData.Text = "开始连续寻卡";
            this.btnStartReadData.UseVisualStyleBackColor = true;
            this.btnStartReadData.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReadOnce
            // 
            this.btnReadOnce.Location = new System.Drawing.Point(347, 380);
            this.btnReadOnce.Name = "btnReadOnce";
            this.btnReadOnce.Size = new System.Drawing.Size(93, 38);
            this.btnReadOnce.TabIndex = 1;
            this.btnReadOnce.Text = "寻卡一次";
            this.btnReadOnce.UseVisualStyleBackColor = true;
            this.btnReadOnce.Click += new System.EventHandler(this.btnInvokeOnce_Click);
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(287, 48);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(495, 303);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // TagAccess
            // 
            this.TagAccess.Controls.Add(this.labResult);
            this.TagAccess.Controls.Add(this.gbDestroyTag);
            this.TagAccess.Controls.Add(this.gbLockTag);
            this.TagAccess.Controls.Add(this.gbRWData);
            this.TagAccess.Location = new System.Drawing.Point(4, 22);
            this.TagAccess.Name = "TagAccess";
            this.TagAccess.Padding = new System.Windows.Forms.Padding(3);
            this.TagAccess.Size = new System.Drawing.Size(846, 443);
            this.TagAccess.TabIndex = 1;
            this.TagAccess.Text = "标签访问";
            this.TagAccess.UseVisualStyleBackColor = true;
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Location = new System.Drawing.Point(71, 400);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(0, 12);
            this.labResult.TabIndex = 26;
            // 
            // gbDestroyTag
            // 
            this.gbDestroyTag.Controls.Add(this.btnKillTag);
            this.gbDestroyTag.Controls.Add(this.labDestroyPwd);
            this.gbDestroyTag.Controls.Add(this.tbKillKillPwd);
            this.gbDestroyTag.Controls.Add(this.labDesAccessPwd);
            this.gbDestroyTag.Controls.Add(this.tbKillAccessPwd);
            this.gbDestroyTag.Location = new System.Drawing.Point(74, 304);
            this.gbDestroyTag.Name = "gbDestroyTag";
            this.gbDestroyTag.Size = new System.Drawing.Size(650, 81);
            this.gbDestroyTag.TabIndex = 25;
            this.gbDestroyTag.TabStop = false;
            this.gbDestroyTag.Text = "销毁标签";
            // 
            // btnKillTag
            // 
            this.btnKillTag.Location = new System.Drawing.Point(516, 33);
            this.btnKillTag.Name = "btnKillTag";
            this.btnKillTag.Size = new System.Drawing.Size(83, 27);
            this.btnKillTag.TabIndex = 21;
            this.btnKillTag.Text = "销毁";
            this.btnKillTag.UseVisualStyleBackColor = true;
            this.btnKillTag.Click += new System.EventHandler(this.btnKillTag_Click);
            // 
            // labDestroyPwd
            // 
            this.labDestroyPwd.AutoSize = true;
            this.labDestroyPwd.Location = new System.Drawing.Point(258, 39);
            this.labDestroyPwd.Name = "labDestroyPwd";
            this.labDestroyPwd.Size = new System.Drawing.Size(53, 12);
            this.labDestroyPwd.TabIndex = 24;
            this.labDestroyPwd.Text = "注销密码";
            // 
            // tbKillKillPwd
            // 
            this.tbKillKillPwd.Location = new System.Drawing.Point(356, 36);
            this.tbKillKillPwd.Name = "tbKillKillPwd";
            this.tbKillKillPwd.Size = new System.Drawing.Size(100, 21);
            this.tbKillKillPwd.TabIndex = 23;
            // 
            // labDesAccessPwd
            // 
            this.labDesAccessPwd.AutoSize = true;
            this.labDesAccessPwd.Location = new System.Drawing.Point(41, 42);
            this.labDesAccessPwd.Name = "labDesAccessPwd";
            this.labDesAccessPwd.Size = new System.Drawing.Size(53, 12);
            this.labDesAccessPwd.TabIndex = 22;
            this.labDesAccessPwd.Text = "访问密码";
            // 
            // tbKillAccessPwd
            // 
            this.tbKillAccessPwd.Location = new System.Drawing.Point(137, 38);
            this.tbKillAccessPwd.Name = "tbKillAccessPwd";
            this.tbKillAccessPwd.Size = new System.Drawing.Size(100, 21);
            this.tbKillAccessPwd.TabIndex = 21;
            // 
            // gbLockTag
            // 
            this.gbLockTag.Controls.Add(this.btnLockTag);
            this.gbLockTag.Controls.Add(this.labLockType);
            this.gbLockTag.Controls.Add(this.labLockBank);
            this.gbLockTag.Controls.Add(this.labLockAccessPwd);
            this.gbLockTag.Controls.Add(this.tbLockAccessPwd);
            this.gbLockTag.Controls.Add(this.cbbLockType);
            this.gbLockTag.Controls.Add(this.cbbLockBank);
            this.gbLockTag.Location = new System.Drawing.Point(73, 185);
            this.gbLockTag.Name = "gbLockTag";
            this.gbLockTag.Size = new System.Drawing.Size(652, 113);
            this.gbLockTag.TabIndex = 22;
            this.gbLockTag.TabStop = false;
            this.gbLockTag.Text = "锁卡/解锁";
            // 
            // btnLockTag
            // 
            this.btnLockTag.Location = new System.Drawing.Point(517, 56);
            this.btnLockTag.Name = "btnLockTag";
            this.btnLockTag.Size = new System.Drawing.Size(83, 27);
            this.btnLockTag.TabIndex = 20;
            this.btnLockTag.Text = "执行";
            this.btnLockTag.UseVisualStyleBackColor = true;
            this.btnLockTag.Click += new System.EventHandler(this.btnLockTag_Click);
            // 
            // labLockType
            // 
            this.labLockType.AutoSize = true;
            this.labLockType.Location = new System.Drawing.Point(283, 29);
            this.labLockType.Name = "labLockType";
            this.labLockType.Size = new System.Drawing.Size(29, 12);
            this.labLockType.TabIndex = 18;
            this.labLockType.Text = "类型";
            // 
            // labLockBank
            // 
            this.labLockBank.AutoSize = true;
            this.labLockBank.Location = new System.Drawing.Point(44, 29);
            this.labLockBank.Name = "labLockBank";
            this.labLockBank.Size = new System.Drawing.Size(53, 12);
            this.labLockBank.TabIndex = 17;
            this.labLockBank.Text = "操作区域";
            // 
            // labLockAccessPwd
            // 
            this.labLockAccessPwd.AutoSize = true;
            this.labLockAccessPwd.Location = new System.Drawing.Point(45, 67);
            this.labLockAccessPwd.Name = "labLockAccessPwd";
            this.labLockAccessPwd.Size = new System.Drawing.Size(53, 12);
            this.labLockAccessPwd.TabIndex = 16;
            this.labLockAccessPwd.Text = "访问密码";
            // 
            // tbLockAccessPwd
            // 
            this.tbLockAccessPwd.Location = new System.Drawing.Point(139, 61);
            this.tbLockAccessPwd.Name = "tbLockAccessPwd";
            this.tbLockAccessPwd.Size = new System.Drawing.Size(100, 21);
            this.tbLockAccessPwd.TabIndex = 15;
            // 
            // cbbLockType
            // 
            this.cbbLockType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLockType.FormattingEnabled = true;
            this.cbbLockType.Location = new System.Drawing.Point(342, 26);
            this.cbbLockType.Name = "cbbLockType";
            this.cbbLockType.Size = new System.Drawing.Size(100, 20);
            this.cbbLockType.TabIndex = 4;
            // 
            // cbbLockBank
            // 
            this.cbbLockBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLockBank.FormattingEnabled = true;
            this.cbbLockBank.Location = new System.Drawing.Point(137, 26);
            this.cbbLockBank.Name = "cbbLockBank";
            this.cbbLockBank.Size = new System.Drawing.Size(100, 20);
            this.cbbLockBank.TabIndex = 3;
            // 
            // gbRWData
            // 
            this.gbRWData.Controls.Add(this.labRWAccessPwd);
            this.gbRWData.Controls.Add(this.labData);
            this.gbRWData.Controls.Add(this.labLength);
            this.gbRWData.Controls.Add(this.labStartAdd);
            this.gbRWData.Controls.Add(this.labOprBank);
            this.gbRWData.Controls.Add(this.tbRWAccessPwd);
            this.gbRWData.Controls.Add(this.btnWriteData);
            this.gbRWData.Controls.Add(this.btnClearData);
            this.gbRWData.Controls.Add(this.btnReadData);
            this.gbRWData.Controls.Add(this.tbRWData);
            this.gbRWData.Controls.Add(this.cbbLength);
            this.gbRWData.Controls.Add(this.cbbStartAdd);
            this.gbRWData.Controls.Add(this.cbbRWBank);
            this.gbRWData.Location = new System.Drawing.Point(73, 27);
            this.gbRWData.Name = "gbRWData";
            this.gbRWData.Size = new System.Drawing.Size(652, 152);
            this.gbRWData.TabIndex = 21;
            this.gbRWData.TabStop = false;
            this.gbRWData.Text = "读/写数据";
            // 
            // labRWAccessPwd
            // 
            this.labRWAccessPwd.AutoSize = true;
            this.labRWAccessPwd.Location = new System.Drawing.Point(42, 112);
            this.labRWAccessPwd.Name = "labRWAccessPwd";
            this.labRWAccessPwd.Size = new System.Drawing.Size(53, 12);
            this.labRWAccessPwd.TabIndex = 14;
            this.labRWAccessPwd.Text = "访问密码";
            // 
            // labData
            // 
            this.labData.AutoSize = true;
            this.labData.Location = new System.Drawing.Point(42, 74);
            this.labData.Name = "labData";
            this.labData.Size = new System.Drawing.Size(29, 12);
            this.labData.TabIndex = 13;
            this.labData.Text = "数据";
            // 
            // labLength
            // 
            this.labLength.AutoSize = true;
            this.labLength.Location = new System.Drawing.Point(460, 36);
            this.labLength.Name = "labLength";
            this.labLength.Size = new System.Drawing.Size(29, 12);
            this.labLength.TabIndex = 12;
            this.labLength.Text = "长度";
            // 
            // labStartAdd
            // 
            this.labStartAdd.AutoSize = true;
            this.labStartAdd.Location = new System.Drawing.Point(217, 35);
            this.labStartAdd.Name = "labStartAdd";
            this.labStartAdd.Size = new System.Drawing.Size(53, 12);
            this.labStartAdd.TabIndex = 11;
            this.labStartAdd.Text = "起始地址";
            // 
            // labOprBank
            // 
            this.labOprBank.AutoSize = true;
            this.labOprBank.Location = new System.Drawing.Point(42, 36);
            this.labOprBank.Name = "labOprBank";
            this.labOprBank.Size = new System.Drawing.Size(53, 12);
            this.labOprBank.TabIndex = 10;
            this.labOprBank.Text = "操作区域";
            // 
            // tbRWAccessPwd
            // 
            this.tbRWAccessPwd.Location = new System.Drawing.Point(135, 108);
            this.tbRWAccessPwd.Name = "tbRWAccessPwd";
            this.tbRWAccessPwd.Size = new System.Drawing.Size(100, 21);
            this.tbRWAccessPwd.TabIndex = 9;
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(517, 107);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(83, 27);
            this.btnWriteData.TabIndex = 8;
            this.btnWriteData.Text = "写入";
            this.btnWriteData.UseVisualStyleBackColor = true;
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(421, 107);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(83, 27);
            this.btnClearData.TabIndex = 7;
            this.btnClearData.Text = "清空";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(324, 107);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(83, 27);
            this.btnReadData.TabIndex = 6;
            this.btnReadData.Text = "读取";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // tbRWData
            // 
            this.tbRWData.Location = new System.Drawing.Point(100, 60);
            this.tbRWData.Multiline = true;
            this.tbRWData.Name = "tbRWData";
            this.tbRWData.Size = new System.Drawing.Size(500, 36);
            this.tbRWData.TabIndex = 5;
            // 
            // cbbLength
            // 
            this.cbbLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLength.FormattingEnabled = true;
            this.cbbLength.Location = new System.Drawing.Point(510, 32);
            this.cbbLength.Name = "cbbLength";
            this.cbbLength.Size = new System.Drawing.Size(88, 20);
            this.cbbLength.TabIndex = 2;
            // 
            // cbbStartAdd
            // 
            this.cbbStartAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStartAdd.FormattingEnabled = true;
            this.cbbStartAdd.Location = new System.Drawing.Point(309, 32);
            this.cbbStartAdd.Name = "cbbStartAdd";
            this.cbbStartAdd.Size = new System.Drawing.Size(88, 20);
            this.cbbStartAdd.TabIndex = 1;
            this.cbbStartAdd.SelectedIndexChanged += new System.EventHandler(this.cbbStartAdd_SelectedIndexChanged);
            // 
            // cbbRWBank
            // 
            this.cbbRWBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRWBank.FormattingEnabled = true;
            this.cbbRWBank.Location = new System.Drawing.Point(100, 32);
            this.cbbRWBank.Name = "cbbRWBank";
            this.cbbRWBank.Size = new System.Drawing.Size(88, 20);
            this.cbbRWBank.TabIndex = 0;
            this.cbbRWBank.SelectedIndexChanged += new System.EventHandler(this.cbbRWBank_SelectedIndexChanged);
            // 
            // SetCommParam
            // 
            this.SetCommParam.Controls.Add(this.gbSPParams);
            this.SetCommParam.Controls.Add(this.gbNetParams);
            this.SetCommParam.Controls.Add(this.btnSetParams);
            this.SetCommParam.Controls.Add(this.btnDefaultParams);
            this.SetCommParam.Controls.Add(this.btnModifyDev);
            this.SetCommParam.Controls.Add(this.btnSearchDev);
            this.SetCommParam.Controls.Add(this.lvZl);
            this.SetCommParam.Location = new System.Drawing.Point(4, 22);
            this.SetCommParam.Name = "SetCommParam";
            this.SetCommParam.Padding = new System.Windows.Forms.Padding(3);
            this.SetCommParam.Size = new System.Drawing.Size(846, 443);
            this.SetCommParam.TabIndex = 2;
            this.SetCommParam.Text = "设置通信参数";
            this.SetCommParam.UseVisualStyleBackColor = true;
            this.SetCommParam.Enter += new System.EventHandler(this.SetCommParam_Enter);
            // 
            // gbSPParams
            // 
            this.gbSPParams.Controls.Add(this.labDataBits);
            this.gbSPParams.Controls.Add(this.labCheckBits);
            this.gbSPParams.Controls.Add(this.labBaudRate);
            this.gbSPParams.Controls.Add(this.comboBoxBaudRate);
            this.gbSPParams.Controls.Add(this.comboBoxCheckBits);
            this.gbSPParams.Controls.Add(this.comboBoxDataBits);
            this.gbSPParams.Location = new System.Drawing.Point(48, 310);
            this.gbSPParams.Name = "gbSPParams";
            this.gbSPParams.Size = new System.Drawing.Size(349, 114);
            this.gbSPParams.TabIndex = 28;
            this.gbSPParams.TabStop = false;
            this.gbSPParams.Text = "串口参数";
            // 
            // labDataBits
            // 
            this.labDataBits.AutoSize = true;
            this.labDataBits.Location = new System.Drawing.Point(19, 79);
            this.labDataBits.Name = "labDataBits";
            this.labDataBits.Size = new System.Drawing.Size(41, 12);
            this.labDataBits.TabIndex = 27;
            this.labDataBits.Text = "数据位";
            // 
            // labCheckBits
            // 
            this.labCheckBits.AutoSize = true;
            this.labCheckBits.Location = new System.Drawing.Point(192, 36);
            this.labCheckBits.Name = "labCheckBits";
            this.labCheckBits.Size = new System.Drawing.Size(41, 12);
            this.labCheckBits.TabIndex = 26;
            this.labCheckBits.Text = "校验位";
            // 
            // labBaudRate
            // 
            this.labBaudRate.AutoSize = true;
            this.labBaudRate.Location = new System.Drawing.Point(17, 36);
            this.labBaudRate.Name = "labBaudRate";
            this.labBaudRate.Size = new System.Drawing.Size(41, 12);
            this.labBaudRate.TabIndex = 25;
            this.labBaudRate.Text = "波特率";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(85, 33);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(89, 20);
            this.comboBoxBaudRate.TabIndex = 7;
            // 
            // comboBoxCheckBits
            // 
            this.comboBoxCheckBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCheckBits.FormattingEnabled = true;
            this.comboBoxCheckBits.Location = new System.Drawing.Point(242, 33);
            this.comboBoxCheckBits.Name = "comboBoxCheckBits";
            this.comboBoxCheckBits.Size = new System.Drawing.Size(89, 20);
            this.comboBoxCheckBits.TabIndex = 6;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Location = new System.Drawing.Point(84, 76);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(89, 20);
            this.comboBoxDataBits.TabIndex = 5;
            // 
            // gbNetParams
            // 
            this.gbNetParams.Controls.Add(this.labPromotion);
            this.gbNetParams.Controls.Add(this.labDestPort);
            this.gbNetParams.Controls.Add(this.labDestIP);
            this.gbNetParams.Controls.Add(this.labGateway);
            this.gbNetParams.Controls.Add(this.labPort);
            this.gbNetParams.Controls.Add(this.labMask);
            this.gbNetParams.Controls.Add(this.labIPAdd);
            this.gbNetParams.Controls.Add(this.labIPMode);
            this.gbNetParams.Controls.Add(this.labNetMode);
            this.gbNetParams.Controls.Add(this.textBoxDestPort);
            this.gbNetParams.Controls.Add(this.textBoxDestIP);
            this.gbNetParams.Controls.Add(this.textBoxGateway);
            this.gbNetParams.Controls.Add(this.textBoxPortNo);
            this.gbNetParams.Controls.Add(this.textBoxNetMask);
            this.gbNetParams.Controls.Add(this.textBoxIPAdd);
            this.gbNetParams.Controls.Add(this.comboBoxIPMode);
            this.gbNetParams.Controls.Add(this.comboBoxNetMode);
            this.gbNetParams.Location = new System.Drawing.Point(436, 15);
            this.gbNetParams.Name = "gbNetParams";
            this.gbNetParams.Size = new System.Drawing.Size(331, 369);
            this.gbNetParams.TabIndex = 25;
            this.gbNetParams.TabStop = false;
            this.gbNetParams.Text = "网络参数";
            // 
            // labPromotion
            // 
            this.labPromotion.AutoSize = true;
            this.labPromotion.Location = new System.Drawing.Point(56, 259);
            this.labPromotion.Name = "labPromotion";
            this.labPromotion.Size = new System.Drawing.Size(185, 12);
            this.labPromotion.TabIndex = 24;
            this.labPromotion.Text = "以下设置仅适用于TCP Client模式";
            // 
            // labDestPort
            // 
            this.labDestPort.AutoSize = true;
            this.labDestPort.Location = new System.Drawing.Point(58, 330);
            this.labDestPort.Name = "labDestPort";
            this.labDestPort.Size = new System.Drawing.Size(53, 12);
            this.labDestPort.TabIndex = 23;
            this.labDestPort.Text = "目的端口";
            // 
            // labDestIP
            // 
            this.labDestIP.AutoSize = true;
            this.labDestIP.Location = new System.Drawing.Point(59, 291);
            this.labDestIP.Name = "labDestIP";
            this.labDestIP.Size = new System.Drawing.Size(41, 12);
            this.labDestIP.TabIndex = 22;
            this.labDestIP.Text = "目的IP";
            // 
            // labGateway
            // 
            this.labGateway.AutoSize = true;
            this.labGateway.Location = new System.Drawing.Point(58, 219);
            this.labGateway.Name = "labGateway";
            this.labGateway.Size = new System.Drawing.Size(29, 12);
            this.labGateway.TabIndex = 21;
            this.labGateway.Text = "网关";
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(58, 178);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(41, 12);
            this.labPort.TabIndex = 20;
            this.labPort.Text = "端口号";
            // 
            // labMask
            // 
            this.labMask.AutoSize = true;
            this.labMask.Location = new System.Drawing.Point(58, 142);
            this.labMask.Name = "labMask";
            this.labMask.Size = new System.Drawing.Size(53, 12);
            this.labMask.TabIndex = 19;
            this.labMask.Text = "子网掩码";
            // 
            // labIPAdd
            // 
            this.labIPAdd.AutoSize = true;
            this.labIPAdd.Location = new System.Drawing.Point(58, 101);
            this.labIPAdd.Name = "labIPAdd";
            this.labIPAdd.Size = new System.Drawing.Size(41, 12);
            this.labIPAdd.TabIndex = 18;
            this.labIPAdd.Text = "IP地址";
            // 
            // labIPMode
            // 
            this.labIPMode.AutoSize = true;
            this.labIPMode.Location = new System.Drawing.Point(58, 66);
            this.labIPMode.Name = "labIPMode";
            this.labIPMode.Size = new System.Drawing.Size(41, 12);
            this.labIPMode.TabIndex = 17;
            this.labIPMode.Text = "IP模式";
            // 
            // labNetMode
            // 
            this.labNetMode.AutoSize = true;
            this.labNetMode.Location = new System.Drawing.Point(58, 31);
            this.labNetMode.Name = "labNetMode";
            this.labNetMode.Size = new System.Drawing.Size(53, 12);
            this.labNetMode.TabIndex = 16;
            this.labNetMode.Text = "工作模式";
            // 
            // textBoxDestPort
            // 
            this.textBoxDestPort.Location = new System.Drawing.Point(177, 327);
            this.textBoxDestPort.Name = "textBoxDestPort";
            this.textBoxDestPort.Size = new System.Drawing.Size(106, 21);
            this.textBoxDestPort.TabIndex = 13;
            // 
            // textBoxDestIP
            // 
            this.textBoxDestIP.Location = new System.Drawing.Point(177, 286);
            this.textBoxDestIP.Name = "textBoxDestIP";
            this.textBoxDestIP.Size = new System.Drawing.Size(106, 21);
            this.textBoxDestIP.TabIndex = 12;
            // 
            // textBoxGateway
            // 
            this.textBoxGateway.Location = new System.Drawing.Point(177, 215);
            this.textBoxGateway.Name = "textBoxGateway";
            this.textBoxGateway.Size = new System.Drawing.Size(106, 21);
            this.textBoxGateway.TabIndex = 11;
            // 
            // textBoxPortNo
            // 
            this.textBoxPortNo.Location = new System.Drawing.Point(177, 175);
            this.textBoxPortNo.Name = "textBoxPortNo";
            this.textBoxPortNo.Size = new System.Drawing.Size(106, 21);
            this.textBoxPortNo.TabIndex = 10;
            // 
            // textBoxNetMask
            // 
            this.textBoxNetMask.Location = new System.Drawing.Point(177, 138);
            this.textBoxNetMask.Name = "textBoxNetMask";
            this.textBoxNetMask.Size = new System.Drawing.Size(106, 21);
            this.textBoxNetMask.TabIndex = 9;
            // 
            // textBoxIPAdd
            // 
            this.textBoxIPAdd.Location = new System.Drawing.Point(177, 98);
            this.textBoxIPAdd.Name = "textBoxIPAdd";
            this.textBoxIPAdd.Size = new System.Drawing.Size(106, 21);
            this.textBoxIPAdd.TabIndex = 8;
            // 
            // comboBoxIPMode
            // 
            this.comboBoxIPMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIPMode.FormattingEnabled = true;
            this.comboBoxIPMode.Location = new System.Drawing.Point(178, 63);
            this.comboBoxIPMode.Name = "comboBoxIPMode";
            this.comboBoxIPMode.Size = new System.Drawing.Size(106, 20);
            this.comboBoxIPMode.TabIndex = 4;
            // 
            // comboBoxNetMode
            // 
            this.comboBoxNetMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNetMode.FormattingEnabled = true;
            this.comboBoxNetMode.Location = new System.Drawing.Point(177, 28);
            this.comboBoxNetMode.Name = "comboBoxNetMode";
            this.comboBoxNetMode.Size = new System.Drawing.Size(106, 20);
            this.comboBoxNetMode.TabIndex = 3;
            // 
            // btnSetParams
            // 
            this.btnSetParams.Location = new System.Drawing.Point(631, 391);
            this.btnSetParams.Name = "btnSetParams";
            this.btnSetParams.Size = new System.Drawing.Size(100, 35);
            this.btnSetParams.TabIndex = 15;
            this.btnSetParams.Text = "设置参数";
            this.btnSetParams.UseVisualStyleBackColor = true;
            this.btnSetParams.Click += new System.EventHandler(this.btnSetParams_Click);
            // 
            // btnDefaultParams
            // 
            this.btnDefaultParams.Location = new System.Drawing.Point(477, 392);
            this.btnDefaultParams.Name = "btnDefaultParams";
            this.btnDefaultParams.Size = new System.Drawing.Size(100, 35);
            this.btnDefaultParams.TabIndex = 14;
            this.btnDefaultParams.Text = "默认参数";
            this.btnDefaultParams.UseVisualStyleBackColor = true;
            this.btnDefaultParams.Click += new System.EventHandler(this.btnDefaultParams_Click);
            // 
            // btnModifyDev
            // 
            this.btnModifyDev.Location = new System.Drawing.Point(251, 263);
            this.btnModifyDev.Name = "btnModifyDev";
            this.btnModifyDev.Size = new System.Drawing.Size(100, 35);
            this.btnModifyDev.TabIndex = 2;
            this.btnModifyDev.Text = "编辑设备";
            this.btnModifyDev.UseVisualStyleBackColor = true;
            this.btnModifyDev.Click += new System.EventHandler(this.btnModifyDev_Click);
            // 
            // btnSearchDev
            // 
            this.btnSearchDev.Location = new System.Drawing.Point(99, 263);
            this.btnSearchDev.Name = "btnSearchDev";
            this.btnSearchDev.Size = new System.Drawing.Size(100, 35);
            this.btnSearchDev.TabIndex = 1;
            this.btnSearchDev.Text = "搜索设备";
            this.btnSearchDev.UseVisualStyleBackColor = true;
            this.btnSearchDev.Click += new System.EventHandler(this.btnSearchDev_Click);
            // 
            // lvZl
            // 
            this.lvZl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNo,
            this.columnHeaderIPAdd,
            this.columnHeaderPort,
            this.columnHeaderMAC});
            this.lvZl.Location = new System.Drawing.Point(52, 22);
            this.lvZl.Name = "lvZl";
            this.lvZl.Size = new System.Drawing.Size(346, 220);
            this.lvZl.TabIndex = 0;
            this.lvZl.UseCompatibleStateImageBehavior = false;
            this.lvZl.View = System.Windows.Forms.View.Details;
            this.lvZl.ItemActivate += new System.EventHandler(this.listViewDev_ItemActivate);
            // 
            // columnHeaderNo
            // 
            this.columnHeaderNo.Text = "序号";
            // 
            // columnHeaderIPAdd
            // 
            this.columnHeaderIPAdd.Text = "IP地址";
            this.columnHeaderIPAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderIPAdd.Width = 120;
            // 
            // columnHeaderPort
            // 
            this.columnHeaderPort.Text = "端口";
            this.columnHeaderPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderMAC
            // 
            this.columnHeaderMAC.Text = "MAC地址";
            this.columnHeaderMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMAC.Width = 120;
            // 
            // SetReaderParam
            // 
            this.SetReaderParam.Controls.Add(this.labSetParam);
            this.SetReaderParam.Controls.Add(this.gbDevParams);
            this.SetReaderParam.Controls.Add(this.gbIOOpr);
            this.SetReaderParam.Location = new System.Drawing.Point(4, 22);
            this.SetReaderParam.Name = "SetReaderParam";
            this.SetReaderParam.Padding = new System.Windows.Forms.Padding(3);
            this.SetReaderParam.Size = new System.Drawing.Size(846, 443);
            this.SetReaderParam.TabIndex = 3;
            this.SetReaderParam.Text = "读写器参数及IO操作";
            this.SetReaderParam.UseVisualStyleBackColor = true;
            // 
            // labSetParam
            // 
            this.labSetParam.AutoSize = true;
            this.labSetParam.Location = new System.Drawing.Point(64, 405);
            this.labSetParam.Name = "labSetParam";
            this.labSetParam.Size = new System.Drawing.Size(0, 12);
            this.labSetParam.TabIndex = 14;
            // 
            // gbDevParams
            // 
            this.gbDevParams.Controls.Add(this.btnSetHeartTime);
            this.gbDevParams.Controls.Add(this.btnSetNeighJudge);
            this.gbDevParams.Controls.Add(this.btnSetDevNo);
            this.gbDevParams.Controls.Add(this.labDevNo);
            this.gbDevParams.Controls.Add(this.labNeightJudge);
            this.gbDevParams.Controls.Add(this.labAlive);
            this.gbDevParams.Controls.Add(this.tbHeartTime);
            this.gbDevParams.Controls.Add(this.tbNeighJudge);
            this.gbDevParams.Controls.Add(this.tbDevNo);
            this.gbDevParams.Location = new System.Drawing.Point(48, 42);
            this.gbDevParams.Name = "gbDevParams";
            this.gbDevParams.Size = new System.Drawing.Size(325, 232);
            this.gbDevParams.TabIndex = 13;
            this.gbDevParams.TabStop = false;
            this.gbDevParams.Text = "设备参数";
            // 
            // btnSetHeartTime
            // 
            this.btnSetHeartTime.Location = new System.Drawing.Point(219, 166);
            this.btnSetHeartTime.Name = "btnSetHeartTime";
            this.btnSetHeartTime.Size = new System.Drawing.Size(82, 30);
            this.btnSetHeartTime.TabIndex = 13;
            this.btnSetHeartTime.Text = "设置";
            this.btnSetHeartTime.UseVisualStyleBackColor = true;
            this.btnSetHeartTime.Click += new System.EventHandler(this.btnSetHeartTime_Click);
            // 
            // btnSetNeighJudge
            // 
            this.btnSetNeighJudge.Location = new System.Drawing.Point(219, 90);
            this.btnSetNeighJudge.Name = "btnSetNeighJudge";
            this.btnSetNeighJudge.Size = new System.Drawing.Size(82, 30);
            this.btnSetNeighJudge.TabIndex = 12;
            this.btnSetNeighJudge.Text = "设置";
            this.btnSetNeighJudge.UseVisualStyleBackColor = true;
            this.btnSetNeighJudge.Click += new System.EventHandler(this.btnSetNeighJudge_Click);
            // 
            // btnSetDevNo
            // 
            this.btnSetDevNo.Location = new System.Drawing.Point(219, 22);
            this.btnSetDevNo.Name = "btnSetDevNo";
            this.btnSetDevNo.Size = new System.Drawing.Size(82, 30);
            this.btnSetDevNo.TabIndex = 8;
            this.btnSetDevNo.Text = "设置";
            this.btnSetDevNo.UseVisualStyleBackColor = true;
            this.btnSetDevNo.Click += new System.EventHandler(this.btnSetDevNo_Click);
            // 
            // labDevNo
            // 
            this.labDevNo.AutoSize = true;
            this.labDevNo.Location = new System.Drawing.Point(29, 28);
            this.labDevNo.Name = "labDevNo";
            this.labDevNo.Size = new System.Drawing.Size(41, 12);
            this.labDevNo.TabIndex = 11;
            this.labDevNo.Text = "设备号";
            // 
            // labNeightJudge
            // 
            this.labNeightJudge.AutoSize = true;
            this.labNeightJudge.Location = new System.Drawing.Point(26, 99);
            this.labNeightJudge.Name = "labNeightJudge";
            this.labNeightJudge.Size = new System.Drawing.Size(53, 12);
            this.labNeightJudge.TabIndex = 10;
            this.labNeightJudge.Text = "相邻判定";
            // 
            // labAlive
            // 
            this.labAlive.AutoSize = true;
            this.labAlive.Location = new System.Drawing.Point(29, 175);
            this.labAlive.Name = "labAlive";
            this.labAlive.Size = new System.Drawing.Size(53, 12);
            this.labAlive.TabIndex = 9;
            this.labAlive.Text = "心跳时间";
            // 
            // tbHeartTime
            // 
            this.tbHeartTime.Location = new System.Drawing.Point(133, 172);
            this.tbHeartTime.Name = "tbHeartTime";
            this.tbHeartTime.Size = new System.Drawing.Size(60, 21);
            this.tbHeartTime.TabIndex = 8;
            // 
            // tbNeighJudge
            // 
            this.tbNeighJudge.Location = new System.Drawing.Point(133, 96);
            this.tbNeighJudge.Name = "tbNeighJudge";
            this.tbNeighJudge.Size = new System.Drawing.Size(60, 21);
            this.tbNeighJudge.TabIndex = 1;
            // 
            // tbDevNo
            // 
            this.tbDevNo.Location = new System.Drawing.Point(133, 28);
            this.tbDevNo.Name = "tbDevNo";
            this.tbDevNo.Size = new System.Drawing.Size(60, 21);
            this.tbDevNo.TabIndex = 0;
            // 
            // gbIOOpr
            // 
            this.gbIOOpr.Controls.Add(this.btnSetOutPort);
            this.gbIOOpr.Controls.Add(this.btnGetDI);
            this.gbIOOpr.Controls.Add(this.cbOut2);
            this.gbIOOpr.Controls.Add(this.cbOut1);
            this.gbIOOpr.Controls.Add(this.cbIn2);
            this.gbIOOpr.Controls.Add(this.cbIn1);
            this.gbIOOpr.Location = new System.Drawing.Point(394, 42);
            this.gbIOOpr.Name = "gbIOOpr";
            this.gbIOOpr.Size = new System.Drawing.Size(354, 232);
            this.gbIOOpr.TabIndex = 12;
            this.gbIOOpr.TabStop = false;
            this.gbIOOpr.Text = "I/O口操作";
            // 
            // btnSetOutPort
            // 
            this.btnSetOutPort.Location = new System.Drawing.Point(238, 146);
            this.btnSetOutPort.Name = "btnSetOutPort";
            this.btnSetOutPort.Size = new System.Drawing.Size(82, 30);
            this.btnSetOutPort.TabIndex = 7;
            this.btnSetOutPort.Text = "设置";
            this.btnSetOutPort.UseVisualStyleBackColor = true;
            this.btnSetOutPort.Click += new System.EventHandler(this.btnSetOutPort_Click);
            // 
            // btnGetDI
            // 
            this.btnGetDI.Location = new System.Drawing.Point(238, 60);
            this.btnGetDI.Name = "btnGetDI";
            this.btnGetDI.Size = new System.Drawing.Size(82, 30);
            this.btnGetDI.TabIndex = 6;
            this.btnGetDI.Text = "读取";
            this.btnGetDI.UseVisualStyleBackColor = true;
            this.btnGetDI.Click += new System.EventHandler(this.btnGetInPort_Click);
            // 
            // cbOut2
            // 
            this.cbOut2.AutoSize = true;
            this.cbOut2.Location = new System.Drawing.Point(138, 154);
            this.cbOut2.Name = "cbOut2";
            this.cbOut2.Size = new System.Drawing.Size(66, 16);
            this.cbOut2.TabIndex = 5;
            this.cbOut2.Text = "输出口2";
            this.cbOut2.UseVisualStyleBackColor = true;
            // 
            // cbOut1
            // 
            this.cbOut1.AutoSize = true;
            this.cbOut1.Location = new System.Drawing.Point(29, 154);
            this.cbOut1.Name = "cbOut1";
            this.cbOut1.Size = new System.Drawing.Size(66, 16);
            this.cbOut1.TabIndex = 4;
            this.cbOut1.Text = "输出口1";
            this.cbOut1.UseVisualStyleBackColor = true;
            // 
            // cbIn2
            // 
            this.cbIn2.AutoSize = true;
            this.cbIn2.Location = new System.Drawing.Point(138, 68);
            this.cbIn2.Name = "cbIn2";
            this.cbIn2.Size = new System.Drawing.Size(66, 16);
            this.cbIn2.TabIndex = 3;
            this.cbIn2.Text = "输入口2";
            this.cbIn2.UseVisualStyleBackColor = true;
            // 
            // cbIn1
            // 
            this.cbIn1.AutoSize = true;
            this.cbIn1.Location = new System.Drawing.Point(29, 68);
            this.cbIn1.Name = "cbIn1";
            this.cbIn1.Size = new System.Drawing.Size(66, 16);
            this.cbIn1.TabIndex = 2;
            this.cbIn1.Text = "输入口1";
            this.cbIn1.UseVisualStyleBackColor = true;
            // 
            // timerConnect
            // 
            this.timerConnect.Tick += new System.EventHandler(this.timerConnect_Tick);
            // 
            // cbbLangSwitch
            // 
            this.cbbLangSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLangSwitch.FormattingEnabled = true;
            this.cbbLangSwitch.Items.AddRange(new object[] {
            "简体中文",
            "English"});
            this.cbbLangSwitch.Location = new System.Drawing.Point(712, 5);
            this.cbbLangSwitch.Name = "cbbLangSwitch";
            this.cbbLangSwitch.Size = new System.Drawing.Size(76, 20);
            this.cbbLangSwitch.TabIndex = 1;
            this.cbbLangSwitch.SelectedIndexChanged += new System.EventHandler(this.cbbLangSwitch_SelectedIndexChanged);
            // 
            // cbSaveFile
            // 
            this.cbSaveFile.AutoSize = true;
            this.cbSaveFile.Location = new System.Drawing.Point(697, 356);
            this.cbSaveFile.Name = "cbSaveFile";
            this.cbSaveFile.Size = new System.Drawing.Size(84, 16);
            this.cbSaveFile.TabIndex = 38;
            this.cbSaveFile.Text = "保存为文件";
            this.cbSaveFile.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 493);
            this.Controls.Add(this.cbbLangSwitch);
            this.Controls.Add(this.tabControl);
            this.Name = "MainWindow";
            this.Text = "R2kDemo_C#_V1.0";
            this.tabControl.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.gbCommMode.ResumeLayout(false);
            this.gbCommMode.PerformLayout();
            this.gbAntParams.ResumeLayout(false);
            this.gbAntParams.PerformLayout();
            this.TagAccess.ResumeLayout(false);
            this.TagAccess.PerformLayout();
            this.gbDestroyTag.ResumeLayout(false);
            this.gbDestroyTag.PerformLayout();
            this.gbLockTag.ResumeLayout(false);
            this.gbLockTag.PerformLayout();
            this.gbRWData.ResumeLayout(false);
            this.gbRWData.PerformLayout();
            this.SetCommParam.ResumeLayout(false);
            this.gbSPParams.ResumeLayout(false);
            this.gbSPParams.PerformLayout();
            this.gbNetParams.ResumeLayout(false);
            this.gbNetParams.PerformLayout();
            this.SetReaderParam.ResumeLayout(false);
            this.SetReaderParam.PerformLayout();
            this.gbDevParams.ResumeLayout(false);
            this.gbDevParams.PerformLayout();
            this.gbIOOpr.ResumeLayout(false);
            this.gbIOOpr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage TagAccess;
        private System.Windows.Forms.TabPage SetCommParam;
        private System.Windows.Forms.TabPage SetReaderParam;
        private System.Windows.Forms.Button btnClearListView;
        private System.Windows.Forms.Button btnStopReadData;
        private System.Windows.Forms.Button btnStartReadData;
        private System.Windows.Forms.Button btnReadOnce;
       // private System.Windows.Forms.ListView listView;
        private ListViewNF listView;
        private System.Windows.Forms.ComboBox comboBoxIP;
        private System.Windows.Forms.Label labCommPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox comboBoxSerialCommPort;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox comboBoxWT4;
        private System.Windows.Forms.ComboBox comboBoxPower4;
        private System.Windows.Forms.ComboBox comboBoxWT3;
        private System.Windows.Forms.ComboBox comboBoxPower3;
        private System.Windows.Forms.ComboBox comboBoxWT2;
        private System.Windows.Forms.ComboBox comboBoxPower2;
        private System.Windows.Forms.ComboBox comboBoxWT1;
        private System.Windows.Forms.ComboBox comboBoxPower1;
        private System.Windows.Forms.CheckBox cbAnt4;
        private System.Windows.Forms.CheckBox cbAnt3;
        private System.Windows.Forms.CheckBox cbAnt2;
        private System.Windows.Forms.CheckBox cbAnt1;
        private System.Windows.Forms.Button btnSetAnts;
        private System.Windows.Forms.Button btnGetAnts;
        private System.Windows.Forms.GroupBox gbAntParams;
        private System.Windows.Forms.RadioButton rbNet;
        private System.Windows.Forms.RadioButton rbSerialPort;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.RadioButton rbDesc;
        private System.Windows.Forms.RadioButton rbAsc;
        private System.Windows.Forms.GroupBox gbCommMode;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelTagCount;
        private System.Windows.Forms.Label labReadCount;
        private System.Windows.Forms.Label labTagCount;
        private System.Windows.Forms.TextBox textBoxIPAdd;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxCheckBits;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxIPMode;
        private System.Windows.Forms.ComboBox comboBoxNetMode;
        private System.Windows.Forms.Button btnModifyDev;
        private System.Windows.Forms.Button btnSearchDev;
        private System.Windows.Forms.ListView lvZl;
        private System.Windows.Forms.Label labGateway;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.Label labMask;
        private System.Windows.Forms.Label labIPAdd;
        private System.Windows.Forms.Label labIPMode;
        private System.Windows.Forms.Label labNetMode;
        private System.Windows.Forms.Button btnSetParams;
        private System.Windows.Forms.Button btnDefaultParams;
        private System.Windows.Forms.TextBox textBoxDestPort;
        private System.Windows.Forms.TextBox textBoxDestIP;
        private System.Windows.Forms.TextBox textBoxGateway;
        private System.Windows.Forms.TextBox textBoxPortNo;
        private System.Windows.Forms.TextBox textBoxNetMask;
        private System.Windows.Forms.GroupBox gbNetParams;
        private System.Windows.Forms.Label labPromotion;
        private System.Windows.Forms.Label labDestPort;
        private System.Windows.Forms.Label labDestIP;
        private System.Windows.Forms.GroupBox gbSPParams;
        private System.Windows.Forms.Label labDataBits;
        private System.Windows.Forms.Label labCheckBits;
        private System.Windows.Forms.Label labBaudRate;
        private System.Windows.Forms.ColumnHeader columnHeaderNo;
        private System.Windows.Forms.ColumnHeader columnHeaderIPAdd;
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderMAC;
        private System.Windows.Forms.GroupBox gbDestroyTag;
        private System.Windows.Forms.Button btnKillTag;
        private System.Windows.Forms.Label labDestroyPwd;
        private System.Windows.Forms.TextBox tbKillKillPwd;
        private System.Windows.Forms.Label labDesAccessPwd;
        private System.Windows.Forms.TextBox tbKillAccessPwd;
        private System.Windows.Forms.GroupBox gbLockTag;
        private System.Windows.Forms.Button btnLockTag;
        private System.Windows.Forms.Label labLockType;
        private System.Windows.Forms.Label labLockBank;
        private System.Windows.Forms.Label labLockAccessPwd;
        private System.Windows.Forms.TextBox tbLockAccessPwd;
        private System.Windows.Forms.ComboBox cbbLockType;
        private System.Windows.Forms.ComboBox cbbLockBank;
        private System.Windows.Forms.GroupBox gbRWData;
        private System.Windows.Forms.Label labRWAccessPwd;
        private System.Windows.Forms.Label labData;
        private System.Windows.Forms.Label labLength;
        private System.Windows.Forms.Label labStartAdd;
        private System.Windows.Forms.Label labOprBank;
        private System.Windows.Forms.TextBox tbRWAccessPwd;
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.TextBox tbRWData;
        private System.Windows.Forms.ComboBox cbbLength;
        private System.Windows.Forms.ComboBox cbbStartAdd;
        private System.Windows.Forms.ComboBox cbbRWBank;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.GroupBox gbDevParams;
        private System.Windows.Forms.Label labDevNo;
        private System.Windows.Forms.Label labNeightJudge;
        private System.Windows.Forms.Label labAlive;
        private System.Windows.Forms.TextBox tbHeartTime;
        private System.Windows.Forms.TextBox tbNeighJudge;
        private System.Windows.Forms.TextBox tbDevNo;
        private System.Windows.Forms.GroupBox gbIOOpr;
        private System.Windows.Forms.Button btnSetOutPort;
        private System.Windows.Forms.Button btnGetDI;
        private System.Windows.Forms.CheckBox cbOut2;
        private System.Windows.Forms.CheckBox cbOut1;
        private System.Windows.Forms.CheckBox cbIn2;
        private System.Windows.Forms.CheckBox cbIn1;
        private System.Windows.Forms.Button btnSetHeartTime;
        private System.Windows.Forms.Button btnSetNeighJudge;
        private System.Windows.Forms.Button btnSetDevNo;
        private System.Windows.Forms.Label labSetParam;
        private System.Windows.Forms.Timer timerConnect;
        private System.Windows.Forms.Label labAntUnit;
        private System.Windows.Forms.ComboBox cbbLangSwitch;
        private System.Windows.Forms.CheckBox cbSaveFile;
    }
}

