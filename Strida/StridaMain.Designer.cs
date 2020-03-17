namespace ADEng.Strida
{
    partial class StridaMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StridaMain));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도구TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.장비관리DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.등록관리AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.매핑관리MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.프로그램정보IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainListviewPN = new System.Windows.Forms.Panel();
            this.ListviewResetLB = new System.Windows.Forms.Label();
            this.MainListviewLB = new System.Windows.Forms.Label();
            this.MainOrderLV = new System.Windows.Forms.ListView();
            this.MainImageList = new System.Windows.Forms.ImageList(this.components);
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenuStrip.SuspendLayout();
            this.MainListviewPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.도구TToolStripMenuItem,
            this.도움말HToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(760, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.종료XToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 종료XToolStripMenuItem
            // 
            this.종료XToolStripMenuItem.Name = "종료XToolStripMenuItem";
            this.종료XToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.종료XToolStripMenuItem.Text = "종료(&X)";
            this.종료XToolStripMenuItem.Click += new System.EventHandler(this.종료XToolStripMenuItem_Click);
            // 
            // 도구TToolStripMenuItem
            // 
            this.도구TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.장비관리DToolStripMenuItem,
            this.환경설정EToolStripMenuItem});
            this.도구TToolStripMenuItem.Name = "도구TToolStripMenuItem";
            this.도구TToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.도구TToolStripMenuItem.Text = "도구(&T)";
            // 
            // 장비관리DToolStripMenuItem
            // 
            this.장비관리DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.등록관리AToolStripMenuItem,
            this.매핑관리MToolStripMenuItem});
            this.장비관리DToolStripMenuItem.Image = global::Strida.Properties.Resources.우량기정보관리_24_24;
            this.장비관리DToolStripMenuItem.Name = "장비관리DToolStripMenuItem";
            this.장비관리DToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.장비관리DToolStripMenuItem.Text = "장비 관리(&D)";
            // 
            // 등록관리AToolStripMenuItem
            // 
            this.등록관리AToolStripMenuItem.Name = "등록관리AToolStripMenuItem";
            this.등록관리AToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.등록관리AToolStripMenuItem.Text = "등록 관리(&A)";
            this.등록관리AToolStripMenuItem.Click += new System.EventHandler(this.등록관리AToolStripMenuItem_Click);
            // 
            // 매핑관리MToolStripMenuItem
            // 
            this.매핑관리MToolStripMenuItem.Name = "매핑관리MToolStripMenuItem";
            this.매핑관리MToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.매핑관리MToolStripMenuItem.Text = "연결 관리(&M)";
            this.매핑관리MToolStripMenuItem.Click += new System.EventHandler(this.매핑관리MToolStripMenuItem_Click);
            // 
            // 환경설정EToolStripMenuItem
            // 
            this.환경설정EToolStripMenuItem.Image = global::Strida.Properties.Resources.DMB_dialogue_control_24;
            this.환경설정EToolStripMenuItem.Name = "환경설정EToolStripMenuItem";
            this.환경설정EToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.환경설정EToolStripMenuItem.Text = "환경 설정(&E)";
            this.환경설정EToolStripMenuItem.Click += new System.EventHandler(this.환경설정EToolStripMenuItem_Click);
            // 
            // 도움말HToolStripMenuItem
            // 
            this.도움말HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.프로그램정보IToolStripMenuItem});
            this.도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            this.도움말HToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.도움말HToolStripMenuItem.Text = "도움말(&H)";
            // 
            // 프로그램정보IToolStripMenuItem
            // 
            this.프로그램정보IToolStripMenuItem.Image = global::Strida.Properties.Resources.IconPopInfo;
            this.프로그램정보IToolStripMenuItem.Name = "프로그램정보IToolStripMenuItem";
            this.프로그램정보IToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.프로그램정보IToolStripMenuItem.Text = "프로그램 정보(&I)";
            this.프로그램정보IToolStripMenuItem.Click += new System.EventHandler(this.프로그램정보IToolStripMenuItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 456);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(760, 22);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // MainListviewPN
            // 
            this.MainListviewPN.BackgroundImage = global::Strida.Properties.Resources.DMB_main;
            this.MainListviewPN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainListviewPN.Controls.Add(this.ListviewResetLB);
            this.MainListviewPN.Controls.Add(this.MainListviewLB);
            this.MainListviewPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainListviewPN.Location = new System.Drawing.Point(0, 24);
            this.MainListviewPN.Name = "MainListviewPN";
            this.MainListviewPN.Padding = new System.Windows.Forms.Padding(3);
            this.MainListviewPN.Size = new System.Drawing.Size(760, 28);
            this.MainListviewPN.TabIndex = 2;
            // 
            // ListviewResetLB
            // 
            this.ListviewResetLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ListviewResetLB.BackColor = System.Drawing.Color.Transparent;
            this.ListviewResetLB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListviewResetLB.Image = global::Strida.Properties.Resources.DMB_reset;
            this.ListviewResetLB.Location = new System.Drawing.Point(728, 8);
            this.ListviewResetLB.Name = "ListviewResetLB";
            this.ListviewResetLB.Size = new System.Drawing.Size(20, 12);
            this.ListviewResetLB.TabIndex = 4;
            this.MainToolTip.SetToolTip(this.ListviewResetLB, "발령/결과 내역 초기화");
            this.ListviewResetLB.Click += new System.EventHandler(this.ListviewResetLB_Click);
            // 
            // MainListviewLB
            // 
            this.MainListviewLB.AutoSize = true;
            this.MainListviewLB.BackColor = System.Drawing.Color.Transparent;
            this.MainListviewLB.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MainListviewLB.Location = new System.Drawing.Point(8, 9);
            this.MainListviewLB.Name = "MainListviewLB";
            this.MainListviewLB.Size = new System.Drawing.Size(95, 12);
            this.MainListviewLB.TabIndex = 3;
            this.MainListviewLB.Text = "발령/결과 내역";
            // 
            // MainOrderLV
            // 
            this.MainOrderLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainOrderLV.FullRowSelect = true;
            this.MainOrderLV.GridLines = true;
            this.MainOrderLV.HideSelection = false;
            this.MainOrderLV.Location = new System.Drawing.Point(0, 52);
            this.MainOrderLV.MultiSelect = false;
            this.MainOrderLV.Name = "MainOrderLV";
            this.MainOrderLV.Size = new System.Drawing.Size(760, 404);
            this.MainOrderLV.StateImageList = this.MainImageList;
            this.MainOrderLV.TabIndex = 3;
            this.MainOrderLV.UseCompatibleStateImageBehavior = false;
            this.MainOrderLV.View = System.Windows.Forms.View.Details;
            // 
            // MainImageList
            // 
            this.MainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainImageList.ImageStream")));
            this.MainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MainImageList.Images.SetKeyName(0, "arrow_left_green.ico");
            this.MainImageList.Images.SetKeyName(1, "arrow_right_blue.ico");
            this.MainImageList.Images.SetKeyName(2, "arrow2_left_green.ico");
            this.MainImageList.Images.SetKeyName(3, "arrow2_right_blue.ico");
            this.MainImageList.Images.SetKeyName(4, "delete.ico");
            // 
            // StridaMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 478);
            this.Controls.Add(this.MainOrderLV);
            this.Controls.Add(this.MainListviewPN);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.MinimumSize = new System.Drawing.Size(512, 256);
            this.Name = "StridaMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OAE 연계 프로그램";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainListviewPN.ResumeLayout(false);
            this.MainListviewPN.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도구TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 장비관리DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 환경설정EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 프로그램정보IToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem 등록관리AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 매핑관리MToolStripMenuItem;
        private System.Windows.Forms.Panel MainListviewPN;
        private System.Windows.Forms.Label MainListviewLB;
        private System.Windows.Forms.ListView MainOrderLV;
        private System.Windows.Forms.ImageList MainImageList;
        private System.Windows.Forms.Label ListviewResetLB;
        private System.Windows.Forms.ToolTip MainToolTip;
    }
}

