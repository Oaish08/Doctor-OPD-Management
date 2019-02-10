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
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO.Compression;
using System.Threading;

namespace Doctor
{
    public partial class patient : UserControl
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        PrivateFontCollection pfc = new PrivateFontCollection();

        public event EventHandler PatientEvent;

        int personalinformation_Height;
        bool personalinformation_Hided;

        int lastvisited_Height;
        bool lastvisited_Hided;

        int newdiagnosis_Height;
        bool newdiagnosis_Hided;

        int medicalhistory_Height;
        bool medicalhistory_Hided;

        int appointmentpayment_Height;
        bool appointmentpayment_Hided;

        int selectedrowindex = -1;
        int delete_allpatientdocument = -1;

        int documentcount = 1;

        bool newdocuments = false, newmedicines = false, viewappointment = false, viewvaccination = false, viewpayment = false;

        string clinmdID = string.Empty;

        bool write = false;

        bool crm = false;

        Firebase_Class firebase;

        public bool Write
        {
            get { return this.write; }
            set { this.write = true; }
        }

        public bool CRM
        {
            get { return this.crm; }
            set { this.crm = value; }
        }

        public User_Form ParentForm { get; set; }

        public Button NewPatient
        {
            get { return this.btnnewpatient; }
        }

        public patient()
        {
            InitializeComponent();

            this.newDocument1.NewDocumentEvent += NewDocument_MyEvent;

            this.newAppointment1.NewAppointmentEvent += newAppointment_MyEvent;

            this.newVaccination1.NewVaccinationEvent += newVaccination_MyEvent;

            this.newPayment1.NewPaymentEvent += newPayment_MyEvent;

            this.confirmmessage1.ConfirmMessageEvent += confirmMessage_MyEvent;

            personalinformation_Height = panel_personalinformation.Height;
            personalinformation_Hided = true;

            lastvisited_Height = panel_lastdiagnosis.Height;
            lastvisited_Hided = true;

            newdiagnosis_Height = panel_newdiagnosis.Height;
            newdiagnosis_Hided = true;

            medicalhistory_Height = panel_medicalhistory.Height;
            medicalhistory_Hided = true;

            appointmentpayment_Height = panel_appointmentpayment.Height;
            appointmentpayment_Hided = true;

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
            foreach (Control i in panel_search.Controls)
            {
                if (i.GetType() == typeof(Label))
                {
                    i.Font = new Font(pfc.Families[0], 9);
                }
            }
            foreach (Control i in panel_Information.Controls)
            {
                if (i.GetType() == typeof(Panel))
                {
                    foreach (Control c in i.Controls)
                    {
                        if (c.GetType() == typeof(Label))
                        {
                            c.Font = new Font(pfc.Families[0], 9);
                        }
                    }
                }
            }
            lbpatients.Font = new Font(pfc.Families[0], 22);
        }

        private void Firebase_Myevent(object sender, EventArgs e)
        {
            searchData();
        }

        private void confirmMessage_MyEvent(object sender, EventArgs e)
        {
            if(newdocuments == true)
            {
                try
                {
                    string clinmdID = this.newDocument1.TempID;
                    string document = Path.GetFileNameWithoutExtension(dgvnewdiagnosisdocument.Rows[selectedrowindex].Cells[2].Value.ToString());
                    string path = Properties.Settings.Default.documentLocation + @"\Offline\";
                    File.Delete(path + Path.GetFileNameWithoutExtension(dgvnewdiagnosisdocument.Rows[selectedrowindex].Cells[2].Value.ToString()) + ".png");
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("DocumentDelete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdID);
                    cmd.Parameters.AddWithValue("@document", document);
                    cmd.ExecuteNonQuery();
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
                dgvnewdiagnosisdocument.Rows.RemoveAt(selectedrowindex);
                dgvallpatientdocument.Rows.RemoveAt(delete_allpatientdocument);
                delete_allpatientdocument = -1;
                selectedrowindex = -1;
            }
            if(newmedicines == true)
            {
                dgvnewdiagnosismedicines.Rows.RemoveAt(selectedrowindex);
                selectedrowindex = -1;
            }            
            if(viewappointment == true)
            {
                string status = string.Empty;
                string appointmentID = dgvpatientappointment.Rows[selectedrowindex].Cells[6].Value.ToString();
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("AppointmentStatusUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@appointmentID", appointmentID);
                    if (confirmmessage1.delete == true)
                    {
                        status = "cancelled";
                        cmd.Parameters.AddWithValue("@appointmentstatus", status);
                    }
                    else
                    {
                        status = "completed";
                        cmd.Parameters.AddWithValue("@appointmentstatus", status);
                    }
                    cmd.ExecuteNonQuery();
                    loadAppointment();
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
                
                confirmmessage1.delete = false;
                ParentForm.Opacity = 1;
                selectedrowindex = -1;
            }
            if(viewvaccination == true)
            {
                string status = string.Empty;
                string vaccinationID = vaccinationID = dgvpatientvaccination.Rows[selectedrowindex].Cells[7].Value.ToString(); ;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("VaccinationStatusUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vaccinationID", vaccinationID);
                    
                    if (confirmmessage1.delete == true)
                    {
                        status = "cancelled";
                        cmd.Parameters.AddWithValue("@vaccinationstatus", status);
                    }
                    else
                    {
                        status = "completed";
                        cmd.Parameters.AddWithValue("@vaccinationstatus", status);
                    }
                    cmd.ExecuteNonQuery();
                    loadVaccination();
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
               
                confirmmessage1.delete = false;
                ParentForm.Opacity = 1;
                selectedrowindex = -1;
            }
            if(viewpayment == true)
            {
                string paymentID = dgvpatientpayment.Rows[selectedrowindex].Cells[8].Value.ToString();
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    if (confirmmessage1.delete == true)
                    {
                        SqlCommand cmd = new SqlCommand("PaymentDelete", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@paymentID", paymentID);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string amtpaid = dgvpatientpayment.Rows[selectedrowindex].Cells[1].Value.ToString();
                        dgvpatientpayment.Rows[selectedrowindex].Cells[5].Value = 0;
                        string status = string.Empty;
                        status = "completed";
                        SqlCommand cmd = new SqlCommand("PaymentComplete", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@paymentID", paymentID);
                        cmd.Parameters.AddWithValue("@amtpaid", amtpaid);
                        cmd.Parameters.AddWithValue("@baldue", "0");
                        cmd.Parameters.AddWithValue("@paymentstatus", status);
                        cmd.ExecuteNonQuery();
                    }
                    loadPayment();
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
                
                confirmmessage1.delete = false;
                ParentForm.Opacity = 1;
                selectedrowindex = -1;
            }
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void newPayment_MyEvent(object sender, EventArgs e)
        {
            string firstname = newVaccination1.FirstName;
            string lastname = newVaccination1.LastName;
            string mobile = newVaccination1.Mobile;

            tbfirstname.Text = firstname;
            tblastname.Text = lastname;
            tbmobilenumber.Text = mobile;

            loadPayment();

            message1.Visible = true;
            ((Label)message1.Controls["lbmessage"]).Text = "Payment is added to Patient";

            this.newDocument1.ClinmdID = this.newPayment1.TempID;
            this.newAppointment1.ClinmdID = this.newPayment1.TempID;
            this.newVaccination1.ClinmdID = this.newPayment1.TempID;
        }

        public void loadPayment()
        {
            dgvpatientpayment.Rows.Clear();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string duedate = string.Empty;
                string amount = string.Empty;
                string amtpaid = string.Empty;
                string baldue = string.Empty;
                string paymentstatus = string.Empty;
                string paymentID = string.Empty;
                Image img = null;

                SqlCommand cmd = new SqlCommand("PatientViewData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", "Payment");
                cmd.Parameters.AddWithValue("@clinmdid", this.newPayment1.ClinmdID);
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    duedate = reader[0].ToString();
                    amount = reader[1].ToString();
                    amtpaid = reader[2].ToString();
                    baldue = reader[3].ToString();
                    paymentstatus = reader[4].ToString();
                    paymentID = reader[5].ToString();
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
                    dgvpatientpayment.Rows.Add(duedate, amount, amtpaid, baldue, img, null, Properties.Resources.cancel, paymentstatus, paymentID);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void newVaccination_MyEvent(object sender, EventArgs e)
        {
            string firstname = newVaccination1.FirstName;
            string lastname = newVaccination1.LastName;
            string gender = newVaccination1.Gender;
            string age = newVaccination1.Age;
            string mobile = newVaccination1.Mobile;

            if (firstname == "")
                firstname = "First Name";
            if (lastname == "")
                lastname = "Last Name";
            if (age == "")
                age = "Age";
            if (mobile == "NA")
                mobile = "Number";

            tbfirstname.Text = firstname;
            tblastname.Text = lastname;
            if (gender == "Male")
                rbmale.Checked = true;
            if (gender == "Female")
                rbfemale.Checked = true;
            tbage.Text = age;
            tbmobilenumber.Text = mobile;

            loadVaccination();

            message1.Visible = true;
            ((Label)message1.Controls["lbmessage"]).Text = "Vaccination is added to Patient";

            this.newDocument1.ClinmdID = this.newVaccination1.TempID;
            this.newAppointment1.ClinmdID = this.newVaccination1.TempID;
            this.newPayment1.ClinmdID = this.newVaccination1.TempID;
        }

        public void loadVaccination()
        {
            dgvpatientvaccination.Rows.Clear();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string vaccinationdate = string.Empty;
                string timeslot = string.Empty;
                string vaccinationtype = string.Empty;
                string vaccinationstatus = string.Empty;
                string vaccinationID = string.Empty;
                Image img = null;

                SqlCommand cmd = new SqlCommand("PatientViewData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", "Vaccination");
                cmd.Parameters.AddWithValue("@clinmdid", this.newVaccination1.ClinmdID);
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vaccinationdate = reader[0].ToString();
                    timeslot = reader[1].ToString();
                    vaccinationtype = reader[2].ToString();
                    vaccinationstatus = reader[3].ToString();
                    vaccinationID = reader[4].ToString();

                    if (vaccinationstatus == "today")
                        img = Properties.Resources.today;
                    else if (vaccinationstatus == "upcoming")
                        img = Properties.Resources.upcoming;
                    else if (vaccinationstatus == "completed")
                        img = Properties.Resources.completed;
                    else if (vaccinationstatus == "cancelled")
                        img = Properties.Resources.cancelled;

                    dgvpatientvaccination.Rows.Add(vaccinationdate, timeslot, vaccinationtype, img, null, Properties.Resources.cancel, vaccinationstatus, vaccinationID);
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

        private void newAppointment_MyEvent(object sender, EventArgs e)
        {
            string firstname = newAppointment1.FirstName;
            string lastname = newAppointment1.LastName;
            string gender = newAppointment1.Gender;
            string age = newAppointment1.Age;
            string mobile = newAppointment1.Mobile;

            if (firstname == "")
                firstname = "First Name";
            if (lastname == "")
                lastname = "Last Name";
            if (age == "")
                age = "Age";
            if (mobile == "NA")
                mobile = "Number";

            tbfirstname.Text = firstname;
            tblastname.Text = lastname;
            if (gender == "Male")
                rbmale.Checked = true;
            if (gender == "Female")
                rbfemale.Checked = true;
            tbage.Text = age;
            tbmobilenumber.Text = mobile;

            loadAppointment();

            message1.Visible = true;
            ((Label)message1.Controls["lbmessage"]).Text = "Appointment is added to Patient";

            this.newDocument1.ClinmdID = this.newAppointment1.TempID;
            this.newVaccination1.ClinmdID = this.newAppointment1.TempID;
            this.newPayment1.ClinmdID = this.newAppointment1.TempID;
        }

        public void loadAppointment()
        {
            Image img = null;
            dgvpatientappointment.Rows.Clear();
            try
            {
                string appointmentdate = string.Empty;
                string timeslot = string.Empty;
                string appointmentstatus = string.Empty;
                string appointmentID = string.Empty;

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("PatientViewData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", "Appointment");
                cmd.Parameters.AddWithValue("@clinmdid", this.newAppointment1.ClinmdID);
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    appointmentdate = reader[0].ToString();
                    timeslot = reader[1].ToString();
                    appointmentstatus = reader[2].ToString();
                    appointmentID = reader[3].ToString();

                    if (appointmentstatus == "today")
                        img = Properties.Resources.today;
                    else if (appointmentstatus == "upcoming")
                        img = Properties.Resources.upcoming;
                    else if (appointmentstatus == "completed")
                        img = Properties.Resources.completed;
                    else if (appointmentstatus == "cancelled")
                        img = Properties.Resources.cancelled;

                    dgvpatientappointment.Rows.Add(appointmentdate, timeslot, img, null, Properties.Resources.cancel, appointmentstatus, appointmentID);
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

        private void NewDocument_MyEvent(object sender, EventArgs e)
        {
            string ugcid = newDocument1.UGCID;
            string firstname = newDocument1.FirstName;
            string lastname = newDocument1.LastName;
            string gender = newDocument1.Gender;
            string age = newDocument1.Age;
            string mobile = newDocument1.Mobile;
            string date = newDocument1.Date;
            List<string> documentList = newDocument1.Document;

            if (ugcid == "")
                ugcid = "UGC ID";
            if (firstname == "")
                firstname = "First Name";
            if (lastname == "")
                lastname = "Last Name";
            if (age == "")
                age = "Age";
            if (mobile == "NA")
                mobile = "Number";

            tbpatientugcid.Text = ugcid;
            tbfirstname.Text = firstname;
            tblastname.Text = lastname;
            if (gender == "Male")
                rbmale.Checked = true;
            if (gender == "Female")
                rbfemale.Checked = true;
            tbage.Text = age;
            tbmobilenumber.Text = mobile;

            foreach(string document in documentList)
            {
                dgvnewdiagnosisdocument.Rows.Add("Document " + documentcount, Properties.Resources.cancel, document);
                dgvallpatientdocument.Rows.Add(null,  date, "Document " + documentcount, document);
                documentcount++;
            }

            message1.Visible = true;
            ((Label)message1.Controls["lbmessage"]).Text = "Document is added to Patient Medical History";

            this.newAppointment1.ClinmdID = this.newDocument1.TempID;
            this.newVaccination1.ClinmdID = this.newDocument1.TempID;
            this.newPayment1.ClinmdID = this.newDocument1.TempID;
        }

        private void patient_Load(object sender, EventArgs e)
        {
            panel_personalinformation.Height = 0;
            panel_lastdiagnosis.Height = 0;
            panel_newdiagnosis.Height = 0;
            panel_medicalhistory.Height = 0;
            panel_appointmentpayment.Height = 0;
            SetFontAndColors();
            tbsearchpatientname.Text = "";

            rtblastdiagnosisdiagnosis.SelectionIndent = 5;
            rtblastdiagnosisdiagnosis.BulletIndent = 5;
            rtblastdiagnosisdiagnosis.SelectionBullet = true;
            rtblastdiagnosissymptoms.SelectionIndent = 5;
            rtblastdiagnosissymptoms.BulletIndent = 5;
            rtblastdiagnosissymptoms.SelectionBullet = true;

            rtbnewdiagnosissympotms.SelectionIndent = 5;
            rtbnewdiagnosissympotms.BulletIndent = 5;
            rtbnewdiagnosissympotms.SelectionBullet = true;
            rtbnewdiagnosisdiagnosis.SelectionIndent = 5;
            rtbnewdiagnosisdiagnosis.BulletIndent = 5;
            rtbnewdiagnosisdiagnosis.SelectionBullet = true;

            searchData();
        }

        public void call_Thread()
        {
            firebase = new Firebase_Class();

            Thread thread_prescription_document = new Thread(new ThreadStart(firebase.Thread_prescriptions_documents));
            thread_prescription_document.Start();

            Thread thread_patient = new Thread(new ThreadStart(firebase.Thread_patient));
            thread_patient.Start();

            firebase.Firebase_Event += Firebase_Myevent;
        }

        private void SetFontAndColors()
        {
            dgvpatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpatient.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvpatient.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvpatient.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvlastdiagnosispage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvlastdiagnosispage.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvlastdiagnosispage.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvlastdiagnosispage.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvlastdiagnosisdocument.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvlastdiagnosisdocument.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvlastdiagnosisdocument.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvlastdiagnosisdocument.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvlastdiagnosismedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvlastdiagnosismedicine.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvlastdiagnosismedicine.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvlastdiagnosismedicine.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvnewdiagnosisdocument.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvnewdiagnosisdocument.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvnewdiagnosisdocument.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvnewdiagnosisdocument.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvnewdiagnosismedicines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvnewdiagnosismedicines.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvnewdiagnosismedicines.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvnewdiagnosismedicines.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvallpatientpage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvallpatientpage.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvallpatientpage.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvallpatientpage.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvallpatientdocument.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvallpatientdocument.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvallpatientdocument.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvallpatientdocument.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvallpatientmedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvallpatientmedicine.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvallpatientmedicine.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvallpatientmedicine.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvpatientvaccination.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpatientvaccination.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvpatientvaccination.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvpatientvaccination.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvpatientappointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpatientappointment.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvpatientappointment.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvpatientappointment.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

            dgvpatientpayment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpatientpayment.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvpatientpayment.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvpatientpayment.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
        }

        private void btnpersonalinformation_Click(object sender, EventArgs e)
        {
            timer_personalinformation.Start();
            tbpatientugcid.Focus();
            if (tbpatientugcid.Text == "")
                tbpatientugcid.Text = "UGC ID";
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void btnlastdiagnosis_Click(object sender, EventArgs e)
        {
            timer_lastdiagnosis.Start();
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void btnnewdiagnosis_Click(object sender, EventArgs e)
        {
            timer_newdiagnosis.Start();
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void btnmedicalhistory_Click_1(object sender, EventArgs e)
        {
            timer_medicalhistory.Start();
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void btnappointmentpayment_Click_1(object sender, EventArgs e)
        {
            timer_appointmentpayment.Start();
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void timersliding_Tick(object sender, EventArgs e)//timer_personalinformation
        {
            if(personalinformation_Hided)
            {
                panel_personalinformation.Height += 50;
                if(panel_personalinformation.Height >= personalinformation_Height)
                {
                    timer_personalinformation.Stop();
                    personalinformation_Hided = false;
                    btnpersonalinformation.Text = "Personal Information                                                       ^";
                    this.Refresh();
                }
            }
            else
            {
                panel_personalinformation.Height -= 50;
                if (panel_personalinformation.Height <= 0)
                {
                    timer_personalinformation.Stop();
                    personalinformation_Hided = true;
                    btnpersonalinformation.Text = "Personal Information                                                       v";
                    this.Refresh();
                }
            }
        }

        private void timer_lastdiagnosis_Tick(object sender, EventArgs e)
        {
            if (lastvisited_Hided)
            {
                panel_lastdiagnosis.Height += 50;
                if (panel_lastdiagnosis.Height >= lastvisited_Height)
                {
                    timer_lastdiagnosis.Stop();
                    lastvisited_Hided = false;
                    btnlastdiagnosis.Text = "Last Diagnosis                                                                    ^";
                    this.Refresh();
                }
            }
            else
            {
                panel_lastdiagnosis.Height -= 50;
                if (panel_lastdiagnosis.Height <= 0)
                {
                    timer_lastdiagnosis.Stop();
                    lastvisited_Hided = true;
                    btnlastdiagnosis.Text = "Last Diagnosis                                                                    v";
                    this.Refresh();
                }
            }
        }

        private void timer_newdiagnosis_Tick(object sender, EventArgs e)
        {
            if (newdiagnosis_Hided)
            {
                panel_newdiagnosis.Height += 50;
                if (panel_newdiagnosis.Height >= newdiagnosis_Height)
                {
                    timer_newdiagnosis.Stop();
                    newdiagnosis_Hided = false;
                    btnnewdiagnosis.Text = "New Diagnosis                                                                   ^";
                    this.Refresh();
                }
            }
            else
            {
                panel_newdiagnosis.Height -= 50;
                if (panel_newdiagnosis.Height <= 0)
                {
                    timer_newdiagnosis.Stop();
                    newdiagnosis_Hided = true;
                    btnnewdiagnosis.Text = "New Diagnosis                                                                   v";
                    this.Refresh();
                }
            }
        }

        private void timer_medicalhistory_Tick(object sender, EventArgs e)
        {
            if (medicalhistory_Hided)
            {
                panel_medicalhistory.Height += 50;
                if (panel_medicalhistory.Height >= medicalhistory_Height)
                {
                    timer_medicalhistory.Stop();
                    medicalhistory_Hided = false;
                    btnmedicalhistory.Text = "Medical History                                                                  ^";
                    this.Refresh();
                }
            }
            else
            {
                panel_medicalhistory.Height -= 50;
                if (panel_medicalhistory.Height <= 0)
                {
                    timer_medicalhistory.Stop();
                    medicalhistory_Hided = true;
                    btnmedicalhistory.Text = "Medical History                                                                  v";
                    this.Refresh();
                }
            }
        }

        private void timer_appointmentpayment_Tick(object sender, EventArgs e)
        {
            if (appointmentpayment_Hided)
            {
                panel_appointmentpayment.Height += 50;
                if (panel_appointmentpayment.Height >= appointmentpayment_Height)
                {
                    timer_appointmentpayment.Stop();
                    appointmentpayment_Hided = false;
                    btnappointmentpaymentvaccination.Text = "Appointment Vaccination Payment                            ^";
                    this.Refresh();
                }
            }
            else
            {
                panel_appointmentpayment.Height -= 50;
                if (panel_appointmentpayment.Height <= 0)
                {
                    timer_appointmentpayment.Stop();
                    appointmentpayment_Hided = true;
                    btnappointmentpaymentvaccination.Text = "Appointment Vaccination Payment                            v";
                    this.Refresh();
                }
            }
        }

        private void dgvpatient_Paint(object sender, PaintEventArgs e)
        {
            dgvpatient.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvpatient.GetCellDisplayRectangle(dgvpatient.Columns["Columnugcid"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvpatient.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvlastdiagnosispage_Paint(object sender, PaintEventArgs e)
        {
            dgvlastdiagnosispage.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvlastdiagnosispage.GetCellDisplayRectangle(dgvlastdiagnosispage.Columns["Columnlastvisitedpage"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvlastdiagnosispage.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvlastdiagnosisdocument_Paint(object sender, PaintEventArgs e)
        {
            dgvlastdiagnosisdocument.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvlastdiagnosisdocument.GetCellDisplayRectangle(dgvlastdiagnosisdocument.Columns["Columnlastvisiteddocument"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvlastdiagnosisdocument.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvlastdiagnosismedicine_Paint(object sender, PaintEventArgs e)
        {
            dgvlastdiagnosismedicine.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvlastdiagnosismedicine.GetCellDisplayRectangle(dgvlastdiagnosismedicine.Columns["Columnlastvisitedmedicine"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvlastdiagnosismedicine.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvnewdiagnosisdocument_Paint(object sender, PaintEventArgs e)
        {
            dgvnewdiagnosisdocument.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvnewdiagnosisdocument.GetCellDisplayRectangle(dgvnewdiagnosisdocument.Columns["Columnnewdiagnosisdocument"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvnewdiagnosisdocument.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvnewdiagnosismedicines_Paint(object sender, PaintEventArgs e)
        {
            dgvnewdiagnosismedicines.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvnewdiagnosismedicines.GetCellDisplayRectangle(dgvnewdiagnosismedicines.Columns["Columnnewdiagnosismedicnes"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvnewdiagnosismedicines.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }
        private void panel_newdiagnosis_Paint(object sender, PaintEventArgs e){}

        private void dgvallpatientpage_Paint_1(object sender, PaintEventArgs e)
        {
            dgvallpatientpage.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvallpatientpage.GetCellDisplayRectangle(dgvallpatientpage.Columns["Columnprintallpages"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvallpatientpage.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvallpatientdocument_Paint_1(object sender, PaintEventArgs e)
        {
            dgvallpatientdocument.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvallpatientdocument.GetCellDisplayRectangle(dgvallpatientdocument.Columns["Columnprintalldocument"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvallpatientdocument.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvallpatientmedicine_Paint_1(object sender, PaintEventArgs e)
        {
            dgvallpatientmedicine.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvallpatientmedicine.GetCellDisplayRectangle(dgvallpatientmedicine.Columns["Columnallmedicine"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvallpatientmedicine.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvpatientappointment_Paint_1(object sender, PaintEventArgs e)
        {
            dgvpatientappointment.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvpatientappointment.GetCellDisplayRectangle(dgvpatientappointment.Columns["Columnappointmentdate"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvpatientappointment.Columns["<Column>"];
            Color cl;
            cl = dgvpatientappointment.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvpatientvaccination_Paint_1(object sender, PaintEventArgs e)
        {
            dgvpatientvaccination.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvpatientvaccination.GetCellDisplayRectangle(dgvpatientvaccination.Columns["Columnvaccinationdate"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvpatientvaccination.Columns["<Column>"];
            Color cl;
            cl = dgvpatient.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void dgvpatientpayment_Paint_1(object sender, PaintEventArgs e)
        {

            dgvpatientpayment.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dgvpatientpayment.GetCellDisplayRectangle(dgvpatientpayment.Columns["Columnduedate"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width - 2;
            headerRect.Y += 1;
            headerRect.Width = 2 * 2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dgvpatientpayment.Columns["<Column>"];
            Color cl;
            cl = dgvpatientpayment.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);
        }

        private void tbsearchpatientname_Click(object sender, EventArgs e)
        {
            if (tbsearchpatientname.Text == "Name")
                tbsearchpatientname.Text = "";
            tbsearchlastvisiteddate.Enabled = true;
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
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
            tbsearchlastvisiteddate.Enabled = true;
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
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
                tbsearchmobile.Text = "Number";
        }

        private void tbsearchugcid_Click(object sender, EventArgs e)
        {
            if (tbsearchugcid.Text == "UGC ID")
                tbsearchugcid.Text = "";
            tbsearchlastvisiteddate.Enabled = true;
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void tbsearchugcid_Leave(object sender, EventArgs e)
        {
            if (tbsearchugcid.Text == "")
                tbsearchugcid.Text = "UGC ID";
        }

        private void tbsearchlastvisiteddate_Click(object sender, EventArgs e)
        {
            if(tbsearchlastvisiteddate.Text == "Select Date")
                tbsearchlastvisiteddate.Text = "";
            calenderlastvisiteddate.Visible = true;
            tbsearchlastvisiteddate.Enabled = false;
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void tbsearchlastvisiteddate_TextChanged(object sender, EventArgs e)
        {
            calenderlastvisiteddate.Visible = true;
            calenderlastvisiteddate.Focus();
        }

        private void calenderlastvisiteddate_DateSelected(object sender, DateRangeEventArgs e)
        {
            tbsearchlastvisiteddate.Text = calenderlastvisiteddate.SelectionStart.ToString("dd-MMM-yyyy");
            calenderlastvisiteddate.Visible = false;
            tbsearchlastvisiteddate.Enabled = true;
        }

        private void calenderlastvisiteddate_Leave(object sender, EventArgs e)
        {
            if (tbsearchlastvisiteddate.Text == "")
                tbsearchlastvisiteddate.Text = "Select Date";
            calenderlastvisiteddate.Visible = false;
            tbsearchlastvisiteddate.Enabled = true;
        }

        private void calenderlastvisiteddate_MouseLeave(object sender, EventArgs e)
        {
            if (tbsearchlastvisiteddate.Text == "")
                tbsearchlastvisiteddate.Text = "Select Date";
            calenderlastvisiteddate.Visible = false;
            tbsearchlastvisiteddate.Enabled = true;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearData();

            searchData();
        }

        private void tbpatientugcid_Click(object sender, EventArgs e)
        {
            if (tbpatientugcid.Text == "UGC ID")
                tbpatientugcid.Text = "";
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void tbpatientugcid_Leave(object sender, EventArgs e)
        {
            if (tbpatientugcid.Text == "")
                tbpatientugcid.Text = "UGC ID";
        }

        private void tbfirstname_Click(object sender, EventArgs e)
        {
            if (tbfirstname.Text == "First Name")
                tbfirstname.Text = "";
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
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
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void tblastname_Leave(object sender, EventArgs e)
        {
            if (tblastname.Text == "")
                tblastname.Text = "Last Name";
        }

        private void rbmale_Click(object sender, EventArgs e)
        {
            rbmale.Checked = true;
            rbfemale.Checked = false;
        }

        private void rbfemale_Click(object sender, EventArgs e)
        {
            rbmale.Checked = false;
            rbfemale.Checked = true;
        }

        private void tbage_Click(object sender, EventArgs e)
        {
            if (tbage.Text == "Age")
                tbage.Text = "";
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
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
            ParentForm.Opacity = 1;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
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

        private void button1_Click(object sender, EventArgs e)//btnaddprescription
        {
            ParentForm.PBdrawing.Visible = true;
        }

        private void btnadddocument_Click(object sender, EventArgs e)
        {
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newDocument1.Controls["tbdocuments"]).Focus();
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newDocument1.Controls["tbugcid"]).Text = tbpatientugcid.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newDocument1.Controls["tbfirstname"]).Text = tbfirstname.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newDocument1.Controls["tblastname"]).Text = tblastname.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newDocument1.Controls["tbage"]).Text = tbage.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newDocument1.Controls["tbmobilenumber"]).Text = tbmobilenumber.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newDocument1.Controls["tbdate"]).Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if(rbmale.Checked == true)
                ((MaterialSkin.Controls.MaterialRadioButton)this.newDocument1.Controls["rbmale"]).Checked = true;
            if(rbfemale.Checked == true)
                ((MaterialSkin.Controls.MaterialRadioButton)this.newDocument1.Controls["rbfemale"]).Checked = true;
            ((MonthCalendar)this.newDocument1.Controls["calenderdate"]).SetDate(DateTime.Now);
             ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newDocument1.Controls["tbdocuments"]).Text = "";
            ((Label)this.newDocument1.Controls["lberror"]).Visible = false;
            
            newDocument1.Visible = true;
            ParentForm.Opacity = 0.92;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void newDocument1_Leave(object sender, EventArgs e)
        {
            newDocument1.Visible = false;
        }

        private void btnaddappointment_Click(object sender, EventArgs e)
        {
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Focus();
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Text = tbfirstname.Text;
            if (tbfirstname.Text == "First Name")
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Text = "";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tblastname"]).Text = tblastname.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbage"]).Text = tbage.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbmobilenumber"]).Text = tbmobilenumber.Text;
            if (rbmale.Checked == true)
                ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbmale"]).Checked = true;
            if (rbfemale.Checked == true)
                ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbfemale"]).Checked = true;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbdate"]).Text = "Select Date";
            ((MonthCalendar)this.newAppointment1.Controls["calenderdate"]).SetDate(DateTime.Now);
            ((ComboBox)this.newAppointment1.Controls["cbtimeslot"]).SelectedIndex = 0;
            ((Label)this.newAppointment1.Controls["lberror"]).Visible = false;
            this.newAppointment1.AppointmentID = "0";
            newAppointment1.Visible = true;
            ParentForm.Opacity = 0.92;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void newAppointment1_Leave(object sender, EventArgs e)
        {
            newAppointment1.Visible = false;
        }

        private void btnaddvaccination_Click(object sender, EventArgs e)
        {
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Focus();
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Text = tbfirstname.Text;
            if (tbfirstname.Text == "First Name")
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Text = "";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tblastname"]).Text = tblastname.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbage"]).Text = tbage.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbmobilenumber"]).Text = tbmobilenumber.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbdate"]).Text = "Select Date";
            ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbmale"]).Checked = false;
            ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbfemale"]).Checked = false;
            ((MonthCalendar)this.newVaccination1.Controls["calenderdate"]).SetDate(DateTime.Now);
            ((ComboBox)this.newVaccination1.Controls["cbtimeslot"]).SelectedIndex = 0;
            ((ComboBox)this.newVaccination1.Controls["cbvaccinationtype"]).SelectedIndex = 0;
            ((Label)this.newVaccination1.Controls["lberror"]).Visible = false;
            this.newVaccination1.VaccinationID = "0";
            newVaccination1.Visible = true;
            ParentForm.Opacity = 0.92;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void newVaccination1_Leave(object sender, EventArgs e)
        {
            newVaccination1.Visible = false;
        }

        private void btnaddpayment_Click(object sender, EventArgs e)
        {
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Focus();
            ((Label)this.newPayment1.Controls["lberror"]).Visible = false;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbduedate"]).Text = "Select Date";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Text = tbfirstname.Text;
            if (tbfirstname.Text == "First Name")
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Text = "";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tblastname"]).Text = tblastname.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbmobilenumber"]).Text = tbmobilenumber.Text;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbamt"]).Text = "0.0";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbamtpaid"]).Text = "0.0";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbmoreamtpaid"]).Visible = false;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbbaldue"]).Text = "0.0";
            ((MonthCalendar)this.newPayment1.Controls["calenderduedate"]).SetDate(DateTime.Now);
            this.newPayment1.PaymentID = "0";
            newPayment1.Visible = true;
            ParentForm.Opacity = 0.92;
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void newPayment1_Leave(object sender, EventArgs e)
        {
            newPayment1.Visible = false;
        }

        private void message1_Leave(object sender, EventArgs e)
        {
            message1.Visible = false;
            ParentForm.Opacity = 1;
        }

        private void message1_VisibleChanged(object sender, EventArgs e)
        {
            if (message1.Visible == true)
                this.ParentForm.Opacity = 0.92;
        }

        private void dgvnewdiagnosisdocument_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvnewdiagnosisdocument.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvnewdiagnosisdocument.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvnewdiagnosisdocument.Rows[selectedrowindex];

                List<string> path = new List<string>();
                List<string> date = new List<string>();
                foreach (DataGridViewRow row in dgvnewdiagnosisdocument.Rows)
                {
                    path.Add((row.Cells[2].Value).ToString());
                    date.Add("Today");
                }

                ParentForm.Opacity = 0.80;
                Image_Form obj = new Image_Form(path, selectedrowindex, date);
                obj.Show();
                obj.imageEvent += Image_MyEvent;
            }
        }

        private void Image_MyEvent(object sender, EventArgs e)
        {
            ParentForm.Opacity = 1;
        }

        private void dgvnewdiagnosisdocument_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex < dgvnewdiagnosisdocument.SelectedCells.Count)
            {
                selectedrowindex = dgvnewdiagnosisdocument.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvnewdiagnosisdocument.Rows[selectedrowindex];

                string document = (selectedRow.Cells[0].Value).ToString();
                foreach(DataGridViewRow row in dgvallpatientdocument.Rows)
                {
                    if((row.Cells[2].Value).ToString() == document)
                    {
                        delete_allpatientdocument = row.Index;
                    }
                }
                confirmmessage1.Visible = true;
                ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to Delete?";
                ParentForm.Opacity = 0.92;
                newdocuments = true;
            }
        }

        private void confirmmessage1_Leave(object sender, EventArgs e)
        {
            ParentForm.Opacity = 1;
        }

        private void btnnumofmedicines_Click(object sender, EventArgs e)//tbnumofmedicines
        {
            if (tbnumofmedicines.Text == "Number")
                tbnumofmedicines.Text = "";
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void btnnumofmedicines_Leave(object sender, EventArgs e)//tbnumofmedicines
        {
            if (tbnumofmedicines.Text == "")
                tbnumofmedicines.Text = "Number";
        }

        private void tbnumofmedicines_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnnumofmedicinesok_Click(object sender, EventArgs e)
        {
            if(tbnumofmedicines.Text != "" && tbnumofmedicines.Text != "Number")
            {
                dgvnewdiagnosismedicines.Rows.Clear();
                for (int i = 0; i < Convert.ToInt32(tbnumofmedicines.Text); i++)
                {
                    dgvnewdiagnosismedicines.Rows.Add("Name", "Select", "Number", "Select");
                }             
            }
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
        }

        private void dgvnewdiagnosismedicines_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string titleText = dgvnewdiagnosismedicines.Columns[0].HeaderText;
            try
            {
                if (titleText.Equals("Medicine"))
                {
                    TextBox autoText = e.Control as TextBox;
                    if (autoText != null)
                    {
                        autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                        autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "select name from Table_Medicine";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DataCollection.Add(reader[0].ToString());
                        }
                        reader.Close();
                        autoText.AutoCompleteCustomSource = DataCollection;
                    }
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

        private void dgvnewdiagnosismedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex < dgvnewdiagnosismedicines.SelectedCells.Count)
            {
                selectedrowindex = dgvnewdiagnosismedicines.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvnewdiagnosismedicines.Rows[selectedrowindex];

                confirmmessage1.Visible = true;
                ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to Delete?";
                ParentForm.Opacity = 0.92;
                newmedicines = true;
            }
        }

        private void cbselectallpage_CheckedChanged(object sender, EventArgs e)
        {
            if(cbselectallpage.Checked == true)
            {
                for (int i = 0; i < dgvallpatientpage.Rows.Count; i++)
                {
                    dgvallpatientpage.Rows[i].Cells[0].Value = true;
                }
            }
            if (cbselectallpage.Checked == false)
            {
                for (int i = 0; i < dgvallpatientpage.Rows.Count; i++)
                {
                    dgvallpatientpage.Rows[i].Cells[0].Value = false;
                }
            }
        }

        private void cbselectalldocument_CheckedChanged(object sender, EventArgs e)
        {
            if (cbselectalldocument.Checked == true)
            {
                for(int i = 0; i<dgvallpatientdocument.Rows.Count;i++)
                {
                    dgvallpatientdocument.Rows[i].Cells[0].Value = true;
                }
            }
            if (cbselectalldocument.Checked == false)
            {
                for (int i = 0; i < dgvallpatientdocument.Rows.Count; i++)
                {
                    dgvallpatientdocument.Rows[i].Cells[0].Value = false;
                }
            }
        }

        private void dgvallpatientdocument_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvallpatientdocument.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvallpatientdocument.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvallpatientdocument.Rows[selectedrowindex];

                List<string> path = new List<string>();
                List<string> date = new List<string>();
                foreach (DataGridViewRow row in dgvallpatientdocument.Rows)
                {
                    path.Add((row.Cells[3].Value).ToString());
                    if ((row.Cells[1].Value).ToString() == DateTime.Now.ToString("dd-MMM-yyyy"))
                        date.Add("Today");
                    else
                        date.Add((row.Cells[1].Value).ToString());
                }

                ParentForm.Opacity = 0.80;
                Image_Form obj = new Image_Form(path, selectedrowindex, date);
                obj.Show();
                obj.imageEvent += Image_MyEvent;
            }
        }

        private void dgvallpatientpage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvallpatientpage.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvallpatientpage.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvallpatientpage.Rows[selectedrowindex];

                List<string> path = new List<string>();
                List<string> date = new List<string>();
                foreach (DataGridViewRow row in dgvallpatientpage.Rows)
                {
                    path.Add((row.Cells[3].Value).ToString());
                    if ((row.Cells[1].Value).ToString() == DateTime.Now.ToString("dd-MMM-yyyy"))
                        date.Add("Today");
                    else
                        date.Add((row.Cells[1].Value).ToString());
                }

                ParentForm.Opacity = 0.80;
                Image_Form obj = new Image_Form(path, selectedrowindex, date);
                obj.Show();
                obj.imageEvent += Image_MyEvent;
                obj.imageChangeEvent += ChangeImage_MyEvent;
            }
        }

        private void btnsavemedicalrecords_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string pathDocument = folderBrowser.SelectedPath + @"ClinMD\" + tbfirstname.Text + tblastname.Text + @"\Document\";
                string pathPrescription = folderBrowser.SelectedPath + @"ClinMD\" + tbfirstname.Text + tblastname.Text + @"\Prescription\";

                for (int i = 0; i < dgvallpatientdocument.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvallpatientdocument.Rows[i].Cells[0].Value) == true)
                    {
                        try
                        {
                            string date = dgvallpatientdocument.Rows[i].Cells[1].Value.ToString();
                            if (!Directory.Exists(pathDocument))
                                Directory.CreateDirectory(pathDocument);
                            File.Copy(dgvallpatientdocument.Rows[i].Cells[3].Value.ToString(), pathDocument + date + ", " + Path.GetFileNameWithoutExtension(dgvallpatientdocument.Rows[i].Cells[3].Value.ToString()) + ".png");
                            PdfHelper.Instance.SaveImageAsPdf(pathDocument + date + ", " + Path.GetFileNameWithoutExtension(dgvallpatientdocument.Rows[i].Cells[3].Value.ToString()) + ".png", pathDocument + date + ", " + Path.GetFileNameWithoutExtension(dgvallpatientdocument.Rows[i].Cells[3].Value.ToString()) + ".pdf", 1000, true);
                        }
                        catch(Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    }
                }

                for (int i = 0; i < dgvallpatientpage.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvallpatientpage.Rows[i].Cells[0].Value) == true)
                    {
                        if(dgvallpatientpage.Rows[i].Cells[3].Value.ToString() != "NA")
                        {
                            try
                            {
                                string date = dgvallpatientpage.Rows[i].Cells[1].Value.ToString();
                                if (!Directory.Exists(pathPrescription))
                                    Directory.CreateDirectory(pathPrescription);
                                File.Copy(dgvallpatientpage.Rows[i].Cells[3].Value.ToString(), pathPrescription + date + ", " + Path.GetFileNameWithoutExtension(dgvallpatientpage.Rows[i].Cells[3].Value.ToString()) + ".png");
                                PdfHelper.Instance.SaveImageAsPdf(pathPrescription + date + ", " + Path.GetFileNameWithoutExtension(dgvallpatientpage.Rows[i].Cells[3].Value.ToString()) + ".png", pathPrescription + date + ", " + Path.GetFileNameWithoutExtension(dgvallpatientpage.Rows[i].Cells[3].Value.ToString()) + ".pdf", 1000, true);
                            }
                            catch(Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                }

                Process.Start(folderBrowser.SelectedPath + @"\ClinMD");
            }

            for (int i = 0; i < dgvallpatientpage.Rows.Count; i++)
            {
                dgvallpatientpage.Rows[i].Cells[0].Value = false;
            }
            for (int i = 0; i < dgvallpatientdocument.Rows.Count; i++)
            {
                dgvallpatientdocument.Rows[i].Cells[0].Value = false;
            }

            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
            cbselectallpage.Checked = false;
            cbselectalldocument.Checked = false;
        }

        private void dgvpatientappointment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvpatientappointment.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvpatientappointment.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvpatientappointment.Rows[selectedrowindex];

                string date = (selectedRow.Cells[0].Value).ToString();
                string time = (selectedRow.Cells[1].Value).ToString();
                string firstname = tbfirstname.Text;
                string lastname = tblastname.Text;
                string gender = string.Empty;
                string age = tbage.Text;
                string mobile = tbmobilenumber.Text;
                string appointmentID = (selectedRow.Cells[6].Value).ToString();

                this.newAppointment1.Visible = false;
                ParentForm.Opacity = 1;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Focus();

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbdate"]).Text = date;
                ((ComboBox)this.newAppointment1.Controls["cbtimeslot"]).SelectedItem = time;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbfirstname"]).Text = firstname;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tblastname"]).Text = lastname;

                if (rbmale.Checked == true)
                    gender = "Male";
                if (rbfemale.Checked == true)
                    gender = "Female";

                if (gender == "Male")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbmale"]).Checked = true;
                }
                if (gender == "Female")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newAppointment1.Controls["rbfemale"]).Checked = true;
                }

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbage"]).Text = age;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newAppointment1.Controls["tbmobilenumber"]).Text = mobile;
                
                ((Label)this.newAppointment1.Controls["lberror"]).Visible = false;

                this.newAppointment1.AppointmentID = appointmentID;
                this.newAppointment1.ClinmdID = clinmdID;

                ParentForm.Opacity = 0.92;

                newAppointment1.Focus();
                newAppointment1.Visible = true;
            }
        }

        private void dgvpatientappointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
            if (e.ColumnIndex == 3 && e.RowIndex < dgvpatientappointment.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientappointment.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientappointment.Rows[selectedrowindex];

                string patientname = string.Empty;
                if (tbfirstname.Text != "First Name")
                    patientname = tbfirstname.Text;
                if(tblastname.Text != "Last Name")
                    patientname = patientname + " " + tblastname.Text;
                string status = (selectedRow.Cells[5].Value).ToString();
                if (status != "completed" && status != "cancelled")
                {
                    confirmmessage1.Visible = true;
                    ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to complete appointment of patient " + patientname + " ?";
                    ParentForm.Opacity = 0.92;
                    viewappointment = true;
                }
            }
            if (e.ColumnIndex == 4 && e.RowIndex < dgvpatientappointment.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientappointment.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientappointment.Rows[selectedrowindex];

                string patientname = string.Empty;
                if (tbfirstname.Text != "First Name")
                    patientname = tbfirstname.Text;
                if (tblastname.Text != "Last Name")
                    patientname = patientname + " " + tblastname.Text;
                string status = (selectedRow.Cells[5].Value).ToString();

                if (status != "completed" && status != "cancelled")
                {
                    confirmmessage1.Visible = true;
                    ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to cancel appointment of patient " + patientname + " ?";
                    confirmmessage1.delete = true;
                    ParentForm.Opacity = 0.92;
                    viewappointment = true;
                }
            }
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
                string firstname = tbfirstname.Text;
                string lastname = tblastname.Text;
                string gender = string.Empty;
                string age = tbage.Text;
                string mobile = tbmobilenumber.Text;
                string vaccinationID = (selectedRow.Cells[7].Value).ToString();

                this.newVaccination1.Visible = false;
                ParentForm.Opacity = 1;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Focus();

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbdate"]).Text = date;
                ((ComboBox)this.newVaccination1.Controls["cbtimeslot"]).SelectedItem = time;
                ((ComboBox)this.newVaccination1.Controls["cbvaccinationtype"]).SelectedItem = vaccination;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbfirstname"]).Text = firstname;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tblastname"]).Text = lastname;

                if (rbmale.Checked == true)
                    gender = "Male";
                if (rbfemale.Checked == true)
                    gender = "Female";

                if (gender == "Male")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbmale"]).Checked = true;
                }
                if (gender == "Female")
                {
                    ((MaterialSkin.Controls.MaterialRadioButton)this.newVaccination1.Controls["rbfemale"]).Checked = true;
                }

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbage"]).Text = age;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newVaccination1.Controls["tbmobilenumber"]).Text = mobile;
                
                ((Label)this.newVaccination1.Controls["lberror"]).Visible = false;
                this.newVaccination1.VaccinationID = vaccinationID;
                this.newVaccination1.ClinmdID = clinmdID;

                ParentForm.Opacity = 0.92;

                newVaccination1.Focus();
                newVaccination1.Visible = true;
            }
        }

        private void dgvpatientvaccination_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
            if (e.ColumnIndex == 4 && e.RowIndex < dgvpatientvaccination.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientvaccination.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientvaccination.Rows[selectedrowindex];

                string patientname = string.Empty;
                if (tbfirstname.Text != "First Name")
                    patientname = tbfirstname.Text;
                if (tblastname.Text != "Last Name")
                    patientname = patientname + " " + tblastname.Text;

                string status = (selectedRow.Cells[6].Value).ToString();
                if (status != "completed" && status != "cancelled")
                {
                    confirmmessage1.Visible = true;
                    ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to complete appointment of patient " + patientname + " ?";
                    ParentForm.Opacity = 0.92;
                }
            }
            if (e.ColumnIndex == 5 && e.RowIndex < dgvpatientvaccination.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientvaccination.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientvaccination.Rows[selectedrowindex];

                string patientname = string.Empty;
                if (tbfirstname.Text != "First Name")
                    patientname = tbfirstname.Text;
                if (tblastname.Text != "Last Name")
                    patientname = patientname + " " + tblastname.Text;

                string status = (selectedRow.Cells[6].Value).ToString();

                if (status != "completed" && status != "cancelled")
                {
                    confirmmessage1.Visible = true;
                    ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to cancel appointment of patient " + patientname + " ?";
                    confirmmessage1.delete = true;
                    ParentForm.Opacity = 0.92;
                }
            }
            viewvaccination = true;
        }

        private void dgvpatientpayment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvpatientpayment.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvpatientpayment.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvpatientpayment.Rows[selectedrowindex];

                string duedate = (selectedRow.Cells[0].Value).ToString();
                string firstname = tbfirstname.Text;
                string lastname = tblastname.Text;
                string mobile = tbmobilenumber.Text;
                string amount = (selectedRow.Cells[1].Value).ToString();
                string amtpaid = (selectedRow.Cells[2].Value).ToString();
                string baldue = (selectedRow.Cells[3].Value).ToString();
                string paymentID = (selectedRow.Cells[8].Value).ToString();

                this.newPayment1.Visible = false;
                ParentForm.Opacity = 1;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Focus();

                if (duedate != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbduedate"]).Text = duedate;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbduedate"]).Text = "Select Date";

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Text = firstname;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tblastname"]).Text = lastname;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbmobilenumber"]).Text = mobile;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbamt"]).Text = amount;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbamtpaid"]).Text = amtpaid;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbbaldue"]).Text = baldue;

                ((Label)this.newPayment1.Controls["lberror"]).Visible = false;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbmoreamtpaid"]).Visible = false;
                this.newPayment1.PaymentID = paymentID;
                this.newPayment1.ClinmdID = clinmdID;

                ParentForm.Opacity = 0.92;

                newPayment1.Focus();
                newPayment1.Visible = true;
            }
        }

        private void dgvpatientpayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
            if (e.ColumnIndex == 5 && e.RowIndex < dgvpatientpayment.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientpayment.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientpayment.Rows[selectedrowindex];

                string patientname = string.Empty;
                if (tbfirstname.Text != "First Name")
                    patientname = tbfirstname.Text;
                if (tblastname.Text != "Last Name")
                    patientname = patientname + " " + tblastname.Text;
                string baldue = (selectedRow.Cells[3].Value).ToString();
                string status = (selectedRow.Cells[7].Value).ToString();

                if ((status != "completed" && status != "unknown") || (status == "unknown" && (baldue != "0" && baldue != "0.0")))
                {
                    confirmmessage1.Visible = true;
                    ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to complete payment of patient " + patientname + " ?";
                    ParentForm.Opacity = 0.92;
                }
            }
            if (e.ColumnIndex == 6 && e.RowIndex < dgvpatientpayment.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientpayment.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientpayment.Rows[selectedrowindex];

                string patientname = string.Empty;
                if (tbfirstname.Text != "First Name")
                    patientname = tbfirstname.Text;
                if (tblastname.Text != "Last Name")
                    patientname = patientname + " " + tblastname.Text;
                string baldue = (selectedRow.Cells[3].Value).ToString();
                string status = (selectedRow.Cells[7].Value).ToString();

                confirmmessage1.Visible = true;
                ((Label)confirmmessage1.Controls["lbmessage"]).Text = "Are you Sure you want to delete payment of patient " + patientname + " ?";
                confirmmessage1.delete = true;
                ParentForm.Opacity = 0.92;
            }
            viewpayment = true;
        }

        private void btnsavepatient_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (PatientEvent != null)
                {
                    PatientEvent(null, null);
                }

                insertData();
            }
            else
            {
                clearData();
            }
             
        }

        private void btnnewpatient_Click(object sender, EventArgs e)
        {
            if (personalinformation_Hided)
                timer_personalinformation.Start();

            DialogResult result = MessageBox.Show("Do you want to save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (write == true)
                {
                    if (PatientEvent != null)
                    {
                        PatientEvent(null, null);
                    }
                }
                else
                {
                    Properties.Settings.Default.page += 1;
                    Properties.Settings.Default.Save();
                }

                insertData();
            }
            else
            {
                clearData();
            }
        }

        public void insertData()
        {
            string ugcId = tbpatientugcid.Text.ToUpper().Trim();
            string firstname = tbfirstname.Text.ToUpper().Trim();
            string lastname = tblastname.Text.ToUpper().Trim();
            string gender = string.Empty;
            string age = tbage.Text.ToUpper().Trim();
            string mobile = tbmobilenumber.Text.ToUpper().Trim();
            string diagnose = csvForm(rtbnewdiagnosisdiagnosis.Text);
            string symptoms = csvForm(rtbnewdiagnosissympotms.Text);
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
            if (diagnose == "")
                diagnose = "NA";
            if (symptoms == "")
                symptoms = "NA";
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd;

                string tempID = this.newDocument1.TempID;
                tempID = this.newAppointment1.TempID;
                tempID = this.newVaccination1.TempID;
                tempID = this.newPayment1.TempID;

                if (tempID == "")
                {
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
                }


                string location = string.Empty;

                if(write)
                {
                    string path = Properties.Settings.Default.prescriptionLocation + @"\Offline\";
                    location = path + Properties.Settings.Default.page + ".png";
                }
                else
                {
                    location = "NA";
                }

                int crm_value = 0;

                if (crm)
                    crm_value = 1;
                else
                    crm_value = 0;

                cmd = new SqlCommand("PatientPage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "Insert");
                cmd.Parameters.AddWithValue("@pageid", "0");
                cmd.Parameters.AddWithValue("@clinmdID", tempID);
                cmd.Parameters.AddWithValue("@page", Properties.Settings.Default.page);
                cmd.Parameters.AddWithValue("@diagnose", diagnose);
                cmd.Parameters.AddWithValue("@symptoms", symptoms);
                cmd.Parameters.AddWithValue("@timestamp", datetime);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@transcribed", "0");
                cmd.Parameters.AddWithValue("@CRM", crm_value);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("LastVisitedPage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clinmdid", tempID);
                cmd.Parameters.AddWithValue("@page", Properties.Settings.Default.page);
                cmd.ExecuteNonQuery();

                foreach (DataGridViewRow rows in dgvnewdiagnosismedicines.Rows)
                {
                    string name = rows.Cells[0].Value.ToString();
                    string time = rows.Cells[1].Value.ToString();
                    string day = rows.Cells[2].Value.ToString();
                    string additional = rows.Cells[3].Value.ToString();

                    if (name == "Name" || name == "")
                        name = "NA";
                    if (time == "Select")
                        time = "NA";
                    if (day == "" || day == "Number")
                        day = "NA";
                    if (additional == "Select")
                        additional = "NA";
                    
                    cmd = new SqlCommand("PatientMedicine", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@medicineID", "0");
                    cmd.Parameters.AddWithValue("@page", Properties.Settings.Default.page);
                    cmd.Parameters.AddWithValue("@clinmdID", tempID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@additional", additional);
                    cmd.Parameters.AddWithValue("@transcribed", "0");
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

            clearData();
        }

        public string csvForm(string Main)
        {
            string csv = string.Empty;
            foreach (char c in Main)
            {
                if (c != '\n')
                {
                    csv += c.ToString();
                }
                else
                    csv += ',';
            }
            return csv;
        }

        public string CSVToNormal(string Main)
        {
            string normal = string.Empty;
            foreach (char c in Main)
            {
                if (c != ',')
                {
                    normal += c.ToString();
                }
                else
                    normal += '\n';
            }
            return normal;
        }

        public void clearData()
        {
            if (Properties.Settings.Default.firebase_upload == false && Properties.Settings.Default.firebase_download == false)
            {
                Firebase_Class obj = new Firebase_Class();
                obj.prescriptions_documents();
            }

            write = false;
            crm = false;
            ParentForm.PBdrawing.Image = Image.FromFile(Properties.Settings.Default.prescriptionPage);

            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
            selectedrowindex = -1;
            ParentForm.Opacity = 1;

            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";
            tbsearchugcid.Text = "UGC ID";
            tbsearchlastvisiteddate.Text = "Select Date";
            tbsearchlastvisiteddate.Enabled = true;

            clinmdID = string.Empty;
            newDocument1.ClinmdID = string.Empty;
            tbpatientugcid.Focus();
            tbpatientugcid.Text = "";
            tbfirstname.Text = "First Name";
            tblastname.Text = "Last Name";
            rbmale.Checked = false;
            rbfemale.Checked = false;
            tbage.Text = "Age";
            tbmobilenumber.Text = "Number";

            dgvlastdiagnosispage.Rows.Clear();
            dgvlastdiagnosisdocument.Rows.Clear();
            dgvlastdiagnosismedicine.Rows.Clear();
            rtblastdiagnosisdiagnosis.Text = "";
            rtblastdiagnosissymptoms.Text = "";

            dgvnewdiagnosisdocument.Rows.Clear();
            dgvnewdiagnosismedicines.Rows.Clear();
            rtbnewdiagnosisdiagnosis.Text = "";
            rtbnewdiagnosissympotms.Text = "";
            tbnumofmedicines.Text = "Number";

            dgvallpatientpage.Rows.Clear();
            dgvallpatientdocument.Rows.Clear();
            dgvallpatientmedicine.Rows.Clear();

            dgvpatientappointment.Rows.Clear();
            dgvpatientvaccination.Rows.Clear();
            dgvpatientpayment.Rows.Clear();

            searchData();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            searchData();   
        }

        public void searchData()
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.searchData));
            }
            else
            {
                dgvpatient.Rows.Clear();

                string ugcid = string.Empty;
                string lastvisited = string.Empty;
                string patientname = string.Empty;
                string mobile = string.Empty;
                string clinmdid = string.Empty;

                string searchname = tbsearchpatientname.Text.Trim();
                string searchmobile = tbsearchmobile.Text.Trim();
                string searchugcid = tbsearchugcid.Text.Trim();
                string searchlastvisited = tbsearchlastvisiteddate.Text.Trim();

                if (searchname == "Name")
                    searchname = "";
                if (searchmobile == "Number")
                    searchmobile = "";
                if (searchugcid == "UGC ID")
                    searchugcid = "";
                if (searchlastvisited == "Select Date")
                    searchlastvisited = "";

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("PatientSearch", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", searchname);
                    cmd.Parameters.AddWithValue("@mobile", searchmobile);
                    cmd.Parameters.AddWithValue("@ugcid", searchugcid);
                    cmd.Parameters.AddWithValue("@lastvisited", searchlastvisited);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ugcid = reader[0].ToString();
                        lastvisited = reader[1].ToString();
                        patientname = reader[2].ToString() + " " + reader[3].ToString();
                        mobile = reader[4].ToString();
                        clinmdid = reader[5].ToString();

                        if (ugcid == "NA" && patientname == "NA NA" && mobile == "NA")
                        {
                            patientname = "Page " + reader[6].ToString();
                        }
                        dgvpatient.Rows.Add(ugcid, lastvisited, patientname, mobile, null, clinmdid);
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

        private void dgvpatient_Click(object sender, EventArgs e)
        {
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
            selectedrowindex = -1;
            ParentForm.Opacity = 1;
        }

        private void dgvlastdiagnosispage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvlastdiagnosispage.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvlastdiagnosispage.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvlastdiagnosispage.Rows[selectedrowindex];

                List<string> path = new List<string>();
                List<string> date = new List<string>();
                foreach (DataGridViewRow row in dgvlastdiagnosispage.Rows)
                {
                    path.Add((row.Cells[1].Value).ToString());
                    if ((row.Cells[2].Value).ToString() == DateTime.Now.ToString("dd-MMM-yyyy"))
                        date.Add("Today");
                    else
                        date.Add((row.Cells[2].Value).ToString());
                }

                ParentForm.Opacity = 0.80;
                Image_Form obj = new Image_Form(path, selectedrowindex, date);
                obj.Show();
                obj.imageEvent += Image_MyEvent;
                obj.imageChangeEvent += ChangeImage_MyEvent;
            }
        }

        private void ChangeImage_MyEvent(object sender)
        {
            try
            {
                ParentForm.PBdrawing.Image = Image.FromFile((sender).ToString());
            }
            catch(Exception ex)
            {
                ParentForm.PBdrawing.Image = Image.FromFile(Properties.Settings.Default.prescriptionPage);
            }
            ParentForm.PBdrawing.Visible = true;
            ParentForm.Opacity = 0.96;
        }

        private void dgvlastdiagnosisdocument_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvlastdiagnosisdocument.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvlastdiagnosisdocument.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvlastdiagnosisdocument.Rows[selectedrowindex];

                List<string> path = new List<string>();
                List<string> date = new List<string>();
                foreach (DataGridViewRow row in dgvlastdiagnosisdocument.Rows)
                {
                    path.Add((row.Cells[1].Value).ToString());
                    if ((row.Cells[2].Value).ToString() == DateTime.Now.ToString("dd-MMM-yyyy"))
                        date.Add("Today");
                    else
                        date.Add((row.Cells[2].Value).ToString());
                }

                ParentForm.Opacity = 0.80;
                Image_Form obj = new Image_Form(path, selectedrowindex, date);
                obj.Show();
                obj.imageEvent += Image_MyEvent;
            }
        }

        private void btnviewallpage_Click(object sender, EventArgs e)
        {
            if(dgvallpatientpage.RowCount > 0)
            {
                dgvallpatientpage.Rows[0].Selected = true;
                if (dgvallpatientpage.SelectedCells.Count > 0)
                {
                    selectedrowindex = dgvallpatientpage.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dgvallpatientpage.Rows[selectedrowindex];

                    List<string> path = new List<string>();
                    List<string> date = new List<string>();
                    foreach (DataGridViewRow row in dgvallpatientpage.Rows)
                    {
                        path.Add((row.Cells[3].Value).ToString());
                        if ((row.Cells[1].Value).ToString() == DateTime.Now.ToString("dd-MMM-yyyy"))
                            date.Add("Today");
                        else
                            date.Add((row.Cells[1].Value).ToString());
                    }

                    ParentForm.Opacity = 0.80;
                    Image_Form obj = new Image_Form(path, selectedrowindex, date);
                    obj.Show();
                    obj.imageEvent += Image_MyEvent;
                    obj.imageChangeEvent += ChangeImage_MyEvent;
                }
            }
        }

        private void btnviewalldocuments_Click(object sender, EventArgs e)
        {
            if (dgvallpatientdocument.RowCount > 0)
            {
                dgvallpatientdocument.Rows[0].Selected = true;
                if (dgvallpatientdocument.SelectedCells.Count > 0)
                {
                    selectedrowindex = dgvallpatientdocument.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dgvallpatientdocument.Rows[selectedrowindex];

                    List<string> path = new List<string>();
                    List<string> date = new List<string>();
                    foreach (DataGridViewRow row in dgvallpatientdocument.Rows)
                    {
                        path.Add((row.Cells[3].Value).ToString());
                        if ((row.Cells[1].Value).ToString() == DateTime.Now.ToString("dd-MMM-yyyy"))
                            date.Add("Today");
                        else
                            date.Add((row.Cells[1].Value).ToString());
                    }

                    ParentForm.Opacity = 0.80;
                    Image_Form obj = new Image_Form(path, selectedrowindex, date);
                    obj.Show();
                    obj.imageEvent += Image_MyEvent;
                }
            }
        }

        private void dgvpatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (personalinformation_Hided)
                timer_personalinformation.Start();
            if (lastvisited_Hided)
                timer_lastdiagnosis.Start();

            if (dgvpatient.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvpatient.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvpatient.Rows[selectedrowindex];

                string clinmdID = (selectedRow.Cells[5].Value).ToString();
                clearData();
                viewData(clinmdID);
            }

            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
            selectedrowindex = -1;
            ParentForm.Opacity = 1;
        }

        public void viewData(string clinmdid)
        {
            string type = "PersonalInformation";
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd;
                if (type == "PersonalInformation")
                {
                    cmd = new SqlCommand("PatientViewData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string ugcid = reader[0].ToString();
                        string firstname = reader[1].ToString();
                        string lastname = reader[2].ToString();
                        string age = reader[4].ToString();
                        string mobile = reader[5].ToString();
                        if (ugcid == "NA")
                            ugcid = "UGC ID";
                        if (firstname == "NA")
                            firstname = "First Name";
                        if (lastname == "NA")
                            lastname = "Last Name";
                        if (age == "NA")
                            age = "Age";
                        if (mobile == "NA")
                            mobile = "Number";
                        tbpatientugcid.Text = ugcid;
                        tbfirstname.Text = firstname;
                        tblastname.Text = lastname;
                        if (reader[3].ToString() == "Male")
                            rbmale.Checked = true;
                        if (reader[3].ToString() == "Female")
                            rbfemale.Checked = true;
                        tbage.Text = age;
                        tbmobilenumber.Text = mobile;
                    }
                    reader.Close();
                    type = "LastVisitedPage";
                }
                if (type == "LastVisitedPage")
                {
                    cmd = new SqlCommand("PatientViewData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string dd = reader[2].ToString().Substring(6, 2);
                        string MM = reader[2].ToString().Substring(4, 2);
                        string yyyy = reader[2].ToString().Substring(0, 4);
                        string date = dd + "-" + MM + "-" + yyyy;
                        dgvlastdiagnosispage.Rows.Add(reader[0].ToString(), reader[1].ToString(), date);
                        rtblastdiagnosisdiagnosis.Text = CSVToNormal(reader[3].ToString());
                        rtblastdiagnosissymptoms.Text = CSVToNormal(reader[4].ToString());
                    }
                    reader.Close();
                    type = "LastVisitedDocument";
                }
                if (type == "LastVisitedDocument")
                {
                    cmd = new SqlCommand("PatientViewData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string dd = reader[2].ToString().Substring(6, 2);
                        string MM = reader[2].ToString().Substring(4, 2);
                        string yyyy = reader[2].ToString().Substring(0, 4);
                        string date = dd + "-" + MM + "-" + yyyy;
                        dgvlastdiagnosisdocument.Rows.Add(reader[0].ToString(), reader[1].ToString(), date);
                    }
                    reader.Close();
                    type = "LastVisitedMedicine";
                }
                if (type == "LastVisitedMedicine")
                {
                    cmd = new SqlCommand("PatientViewData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvlastdiagnosismedicine.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                    }
                    reader.Close();
                    type = "AllPages";
                }
                if (type == "AllPages")
                {
                    cmd = new SqlCommand("PatientViewData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string dd = reader[2].ToString().Substring(6, 2);
                        string MM = reader[2].ToString().Substring(4, 2);
                        string yyyy = reader[2].ToString().Substring(0, 4);
                        string date = dd + "-" + MM + "-" + yyyy;
                        dgvallpatientpage.Rows.Add(null, date, reader[0].ToString(), reader[1].ToString());
                    }
                    reader.Close();
                    type = "AllDocuments";
                }
                if (type == "AllDocuments")
                {
                    cmd = new SqlCommand("PatientViewData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string dd = reader[2].ToString().Substring(6, 2);
                        string MM = reader[2].ToString().Substring(4, 2);
                        string yyyy = reader[2].ToString().Substring(0, 4);
                        string date = dd + "-" + MM + "-" + yyyy;
                        dgvallpatientdocument.Rows.Add(null, date, reader[0].ToString(), reader[1].ToString());
                    }
                    reader.Close();
                    type = "AllMedicines";
                }
                if (type == "AllMedicines")
                {
                    cmd = new SqlCommand("PatientViewData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvallpatientmedicine.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                    }
                    reader.Close();
                    type = "Appointment";
                }
                if (type == "Appointment")
                {
                    string appointmentdate = string.Empty;
                    string timeslot = string.Empty;
                    string appointmentstatus = string.Empty;
                    string appointmentID = string.Empty;
                    Image img = null;

                    cmd = new SqlCommand("PatientViewData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointmentdate = reader[0].ToString();
                        timeslot = reader[1].ToString();
                        appointmentstatus = reader[2].ToString();
                        appointmentID = reader[3].ToString();

                        if (appointmentstatus == "today")
                            img = Properties.Resources.today;
                        else if (appointmentstatus == "upcoming")
                            img = Properties.Resources.upcoming;
                        else if (appointmentstatus == "completed")
                            img = Properties.Resources.completed;
                        else if (appointmentstatus == "cancelled")
                            img = Properties.Resources.cancelled;

                        dgvpatientappointment.Rows.Add(appointmentdate, timeslot, img, null, Properties.Resources.cancel, appointmentstatus, appointmentID);
                    }
                    reader.Close();
                    type = "Vaccination";
                }
                if(type == "Vaccination")
                {
                    string vaccinationdate = string.Empty;
                    string timeslot = string.Empty;
                    string vaccinationtype = string.Empty;
                    string vaccinationstatus = string.Empty;
                    string vaccinationID = string.Empty;
                    Image img = null;
                    
                    cmd = new SqlCommand("PatientViewData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        vaccinationdate = reader[0].ToString();
                        timeslot = reader[1].ToString();
                        vaccinationtype = reader[2].ToString();
                        vaccinationstatus = reader[3].ToString();
                        vaccinationID = reader[4].ToString();

                        if (vaccinationstatus == "today")
                            img = Properties.Resources.today;
                        else if (vaccinationstatus == "upcoming")
                            img = Properties.Resources.upcoming;
                        else if (vaccinationstatus == "completed")
                            img = Properties.Resources.completed;
                        else if (vaccinationstatus == "cancelled")
                            img = Properties.Resources.cancelled;

                        dgvpatientvaccination.Rows.Add(vaccinationdate, timeslot, vaccinationtype, img, null, Properties.Resources.cancel, vaccinationstatus, vaccinationID);
                    }
                    reader.Close();
                    type = "Payment";
                }
                if(type == "Payment")
                {
                    try
                    {
                        string duedate = string.Empty;
                        string amount = string.Empty;
                        string amtpaid = string.Empty;
                        string baldue = string.Empty;
                        string paymentstatus = string.Empty;
                        string paymentID = string.Empty;
                        Image img = null;

                        cmd = new SqlCommand("PatientViewData", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@clinmdid", clinmdid);
                        cmd.ExecuteNonQuery();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            duedate = reader[0].ToString();
                            amount = reader[1].ToString();
                            amtpaid = reader[2].ToString();
                            baldue = reader[3].ToString();
                            paymentstatus = reader[4].ToString();
                            paymentID = reader[5].ToString();
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
                            dgvpatientpayment.Rows.Add(duedate, amount, amtpaid, baldue, img, null, Properties.Resources.cancel, paymentstatus, paymentID);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                this.clinmdID = clinmdid;
                this.newDocument1.ClinmdID = clinmdID;
                this.newAppointment1.ClinmdID = clinmdID;
                this.newVaccination1.ClinmdID = clinmdID;
                this.newPayment1.ClinmdID = clinmdID;
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

        private void btndownloadpatientrecord_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(folderBrowser.SelectedPath + @"\ClinMD.zip"))
                    File.Delete(folderBrowser.SelectedPath + @"\ClinMD.zip");
                for (int i = 0; i < dgvpatient.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvpatient.Rows[i].Cells[4].Value) == true)
                    {
                        string name = dgvpatient.Rows[i].Cells[2].Value.ToString();
                        string mobile = dgvpatient.Rows[i].Cells[3].Value.ToString();
                        string clinmdID = dgvpatient.Rows[i].Cells[5].Value.ToString();

                        string path = folderBrowser.SelectedPath + @"\ClinMDcompress\" + name + mobile + @"\";

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        try
                        {
                            if (con.State == ConnectionState.Closed)
                                con.Open();
                            SqlCommand cmd;
                            cmd = new SqlCommand("PatientViewData", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@type", "AllPages");
                            cmd.Parameters.AddWithValue("@clinmdid", clinmdID);
                            cmd.ExecuteNonQuery();
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader[1].ToString() != "NA")
                                {
                                    string dd = reader[2].ToString().Substring(6, 2);
                                    string MM = reader[2].ToString().Substring(4, 2);
                                    string yyyy = reader[2].ToString().Substring(0, 4);
                                    string date = dd + "-" + MM + "-" + yyyy;

                                    Image img = Image.FromFile(reader[1].ToString());
                                    img.Save(path + "Page " + Path.GetFileNameWithoutExtension(reader[1].ToString()) + ".png");
                                    PdfHelper.Instance.SaveImageAsPdf(path + "Page " + Path.GetFileNameWithoutExtension(reader[1].ToString()) + ".png", path + date + ", Prescription " + Path.GetFileNameWithoutExtension(reader[1].ToString()) + ".pdf", 1000, true);
                                }
                            }
                            reader.Close();

                            cmd = new SqlCommand("PatientViewData", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@type", "AllDocuments");
                            cmd.Parameters.AddWithValue("@clinmdid", clinmdID);
                            cmd.ExecuteNonQuery();
                            SqlDataReader reader1 = cmd.ExecuteReader();
                            while (reader1.Read())
                            {
                                if (reader1[1].ToString() != "NA")
                                {
                                    string dd = reader[2].ToString().Substring(6, 2);
                                    string MM = reader[2].ToString().Substring(4, 2);
                                    string yyyy = reader[2].ToString().Substring(0, 4);
                                    string date = dd + "-" + MM + "-" + yyyy;

                                    Image img = Image.FromFile(reader1[1].ToString());
                                    img.Save(path + "Document " + Path.GetFileNameWithoutExtension(reader1[1].ToString()) + ".png");
                                    PdfHelper.Instance.SaveImageAsPdf(path + "Document " + Path.GetFileNameWithoutExtension(reader1[1].ToString()) + ".png", path + date + ", Document " + Path.GetFileNameWithoutExtension(reader1[1].ToString()) + ".pdf", 1000, true);
                                }
                            }
                            reader.Close();

                            try
                            {
                                ZipFile.CreateFromDirectory(folderBrowser.SelectedPath + @"\ClinMDcompress", folderBrowser.SelectedPath + @"\ClinMD.zip");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
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

                Process.Start(folderBrowser.SelectedPath);
            }


            if (Directory.Exists(folderBrowser.SelectedPath + @"\ClinMDcompress"))
            {
                foreach (string dir in Directory.GetDirectories(folderBrowser.SelectedPath + @"\ClinMDcompress"))
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        File.Delete(file);
                    }
                    Directory.Delete(dir);
                }
                Directory.Delete(folderBrowser.SelectedPath + @"\ClinMDcompress");
            }

            for (int i = 0; i < dgvpatient.Rows.Count; i++)
            {
                dgvpatient.Rows[i].Cells[4].Value = false;
            }
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
            selectedrowindex = -1;
            ParentForm.Opacity = 1;
            cbselectallpatients.Checked = false;
        }

        private void cbselectallpatients_CheckedChanged(object sender, EventArgs e)
        {
            viewappointment = false;
            viewvaccination = false;
            viewpayment = false;
            newdocuments = false;
            newmedicines = false;
            selectedrowindex = -1;
            ParentForm.Opacity = 1;

            if (cbselectallpatients.Checked == true)
            {
                for (int i = 0; i < dgvpatient.Rows.Count; i++)
                {
                    dgvpatient.Rows[i].Cells[4].Value = true;
                }
            }
            if (cbselectallpatients.Checked == false)
            {
                for (int i = 0; i < dgvpatient.Rows.Count; i++)
                {
                    dgvpatient.Rows[i].Cells[4].Value = false;
                }
            }
        }
    }
}
