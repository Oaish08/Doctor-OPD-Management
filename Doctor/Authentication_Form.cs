using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MaterialSkin;
using System.IO;
using System.Diagnostics;

namespace Doctor
{
    public partial class Authentication_Form : Form
    {
        System.Timers.Timer otpTimer;
        int otptime = 120;
        bool sendOTP = false;
        bool resendOTP = false;
        bool setPIN = false;

        bool matchMobile = false;

        int otp_sent = 0;

        MaterialSkinManager skinManager;
        public Authentication_Form()
        {
            Thread splash = new Thread(new ThreadStart(StartForm));
            splash.Start();
            Thread.Sleep(2000);
            splash.Abort();
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.ColorScheme = new ColorScheme(Primary.Cyan600, Primary.Brown900, Primary.Cyan700, Accent.Cyan700, TextShade.WHITE);

            this.Size = new Size(280, 440);
        }

        public void StartForm()
        {
            Application.Run(new Splash_Form());
        }

        private void Authentication_Form_Load(object sender, EventArgs e)
        {
            timer_tochange.Start();
            otpTimer = new System.Timers.Timer();
            otpTimer.Elapsed += OnTimeElasped;
        }

        private void OnTimeElasped(object sender, ElapsedEventArgs e)
        {
            otpTimer.Interval = 1000;
            if (otptime >= 0)
            {
                Invoke(new Action(() =>
                {
                    lbotptime.Text = otptime.ToString();
                    if (otptime == 0)
                    {
                        otp_sent = 0;
                        lbotpexpire.Text = "Please try again";
                        lbotptime.Visible = false;
                        lbotpseconds.Visible = false;
                    }
                    otptime--;
                }));
            }
        }

        public bool tcpsocket()
        {
            try
            {
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("www.google.co.in", 80);
                client.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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

        private void timer_tochange_Tick(object sender, EventArgs e)
        {
            timer_tochange.Interval = 5;
            if (sendOTP == true)
            {
                otp();
            }
            else if (resendOTP == true)
            {
                otpTOreg();
            }
            else if (setPIN == true)
            {
                pin();
            }
            else
            {
                reg();
            }
        }

        //slide panel
        int move_speed = 20;
        void reg()
        {
            if (panel_getMobile.Left > 0)
            {
                panel_flash.Left -= move_speed;
                panel_getMobile.Left -= move_speed;
                if (panel_getMobile.Left == 0)
                {
                    timer_tochange.Stop();
                }
            }
        }

        void otp()
        {
            if (panel_otp.Left > 0)
            {
                panel_otp.Left -= move_speed;
                if (panel_otp.Left == 0)
                {
                    timer_tochange.Stop();
                    sendOTP = false;
                    otpTimer.Start();
                }
            }
        }

        void otpTOreg()
        {
            if (panel_getMobile.Left == 0)
            {
                panel_otp.Left += move_speed;
                if (panel_otp.Left < 0)
                {
                    timer_tochange.Stop();
                    resendOTP = false;
                }
            }
        }

        void pin()
        {
            if (panel_pin.Left > 0)
            {
                panel_otp.Left -= move_speed;
                panel_pin.Left -= move_speed;
                if (panel_pin.Left == 0)
                {
                    timer_tochange.Stop();
                    setPIN = false;
                }
            }
        }

        private void pbgetOTP_Click(object sender, EventArgs e)
        {
            if (tcpsocket() == true)
            {
                Cursor.Current = Cursors.WaitCursor;
                mobile_registered();
            }
            else
            {
                lberrorMobile.Text = "Check your Internet Connection";
                lberrorMobile.Visible = true;
            }
        }

        private void pbgetOTP_MouseHover(object sender, EventArgs e)
        {
            pbgetOTP.Image = Properties.Resources.login1_0;
        }

        private void pbgetOTP_MouseLeave(object sender, EventArgs e)
        {
            pbgetOTP.Image = Properties.Resources.login2_0;
        }

        private void tbmobile_Click(object sender, EventArgs e)
        {
            if (tbmobile.Text == "Mobile Number")
                tbmobile.Text = "";
            lberrorMobile.Visible = false;
        }

        private void tbmobile_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbmobile.Text))
                tbmobile.Text = "Mobile Number";
        }

        private void tbmobile_TextChanged(object sender, EventArgs e)
        {
            lberrorMobile.Visible = false;
        }

        private void tbmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbmobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tcpsocket() == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mobile_registered();
                }
                else
                {
                    lberrorMobile.Text = "Check your Internet Connection";
                    lberrorMobile.Visible = true;
                }
            }
        }

        public async Task mobile_registered()
        {
            int result = 0;
            var firebase = new FirebaseClient(Properties.Settings.Default.firebaseuri);
            var mobile = await firebase
                .Child("Doctors")
                .Child("Doctor Id")
                .OnceAsync<doctor>();
            foreach (var i in mobile)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (i.Object.phone == tbmobile.Text)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    result = 1;
                }
            }
            if (result == 1)
                matchMobile = true;
            else
                matchMobile = false;
            if (string.IsNullOrEmpty(tbmobile.Text) || tbmobile.Text.Length != 10 || !tbmobile.Text.All(char.IsDigit))
            {
                lberrorMobile.Text = "Please enter 10 digits Mobile Number";
                lberrorMobile.Visible = true;
            }
            else if (matchMobile == false)
            {
                lberrorMobile.Text = "Please enter registered Mobile Number";
                lberrorMobile.Visible = true;
            }
            else
            {
                lberrorMobile.Visible = false;
                Cursor.Current = Cursors.WaitCursor;
                Random num = new Random();
                otp_sent = num.Next(1001, 9999);
                string message = otp_sent + " is the otp code for your registration on CLINMD valid for 2 mins. PLEASE DO NOT SHARE IT WITH ANYONE(CLINMD OR OTHERWISE). ClinMD will never call to confirm your verification code";

                if (tcpsocket() == true)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("");//Use your own message service
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    request.Abort();
                    sendOTP = true;
                    timer_tochange.Start();
                    lbmobilenumber.Text = "OTP send to " + tbmobile.Text;
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    lberrorMobile.Text = "Check your Internet Connection";
                    lberrorMobile.Visible = true;
                }
            }
        }

        private void lbotpresend_MouseHover(object sender, EventArgs e)
        {
            lbotpresend.ForeColor = Color.DarkCyan;
        }

        private void lbotpresend_MouseLeave(object sender, EventArgs e)
        {
            lbotpresend.ForeColor = Color.Black;
        }

        private void lbotpresend_Click(object sender, EventArgs e)
        {
            otpTimer.Stop();
            tbotp.Text = "OTP";
            otptime = 120;
            lbotpexpire.Text = "OTP expires in ";
            lbotptime.Visible = true;
            lbotpseconds.Visible = true;
            resendOTP = true;
            timer_tochange.Start();
        }

        private void tbotp_Click(object sender, EventArgs e)
        {
            if (tbotp.Text == "OTP")
                tbotp.Text = "";
            lberrorOTP.Visible = false;
        }

        private void tbotp_TextChanged(object sender, EventArgs e)
        {
            lberrorOTP.Visible = false;
        }

        private void tbotp_Leave(object sender, EventArgs e)
        {
            if(tbotp.Text == "")
                tbotp.Text = "OTP";
            lberrorOTP.Visible = false;
        }

        private void tbotp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbotp.Text == otp_sent.ToString())
                {
                    tbmobile.Visible = false;
                    pictureBox1.Visible = false;
                    pbgetOTP.Visible = false;
                    sendOTP = false;
                    resendOTP = false;
                    setPIN = true;
                    timer_tochange.Start();
                    otpTimer.Stop();
                    otp_sent = 0;
                    lbotptime.Text = "120";
                }
                else
                {
                    lberrorOTP.Text = "Wrong OTP";
                    lberrorOTP.Visible = true;
                }
            }
        }

        private void pbconfirmotp_Click(object sender, EventArgs e)
        {
            if (tbotp.Text == otp_sent.ToString())
            {
                tbmobile.Visible = false;
                pictureBox1.Visible = false;
                pbgetOTP.Visible = false;
                sendOTP = false;
                resendOTP = false;
                setPIN = true;
                timer_tochange.Start();
                otpTimer.Stop();
                otp_sent = 0;
                lbotptime.Text = "120";
            }
            else
            {
                lberrorOTP.Text = "Wrong OTP";
                lberrorOTP.Visible = true;
            }
        }

        private void pbconfirmotp_MouseHover(object sender, EventArgs e)
        {
            pbconfirmotp.Image = Properties.Resources.login1_0;
        }

        private void pbconfirmotp_MouseLeave(object sender, EventArgs e)
        {
            pbconfirmotp.Image = Properties.Resources.login2_0;
        }

        private void tbconfirmpin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbpin.Text.Length >= 6)
                {
                    if (tbpin.Text == tbconfirmpin.Text)
                    {
                        if (tcpsocket() == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            saveDetails();
                        }
                        else
                            lberrorPIN.Text = "Please check your Internet Connection";
                    }
                    else
                    {
                        lberrorPIN.Visible = true;
                        lberrorPIN.Text = "Password does not match";
                    }
                }
                else
                {
                    lberrorPIN.Visible = true;
                    lberrorPIN.Text = "Password length too short";
                }
            }
        }

        private void pbpin_Click(object sender, EventArgs e)
        {
            if (tbpin.Text.Length >= 6)
            {
                if (tbpin.Text == tbconfirmpin.Text)
                {
                    if (tcpsocket() == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        saveDetails();
                    }
                    else
                        lberrorPIN.Text = "Please check your Internet Connection";
                }
                else
                {
                    lberrorPIN.Visible = true;
                    lberrorPIN.Text = "Password does not match";
                }
            }
            else
            {
                lberrorPIN.Visible = true;
                lberrorPIN.Text = "Password length too short";
            }
        }

        public async Task saveDetails()
        {
            try
            {
                if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName + @"\prescription.png"))
                {
                    File.Delete(@"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName + @"\prescription.png");
                }
                if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName + @"\propfile_picture.png"))
                {
                    File.Delete(@"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName + @"\propfile_picture.png");
                }
                var firebase = new FirebaseClient(Properties.Settings.Default.firebaseuri);
                var mobile = await firebase
                    .Child("Doctors")
                    .Child("Doctor Id")
                    .OnceAsync<doctor>();
                foreach (var i in mobile)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (i.Object.phone == tbmobile.Text)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Properties.Settings.Default.registrationID = i.Object.registrationID;
                        Properties.Settings.Default.firstName = i.Object.firstName;
                        Properties.Settings.Default.lastName = i.Object.lastName;
                        Properties.Settings.Default.email = i.Object.email;
                        Properties.Settings.Default.mobile = i.Object.phone;
                        Properties.Settings.Default.DOB = i.Object.DOB;
                        Properties.Settings.Default.clinicAddress = i.Object.clinicAddress;
                        Properties.Settings.Default.registrationYear = i.Object.registrationYear;
                        Properties.Settings.Default.degree = i.Object.degree;
                        Properties.Settings.Default.speciality = i.Object.speciality;
                        Properties.Settings.Default.Save();

                        if (!Directory.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName))
                            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName);

                        var prescription = await firebase
                            .Child("Doctors")
                            .Child(i.Object.registrationID)
                            .Child("Doctor Prescription Page")
                            .OnceAsync<doctor>();
                        foreach (var j in prescription)
                        {
                            if (!string.IsNullOrEmpty(j.Object.page_link))
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                WebClient myWebClient = new WebClient();
                                myWebClient.DownloadFile(j.Object.page_link, @"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName + @"\prescription.png");
                                Properties.Settings.Default.prescriptionPage = @"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName + @"\prescription.png";
                                Properties.Settings.Default.Save();
                            }
                        }
                        var profile = await firebase
                            .Child("Doctors")
                            .Child(i.Object.registrationID)
                            .Child("Doctor Profile Picture")
                            .OnceAsync<doctor>();
                        foreach (var j in profile)
                        {
                            if (!string.IsNullOrEmpty(j.Object.profile_link))
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                WebClient myWebClient = new WebClient();
                                myWebClient.DownloadFile(j.Object.profile_link, @"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName + @"\propfile_picture.png");
                                Properties.Settings.Default.profilePicture = @"C:\Users\" + Environment.UserName + @"\AppData\Local\" + Application.ProductName + @"\propfile_picture.png";
                                Properties.Settings.Default.Save();
                            }
                        }
                    }
                }
                Properties.Settings.Default.prescriptionLocation = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Doctor\Page\";
                Properties.Settings.Default.documentLocation = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Doctor\Document\";
                Properties.Settings.Default.authentication = true;
                Properties.Settings.Default.password = tbconfirmpin.Text;
                Properties.Settings.Default.Save();
                Cursor.Current = Cursors.Default;
                this.Hide();
                try
                {
                    User_Form obj = new User_Form();
                    obj.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbpin_MouseHover(object sender, EventArgs e)
        {
            pbpin.Image = Properties.Resources.login1_0;
        }

        private void pbpin_MouseLeave(object sender, EventArgs e)
        {
            pbpin.Image = Properties.Resources.login2_0;
        }

        private void tbpin_TextChanged(object sender, EventArgs e)
        {
            lberrorPIN.Visible = false;
            if (tbpin.Text == "Password")
                tbpin.PasswordChar = '\0';
            else
                tbpin.PasswordChar = '*';
        }

        private void tbconfirmpin_TextChanged(object sender, EventArgs e)
        {
            lberrorPIN.Visible = false;
            if (tbconfirmpin.Text == "Confirm Password")
                tbconfirmpin.PasswordChar = '\0';
            else
                tbconfirmpin.PasswordChar = '*';
        }

        private void tbpin_ChangeUICues(object sender, UICuesEventArgs e) { }

        private void tbpin_Click(object sender, EventArgs e)
        {
            if (tbpin.Text == "Password")
                tbpin.Text = "";
            lberrorPIN.Visible = false;
            tbpin.PasswordChar = '*';
        }

        private void tbconfirmpin_Click(object sender, EventArgs e)
        {
            if (tbconfirmpin.Text == "Confirm Password")
                tbconfirmpin.Text = "";
            lberrorPIN.Visible = false;
            tbconfirmpin.PasswordChar = '*';
        }

        private void tbpin_Leave(object sender, EventArgs e)
        {
            if (tbpin.Text == "")
            {
                tbpin.PasswordChar = '\0';
                tbpin.Text = "Password";
            }
        }

        private void tbconfirmpin_Leave(object sender, EventArgs e)
        {
            if (tbconfirmpin.Text == "")
            {
                tbconfirmpin.PasswordChar = '\0';
                tbconfirmpin.Text = "Confirm Password";
            }
        }

        private void pbviewpassword_MouseHover(object sender, EventArgs e)
        {
            if (tbpin.Text != "Password")
            {
                tbpin.PasswordChar = '\0';
                pbviewpassword.Image = Properties.Resources.show;
            }
        }

        private void pbviewpassword_MouseLeave(object sender, EventArgs e)
        {
            if (tbpin.Text != "Password")
            {
                tbpin.PasswordChar = '*';
                pbviewpassword.Image = Properties.Resources.hide;
            }
        }

        private void pbviewconfirmpassword_MouseHover(object sender, EventArgs e)
        {
            if (tbconfirmpin.Text != "Confirm Password")
            {
                tbconfirmpin.PasswordChar = '\0';
                pbviewconfirmpassword.Image = Properties.Resources.show;
            }
        }

        private void pbviewconfirmpassword_MouseLeave(object sender, EventArgs e)
        {
            if (tbconfirmpin.Text != "Confirm Password")
            {
                tbconfirmpin.PasswordChar = '*';
                pbviewconfirmpassword.Image = Properties.Resources.hide;
            }
        }
    }
}
