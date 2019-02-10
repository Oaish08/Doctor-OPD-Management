using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Doctor
{
    public partial class profile : UserControl
    {
        PrivateFontCollection pfc = new PrivateFontCollection();
        public profile()
        {
            InitializeComponent();

            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            lbpersonalinformation.Font = new Font(pfc.Families[0], 22);
            lbsecurity.Font = new Font(pfc.Families[0], 22);
            lbname.Font = new Font(pfc.Families[0], 14);
            lbnumber.Font = new Font(pfc.Families[0], 14);
            lbDOB.Font = new Font(pfc.Families[0], 14);
            lbemailaddress.Font = new Font(pfc.Families[0], 14);
            lbclinicaddress.Font = new Font(pfc.Families[0], 14);
            lbspeciality.Font = new Font(pfc.Families[0], 14);
            lbdegree.Font = new Font(pfc.Families[0], 14);
            lbpassword.Font = new Font(pfc.Families[0], 14);
            lbconfirmpassword.Font = new Font(pfc.Families[0], 14);

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pbdoctor.Width, pbdoctor.Height);
            pbdoctor.Region = new Region(path);
        }

        private void profile_Load(object sender, EventArgs e)
        {
            lbdoctorname.Text = Properties.Settings.Default.firstName + " " + Properties.Settings.Default.lastName;
            lbdoctorcontactnumber.Text = Properties.Settings.Default.mobile;
            tbemailaddress.Text = Properties.Settings.Default.email;
            tbDOB.Text = Properties.Settings.Default.DOB;
            tbclinicaddress.Text = Properties.Settings.Default.clinicAddress;
            tbspeciality.Text = Properties.Settings.Default.speciality;
            tbdegree.Text = Properties.Settings.Default.degree;
            if(File.Exists(Properties.Settings.Default.profilePicture))
                pbdoctor.Image = Image.FromFile(Properties.Settings.Default.profilePicture);
        }

        private void profile_Paint(object sender, PaintEventArgs e)
        {
            tbemailaddress.BorderStyle = BorderStyle.None;
            tbDOB.BorderStyle = BorderStyle.None;
            tbclinicaddress.BorderStyle = BorderStyle.None;
            tbspeciality.BorderStyle = BorderStyle.None;
            tbdegree.BorderStyle = BorderStyle.None;
            tbpassword.BorderStyle = BorderStyle.None;
            tbconfirmpassword.BorderStyle = BorderStyle.None;

            Pen p = new Pen(Color.LightGray);
            Graphics g = e.Graphics;
            int variance = 3;

            g.DrawRectangle(p, new Rectangle(tbemailaddress.Location.X - variance, tbemailaddress.Location.Y - variance, tbemailaddress.Width + variance, tbemailaddress.Height + variance));
            g.DrawRectangle(p, new Rectangle(tbDOB.Location.X - variance, tbDOB.Location.Y - variance, tbDOB.Width + variance, tbDOB.Height + variance));
            g.DrawRectangle(p, new Rectangle(tbclinicaddress.Location.X - variance, tbclinicaddress.Location.Y - variance, tbclinicaddress.Width + variance, tbclinicaddress.Height + variance));
            g.DrawRectangle(p, new Rectangle(tbspeciality.Location.X - variance, tbspeciality.Location.Y - variance, tbspeciality.Width + variance, tbspeciality.Height + variance));
            g.DrawRectangle(p, new Rectangle(tbdegree.Location.X - variance, tbdegree.Location.Y - variance, tbdegree.Width + variance, tbdegree.Height + variance));
            g.DrawRectangle(p, new Rectangle(tbpassword.Location.X - variance, tbpassword.Location.Y - variance, tbpassword.Width + variance, tbpassword.Height + variance));
            g.DrawRectangle(p, new Rectangle(tbconfirmpassword.Location.X - variance, tbconfirmpassword.Location.Y - variance, tbconfirmpassword.Width + variance, tbconfirmpassword.Height + variance));
        }

        private void tbDOB_Leave(object sender, EventArgs e)
        {
            if (tbDOB.Text == "")
                tbDOB.Text = "dd-mm-yyyy";
        }

        private void tbemailaddress_Leave(object sender, EventArgs e)
        {
            if (tbemailaddress.Text == "")
                tbemailaddress.Text = "email address";
        }

        private void tbclinicaddress_Leave(object sender, EventArgs e)
        {
            if (tbclinicaddress.Text == "")
                tbclinicaddress.Text = "clinic address";
        }

        private void tbspeciality_Leave(object sender, EventArgs e)
        {
            if (tbspeciality.Text == "")
                tbspeciality.Text = "speciality";
        }

        private void tbdegree_Leave(object sender, EventArgs e)
        {
            if (tbdegree.Text == "")
                tbdegree.Text = "degree";
        }

        private void tbpassword_Leave(object sender, EventArgs e)
        {
            if (tbpassword.Text == "")
            {
                tbpassword.PasswordChar = '\0';
                tbpassword.Text = "password";
            }
            lberrorpassword.Visible = false;
        }

        private void tbconfirmpassword_Leave(object sender, EventArgs e)
        {
            if (tbconfirmpassword.Text == "")
            {
                tbconfirmpassword.PasswordChar = '\0';
                tbconfirmpassword.Text = "confirm password";
            }
            lberrorpassword.Visible = false;
        }

        private void btnsave_MouseHover(object sender, EventArgs e)
        {
            btnsave.BackgroundImage = Properties.Resources.highlightsave;
        }

        private void btnsave_MouseLeave(object sender, EventArgs e)
        {
            btnsave.BackgroundImage = Properties.Resources.save1;        
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string dob = tbDOB.Text;
            string email = tbemailaddress.Text;
            string clinicsddress = tbclinicaddress.Text;
            string speciality = tbspeciality.Text;
            string degree = tbspeciality.Text;

            if (dob != Properties.Settings.Default.DOB || email != Properties.Settings.Default.email || clinicsddress != Properties.Settings.Default.clinicAddress || speciality != Properties.Settings.Default.speciality || degree != Properties.Settings.Default.degree)
            {
                Properties.Settings.Default.DOB =  dob;
                Properties.Settings.Default.email = email;
                Properties.Settings.Default.clinicAddress = clinicsddress;
                Properties.Settings.Default.speciality = speciality;
                Properties.Settings.Default.degree = degree;
                Properties.Settings.Default.Save();
                btnsave.BackgroundImage = Properties.Resources.savedone;
            }
            else
            {
                btnsave.BackgroundImage = Properties.Resources.savedone;
            }
        }

        private void btnsavepassword_MouseHover(object sender, EventArgs e)
        {
            btnsavepassword.BackgroundImage = Properties.Resources.highlightsave;
        }

        private void btnsavepassword_MouseLeave(object sender, EventArgs e)
        {
            btnsavepassword.BackgroundImage = Properties.Resources.save1;
        }

        private void btnsavepassword_Click(object sender, EventArgs e)
        {
            if(tbpassword.Text != "password" & tbconfirmpassword.Text != "confirm password")
            {
                if (tbpassword.Text.Length >= 6)
                {
                    if (tbpassword.Text == tbconfirmpassword.Text)
                    {
                        Properties.Settings.Default.authentication = true;
                        Properties.Settings.Default.password = tbconfirmpassword.Text;
                        Properties.Settings.Default.Save();
                        btnsavepassword.BackgroundImage = Properties.Resources.savedone;
                    }
                    else
                    {
                        lberrorpassword.Visible = true;
                        lberrorpassword.Text = "Password does not match";
                    }
                }
                else
                {
                    lberrorpassword.Visible = true;
                    lberrorpassword.Text = "Password length too short";
                }
            }
            else
            {
                lberrorpassword.Visible = true;
                lberrorpassword.Text = "Write something else";
            }
        }

        private void tbpassword_Click(object sender, EventArgs e)
        {
            if (tbpassword.Text == "password")
                tbpassword.Text = "";
            lberrorpassword.Visible = false;
            tbpassword.PasswordChar = '*';
        }

        private void tbpassword_TextChanged(object sender, EventArgs e)
        {
            lberrorpassword.Visible = false;
            if (tbpassword.Text == "password")
                tbpassword.PasswordChar = '\0';
            else
                tbpassword.PasswordChar = '*';
        }

        private void tbconfirmpassword_Click(object sender, EventArgs e)
        {
            if (tbconfirmpassword.Text == "confirm password")
                tbconfirmpassword.Text = "";
            lberrorpassword.Visible = false;
            tbconfirmpassword.PasswordChar = '*';
        }

        private void tbconfirmpassword_TextChanged(object sender, EventArgs e)
        {
            lberrorpassword.Visible = false;
            if (tbconfirmpassword.Text == "confirm password")
                tbconfirmpassword.PasswordChar = '\0';
            else
                tbconfirmpassword.PasswordChar = '*';
        }

        private void pbviewpassword_MouseHover(object sender, EventArgs e)
        {
            if (tbpassword.Text != "password")
            {
                tbpassword.PasswordChar = '\0';
                pbviewpassword.Image = Properties.Resources.show;
            }

        }

        private void pbviewpassword_MouseLeave(object sender, EventArgs e)
        {
            if (tbpassword.Text != "password")
            {
                tbpassword.PasswordChar = '*';
                pbviewpassword.Image = Properties.Resources.hide;
            }
        }

        private void pbviewconfirmpassword_MouseHover(object sender, EventArgs e)
        {
            if (tbconfirmpassword.Text != "confirm password")
            {
                tbconfirmpassword.PasswordChar = '\0';
                pbviewconfirmpassword.Image = Properties.Resources.show;
            }
        }

        private void pbviewconfirmpassword_MouseLeave(object sender, EventArgs e)
        {
            if (tbconfirmpassword.Text != "confirm password")
            {
                tbconfirmpassword.PasswordChar = '*';
                pbviewconfirmpassword.Image = Properties.Resources.hide;
            }
        }

        private void pbdoctor_MouseHover(object sender, EventArgs e)
        {
            btnedit.Visible = true;
        }

        private void pbdoctor_MouseLeave(object sender, EventArgs e){}

        private void pbdoctor_MouseMove(object sender, MouseEventArgs e){}

        private void btnsavepassword_Paint(object sender, PaintEventArgs e){}

        private void pbdoctor_Click(object sender, EventArgs e){}

        private void btnedit_MouseHover(object sender, EventArgs e)
        {
            btnedit.Visible = true;
        }

        private void btnedit_MouseLeave(object sender, EventArgs e)
        {
            btnedit.Visible = false;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse Profile Picure";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "JPEG Files (*.jpg*)|*.jpg|PNG Files (*.png*)|*.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbdoctor.Image = Image.FromFile(openFileDialog1.FileName);
                Properties.Settings.Default.profilePicture = openFileDialog1.FileName;
                Properties.Settings.Default.Save();
            }
        }
    }
}