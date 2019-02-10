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
using System.Globalization;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Doctor
{
    public partial class newDocument : UserControl
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        PrivateFontCollection pfc = new PrivateFontCollection();
        public event EventHandler NewDocumentEvent;

        string gender = "NA";
        List<string> documentList = new List<string>();

        string tempID = string.Empty;

        string clinmdID = string.Empty;

        public string ClinmdID
        {
            get { return this.clinmdID; }
            set { this.clinmdID = value; }
        }

        public string TempID
        {
            get { return this.tempID; }
        }

        public string UGCID
        {
            get { return this.tbugcid.Text.ToUpper().Trim(); }
        }

        public string FirstName
        {
            get { return this.tbfirstname.Text.ToUpper().Trim(); }
        }

        public string LastName
        {
            get { return this.tblastname.Text.ToUpper().Trim(); }
        }

        public string Mobile
        {
            get { return this.tbmobilenumber.Text; }
        }

        public string Gender
        {
            get { return gender; }
        }

        public string Age
        {
            get { return this.tbage.Text; }
        }

        public string Date
        {
            get { return this.tbdate.Text; }
        }

        public List<string> Document
        {
            get { return documentList; }
        }

        public newDocument()
        {
            InitializeComponent();
            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);
            foreach (Control i in this.Controls)
            {
                if (i.GetType() == typeof(Label))
                {
                    i.Font = new Font(pfc.Families[0], 9);
                }
            }
            lbpatientdocument.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            lbpatientinformation.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);

            calenderdate.SetDate(DateTime.Now);
        }

        private void pbclose_MouseHover(object sender, EventArgs e)
        {
            pbclose.Image = Properties.Resources.colorclose;
        }

        private void pbclose_MouseLeave(object sender, EventArgs e)
        {
            pbclose.Image = Properties.Resources._close;
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void tbugcid_Click(object sender, EventArgs e)
        {
            if (tbugcid.Text == "UGC ID")
                tbugcid.Text = "";
            calenderdate.Visible = false;
            tbdate.Enabled = true;
            lberror.Visible = false;
        }

        private void tbugcid_Leave(object sender, EventArgs e)
        {
            if (tbugcid.Text == "")
                tbugcid.Text = "UGC ID";
        }

        private void tbfirstname_Click(object sender, EventArgs e)
        {
            if (tbfirstname.Text == "First Name")
                tbfirstname.Text = "";
            calenderdate.Visible = false;
            tbdate.Enabled = true;
            lberror.Visible = false;
        }

        private void tbfirstname_Leave(object sender, EventArgs e)
        {
            if (tbfirstname.Text == "")
                tbfirstname.Text = "First Name";
        }

        private void tblastname_Click(object sender, EventArgs e)
        {
            if (tblastname.Text == "Last Name")
                tblastname.Text = "";
            calenderdate.Visible = false;
            tbdate.Enabled = true;
            lberror.Visible = false;
        }

        private void tblastname_Leave(object sender, EventArgs e)
        {
            if (tblastname.Text == "")
                tblastname.Text = "Last Name";
        }

        private void tbage_Click(object sender, EventArgs e)
        {
            if (tbage.Text == "Age")
                tbage.Text = "";
            calenderdate.Visible = false;
            tbdate.Enabled = true;
            lberror.Visible = false;
        }

        private void tbage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbage_Leave(object sender, EventArgs e)
        {
            if (tbage.Text == "")
                tbage.Text = "Age";
        }

        private void tbmobilenumber_Click(object sender, EventArgs e)
        {
            if (tbmobilenumber.Text == "Number")
                tbmobilenumber.Text = "";
            calenderdate.Visible = false;
            tbdate.Enabled = true;
            lberror.Visible = false;
        }

        private void tbmobilenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbmobilenumber_Leave(object sender, EventArgs e)
        {
            if (tbmobilenumber.Text == "")
                tbmobilenumber.Text = "Number";
        }

        private void tbdate_Click(object sender, EventArgs e)
        {
            calenderdate.Visible = true;
            tbdate.Enabled = false;
            lberror.Visible = false;
        }

        private void tbdate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime checkDate = DateTime.ParseExact(tbdate.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                if (tbdate.Text != "Select Date")
                    calenderdate.Visible = true;
            }
        }

        private void tbdate_Leave(object sender, EventArgs e)
        {
            if (tbdate.Text == "")
                tbdate.Text = "Select Date";
        }

        private void calenderdate_DateSelected(object sender, DateRangeEventArgs e)
        {
            tbdate.Text = calenderdate.SelectionStart.ToString("dd-MMM-yyyy");
            calenderdate.Visible = false;
            tbdate.Enabled = true;
        }

        private void calenderdate_MouseLeave(object sender, EventArgs e)
        {
            calenderdate.Visible = false;
            tbdate.Enabled = true;
        }

        private void tbdocuments_Click(object sender, EventArgs e)
        {
            if(tbdocuments.Text == "Browse")
                tbdocuments.Text = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse Profile Picure";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (tbdocuments.Text == "Browse")
                    tbdocuments.Text = "";
                foreach (String file in openFileDialog1.FileNames)
                {
                    documentList.Add(file);
                    tbdocuments.Text += "\"" + file + "\"";
                }
                tbdocuments.Focus();
            }
        }

        private void tbdocuments_Leave(object sender, EventArgs e)
        {
            if (tbdocuments.Text == "")
                tbdocuments.Text = "Browse";
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse Profile Picure";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (tbdocuments.Text == "Browse")
                    tbdocuments.Text = "";
                foreach (String file in openFileDialog1.FileNames)
                {
                    Properties.Settings.Default.document += 1;
                    Properties.Settings.Default.Save();
                    string path = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Doctor\Document\Offline\";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    File.Copy(file, path + Properties.Settings.Default.document + Path.GetExtension(file));
                    documentList.Add(path + Properties.Settings.Default.document + Path.GetExtension(file));
                    tbdocuments.Text += "\"" + file + "\"";
                }
                tbdocuments.Focus();
            }
        }

        private void btnadddocument_Click(object sender, EventArgs e)
        {
            if (tbugcid.Text == "UGC ID")
                tbugcid.Text = "";
            if (tbfirstname.Text == "First Name")
                tbfirstname.Text = "";
            if (tblastname.Text == "Last Name")
                tblastname.Text = "";
            if (tbmobilenumber.Text == "Number")
                tbmobilenumber.Text = "";
            if (tbage.Text == "Age")
                tbage.Text = "";
            string personalInformation =  tbugcid.Text + tbfirstname.Text + tblastname.Text + tbmobilenumber.Text;
            if (personalInformation != "")
            {
                if (tbmobilenumber.Text.Length == 10 || tbmobilenumber.Text == "" || tbmobilenumber.Text == "NA")
                {
                    if (tbmobilenumber.Text == "")
                        tbmobilenumber.Text = "NA";
                    if (tbdate.Text == "Select Date")
                    {
                        lberror.Text = "* Date should be in 01-Jan-2000 format";
                        lberror.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            DateTime checkDate = DateTime.ParseExact(tbdate.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            if (tbdocuments.Text != "Browse" && tbdocuments.Text != "")
                            {
                                bool exists = false;
                                foreach(string document in documentList)
                                {
                                    if (!File.Exists(document))
                                        exists = false;
                                    else
                                        exists = true;
                                }
                                if(exists == true)
                                {
                                    if (rbmale.Checked == true)
                                        gender = "Male";
                                    if (rbfemale.Checked == true)
                                        gender = "Female";
                                    insertData();
                                    if (NewDocumentEvent != null)
                                    {
                                        NewDocumentEvent(null, null);
                                    }
                                    documentList = new List<string>();
                                    this.Visible = false;
                                }
                                else
                                {
                                    lberror.Text = "* Please select a document";
                                    lberror.Visible = true;
                                }
                            }
                            else
                            {
                                lberror.Text = "* Please select a document";
                                lberror.Visible = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            lberror.Text = "* Date should be in 01-Jan-2000 format";
                            lberror.Visible = true;
                        }
                    }
                }
                else
                {
                    lberror.Text = "* Mobile number not valid";
                    lberror.Visible = true;
                }
            }
            else
            {
                lberror.Text = "* Please enter some information of Patient";
                lberror.Visible = true;
                tbugcid.Text = "UGC ID";
                tbfirstname.Text = "First Name";
                tblastname.Text = "Last Name";
                tbmobilenumber.Text = "Number";
                tbage.Text = "Age";
            }
        }

        public void insertData()
        {
            string ugcId = tbugcid.Text.ToUpper().Trim();
            string firstname = tbfirstname.Text.ToUpper().Trim();
            string lastname = tblastname.Text.ToUpper().Trim();
            string gender = string.Empty;
            string age = tbage.Text.ToUpper().Trim();
            string mobile = tbmobilenumber.Text.ToUpper().Trim();
            string today = DateTime.Now.ToString("dd-MMM-yyyy");
            string datetime = new string(DateTime.Now.ToString("yyyy-MM-dd HH:mm").Where(Char.IsDigit).ToArray());

            if (ugcId == "UGC ID" || ugcId == "")
                ugcId = "NA";
            if (firstname == "FIRST NAME" || firstname == "")
                firstname = "NA";
            if (lastname == "LAST NAME" || lastname == "")
                lastname = "NA";
            if (rbmale.Checked == true)
                gender = "Male";
            if (rbfemale.Checked == true)
                gender = "Female";
            if (gender == "")
                gender = "NA";
            if (age == "AGE" || age == "")
                age = "NA";
            if (mobile == "NUMBER" || mobile == "")
                mobile = "NA";

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd;

                cmd = new SqlCommand("Patient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (clinmdID == string.Empty)
                {
                    Properties.Settings.Default.tempID = Properties.Settings.Default.tempID + 1;
                    Properties.Settings.Default.Save();
                    tempID = "tempID" + (Properties.Settings.Default.tempID).ToString();
                    cmd.Parameters.AddWithValue("@mode", "Insert");
                }
                else
                {
                    tempID = clinmdID;
                    cmd.Parameters.AddWithValue("@mode", "Update");
                }
                
                cmd.Parameters.AddWithValue("@clinmdID", tempID);
                cmd.Parameters.AddWithValue("@ugcID", ugcId);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@lastVisitedDate", today);
                cmd.Parameters.AddWithValue("@transcribed", "0");
                cmd.ExecuteNonQuery();

                foreach(string i in documentList)
                {
                    cmd = new SqlCommand("PatientDocument", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "Insert");
                    cmd.Parameters.AddWithValue("@documentid", "0");
                    cmd.Parameters.AddWithValue("@clinmdID", tempID);
                    cmd.Parameters.AddWithValue("@document", Path.GetFileNameWithoutExtension(i));
                    cmd.Parameters.AddWithValue("@timestamp", datetime);
                    cmd.Parameters.AddWithValue("@location", i);
                    cmd.Parameters.AddWithValue("@transcribed", "0");
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("LastVisitedDocument", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clinmdid", tempID);
                    cmd.Parameters.AddWithValue("@document", Path.GetFileNameWithoutExtension(i));
                    cmd.ExecuteNonQuery();
                }
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
    }
}