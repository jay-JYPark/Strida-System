using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using ADEng.StridaBiz;

namespace ADEng.Strida
{
    public class DeviceMapForm : Form
    {
        #region instance
        private ImageList MainImageList;
        private System.ComponentModel.IContainer components;
        private Panel DeviceSidePN;
        private Button CloseBtn;
        private ListView DeviceLV;
        private PictureBox DeviceMainPB;
        private Panel DeviceMainPN;
        private Label DeviceMainLB;
        private Panel DeviceListPN;
        private Label DeviceListLB;
        private Panel OaDeviceListPN;
        private Label OaDeviceListLB;
        private ListView OaDeviceLV;
        private Button AddBtn;
        private DeviceMng deviceMng;
        #endregion

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceMapForm));
            this.MainImageList = new System.Windows.Forms.ImageList(this.components);
            this.DeviceSidePN = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.DeviceLV = new System.Windows.Forms.ListView();
            this.DeviceMainPB = new System.Windows.Forms.PictureBox();
            this.DeviceMainPN = new System.Windows.Forms.Panel();
            this.DeviceMainLB = new System.Windows.Forms.Label();
            this.DeviceListPN = new System.Windows.Forms.Panel();
            this.DeviceListLB = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.OaDeviceListPN = new System.Windows.Forms.Panel();
            this.OaDeviceListLB = new System.Windows.Forms.Label();
            this.OaDeviceLV = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMainPB)).BeginInit();
            this.DeviceMainPN.SuspendLayout();
            this.DeviceListPN.SuspendLayout();
            this.OaDeviceListPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainImageList
            // 
            this.MainImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.MainImageList.ImageSize = new System.Drawing.Size(20, 20);
            this.MainImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DeviceSidePN
            // 
            this.DeviceSidePN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeviceSidePN.BackgroundImage")));
            this.DeviceSidePN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceSidePN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeviceSidePN.Location = new System.Drawing.Point(0, 43);
            this.DeviceSidePN.Name = "DeviceSidePN";
            this.DeviceSidePN.Size = new System.Drawing.Size(411, 5);
            this.DeviceSidePN.TabIndex = 17;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(323, 334);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 20;
            this.CloseBtn.Text = "닫기";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // DeviceLV
            // 
            this.DeviceLV.FullRowSelect = true;
            this.DeviceLV.GridLines = true;
            this.DeviceLV.HideSelection = false;
            this.DeviceLV.Location = new System.Drawing.Point(14, 92);
            this.DeviceLV.MultiSelect = false;
            this.DeviceLV.Name = "DeviceLV";
            this.DeviceLV.Size = new System.Drawing.Size(219, 236);
            this.DeviceLV.StateImageList = this.MainImageList;
            this.DeviceLV.TabIndex = 19;
            this.DeviceLV.UseCompatibleStateImageBehavior = false;
            this.DeviceLV.View = System.Windows.Forms.View.Details;
            this.DeviceLV.SelectedIndexChanged += new System.EventHandler(this.DeviceLV_SelectedIndexChanged);
            // 
            // DeviceMainPB
            // 
            this.DeviceMainPB.BackColor = System.Drawing.Color.Transparent;
            this.DeviceMainPB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeviceMainPB.BackgroundImage")));
            this.DeviceMainPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceMainPB.Location = new System.Drawing.Point(359, 4);
            this.DeviceMainPB.Name = "DeviceMainPB";
            this.DeviceMainPB.Size = new System.Drawing.Size(39, 35);
            this.DeviceMainPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeviceMainPB.TabIndex = 1;
            this.DeviceMainPB.TabStop = false;
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
            this.DeviceMainPN.Size = new System.Drawing.Size(411, 43);
            this.DeviceMainPN.TabIndex = 16;
            // 
            // DeviceMainLB
            // 
            this.DeviceMainLB.AutoSize = true;
            this.DeviceMainLB.BackColor = System.Drawing.Color.Transparent;
            this.DeviceMainLB.Location = new System.Drawing.Point(12, 9);
            this.DeviceMainLB.Name = "DeviceMainLB";
            this.DeviceMainLB.Size = new System.Drawing.Size(251, 12);
            this.DeviceMainLB.TabIndex = 0;
            this.DeviceMainLB.Text = "민방위/DMB 장비에 OAE 장비를 연결합니다.";
            // 
            // DeviceListPN
            // 
            this.DeviceListPN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeviceListPN.BackgroundImage")));
            this.DeviceListPN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceListPN.Controls.Add(this.DeviceListLB);
            this.DeviceListPN.Location = new System.Drawing.Point(14, 62);
            this.DeviceListPN.Name = "DeviceListPN";
            this.DeviceListPN.Size = new System.Drawing.Size(219, 24);
            this.DeviceListPN.TabIndex = 18;
            // 
            // DeviceListLB
            // 
            this.DeviceListLB.BackColor = System.Drawing.SystemColors.Control;
            this.DeviceListLB.Dock = System.Windows.Forms.DockStyle.Left;
            this.DeviceListLB.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DeviceListLB.Location = new System.Drawing.Point(0, 0);
            this.DeviceListLB.Name = "DeviceListLB";
            this.DeviceListLB.Size = new System.Drawing.Size(102, 24);
            this.DeviceListLB.TabIndex = 1;
            this.DeviceListLB.Text = "민방위/DMB 목록";
            this.DeviceListLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(242, 334);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 21;
            this.AddBtn.Text = "저장";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // OaDeviceListPN
            // 
            this.OaDeviceListPN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OaDeviceListPN.BackgroundImage")));
            this.OaDeviceListPN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OaDeviceListPN.Controls.Add(this.OaDeviceListLB);
            this.OaDeviceListPN.Location = new System.Drawing.Point(251, 62);
            this.OaDeviceListPN.Name = "OaDeviceListPN";
            this.OaDeviceListPN.Size = new System.Drawing.Size(147, 24);
            this.OaDeviceListPN.TabIndex = 19;
            // 
            // OaDeviceListLB
            // 
            this.OaDeviceListLB.BackColor = System.Drawing.SystemColors.Control;
            this.OaDeviceListLB.Dock = System.Windows.Forms.DockStyle.Left;
            this.OaDeviceListLB.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.OaDeviceListLB.Location = new System.Drawing.Point(0, 0);
            this.OaDeviceListLB.Name = "OaDeviceListLB";
            this.OaDeviceListLB.Size = new System.Drawing.Size(86, 24);
            this.OaDeviceListLB.TabIndex = 1;
            this.OaDeviceListLB.Text = "OAE 장비 목록";
            this.OaDeviceListLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OaDeviceLV
            // 
            this.OaDeviceLV.CheckBoxes = true;
            this.OaDeviceLV.Location = new System.Drawing.Point(253, 92);
            this.OaDeviceLV.Name = "OaDeviceLV";
            this.OaDeviceLV.Size = new System.Drawing.Size(145, 236);
            this.OaDeviceLV.TabIndex = 22;
            this.OaDeviceLV.UseCompatibleStateImageBehavior = false;
            this.OaDeviceLV.View = System.Windows.Forms.View.SmallIcon;
            this.OaDeviceLV.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OaDeviceLV_ItemChecked);
            // 
            // DeviceMapForm
            // 
            this.ClientSize = new System.Drawing.Size(411, 364);
            this.Controls.Add(this.OaDeviceLV);
            this.Controls.Add(this.OaDeviceListPN);
            this.Controls.Add(this.DeviceSidePN);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.DeviceLV);
            this.Controls.Add(this.DeviceMainPN);
            this.Controls.Add(this.DeviceListPN);
            this.Controls.Add(this.AddBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceMapForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "장비 관리_연결";
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMainPB)).EndInit();
            this.DeviceMainPN.ResumeLayout(false);
            this.DeviceMainPN.PerformLayout();
            this.DeviceListPN.ResumeLayout(false);
            this.OaDeviceListPN.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 생성자
        /// </summary>
        public DeviceMapForm(DeviceMng _deviceMng)
        {
            this.InitializeComponent();
            this.deviceMng = _deviceMng;
            this.init();
            this.AnDDeviceInit();
        }

        /// <summary>
        /// 리스트뷰를 초기화한다.
        /// </summary>
        private void init()
        {
            #region 리스트뷰 초기화
            ColumnHeader dIcon = new ColumnHeader();
            dIcon.Text = string.Empty;
            dIcon.Width = 0;
            this.DeviceLV.Columns.Add(dIcon);

            ColumnHeader dPkid = new ColumnHeader();
            dPkid.Text = "번호";
            dPkid.Width = 43;
            this.DeviceLV.Columns.Add(dPkid);

            //ColumnHeader dId = new ColumnHeader();
            //dId.Text = "ID";
            //dId.Width = 160;
            //dId.TextAlign = HorizontalAlignment.Center;
            //this.DeviceLV.Columns.Add(dId);

            ColumnHeader dName = new ColumnHeader();
            dName.Text = "이름";
            dName.Width = 155;
            dName.TextAlign = HorizontalAlignment.Center;
            this.DeviceLV.Columns.Add(dName);
            #endregion
        }

        /// <summary>
        /// 민방위/DMB/OA 장비를 리스트뷰에 초기화한다.
        /// </summary>
        private void AnDDeviceInit()
        {
            for (int i = 0; i < this.deviceMng.SerializedDevice.Count; i++)
            {
                if (this.deviceMng.SerializedDevice[i] is CasDevice ||
                    this.deviceMng.SerializedDevice[i] is DmbDevice)
                {
                    this.DeviceLV.Items.Add(this.GetListViewItem(this.deviceMng.SerializedDevice[i]));
                }
                else if (this.deviceMng.SerializedDevice[i] is OaDevice)
                {
                    this.OaDeviceLV.Items.Add(this.GetOAListViewItem(this.deviceMng.SerializedDevice[i]));
                }
            }
        }

        /// <summary>
        /// DeviceBase 데이터를 ListViewItem로 만든 후 반환한다. (민방위/DMB 용)
        /// </summary>
        /// <param name="_wd"></param>
        /// <returns></returns>
        private ListViewItem GetListViewItem(DeviceBase _db)
        {
            ListViewItem lvi = new ListViewItem();

            lvi.Name = _db.Key;
            lvi.Text = string.Empty;
            lvi.SubItems.Add(string.Format("{0}", this.DeviceLV.Items.Count + 1));
            //lvi.SubItems.Add(_db.Key);
            lvi.SubItems.Add(_db.Name);

            return lvi;
        }

        /// <summary>
        /// DeviceBase 데이터를 ListViewItem로 만든 후 반환한다. (OA용)
        /// </summary>
        /// <param name="_db"></param>
        /// <returns></returns>
        private ListViewItem GetOAListViewItem(DeviceBase _db)
        {
            ListViewItem lvi = new ListViewItem();

            lvi.Name = _db.Key;
            lvi.Text = _db.Name;

            return lvi;
        }

        /// <summary>
        /// 저장 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (this.DeviceLV.SelectedItems.Count == 1)
            {
                MapDevice mapDevice = this.deviceMng.GetDeviceOfDic(this.DeviceLV.SelectedItems[0].Name);

                if (mapDevice != null)
                {
                    mapDevice.OaDeviceList.Clear();

                    for (int i = 0; i < this.OaDeviceLV.Items.Count; i++)
                    {
                        if (this.OaDeviceLV.Items[i].Checked)
                        {
                            DeviceBase tmpDeviceBase = this.deviceMng.GetDevice(this.OaDeviceLV.Items[i].Name);
                            mapDevice.OaDeviceList.Add((OaDevice)tmpDeviceBase);
                        }
                    }

                    this.deviceMng.SetOaDeviceOfMap(mapDevice);
                    MessageBox.Show("성공적으로 저장되었습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("저장을 실패했습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("저장할 장비를 선택하세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 닫기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 리스트뷰 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DeviceLV.SelectedItems.Count != 0)
            {
                for (int i = 0; i < this.OaDeviceLV.Items.Count; i++)
                {
                    this.OaDeviceLV.Items[i].Checked = false;
                }

                MapDevice mapDevice = this.deviceMng.GetDeviceOfDic(this.DeviceLV.SelectedItems[0].Name);

                if (mapDevice != null)
                {
                    for (int i = 0; i < mapDevice.OaDeviceList.Count; i++)
                    {
                        if (this.OaDeviceLV.Items.ContainsKey(mapDevice.OaDeviceList[i].Key))
                        {
                            this.OaDeviceLV.Items[mapDevice.OaDeviceList[i].Key].Checked = true;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.OaDeviceLV.Items.Count; i++)
                {
                    this.OaDeviceLV.Items[i].Checked = false;
                }
            }
        }

        /// <summary>
        /// 리스트뷰 체크박스 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OaDeviceLV_ItemChecked(object sender, System.Windows.Forms.ItemCheckedEventArgs e)
        {
            if (this.DeviceLV.SelectedItems.Count == 0)
            {
                for (int i = 0; i < this.OaDeviceLV.Items.Count; i++)
                {
                    this.OaDeviceLV.Items[i].Checked = false;
                }
            }
        }
    }
}