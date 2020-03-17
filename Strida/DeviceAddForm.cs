using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADEng.StridaBiz;

namespace ADEng.Strida
{
    public class DeviceAddForm : Form
    {
        #region instance
        private ComboBox DeviceDivisionCB;
        private Panel DeviceUnderPN;
        private Panel DeviceSidePN;
        private Label DeviceMainLB;
        private Button OkBtn;
        private Button CancleBtn;
        private Button SaveBtn;
        private TextBox DeviceNameTB;
        private TextBox DeviceIDTB;
        private Label DeviceNameLB;
        private PictureBox DeviceMainPB;
        private Label DeviceIDLB;
        private Label DeviceDivisionLB;
        private Panel DeviceMainPN;
        private DeviceMng deviceMng;
        private DeviceBase deviceBase;
        #endregion

        private delegate void DeviceAddSuccessEventArgsHandler(object sender, DeviceAddSuccessEventArgs dasea);
        private delegate void DeviceUpdateSuccessEventArgsHandler(object sender, DeviceUpdateSuccessEventArgs dusea);

        public event EventHandler<DeviceAddSuccessEventArgs> OnDeviceAddSuccessEvt;
        public event EventHandler<DeviceUpdateSuccessEventArgs> OnDeviceUpdateSuccessEvt;

        #region var
        private readonly string cas = "민방위 장비";
        private readonly string dmb = "DMB 장비";
        private readonly string oae = "OAE 장비";
        #endregion

        /// <summary>
        /// 생성자_등록
        /// </summary>
        public DeviceAddForm(DeviceMng _deviceMng)
        {
            this.InitializeComponent();
            this.SetComboBox();
            this.deviceMng = _deviceMng;

            this.Text = "장비 등록";
            this.DeviceMainLB.Text = "장비를 등록합니다.";
            this.DeviceMainPB.BackgroundImage = global::Strida.Properties.Resources.우량기정보관리_등록_41_40;
        }

        /// <summary>
        /// 생성자_수정
        /// </summary>
        public DeviceAddForm(DeviceMng _deviceMng, DeviceBase _deviceBase)
        {
            this.InitializeComponent();
            this.SetComboBox();
            this.deviceMng = _deviceMng;
            this.deviceBase = _deviceBase;

            this.Text = "장비 수정";
            this.DeviceMainLB.Text = "장비를 수정합니다.";
            this.DeviceMainPB.BackgroundImage = global::Strida.Properties.Resources.우량기정보관리_수정_41_40;
            this.DeviceIDTB.Text = _deviceBase.Key;
            this.DeviceNameTB.Text = _deviceBase.Name;
            this.DeviceIDTB.Enabled = false;

            if (_deviceBase is CasDevice)
            {
                this.DeviceDivisionCB.Text = this.cas;
            }
            else if (_deviceBase is DmbDevice)
            {
                this.DeviceDivisionCB.Text = this.dmb;
            }
            else if (_deviceBase is OaDevice)
            {
                this.DeviceDivisionCB.Text = this.oae;
            }

            this.SaveBtn.Enabled = false;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        #region InitializeComponent
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceAddForm));
            this.DeviceDivisionCB = new System.Windows.Forms.ComboBox();
            this.DeviceUnderPN = new System.Windows.Forms.Panel();
            this.DeviceSidePN = new System.Windows.Forms.Panel();
            this.DeviceMainLB = new System.Windows.Forms.Label();
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancleBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.DeviceNameTB = new System.Windows.Forms.TextBox();
            this.DeviceIDTB = new System.Windows.Forms.TextBox();
            this.DeviceNameLB = new System.Windows.Forms.Label();
            this.DeviceMainPB = new System.Windows.Forms.PictureBox();
            this.DeviceIDLB = new System.Windows.Forms.Label();
            this.DeviceDivisionLB = new System.Windows.Forms.Label();
            this.DeviceMainPN = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMainPB)).BeginInit();
            this.DeviceMainPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceDivisionCB
            // 
            this.DeviceDivisionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceDivisionCB.FormattingEnabled = true;
            this.DeviceDivisionCB.Location = new System.Drawing.Point(87, 55);
            this.DeviceDivisionCB.Name = "DeviceDivisionCB";
            this.DeviceDivisionCB.Size = new System.Drawing.Size(165, 20);
            this.DeviceDivisionCB.TabIndex = 17;
            this.DeviceDivisionCB.SelectedIndexChanged += new System.EventHandler(this.DeviceIDTB_TextChanged);
            // 
            // DeviceUnderPN
            // 
            this.DeviceUnderPN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeviceUnderPN.BackgroundImage")));
            this.DeviceUnderPN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceUnderPN.Location = new System.Drawing.Point(5, 152);
            this.DeviceUnderPN.Name = "DeviceUnderPN";
            this.DeviceUnderPN.Size = new System.Drawing.Size(256, 2);
            this.DeviceUnderPN.TabIndex = 28;
            // 
            // DeviceSidePN
            // 
            this.DeviceSidePN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeviceSidePN.BackgroundImage")));
            this.DeviceSidePN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceSidePN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeviceSidePN.Location = new System.Drawing.Point(0, 40);
            this.DeviceSidePN.Name = "DeviceSidePN";
            this.DeviceSidePN.Size = new System.Drawing.Size(267, 5);
            this.DeviceSidePN.TabIndex = 27;
            // 
            // DeviceMainLB
            // 
            this.DeviceMainLB.AutoSize = true;
            this.DeviceMainLB.BackColor = System.Drawing.Color.Transparent;
            this.DeviceMainLB.Location = new System.Drawing.Point(12, 9);
            this.DeviceMainLB.Name = "DeviceMainLB";
            this.DeviceMainLB.Size = new System.Drawing.Size(0, 12);
            this.DeviceMainLB.TabIndex = 0;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(15, 161);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 22;
            this.OkBtn.Text = "확인";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancleBtn
            // 
            this.CancleBtn.Location = new System.Drawing.Point(96, 161);
            this.CancleBtn.Name = "CancleBtn";
            this.CancleBtn.Size = new System.Drawing.Size(75, 23);
            this.CancleBtn.TabIndex = 24;
            this.CancleBtn.Text = "취소";
            this.CancleBtn.UseVisualStyleBackColor = true;
            this.CancleBtn.Click += new System.EventHandler(this.CancleBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(177, 161);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 26;
            this.SaveBtn.Text = "적용";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // DeviceNameTB
            // 
            this.DeviceNameTB.Location = new System.Drawing.Point(87, 106);
            this.DeviceNameTB.MaxLength = 40;
            this.DeviceNameTB.Name = "DeviceNameTB";
            this.DeviceNameTB.Size = new System.Drawing.Size(165, 21);
            this.DeviceNameTB.TabIndex = 20;
            this.DeviceNameTB.TextChanged += new System.EventHandler(this.DeviceIDTB_TextChanged);
            // 
            // DeviceIDTB
            // 
            this.DeviceIDTB.Location = new System.Drawing.Point(87, 80);
            this.DeviceIDTB.MaxLength = 40;
            this.DeviceIDTB.Name = "DeviceIDTB";
            this.DeviceIDTB.Size = new System.Drawing.Size(165, 21);
            this.DeviceIDTB.TabIndex = 18;
            this.DeviceIDTB.TextChanged += new System.EventHandler(this.DeviceIDTB_TextChanged);
            // 
            // DeviceNameLB
            // 
            this.DeviceNameLB.Location = new System.Drawing.Point(9, 106);
            this.DeviceNameLB.Name = "DeviceNameLB";
            this.DeviceNameLB.Size = new System.Drawing.Size(72, 21);
            this.DeviceNameLB.TabIndex = 25;
            this.DeviceNameLB.Text = "이름 :";
            this.DeviceNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeviceMainPB
            // 
            this.DeviceMainPB.BackColor = System.Drawing.Color.Transparent;
            this.DeviceMainPB.BackgroundImage = global::Strida.Properties.Resources.우량기정보관리_등록_41_40;
            this.DeviceMainPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceMainPB.Location = new System.Drawing.Point(213, 3);
            this.DeviceMainPB.Name = "DeviceMainPB";
            this.DeviceMainPB.Size = new System.Drawing.Size(39, 35);
            this.DeviceMainPB.TabIndex = 1;
            this.DeviceMainPB.TabStop = false;
            // 
            // DeviceIDLB
            // 
            this.DeviceIDLB.Location = new System.Drawing.Point(9, 80);
            this.DeviceIDLB.Name = "DeviceIDLB";
            this.DeviceIDLB.Size = new System.Drawing.Size(72, 21);
            this.DeviceIDLB.TabIndex = 23;
            this.DeviceIDLB.Text = "ID :";
            this.DeviceIDLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeviceDivisionLB
            // 
            this.DeviceDivisionLB.Location = new System.Drawing.Point(9, 55);
            this.DeviceDivisionLB.Name = "DeviceDivisionLB";
            this.DeviceDivisionLB.Size = new System.Drawing.Size(72, 21);
            this.DeviceDivisionLB.TabIndex = 21;
            this.DeviceDivisionLB.Text = "식별자 :";
            this.DeviceDivisionLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeviceMainPN
            // 
            this.DeviceMainPN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeviceMainPN.BackgroundImage")));
            this.DeviceMainPN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceMainPN.Controls.Add(this.DeviceMainPB);
            this.DeviceMainPN.Controls.Add(this.DeviceMainLB);
            this.DeviceMainPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeviceMainPN.Location = new System.Drawing.Point(0, 0);
            this.DeviceMainPN.Name = "DeviceMainPN";
            this.DeviceMainPN.Size = new System.Drawing.Size(267, 40);
            this.DeviceMainPN.TabIndex = 19;
            // 
            // DeviceAddForm
            // 
            this.ClientSize = new System.Drawing.Size(267, 195);
            this.Controls.Add(this.DeviceDivisionCB);
            this.Controls.Add(this.DeviceUnderPN);
            this.Controls.Add(this.DeviceSidePN);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancleBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.DeviceNameTB);
            this.Controls.Add(this.DeviceIDTB);
            this.Controls.Add(this.DeviceNameLB);
            this.Controls.Add(this.DeviceIDLB);
            this.Controls.Add(this.DeviceDivisionLB);
            this.Controls.Add(this.DeviceMainPN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceAddForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMainPB)).EndInit();
            this.DeviceMainPN.ResumeLayout(false);
            this.DeviceMainPN.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// 콤보박스에 식별자를 셋팅한다.
        /// </summary>
        private void SetComboBox()
        {
            this.DeviceDivisionCB.Items.Add(this.cas);
            this.DeviceDivisionCB.Items.Add(this.dmb);
            this.DeviceDivisionCB.Items.Add(this.oae);
            this.DeviceDivisionCB.Text = this.cas;
        }

        /// <summary>
        /// 확인 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkBtn_Click(object sender, EventArgs e)
        {
            bool rst = this.save();

            if (rst)
            {
                this.Close();
            }
            else
            {
                this.SaveBtn.Enabled = false;
            }
        }

        /// <summary>
        /// 취소 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 적용 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            this.save();
            this.SaveBtn.Enabled = false;
        }

        /// <summary>
        /// 저장 메소드
        /// </summary>
        private bool save()
        {
            bool saveRst = false;

            if (this.DeviceIDTB.Text == string.Empty || this.DeviceNameTB.Text == string.Empty)
            {
                MessageBox.Show("정보를 확인하세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.deviceBase == null) //등록
            {
                DeviceBase addDevice;
                bool rst = false;
                
                if (this.DeviceDivisionCB.Text == this.cas)
                {
                    addDevice = new CasDevice();
                    addDevice.Key = this.DeviceIDTB.Text;
                    addDevice.Name = this.DeviceNameTB.Text;
                    rst = this.deviceMng.DeviceAdd(addDevice);
                }
                else if(this.DeviceDivisionCB.Text == this.dmb)
                {
                    addDevice = new DmbDevice();
                    addDevice.Key = this.DeviceIDTB.Text;
                    addDevice.Name = this.DeviceNameTB.Text;
                    rst = this.deviceMng.DeviceAdd(addDevice);
                }
                else if (this.DeviceDivisionCB.Text == this.oae)
                {
                    addDevice = new OaDevice();
                    addDevice.Key = this.DeviceIDTB.Text;
                    addDevice.Name = this.DeviceNameTB.Text;
                    rst = this.deviceMng.DeviceAdd(addDevice);
                }

                if (rst) //등록 성공
                {
                    MessageBox.Show("성공적으로 등록되었습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DeviceBase tmpDeviceBase = new DeviceBase();
                    tmpDeviceBase.Key = this.DeviceIDTB.Text;
                    tmpDeviceBase.Name = this.DeviceNameTB.Text;

                    if (this.OnDeviceAddSuccessEvt != null)
                    {
                        this.OnDeviceAddSuccessEvt(this, new DeviceAddSuccessEventArgs(tmpDeviceBase));
                    }
                    
                    this.DeviceIDTB.Text = string.Empty;
                    this.DeviceNameTB.Text = string.Empty;
                    saveRst = true;
                }
                else //등록 실패
                {
                    MessageBox.Show("중복된 ID가 있습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    saveRst = false;
                }
            }
            else //수정
            {
                DeviceBase addDevice;
                bool rst = false;

                if (this.DeviceDivisionCB.Text == this.cas)
                {
                    addDevice = new CasDevice();
                    addDevice.Key = this.DeviceIDTB.Text;
                    addDevice.Name = this.DeviceNameTB.Text;
                    rst = this.deviceMng.DeviceUpdate(addDevice);
                }
                else if (this.DeviceDivisionCB.Text == this.dmb)
                {
                    addDevice = new DmbDevice();
                    addDevice.Key = this.DeviceIDTB.Text;
                    addDevice.Name = this.DeviceNameTB.Text;
                    rst = this.deviceMng.DeviceUpdate(addDevice);
                }
                else if (this.DeviceDivisionCB.Text == this.oae)
                {
                    addDevice = new OaDevice();
                    addDevice.Key = this.DeviceIDTB.Text;
                    addDevice.Name = this.DeviceNameTB.Text;
                    rst = this.deviceMng.DeviceUpdate(addDevice);
                }

                if (rst) //수정 성공
                {
                    MessageBox.Show("성공적으로 수정되었습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DeviceBase tmpDeviceBase = new DeviceBase();
                    tmpDeviceBase.Key = this.DeviceIDTB.Text;
                    tmpDeviceBase.Name = this.DeviceNameTB.Text;

                    if (this.OnDeviceUpdateSuccessEvt != null)
                    {
                        this.OnDeviceUpdateSuccessEvt(this, new DeviceUpdateSuccessEventArgs(tmpDeviceBase));
                    }

                    saveRst = true;
                }
                else //수정 실패
                {
                    MessageBox.Show("수정을 실패했습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    saveRst = false;
                }
            }

            return saveRst;
        }

        /// <summary>
        /// 텍스트박스 변경 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceIDTB_TextChanged(object sender, EventArgs e)
        {
            if (this.DeviceIDTB.Text != string.Empty && this.DeviceNameTB.Text != string.Empty)
            {
                this.SaveBtn.Enabled = true;
            }
            else
            {
                this.SaveBtn.Enabled = false;
            }
        }
    }

    /// <summary>
    /// 장비 등록 성공 이벤트 아규먼트 클래스
    /// </summary>
    public class DeviceAddSuccessEventArgs : EventArgs
    {
        private DeviceBase dBase;

        public DeviceBase DBase
        {
            get { return this.dBase; }
            set { this.dBase = value; }
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_db"></param>
        public DeviceAddSuccessEventArgs(DeviceBase _db)
        {
            this.dBase = _db;
        }
    }

    /// <summary>
    /// 장비 수정 성공 이벤트 아규먼트 클래스
    /// </summary>
    public class DeviceUpdateSuccessEventArgs : EventArgs
    {
        private DeviceBase dBase;

        public DeviceBase DBase
        {
            get { return this.dBase; }
            set { this.dBase = value; }
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_db"></param>
        public DeviceUpdateSuccessEventArgs(DeviceBase _db)
        {
            this.dBase = _db;
        }
    }
}