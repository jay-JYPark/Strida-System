using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Adeng.Framework.Util;

namespace ADEng.Strida
{
    public class StridaOptionForm : Form
    {
        #region instance
        private Button SaveBtn;
        private Button CancleBtn;
        private PictureBox OptionMainPB;
        private Panel OptionSidePN;
        private Label OptionMainLB;
        private TabControl MainTC;
        private TabPage TabPage1;
        private TextBox TcpPortTB;
        private Label TcpPortLB;
        private TextBox TcpIpTB;
        private Label TcpIpLB;
        private TabPage TabPage2;
        private Label StopBitLB;
        private Label ParityLB;
        private Label DataBitsLB;
        private Label BaudRateLB;
        private Label ComPortLB;
        private ComboBox StopBitCB;
        private ComboBox ParityCB;
        private ComboBox DataBitsCB;
        private ComboBox BaudRateCB;
        private ComboBox ComPortCB;
        private TabPage TabPage3;
        private TextBox UdpPortTB;
        private Label UdpPortLB;
        private TextBox UdpIpTB;
        private Label UdpIpLB;
        private Label TabPage1LB;
        private Label TabPage2LB;
        private Label TabPage3LB;
        private Panel OptionMainPN;
        #endregion

        #region var
        private readonly string IniFilePath = "C:\\Program Files\\AnD\\Strida\\Setting.ini";
        private readonly string setting = "setting";
        private readonly string portNum = "PortNum";
        private readonly string baudRate = "BaudRate";
        private readonly string dataBits = "DataBits";
        private readonly string parity = "Parity";
        private readonly string stopBit = "StopBit";
        private readonly string udpIp = "UdpIp";
        private readonly string udpPort = "UdpPort";
        private readonly string tcpIp = "TcpIp";
        private readonly string tcpSvrIp = "TcpSvrIp";
        private readonly string tcpSvrPort = "TcpSvrPort";
        private TabPage TabPage4;
        private Label TabPage4LB;
        private TextBox TcpSvrPortTB;
        private Label TcpSvrPortLB;
        private TextBox TcpSvrIpTB;
        private Label TcpSvrIpLB;
        private readonly string tcpPort = "TcpPort";
        #endregion

        /// <summary>
        /// 생성자
        /// </summary>
        public StridaOptionForm()
        {
            this.InitializeComponent();
            this.SerialInit();
            this.init();
            this.SaveBtn.Enabled = false;
        }

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancleBtn = new System.Windows.Forms.Button();
            this.OptionSidePN = new System.Windows.Forms.Panel();
            this.OptionMainLB = new System.Windows.Forms.Label();
            this.OptionMainPN = new System.Windows.Forms.Panel();
            this.OptionMainPB = new System.Windows.Forms.PictureBox();
            this.MainTC = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.TabPage1LB = new System.Windows.Forms.Label();
            this.TcpPortTB = new System.Windows.Forms.TextBox();
            this.TcpPortLB = new System.Windows.Forms.Label();
            this.TcpIpTB = new System.Windows.Forms.TextBox();
            this.TcpIpLB = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.TabPage2LB = new System.Windows.Forms.Label();
            this.StopBitLB = new System.Windows.Forms.Label();
            this.ParityLB = new System.Windows.Forms.Label();
            this.DataBitsLB = new System.Windows.Forms.Label();
            this.BaudRateLB = new System.Windows.Forms.Label();
            this.ComPortLB = new System.Windows.Forms.Label();
            this.StopBitCB = new System.Windows.Forms.ComboBox();
            this.ParityCB = new System.Windows.Forms.ComboBox();
            this.DataBitsCB = new System.Windows.Forms.ComboBox();
            this.BaudRateCB = new System.Windows.Forms.ComboBox();
            this.ComPortCB = new System.Windows.Forms.ComboBox();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.TabPage3LB = new System.Windows.Forms.Label();
            this.UdpPortTB = new System.Windows.Forms.TextBox();
            this.UdpPortLB = new System.Windows.Forms.Label();
            this.UdpIpTB = new System.Windows.Forms.TextBox();
            this.UdpIpLB = new System.Windows.Forms.Label();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.TabPage4LB = new System.Windows.Forms.Label();
            this.TcpSvrPortTB = new System.Windows.Forms.TextBox();
            this.TcpSvrPortLB = new System.Windows.Forms.Label();
            this.TcpSvrIpTB = new System.Windows.Forms.TextBox();
            this.TcpSvrIpLB = new System.Windows.Forms.Label();
            this.OptionMainPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionMainPB)).BeginInit();
            this.MainTC.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.TabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(160, 280);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 10;
            this.SaveBtn.Text = "저장";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancleBtn
            // 
            this.CancleBtn.Location = new System.Drawing.Point(241, 280);
            this.CancleBtn.Name = "CancleBtn";
            this.CancleBtn.Size = new System.Drawing.Size(75, 23);
            this.CancleBtn.TabIndex = 9;
            this.CancleBtn.Text = "닫기";
            this.CancleBtn.UseVisualStyleBackColor = true;
            this.CancleBtn.Click += new System.EventHandler(this.CancleBtn_Click);
            // 
            // OptionSidePN
            // 
            this.OptionSidePN.BackgroundImage = global::Strida.Properties.Resources.DMB_bar;
            this.OptionSidePN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionSidePN.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionSidePN.Location = new System.Drawing.Point(0, 40);
            this.OptionSidePN.Name = "OptionSidePN";
            this.OptionSidePN.Size = new System.Drawing.Size(328, 5);
            this.OptionSidePN.TabIndex = 7;
            // 
            // OptionMainLB
            // 
            this.OptionMainLB.AutoSize = true;
            this.OptionMainLB.BackColor = System.Drawing.Color.Transparent;
            this.OptionMainLB.Location = new System.Drawing.Point(12, 9);
            this.OptionMainLB.Name = "OptionMainLB";
            this.OptionMainLB.Size = new System.Drawing.Size(199, 12);
            this.OptionMainLB.TabIndex = 0;
            this.OptionMainLB.Text = "각종 설정 내용을 편집/저장 합니다.";
            // 
            // OptionMainPN
            // 
            this.OptionMainPN.BackgroundImage = global::Strida.Properties.Resources.DMB_dialogue_Bg;
            this.OptionMainPN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionMainPN.Controls.Add(this.OptionMainPB);
            this.OptionMainPN.Controls.Add(this.OptionMainLB);
            this.OptionMainPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionMainPN.Location = new System.Drawing.Point(0, 0);
            this.OptionMainPN.Name = "OptionMainPN";
            this.OptionMainPN.Size = new System.Drawing.Size(328, 40);
            this.OptionMainPN.TabIndex = 6;
            // 
            // OptionMainPB
            // 
            this.OptionMainPB.BackColor = System.Drawing.Color.Transparent;
            this.OptionMainPB.BackgroundImage = global::Strida.Properties.Resources.DMB_dialogue_control;
            this.OptionMainPB.Location = new System.Drawing.Point(276, 0);
            this.OptionMainPB.Name = "OptionMainPB";
            this.OptionMainPB.Size = new System.Drawing.Size(41, 40);
            this.OptionMainPB.TabIndex = 1;
            this.OptionMainPB.TabStop = false;
            // 
            // MainTC
            // 
            this.MainTC.Controls.Add(this.TabPage1);
            this.MainTC.Controls.Add(this.TabPage2);
            this.MainTC.Controls.Add(this.TabPage3);
            this.MainTC.Controls.Add(this.TabPage4);
            this.MainTC.Location = new System.Drawing.Point(12, 51);
            this.MainTC.Name = "MainTC";
            this.MainTC.SelectedIndex = 0;
            this.MainTC.Size = new System.Drawing.Size(305, 223);
            this.MainTC.TabIndex = 11;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.TabPage1LB);
            this.TabPage1.Controls.Add(this.TcpPortTB);
            this.TabPage1.Controls.Add(this.TcpPortLB);
            this.TabPage1.Controls.Add(this.TcpIpTB);
            this.TabPage1.Controls.Add(this.TcpIpLB);
            this.TabPage1.Location = new System.Drawing.Point(4, 21);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(297, 198);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "TCP 설정";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // TabPage1LB
            // 
            this.TabPage1LB.AutoSize = true;
            this.TabPage1LB.ForeColor = System.Drawing.Color.Blue;
            this.TabPage1LB.Location = new System.Drawing.Point(25, 164);
            this.TabPage1LB.Name = "TabPage1LB";
            this.TabPage1LB.Size = new System.Drawing.Size(251, 12);
            this.TabPage1LB.TabIndex = 19;
            this.TabPage1LB.Text = "※ OAE 연결을 위한 OAE 서버를 설정합니다.";
            // 
            // TcpPortTB
            // 
            this.TcpPortTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TcpPortTB.BackColor = System.Drawing.SystemColors.Window;
            this.TcpPortTB.Location = new System.Drawing.Point(111, 78);
            this.TcpPortTB.Margin = new System.Windows.Forms.Padding(2);
            this.TcpPortTB.MaxLength = 5;
            this.TcpPortTB.Name = "TcpPortTB";
            this.TcpPortTB.Size = new System.Drawing.Size(108, 21);
            this.TcpPortTB.TabIndex = 16;
            this.TcpPortTB.TextChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            this.TcpPortTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TcpPortTB_KeyDown);
            // 
            // TcpPortLB
            // 
            this.TcpPortLB.Location = new System.Drawing.Point(48, 78);
            this.TcpPortLB.Margin = new System.Windows.Forms.Padding(2);
            this.TcpPortLB.Name = "TcpPortLB";
            this.TcpPortLB.Size = new System.Drawing.Size(57, 21);
            this.TcpPortLB.TabIndex = 18;
            this.TcpPortLB.Text = "PORT : ";
            this.TcpPortLB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TcpIpTB
            // 
            this.TcpIpTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TcpIpTB.BackColor = System.Drawing.SystemColors.Window;
            this.TcpIpTB.Location = new System.Drawing.Point(111, 54);
            this.TcpIpTB.Margin = new System.Windows.Forms.Padding(2);
            this.TcpIpTB.MaxLength = 15;
            this.TcpIpTB.Name = "TcpIpTB";
            this.TcpIpTB.Size = new System.Drawing.Size(108, 21);
            this.TcpIpTB.TabIndex = 15;
            this.TcpIpTB.TextChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            this.TcpIpTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TcpIpTB_KeyDown);
            // 
            // TcpIpLB
            // 
            this.TcpIpLB.Location = new System.Drawing.Point(50, 54);
            this.TcpIpLB.Margin = new System.Windows.Forms.Padding(2);
            this.TcpIpLB.Name = "TcpIpLB";
            this.TcpIpLB.Size = new System.Drawing.Size(55, 21);
            this.TcpIpLB.TabIndex = 17;
            this.TcpIpLB.Text = "IP : ";
            this.TcpIpLB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.TabPage2LB);
            this.TabPage2.Controls.Add(this.StopBitLB);
            this.TabPage2.Controls.Add(this.ParityLB);
            this.TabPage2.Controls.Add(this.DataBitsLB);
            this.TabPage2.Controls.Add(this.BaudRateLB);
            this.TabPage2.Controls.Add(this.ComPortLB);
            this.TabPage2.Controls.Add(this.StopBitCB);
            this.TabPage2.Controls.Add(this.ParityCB);
            this.TabPage2.Controls.Add(this.DataBitsCB);
            this.TabPage2.Controls.Add(this.BaudRateCB);
            this.TabPage2.Controls.Add(this.ComPortCB);
            this.TabPage2.Location = new System.Drawing.Point(4, 21);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(297, 198);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Serial 설정";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // TabPage2LB
            // 
            this.TabPage2LB.AutoSize = true;
            this.TabPage2LB.ForeColor = System.Drawing.Color.Blue;
            this.TabPage2LB.Location = new System.Drawing.Point(25, 164);
            this.TabPage2LB.Name = "TabPage2LB";
            this.TabPage2LB.Size = new System.Drawing.Size(165, 12);
            this.TabPage2LB.TabIndex = 304;
            this.TabPage2LB.Text = "※ 민방위 연결을 설정합니다.";
            // 
            // StopBitLB
            // 
            this.StopBitLB.AutoSize = true;
            this.StopBitLB.Location = new System.Drawing.Point(47, 119);
            this.StopBitLB.Name = "StopBitLB";
            this.StopBitLB.Size = new System.Drawing.Size(61, 12);
            this.StopBitLB.TabIndex = 303;
            this.StopBitLB.Text = "정지비트 :";
            // 
            // ParityLB
            // 
            this.ParityLB.AutoSize = true;
            this.ParityLB.Location = new System.Drawing.Point(59, 96);
            this.ParityLB.Name = "ParityLB";
            this.ParityLB.Size = new System.Drawing.Size(49, 12);
            this.ParityLB.TabIndex = 302;
            this.ParityLB.Text = "패리티 :";
            // 
            // DataBitsLB
            // 
            this.DataBitsLB.AutoSize = true;
            this.DataBitsLB.Location = new System.Drawing.Point(35, 73);
            this.DataBitsLB.Name = "DataBitsLB";
            this.DataBitsLB.Size = new System.Drawing.Size(73, 12);
            this.DataBitsLB.TabIndex = 301;
            this.DataBitsLB.Text = "데이터비트 :";
            // 
            // BaudRateLB
            // 
            this.BaudRateLB.AutoSize = true;
            this.BaudRateLB.Location = new System.Drawing.Point(53, 50);
            this.BaudRateLB.Name = "BaudRateLB";
            this.BaudRateLB.Size = new System.Drawing.Size(55, 12);
            this.BaudRateLB.TabIndex = 300;
            this.BaudRateLB.Text = "비트/초 :";
            // 
            // ComPortLB
            // 
            this.ComPortLB.AutoSize = true;
            this.ComPortLB.Location = new System.Drawing.Point(44, 28);
            this.ComPortLB.Name = "ComPortLB";
            this.ComPortLB.Size = new System.Drawing.Size(64, 12);
            this.ComPortLB.TabIndex = 299;
            this.ComPortLB.Text = "Com포트 :";
            // 
            // StopBitCB
            // 
            this.StopBitCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopBitCB.FormattingEnabled = true;
            this.StopBitCB.Location = new System.Drawing.Point(121, 116);
            this.StopBitCB.Name = "StopBitCB";
            this.StopBitCB.Size = new System.Drawing.Size(136, 20);
            this.StopBitCB.TabIndex = 298;
            this.StopBitCB.SelectedIndexChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            // 
            // ParityCB
            // 
            this.ParityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParityCB.FormattingEnabled = true;
            this.ParityCB.Location = new System.Drawing.Point(121, 93);
            this.ParityCB.Name = "ParityCB";
            this.ParityCB.Size = new System.Drawing.Size(136, 20);
            this.ParityCB.TabIndex = 297;
            this.ParityCB.SelectedIndexChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            // 
            // DataBitsCB
            // 
            this.DataBitsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBitsCB.FormattingEnabled = true;
            this.DataBitsCB.Location = new System.Drawing.Point(121, 70);
            this.DataBitsCB.Name = "DataBitsCB";
            this.DataBitsCB.Size = new System.Drawing.Size(136, 20);
            this.DataBitsCB.TabIndex = 296;
            this.DataBitsCB.SelectedIndexChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            // 
            // BaudRateCB
            // 
            this.BaudRateCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudRateCB.FormattingEnabled = true;
            this.BaudRateCB.Location = new System.Drawing.Point(121, 47);
            this.BaudRateCB.Name = "BaudRateCB";
            this.BaudRateCB.Size = new System.Drawing.Size(136, 20);
            this.BaudRateCB.TabIndex = 295;
            this.BaudRateCB.SelectedIndexChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            // 
            // ComPortCB
            // 
            this.ComPortCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComPortCB.FormattingEnabled = true;
            this.ComPortCB.Location = new System.Drawing.Point(121, 24);
            this.ComPortCB.Name = "ComPortCB";
            this.ComPortCB.Size = new System.Drawing.Size(136, 20);
            this.ComPortCB.TabIndex = 294;
            this.ComPortCB.SelectedIndexChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.TabPage3LB);
            this.TabPage3.Controls.Add(this.UdpPortTB);
            this.TabPage3.Controls.Add(this.UdpPortLB);
            this.TabPage3.Controls.Add(this.UdpIpTB);
            this.TabPage3.Controls.Add(this.UdpIpLB);
            this.TabPage3.Location = new System.Drawing.Point(4, 21);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(297, 198);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "UDP 설정";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // TabPage3LB
            // 
            this.TabPage3LB.AutoSize = true;
            this.TabPage3LB.ForeColor = System.Drawing.Color.Blue;
            this.TabPage3LB.Location = new System.Drawing.Point(25, 164);
            this.TabPage3LB.Name = "TabPage3LB";
            this.TabPage3LB.Size = new System.Drawing.Size(156, 12);
            this.TabPage3LB.TabIndex = 305;
            this.TabPage3LB.Text = "※ DMB 연결을 설정합니다.";
            // 
            // UdpPortTB
            // 
            this.UdpPortTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UdpPortTB.BackColor = System.Drawing.SystemColors.Window;
            this.UdpPortTB.Location = new System.Drawing.Point(111, 78);
            this.UdpPortTB.Margin = new System.Windows.Forms.Padding(2);
            this.UdpPortTB.MaxLength = 5;
            this.UdpPortTB.Name = "UdpPortTB";
            this.UdpPortTB.Size = new System.Drawing.Size(108, 21);
            this.UdpPortTB.TabIndex = 20;
            this.UdpPortTB.TextChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            this.UdpPortTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TcpPortTB_KeyDown);
            // 
            // UdpPortLB
            // 
            this.UdpPortLB.Location = new System.Drawing.Point(48, 78);
            this.UdpPortLB.Margin = new System.Windows.Forms.Padding(2);
            this.UdpPortLB.Name = "UdpPortLB";
            this.UdpPortLB.Size = new System.Drawing.Size(57, 21);
            this.UdpPortLB.TabIndex = 22;
            this.UdpPortLB.Text = "PORT : ";
            this.UdpPortLB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UdpIpTB
            // 
            this.UdpIpTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UdpIpTB.BackColor = System.Drawing.SystemColors.Window;
            this.UdpIpTB.Location = new System.Drawing.Point(111, 54);
            this.UdpIpTB.Margin = new System.Windows.Forms.Padding(2);
            this.UdpIpTB.MaxLength = 15;
            this.UdpIpTB.Name = "UdpIpTB";
            this.UdpIpTB.Size = new System.Drawing.Size(108, 21);
            this.UdpIpTB.TabIndex = 19;
            this.UdpIpTB.TextChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            this.UdpIpTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TcpIpTB_KeyDown);
            // 
            // UdpIpLB
            // 
            this.UdpIpLB.Location = new System.Drawing.Point(50, 54);
            this.UdpIpLB.Margin = new System.Windows.Forms.Padding(2);
            this.UdpIpLB.Name = "UdpIpLB";
            this.UdpIpLB.Size = new System.Drawing.Size(55, 21);
            this.UdpIpLB.TabIndex = 21;
            this.UdpIpLB.Text = "IP : ";
            this.UdpIpLB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.TabPage4LB);
            this.TabPage4.Controls.Add(this.TcpSvrPortTB);
            this.TabPage4.Controls.Add(this.TcpSvrPortLB);
            this.TabPage4.Controls.Add(this.TcpSvrIpTB);
            this.TabPage4.Controls.Add(this.TcpSvrIpLB);
            this.TabPage4.Location = new System.Drawing.Point(4, 21);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage4.Size = new System.Drawing.Size(297, 198);
            this.TabPage4.TabIndex = 3;
            this.TabPage4.Text = "서버 설정";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // TabPage4LB
            // 
            this.TabPage4LB.AutoSize = true;
            this.TabPage4LB.ForeColor = System.Drawing.Color.Blue;
            this.TabPage4LB.Location = new System.Drawing.Point(25, 164);
            this.TabPage4LB.Name = "TabPage4LB";
            this.TabPage4LB.Size = new System.Drawing.Size(250, 12);
            this.TabPage4LB.TabIndex = 24;
            this.TabPage4LB.Text = "※ OAE 연결을 위한 로컬 서버를 설정합니다.";
            // 
            // TcpSvrPortTB
            // 
            this.TcpSvrPortTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TcpSvrPortTB.BackColor = System.Drawing.SystemColors.Window;
            this.TcpSvrPortTB.Location = new System.Drawing.Point(111, 78);
            this.TcpSvrPortTB.Margin = new System.Windows.Forms.Padding(2);
            this.TcpSvrPortTB.MaxLength = 5;
            this.TcpSvrPortTB.Name = "TcpSvrPortTB";
            this.TcpSvrPortTB.Size = new System.Drawing.Size(108, 21);
            this.TcpSvrPortTB.TabIndex = 21;
            this.TcpSvrPortTB.TextChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            this.TcpSvrPortTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TcpPortTB_KeyDown);
            // 
            // TcpSvrPortLB
            // 
            this.TcpSvrPortLB.Location = new System.Drawing.Point(48, 78);
            this.TcpSvrPortLB.Margin = new System.Windows.Forms.Padding(2);
            this.TcpSvrPortLB.Name = "TcpSvrPortLB";
            this.TcpSvrPortLB.Size = new System.Drawing.Size(57, 21);
            this.TcpSvrPortLB.TabIndex = 23;
            this.TcpSvrPortLB.Text = "PORT : ";
            this.TcpSvrPortLB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TcpSvrIpTB
            // 
            this.TcpSvrIpTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TcpSvrIpTB.BackColor = System.Drawing.SystemColors.Window;
            this.TcpSvrIpTB.Location = new System.Drawing.Point(111, 54);
            this.TcpSvrIpTB.Margin = new System.Windows.Forms.Padding(2);
            this.TcpSvrIpTB.MaxLength = 15;
            this.TcpSvrIpTB.Name = "TcpSvrIpTB";
            this.TcpSvrIpTB.Size = new System.Drawing.Size(108, 21);
            this.TcpSvrIpTB.TabIndex = 20;
            this.TcpSvrIpTB.TextChanged += new System.EventHandler(this.TcpIpTB_TextChanged);
            this.TcpSvrIpTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TcpIpTB_KeyDown);
            // 
            // TcpSvrIpLB
            // 
            this.TcpSvrIpLB.Location = new System.Drawing.Point(50, 54);
            this.TcpSvrIpLB.Margin = new System.Windows.Forms.Padding(2);
            this.TcpSvrIpLB.Name = "TcpSvrIpLB";
            this.TcpSvrIpLB.Size = new System.Drawing.Size(55, 21);
            this.TcpSvrIpLB.TabIndex = 22;
            this.TcpSvrIpLB.Text = "IP : ";
            this.TcpSvrIpLB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StridaOptionForm
            // 
            this.ClientSize = new System.Drawing.Size(328, 311);
            this.Controls.Add(this.MainTC);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CancleBtn);
            this.Controls.Add(this.OptionSidePN);
            this.Controls.Add(this.OptionMainPN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StridaOptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "환경 설정";
            this.OptionMainPN.ResumeLayout(false);
            this.OptionMainPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionMainPB)).EndInit();
            this.MainTC.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            this.TabPage4.ResumeLayout(false);
            this.TabPage4.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 데이터 초기화
        /// </summary>
        private void init()
        {
            this.ComPortCB.Text = AdengUtil.INIReadValueString(this.setting, this.portNum, this.IniFilePath);
            this.BaudRateCB.Text = AdengUtil.INIReadValueString(this.setting, this.baudRate, this.IniFilePath);
            this.DataBitsCB.Text = AdengUtil.INIReadValueString(this.setting, this.dataBits, this.IniFilePath);
            string p = AdengUtil.INIReadValueString(this.setting, this.parity, this.IniFilePath);
            this.StopBitCB.Text = AdengUtil.INIReadValueString(this.setting, this.stopBit, this.IniFilePath);
            this.UdpIpTB.Text = AdengUtil.INIReadValueString(this.setting, this.udpIp, this.IniFilePath);
            this.UdpPortTB.Text = AdengUtil.INIReadValueString(this.setting, this.udpPort, this.IniFilePath);
            this.TcpIpTB.Text = AdengUtil.INIReadValueString(this.setting, this.tcpIp, this.IniFilePath);
            this.TcpPortTB.Text = AdengUtil.INIReadValueString(this.setting, this.tcpPort, this.IniFilePath);
            this.TcpSvrIpTB.Text = AdengUtil.INIReadValueString(this.setting, this.tcpSvrIp, this.IniFilePath);
            this.TcpSvrPortTB.Text = AdengUtil.INIReadValueString(this.setting, this.tcpSvrPort, this.IniFilePath);

            //parity = 0이면 Parity.None
            //parity = 1이면 Parity.Even
            //parity = 2이면 Parity.Odd
            this.ParityCB.Text = (p == "2") ? "홀수" : (p == "1") ? "짝수" : "없음";
        }

        /// <summary>
        /// Serial 초기화
        /// </summary>
        private void SerialInit()
        {
            foreach (string portName in SerialPort.GetPortNames())
            {
                this.ComPortCB.Items.Add(portName);
            }

            this.ComPortCB.Sorted = true;

            this.BaudRateCB.Items.Add("2400");
            this.BaudRateCB.Items.Add("4800");
            this.BaudRateCB.Items.Add("9600");
            this.BaudRateCB.Items.Add("19200");
            this.BaudRateCB.Items.Add("38400");
            this.BaudRateCB.Items.Add("57600");
            this.BaudRateCB.Items.Add("115200");

            this.DataBitsCB.Items.Add("5");
            this.DataBitsCB.Items.Add("6");
            this.DataBitsCB.Items.Add("7");
            this.DataBitsCB.Items.Add("8");

            this.ParityCB.Items.Add("홀수");
            this.ParityCB.Items.Add("짝수");
            this.ParityCB.Items.Add("없음");

            this.StopBitCB.Items.Add("1");
            this.StopBitCB.Items.Add("1.5");
            this.StopBitCB.Items.Add("2");
        }

        /// <summary>
        /// 저장 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (this.SaveValidation())
            {
                AdengUtil.INIWriteValueString(this.setting, this.portNum, this.ComPortCB.Text, IniFilePath);
                AdengUtil.INIWriteValueString(this.setting, this.baudRate, this.BaudRateCB.Text, IniFilePath);
                AdengUtil.INIWriteValueString(this.setting, this.dataBits, this.DataBitsCB.Text, IniFilePath);
                AdengUtil.INIWriteValueString(this.setting, this.stopBit, this.StopBitCB.Text, IniFilePath);
                AdengUtil.INIWriteValueString(this.setting, this.udpIp, this.UdpIpTB.Text, IniFilePath);
                AdengUtil.INIWriteValueString(this.setting, this.udpPort, this.UdpPortTB.Text, IniFilePath);
                AdengUtil.INIWriteValueString(this.setting, this.tcpIp, this.TcpIpTB.Text, IniFilePath);
                AdengUtil.INIWriteValueString(this.setting, this.tcpPort, this.TcpPortTB.Text, IniFilePath);
                AdengUtil.INIWriteValueString(this.setting, this.tcpSvrIp, this.TcpSvrIpTB.Text, IniFilePath);
                AdengUtil.INIWriteValueString(this.setting, this.tcpSvrPort, this.TcpSvrPortTB.Text, IniFilePath);

                string tmpStr = (this.ParityCB.Text == "홀수") ? "2" :
                                (this.ParityCB.Text == "짝수") ? "1" : "0";
                AdengUtil.INIWriteValueString(this.setting, this.parity, tmpStr, IniFilePath);
                this.SaveBtn.Enabled = false;
            }
            else
            {
                MessageBox.Show("정보를 확인하세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 닫기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 저장 전 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool SaveValidation()
        {
            if (this.TcpIpTB.Text == string.Empty)
            {
                return false;
            }

            if (this.TcpPortTB.Text == string.Empty)
            {
                return false;
            }

            if (this.UdpIpTB.Text == string.Empty)
            {
                return false;
            }

            if (this.UdpPortTB.Text == string.Empty)
            {
                return false;
            }

            if (this.ComPortCB.Text == string.Empty)
            {
                return false;
            }

            if (this.TcpSvrIpTB.Text == string.Empty)
            {
                return false;
            }

            if (this.TcpSvrPortTB.Text == string.Empty)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 텍스트박스 변경 시..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpIpTB_TextChanged(object sender, EventArgs e)
        {
            this.SaveBtn.Enabled = true;
        }

        /// <summary>
        /// IP 텍스트박스 키 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpIpTB_KeyDown(object sender, KeyEventArgs e)
        {
            // 8 - 백스페이스
            // 46 - DEL
            // 37 - 좌 화살표
            // 38 - 위 화살표
            // 39 - 우 화살표
            // 40 - 아래 화살표
            // 16 - 쉬프트
            // 190 - '.'
            // 110 - '.'
            // (48 ~ 57) - 숫자 0 ~ 9 
            // (96 ~ 105) - 숫자 0 ~ 9
            // 35 - End
            // 36 - Home
            if (e.KeyValue == 8 || e.KeyValue == 46 || e.KeyValue == 37 || e.KeyValue == 38
                || e.KeyValue == 39 || e.KeyValue == 40 || e.KeyValue == 16 || e.KeyValue == 190 || e.KeyValue == 110
                || (e.KeyValue > 47 && e.KeyValue < 58)
                || (e.KeyValue > 95 && e.KeyValue < 106)
                || e.KeyValue == 35 || e.KeyValue == 36)
            {
                e.SuppressKeyPress = false;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// PORT 텍스트박스 키 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpPortTB_KeyDown(object sender, KeyEventArgs e)
        {
            // 8 - 백스페이스
            // 46 - DEL
            // 37 - 좌 화살표
            // 38 - 위 화살표
            // 39 - 우 화살표
            // 40 - 아래 화살표
            // 16 - 쉬프트
            // (48 ~ 57) - 숫자 0 ~ 9 
            // (96 ~ 105) - 숫자 0 ~ 9
            // 35 - End
            // 36 - Home
            if (e.KeyValue == 8 || e.KeyValue == 46 || e.KeyValue == 16
                || e.KeyValue == 37 || e.KeyValue == 38 || e.KeyValue == 39 || e.KeyValue == 40
                || (e.KeyValue > 47 && e.KeyValue < 58)
                || (e.KeyValue > 95 && e.KeyValue < 106)
                || e.KeyValue == 35 || e.KeyValue == 36)
            {
                e.SuppressKeyPress = false;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}