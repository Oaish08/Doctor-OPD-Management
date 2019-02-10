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
using System.Diagnostics;
using System.Data.SqlClient;

namespace Doctor
{
    public partial class appointment : UserControl
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);
        PrivateFontCollection pfc = new PrivateFontCollection();

        public User_Form ParentForm { get; set; }

        int selectedrowindex = -1;

        public event EventHandler CalendarVaccination;

        public event EventHandler CalendarVaccinationCancel;

        string firstname = string.Empty, lastname = string.Empty, gender = string.Empty, age = string.Empty, mobile = string.Empty, date = string.Empty, timeslot = string.Empty, appointmentid = string.Empty, type = string.Empty;

        string vaccinationtype = string.Empty;

        public string Type
        {
            get { return type; }
            set { this.type = value; }
        }

        public string AppointmentID
        {
            get { return appointmentid; }
            set { this.appointmentid = value; }
        }

        public string VaccinationType
        {
            get { return vaccinationtype; }
            set { this.vaccinationtype = value; }
        }

        public string FirstName
        {
            get { return firstname; }
            set { this.firstname = value; }
        }

        public string LastName
        {
            get { return lastname; }
            set { this.lastname = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { this.gender = value; }
        }

        public string Age
        {
            get { return age; }
            set { this.age = value; }
        }

        public string Mobile
        {
            get { return mobile; }
            set { this.mobile = value; }
        }

        public string Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public string TimeSlot
        {
            get { return timeslot; }
            set { this.timeslot = value; }
        }

        public DataGridView data
        {
            get { return this.dgvpatientappointment; }
        }

        public appointment()
        {
            InitializeComponent();

            this.newAppointment1.NewAppointmentEvent += appointmentWindow_MyEvent;

            this.confirmmessage1.ConfirmMessageEvent += confirmwindow_MyEvent;

            this.calendarView1.CalendarNewAppointment += calendarAppointment_MyEvent;

            this.calendarView1.CalendarCancelAppointment += calendarCancelAppointment_MyEvent;

            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            lbappointments.Font = new Font(pfc.Families[0], 22);
            lbpatientname.Font = new Font(pfc.Families[0], 9);
            lbmobile.Font = new Font(pfc.Families[0], 9);
            lbdatetime.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            lbdate.Font = new Font(pfc.Families[0], 8, FontStyle.Bold);
            lbsortby.Font = new Font(pfc.Families[0], 11, FontStyle.Bold);

            lbcalenderview.Font = new Font(pfc.Families[0], 9, FontStyle.Bold);
            lblistview.Font = new Font(pfc.Families[0], 9, FontStyle.Bold);
        }

        private void calendarCancelAppointment_MyEvent(object sender, EventArgs e)
        {
            firstname = this.calendarView1.FirstName;
            lastname = this.calendarView1.LastName;
            appointmentid = this.calendarView1.AppointmentID;
            date = this.calendarView1.Date;
            type = this.calendarView1.Type;

            viewCancelAppointment();
        }

        public void viewCancelAppointment()
        {
            if (this.Visible == true && type == "appointment")
            {
                this.confirmmessage1.Visible = false;
                ParentForm.Opacity = 1;
                this.confirmmessage1.delete = true;
                ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to cancel appointment of patient " + firstname + " " + lastname + " ?";
                this.ParentForm.Opacity = 0.92;
                this.confirmmessage1.Visible = true;
            }
            else
            {
                if (CalendarVaccinationCancel != null)
                {
                    CalendarVaccinationCancel(null, null);
                }
            }
        }

        private void calendarAppointment_MyEvent(object sender, EventArgs e)
        {
            date = this.calendarView1.Date;
            timeslot = this.calendarView1.TimeSlot;
            firstname = this.calendarView1.FirstName;
            lastname = this.calendarView1.LastName;
            gender = this.calendarView1.Gender;
            age = this.calendarView1.Age;
            mobile = this.calendarView1.Mobile;
            appointmentid = this.calendarView1.AppointmentID;
            vaccinationtype = this.calendarView1.VaccinationType;
            type = this.calendarView1.Type;

            viewNewAppointment();
        }

        public void viewNewAppointment()
        {
            if ((this.Visible == true && type == "appointment") || type == "type")
            {
                this.newAppointment1.Visible = false;
                ParentForm.Opacity = 1;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Focus();

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbdate"]).Text = date;
                ((ComboBox)this.newAppointment1.Controls["cbtimeslot"]).SelectedItem = timeslot;

                if (firstname != "NA")
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Text = firstname;
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Text = "First Name";
                }

                if (lastname != "")
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tblastname"]).Text = lastname;
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tblastname"]).Text = "Last Name";
                }

                if (gender == "Male")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbmale"]).Checked = true;
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbmale"]).Checked = false;
                }
                if (gender == "Female")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbfemale"]).Checked = true;
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbfemale"]).Checked = false;
                }

                if (age != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbage"]).Text = age;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbage"]).Text = "Age";

                if (mobile != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbmobilenumber"]).Text = mobile;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbmobilenumber"]).Text = "Number";

                ((Label)this.newAppointment1.Controls["lberror"]).Visible = false;

                this.newAppointment1.AppointmentID = appointmentid;

                this.ParentForm.Opacity = 0.92;
                this.newAppointment1.Visible = true;
            }
            else
            {
                if (CalendarVaccination != null)
                {
                    CalendarVaccination(null, null);
                }
            }
        }

        private void confirmwindow_MyEvent(object sender, EventArgs e)
        {
            string status = string.Empty;
            string appointmentID = string.Empty;
            string date = string.Empty;

            if (selectedrowindex != -1)
            {
                appointmentID = dgvpatientappointment.Rows[selectedrowindex].Cells[10].Value.ToString();
                date = dgvpatientappointment.Rows[selectedrowindex].Cells[0].Value.ToString();
            }
            else
            {
                appointmentID = this.calendarView1.AppointmentID;
                date = this.calendarView1.Date;
            }

            if (confirmmessage1.delete == true)
            {
                status = "cancelled";
                Image img = null;
                img = Properties.Resources.cancelled;

                try
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd = new SqlCommand("AppointmentStatusUpdate", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@appointmentID", appointmentID);
                        cmd.Parameters.AddWithValue("@appointmentstatus", status);
                        cmd.ExecuteNonQuery();

                        tbsearchpatientname.Text = "Name";
                        tbsearchmobile.Text = "Number";

                        cbsortby.SelectedItem = "All";

                        lbdate.Text = date;

                        this.calendarView1.searchData();

                        searchData();
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
                catch (Exception exc)
                {
                    Debug.WriteLine(exc.Message);
                }
            }
            else
            {
                status = "completed";
                Image img = null;
                img = Properties.Resources.completed;

                try
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd = new SqlCommand("AppointmentStatusUpdate", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@appointmentID", appointmentID);
                        cmd.Parameters.AddWithValue("@appointmentstatus", status);
                        cmd.ExecuteNonQuery();

                        tbsearchpatientname.Text = "Name";
                        tbsearchmobile.Text = "Number";

                        cbsortby.SelectedItem = "All";

                        lbdate.Text = date;

                        this.calendarView1.searchData();

                        searchData();
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
                catch (Exception exc)
                {
                    Debug.WriteLine(exc.Message);
                }
            }
            confirmmessage1.delete = false;
            ParentForm.Opacity = 1;
            selectedrowindex = -1;
        }

        private void appointmentWindow_MyEvent(object sender, EventArgs e)
        {
            string status = string.Empty;
            string name = string.Empty;
            if (this.newAppointment1.PatientName != " ")
                name = this.newAppointment1.PatientName;
            else
                name = "NA";

            string age = string.Empty;
            if (this.newAppointment1.Age != "")
                age = this.newAppointment1.Age;
            else
                age = "NA";

            Image img = null;
            string today = DateTime.Now.ToString("dd-MMM-yyyy");
            if(DateTime.Parse(this.newAppointment1.Date) == DateTime.Parse(today))
            {
                img = Properties.Resources.today;
                status = "today";
            }
            else if(DateTime.Parse(this.newAppointment1.Date) > DateTime.Parse(today))
            {
                img = Properties.Resources.upcoming;
                status = "upcoming";
            }

            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";

            cbsortby.SelectedItem = "All";

            lbdate.Text = this.newAppointment1.Date;

            this.calendarView1.searchData();

            searchData();

            if (lbdate.Text == DateTime.Now.ToString("dd-MMM-yyyy"))
                lbdate.Text = "Today";

            selectedrowindex = -1;
        }

        private void appointment_Load(object sender, EventArgs e)
        {
            SetFontAndColors();
            timerDateTimeNow.Start();

            calenderappointment.SetDate(DateTime.Now);
            lbdate.Text = "Today";

            cbsortby.SelectedItem = "All";
        }

        private void SetFontAndColors()
        {
            dgvpatientappointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpatientappointment.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvpatientappointment.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvpatientappointment.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
        }

        private void dgvpatientappointment_Paint(object sender, PaintEventArgs e)
        {
            dgvpatientappointment.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvpatientappointment.GetCellDisplayRectangle(dgvpatientappointment.Columns["Columndate"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvpatientappointment.Columns["<Column>"];
            Color cl;
            cl = dgvpatientappointment.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void timerDateTimeNow_Tick(object sender, EventArgs e)
        {
            lbdatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy    hh:mm:ss tt");
        }

        private void pbcalendar_Click(object sender, EventArgs e)
        {
            calenderappointment.Visible = true;
        }

        private void calenderappointment_MouseLeave(object sender, EventArgs e)
        {
            calenderappointment.Visible = false;
        }

        private void calenderappointment_DateSelected(object sender, DateRangeEventArgs e)
        {
            lbdate.Text = calenderappointment.SelectionStart.ToString("dd-MMM-yyyy");
            if (calenderappointment.SelectionStart.ToString("dd-MMM-yyyy") == DateTime.Now.ToString("dd-MMM-yyyy"))
                lbdate.Text = "Today";
            calenderappointment.Visible = false;
        }

        void searchData()
        {
            dgvpatientappointment.Rows.Clear();
            try
            {
                string appointmentdate = string.Empty;
                string timeslot = string.Empty;
                string patientname = string.Empty;
                string gender = string.Empty;
                string age = string.Empty;
                string mobile = string.Empty;
                string appointmentstatus = string.Empty;
                string appointmentID = string.Empty;
                string searchpatientname = tbsearchpatientname.Text.Trim();
                string searchmobile = tbsearchmobile.Text.Trim();
                string searchdate = lbdate.Text;
                Image img = null;

                if (searchpatientname == "Name")
                    searchpatientname = "";
                if (searchmobile == "Number")
                    searchmobile = "";
                if (lbdate.Text == "Today")
                    searchdate = DateTime.Now.ToString("dd-MMM-yyyy");

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("AppointmentSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patientname", searchpatientname);
                cmd.Parameters.AddWithValue("@mobile", searchmobile);
                cmd.Parameters.AddWithValue("@appointmentdate", searchdate);
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
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

                    dgvpatientappointment.Rows.Add(appointmentdate, timeslot, patientname, gender, age, mobile, img, null, Properties.Resources.cancel, appointmentstatus, appointmentID);
                }
                reader.Close();
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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            searchData();
        }

        private void tbsearchpatientname_Click(object sender, EventArgs e)
        {
            if (tbsearchpatientname.Text == "Name")
                tbsearchpatientname.Text = "";
            calenderappointment.Visible = false;
        }

        private void tbsearchpatientname_Leave(object sender, EventArgs e)
        {
            if (tbsearchpatientname.Text == "")
                tbsearchpatientname.Text = "Name";
        }

        private void tbsearchmobile_Click(object sender, EventArgs e)
        {
            if (tbsearchmobile.Text == "Number")
                tbsearchmobile.Text = "";
            calenderappointment.Visible = false;
        }

        private void tbsearchmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbsearchmobile_Leave(object sender, EventArgs e)
        {
            if (tbsearchmobile.Text == "")
            {
                tbsearchmobile.Text = "Number";
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";
            calenderappointment.Visible = false;

            cbsortby.SelectedItem = "All";

            searchData();
        }

        private void lbdate_TextChanged(object sender, EventArgs e)
        {
            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";

            cbsortby.SelectedItem = "All";

            searchData();

            if (lbdate.Text == DateTime.Now.ToString("dd-MMM-yyyy"))
                lbdate.Text = "Today";
        }

        private void pblastdate_Click(object sender, EventArgs e)
        {
            if (lbdate.Text != "Today")
            {
                lbdate.Text = DateTime.Parse(lbdate.Text).AddDays(-1).ToString("dd-MMM-yyyy");
                if (lbdate.Text == DateTime.Now.ToString("dd-MMM-yyyy"))
                    lbdate.Text = "Today";
            }
            else
                lbdate.Text = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
        }

        private void pbnextdate_Click(object sender, EventArgs e)
        {
            if (lbdate.Text != "Today")
            {
                lbdate.Text = DateTime.Parse(lbdate.Text).AddDays(1).ToString("dd-MMM-yyyy");
                if (lbdate.Text == DateTime.Now.ToString("dd-MMM-yyyy"))
                    lbdate.Text = "Today";
            }
            else
                lbdate.Text = DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy");
        }

        public void sortData()
        {
            dgvpatientappointment.Rows.Clear();
            try
            {
                string appointmentdate = string.Empty;
                string timeslot = string.Empty;
                string patientname = string.Empty;
                string gender = string.Empty;
                string age = string.Empty;
                string mobile = string.Empty;
                string appointmentstatus = string.Empty;
                string appointmentID = string.Empty;
                string sortby = cbsortby.SelectedItem.ToString();
                string searchdate = lbdate.Text;
                Image img = null;

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("AppointmentSorting", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@appointmentstatus", sortby);
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
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

                    dgvpatientappointment.Rows.Add(appointmentdate, timeslot, patientname, gender, age, mobile, img, null, Properties.Resources.cancel, appointmentstatus, appointmentID);
                }
                reader.Close();
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

        private void cbsortby_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";

            sortData();
        }

        private void dgvpatientappointment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvpatientappointment.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvpatientappointment.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvpatientappointment.Rows[selectedrowindex];

                string date = (selectedRow.Cells[0].Value).ToString();
                string time = (selectedRow.Cells[1].Value).ToString();
                string patientname = (selectedRow.Cells[2].Value).ToString();
                string gender = (selectedRow.Cells[3].Value).ToString();
                string age = (selectedRow.Cells[4].Value).ToString();
                string mobile = (selectedRow.Cells[5].Value).ToString();
                string appointmentID = (selectedRow.Cells[10].Value).ToString();

                this.newAppointment1.Visible = false;
                ParentForm.Opacity = 1;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Focus();

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbdate"]).Text = date;
                ((ComboBox)this.newAppointment1.Controls["cbtimeslot"]).SelectedItem = time;

                if (patientname != "NA")
                {
                    string[] name = patientname.Split(' ');
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Text = name[0];
                    string lastname = string.Empty;
                    for (int i = 1; i < name.Length; i++)
                    {
                        lastname += name[i];
                    }
                    if (lastname != "")
                        ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tblastname"]).Text = lastname;
                    else
                        ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tblastname"]).Text = "Last Name";
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Text = "First Name";
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tblastname"]).Text = "Last Name";
                }

                if (gender == "Male")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbmale"]).Checked = true;
                }
                if (gender == "Female")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbfemale"]).Checked = true;
                }

                if (age != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbage"]).Text = age;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbage"]).Text = "Age";

                if (mobile != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbmobilenumber"]).Text = mobile;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbmobilenumber"]).Text = "Number";


                ((Label)this.newAppointment1.Controls["lberror"]).Visible = false;

                this.newAppointment1.AppointmentID = appointmentID;

                ParentForm.Opacity = 0.92;

                newAppointment1.Focus();
                newAppointment1.Visible = true;
            }
        }

        private void dgvpatientappointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex < dgvpatientappointment.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientappointment.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientappointment.Rows[selectedrowindex];

                string patientname = (selectedRow.Cells[2].Value).ToString();
                string status = (selectedRow.Cells[9].Value).ToString();

                string time = (selectedRow.Cells[1].Value).ToString();

                if (status != "completed" && status != "cancelled")
                {
                    confirmmessage1.Visible = true;
                    ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to complete appointment of patient " + patientname + " ?";
                    ((ComboBox)this.newAppointment1.Controls["cbtimeslot"]).SelectedItem = time;
                    ParentForm.Opacity = 0.92;
                }
            }
            if (e.ColumnIndex == 8 && e.RowIndex < dgvpatientappointment.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientappointment.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientappointment.Rows[selectedrowindex];

                string patientname = (selectedRow.Cells[2].Value).ToString();
                string status = (selectedRow.Cells[9].Value).ToString();

                string time = (selectedRow.Cells[1].Value).ToString();

                if (status != "completed" && status != "cancelled")
                {
                    confirmmessage1.Visible = true;
                    ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to cancel appointment of patient " + patientname + " ?";
                    confirmmessage1.delete = true;
                    ((ComboBox)this.newAppointment1.Controls["cbtimeslot"]).SelectedItem = time;
                    ParentForm.Opacity = 0.92;
                }
            }
        }

        private void dgvpatientappointment_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e){}

        private void btnnewappointment_Click(object sender, EventArgs e)
        {
            selectedrowindex = -1;
            calenderappointment.Visible = false;
            ParentForm.Opacity = 0.92;

            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Focus();
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Text = "";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tblastname"]).Text = "Last Name";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbage"]).Text = "Age";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbmobilenumber"]).Text = "Number";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbdate"]).Text = "Select Date";
            ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbmale"]).Checked = false;
            ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbfemale"]).Checked = false;
            ((ComboBox)this.newAppointment1.Controls["cbtimeslot"]).SelectedIndex = 0;
            ((MonthCalendar)this.newAppointment1.Controls["calenderdate"]).SetDate(DateTime.Now);
            ((Label)this.newAppointment1.Controls["lberror"]).Visible = false;
            this.newAppointment1.AppointmentID = "0";
            newAppointment1.Visible = true;
        }

        private void newAppointment1_Leave(object sender, EventArgs e)
        {
            newAppointment1.Visible = false;
            ParentForm.Opacity = 1;
        }

        private void confirmmessage1_Leave(object sender, EventArgs e)
        {
            confirmmessage1.Visible = false;
            ParentForm.Opacity = 1;
        }

        private void lbcalenderview_Click(object sender, EventArgs e)
        {
            calendarView1.Visible = true;
            lbcalenderview.ForeColor = Color.FromArgb(56, 143, 163);
            lblistview.ForeColor = Color.Black;
        }

        private void lbcalenderview_MouseHover(object sender, EventArgs e)
        {
            lbcalenderview.ForeColor = Color.FromArgb(56, 143, 163);
        }

        private void lbcalenderview_MouseLeave(object sender, EventArgs e)
        {
            if (calendarView1.Visible == false)
                lbcalenderview.ForeColor = Color.Black;
        }

        private void lblistview_Click(object sender, EventArgs e)
        {
            calendarView1.Visible = false;
            lbcalenderview.ForeColor = Color.Black;
            lblistview.ForeColor = Color.FromArgb(56, 143, 163);
        }

        private void lblistview_MouseHover(object sender, EventArgs e)
        {
            lblistview.ForeColor = Color.FromArgb(56, 143, 163);
        }

        private void lblistview_MouseLeave(object sender, EventArgs e)
        {
            if (calendarView1.Visible == true)
                lblistview.ForeColor = Color.Black;
        }

        private void appointment_VisibleChanged(object sender, EventArgs e)
        {
            this.calendarView1.searchData();
            calendarView1.Visible = true;
            lbcalenderview.ForeColor = Color.FromArgb(56, 143, 163);
            lblistview.ForeColor = Color.Black;
        }
    }
}
