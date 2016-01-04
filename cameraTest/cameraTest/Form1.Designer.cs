namespace cameraTest
{
    partial class Form1
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
            this.videoPlayer = new AForge.Controls.VideoSourcePlayer();
            this.list_cam = new System.Windows.Forms.ComboBox();
            this.list_com = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.button_cam_open = new System.Windows.Forms.Button();
            this.button_cam_close = new System.Windows.Forms.Button();
            this.button_com_open = new System.Windows.Forms.Button();
            this.button_com_close = new System.Windows.Forms.Button();
            this.text_info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // videoPlayer
            // 
            this.videoPlayer.Location = new System.Drawing.Point(161, 12);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.Size = new System.Drawing.Size(292, 237);
            this.videoPlayer.TabIndex = 0;
            this.videoPlayer.Text = "videoSourcePlayer1";
            this.videoPlayer.VideoSource = null;
            // 
            // list_cam
            // 
            this.list_cam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.list_cam.FormattingEnabled = true;
            this.list_cam.Location = new System.Drawing.Point(24, 89);
            this.list_cam.Name = "list_cam";
            this.list_cam.Size = new System.Drawing.Size(121, 20);
            this.list_cam.TabIndex = 1;
            // 
            // list_com
            // 
            this.list_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.list_com.FormattingEnabled = true;
            this.list_com.Location = new System.Drawing.Point(24, 34);
            this.list_com.Name = "list_com";
            this.list_com.Size = new System.Drawing.Size(121, 20);
            this.list_com.TabIndex = 2;
            // 
            // button_cam_open
            // 
            this.button_cam_open.Location = new System.Drawing.Point(24, 115);
            this.button_cam_open.Name = "button_cam_open";
            this.button_cam_open.Size = new System.Drawing.Size(50, 23);
            this.button_cam_open.TabIndex = 3;
            this.button_cam_open.Text = "打开";
            this.button_cam_open.UseVisualStyleBackColor = true;
            this.button_cam_open.Click += new System.EventHandler(this.button_cam_open_Click);
            // 
            // button_cam_close
            // 
            this.button_cam_close.Location = new System.Drawing.Point(95, 115);
            this.button_cam_close.Name = "button_cam_close";
            this.button_cam_close.Size = new System.Drawing.Size(50, 23);
            this.button_cam_close.TabIndex = 4;
            this.button_cam_close.Text = "关闭";
            this.button_cam_close.UseVisualStyleBackColor = true;
            this.button_cam_close.Click += new System.EventHandler(this.button_cam_close_Click);
            // 
            // button_com_open
            // 
            this.button_com_open.Location = new System.Drawing.Point(24, 60);
            this.button_com_open.Name = "button_com_open";
            this.button_com_open.Size = new System.Drawing.Size(50, 23);
            this.button_com_open.TabIndex = 5;
            this.button_com_open.Text = "打开";
            this.button_com_open.UseVisualStyleBackColor = true;
            this.button_com_open.Click += new System.EventHandler(this.button_com_open_Click);
            // 
            // button_com_close
            // 
            this.button_com_close.Location = new System.Drawing.Point(95, 60);
            this.button_com_close.Name = "button_com_close";
            this.button_com_close.Size = new System.Drawing.Size(50, 23);
            this.button_com_close.TabIndex = 6;
            this.button_com_close.Text = "关闭";
            this.button_com_close.UseVisualStyleBackColor = true;
            this.button_com_close.Click += new System.EventHandler(this.button_com_close_Click);
            // 
            // text_info
            // 
            this.text_info.Location = new System.Drawing.Point(24, 162);
            this.text_info.Multiline = true;
            this.text_info.Name = "text_info";
            this.text_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_info.Size = new System.Drawing.Size(121, 87);
            this.text_info.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 261);
            this.Controls.Add(this.text_info);
            this.Controls.Add(this.button_com_close);
            this.Controls.Add(this.button_com_open);
            this.Controls.Add(this.button_cam_close);
            this.Controls.Add(this.button_cam_open);
            this.Controls.Add(this.list_com);
            this.Controls.Add(this.list_cam);
            this.Controls.Add(this.videoPlayer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoPlayer;
        private System.Windows.Forms.ComboBox list_cam;
        private System.Windows.Forms.ComboBox list_com;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button button_cam_open;
        private System.Windows.Forms.Button button_cam_close;
        private System.Windows.Forms.Button button_com_open;
        private System.Windows.Forms.Button button_com_close;
        private System.Windows.Forms.TextBox text_info;


    }
}

