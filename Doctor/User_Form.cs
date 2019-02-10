using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class User_Form : Form
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        #region Member Value

        Pen m_DrawPen;
        System.Boolean bPenRunning = false;
        int PacketCnt = 0;
        bool m_bDraw = false;

        bool m_bDrag;
        PointF m_ptMouseMove;
        bool bPenConnecting = false;
        bool bPenConnectExit = false;

        //for drawing .
        Bitmap m_Bmp; //bitmap for double buffering
        Bitmap m_BmpLayer; //bitmap for layer drawing in case of highlighter pen
        public Graphics m_GrBmp; //virtual bitmap
        public Graphics m_GrMain; //graphics for picturebox control
        public Graphics m_GrLayer; //graphics for m_BmpLayer

        int intNumberOfPoints = 0;

        System.IntPtr m_ReciveHanle;
        System.IntPtr m_DrawHanle;
        Module1._pen_rec m_pRec = new Module1._pen_rec(); //structure for Pen Data

        public bool bPenConnect = false; //Pen is connect or not
        public System.Timers.Timer m_ConnectTime;
        public System.Threading.Thread ConnectThread;

        Module1.PENSTYLE m_PenStyle;
        CPNFStroke m_Stroke;
        ImageAttributes imgattr; //highlighter attribute
        const double Htransparency = 0.3; // transparency of highlighter

        PenMemory_Form m_frmMemory;

        int connectdisconnect_message = 0;

        #endregion

        #region delegates

        delegate void ConnectDelegate();

        delegate void connectPenTextDelegate(string sTitle);

        #endregion

        #region Timer

        public void ConnectingTimerStart()
        {
            m_ConnectTime = new System.Timers.Timer(10000);

            m_ConnectTime.Elapsed += ClickaliveTime_Elapsed;

            m_ConnectTime.Start();
        }

        public void ConnectingTimerEnd()
        {
            if (ReferenceEquals(m_ConnectTime, null))
            {
                return;
            }

            m_ConnectTime.Stop();
            bPenConnectExit = true;

            m_ConnectTime.Elapsed -= ClickaliveTime_Elapsed;
        }

        public void ClickaliveTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ConnectingTimerEnd();
            ConnectDelegate del1 = new ConnectDelegate(MessageDelegate);
            this.BeginInvoke(del1);
        }

        int x = 5;
        private void timerpower_Tick(object sender, EventArgs e)
        {
            if (power == false)
            {
                x += 5;
                panelpowerbutton.Location = new Point(x, 0);
                if (panelpowerbutton.Location.X >= location.X)
                {
                    timerpower.Stop();
                    power = true;
                    panelConnect.BackColor = Color.FromArgb(245, 245, 245);
                    lbpower.Text = "ON";
                    if(!bPenConnect)
                    {
                        m_ReciveHanle = this.Handle;
                        m_DrawHanle = pbdrawing.Handle;

                        if (bPenConnecting == false)
                        {
                            m_frmMemory = new PenMemory_Form();
                            m_frmMemory.Show();
                            m_frmMemory.FormClosing += MemoryForm_MyEvent;
                            connectdisconnect_message = 0;
                            panelConnect.Enabled = false;
                            panelpowerbutton.Enabled = false;
                            panelpowerbar.Enabled = false;
                            ConnectThread = new System.Threading.Thread(new System.Threading.ThreadStart(ConnectPen));
                            ConnectThread.Start();
                            bPenConnecting = true;
                        }
                    }
                    this.Refresh();
                }
            }
            else
            {
                x -= 5;
                panelpowerbutton.Location = new Point(x, 0);
                if (panelpowerbutton.Location.X <= 0)
                {
                    timerpower.Stop();
                    power = false;
                    panelConnect.BackColor = Color.FromArgb(252, 252, 252);
                    lbpower.Text = "OFF";
                    if(bPenConnect)
                    {
                        bPenConnecting = false;
                        DisConnectPen();
                        progbarbattery.Value = 0;
                        lbbattery.Text = "Battery";
                        connectPenTextChange("OFF");
                    }
                    this.Refresh();
                }
            }
        }

        private void MemoryForm_MyEvent(object sender, FormClosingEventArgs e)
        {
            if (lbbattery.Text == "Battery")
            {
                if (message1.Visible == false)
                {
                    ((Label)message1.Controls["lbmessage"]).Text = "Try again connecting Pen";
                    message1.Visible = true;
                    m_frmMemory.Close();
                }
            }
        }

        #endregion

        public PictureBox PBdrawing
        {
            get { return this.pbdrawing; }
        }

        PrivateFontCollection pfc = new PrivateFontCollection();
        Color backcolor = Color.FromArgb(56, 143, 163);
        Color highlightcolor = Color.FromArgb(56, 113, 133);
        Color selectcolor = Color.FromArgb(56, 213, 233);

        Point location;
        bool power;

        public User_Form()
        {
            InitializeComponent();

            this.payment1.ParentForm = this;

            this.appointment1.ParentForm = this;

            this.vaccination1.ParentForm = this;

            this.patient1.ParentForm = this;

            this.report1.reportEvent += Search_MyEvent;

            this.appointment1.CalendarVaccination += NewVaccination_MyEvent;

            this.appointment1.CalendarVaccinationCancel += CancelVaccination_MyEvent;

            this.vaccination1.CalendarAppointment += NewAppointment_MyEvent;

            this.vaccination1.CalendarAppointmentCancel += CancelAppointment_MyEvent;

            this.patient1.PatientEvent += Image_MyEvent;

            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            lbreports.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbpatients.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbmanagappointment.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbmanagvaccination.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbpayment.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbprofile.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbmastersearch.Font = new Font(pfc.Families[0], 10, FontStyle.Bold);
            lbbattery.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            gbpencontrol.Font = new Font(pfc.Families[0], 7, FontStyle.Bold);
            lbpower.Font = new Font(pfc.Families[0], 9, FontStyle.Bold);

            tbmastersearch.Text = "Search";
            tbmastersearch.ForeColor = Color.DarkGray;

            lbbattery.Text = "Battery";

            location = new Point(panelConnect.Width-5,0);
            power = false;
        }

        private void Image_MyEvent(object sender, EventArgs e)
        {
            Properties.Settings.Default.page += 1;
            Properties.Settings.Default.Save();
            string path = Properties.Settings.Default.prescriptionLocation + @"Offline\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            m_Bmp.Save(path + Properties.Settings.Default.page + ".png", System.Drawing.Imaging.ImageFormat.Png);
            overlayImage();
        }

        private void CancelAppointment_MyEvent(object sender, EventArgs e)
        {
            appointmentClick();

            this.appointment1.FirstName = this.vaccination1.FirstName;
            this.appointment1.LastName = this.vaccination1.LastName;
            this.appointment1.AppointmentID = this.vaccination1.AppointmentID;
            this.appointment1.Date = this.vaccination1.Date;
            this.appointment1.Type = "appointment";

            this.appointment1.viewCancelAppointment();
        }

        private void NewAppointment_MyEvent(object sender, EventArgs e)
        {
            appointmentClick();

            this.appointment1.AppointmentID = this.vaccination1.AppointmentID;
            this.appointment1.Date = this.vaccination1.Date;
            this.appointment1.TimeSlot = this.vaccination1.TimeSlot;
            this.appointment1.FirstName = this.vaccination1.FirstName;
            this.appointment1.LastName = this.vaccination1.LastName;
            this.appointment1.Gender = this.vaccination1.Gender;
            this.appointment1.Age = this.vaccination1.Age;
            this.appointment1.Mobile = this.vaccination1.Mobile;
            this.appointment1.VaccinationType = this.vaccination1.VaccinationType;
            this.appointment1.Type = "appointment";

            this.appointment1.viewNewAppointment();
        }

        private void CancelVaccination_MyEvent(object sender, EventArgs e)
        {
            vaccicationClick();

            this.vaccination1.FirstName = this.appointment1.FirstName;
            this.vaccination1.LastName = this.appointment1.LastName;
            this.vaccination1.AppointmentID = this.appointment1.AppointmentID;
            this.vaccination1.Date = this.appointment1.Date;
            this.vaccination1.Type = "vaccination";

            this.vaccination1.viewCancelVaccination();
        }

        private void NewVaccination_MyEvent(object sender, EventArgs e)
        {
            vaccicationClick();

            this.vaccination1.AppointmentID = this.appointment1.AppointmentID;
            this.vaccination1.Date = this.appointment1.Date;
            this.vaccination1.TimeSlot = this.appointment1.TimeSlot;
            this.vaccination1.FirstName = this.appointment1.FirstName;
            this.vaccination1.LastName = this.appointment1.LastName;
            this.vaccination1.Gender = this.appointment1.Gender;
            this.vaccination1.Age = this.appointment1.Age;
            this.vaccination1.Mobile = this.appointment1.Mobile;
            this.vaccination1.VaccinationType = this.appointment1.VaccinationType;
            this.vaccination1.Type = "vaccination";

            this.vaccination1.viewNewVaccination();
        }

        private void Search_MyEvent(object sender, EventArgs e)
        {
            string type = this.report1.Type;
            string ID = this.report1.ID;

            string appointmentdate = string.Empty;
            string vaccinationdate = string.Empty;
            string duedate = string.Empty;
            string timeslot = string.Empty;
            string vaccinationtype = string.Empty;
            string patientname = string.Empty;
            string gender = string.Empty;
            string age = string.Empty;
            string mobile = string.Empty;
            string vaccinationstatus = string.Empty;
            string vaccinationID = string.Empty;
            string appointmentstatus = string.Empty;
            string appointmentID = string.Empty;
            string amount = string.Empty;
            string amtpaid = string.Empty;
            string baldue = string.Empty;
            string paymentstatus = string.Empty;
            string paymentID = string.Empty;
            Image img = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd;
                cmd = new SqlCommand("MasterSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

                if (type == "appointment")
                {
                    appointmentClick();

                    appointment1.data.Rows.Clear();
                    while(reader.Read())
                    {
                        appointmentdate = reader[0].ToString();
                        timeslot = reader[1].ToString();
                        patientname = reader[2].ToString();
                        gender = reader[3].ToString();
                        age = reader[4].ToString();
                        mobile = reader[5].ToString();
                        appointmentstatus = reader[6].ToString();
                        appointmentID = reader[7].ToString();

                        if (appointmentstatus == "today")
                            img = Properties.Resources.today;
                        else if (appointmentstatus == "upcoming")
                            img = Properties.Resources.upcoming;
                        else if (appointmentstatus == "completed")
                            img = Properties.Resources.completed;
                        else if (appointmentstatus == "cancelled")
                            img = Properties.Resources.cancelled;

                        this.appointment1.data.Rows.Add(appointmentdate, timeslot, patientname, gender, age, mobile, img, null, Properties.Resources.cancel, appointmentstatus, appointmentID);

                        ((calendarView)this.appointment1.Controls["calendarView1"]).Visible = false;
                    }
                }
                else if (type == "vaccination")
                {
                    vaccicationClick();

                    vaccination1.data.Rows.Clear();
                    while (reader.Read())
                    {
                        vaccinationdate = reader[0].ToString();
                        timeslot = reader[1].ToString();
                        vaccinationtype = reader[2].ToString();
                        patientname = reader[3].ToString();
                        gender = reader[4].ToString();
                        age = reader[5].ToString();
                        mobile = reader[6].ToString();
                        vaccinationstatus = reader[7].ToString();
                        vaccinationID = reader[8].ToString();

                        if (vaccinationstatus == "today")
                            img = Properties.Resources.today;
                        else if (vaccinationstatus == "upcoming")
                            img = Properties.Resources.upcoming;
                        else if (vaccinationstatus == "completed")
                            img = Properties.Resources.completed;
                        else if (vaccinationstatus == "cancelled")
                            img = Properties.Resources.cancelled;

                        this.vaccination1.data.Rows.Add(vaccinationdate, timeslot, vaccinationtype, patientname, gender, age, mobile, img, null, Properties.Resources.cancel, vaccinationstatus, vaccinationID);
                        ((calendarView)this.vaccination1.Controls["calendarView1"]).Visible = false;
                    }
                }
                else if (type == "payment")
                {
                    paymentClick();

                    payment1.data.Rows.Clear();
                    while (reader.Read())
                    {
                        duedate = reader[0].ToString();
                        patientname = reader[1].ToString();
                        mobile = reader[2].ToString();
                        amount = reader[3].ToString();
                        amtpaid = reader[4].ToString();
                        baldue = reader[5].ToString();
                        paymentstatus = reader[6].ToString();
                        paymentID = reader[7].ToString();

                        if (paymentstatus == "overdue")
                            img = Properties.Resources.overdue;
                        else if (paymentstatus == "upcoming")
                            img = Properties.Resources.upcoming;
                        else if (paymentstatus == "completed")
                            img = Properties.Resources.completed;
                        else if (paymentstatus == "today")
                            img = Properties.Resources.today;
                        else
                            img = Properties.Resources.unknownstatus;

                        this.payment1.data.Rows.Add(duedate, patientname, mobile, amount, amtpaid, baldue, img, null, Properties.Resources.cancel, paymentstatus, paymentID);
                    }
                    
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void User_Form_Load(object sender, EventArgs e)
        {
            btnreports.BackColor = selectcolor;
            panel_sidebar.Height = btnreports.Height;
            panel_sidebar.Top = btnreports.Top;

            pbdrawing.Image = Image.FromFile(Properties.Settings.Default.prescriptionPage);

            setPenStyle();

            m_bDraw = true;

            CreateBitmap(true);

            timerpower.Start();

            try
            {
                tbmastersearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                tbmastersearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select firstname, lastname, mobile from Table_Patient";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string firstname = reader[0].ToString();
                    string lastname = reader[1].ToString();
                    string mobile = reader[2].ToString();
                    if (firstname != "NA")
                    {
                        DataCollection.Add(firstname);
                    }
                    if (lastname != "NA")
                    {
                        DataCollection.Add(lastname);
                    }
                    if(mobile != "NA")
                    {
                        DataCollection.Add(mobile);
                    }
                }
                reader.Close();
                tbmastersearch.AutoCompleteCustomSource = DataCollection;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            Update_Class update = new Update_Class();
            Thread update_thread = new Thread(new ThreadStart(update.Update_Thread));
            update_thread.Start();

            this.patient1.call_Thread();
        }

        #region Connect/Disconnect
        public void EquilReceiveHandle()
        {
            //If you set this, USB connection message will be sent to the window handle.
            //without find connect pen
            Module1.SetReciveHandle(m_ReciveHanle);
        }
        public void ConnectPen()
        {
            //        SetReciveHandle(m_ReciveHanle)
            this.Invoke(new MethodInvoker(this.EquilReceiveHandle));
            Module1.SetDrawRect(pbdrawing.Width, pbdrawing.Height);

            if (Module1.FindDevice()) //find usb connetion (only for over F/W version 6)
            {
            }
            else
            {
                Module1.PortSearch(); //find BT Connection

            }


            ConnectingTimerStart(); //waiting for connection

            while (bPenConnectExit == false)
            {
                System.Threading.Thread.Sleep(100);
            }

            //check if connecting pen
            ConnectingTimerEnd();

            bPenConnectExit = false;

            bPenConnect = true;

            ConnectDelegate del = new ConnectDelegate(DelegateUISet);
            this.BeginInvoke(del);

            SetCalibration();
            bPenConnecting = false;
            MouseFlagDisable();
        }

        public void DisConnectPen()
        {
            try
            {
                Module1.OnDisconnect(0);
            }
            catch (Exception)
            {
            }

            bPenConnect = System.Convert.ToBoolean(Module1.CheckConnect());

            ConnectDelegate del = new ConnectDelegate(DelegateUISet);
            this.BeginInvoke(del);

            bPenConnecting = false;
            MouseFlagDisable();
        }

        #endregion

        #region General Function

        public void MessageDelegate()
        {
            if (lbbattery.Text == "Battery")
            {
                if(message1.Visible == false)
                {
                    m_frmMemory.Close();
                }
            }
        }

        public void setPenStyle()
        {
            m_PenStyle = (Module1.PENSTYLE)0;

            if (m_PenStyle == Module1.PENSTYLE.PENSTYLE_HIGHLIGHT)
            {
                m_DrawPen = new Pen(Color.Red, 1);
                m_DrawPen.SetLineCap(LineCap.Square, LineCap.Square, DashCap.Round);
                m_DrawPen.LineJoin = LineJoin.Round;
                m_DrawPen.Color = Color.Red;
            }
            else
            {
                m_DrawPen = new Pen(Color.Black, 1);
                m_DrawPen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Flat);
                m_DrawPen.LineJoin = LineJoin.Round;
            }
        }
        public void MouseFlagDisable()
        {
            if (m_bDrag)
            {
                picMainDoMouseUp(m_ptMouseMove, (System.Int32)MouseButtons.Left, 255, false);
            }
        }

        private void DelegateUISet()
        {
            if (bPenConnect)
            {
                bPenRunning = true;
                panelConnect.Enabled = true;
                panelpowerbutton.Enabled = true;
                panelpowerbar.Enabled = true;
                this.clear_page();
            }
            else
            {
                bPenRunning = true;
                panelConnect.Enabled = true;
                panelpowerbutton.Enabled = true;
                panelpowerbar.Enabled = true;
            }
        }

        public Rectangle GetRegularRectFromPoint(Point ptStart, Point ptEnd)
        {
            Rectangle rt2 = new Rectangle();
            rt2.X = Math.Min(ptStart.X, ptEnd.X);
            rt2.Y = Math.Min(ptStart.Y, ptEnd.Y);

            rt2.Width = Math.Abs(ptEnd.X - ptStart.X);
            rt2.Height = Math.Abs(ptEnd.Y - ptStart.Y);
            return rt2;

        }

        private void connectPenTextChange(string sTitle)
        {
            lbpower.Text = sTitle;
        }

        public void CreateBitmap(bool bCreate)
        {
            if (m_Bmp != null)
            {
                m_Bmp.Dispose();
            }
            if (m_BmpLayer != null)
            {
                m_BmpLayer.Dispose();
            }


            m_Bmp = new Bitmap(pbdrawing.Width, pbdrawing.Height);
            m_BmpLayer = new Bitmap(pbdrawing.Width, pbdrawing.Height);

            m_GrBmp = Graphics.FromImage(m_Bmp);
            m_GrLayer = Graphics.FromImage(m_BmpLayer);

            m_GrBmp.SmoothingMode = SmoothingMode.AntiAlias;
            m_GrLayer.SmoothingMode = SmoothingMode.AntiAlias;

            SetHPenAlpha();
        }
        public void SetHPenAlpha()
        {
            if (ReferenceEquals(imgattr, null))
            {
                imgattr = new ImageAttributes(); //imgattr.Dispose()
            }

            float[][] values = new float[][] { new Single[] { 1, 0, 0, 0, 0 }, new Single[] { 0, 1, 0, 0, 0 }, new Single[] { 0, 0, 1, 0, 0 }, new Single[] { 0, 0, 0, Convert.ToSingle(Htransparency), 0 }, new Single[] { 0, 0, 0, 0, 1, 0 } };
            ColorMatrix colMatrix = new ColorMatrix(values);
            imgattr.SetColorMatrix(colMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        }

        public void SetCalibration()
        {
            PointF ptStart = new PointF();
            PointF ptEnd = new PointF();
            RegistryKey regWord = null;
            if (GetRegistryKey(ref regWord, true))
            {
                if (Module1.EquilModelCode == 3)
                {
                    ptStart.X = 1810;
                    ptStart.Y = 325;
                    ptEnd.X = 5500;
                    ptEnd.Y = 5340;
                    //If key is not exist, each calibration value setting with letter
                    //ptStart.X = float.Parse(System.Convert.ToString(regWord.GetValue("Equil2Left", "10000")));
                    //ptStart.Y = float.Parse(System.Convert.ToString(regWord.GetValue("Equil2Top", "10000")));
                    //ptEnd.X = float.Parse(System.Convert.ToString(regWord.GetValue("Equil2Right", "0")));
                    //ptEnd.Y = float.Parse(System.Convert.ToString(regWord.GetValue("Equil2Bottm", "0")));
                }
                else if (Module1.EquilModelCode == 4)
                {
                    //If key is not exist, each calibration value setting with 6 fit X 4 fit Board
                    ptStart.X = float.Parse(System.Convert.ToString(regWord.GetValue("EquilMakerLeft", "1728")));
                    ptStart.Y = float.Parse(System.Convert.ToString(regWord.GetValue("EquilMakerTop", "45372")));
                    ptEnd.X = float.Parse(System.Convert.ToString(regWord.GetValue("EquilMakerRight", "13796")));
                    ptEnd.Y = float.Parse(System.Convert.ToString(regWord.GetValue("EquilMakerBottm", "9452")));
                }
                else
                {
                    ptStart.X = float.Parse(System.Convert.ToString(regWord.GetValue("EquilLeft", "1737")));
                    ptStart.Y = float.Parse(System.Convert.ToString(regWord.GetValue("EquilTop", "541")));
                    ptEnd.X = float.Parse(System.Convert.ToString(regWord.GetValue("EquilRight", "3708")));
                    ptEnd.Y = float.Parse(System.Convert.ToString(regWord.GetValue("EquilBottm", "4277")));
                }

                if (bPenConnect)
                {
                    Module1.SetCalibration_Top(ptStart.X, ptStart.Y);
                    Module1.SetCalibration_Bottom(ptEnd.X, ptEnd.Y);
                    Module1.SetCalibration_End();
                }
            }
            else
            {
                if (Module1.EquilModelCode == 3)
                {
                    //If key is not exist, each calibration value setting with letter
                    ptStart.X = 1906;
                    ptStart.Y = 345;
                    ptEnd.X = 5320;
                    ptEnd.Y = 4846;
                }
                else if (Module1.EquilModelCode == 4)
                {
                    //If key is not exist, each calibration value setting with 6 fit X 4 fit Board
                    ptStart.X = 1728;
                    ptStart.Y = 45372;
                    ptEnd.X = 13796;
                    ptEnd.Y = 9452;
                }
                else
                {
                    ptStart.X = 1737;
                    ptStart.Y = 541;
                    ptEnd.X = 3708;
                    ptEnd.Y = 4277;
                }

                if (bPenConnect)
                {
                    Module1.SetCalibration_Top(ptStart.X, ptStart.Y);
                    Module1.SetCalibration_Bottom(ptEnd.X, ptEnd.Y);
                    Module1.SetCalibration_End();

                    SaveRegisty(ptStart, ptEnd);
                }
            }
        }

        private void SaveRegisty(PointF ptStart, PointF ptEnd)
        {
            RegistryKey regWord = null;
            if (GetRegistryKey(ref regWord, false))
            {
                if (Module1.EquilModelCode == 3)
                {
                    regWord.SetValue("Equil2Left", ptStart.X.ToString());
                    regWord.SetValue("Equil2Top", ptStart.Y.ToString());
                    regWord.SetValue("Equil2Right", ptEnd.X.ToString());
                    regWord.SetValue("Equil2Bottm", ptEnd.Y.ToString());
                }
                else if (Module1.EquilModelCode == 4)
                {
                    regWord.SetValue("EquilMakerLeft", ptStart.X.ToString());
                    regWord.SetValue("EquilMakerTop", ptStart.Y.ToString());
                    regWord.SetValue("EquilMakerRight", ptEnd.X.ToString());
                    regWord.SetValue("EquilMakerBottm", ptEnd.Y.ToString());
                }
                else
                {
                    regWord.SetValue("EquilLeft", ptStart.X.ToString());
                    regWord.SetValue("EquilTop", ptStart.Y.ToString());
                    regWord.SetValue("EquilRight", ptEnd.X.ToString());
                    regWord.SetValue("EquilBottm", ptEnd.Y.ToString());
                }
            }
        }

        /// <summary>
        /// Return registry value
        /// </summary>
        /// <param name="regWord">return registry key</param>
        /// <param name="bOpen">open or save</param>
        /// <returns>True is exist key, false is not exist key.</returns>
        /// <remarks></remarks>
        public bool GetRegistryKey(ref Microsoft.Win32.RegistryKey regWord, bool bOpen)
        {
            Microsoft.Win32.RegistryKey regClasses = Microsoft.Win32.Registry.CurrentUser;

            if (bOpen)
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    regWord = regClasses.OpenSubKey("Software\\Wow6432Node\\PNF\\Equilnote\\Settings");
                }
                else
                {
                    regWord = regClasses.OpenSubKey("Software\\PNF\\Equilnote\\Settings");
                }

                regWord = regClasses.OpenSubKey("Software\\PNF\\EquilSimulator\\Settings");
            }
            else
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    regWord = regClasses.CreateSubKey("Software\\Wow6432Node\\PNF\\Equilnote\\Settings", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                else
                {
                    regWord = regClasses.CreateSubKey("Software\\PNF\\Equilnote\\Settings", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                regWord = regClasses.CreateSubKey("Software\\PNF\\EquilSimulator\\Settings", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            regClasses.Close();
            if (ReferenceEquals(regWord, null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SetDIList()
        {
            m_frmMemory.SetDIList();
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public void overlayImage()
        {
            Image imageBackground;

            try
            {
                imageBackground = pbdrawing.Image;
                imageBackground = resizeImage(imageBackground, new Size(541, 766));

                string path = Properties.Settings.Default.prescriptionLocation + @"\Offline\";
                Image imageOverlay = Image.FromFile(path + Properties.Settings.Default.page + ".png");

                Image img = new Bitmap(541, 766);
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.DrawImage(imageBackground, new Point(0, 0));
                    g.DrawImage(imageOverlay, new Point(0, 0));
                }
                imageBackground.Dispose();
                imageOverlay.Dispose();
                img.Save(path + Properties.Settings.Default.page + ".png", System.Drawing.Imaging.ImageFormat.Png);
                img.Dispose();
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.Message);
            }
        }

        #endregion

        #region events

        #region Mouse Event
        public void picMainDoMouseDown(PointF e, int btn, int press, bool bCtrlKey)
        {
            m_bDrag = true;

            switch (m_PenStyle)
            {
                case Module1.PENSTYLE.PENSTYLE_BRUSH:
                case Module1.PENSTYLE.PENSTYLE_HIGHLIGHT:
                case Module1.PENSTYLE.PENSTYLE_NORMAL:

                    m_Stroke = new CPNFStroke();
                    m_Stroke.AddItem(e, press);
                    break;
            }
        }

        public void picMainDoMouseMove(PointF e, int btn, int Press, bool bCtrlKey)
        {
            try
            {
                if (m_bDrag == true)
                {
                    m_ptMouseMove.X = e.X;
                    m_ptMouseMove.Y = e.Y;

                    switch (m_PenStyle)
                    {

                        case Module1.PENSTYLE.PENSTYLE_BRUSH:
                            m_Stroke.AddItem(m_ptMouseMove, Press);
                            m_Stroke.DrawBrushByPenPressure(m_GrBmp, m_DrawPen, -1);
                            m_Stroke.DrawBrushByPenPressure(m_GrMain, m_DrawPen, -1);
                            break;

                        case Module1.PENSTYLE.PENSTYLE_HIGHLIGHT:
                            m_Stroke.AddItem(m_ptMouseMove, Press);
                            RectangleF clipRect = m_Stroke.DrawLastQuard(m_GrLayer, m_DrawPen, -1);
                            pbdrawing.Invalidate(Rectangle.Round(clipRect));
                            break;

                        case Module1.PENSTYLE.PENSTYLE_NORMAL:
                            m_GrMain = pbdrawing.CreateGraphics();
                            m_GrMain.SmoothingMode = SmoothingMode.AntiAlias;
                            m_Stroke.AddItem(m_ptMouseMove, Press);
                            m_Stroke.DrawLastQuard(m_GrBmp, m_DrawPen, -1);
                            m_Stroke.DrawLastQuard(m_GrMain, m_DrawPen, -1);
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }

        public void picMainDoMouseUp(PointF e, int btn, int press, bool bCtrlKey)
        {
            if (m_bDrag == true)
            {
                m_bDrag = false;
                if (m_PenStyle == Module1.PENSTYLE.PENSTYLE_HIGHLIGHT)
                {
                    m_GrBmp.DrawImage(m_BmpLayer, new Rectangle(0, 0, m_Bmp.Width, m_Bmp.Height), 0, 0, m_BmpLayer.Width, m_BmpLayer.Height, GraphicsUnit.Pixel, imgattr);
                    m_GrLayer.Clear(Color.Transparent);
                }
                pbdrawing.Invalidate();
            }
        }
        #endregion

        #region Click Event
        public void clear_page()
        {
            if (m_bDraw)
            {
                CreateBitmap(true);
                
                pbdrawing.Invalidate();
            }
            else
            {
                //lbLog.Items.Clear();
            }
        }

        private void panelConnect_Click(object sender, EventArgs e)
        {
            timerpower.Start();
        }

        private void panelpowerbar_Click(object sender, EventArgs e)
        {
            timerpower.Start();
        }

        private void panelpowerbutton_Click(object sender, EventArgs e)
        {
            timerpower.Start();
        }
        #endregion

        #region Drawing Event

        private void pbdrawing_Paint(object sender, PaintEventArgs e)
        {
            if (ReferenceEquals(m_Bmp, null))
            {
                return;
            }

            Graphics gr = e.Graphics;
            GraphicsState grState = null;

            m_GrBmp.Dispose();
            m_GrBmp = Graphics.FromImage(m_Bmp);
            m_GrBmp.SmoothingMode = SmoothingMode.AntiAlias;

            gr.DrawImage(m_Bmp, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);

            if (m_bDrag)
            {
                switch (m_PenStyle)
                {
                    case Module1.PENSTYLE.PENSTYLE_HIGHLIGHT:
                        gr.DrawImage(m_BmpLayer, e.ClipRectangle, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height, GraphicsUnit.Pixel, imgattr);
                        break;
                }
            }
        }

        public System.Drawing.Rectangle GetWorkAreaRect(int nWorkAreaType)
        {
            switch (nWorkAreaType)
            {
                case (int)Module1.WorkAreaType.LETTER:
                    return Module1.Cali_LETTER;
                case (int)Module1.WorkAreaType.A4:
                    return Module1.Cali_A4;
                case (int)Module1.WorkAreaType.A5:
                    return Module1.Cali_A5;
                case (int)Module1.WorkAreaType.B5:
                    return Module1.Cali_B5;
                case (int)Module1.WorkAreaType.B6:
                    return Module1.Cali_B6;
                default:
                    return Rectangle.Empty;
            }
        }
        #endregion
        
        #endregion

        #region Win Messages
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case Module1.WM_DI_CHANGE_STATION:
                    MessageBox.Show("Sensor position changed");
                    break;

                case Module1.WM_DISCONNECTUSB:
                    MessageBox.Show("USB Disconnected");
                    break;

                case Module1.WM_DI_NEWPAGE:
                    Properties.Settings.Default.page += 1;
                    Properties.Settings.Default.Save();
                    string path = Properties.Settings.Default.prescriptionLocation + @"Offline\";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    m_Bmp.Save(path + Properties.Settings.Default.page + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    overlayImage();
                    pbdrawing.Image = Image.FromFile(Properties.Settings.Default.prescriptionPage);
                    this.clear_page();
                    pbdrawing.Visible = false;
                    this.Opacity = 1;
                    patient1.insertData();
                    break;

                case Module1.WM_DI_DUPLICATE:
                    MessageBox.Show("long press button of sensor(Duplicate Page)");
                    break;

                case Module1.WM_RETURNMESSAGE:
                    if (bPenConnect && bPenRunning)
                    {
                        PacketCnt++;

                        m_pRec = new Module1._pen_rec();
                        //  object n_pRec = new Module1._pen_rec();

                        m_pRec = (Module1._pen_rec)Marshal.PtrToStructure(m.WParam, new Module1._pen_rec().GetType()); //get pen data from message

                        int press = m_pRec.P;

                        PointF pt = new PointF();

                        if (m_pRec.ModelCode == 4)
                        {
                            switch (m_pRec.PenTiming)
                            {
                            }
                        }

                        if (m_bDraw)
                        {
                            patient1.Write = true;
                            if (pbdrawing.Visible == false)
                            {
                                this.Opacity = 0.96;
                                pbdrawing.Visible = true;
                                Cursor.Position = new Point(455, 2);
                            }
                            try
                            {
                                pt.X = m_pRec.TX; // Calibrated X
                                pt.Y = m_pRec.TY; // Calibrated Y

                                if(m_pRec.X >= 1670 && m_pRec.X <= 5400 && m_pRec.Y >= 490 && m_pRec.Y <= 800)
                                {
                                    patient1.CRM = true;
                                }

                                switch (m_pRec.PenStatus)
                                {
                                    case (int)Module1.PenStatus.PEN_DOWN:
                                        picMainDoMouseDown(pt, (System.Int32)MouseButtons.Left, press, false);
                                        break;
                                    case (int)Module1.PenStatus.PEN_MOVE:
                                        if (m_bDrag == true)
                                        {
                                            if (m_ptMouseMove.X * 1000 == pt.X * 1000 && m_ptMouseMove.Y * 1000 == pt.Y * 1000) //Move 상태에서 중복된 데이터는 그릴필요가 없어서 제외함.
                                            {
                                            }
                                            else
                                            {
                                                picMainDoMouseMove(pt, (System.Int32)MouseButtons.Left, press, false);
                                            }
                                        }
                                        break;
                                    case (int)Module1.PenStatus.PEN_UP:
                                        picMainDoMouseUp(pt, (System.Int32)MouseButtons.Left, press, false);
                                        break;
                                    case (int)Module1.PenStatus.PEN_HOVER:
                                        break;
                                }
                            }
                            catch (Exception)
                            {
                                MouseFlagDisable();
                            }
                        }
                    }
                    //Console.WriteLine("WM_RETURNMESSAGE");
                    break;

                case Module1.WM_GESTUREMESSAGE:
                    MouseFlagDisable();
                    if (m.LParam == (IntPtr)Module1.GestureMessage.GESTURE_CIRCLE_CLOCKWISE)
                    {
                    }
                    else if (m.LParam == (IntPtr)Module1.GestureMessage.GESTURE_CIRCLE_COUNTERCLOCKWISE)
                    {
                    }
                    else if (m.LParam == (IntPtr)Module1.GestureMessage.GESTURE_CLICK)
                    {
                    }
                    break;

                case Module1.WM_PENCONDITION:
                    //Console.WriteLine("WM_PENCONDITION");
                    Module1.PENConditionData pCondition = new Module1.PENConditionData();
                    pCondition = (Module1.PENConditionData)Marshal.PtrToStructure(m.WParam, new Module1.PENConditionData().GetType()); //PEN DATA STRUCTURE
                    progbarbattery.Minimum = 0;
                    progbarbattery.Maximum = 100;
                    progbarbattery.Value = pCondition.battery_station;
                    if (!pCondition.battery_station.ToString().Equals("0"))
                    {
                        lbbattery.Visible = true;
                        lbbattery.Text = pCondition.battery_station.ToString() + " % Remaining";
                        connectdisconnect_message++;
                    }
                    if(connectdisconnect_message == 1)
                    {
                        ((Label)message1.Controls["lbmessage"]).Text = "Pen connected you can start writing";
                        message1.Visible = true;
                        m_frmMemory.Close();
                    }
                    switch (pCondition.StationPosition)
                    {
                    }

                    Module1.CURRENT_MARKER_DIRECT = pCondition.StationPosition;

                    PacketCnt++; //

                    if (m.LParam == (IntPtr)1) //power off of receiver
                    {
                        DisConnectPen();
                        MouseFlagDisable();
                    }
                    else if (m.LParam == (IntPtr)2) //
                    {

                    }
                    else if (m.LParam == (IntPtr)3) //after connecting firt data receiving
                    {
                        bPenConnectExit = true;
                        Module1.EquilModelCode = pCondition.modelCode; //save equil model number
                        bPenConnect = true;
                    }
                    else if (m.LParam == (IntPtr)0)
                    {
                        if (!bPenConnect) //USB auto recognition.
                        {
                            bPenConnect = true;
                            Module1.EquilModelCode = pCondition.modelCode; //save equil model number
                        }
                    }
                    if (Module1.EquilModelCode == 4)
                    {
                    }
                    if (bPenConnect && bPenRunning)
                    {
                        MouseFlagDisable();
                    }
                    break;

                case Module1.WM_MCU_VERSION:
                    if (Module1.EquilModelCode == 4)
                    {
                        int nVersion1 = m.WParam.ToInt32();
                        int nVersion2 = m.LParam.ToInt32();
                    }
                    break;

                case Module1.WM_DISCONNECTPEN:
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new MethodInvoker(DisConnectPen));
                    }
                    else
                    {
                        timerpower.Start();
                    }
                    if(panelConnect.InvokeRequired)
                    {
                        connectPenTextDelegate cpd = new connectPenTextDelegate(connectPenTextChange);
                        panelConnect.BeginInvoke(cpd, "ON");
                    }
                    if(panelpowerbutton.InvokeRequired)
                    {
                        connectPenTextDelegate cpd = new connectPenTextDelegate(connectPenTextChange);
                        panelpowerbutton.BeginInvoke(cpd, "ON");
                    }
                    if(panelpowerbar.InvokeRequired)
                    {
                        connectPenTextDelegate cpd = new connectPenTextDelegate(connectPenTextChange);
                        panelpowerbar.BeginInvoke(cpd, "ON");
                    }
                    break;
                ///'''' For Memory Import

                case Module1.WM_SHOWLIST:
                    Console.WriteLine(string.Format("Memory Import WM_SHOWLIST - {0}", m.LParam));
                    SetDIList();
                    break;

                case Module1.WM_DI_START:
                    // When data in memory exists,
                    Console.WriteLine("Memory Import WM_DI_START =======================");
                    break;
                case Module1.WM_DI_OK:
                    Console.WriteLine("Memory Import WM_DI_OK =======================");
                    break;

                case Module1.WM_DI_FAIL:
                    Console.WriteLine("Memory Import WM_DI_FAIL =======================");
                    break;

                case Module1.WM_DI_REMOVEOK:
                    Console.WriteLine(string.Format("Memory ImportWM_DI_REMOVEOK - folder : {0}, file : {1}", m.WParam, m.LParam));
                    break;

                case Module1.WM_DI_ACC:
                    Console.WriteLine("Memory Import WM_DI_ACC =======================");
                    break;
                // for smart pen 2
                // Sensor is lifted for changing paper. you should create new page.
                //	case Module1.WM_DI_CHANGE_STATION:
                //	Console.WriteLine("Memory Import WM_DI_CHANGE_STATION =======================");
                //break;
                // for smart marker
                // station is changed

                //PenStateTimerStop()
                case Module1.WM_DI_PAGE_NUM:
                    int nDIPaperSize = (int)m.LParam; //Paper Size
                    Console.WriteLine("WM_DI_PAGE_NUM ==>{0}", nDIPaperSize);
                    Rectangle rect = GetWorkAreaRect(nDIPaperSize);
                    Module1.SetCalibration_Top(rect.Left, rect.Top);
                    Module1.SetCalibration_Bottom(rect.Right, rect.Bottom);
                    Module1.SetCalibration_End();
                    break;

                //nMakePage = 1
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion

        private void pbclose_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.firebase_upload == false && Properties.Settings.Default.firebase_download == false)
            {
                con.Close();
                Environment.Exit(0);
            }
            else
            {
                ((Label)message1.Controls["lbmessage"]).Text = "Data is Synchronizing Please wait";
                message1.Visible = true;
            }
        }

        private void pbclose_MouseHover(object sender, EventArgs e)
        {
            pbclose.Image = Properties.Resources.colorclose;
        }

        private void pbclose_MouseLeave(object sender, EventArgs e)
        {
            pbclose.Image = Properties.Resources._close;
        }

        private void pbminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbminimize_MouseHover(object sender, EventArgs e)
        {
            pbminimize.Image = Properties.Resources.colorminize;
        }

        private void pbminimize_MouseLeave(object sender, EventArgs e)
        {
            pbminimize.Image = Properties.Resources._minimize;
        }

        void reportCLick()
        {
            btnreports.BackColor = selectcolor;
            panel_sidebar.Height = btnreports.Height;
            panel_sidebar.Top = btnreports.Top;

            btnpatients.BackColor = backcolor;
            btnmanagappointment.BackColor = backcolor;
            btnmanagvaccination.BackColor = backcolor;
            btnpayment.BackColor = backcolor;
            btnprofile.BackColor = backcolor;

            profile1.Visible = false;
            payment1.Visible = false;
            appointment1.Visible = false;
            vaccination1.Visible = false;
            patient1.Visible = false;
            report1.Visible = true;

            if (tbmastersearch.Text == "")
            {
                tbmastersearch.Text = "Search";
                tbmastersearch.ForeColor = Color.DarkGray;
            }

            this.Opacity = 1;
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            reportCLick();
        }

        private void btnreports_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnreports.Top)
            {
                btnreports.BackColor = highlightcolor;
            }
        }

        private void btnreports_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnreports.Top)
            {
                btnreports.BackColor = backcolor;
            }
        }

        private void lbreports_Click(object sender, EventArgs e)
        {
            reportCLick();
        }

        private void lbreports_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnreports.Top)
            {
                btnreports.BackColor = highlightcolor;
            }
        }

        private void lbreports_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnreports.Top)
            {
                btnreports.BackColor = backcolor;
            }
        }

        private void pbreports_Click(object sender, EventArgs e)
        {
            reportCLick();
        }

        private void pbreports_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnreports.Top)
            {
                btnreports.BackColor = highlightcolor;
            }
        }

        private void pbreports_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnreports.Top)
            {
                btnreports.BackColor = backcolor;
            }
        }

        void patientClick()
        {
            btnpatients.BackColor = selectcolor;
            panel_sidebar.Height = btnpatients.Height;
            panel_sidebar.Top = btnpatients.Top;

            btnreports.BackColor = backcolor;
            btnmanagappointment.BackColor = backcolor;
            btnmanagvaccination.BackColor = backcolor;
            btnpayment.BackColor = backcolor;
            btnprofile.BackColor = backcolor;

            profile1.Visible = false;
            payment1.Visible = false;
            appointment1.Visible = false;
            vaccination1.Visible = false;
            patient1.Visible = true;
            report1.Visible = false;

            if (tbmastersearch.Text == "")
            {
                tbmastersearch.Text = "Search";
                tbmastersearch.ForeColor = Color.DarkGray;
            }

            this.Opacity = 1;
        }

        private void btnpatients_Click(object sender, EventArgs e)
        {
            patientClick();
        }

        private void btnpatients_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpatients.Top)
            {
                btnpatients.BackColor = highlightcolor;
            }
        }

        private void btnpatients_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpatients.Top)
            {
                btnpatients.BackColor = backcolor;
            }
        }

        private void lbpatients_Click(object sender, EventArgs e)
        {
            patientClick();
        }

        private void lbpatients_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpatients.Top)
            {
                btnpatients.BackColor = highlightcolor;
            }
        }

        private void lbpatients_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpatients.Top)
            {
                btnpatients.BackColor = backcolor;
            }
        }

        private void pbpatients_Click(object sender, EventArgs e)
        {
            patientClick();
        }

        private void pbpatients_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpatients.Top)
            {
                btnpatients.BackColor = highlightcolor;
            }
        }

        private void pbpatients_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpatients.Top)
            {
                btnpatients.BackColor = backcolor;
            }
        }

        void appointmentClick()
        {
            btnmanagappointment.BackColor = selectcolor;
            panel_sidebar.Height = btnmanagappointment.Height;
            panel_sidebar.Top = btnmanagappointment.Top;

            btnreports.BackColor = backcolor;
            btnpatients.BackColor = backcolor;
            btnmanagvaccination.BackColor = backcolor;
            btnpayment.BackColor = backcolor;
            btnprofile.BackColor = backcolor;

            profile1.Visible = false;
            payment1.Visible = false;
            appointment1.Visible = true;
            vaccination1.Visible = false;
            patient1.Visible = false;
            report1.Visible = false;

            if (tbmastersearch.Text == "")
            {                
                tbmastersearch.Text = "Search";
                tbmastersearch.ForeColor = Color.DarkGray;
            }

            this.Opacity = 1;
        }

        private void btnmanagappointment_Click(object sender, EventArgs e)
        {
            appointmentClick();
        }

        private void btnmanagappointment_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagappointment.Top)
            {
                btnmanagappointment.BackColor = highlightcolor;
            }
        }

        private void btnmanagappointment_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagappointment.Top)
            {
                btnmanagappointment.BackColor = backcolor;
            }
        }

        private void lbmanagappointment_Click(object sender, EventArgs e)
        {
            appointmentClick();
        }

        private void lbmanagappointment_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagappointment.Top)
            {
                btnmanagappointment.BackColor = highlightcolor;
            }
        }

        private void lbmanagappointment_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagappointment.Top)
            {
                btnmanagappointment.BackColor = backcolor;
            }
        }

        private void pbmanagappoiment_Click(object sender, EventArgs e)
        {
            appointmentClick();
        }

        private void pbmanagappoiment_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagappointment.Top)
            {
                btnmanagappointment.BackColor = highlightcolor;
            }
        }

        private void pbmanagappoiment_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagappointment.Top)
            {
                btnmanagappointment.BackColor = backcolor;
            }
        }

        void vaccicationClick()
        {
            btnmanagvaccination.BackColor = selectcolor;
            panel_sidebar.Height = btnmanagvaccination.Height;
            panel_sidebar.Top = btnmanagvaccination.Top;

            btnpatients.BackColor = backcolor;
            btnmanagappointment.BackColor = backcolor;
            btnreports.BackColor = backcolor;
            btnpayment.BackColor = backcolor;
            btnprofile.BackColor = backcolor;

            profile1.Visible = false;
            payment1.Visible = false;
            appointment1.Visible = false;
            vaccination1.Visible = true;
            patient1.Visible = false;
            report1.Visible = false;

            if (tbmastersearch.Text == "")
            {
                tbmastersearch.Text = "Search";
                tbmastersearch.ForeColor = Color.DarkGray;
            }

            this.Opacity = 1;
        }

        private void btnmanagvaccination_Click(object sender, EventArgs e)
        {
            vaccicationClick();
        }

        private void btnmanagvaccination_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagvaccination.Top)
            {
                btnmanagvaccination.BackColor = highlightcolor;
            }
        }

        private void btnmanagvaccination_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagvaccination.Top)
            {
                btnmanagvaccination.BackColor = backcolor;
            }
        }

        private void lbmanagvaccination_Click(object sender, EventArgs e)
        {
            vaccicationClick();
        }

        private void lbmanagvaccination_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagvaccination.Top)
            {
                btnmanagvaccination.BackColor = highlightcolor;
            }
        }

        private void lbmanagvaccination_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagvaccination.Top)
            {
                btnmanagvaccination.BackColor = backcolor;
            }
        }

        private void pbmanagvaccinations_Click(object sender, EventArgs e)
        {
            vaccicationClick();
        }

        private void pbmanagvaccinations_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagvaccination.Top)
            {
                btnmanagvaccination.BackColor = highlightcolor;
            }
        }

        private void pbmanagvaccinations_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnmanagvaccination.Top)
            {
                btnmanagvaccination.BackColor = backcolor;
            }
        }

        void paymentClick()
        {
            btnpayment.BackColor = selectcolor;
            panel_sidebar.Height = btnpayment.Height;
            panel_sidebar.Top = btnpayment.Top;

            btnpatients.BackColor = backcolor;
            btnmanagappointment.BackColor = backcolor;
            btnreports.BackColor = backcolor;
            btnmanagvaccination.BackColor = backcolor;
            btnprofile.BackColor = backcolor;

            profile1.Visible = false;
            payment1.Visible = true;
            appointment1.Visible = false;
            vaccination1.Visible = false;
            patient1.Visible = false;
            report1.Visible = false;

            if (tbmastersearch.Text == "")
            {
                tbmastersearch.Text = "Search";
                tbmastersearch.ForeColor = Color.DarkGray;
            }

            this.Opacity = 1;
        }

        private void btnpayment_Click(object sender, EventArgs e)
        {
            paymentClick();
        }

        private void btnpayment_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpayment.Top)
            {
                btnpayment.BackColor = highlightcolor;
            }
        }

        private void btnpayment_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpayment.Top)
            {
                btnpayment.BackColor = backcolor;
            }
        }

        private void lbpayment_Click(object sender, EventArgs e)
        {
            paymentClick();
        }

        private void lbpayment_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpayment.Top)
            {
                btnpayment.BackColor = highlightcolor;
            }
        }

        private void lbpayment_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpayment.Top)
            {
                btnpayment.BackColor = backcolor;
            }
        }

        private void pbpayment_Click(object sender, EventArgs e)
        {
            paymentClick();
        }

        private void pbpayment_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpayment.Top)
            {
                btnpayment.BackColor = highlightcolor;
            }
        }

        private void pbpayment_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnpayment.Top)
            {
                btnpayment.BackColor = backcolor;
            }
        }

        void profileClick()
        {
            btnprofile.BackColor = selectcolor;
            panel_sidebar.Height = btnprofile.Height;
            panel_sidebar.Top = btnprofile.Top;

            btnpatients.BackColor = backcolor;
            btnmanagappointment.BackColor = backcolor;
            btnreports.BackColor = backcolor;
            btnmanagvaccination.BackColor = backcolor;
            btnpayment.BackColor = backcolor;

            profile1.Visible = true;
            payment1.Visible = false;
            appointment1.Visible = false;
            vaccination1.Visible = false;
            patient1.Visible = false;
            report1.Visible = false;

            if (tbmastersearch.Text == "")
            {
                tbmastersearch.Text = "Search";
                tbmastersearch.ForeColor = Color.DarkGray;
            }

            this.Opacity = 1;
        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
            profileClick();
        }

        private void btnprofile_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnprofile.Top)
            {
                btnprofile.BackColor = highlightcolor;
            }
        }

        private void btnprofile_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnprofile.Top)
            {
                btnprofile.BackColor = backcolor;
            }
        }

        private void lbprofile_Click(object sender, EventArgs e)
        {
            profileClick();
        }

        private void lbprofile_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnprofile.Top)
            {
                btnprofile.BackColor = highlightcolor;
            }
        }

        private void lbprofile_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnprofile.Top)
            {
                btnprofile.BackColor = backcolor;
            }
        }

        private void pbprofile_Click(object sender, EventArgs e)
        {
            profileClick();
        }

        private void pbprofile_MouseHover(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnprofile.Top)
            {
                btnprofile.BackColor = highlightcolor;
            }
        }

        private void pbprofile_MouseLeave(object sender, EventArgs e)
        {
            if (panel_sidebar.Top != btnprofile.Top)
            {
                btnprofile.BackColor = backcolor;
            }
        }

        private void tbmastersearch_Click(object sender, EventArgs e)
        {
            if (tbmastersearch.Text == "Search")
                tbmastersearch.Text = "";
            lbhintmastersearch.Visible = false;
        }

        private void tbmastersearch_TextChanged(object sender, EventArgs e)
        {
            tbmastersearch.ForeColor = Color.Black;
            lbhintmastersearch.Visible = false;
        }

        private void tbmastersearch_Leave(object sender, EventArgs e)
        {
            if(tbmastersearch.Text == "")
            {
                tbmastersearch.Text = "Search";
                tbmastersearch.ForeColor = Color.DarkGray;
            }
            lbhintmastersearch.Visible = false;
        }

        private void tbmastersearch_MouseHover(object sender, EventArgs e)
        {
            lbhintmastersearch.Visible = true;
        }

        private void tbmastersearch_MouseLeave(object sender, EventArgs e)
        {
            lbhintmastersearch.Visible = false;
        }

        private void pbmastersearch_MouseHover(object sender, EventArgs e)
        {
            pbmastersearch.BackColor = Color.FromArgb(245,245,245);
        }

        private void pbmastersearch_MouseLeave(object sender, EventArgs e)
        {
            pbmastersearch.BackColor = Color.FromArgb(250,250,250);
        }

        private void pbfeedback_MouseHover(object sender, EventArgs e)
        {
            lbhintfeedback.Visible = true;
        }

        private void pbfeedback_MouseLeave(object sender, EventArgs e)
        {
            lbhintfeedback.Visible = false;
        }

        private void pbhelp_MouseHover(object sender, EventArgs e)
        {
            lbhinthelp.Visible = true;
        }

        private void pbhelp_MouseLeave(object sender, EventArgs e)
        {
            lbhinthelp.Visible = false;
        }

        private void panelpenbattery_MouseHover(object sender, EventArgs e)
        {
            lbhintbattery.Visible = true;
        }

        private void panelpenbattery_MouseLeave(object sender, EventArgs e)
        {
            lbhintbattery.Visible = false;
        }

        private void panelpowerbar_MouseHover(object sender, EventArgs e)
        {
            lbhintpower.Visible = true;
        }

        private void panelpowerbar_MouseLeave(object sender, EventArgs e)
        {
            lbhintpower.Visible = false;
        }

        private void panelConnect_MouseHover(object sender, EventArgs e)
        {
            lbhintpower.Visible = true;
        }

        private void panelConnect_MouseLeave(object sender, EventArgs e)
        {
            lbhintpower.Visible = false;
        }

        private void btnaddnewpatient_Click(object sender, EventArgs e)
        {
            patientClick();
            patient1.Write = true;
            patient1.NewPatient.PerformClick();
        }

        private void pbdrawing_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 1;
            pbdrawing.Visible = false;
        }

        private void message1_VisibleChanged(object sender, EventArgs e)
        {
            if (message1.Visible == true)
                this.Opacity = 0.92;
        }

        private void message1_Leave(object sender, EventArgs e)
        {
            message1.Visible = false;
            this.Opacity = 1;
        }

        private void pbmastersearch_Click(object sender, EventArgs e)
        {
            if (tbmastersearch.Text.All(char.IsDigit))
            {
                foreach (Control control in ((Panel)this.patient1.Controls["panel_search"]).Controls)
                {
                    if (control.GetType() == typeof(MaterialSkin.Controls.MaterialSingleLineTextField))
                    {
                        if (control.Name == "tbsearchmobile")
                            control.Text = tbmastersearch.Text;
                    }
                }
            }
            else
            {
                foreach (Control control in ((Panel)this.patient1.Controls["panel_search"]).Controls)
                {
                    if (control.GetType() == typeof(MaterialSkin.Controls.MaterialSingleLineTextField))
                    {
                        if (control.Name == "tbsearchpatientname")
                            control.Text = tbmastersearch.Text;
                    }
                }
            }
            this.patient1.searchData();
            patientClick();
        }

        private void tbmastersearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbmastersearch.Text.All(char.IsDigit))
                {
                    foreach (Control control in ((Panel)this.patient1.Controls["panel_search"]).Controls)
                    {
                        if (control.GetType() == typeof(MaterialSkin.Controls.MaterialSingleLineTextField))
                        {
                            if (control.Name == "tbsearchmobile")
                                control.Text = tbmastersearch.Text;
                        }
                    }
                }
                else
                {
                    foreach(Control control in ((Panel)this.patient1.Controls["panel_search"]).Controls)
                    {
                        if(control.GetType() == typeof(MaterialSkin.Controls.MaterialSingleLineTextField))
                        {
                            if (control.Name == "tbsearchpatientname")
                                control.Text = tbmastersearch.Text;
                        }
                    }
                }
                this.patient1.searchData();
                patientClick();
            }
        }
    }
}