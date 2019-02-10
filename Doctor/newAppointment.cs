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
using System.Data.SqlClient;
using System.Diagnostics;

namespace Doctor
{
    public partial class newAppointment : UserControl
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        PrivateFontCollection pfc = new PrivateFontCollection();
        public event EventHandler NewAppointmentEvent;

        string gender = "NA";
        string time = string.Empty;
        int timeslot = 0;

        string tempID = string.Empty;

        List<string> TimeSlotList = new List<string>();

        string appointmentID = "0";

        string clinmdID = string.Empty;

        public string TempID
        {
            get { return this.tempID; }
        }

        public string AppointmentID
        {
            set { this.appointmentID = value; }
        }

        public string ClinmdID
        {
            get { return this.clinmdID; }
            set { this.clinmdID = value; }
        }

        public string FirstName
        {
            get { return this.tbfirstname.Text.ToUpper().Trim(); }
        }

        public string LastName
        {
            get { return this.tblastname.Text.ToUpper().Trim(); }
        }

        public string PatientName
        {
            get { return this.tbfirstname.Text.ToUpper().Trim() + " " + this.tblastname.Text.ToUpper().Trim(); }
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
        
        public string Time
        {
            get { return time; }
        }

        public int TimeSlot
        {
            get { return timeslot; }
        }

        public newAppointment()
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
            lbpatientappointment.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            lbpatientinformation.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);

            calenderdate.SetDate(DateTime.Now);

            TimeSlotList.Add("----Select----");
            TimeSlotList.Add("11:00 - 11:15 AM");
            TimeSlotList.Add("11:15 - 11:30 AM");
            TimeSlotList.Add("11:30 - 11:45 AM");
            TimeSlotList.Add("11:45 - 12:00 AM");

            cbtimeslot.DataSource = TimeSlotList;

            cbtimeslot.SelectedIndex = 0;
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

        private void tbage_Leave(object sender, EventArgs e)
        {
            if (tbage.Text == "")
                tbage.Text = "Age";
        }

        private void tbage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbmobilenumber_Click(object sender, EventArgs e)
        {
            if (tbmobilenumber.Text == "Number")
                tbmobilenumber.Text = "";
            calenderdate.Visible = false;
            tbdate.Enabled = true;
            lberror.Visible = false;
        }

        private void tbmobilenumber_Leave(object sender, EventArgs e)
        {
            if (tbmobilenumber.Text == "")
                tbmobilenumber.Text = "Number";
        }

        private void tbmobilenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbdate_Click(object sender, EventArgs e)
        {
            calenderdate.Visible = true;
            tbdate.Enabled = false;
            lberror.Visible = false;
        }

        private void tbdate_Leave(object sender, EventArgs e)
        {
            if (tbdate.Text == "")
                tbdate.Text = "Select Date";
        }

        public void availableTimeSlot(string date)
        {
            cbtimeslot.DataSource = null;

            List<string> TimeSlotBooked = new List<string>();
            List<string> TimeSlotAvailable = new List<string>();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd;

                cmd = new SqlCommand("AppointmentSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patientname", "");
                cmd.Parameters.AddWithValue("@mobile", "");
                cmd.Parameters.AddWithValue("@appointmentdate", date);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TimeSlotBooked.Add(reader[1].ToString());
                }
                reader.Close();

                cmd = new SqlCommand("VaccinationSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patientname", "");
                cmd.Parameters.AddWithValue("@mobile", "");
                cmd.Parameters.AddWithValue("@vaccinationdate", date);
                cmd.ExecuteNonQuery();
                SqlDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    TimeSlotBooked.Add(reader1[1].ToString());
                }
                reader1.Close();

                TimeSlotAvailable = TimeSlotList.Except(TimeSlotBooked).ToList();

                cbtimeslot.DataSource = TimeSlotAvailable;

                cbtimeslot.SelectedIndex = 0;
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

        private void tbdate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime checkDate = DateTime.ParseExact(tbdate.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                availableTimeSlot(tbdate.Text);
            }
            catch (Exception ex)
            {
                if (tbdate.Text != "Select Date")
                    calenderdate.Visible = true;
            }
        }

        private void cbtimeslot_Click(object sender, EventArgs e)
        {
            lberror.Visible = false;
        }

        private void btnaddpayment_Click(object sender, EventArgs e)
        {
            if (tbfirstname.Text == "First Name")
                tbfirstname.Text = "";
            if (tblastname.Text == "Last Name")
                tblastname.Text = "";
            if (tbmobilenumber.Text == "Number")
                tbmobilenumber.Text = "";
            if (tbage.Text == "Age")
                tbage.Text = "";
            string personalInformation = tbfirstname.Text + tblastname.Text + tbmobilenumber.Text;
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
                            if (checkDate >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
                            {
                                if (cbtimeslot.SelectedIndex != 0)
                                {
                                    if (rbmale.Checked == true)
                                        gender = "Male";
                                    if (rbfemale.Checked == true)
                                        gender = "Female";
                                    time = cbtimeslot.SelectedItem.ToString();
                                    timeslot = cbtimeslot.SelectedIndex - 1;
                                    insertData();
                                    if(NewAppointmentEvent!=null)
                                    {
                                        NewAppointmentEvent(null,null);
                                    }
                                    this.Visible = false;
                                }
                                else
                                {
                                    lberror.Text = "* Please select a time slot";
                                    lberror.Visible = true;
                                }
                            }
                            else
                            {
                                lberror.Text = "* Please select a valid date";
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
                tbfirstname.Text = "First Name";
                tblastname.Text = "Last Name";
                tbmobilenumber.Text = "Number";
                tbage.Text = "Age";
            }
        }

        public void insertData()
        {
            string status = string.Empty;
            string name = string.Empty;
            if (this.PatientName != " ")
                name = this.PatientName;
            else
                name = "NA";

            string age = string.Empty;
            if (this.Age != "")
                age = this.Age;
            else
                age = "NA";

            Image img = null;
            string today = DateTime.Now.ToString("dd-MMM-yyyy");
            if (DateTime.Parse(this.Date) == DateTime.Parse(today))
            {
                img = Properties.Resources.today;
                status = "today";
            }
            else if (DateTime.Parse(this.Date) > DateTime.Parse(today))
            {
                img = Properties.Resources.upcoming;
                status = "upcoming";
            }

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("AppointmentInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (clinmdID == string.Empty)
                {
                    Properties.Settings.Default.tempID = Properties.Settings.Default.tempID + 1;
                    Properties.Settings.Default.Save();
                    tempID = "tempID" + (Properties.Settings.Default.tempID).ToString();
                }
                else
                {
                    tempID = clinmdID;
                }

                if (appointmentID == "0")
                    cmd.Parameters.AddWithValue("@mode", "Insert");
                else
                    cmd.Parameters.AddWithValue("@mode", "Update");

                cmd.Parameters.AddWithValue("@appointmentID", appointmentID);
                cmd.Parameters.AddWithValue("@clinmdID", tempID);
                cmd.Parameters.AddWithValue("@patientname", name);
                cmd.Parameters.AddWithValue("@gender", this.Gender);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@mobile", this.Mobile);
                cmd.Parameters.AddWithValue("@appointmentdate", this.Date);
                cmd.Parameters.AddWithValue("@timeslot", this.Time);
                cmd.Parameters.AddWithValue("@appointmentstatus", status);
                cmd.Parameters.AddWithValue("@transcribed", "0");
                cmd.ExecuteNonQuery();
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
        }
    }
}
