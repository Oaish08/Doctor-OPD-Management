using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class Password_Form : Form
    {
        bool forgetpassword = false;
        bool back = false;
        bool getpassword = false;
        bool resendpassword = false;

        string sentPassword = string.Empty;

        public Password_Form()
        {
            Thread splash = new Thread(new ThreadStart(StartForm));
            splash.Start();
            Thread.Sleep(2000);
            splash.Abort();
            InitializeComponent();
            this.Size = new Size(280, 440);
        }

        public void StartForm()
        {
            Application.Run(new Splash_Form());
        }

        private void Password_Form_Load(object sender, EventArgs e)
        {
            timer_tochange.Start();
        }

        private void timer_tochange_Tick_1(object sender, EventArgs e)
        {
            timer_tochange.Interval = 5;
            if (forgetpassword == true)
            {
                credential();
            }
            else if (back == true)
            {
                credentialTOreg();
            }
            else if (getpassword == true)
            {
                setpassword();
            }
            else if (resendpassword == true)
            {
                setpasswordTocredential();
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
            if (panel_password.Left > 0)
            {
                panel_flash.Left -= move_speed;
                panel_password.Left -= move_speed;
                if (panel_password.Left == 0)
                {
                    timer_tochange.Stop();
                }
            }
        }

        void credential()
        {
            if (panel_credential.Left > 0)
            {
                panel_credential.Left -= move_speed;
                if (panel_credential.Left == 0)
                {
                    pbback.Visible = true;
                    timer_tochange.Stop();
                    forgetpassword = false;
                }
            }
        }

        void credentialTOreg()
        {
            if (panel_password.Left == 0)
            {
                panel_credential.Left += move_speed;
                if (panel_credential.Left < 0)
                {
                    timer_tochange.Stop();
                    back = false;
                }
            }
        }

        void setpassword()
        {
            if (panel_getpassword.Left > 0)
            {
                panel_credential.Left -= move_speed;
                panel_getpassword.Left -= move_speed;
                if (panel_getpassword.Left == 0)
                {
                    timer_tochange.Stop();
                    getpassword = false;
                }
            }
        }

        void setpasswordTocredential()
        {
            if (panel_credential.Left < 0)
            {
                panel_getpassword.Left += move_speed;
                panel_credential.Left += move_speed;
                if (panel_credential.Left == 0)
                {
                    timer_tochange.Stop();
                    resendpassword = false;
                }
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

        private void tbpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbpassword.Text == Properties.Settings.Default.password)
                {
                    this.Hide();
                    User_Form obj = new User_Form();
                    obj.Show();
                }
                else
                {
                    lberrorPassword.Text = "Password doesn't match";
                    lberrorPassword.Visible = true;
                }
            }
        }

        private void pbpassword_Click(object sender, EventArgs e)
        {
            if (tbpassword.Text == Properties.Settings.Default.password)
            {
                this.Hide();
                User_Form obj = new User_Form();
                obj.Show();
            }
            else
            {
                lberrorPassword.Text = "Password doesn't match";
                lberrorPassword.Visible = true;
            }
        }

        private void pbpassword_MouseHover(object sender, EventArgs e)
        {
            pbpassword.Image = Properties.Resources.login1_0;
        }

        private void pbpassword_MouseLeave(object sender, EventArgs e)
        {
            pbpassword.Image = Properties.Resources.login2_0;
        }

        private void tbpassword_TextChanged(object sender, EventArgs e)
        {
            lberrorPassword.Visible = false;
            if (tbpassword.Text == "Password")
                tbpassword.PasswordChar = '\0';
            else
                tbpassword.PasswordChar = '*';
        }

        private void tbpassword_Click(object sender, EventArgs e)
        {
            if (tbpassword.Text == "Password")
                tbpassword.Text = "";
            lberrorPassword.Visible = false;
            tbpassword.PasswordChar = '*';
        }

        private void tbpassword_Leave(object sender, EventArgs e)
        {
            if (tbpassword.Text == "")
            {
                tbpassword.PasswordChar = '\0';
                tbpassword.Text = "Password";
            }
        }

        private void pbviewpassword_MouseHover(object sender, EventArgs e)
        {
            if (tbpassword.Text != "Password")
            {
                tbpassword.PasswordChar = '\0';
                pbviewpassword.Image = Properties.Resources.show;
            }
        }

        private void pbviewpassword_MouseLeave(object sender, EventArgs e)
        {
            if (tbpassword.Text != "Password")
            {
                tbpassword.PasswordChar = '*';
                pbviewpassword.Image = Properties.Resources.hide;
            }
        }

        private void lbforegetpassword_Click(object sender, EventArgs e)
        {
            forgetpassword = true;
            lbmobilecredential.Text = Properties.Settings.Default.mobile;
            tbemail.Text = Properties.Settings.Default.email;
            timer_tochange.Start();
        }

        private void lbforegetpassword_MouseHover(object sender, EventArgs e)
        {
            lbforegetpassword.ForeColor = Color.DarkCyan;
        }

        private void lbforegetpassword_MouseLeave(object sender, EventArgs e)
        {
            lbforegetpassword.ForeColor = Color.Black;
        }

        private void pbback_Click(object sender, EventArgs e)
        {
            back = true;
            pbback.Visible = false;
            timer_tochange.Start();
        }

        private void pbback_MouseHover(object sender, EventArgs e)
        {
            pbback.Image = Properties.Resources.colorback;
        }

        private void pbback_MouseLeave(object sender, EventArgs e)
        {
            pbback.Image = Properties.Resources.back;
        }

        private void tbemail_TextChanged(object sender, EventArgs e)
        {
            lberrorcredential.Visible = false;
        }

        private void tbemail_Click(object sender, EventArgs e)
        {
            if (tbemail.Text == "Email")
                tbemail.Text = "";
            lberrorcredential.Visible = false;
        }

        private void tbemail_Leave(object sender, EventArgs e)
        {
            if (tbemail.Text == "")
                tbemail.Text = "Email";
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

        private void pbsendpassword_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(tbemail.Text) == false)
            {
                lberrorcredential.Text = "Please enter correct email address";
                lberrorcredential.Visible = true;
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                lbforegetpassword.Visible = false;
                tbpassword.Visible = false;
                lberrorgetPassword.Visible = false;
                pbpassword.Visible = false;
                pbback.Visible = false;
                pictureBox1.Visible = false;
                pbviewpassword.Visible = false;
                back = false;
                forgetpassword = false;
                getpassword = true;
                lbmobilenumbersend.Text = "Password sent to " + lbmobilecredential.Text + "\n" + tbemail.Text;

                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
                sentPassword = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());


                if (tcpsocket() == true)
                {
                    sendMail();

                    sendMsg();

                    timer_tochange.Start();
                }
                else
                {
                    lbmobilenumbersend.Text = "Please check your Internet Connection";
                }
            }
        }

        public void sendMail()
        {
            try
            {
                MailMessage msg = new MailMessage();

                msg.From = new MailAddress("info@clinmd.com");
                msg.To.Add(tbemail.Text);
                msg.Subject = "Forget Password";
                msg.Body = "Hi Dr. " + Properties.Settings.Default.firstName + " " + Properties.Settings.Default.lastName + ",\n\n\t We have received a request for forget password from your CLINMD account associated with mobile number +91" + Properties.Settings.Default.mobile.Substring(0, 3) + "****" + Properties.Settings.Default.mobile.Substring(7, 3) + ".\n\n----- " + sentPassword + " ----- is new password for your CLINMD account.\nPlease change your password after login. PLEASE DO NOT SHARE IT WITH ANYONE(CLINMD OR OTHERWISE).\n\n\tIf you didn't ask for this change you can safely ignore this email. Your password won't change and your account and data is safe.\nRegard,\nTeam ClinMD";
                msg.Priority = MailPriority.High;

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("", "");// Use your own email service
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(msg);
                }
                Cursor.Current = Cursors.WaitCursor;//omiprince8@gmail.com
            }
            catch (SmtpException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void sendMsg()
        {
            string message = sentPassword + " is new password for your CLINMD account. Please change your password after login. PLEASE DO NOT SHARE IT WITH ANYONE(CLINMD OR OTHERWISE)";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("");//Use your own message service
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            request.Abort();
            Cursor.Current = Cursors.WaitCursor;
        }

        bool invalid = false;

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid email format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        private void pbsendpassword_MouseHover(object sender, EventArgs e)
        {
            pbsendpassword.Image = Properties.Resources.login1_0;
        }

        private void pbsendpassword_MouseLeave(object sender, EventArgs e)
        {
            pbsendpassword.Image = Properties.Resources.login2_0;
        }

        private void lbpasswordresend_Click(object sender, EventArgs e)
        {
            resendpassword = true;
            tbsetpassword.Text = "Password";
            timer_tochange.Start();
        }

        private void lbpasswordresend_MouseHover(object sender, EventArgs e)
        {
            lbpasswordresend.ForeColor = Color.DarkCyan;
        }

        private void lbpasswordresend_MouseLeave(object sender, EventArgs e)
        {
            lbpasswordresend.ForeColor = Color.Black;
        }

        private void tbsetpassword_TextChanged(object sender, EventArgs e)
        {
            lberrorgetPassword.Visible = false;
            if (tbsetpassword.Text == "Password")
                tbsetpassword.PasswordChar = '\0';
            else
                tbsetpassword.PasswordChar = '*';
        }

        private void tbsetpassword_Click(object sender, EventArgs e)
        {
            if (tbsetpassword.Text == "Password")
                tbsetpassword.Text = "";
            lberrorgetPassword.Visible = false;
            tbsetpassword.PasswordChar = '*';
        }

        private void tbsetpassword_Leave(object sender, EventArgs e)
        {
            if (tbsetpassword.Text == "")
            {
                tbsetpassword.PasswordChar = '\0';
                tbsetpassword.Text = "Password";
            }
        }

        private void pbviewresendpassword_MouseHover(object sender, EventArgs e)
        {
            if (tbsetpassword.Text != "Password")
            {
                tbsetpassword.PasswordChar = '\0';
                pbviewresendpassword.Image = Properties.Resources.show;
            }
        }

        private void pbviewresendpassword_MouseLeave(object sender, EventArgs e)
        {
            if (tbsetpassword.Text != "Password")
            {
                tbsetpassword.PasswordChar = '*';
                pbviewresendpassword.Image = Properties.Resources.hide;
            }
        }

        private void pbconfirmpassword_Click(object sender, EventArgs e)
        {
            if (tbsetpassword.Text == sentPassword)
            {
                Properties.Settings.Default.password = sentPassword;
                Properties.Settings.Default.Save();
                this.Hide();
                User_Form obj = new User_Form();
                obj.Show();
            }
            else
            {
                lberrorgetPassword.Text = "Please give password sent to your crendentials";
                lberrorgetPassword.Visible = true;
            }
        }

        private void pbconfirmpassword_MouseHover(object sender, EventArgs e)
        {
            pbconfirmpassword.Image = Properties.Resources.login1_0;
        }

        private void pbconfirmpassword_MouseLeave(object sender, EventArgs e)
        {
            pbconfirmpassword.Image = Properties.Resources.login2_0;
        }

        private void lbmobilecredential_Click(object sender, EventArgs e) { }

        private void lbmobilecredential_TextChanged(object sender, EventArgs e) { }

        private void lbmobilecredential_Leave(object sender, EventArgs e) { }
    }
}
