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
    public partial class report : UserControl
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        PrivateFontCollection pfc = new PrivateFontCollection();
        Color backcolor = Color.FromArgb(56, 143, 163);
        Color highlightcolor = Color.FromArgb(56, 113, 133);
        Color selectcolor = Color.FromArgb(56, 213, 233);

        int notices_Height;
        bool notices_Hided;

        public event EventHandler reportEvent;

        int selectedrowindex = -1;

        string id = string.Empty, type = string.Empty;

        public string ID
        {
            get { return this.id; }
        }

        public string Type
        {
            get { return this.type; }
        }

        public report()
        {
            InitializeComponent();

            this.calendar1.CalendarDate = DateTime.Now;

            this.calendar1.mydateEvent += Date_MyEvent;

            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            lbreports.Font = new Font(pfc.Families[0], 22);
            lbpatients.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbmedication.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbappointment.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbvaccination.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbpayment.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            btnnotices.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lbnonotices.Font = new Font(pfc.Families[0], 9, FontStyle.Bold);

            lbselecteddate.Text = DateTime.Now.ToString("dd-MMM-yyyy");                
            lbselecteddate.Font = new Font(pfc.Families[0], 20, FontStyle.Bold);

            notices_Height = panel_notices.Height;
            notices_Hided = false;
        }

        private void Date_MyEvent(object sender, EventArgs e)
        {
            lbselecteddate.Text = this.calendar1.mydate;
        }

        private void report_Load(object sender, EventArgs e)
        {
            panel_notices.Height = notices_Height;

            SetFontAndColors();
        }

        private void SetFontAndColors()
        {
            dgvnotices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvnotices.DefaultCellStyle.Font = new Font("Times New Roman", 13);
            dgvnotices.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvnotices.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
        }

        void patientClick()
        {
            btnpatients.BackColor = selectcolor;

            btnmedication.BackColor = backcolor;
            btnappointment.BackColor = backcolor;
            btnvaccination.BackColor = backcolor;
            btnpayment.BackColor = backcolor;
        }

        private void btnpatients_Click(object sender, EventArgs e)
        {
            patientClick();
        }

        private void btnpatients_Leave(object sender, EventArgs e)
        {
            btnpatients.BackColor = backcolor;
        }

        private void btnpatients_MouseHover(object sender, EventArgs e)
        {
            btnpatients.BackColor = highlightcolor;
        }

        private void btnpatients_MouseLeave(object sender, EventArgs e)
        {
            btnpatients.BackColor = backcolor;
        }

        private void pbpatients_Click(object sender, EventArgs e)
        {
            patientClick();
        }

        private void pbpatients_MouseHover(object sender, EventArgs e)
        {
            btnpatients.BackColor = highlightcolor;
        }

        private void pbpatients_MouseLeave(object sender, EventArgs e)
        {
            btnpatients.BackColor = backcolor;

        }

        private void lbpatients_Click(object sender, EventArgs e)
        {
            patientClick();
        }

        private void lbpatients_MouseHover(object sender, EventArgs e)
        {
            btnpatients.BackColor = highlightcolor;
        }

        private void lbpatients_MouseLeave(object sender, EventArgs e)
        {
            btnpatients.BackColor = backcolor;
        }

        void medicationCLick()
        {
            btnmedication.BackColor = selectcolor;

            btnpatients.BackColor = backcolor;
            btnappointment.BackColor = backcolor;
            btnvaccination.BackColor = backcolor;
            btnpayment.BackColor = backcolor;
        }

        private void btnmedication_Click(object sender, EventArgs e)
        {
            medicationCLick();
        }

        private void btnmedication_Leave(object sender, EventArgs e)
        {
            btnmedication.BackColor = backcolor;
        }

        private void btnmedication_MouseHover(object sender, EventArgs e)
        {
            btnmedication.BackColor = highlightcolor;
        }

        private void btnmedication_MouseLeave(object sender, EventArgs e)
        {
            btnmedication.BackColor = backcolor;
        }

        private void pbmedication_Click(object sender, EventArgs e)
        {
            medicationCLick();
        }

        private void pbmedication_MouseHover(object sender, EventArgs e)
        {
            btnmedication.BackColor = highlightcolor;
        }

        private void pbmedication_MouseLeave(object sender, EventArgs e)
        {
            btnmedication.BackColor = backcolor;
        }

        private void lbmedication_Click(object sender, EventArgs e)
        {
            medicationCLick();
        }

        private void lbmedication_MouseHover(object sender, EventArgs e)
        {
            btnmedication.BackColor = highlightcolor;
        }

        private void lbmedication_MouseLeave(object sender, EventArgs e)
        {
            btnmedication.BackColor = backcolor;
        }

        void appointmentClick()
        {
            btnappointment.BackColor = selectcolor;

            btnmedication.BackColor = backcolor;
            btnpatients.BackColor = backcolor;
            btnvaccination.BackColor = backcolor;
            btnpayment.BackColor = backcolor;
        }

        private void btnappointment_Click(object sender, EventArgs e)
        {
            appointmentClick();
        }

        private void btnappointment_Leave(object sender, EventArgs e)
        {
            btnappointment.BackColor = backcolor;
        }

        private void btnappointment_MouseHover(object sender, EventArgs e)
        {
            btnappointment.BackColor = highlightcolor;
        }

        private void btnappointment_MouseLeave(object sender, EventArgs e)
        {
            btnappointment.BackColor = backcolor;
        }

        private void pbappoiment_Click(object sender, EventArgs e)
        {
            appointmentClick();
        }

        private void pbappoiment_MouseHover(object sender, EventArgs e)
        {
            btnappointment.BackColor = highlightcolor;
        }

        private void pbappoiment_MouseLeave(object sender, EventArgs e)
        {
            btnappointment.BackColor = backcolor;
        }

        private void lbappointment_Click(object sender, EventArgs e)
        {
            appointmentClick();
        }

        private void lbappointment_MouseHover(object sender, EventArgs e)
        {
            btnappointment.BackColor = highlightcolor;
        }

        private void lbappointment_MouseLeave(object sender, EventArgs e)
        {
            btnappointment.BackColor = backcolor;
        }

        void vaccicationClick()
        {
            btnvaccination.BackColor = selectcolor;

            btnpatients.BackColor = backcolor;
            btnappointment.BackColor = backcolor;
            btnmedication.BackColor = backcolor;
            btnpayment.BackColor = backcolor;
        }

        private void btnvaccination_Click(object sender, EventArgs e)
        {
            vaccicationClick();
        }

        private void btnvaccination_Leave(object sender, EventArgs e)
        {
            btnvaccination.BackColor = backcolor;
        }

        private void btnvaccination_MouseHover(object sender, EventArgs e)
        {
            btnvaccination.BackColor = highlightcolor;
        }

        private void btnvaccination_MouseLeave(object sender, EventArgs e)
        {
            btnvaccination.BackColor = backcolor;
        }

        private void pbvaccinations_Click(object sender, EventArgs e)
        {
            vaccicationClick();
        }

        private void pbvaccinations_MouseHover(object sender, EventArgs e)
        {
            btnvaccination.BackColor = highlightcolor;
        }

        private void pbvaccinations_MouseLeave(object sender, EventArgs e)
        {
            btnvaccination.BackColor = backcolor;
        }

        private void lbvaccination_Click(object sender, EventArgs e)
        {
            vaccicationClick();
        }

        private void lbvaccination_MouseHover(object sender, EventArgs e)
        {
            btnvaccination.BackColor = highlightcolor;
        }

        private void lbvaccination_MouseLeave(object sender, EventArgs e)
        {
            btnvaccination.BackColor = backcolor;
        }

        void paymentClick()
        {
            btnpayment.BackColor = selectcolor;

            btnpatients.BackColor = backcolor;
            btnappointment.BackColor = backcolor;
            btnmedication.BackColor = backcolor;
            btnvaccination.BackColor = backcolor;
        }

        private void btnpayment_Click(object sender, EventArgs e)
        {
            paymentClick();
        }

        private void btnpayment_Leave(object sender, EventArgs e)
        {
            btnpayment.BackColor = backcolor;
        }

        private void btnpayment_MouseHover(object sender, EventArgs e)
        {
            btnpayment.BackColor = highlightcolor;
        }

        private void btnpayment_MouseLeave(object sender, EventArgs e)
        {
            btnpayment.BackColor = backcolor;
        }

        private void pbpayment_Click(object sender, EventArgs e)
        {
            paymentClick();
        }

        private void pbpayment_MouseHover(object sender, EventArgs e)
        {
            btnpayment.BackColor = highlightcolor;
        }

        private void pbpayment_MouseLeave(object sender, EventArgs e)
        {
            btnpayment.BackColor = backcolor;
        }

        private void lbpayment_Click(object sender, EventArgs e)
        {
            paymentClick();
        }

        private void lbpayment_MouseHover(object sender, EventArgs e)
        {
            btnpayment.BackColor = highlightcolor;
        }

        private void lbpayment_MouseLeave(object sender, EventArgs e)
        {
            btnpayment.BackColor = backcolor;
        }

        private void btnnotices_Click(object sender, EventArgs e)
        {
            timer_notice.Start();
        }

        private void timer_notice_Tick(object sender, EventArgs e)
        {
            if (notices_Hided)
            {
                panel_notices.Height += 50;
                if (panel_notices.Height >= notices_Height)
                {
                    timer_notice.Stop();
                    notices_Hided = false;
                    this.Refresh();
                }
            }
            else
            {
                panel_notices.Height -= 50;
                if (panel_notices.Height <= 0)
                {
                    timer_notice.Stop();
                    notices_Hided = true;
                    this.Refresh();
                }
            }
        }


        private void lbselecteddate_TextChanged(object sender, EventArgs e)
        {
            dgvnotices.Rows.Clear();
            loadData();
        }


        public void loadData()
        {
            dgvnotices.Rows.Clear();

            string patientname = string.Empty;
            string timeslot = string.Empty;
            string date = lbselecteddate.Text;
            string n1 = Environment.NewLine;
            string notice = string.Empty;
            string ID = string.Empty;
            Image img = null;
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
                    timeslot = reader[1].ToString();
                    patientname = reader[2].ToString();
                    ID = reader[7].ToString();
                    string appointmentstatus = reader[6].ToString();

                    img = Properties.Resources.appointmentIcon;
                    notice = patientname + n1 + "Appointment " + timeslot + n1 + "Status " + appointmentstatus;
                    string viewdate = DateTime.Now.ToString("dd") + n1 + DateTime.Now.ToString("MMM").ToUpper();
                    dgvnotices.Rows.Add(img, notice, viewdate, "appointment", ID);
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
                    timeslot = reader1[1].ToString();
                    patientname = reader1[3].ToString();
                    ID = reader1[8].ToString();
                    string vaccinationstatus = reader1[7].ToString();

                    img = Properties.Resources.vaccinationIcon;
                    notice = patientname + n1 + "Vaccination " + timeslot + n1 + "Status " + vaccinationstatus;
                    string viewdate = DateTime.Now.ToString("dd") + n1 + DateTime.Now.ToString("MMM").ToUpper();
                    dgvnotices.Rows.Add(img, notice, viewdate, "vaccination", ID);
                }
                reader1.Close();

                cmd = new SqlCommand("PaymentSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("patientname", "");
                cmd.Parameters.AddWithValue("mobile", "");
                cmd.Parameters.AddWithValue("duedate", date);
                cmd.ExecuteNonQuery();
                SqlDataReader reader2 = cmd.ExecuteReader();
                while (reader2.Read())
                {
                    patientname = reader2[1].ToString();
                    string baldue = reader2[5].ToString();
                    ID = reader2[7].ToString();
                    string paymentstatus = reader2[6].ToString();

                    img = Properties.Resources.paymentIcon;
                    notice = patientname + n1 + "Payment Bal Due - " + baldue + n1 + "Status " + paymentstatus;
                    string viewdate = DateTime.Now.ToString("dd") + n1 + DateTime.Now.ToString("MMM").ToUpper();
                    dgvnotices.Rows.Add(img, notice, viewdate, "payment", ID);
                }
                reader2.Close();

                if(dgvnotices.Rows.Count == 0)
                {
                    lbnonotices.Visible = true;
                }
                else
                {
                    lbnonotices.Visible = false;
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

        private void dgvnotices_Paint(object sender, PaintEventArgs e){}

        private void dgvnotices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvnotices.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvnotices.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvnotices.Rows[selectedrowindex];

                type = (selectedRow.Cells[3].Value).ToString();
                id = (selectedRow.Cells[4].Value).ToString();

                if(reportEvent != null)
                {
                    reportEvent(null, null);
                }
            }
        }

        private void report_VisibleChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
