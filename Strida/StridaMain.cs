using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using ADEng.StridaBiz;
using ADEng.Control.WeatherSystem;
using adeng.Olprt;

namespace ADEng.Strida
{
    public partial class StridaMain : Form
    {
        #region instance
        DeviceMng deviceMng;
        OrderBridgeMng orderBridgeMng;
        #endregion

        #region var
        private List<string> versionList = new List<string>();
        private readonly string version_1 = " 2011/06/27 Ver_1.0.0";
        private readonly string deviceLoadPath = "C:\\Program Files\\AnD\\Strida\\DeviceData.xml";
        #endregion

        /// <summary>
        /// 생성자
        /// </summary>
        public StridaMain()
        {
            InitializeComponent();
            this.Init();
        }

        /// <summary>
        /// override OnClosing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("프로그램을 종료하겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
            }
            else
            {
                e.Cancel = true;
            }

            base.OnClosing(e);
        }

        #region init
        /// <summary>
        /// 초기화
        /// </summary>
        private void Init()
        {
            this.deviceMng = new DeviceMng();
            this.orderBridgeMng = new OrderBridgeMng(this.deviceMng);
            this.orderBridgeMng.OnCasOrderEvt += new EventHandler<CasOrderEventArgs>(orderBridgeMng_OnCasOrderEvt);
            this.orderBridgeMng.OnDmbOrderEvt += new EventHandler<DmbOrderEventArgs>(orderBridgeMng_OnDmbOrderEvt);
            this.orderBridgeMng.OnCasOrderSendSuccessEvt += new EventHandler<CasOrderEventArgs>(orderBridgeMng_OnCasOrderSendSuccessEvt);
            this.orderBridgeMng.OnDmbOrderSendSuccessEvt += new EventHandler<DmbOrderEventArgs>(orderBridgeMng_OnDmbOrderSendSuccessEvt);
            this.orderBridgeMng.OnCasOrderConnectFailEvt += new EventHandler<CasOrderEventArgs>(orderBridgeMng_OnCasOrderConnectFailEvt);
            this.orderBridgeMng.OnDmbOrderConnectFailEvt += new EventHandler<DmbOrderEventArgs>(orderBridgeMng_OnDmbOrderConnectFailEvt);
            this.orderBridgeMng.OnCasOrderNotOaDeviceEvt += new EventHandler<CasOrderEventArgs>(orderBridgeMng_OnCasOrderNotOaDeviceEvt);
            this.orderBridgeMng.OnDmbOrderNotOaDeviceEvt += new EventHandler<DmbOrderEventArgs>(orderBridgeMng_OnDmbOrderNotOaDeviceEvt);
            this.orderBridgeMng.OnCasOrderNotDeviceEvt += new EventHandler<CasOrderEventArgs>(orderBridgeMng_OnCasOrderNotDeviceEvt);
            this.orderBridgeMng.OnDmbOrderNotDeviceEvt += new EventHandler<DmbOrderEventArgs>(orderBridgeMng_OnDmbOrderNotDeviceEvt);
            this.orderBridgeMng.OnOrderResultEvt += new EventHandler<OrderResultEventArgs>(orderBridgeMng_OnOrderResultEvt);
            this.SetListviewInit();
            this.Text += this.version_1;
            this.versionList.Add(this.version_1);

            //단말정보 로드
            this.deviceMng.DeviceLoad(deviceLoadPath);
        }
        
        /// <summary>
        /// 발령/결과 리스트뷰 초기화
        /// </summary>
        private void SetListviewInit()
        {
            #region 리스트뷰 초기화
            ColumnHeader dIcon = new ColumnHeader();
            dIcon.Text = string.Empty;
            dIcon.Width = 27;
            this.MainOrderLV.Columns.Add(dIcon);

            ColumnHeader dCmd = new ColumnHeader();
            dCmd.Text = "구분";
            dCmd.Width = 55;
            dCmd.TextAlign = HorizontalAlignment.Center;
            this.MainOrderLV.Columns.Add(dCmd);

            ColumnHeader dTime = new ColumnHeader();
            dTime.Text = "시간";
            dTime.Width = 180;
            dTime.TextAlign = HorizontalAlignment.Center;
            this.MainOrderLV.Columns.Add(dTime);

            ColumnHeader dMsg = new ColumnHeader();
            dMsg.Text = "내용";
            dMsg.Width = 470;
            dMsg.TextAlign = HorizontalAlignment.Left;
            this.MainOrderLV.Columns.Add(dMsg);
            #endregion
        }
        #endregion

        #region UI 클릭 Event
        /// <summary>
        /// 종료 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 등록관리 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 등록관리AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DeviceMngForm deviceMngForm = new DeviceMngForm(this.deviceMng))
            {
                deviceMngForm.ShowDialog();
            }
        }

        /// <summary>
        /// 장비 연결관리 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 매핑관리MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DeviceMapForm deviceMapForm = new DeviceMapForm(this.deviceMng))
            {
                deviceMapForm.ShowDialog();
            }
        }

        /// <summary>
        /// 환경설정 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 환경설정EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StridaOptionForm optionForm = new StridaOptionForm())
            {
                optionForm.ShowDialog();
            }
        }

        /// <summary>
        /// 프로그램 정보 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 프로그램정보IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WeatherAboutForm aboutForm = new WeatherAboutForm(this.Text, this.versionList))
            {
                aboutForm.ShowDialog();
            }
        }

        /// <summary>
        /// 발령/결과 내역 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListviewResetLB_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("발령/결과 내역을 초기화하겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                this.MainOrderLV.Items.Clear();
            }
        }

        /// <summary>
        /// 임시 테스트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            #region XML Make/Read
            /*
            //클래스를 Serialized 해서 XML 파일로 저장
            DeviceBase db1 = new DeviceBase();
            db1.Key = "base";
            db1.Name = "base";
            
            DeviceBase db2 = new CasDevice();
            db2.Key = "cas";
            db2.Name = "cas";
            
            DeviceBase db3 = new DmbDevice();
            db3.Key = "dmb";
            db3.Name = "dmb";

            SerializedDevice sd = new SerializedDevice();
            sd.deviceBaseList.Add(db1);
            sd.deviceBaseList.Add(db2);
            sd.deviceBaseList.Add(db3);

            XmlSerializer my = new XmlSerializer(typeof(SerializedDevice), new Type[] { typeof(CasDevice), typeof(DmbDevice), typeof(OaDevice), typeof(DeviceBase) });
            System.IO.StringWriter sw = new System.IO.StringWriter();
            my.Serialize(sw, sd);
            System.IO.File.WriteAllText("c:\\casmngdata\\xmltest.xml", sw.ToString(), Encoding.Unicode);
            //클래스를 Serialized 해서 XML 파일로 저장_끝


            //XML 파일 읽어서 클래스로 Deserialized
            string tmpStr = System.IO.File.ReadAllText("c:\\casmngdata\\xmltest.xml", Encoding.Unicode);
            System.IO.StringReader sr = new System.IO.StringReader(tmpStr);
            SerializedDevice mapDes = (SerializedDevice)my.Deserialize(sr);
            //XML 파일 읽어서 클래스로 Deserialized_끝
            
            //발령결과 XML 읽기
            //XmlSerializer my = new XmlSerializer(typeof(Response), new Type[] { typeof(Response), typeof(Device) });
            //string tmpStr = System.IO.File.ReadAllText("c:\\casmngdata\\req.xml", Encoding.UTF8);
            //System.IO.StringReader sr = new System.IO.StringReader(tmpStr);
            //Response response = (Response)my.Deserialize(sr);
            //발령결과 XML 읽기_끝
            */
            #endregion
        }
        #endregion

        #region event's
        /// <summary>
        /// DMB 발령 정보를 받는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnDmbOrderEvt(object sender, DmbOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 0;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("DMB");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    e.DmbProto001.DDateTime,
                    (e.DmbProto001.OrderType == 0) ? ("TTS - " + e.DmbProto001.Message.Replace("\r\n", " ")) :
                    (e.DmbProto001.OrderType == 1) ? "경계" :
                    (e.DmbProto001.OrderType == 2) ? "공습" :
                    (e.DmbProto001.OrderType == 3) ? "재난위험" : "해제"));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// 민방위 발령 정보를 받는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnCasOrderEvt(object sender, CasOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                OlprtCTc001 olprt001 = (OlprtCTc001)e.Olp;
                string msg = string.Empty;

                if (olprt001.Kind == 20)
                {
                    byte[] tmpLength = new byte[] { olprt001.Data[19], olprt001.Data[20] };
                    short length = BitConverter.ToInt16(tmpLength, 0);
                    byte[] tmpMsg = new byte[length];

                    for (int i = 0; i < length; i++)
                    {
                        tmpMsg[i] = olprt001.Data[21 + i];
                    }

                    msg = Encoding.Default.GetString(tmpMsg, 0, length);
                }

                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 0;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("민방위");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    olprt001.TimeAlmDT,
                    (olprt001.Kind == 1) ? "예비" :
                    (olprt001.Kind == 2) ? "경계" :
                    (olprt001.Kind == 3) ? "공습" :
                    (olprt001.Kind == 5) ? "해제" :
                    (olprt001.Kind == 9) ? "재난위험" :
                    (olprt001.Kind == 20) ? "TTS - " + msg.Replace("\r\n", " ") : string.Empty));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// DMB 발령 정보 OA로 전송 성공 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnDmbOrderSendSuccessEvt(object sender, DmbOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 1;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("OAE");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    e.DmbProto001.DDateTime,
                    (e.DmbProto001.OrderType == 0) ? "TTS, 전송 성공!" :
                    (e.DmbProto001.OrderType == 1) ? "경계, 전송 성공!" :
                    (e.DmbProto001.OrderType == 2) ? "공습, 전송 성공!" : "재난위험, 전송 성공!"));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// 민방위 발령 정보 OA로 전송 성공 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnCasOrderSendSuccessEvt(object sender, CasOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                OlprtCTc001 olprt001 = (OlprtCTc001)e.Olp;

                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 1;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("OAE");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    olprt001.TimeAlmDT,
                    (olprt001.Kind == 1) ? "예비, 전송 성공!" :
                    (olprt001.Kind == 2) ? "경계, 전송 성공!" :
                    (olprt001.Kind == 3) ? "공습, 전송 성공!" :
                    (olprt001.Kind == 5) ? "해제, 전송 성공!" :
                    (olprt001.Kind == 9) ? "재난위험, 전송 성공!" :
                    (olprt001.Kind == 20) ? "TTS, 전송 성공!" : string.Empty));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// DMB 발령을 송신하기 위한 TCP 커넥션이 실패함을 알리는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnDmbOrderConnectFailEvt(object sender, DmbOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 4;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("DMB");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    e.DmbProto001.DDateTime,
                    (e.DmbProto001.OrderType == 0) ? "TTS, TCP 연결 실패!" :
                    (e.DmbProto001.OrderType == 1) ? "경계, TCP 연결 실패!" :
                    (e.DmbProto001.OrderType == 2) ? "공습, TCP 연결 실패!" : "재난위험, TCP 연결 실패!"));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// 민방위 발령을 송신하기 위한 TCP 커넥션이 실패함을 알리는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnCasOrderConnectFailEvt(object sender, CasOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                OlprtCTc001 olprt001 = (OlprtCTc001)e.Olp;

                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 4;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("민방위");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    olprt001.TimeAlmDT,
                    (olprt001.Kind == 1) ? "예비, TCP 연결 실패!" :
                    (olprt001.Kind == 2) ? "경계, TCP 연결 실패!" :
                    (olprt001.Kind == 3) ? "공습, TCP 연결 실패!" :
                    (olprt001.Kind == 5) ? "해제, TCP 연결 실패!" :
                    (olprt001.Kind == 9) ? "재난위험, TCP 연결 실패!" :
                    (olprt001.Kind == 20) ? "TTS, TCP 연결 실패!" : string.Empty));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// DMB 발령에 대한 해당 OA장비가 없을 경우 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnDmbOrderNotOaDeviceEvt(object sender, DmbOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 4;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("DMB");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    e.DmbProto001.DDateTime,
                    (e.DmbProto001.OrderType == 0) ? "TTS, 연결된 OA장비 없음!" :
                    (e.DmbProto001.OrderType == 1) ? "경계, 연결된 OA장비 없음!" :
                    (e.DmbProto001.OrderType == 2) ? "공습, 연결된 OA장비 없음!" : "재난위험, 연결된 OA장비 없음!"));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// 민방위 발령에 대한 해당 OA장비가 없을 경우 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnCasOrderNotOaDeviceEvt(object sender, CasOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                OlprtCTc001 olprt001 = (OlprtCTc001)e.Olp;

                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 4;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("민방위");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    olprt001.TimeAlmDT,
                    (olprt001.Kind == 1) ? "예비, 연결된 OA장비 없음!" :
                    (olprt001.Kind == 2) ? "경계, 연결된 OA장비 없음!" :
                    (olprt001.Kind == 3) ? "공습, 연결된 OA장비 없음!" :
                    (olprt001.Kind == 5) ? "해제, 연결된 OA장비 없음!" :
                    (olprt001.Kind == 9) ? "재난위험, 연결된 OA장비 없음!" :
                    (olprt001.Kind == 20) ? "TTS, 연결된 OA장비 없음!" : string.Empty));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// DMB 발령에 대한 해당 장비가 등록되어 있지 않을 떄 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnDmbOrderNotDeviceEvt(object sender, DmbOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 4;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("DMB");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    e.DmbProto001.DDateTime,
                    (e.DmbProto001.OrderType == 0) ? "TTS, 해당 발령장비 등록되어 있지 않음!" :
                    (e.DmbProto001.OrderType == 1) ? "경계, 해당 발령장비 등록되어 있지 않음!" :
                    (e.DmbProto001.OrderType == 2) ? "공습, 해당 발령장비 등록되어 있지 않음!" : "재난위험, 해당 발령장비 등록되어 있지 않음!"));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// 민방위 발령에 대한 해당 장비가 등록되어 있지 않을 떄 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnCasOrderNotDeviceEvt(object sender, CasOrderEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                OlprtCTc001 olprt001 = (OlprtCTc001)e.Olp;

                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 4;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("민방위");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0}, {1}",
                    olprt001.TimeAlmDT,
                    (olprt001.Kind == 1) ? "예비, 해당 발령장비 등록되어 있지 않음!" :
                    (olprt001.Kind == 2) ? "경계, 해당 발령장비 등록되어 있지 않음!" :
                    (olprt001.Kind == 3) ? "공습, 해당 발령장비 등록되어 있지 않음!" :
                    (olprt001.Kind == 5) ? "해제, 해당 발령장비 등록되어 있지 않음!" :
                    (olprt001.Kind == 9) ? "재난위험, 해당 발령장비 등록되어 있지 않음!" :
                    (olprt001.Kind == 20) ? "TTS, 해당 발령장비 등록되어 있지 않음!" : string.Empty));

                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }

        /// <summary>
        /// 발령결과 수신 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderBridgeMng_OnOrderResultEvt(object sender, OrderResultEventArgs e)
        {
            MethodInvoker SetInvoker = delegate()
            {
                string result = string.Empty;
                DateTime dt = new DateTime(
                    int.Parse(e.response.WarningNo.Substring(0, 4)),
                    int.Parse(e.response.WarningNo.Substring(4, 2)),
                    int.Parse(e.response.WarningNo.Substring(6, 2)),
                    int.Parse(e.response.WarningNo.Substring(8, 2)),
                    int.Parse(e.response.WarningNo.Substring(10, 2)),
                    int.Parse(e.response.WarningNo.Substring(12, 2)));

                for (int i = 0; i < e.response.DeviceList.Count; i++)
                {
                    result += string.Format(" [{0} - {1}]", e.response.DeviceList[i].DeviceName,
                        (e.response.DeviceList[i].ResultCode == "0") ? "성공" :
                        (e.response.DeviceList[i].ResultCode == "2") ? "대기중" : "실패");
                }

                ListViewItem lvi = new ListViewItem();
                lvi.StateImageIndex = 0;
                lvi.Text = string.Empty;
                lvi.SubItems.Add("OAE");
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add(string.Format("발령시간 - {0},{1}", dt, result));
                this.MainOrderLV.Items.Add(lvi);
            };

            if (this.MainOrderLV.InvokeRequired)
            {
                this.Invoke(SetInvoker);
            }
            else
            {
                SetInvoker();
            }
        }
        #endregion
    }
}