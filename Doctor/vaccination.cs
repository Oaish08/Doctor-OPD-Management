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
    public partial class vaccination : UserControl
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        PrivateFontCollection pfc = new PrivateFontCollection();

        public User_Form ParentForm { get; set; }

        int selectedrowindex = -1;

        public event EventHandler CalendarAppointment;

        public event EventHandler CalendarAppointmentCancel;

        Button getData = new Button();

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
            get { return this.dgvpatientvaccination; }
        }

        public vaccination()
        {
            InitializeComponent();

            this.newVaccination1.NewVaccinationEvent += vaccinationWindow_MyEvent;

            this.confirmmessage1.ConfirmMessageEvent += confirmwindow_MyEvent;

            this.calendarView1.CalendarNewAppointment += calendarAppointment_MyEvent;

            this.calendarView1.CalendarCancelAppointment += calendarCancelAppointment_MyEvent;

            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            lbvaccinations.Font = new Font(pfc.Families[0], 22);
            lbpatientname.Font = new Font(pfc.Families[0], 9);
            lbmobile.Font = new Font(pfc.Families[0], 9);
            lbvaccinationtype.Font = new Font(pfc.Families[0], 11, FontStyle.Bold);
            lbdate.Font = new Font(pfc.Families[0], 8, FontStyle.Bold);
            lbsortby.Font = new Font(pfc.Families[0], 11, FontStyle.Bold);
            lbfilterby.Font = new Font(pfc.Families[0], 11, FontStyle.Bold);

            lbcalenderview.Font = new Font(pfc.Families[0], 9, FontStyle.Bold);
            lblistview.Font = new Font(pfc.Families[0], 9, FontStyle.Bold);
        }

        private void calendarCancelAppointment_MyEvent(object sender, EventArgs e)
        {
            type = this.calendarView1.Type;

            firstname = this.calendarView1.FirstName;
            lastname = this.calendarView1.LastName;
            appointmentid = this.calendarView1.AppointmentID;
            date = this.calendarView1.Date;
            viewCancelVaccination();
        }

        public void viewCancelVaccination()
        {
            if (this.Visible == true && type == "vaccination")
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
                if (CalendarAppointmentCancel != null)
                {
                    CalendarAppointmentCancel(null, null);
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
            vaccinationtype = this.calendarView1.VaccinationType;
            type = this.calendarView1.Type;
            appointmentid = this.calendarView1.AppointmentID;

            viewNewVaccination();
        }

        public void viewNewVaccination()
        {
            if ((this.Visible == true && type == "vaccination") || type == "type")
            {
                this.newVaccination1.Visible = false;
                ParentForm.Opacity = 1;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Focus();

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbdate"]).Text = date;
                ((ComboBox)this.newVaccination1.Controls["cbtimeslot"]).SelectedItem = timeslot;

                ((ComboBox)this.newVaccination1.Controls["cbvaccinationtype"]).SelectedItem = vaccinationtype;

                if (firstname != "NA")
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Text = firstname;
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Text = "First Name";
                }
                if (lastname != "")
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tblastname"]).Text = lastname;
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tblastname"]).Text = "Last Name";
                }

                if (gender == "Male")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbmale"]).Checked = true;
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbmale"]).Checked = false;
                }
                if (gender == "Female")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbfemale"]).Checked = true;
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbfemale"]).Checked = false;
                }

                if (age != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbage"]).Text = age;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbage"]).Text = "Age";

                if (mobile != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbmobilenumber"]).Text = mobile;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbmobilenumber"]).Text = "Number";


                ((Label)this.newVaccination1.Controls["lberror"]).Visible = false;

                this.newVaccination1.VaccinationID = appointmentid;

                ParentForm.Opacity = 0.92;

                newVaccination1.Focus();
                newVaccination1.Visible = true;
            }
            else
            {
                if(CalendarAppointment!=null)
                {
                    CalendarAppointment(null, null);
                }
            }
        }

        private void confirmwindow_MyEvent(object sender, EventArgs e)
        {
            string status = string.Empty;
            string vaccinationID = string.Empty;
            string date = string.Empty;

            if (selectedrowindex != -1)
            {
                vaccinationID = dgvpatientvaccination.Rows[selectedrowindex].Cells[11].Value.ToString();
                date = dgvpatientvaccination.Rows[selectedrowindex].Cells[0].Value.ToString();
            }
            else
            {
                vaccinationID = appointmentid;
                date = this.date;
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
                        SqlCommand cmd = new SqlCommand("VaccinationStatusUpdate", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vaccinationID", vaccinationID);
                        cmd.Parameters.AddWithValue("@vaccinationstatus", status);
                        cmd.ExecuteNonQuery();

                        tbsearchpatientname.Text = "Name";
                        tbsearchmobile.Text = "Number";

                        cbsortby.SelectedItem = "All";
                        cbfilterby.SelectedItem = "All";

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
                catch { }
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
                        SqlCommand cmd = new SqlCommand("VaccinationStatusUpdate", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vaccinationID", vaccinationID);
                        cmd.Parameters.AddWithValue("@vaccinationstatus", status);
                        cmd.ExecuteNonQuery();

                        tbsearchpatientname.Text = "Name";
                        tbsearchmobile.Text = "Number";

                        cbsortby.SelectedItem = "All";
                        cbfilterby.SelectedItem = "All";

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
                catch { }
            }
            confirmmessage1.delete = false;
            ParentForm.Opacity = 1;
            selectedrowindex = -1;
        }

        private void vaccinationWindow_MyEvent(object sender, EventArgs e)
        {
            string status = string.Empty;
            string name = string.Empty;
            if (this.newVaccination1.PatientName != " ")
                name = this.newVaccination1.PatientName;
            else
                name = "NA";

            string age = string.Empty;
            if (this.newVaccination1.Age != "")
                age = this.newVaccination1.Age;
            else
                age = "NA";

            Image img = null;
            string today = DateTime.Now.ToString("dd-MMM-yyyy");
            if (DateTime.Parse(this.newVaccination1.Date) == DateTime.Parse(today))
            {
                img = Properties.Resources.today;
                status = "today";
            }
            else if (DateTime.Parse(this.newVaccination1.Date) > DateTime.Parse(today))
            {
                img = Properties.Resources.upcoming;
                status = "upcoming";
            }

            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";

            cbsortby.SelectedItem = "All";
            cbfilterby.SelectedItem = "All";

            lbdate.Text = this.newVaccination1.Date;

            this.calendarView1.searchData();

            searchData();

            if (lbdate.Text == DateTime.Now.ToString("dd-MMM-yyyy"))
                lbdate.Text = "Today";

            selectedrowindex = -1;
        }

        private void vaccination_Load(object sender, EventArgs e)
        {
            SetFontAndColors();

            calendervaccination.SetDate(DateTime.Now);
            lbdate.Text = "Today";

            cbsortby.SelectedItem = "All";
            cbfilterby.SelectedItem = "All";
        }
        private void SetFontAndColors()
        {
            dgvpatientvaccination.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpatientvaccination.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvpatientvaccination.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvpatientvaccination.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
        }

        private void dgvpatientvaccination_Paint(object sender, PaintEventArgs e)
        {
            dgvpatientvaccination.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvpatientvaccination.GetCellDisplayRectangle(dgvpatientvaccination.Columns["Columndate"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvpatientvaccination.Columns["<Column>"];
            Color cl;
            cl = dgvpatientvaccination.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void tbsearchpatientname_Click(object sender, EventArgs e)
        {
            if (tbsearchpatientname.Text == "Name")
                tbsearchpatientname.Text = "";
            calendervaccination.Visible = false;
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
            calendervaccination.Visible = false;
        }

        private void tbsearchmobile_Leave(object sender, EventArgs e)
        {
            if (tbsearchmobile.Text == "")
                tbsearchmobile.Text = "Number";
        }

        private void tbsearchmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void searchData()
        {
            dgvpatientvaccination.Rows.Clear();
            try
            {
                string vaccinationdate = string.Empty;
                string timeslot = string.Empty;
                string vaccinationtype = string.Empty;
                string patientname = string.Empty;
                string gender = string.Empty;
                string age = string.Empty;
                string mobile = string.Empty;
                string vaccinationstatus = string.Empty;
                string vaccinationID = string.Empty;
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
                SqlCommand cmd = new SqlCommand("VaccinationSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patientname", searchpatientname);
                cmd.Parameters.AddWithValue("@mobile", searchmobile);
                cmd.Parameters.AddWithValue("@vaccinationdate", searchdate);
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
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

                    dgvpatientvaccination.Rows.Add(vaccinationdate, timeslot, vaccinationtype, patientname, gender, age, mobile, img, null, Properties.Resources.cancel, vaccinationstatus, vaccinationID);
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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            searchData();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";
            calendervaccination.Visible = false;
            lbdate.Text = "Today";

            cbsortby.SelectedItem = "All";
            cbfilterby.SelectedItem = "All";

            searchData();
        }

        public void sortfilterData()
        {
            dgvpatientvaccination.Rows.Clear();
            try
            {
                string vaccinationdate = string.Empty;
                string timeslot = string.Empty;
                string vaccinationtype = string.Empty;
                string patientname = string.Empty;
                string gender = string.Empty;
                string age = string.Empty;
                string mobile = string.Empty;
                string vaccinationstatus = string.Empty;
                string vaccinationID = string.Empty;
                string sortby = cbsortby.SelectedItem.ToString();
                string filterby = lbvaccinationtype.Text;
                string searchdate = lbdate.Text;
                Image img = null;

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("VaccinationSorting", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vaccinationtype", filterby);
                cmd.Parameters.AddWithValue("@vaccinationstatus", sortby);
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
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

                    dgvpatientvaccination.Rows.Add(vaccinationdate, timeslot, vaccinationtype, patientname, gender, age, mobile, img, null, Properties.Resources.cancel, vaccinationstatus, vaccinationID);
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

        private void cbfilterby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbfilterby.SelectedIndex == 0)
            {
                lbvaccinationtype.Text = "All Vaccinations";
            }
            else
            {
                lbvaccinationtype.Text = cbfilterby.SelectedItem.ToString();
            }

            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";

            sortfilterData();   
        }

        private void cbsortby_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";

            sortfilterData();
        }

        private void pbcalendar_Click(object sender, EventArgs e)
        {
            calendervaccination.Visible = true;
        }

        private void calendervaccination_DateSelected(object sender, DateRangeEventArgs e)
        {
            lbdate.Text = calendervaccination.SelectionStart.ToString("dd-MMM-yyyy");
            if (calendervaccination.SelectionStart.ToString("dd-MMM-yyyy") == DateTime.Now.ToString("dd-MMM-yyyy"))
                lbdate.Text = "Today";
            calendervaccination.Visible = false;
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

        private void lbdate_TextChanged(object sender, EventArgs e)
        {
            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";

            cbsortby.SelectedItem = "All";
            cbfilterby.SelectedItem = "All";

            searchData();

            if (calendervaccination.SelectionStart.ToString("dd-MMM-yyyy") == DateTime.Now.ToString("dd-MMM-yyyy"))
                lbdate.Text = "Today";
        }

        private void calendervaccination_MouseLeave(object sender, EventArgs e)
        {
            calendervaccination.Visible = false;
        }

        private void dgvpatientvaccination_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvpatientvaccination.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvpatientvaccination.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvpatientvaccination.Rows[selectedrowindex];

                string date = (selectedRow.Cells[0].Value).ToString();
                string time = (selectedRow.Cells[1].Value).ToString();
                string vaccination = (selectedRow.Cells[2].Value).ToString();
                string patientname = (selectedRow.Cells[3].Value).ToString();
                string gender = (selectedRow.Cells[4].Value).ToString();
                string age = (selectedRow.Cells[5].Value).ToString();
                string mobile = (selectedRow.Cells[6].Value).ToString();
                string vaccinationID = (selectedRow.Cells[11].Value).ToString();

                this.newVaccination1.Visible = false;
                ParentForm.Opacity = 1;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Focus();

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbdate"]).Text = date;
                ((ComboBox)this.newVaccination1.Controls["cbtimeslot"]).SelectedItem = time;
                ((ComboBox)this.newVaccination1.Controls["cbvaccinationtype"]).SelectedItem = vaccination;

                if (patientname != "NA")
                {
                    string[] name = patientname.Split(' ');
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Text = name[0];
                    string lastname = string.Empty;
                    for (int i = 1; i < name.Length; i++)
                    {
                        lastname += name[i];
                    }
                    if (lastname != "")
                        ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tblastname"]).Text = lastname;
                    else
                        ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tblastname"]).Text = "Last Name";
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Text = "First Name";
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tblastname"]).Text = "Last Name";
                }

                if (gender == "Male")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbmale"]).Checked = true;
                }
                if (gender == "Female")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbfemale"]).Checked = true;
                }

                if (age != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbage"]).Text = age;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbage"]).Text = "Age";

                if (mobile != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbmobilenumber"]).Text = mobile;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbmobilenumber"]).Text = "Number";


                ((Label)this.newVaccination1.Controls["lberror"]).Visible = false;

                this.newVaccination1.VaccinationID = vaccinationID;

                ParentForm.Opacity = 0.92;

                newVaccination1.Focus();
                newVaccination1.Visible = true;
            }
        }

        private void dgvpatientvaccination_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex < dgvpatientvaccination.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientvaccination.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientvaccination.Rows[selectedrowindex];

                string patientname = (selectedRow.Cells[3].Value).ToString();
                string status = (selectedRow.Cells[10].Value).ToString();
                string time = (selectedRow.Cells[1].Value).ToString();
                if (status != "completed" && status != "cancelled")
                {
                    confirmmessage1.Visible = true;
                    ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to complete appointment of patient " + patientname + " ?";
                    ((ComboBox)this.newVaccination1.Controls["cbtimeslot"]).SelectedItem = time;
                    ParentForm.Opacity = 0.92;
                }
            }
            if (e.ColumnIndex == 9 && e.RowIndex < dgvpatientvaccination.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientvaccination.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientvaccination.Rows[selectedrowindex];

                string patientname = (selectedRow.Cells[3].Value).ToString();
                string status = (selectedRow.Cells[10].Value).ToString();
                string time = (selectedRow.Cells[1].Value).ToString();

                if (status != "completed" && status != "cancelled")
                {
                    confirmmessage1.Visible = true;
                    ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to cancel appointment of patient " + patientname + " ?";
                    confirmmessage1.delete = true;
                    ((ComboBox)this.newVaccination1.Controls["cbtimeslot"]).SelectedItem = time;
                    ParentForm.Opacity = 0.92;
                }
            }
        }

        private void btnnewvaccination_Click(object sender, EventArgs e)
        {
            selectedrowindex = -1;
            calendervaccination.Visible = false;
            ParentForm.Opacity = 0.92;

            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Focus();
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Text = "";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tblastname"]).Text = "Last Name";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbage"]).Text = "Age";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbmobilenumber"]).Text = "Number";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbdate"]).Text = "Select Date";
            ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbmale"]).Checked = false;
            ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbfemale"]).Checked = false;
            ((MonthCalendar)this.newVaccination1.Controls["calenderdate"]).SetDate(DateTime.Now);
            ((ComboBox)this.newVaccination1.Controls["cbtimeslot"]).SelectedIndex = 0;
            ((ComboBox)this.newVaccination1.Controls["cbvaccinationtype"]).SelectedIndex = 0;
            ((Label)this.newVaccination1.Controls["lberror"]).Visible = false;
            this.newVaccination1.VaccinationID = "0";
            newVaccination1.Visible = true;
        }

        private void newVaccination1_Leave(object sender, EventArgs e)
        {
            newVaccination1.Visible = false;
            ParentForm.Opacity = 1;
        }

        private void confirmmessage1_Leave(object sender, EventArgs e)
        {
            newVaccination1.Visible = false;
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

        private void vaccination_VisibleChanged(object sender, EventArgs e)
        {
            this.calendarView1.searchData();
            calendarView1.Visible = true;
            lbcalenderview.ForeColor = Color.FromArgb(56, 143, 163);
            lblistview.ForeColor = Color.Black;
        }
    }
}
