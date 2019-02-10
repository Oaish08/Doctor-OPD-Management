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
    public partial class calendarView : UserControl
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        PrivateFontCollection pfc = new PrivateFontCollection();

        public event EventHandler CalendarNewAppointment;

        public event EventHandler CalendarCancelAppointment;

        int appointment_Height;
        bool appointment_Hided;

        int selectedrowindex = -1;

        string firstname = string.Empty, lastname = string.Empty, gender = string.Empty, age = string.Empty, mobile = string.Empty, timeslot = string.Empty, appointmentid = string.Empty, type = string.Empty;

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
            get { return lbselecteddate.Text; }
            set { this.lbselecteddate.Text = value; }
        }

        public string TimeSlot
        {
            get { return timeslot; }
            set { this.timeslot = value; }
        }

        public DataGridView data
        {
            get { return this.dgvappointments; }
        }

        public calendarView()
        {
            InitializeComponent();

            this.calendar1.CalendarDate = DateTime.Now;

            this.calendar1.mydateEvent += Date_MyEvent;

            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            btnappointmentlist.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);

            lbselecteddate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            lbselecteddate.Font = new Font(pfc.Families[0], 20, FontStyle.Bold);

            appointment_Height = panel_appointments.Height;
            appointment_Hided = false;
        }        

        private void Date_MyEvent(object sender, EventArgs e)
        {
            lbselecteddate.Text = this.calendar1.mydate;
            searchData();
        }

        private void calendarView_Load(object sender, EventArgs e)
        {
            panel_appointments.Height = appointment_Height;

            SetFontAndColors();

            lbselecteddate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            lbselecteddate.Font = new Font(pfc.Families[0], 20, FontStyle.Bold);

            searchData();
        }

        private void SetFontAndColors()
        {
            dgvappointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvappointments.DefaultCellStyle.Font = new Font("Times New Roman", 13);
            dgvappointments.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvappointments.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

        }

        public void searchData()
        {
            dgvappointments.Rows.Clear();
            dgvappointments.Rows.Add("11:00 - 11:15 AM", "Empty Slot", Properties.Resources.cancel, "type", "0");
            dgvappointments.Rows.Add("11:15 - 11:30 AM", "Empty Slot", Properties.Resources.cancel, "type", "0");
            dgvappointments.Rows.Add("11:30 - 11:45 AM", "Empty Slot", Properties.Resources.cancel, "type", "0");
            dgvappointments.Rows.Add("11:45 - 12:00 AM", "Empty Slot", Properties.Resources.cancel, "type", "0");
            try
            {
                string date = lbselecteddate.Text;
                string n1 = Environment.NewLine;
                string notice = string.Empty;

                int index = -1;

                string appointmentdate = string.Empty;
                string vaccinationdate = string.Empty;
                string timeslot = string.Empty;
                string vaccinationtype = string.Empty;
                string patientname = string.Empty;
                string gender = string.Empty;
                string age = string.Empty;
                string mobile = string.Empty;
                string vaccinationID = string.Empty;
                string appointmentID = string.Empty;

                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("AppointmentSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patientname", patientname);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@appointmentdate", date);
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    appointmentdate = reader[0].ToString();
                    timeslot = reader[1].ToString();
                    patientname = reader[2].ToString();
                    gender = reader[3].ToString();
                    age = reader[4].ToString();
                    mobile = reader[5].ToString();
                    string appointmentstatus = reader[6].ToString();
                    appointmentID = reader[7].ToString();

                    if (mobile == "NA")
                        mobile = "";
                    if (gender == "NA")
                        gender = "";
                    if (age == "NA")
                        age = "";

                    notice = patientname + n1 + mobile + n1 + gender + "   " + age;

                    foreach (DataGridViewRow row in dgvappointments.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(timeslot))
                        {
                            index = row.Index;
                            break;
                        }
                    }

                    string today = DateTime.Now.ToString("dd-MMM-yyyy");
                    if (DateTime.Parse(appointmentdate) < DateTime.Parse(today))
                    {
                        dgvappointments.Rows.RemoveAt(index);
                        dgvappointments.Rows.Insert(index, timeslot, notice, Properties.Resources.cancel, "appointment", appointmentID);
                    }
                    else
                    {
                        if (appointmentstatus == "upcoming" || appointmentstatus == "today")
                        {
                            dgvappointments.Rows.RemoveAt(index);
                            dgvappointments.Rows.Insert(index, timeslot, notice, Properties.Resources.cancel, "appointment", appointmentID);
                        }
                    }
                    index = -1;
                }
                reader.Close();

                patientname = string.Empty;
                mobile = string.Empty;

                SqlCommand cmd1 = new SqlCommand("VaccinationSearch", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@patientname", patientname);
                cmd1.Parameters.AddWithValue("@mobile", mobile);
                cmd1.Parameters.AddWithValue("@vaccinationdate", date);
                cmd1.ExecuteNonQuery();
                
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while(reader1.Read())
                {
                    vaccinationdate = reader1[0].ToString();
                    timeslot = reader1[1].ToString();
                    vaccinationtype = reader1[2].ToString();
                    patientname = reader1[3].ToString();
                    gender = reader1[4].ToString();
                    age = reader1[5].ToString();
                    mobile = reader1[6].ToString();
                    string vaccinationstatus = reader1[7].ToString();
                    vaccinationID = reader1[8].ToString();

                    if (mobile == "NA")
                        mobile = "";
                    if (gender == "NA")
                        gender = "";
                    if (age == "NA")
                        age = "";

                    notice = vaccinationtype + n1 + patientname + n1 + mobile + n1 + gender + "   " + age;

                    foreach (DataGridViewRow row in dgvappointments.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(timeslot))
                        {
                            index = row.Index;
                            break;
                        }
                    }

                    string today = DateTime.Now.ToString("dd-MMM-yyyy");
                    if (DateTime.Parse(vaccinationdate) < DateTime.Parse(today))
                    {
                        dgvappointments.Rows.RemoveAt(index);
                        dgvappointments.Rows.Insert(index, timeslot, notice, Properties.Resources.cancel, "vaccination", vaccinationID);
                    }
                    else
                    {
                        if (vaccinationstatus == "upcoming" || vaccinationstatus == "today")
                        {
                            dgvappointments.Rows.RemoveAt(index);
                            dgvappointments.Rows.Insert(index, timeslot, notice, Properties.Resources.cancel, "vaccination", vaccinationID);
                        }
                    }
                    index = -1;
                }
                reader1.Close();
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

        private void btnappointmentlist_Click(object sender, EventArgs e)
        {
            timer_appointment.Start();
        }

        private void timer_appointment_Tick(object sender, EventArgs e)
        {
            if (appointment_Hided)
            {
                panel_appointments.Height += 50;
                if (panel_appointments.Height >= appointment_Height)
                {
                    timer_appointment.Stop();
                    appointment_Hided = false;
                    this.Refresh();
                }
            }
            else
            {
                panel_appointments.Height -= 50;
                if (panel_appointments.Height <= 0)
                {
                    timer_appointment.Stop();
                    appointment_Hided = true;
                    this.Refresh();
                }
            }
        }

        private void dgvappointments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvappointments.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvappointments.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvappointments.Rows[selectedrowindex];

                type = (selectedRow.Cells[3].Value).ToString();
                string ID = (selectedRow.Cells[4].Value).ToString();

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

                    if(type == "appointment")
                    {
                        while (reader.Read())
                        {
                            timeslot = reader[1].ToString();
                            string patientname = reader[2].ToString();
                            gender = reader[3].ToString();
                            age = reader[4].ToString();
                            mobile = reader[5].ToString();
                            string appointmentstatus = reader[6].ToString();
                            appointmentid = reader[7].ToString();

                            if (patientname != "NA")
                            {
                                string[] name = patientname.Split(' ');
                                firstname = name[0];
                                string last = string.Empty;
                                for (int i = 1; i < name.Length; i++)
                                {
                                    last += name[i];
                                }
                                lastname = last;
                            }
                        }
                        reader.Close();
                    }

                    if(type == "vaccination")
                    {
                        while (reader.Read())
                        {
                            timeslot = reader[1].ToString();
                            vaccinationtype = reader[2].ToString();
                            string patientname = reader[3].ToString();
                            gender = reader[4].ToString();
                            age = reader[5].ToString();
                            mobile = reader[6].ToString();
                            string vaccinationstatus = reader[7].ToString();
                            appointmentid = reader[8].ToString();

                            if (patientname != "NA")
                            {
                                string[] name = patientname.Split(' ');
                                firstname = name[0];
                                string last = string.Empty;
                                for (int i = 1; i < name.Length; i++)
                                {
                                    last += name[i];
                                }
                                lastname = last;
                            }
                        }
                        reader.Close();
                    }

                    if(ID == "0")
                    {
                        appointmentid = "0";
                        firstname = "First Name";
                        lastname = "Last Name";
                        age = "Age";
                        mobile = "Number";
                        timeslot = (selectedRow.Cells[0].Value).ToString();
                        vaccinationtype = "All";
                    }

                    if (CalendarNewAppointment != null)
                    {
                        CalendarNewAppointment(null, null);
                    }
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

        private void dgvappointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex < dgvappointments.SelectedCells.Count)
            {
                string today = DateTime.Now.ToString("dd-MMM-yyyy");
                if (DateTime.Parse(lbselecteddate.Text) >= DateTime.Parse(today))
                {
                    selectedrowindex = dgvappointments.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dgvappointments.Rows[selectedrowindex];

                    type = (selectedRow.Cells[3].Value).ToString();
                    string ID = (selectedRow.Cells[4].Value).ToString();

                    appointmentid = ID;

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

                        while (reader.Read())
                        {
                            string patientname = string.Empty;
                            if (type == "appointment")
                                patientname = reader[2].ToString();
                            if(type == "vaccination")
                                patientname = reader[3].ToString();

                            if (patientname != "NA")
                            {
                                string[] name = patientname.Split(' ');
                                firstname = name[0];
                                string last = string.Empty;
                                for (int i = 1; i < name.Length; i++)
                                {
                                    last += name[i];
                                }
                                lastname = last;
                            }
                            if (CalendarCancelAppointment != null)
                            {
                                CalendarCancelAppointment(null, null);
                            }
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
            }
        }
    }
}
