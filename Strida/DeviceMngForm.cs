using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADEng.StridaBiz;

namespace ADEng.Strida
{
    public class DeviceMngForm : Form
    {
        #region instance
        private PictureBox DeviceMainPB;
        private Label DeviceListLB;
        private Button DelBtn;
        private Button AddBtn;
        private Panel DeviceMainPN;
        private Label DeviceMainLB;
        private Panel DeviceSidePN;
        private ImageList MainImageList;
        private System.ComponentModel.IContainer components;
        private Button UpdateBtn;
        private Button CloseBtn;
        private ListView DeviceLV;
        private Panel DeviceListPN;
        private DeviceMng deviceMng;
        #endregion

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_deviceMng">
        /// Main의 DeviceMng
        /// </param>
        public DeviceMngForm(DeviceMng _deviceMng)
        {
            this.InitializeComponent();
            this.deviceMng = _deviceMng;

            //리스트뷰 초기화
            this.ListviewInit();

            //장비 초기화
            this.SetListviewFromDevice();
        }

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceMngForm));
            this.DeviceMainPB = new System.Windows.Forms.PictureBox();
            this.DeviceListLB = new System.Windows.Forms.Label();
            this.DelBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DeviceMainPN = new System.Windows.Forms.Panel();
            this.DeviceMainLB = new System.Windows.Forms.Label();
            this.DeviceSidePN = new System.Windows.Forms.Panel();
            this.MainImageList = new System.Windows.Forms.ImageList(this.components);
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.DeviceLV = new System.Windows.Forms.ListView();
            this.DeviceListPN = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMainPB)).BeginInit();
            this.DeviceMainPN.SuspendLayout();
            this.DeviceListPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceMainPB
            // 
            this.DeviceMainPB.BackColor = System.Drawing.Color.Transparent;
            this.DeviceMainPB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeviceMainPB.BackgroundImage")));
            this.DeviceMainPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceMainPB.Location = new System.Drawing.Point(411, 3);
            this.DeviceMainPB.Name = "DeviceMainPB";
            this.DeviceMainPB.Size = new System.Drawing.Size(39, 35);
            this.DeviceMainPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeviceMainPB.TabIndex = 1;
            this.DeviceMainPB.TabStop = false;
            // 
            // DeviceListLB
            // 
            this.DeviceListLB.BackColor = System.Drawing.SystemColors.Control;
            this.DeviceListLB.Dock = System.Windows.Forms.DockStyle.Left;
            this.DeviceListLB.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DeviceListLB.Location = new System.Drawing.Point(0, 0);
            this.DeviceListLB.Name = "DeviceListLB";
            this.DeviceListLB.Size = new System.Drawing.Size(60, 24);
            this.DeviceListLB.TabIndex = 1;
            this.DeviceListLB.Text = "장비 목록";
            this.DeviceListLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DelBtn
            // 
            this.DelBtn.Location = new System.Drawing.Point(174, 335);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(75, 23);
            this.DelBtn.TabIndex = 17;
            this.DelBtn.Text = "삭제";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(14, 335);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 15;
            this.AddBtn.Text = "등록";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
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
            this.DeviceMainPN.Size = new System.Drawing.Size(464, 43);
            this.DeviceMainPN.TabIndex = 10;
            // 
            // DeviceMainLB
            // 
            this.DeviceMainLB.AutoSize = true;
            this.DeviceMainLB.BackColor = System.Drawing.Color.Transparent;
            this.DeviceMainLB.Location = new System.Drawing.Point(12, 9);
            this.DeviceMainLB.Name = "DeviceMainLB";
            this.DeviceMainLB.Size = new System.Drawing.Size(173, 12);
            this.DeviceMainLB.TabIndex = 0;
            this.DeviceMainLB.Text = "장비를 등록/수정/삭제 합니다.";
            // 
            // DeviceSidePN
            // 
            this.DeviceSidePN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeviceSidePN.BackgroundImage")));
            this.DeviceSidePN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceSidePN.Location = new System.Drawing.Point(2, 44);
            this.DeviceSidePN.Name = "DeviceSidePN";
            this.DeviceSidePN.Size = new System.Drawing.Size(460, 5);
            this.DeviceSidePN.TabIndex = 11;
            // 
            // MainImageList
            // 
            this.MainImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.MainImageList.ImageSize = new System.Drawing.Size(20, 20);
            this.MainImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(93, 335);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateBtn.TabIndex = 16;
            this.UpdateBtn.Text = "수정";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(375, 335);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 14;
            this.CloseBtn.Text = "닫기";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // DeviceLV
            // 
            this.DeviceLV.FullRowSelect = true;
            this.DeviceLV.GridLines = true;
            this.DeviceLV.HideSelection = false;
            this.DeviceLV.Location = new System.Drawing.Point(14, 93);
            this.DeviceLV.Name = "DeviceLV";
            this.DeviceLV.Size = new System.Drawing.Size(436, 236);
            this.DeviceLV.StateImageList = this.MainImageList;
            this.DeviceLV.TabIndex = 13;
            this.DeviceLV.UseCompatibleStateImageBehavior = false;
            this.DeviceLV.View = System.Windows.Forms.View.Details;
            this.DeviceLV.DoubleClick += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // DeviceListPN
            // 
            this.DeviceListPN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeviceListPN.BackgroundImage")));
            this.DeviceListPN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceListPN.Controls.Add(this.DeviceListLB);
            this.DeviceListPN.Location = new System.Drawing.Point(14, 63);
            this.DeviceListPN.Name = "DeviceListPN";
            this.DeviceListPN.Size = new System.Drawing.Size(436, 24);
            this.DeviceListPN.TabIndex = 12;
            // 
            // DeviceMngForm
            // 
            this.ClientSize = new System.Drawing.Size(464, 369);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.DeviceMainPN);
            this.Controls.Add(this.DeviceSidePN);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.DeviceLV);
            this.Controls.Add(this.DeviceListPN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceMngForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "장비 관리_등록";
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMainPB)).EndInit();
            this.DeviceMainPN.ResumeLayout(false);
            this.DeviceMainPN.PerformLayout();
            this.DeviceListPN.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        /// <summary>
        /// 리스트뷰 초기화
        /// </summary>
        private void ListviewInit()
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

            //ColumnHeader dDivision = new ColumnHeader();
            //dDivision.Text = "식별자";
            //dDivision.Width = 55;
            //dDivision.TextAlign = HorizontalAlignment.Center;
            //this.DeviceLV.Columns.Add(dDivision);

            ColumnHeader dId = new ColumnHeader();
            dId.Text = "ID";
            dId.Width = 150;
            dId.TextAlign = HorizontalAlignment.Center;
            this.DeviceLV.Columns.Add(dId);

            ColumnHeader dName = new ColumnHeader();
            dName.Text = "이름";
            dName.Width = 220;
            dName.TextAlign = HorizontalAlignment.Center;
            this.DeviceLV.Columns.Add(dName);
            #endregion
        }

        /// <summary>
        /// 리스트뷰에 장비를 셋팅한다.
        /// </summary>
        private void SetListviewFromDevice()
        {
            for (int i = 0; i < this.deviceMng.SerializedDevice.Count; i++)
            {
                this.DeviceLV.Items.Add(this.GetListViewItem(this.deviceMng.SerializedDevice[i]));
            }
        }

        /// <summary>
        /// 등록 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            using (DeviceAddForm deviceAdd = new DeviceAddForm(this.deviceMng))
            {
                deviceAdd.OnDeviceAddSuccessEvt += new EventHandler<DeviceAddSuccessEventArgs>(deviceAdd_OnDeviceAddSuccessEvt);
                deviceAdd.ShowDialog();
                deviceAdd.OnDeviceAddSuccessEvt -= new EventHandler<DeviceAddSuccessEventArgs>(deviceAdd_OnDeviceAddSuccessEvt);
            }
        }

        /// <summary>
        /// 수정 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (this.DeviceLV.SelectedItems.Count == 0)
            {
                MessageBox.Show("수정할 장비를 선택하세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (this.DeviceLV.SelectedItems.Count > 1)
            {
                MessageBox.Show("한개의 장비를 선택하세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (this.DeviceLV.SelectedItems.Count == 1)
            {
                DeviceBase tmpDeviceBase = this.deviceMng.GetDevice(this.DeviceLV.SelectedItems[0].Name);

                if (tmpDeviceBase != null)
                {
                    using (DeviceAddForm deviceAdd = new DeviceAddForm(this.deviceMng, tmpDeviceBase))
                    {
                        deviceAdd.OnDeviceUpdateSuccessEvt += new EventHandler<DeviceUpdateSuccessEventArgs>(deviceAdd_OnDeviceUpdateSuccessEvt);
                        deviceAdd.ShowDialog();
                        deviceAdd.OnDeviceUpdateSuccessEvt -= new EventHandler<DeviceUpdateSuccessEventArgs>(deviceAdd_OnDeviceUpdateSuccessEvt);
                    }
                }
            }
        }

        /// <summary>
        /// 삭제 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (this.DeviceLV.SelectedItems.Count == 0)
            {
                MessageBox.Show("삭제할 장비를 선택하세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("장비를 삭제하겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                List<DeviceBase> tmpDeviceList = new List<DeviceBase>();

                for (int i = 0; i < this.DeviceLV.SelectedItems.Count; i++)
                {
                    DeviceBase tmpDeviceBase = this.deviceMng.GetDevice(this.DeviceLV.SelectedItems[i].Name);
                    this.deviceMng.DeviceDelete(tmpDeviceBase);

                    if (!this.deviceMng.SerializedDevice.Contains(tmpDeviceBase))
                    {
                        tmpDeviceList.Add(tmpDeviceBase);
                    }
                }

                this.deviceMng.DeviceSerialize();

                for (int i = 0; i < tmpDeviceList.Count; i++)
                {
                    this.DeviceLV.Items.RemoveByKey(tmpDeviceList[i].Key);
                }
                
                this.SetListViewIndex(this.DeviceLV);
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
        /// 장비 수정창에서 주는 장비 수정 성공 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deviceAdd_OnDeviceUpdateSuccessEvt(object sender, DeviceUpdateSuccessEventArgs e)
        {
            this.DeviceLV.Items[e.DBase.Key].SubItems[3].Text = e.DBase.Name;
        }

        /// <summary>
        /// 장비 등록창에서 주는 장비 등록 성공 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deviceAdd_OnDeviceAddSuccessEvt(object sender, DeviceAddSuccessEventArgs e)
        {
            this.DeviceLV.Items.Add(this.GetListViewItem(e.DBase));
        }

        /// <summary>
        /// DeviceBase 데이터를 ListViewItem로 만든 후 반환한다.
        /// </summary>
        /// <param name="_wd"></param>
        /// <returns></returns>
        private ListViewItem GetListViewItem(DeviceBase _db)
        {
            ListViewItem lvi = new ListViewItem();

            lvi.Name = _db.Key;
            lvi.Text = string.Empty;
            lvi.SubItems.Add(string.Format("{0}", this.DeviceLV.Items.Count + 1));
            lvi.SubItems.Add(_db.Key);
            lvi.SubItems.Add(_db.Name);

            return lvi;
        }

        /// <summary>
        /// 리스트뷰의 인덱스를 처음부터 다시 셋팅한다.
        /// </summary>
        /// <param name="lv"></param>
        public void SetListViewIndex(ListView lv)
        {
            for (int i = 0; i < lv.Items.Count; i++)
            {
                int c = i + 1;
                lv.Items[i].SubItems[1].Text = c.ToString();
            }
        }
    }
}