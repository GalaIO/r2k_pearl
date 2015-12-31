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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labCommPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.comboBoxIP = new System.Windows.Forms.ComboBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.btnClearListView = new System.Windows.Forms.Button();
            this.btnStopReadData = new System.Windows.Forms.Button();
            this.btnStartReadData = new System.Windows.Forms.Button();
            this.btnReadOnce = new System.Windows.Forms.Button();
            this.timerConnect = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.General.SuspendLayout();
            this.gbCommMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.General);
            this.tabControl.Location = new System.Drawing.Point(4, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(491, 373);
            this.tabControl.TabIndex = 0;
            // 
            // General
            // 
            this.General.Controls.Add(this.labelCount);
            this.General.Controls.Add(this.labelTagCount);
            this.General.Controls.Add(this.labReadCount);
            this.General.Controls.Add(this.labTagCount);
            this.General.Controls.Add(this.gbCommMode);
            this.General.Controls.Add(this.labelVersion);
            this.General.Controls.Add(this.btnClearListView);
            this.General.Controls.Add(this.btnStopReadData);
            this.General.Controls.Add(this.btnStartReadData);
            this.General.Controls.Add(this.btnReadOnce);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(483, 347);
            this.General.TabIndex = 0;
            this.General.Text = "基本操作";
            this.General.UseVisualStyleBackColor = true;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(394, 324);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(11, 12);
            this.labelCount.TabIndex = 37;
            this.labelCount.Text = "0";
            // 
            // labelTagCount
            // 
            this.labelTagCount.AutoSize = true;
            this.labelTagCount.Location = new System.Drawing.Point(126, 324);
            this.labelTagCount.Name = "labelTagCount";
            this.labelTagCount.Size = new System.Drawing.Size(11, 12);
            this.labelTagCount.TabIndex = 36;
            this.labelTagCount.Text = "0";
            // 
            // labReadCount
            // 
            this.labReadCount.AutoSize = true;
            this.labReadCount.Location = new System.Drawing.Point(329, 324);
            this.labReadCount.Name = "labReadCount";
            this.labReadCount.Size = new System.Drawing.Size(59, 12);
            this.labReadCount.TabIndex = 35;
            this.labReadCount.Text = "读取次数:";
            // 
            // labTagCount
            // 
            this.labTagCount.AutoSize = true;
            this.labTagCount.Location = new System.Drawing.Point(53, 324);
            this.labTagCount.Name = "labTagCount";
            this.labTagCount.Size = new System.Drawing.Size(47, 12);
            this.labTagCount.TabIndex = 34;
            this.labTagCount.Text = "标签数:";
            // 
            // gbCommMode
            // 
            this.gbCommMode.Controls.Add(this.label1);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP";
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
            this.labCommPort.Location = new System.Drawing.Point(13, 68);
            this.labCommPort.Name = "labCommPort";
            this.labCommPort.Size = new System.Drawing.Size(41, 12);
            this.labCommPort.TabIndex = 7;
            this.labCommPort.Text = "端口号";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(69, 59);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(66, 21);
            this.textBoxPort.TabIndex = 6;
            // 
            // comboBoxIP
            // 
            this.comboBoxIP.FormattingEnabled = true;
            this.comboBoxIP.Location = new System.Drawing.Point(69, 24);
            this.comboBoxIP.Name = "comboBoxIP";
            this.comboBoxIP.Size = new System.Drawing.Size(112, 20);
            this.comboBoxIP.TabIndex = 5;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(53, 281);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(0, 12);
            this.labelVersion.TabIndex = 30;
            // 
            // btnClearListView
            // 
            this.btnClearListView.Location = new System.Drawing.Point(356, 213);
            this.btnClearListView.Name = "btnClearListView";
            this.btnClearListView.Size = new System.Drawing.Size(93, 38);
            this.btnClearListView.TabIndex = 4;
            this.btnClearListView.Text = "清空";
            this.btnClearListView.UseVisualStyleBackColor = true;
            this.btnClearListView.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStopReadData
            // 
            this.btnStopReadData.Location = new System.Drawing.Point(245, 213);
            this.btnStopReadData.Name = "btnStopReadData";
            this.btnStopReadData.Size = new System.Drawing.Size(93, 38);
            this.btnStopReadData.TabIndex = 3;
            this.btnStopReadData.Text = "停止连续寻卡";
            this.btnStopReadData.UseVisualStyleBackColor = true;
            this.btnStopReadData.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStartReadData
            // 
            this.btnStartReadData.Location = new System.Drawing.Point(134, 213);
            this.btnStartReadData.Name = "btnStartReadData";
            this.btnStartReadData.Size = new System.Drawing.Size(93, 38);
            this.btnStartReadData.TabIndex = 2;
            this.btnStartReadData.Text = "开始连续寻卡";
            this.btnStartReadData.UseVisualStyleBackColor = true;
            this.btnStartReadData.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReadOnce
            // 
            this.btnReadOnce.Location = new System.Drawing.Point(23, 213);
            this.btnReadOnce.Name = "btnReadOnce";
            this.btnReadOnce.Size = new System.Drawing.Size(93, 38);
            this.btnReadOnce.TabIndex = 1;
            this.btnReadOnce.Text = "寻卡一次";
            this.btnReadOnce.UseVisualStyleBackColor = true;
            this.btnReadOnce.Click += new System.EventHandler(this.btnInvokeOnce_Click);
            // 
            // timerConnect
            // 
            this.timerConnect.Tick += new System.EventHandler(this.timerConnect_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 390);
            this.Controls.Add(this.tabControl);
            this.Name = "MainWindow";
            this.Text = "R2kDemo_C#_V1.0";
            this.tabControl.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.gbCommMode.ResumeLayout(false);
            this.gbCommMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.Button btnClearListView;
        private System.Windows.Forms.Button btnStopReadData;
        private System.Windows.Forms.Button btnStartReadData;
        private System.Windows.Forms.Button btnReadOnce;
        // private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ComboBox comboBoxIP;
        private System.Windows.Forms.Label labCommPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.GroupBox gbCommMode;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelTagCount;
        private System.Windows.Forms.Label labReadCount;
        private System.Windows.Forms.Label labTagCount;
        private System.Windows.Forms.Timer timerConnect;
        private System.Windows.Forms.Label label1;
    }
}

