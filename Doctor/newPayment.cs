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
using MaterialSkin;
using System.Diagnostics;
using System.Globalization;
using System.Data.SqlClient;

namespace Doctor
{
    public partial class newPayment : UserControl
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        MaterialSkinManager skinManager;
        PrivateFontCollection pfc = new PrivateFontCollection();

        public payment ParentForm { get; set; }

        public event EventHandler NewPaymentEvent;

        string paymentID = "0";

        string clinmdID = string.Empty;

        string tempID = string.Empty;

        public string TempID
        {
            get { return this.tempID; }
        }

       public string PaymentID
        {
            set { this.paymentID = value; }
        }

        public string ClinmdID
        {
            get { return this.clinmdID; }
            set { this.clinmdID = value; }
        }

        public string PatientName
        {
            get { return this.tbfirstname.Text.ToUpper().Trim() + " " + this.tblastname.Text.ToUpper().Trim(); }
        }

        public string Mobile
        {
            get { return this.tbmobilenumber.Text; }
        }

        public string DueDate
        {
            get { return this.tbduedate.Text; }
        }

        public string Amount
        {
            get { return this.tbamt.Text; }
        } 

        public string AmountPaid
        {
            get { return (Convert.ToDouble(this.tbamtpaid.Text) + Convert.ToDouble(this.tbmoreamtpaid.Text)).ToString(); }
        }

        public string BalanceDue
        {
            get { return this.tbbaldue.Text; }
        }

        public newPayment()
        {
            InitializeComponent();

            skinManager = MaterialSkinManager.Instance;
            skinManager.ColorScheme = new ColorScheme(Primary.Cyan600, Primary.Brown900, Primary.Cyan700, Accent.Cyan700, TextShade.WHITE);
            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);
            foreach(Control i in this.Controls)
            {
                if(i.GetType() == typeof(Label))
                {
                    i.Font = new Font(pfc.Families[0], 9);
                }
            }
            lbpatientpayment.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            lbpatientinformation.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);

            calenderduedate.SetDate(DateTime.Now);
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
            if(tbfirstname.Text == "First Name")
                tbfirstname.Text = "";
            calenderduedate.Visible = false;
            tbduedate.Enabled = true;
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
            calenderduedate.Visible = false;
            tbduedate.Enabled = true;
            lberror.Visible = false;
        }

        private void tblastname_Leave(object sender, EventArgs e)
        {
            if (tblastname.Text == "")
                tblastname.Text = "Last Name";
        }

        private void tbmobilenumber_Click(object sender, EventArgs e)
        {
            if (tbmobilenumber.Text == "Number")
                tbmobilenumber.Text = "";
            calenderduedate.Visible = false;
            tbduedate.Enabled = true;
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

        private void tbduedate_Click(object sender, EventArgs e)
        {
            calenderduedate.Visible = true;
            tbduedate.Enabled = false;
            lberror.Visible = false;
        }

        private void tbduedate_Leave(object sender, EventArgs e)
        {
            if (tbduedate.Text == "")
                tbduedate.Text = "Select Date";
        }

        private void calenderduedate_DateSelected(object sender, DateRangeEventArgs e)
        {
            tbduedate.Text = calenderduedate.SelectionStart.ToString("dd-MMM-yyyy");
            calenderduedate.Visible = false;
            tbduedate.Enabled = true;
        }

        private void calenderduedate_MouseLeave(object sender, EventArgs e)
        {
            calenderduedate.Visible = false;
            tbduedate.Enabled = true;
        }

        private void tbduedate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime checkDate = DateTime.ParseExact(tbduedate.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                if (tbduedate.Text != "Select Date")
                    calenderduedate.Visible = true;
            }
        }

        private void tbamt_Click(object sender, EventArgs e)
        {
            if (tbamt.Text == "0.0")
                tbamt.Text = "";
            lberror.Visible = false;
        }

        private void tbamt_Leave(object sender, EventArgs e)
        {
            if (tbamt.Text == "")
                tbamt.Text = "0.0";
        }

        private void tbamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbamtpaid_Click(object sender, EventArgs e)
        {
            if (tbamtpaid.Text == "0.0")
                tbamtpaid.Text = "";
            lberror.Visible = false;
        }

        private void tbamtpaid_Leave(object sender, EventArgs e)
        {
            if (tbamtpaid.Text == "")
                tbamtpaid.Text = "0.0";
        }

        private void tbamtpaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbamtpaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnaddpayment.PerformClick();
            }
        }

        private void tbbaldue_Click(object sender, EventArgs e){}

        private void tbbaldue_Leave(object sender, EventArgs e){}

        private void newPayment_VisibleChanged(object sender, EventArgs e){}

        private void tbamt_TextChanged(object sender, EventArgs e)
        {            
            tbbaldue.Text = tbamt.Text;
        }

        private void tbamtpaid_TextChanged(object sender, EventArgs e)
        {
            if (tbamtpaid.Text != "")
            {
                if (tbamt.Text != "0.0")
                {
                    if (lberror.Visible == true)
                        lberror.Visible = false;
                    tbbaldue.Text = (Convert.ToDouble(tbamt.Text) - Convert.ToDouble(tbamtpaid.Text)).ToString();
                    if (Convert.ToDouble(tbbaldue.Text) < 0)
                    {
                        lberror.Text = "* Please check the amount paid";
                        lberror.Visible = true;
                        tbamtpaid.Text = "";
                        tbbaldue.Text = tbamt.Text;
                    }
                }
            }
            else
            {
                tbbaldue.Text = tbamt.Text;
            }
        }

        private void btnmorepaidamt_Click(object sender, EventArgs e)
        {
            tbmoreamtpaid.Visible = true;
            tbmoreamtpaid.Text = "";
            tbmoreamtpaid.Focus();
        }

        private void tbmoreamtpaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbmoreamtpaid_Click(object sender, EventArgs e)
        {
            if (tbmoreamtpaid.Text == "0.0")
                tbmoreamtpaid.Text = "";
            lberror.Visible = false;
        }

        private void tbmoreamtpaid_Leave(object sender, EventArgs e)
        {
            if (tbmoreamtpaid.Text == "")
                tbmoreamtpaid.Text = "0.0";
        }

        private void tbmoreamtpaid_TextChanged(object sender, EventArgs e)
        {
            if (tbmoreamtpaid.Text != "")
            {
                if (tbamt.Text != "0.0")
                {
                    if (Convert.ToDouble(tbbaldue.Text) >= 0)
                    {
                        if (lberror.Visible == true)
                            lberror.Visible = false;
                        tbbaldue.Text = (Convert.ToDouble(tbamt.Text) - (Convert.ToDouble(tbamtpaid.Text) + Convert.ToDouble(tbmoreamtpaid.Text))).ToString();
                        if (Convert.ToDouble(tbbaldue.Text) < 0)
                        {
                            lberror.Text = "* Please check the amount paid";
                            lberror.Visible = true;
                            tbmoreamtpaid.Text = "";
                            tbbaldue.Text = (Convert.ToDouble(tbamt.Text) - Convert.ToDouble(tbamtpaid.Text)).ToString();
                        }
                    }
                }
            }
            else
            {
                tbbaldue.Text = (Convert.ToDouble(tbamt.Text) - Convert.ToDouble(tbamtpaid.Text)).ToString();
            }
        }

        private void btnaddpayment_Click(object sender, EventArgs e)
        {
            if (tbfirstname.Text == "First Name")
                tbfirstname.Text = "";
            if (tblastname.Text == "Last Name")
                tblastname.Text = "";
            if (tbmobilenumber.Text == "Number")
                tbmobilenumber.Text = "";
            string personalInformation = tbfirstname.Text + tblastname.Text + tbmobilenumber.Text;
            if (personalInformation != "")
            {
                if (tbmobilenumber.Text.Length == 10 || tbmobilenumber.Text == "")
                {
                    if (tbmobilenumber.Text == "")
                        tbmobilenumber.Text = "NA";
                    if (tbduedate.Text == "Select Date")
                    {
                        tbduedate.Text = "NA";
                        calenderduedate.Visible = false;
                        if (NewPaymentEvent != null)
                        {
                            NewPaymentEvent(null, null);
                        }
                        this.Visible = false;
                    }
                    else
                    {
                        try
                        {
                            DateTime checkDate = DateTime.ParseExact(tbduedate.Text, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            insertData();
                            if (NewPaymentEvent != null)
                            {
                                NewPaymentEvent(null, null);
                            }
                            this.Visible = false;
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
            }
        }

        public void insertData()
        {
            string name = string.Empty;
            if (this.PatientName != " ")
                name = this.PatientName;
            else
                name = "NA";

            Image img = null;

            string baldue = this.BalanceDue;
            if (baldue == "0.0")
                baldue = "0";

            string status = string.Empty;

            string today = DateTime.Now.ToString("dd-MMM-yyyy");
            if (this.DueDate != "NA")
            {
                if (DateTime.Parse(this.DueDate) == DateTime.Parse(today) && baldue != "0")
                {
                    img = Properties.Resources.today;
                    status = "today";
                }
                else
                {
                    if (DateTime.Parse(this.DueDate) < DateTime.Parse(today) && baldue != "0")
                    {
                        status = "overdue";
                        img = Properties.Resources.overdue;
                    }
                    else if (DateTime.Parse(this.DueDate) > DateTime.Parse(today) && baldue != "0")
                    {
                        status = "upcoming";
                        img = Properties.Resources.upcoming;
                    }
                    else if (baldue == "0" && this.Amount != "0.0")
                    {
                        status = "completed";
                        img = Properties.Resources.completed;
                    }
                    else
                    {
                        status = "unknown";
                        img = Properties.Resources.unknownstatus;
                    }
                }
            }
            else
            {
                status = "unknown";
                img = Properties.Resources.unknownstatus;
            }

            SqlCommand cmd = new SqlCommand("PaymentInsert", con);
            cmd.CommandType = CommandType.StoredProcedure; ;

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

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

                if (paymentID == "0")
                    cmd.Parameters.AddWithValue("@mode", "Insert");
                else
                    cmd.Parameters.AddWithValue("@mode", "Update");

                cmd.Parameters.AddWithValue("@paymentID", paymentID);
                cmd.Parameters.AddWithValue("@clinmdID", tempID);
                cmd.Parameters.AddWithValue("@patientname", name);
                cmd.Parameters.AddWithValue("@mobile", this.Mobile);
                cmd.Parameters.AddWithValue("@duedate", this.DueDate);
                cmd.Parameters.AddWithValue("@amount", this.Amount);
                cmd.Parameters.AddWithValue("@amtpaid", this.AmountPaid);
                cmd.Parameters.AddWithValue("@baldue", this.BalanceDue);
                cmd.Parameters.AddWithValue("@paymentstatus", status);
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