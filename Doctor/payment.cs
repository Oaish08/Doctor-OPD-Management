using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Doctor
{
    public partial class payment : UserControl
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        MaterialSkinManager skinManager;
        PrivateFontCollection pfc = new PrivateFontCollection();

        public User_Form ParentForm { get; set; }

        int selectedrowindex = -1;

        public DataGridView data
        {
            get { return this.dgvpatientpayment; }
        }

        public payment()
        {
            InitializeComponent();

            this.newPayment1.ParentForm = this;

            this.newPayment1.NewPaymentEvent += paymentwindow_MyEvent;

            this.confirmcompletepayment1.ConfirmMessageEvent += confirmwindow_MyEvent;

            skinManager = MaterialSkinManager.Instance;
            skinManager.ColorScheme = new ColorScheme(Primary.Cyan600,Primary.Brown900,Primary.Cyan700,Accent.Cyan700,TextShade.WHITE);
            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            lbpayments.Font = new Font(pfc.Families[0],22);
            lbpatientname.Font = new Font(pfc.Families[0], 9);
            lbmobile.Font = new Font(pfc.Families[0], 9);
            lbduedate.Font = new Font(pfc.Families[0], 9);
            lbpaymenttypes.Font = new Font(pfc.Families[0], 13, FontStyle.Bold);
            rbdues.Font = new Font(pfc.Families[0], 10);
            rball.Font = new Font(pfc.Families[0], 10);
            rbpayments.Font = new Font(pfc.Families[0], 10);

            calenderduedate.SetDate(DateTime.Now);
        }

        private void confirmwindow_MyEvent(object sender, EventArgs e)
        {
            if(confirmcompletepayment1.delete == true)
            {
                string paymentID = dgvpatientpayment.Rows[selectedrowindex].Cells[10].Value.ToString();

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("PaymentDelete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@paymentID", paymentID);
                    cmd.ExecuteNonQuery();
                    tbsearchpatientname.Text = "Name";
                    tbsearchmobile.Text = "Number";
                    tbsearchduedate.Text = "Select Date";
                    dgvpatientpayment.Rows.Clear();
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
            else
            {
                string status = string.Empty;
                string amtpaid = dgvpatientpayment.Rows[selectedrowindex].Cells[3].Value.ToString();
                dgvpatientpayment.Rows[selectedrowindex].Cells[5].Value = 0;
                Image img = null;
                img = Properties.Resources.completed;
                status = "completed";
                string paymentID = dgvpatientpayment.Rows[selectedrowindex].Cells[10].Value.ToString();

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("PaymentComplete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@paymentID", paymentID);
                    cmd.Parameters.AddWithValue("@amtpaid", amtpaid);
                    cmd.Parameters.AddWithValue("@baldue", "0");
                    cmd.Parameters.AddWithValue("@paymentstatus", status);
                    cmd.ExecuteNonQuery();
                    tbsearchpatientname.Text = "Name";
                    tbsearchmobile.Text = "Number";
                    tbsearchduedate.Text = "Select Date";
                    dgvpatientpayment.Rows.Clear();
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
            confirmcompletepayment1.delete = false;
            ParentForm.Opacity = 1;
            selectedrowindex = -1;
        }

        private void paymentwindow_MyEvent(object sender, EventArgs e)
        {
            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";
            tbsearchduedate.Text = "Select Date";
            dgvpatientpayment.Rows.Clear();
            searchData();
        }

        private void payment_Load(object sender, EventArgs e)
        {
            SetFontAndColors();

            rball.Checked = true;
            lbpaymenttypes.Text = "All Payments";
        }

        private void SetFontAndColors()
        {
            dgvpatientpayment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpatientpayment.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvpatientpayment.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            dgvpatientpayment.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
        }

        void sortData()
        {
            try
            {
                string duedate = string.Empty;
                string name = string.Empty;
                string mobile = string.Empty;
                string amount = string.Empty;
                string amtpaid = string.Empty;
                string baldue = string.Empty;
                string paymentstatus = lbpaymenttypes.Text;
                string paymentID = string.Empty;
                Image img = null;

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("PaymentSorting", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("paymentstatus", paymentstatus);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    duedate = reader[0].ToString();
                    name = reader[1].ToString();
                    mobile = reader[2].ToString();
                    amount = reader[3].ToString();
                    amtpaid = reader[4].ToString();
                    baldue = reader[5].ToString();
                    paymentstatus = reader[6].ToString();
                    paymentID = reader[7].ToString();
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
                    dgvpatientpayment.Rows.Add(duedate, name, mobile, amount, amtpaid, baldue, img, null, Properties.Resources.cancel, paymentstatus, paymentID);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void rbdues_Click(object sender, EventArgs e)
        {
            if (rbdues.Checked == true)
                lbpaymenttypes.Text = "Overdues and Upcoming Payments";

            calenderduedate.Visible = false;
            tbsearchduedate.Enabled = true;
        }

        private void rbpayments_Click(object sender, EventArgs e)
        {
            if (rbpayments.Checked == true)
                lbpaymenttypes.Text = "Payments Completed";

            calenderduedate.Visible = false;
            tbsearchduedate.Enabled = true;
        }

        private void rball_Click(object sender, EventArgs e)
        {
            rball.Checked = true;
            lbpaymenttypes.Text = "All Payments";

            calenderduedate.Visible = false;
            tbsearchduedate.Enabled = true;
        }

        private void lbpaymenttypes_TextChanged(object sender, EventArgs e)
        {
            dgvpatientpayment.Rows.Clear();
            sortData();
        }

        private void tbsearchpatientname_Click(object sender, EventArgs e)
        {
            if (tbsearchpatientname.Text == "Name")
                tbsearchpatientname.Text = "";

            calenderduedate.Visible = false;
            tbsearchduedate.Enabled = true;
        }

        private void tbsearchpatientname_Leave(object sender, EventArgs e)
        {
            if (tbsearchpatientname.Text == "")
                tbsearchpatientname.Text = "Name";
        }

        private void tbsearchmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbsearchlastvisited_Click(object sender, EventArgs e)
        {
            calenderduedate.Visible = false;
            tbsearchduedate.Enabled = true;
            if (tbsearchmobile.Text == "Number")
                tbsearchmobile.Text = "";
        }

        private void tbsearchlastvisited_Leave(object sender, EventArgs e)
        {
            if (tbsearchmobile.Text == "")
            {
                tbsearchmobile.Text = "Number";
            }
        }

        private void tbsearchduedate_Click(object sender, EventArgs e)
        {
            calenderduedate.Visible = true;
            tbsearchduedate.Enabled = false;
        }

        private void tbsearchduedate_Leave(object sender, EventArgs e)
        {
            if (tbsearchduedate.Text == "")
            {
                tbsearchduedate.Text = "Select Date";
            }
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)//calenderduedate
        {
            tbsearchduedate.Text = calenderduedate.SelectionStart.ToString("dd-MMM-yyyy");
            calenderduedate.Visible = false;
            tbsearchduedate.Enabled = true;
        }

        private void monthCalendar2_MouseLeave(object sender, EventArgs e)//calenderduedate
        {
            calenderduedate.Visible = false;
            tbsearchduedate.Enabled = true;
        }

        private void monthCalendar2_Leave(object sender, EventArgs e){}

        void searchData()
        {
            try
            {
                string duedate = string.Empty;
                string name = string.Empty;
                string mobile = string.Empty;
                string amount = string.Empty;
                string amtpaid = string.Empty;
                string baldue = string.Empty;
                string paymentstatus = string.Empty;
                string paymentID = string.Empty;
                string searchpatientname = tbsearchpatientname.Text.Trim();
                string searchmobile = tbsearchmobile.Text.Trim();
                string searchduedate = tbsearchduedate.Text.Trim();
                Image img = null;

                if (searchpatientname == "Name")
                    searchpatientname = "";
                if (searchmobile == "Number")
                    searchmobile = "";
                if (searchduedate == "Select Date")
                    searchduedate = "";

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("PaymentSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("patientname",searchpatientname);
                cmd.Parameters.AddWithValue("mobile", searchmobile);
                cmd.Parameters.AddWithValue("duedate", searchduedate);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    duedate = reader[0].ToString();
                    name = reader[1].ToString();
                    mobile = reader[2].ToString();
                    amount = reader[3].ToString();
                    amtpaid = reader[4].ToString();
                    baldue = reader[5].ToString();
                    paymentstatus = reader[6].ToString();
                    paymentID = reader[7].ToString();
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
                    dgvpatientpayment.Rows.Add(duedate, name, mobile, amount, amtpaid, baldue, img, null, Properties.Resources.cancel, paymentstatus, paymentID);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            dgvpatientpayment.Rows.Clear();
            searchData();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            tbsearchpatientname.Text = "Name";
            tbsearchmobile.Text = "Number";
            tbsearchduedate.Text = "Select Date";

            calenderduedate.Visible = false;
            tbsearchduedate.Enabled = true;

            dgvpatientpayment.Rows.Clear();
            searchData();
        }

        private void dgvpatientpayment_Paint(object sender, PaintEventArgs e)
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

        private void dgvpatientpayment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvpatientpayment.SelectedCells.Count > 0)
            {
                selectedrowindex = dgvpatientpayment.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvpatientpayment.Rows[selectedrowindex];

                string duedate = (selectedRow.Cells[0].Value).ToString();
                string patientname = (selectedRow.Cells[1].Value).ToString();
                string mobile = (selectedRow.Cells[2].Value).ToString();
                string amount = (selectedRow.Cells[3].Value).ToString();
                string amtpaid = (selectedRow.Cells[4].Value).ToString();
                string baldue = (selectedRow.Cells[5].Value).ToString();
                string paymentID = (selectedRow.Cells[10].Value).ToString();

                this.newPayment1.Visible = false;
                ParentForm.Opacity = 1;

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Focus();

                if (duedate != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbduedate"]).Text = duedate;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbduedate"]).Text = "Select Date";

                if (patientname != "NA")
                {
                    string[] name = patientname.Split(' ');
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Text = name[0];
                    string lastname = string.Empty;
                    for (int i = 1; i < name.Length; i++)
                    {
                        lastname += name[i];
                    }
                    if (lastname != "")
                        ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tblastname"]).Text = lastname;
                    else
                        ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tblastname"]).Text = "Last Name";
                }
                else
                {
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Text = "First Name";
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tblastname"]).Text = "Last Name";
                }

                if (mobile != "NA")
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbmobilenumber"]).Text = mobile;
                else
                    ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbmobilenumber"]).Text = "Number";

                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbamt"]).Text = amount;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbamtpaid"]).Text = amtpaid;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbbaldue"]).Text = baldue;

                ((Label)this.newPayment1.Controls["lberror"]).Visible = false;
                ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbmoreamtpaid"]).Visible = false;

                this.newPayment1.PaymentID = paymentID;

                ParentForm.Opacity = 0.92;

                newPayment1.Focus();
                newPayment1.Visible = true;
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)//btnnewpayment
        {
            selectedrowindex = -1;
            calenderduedate.Visible = false;
            tbsearchduedate.Enabled = true;

            ParentForm.Opacity = 0.92;

            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Focus();
            ((Label)this.newPayment1.Controls["lberror"]).Visible = false;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbduedate"]).Text = "Select Date";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbfirstname"]).Text = "";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tblastname"]).Text = "Last Name";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbmobilenumber"]).Text = "Number";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbamt"]).Text = "0.0";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbamtpaid"]).Text = "0.0";
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbmoreamtpaid"]).Visible = false;
            ((MaterialSkin.Controls.MaterialSingleLineTextField)this.newPayment1.Controls["tbbaldue"]).Text = "0.0";
            ((MonthCalendar)this.newPayment1.Controls["calenderduedate"]).SetDate(DateTime.Now);
            this.newPayment1.PaymentID = "0";
            newPayment1.Visible = true;
        }

        private void dgvpatientpayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7 && e.RowIndex < dgvpatientpayment.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientpayment.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientpayment.Rows[selectedrowindex];

                string patientname = (selectedRow.Cells[1].Value).ToString();
                string baldue = (selectedRow.Cells[5].Value).ToString();
                string status = (selectedRow.Cells[9].Value).ToString();
                
                if ((status != "completed" && status != "unknown") || (status == "unknown" && (baldue != "0" && baldue != "0.0")))
                {
                    confirmcompletepayment1.Visible = true;
                    ((Label)confirmcompletepayment1.Controls["lbmessage"]).Text = "Are you Sure you want to complete payment of patient " + patientname + " ?";
                    ParentForm.Opacity = 0.92;
                } 
            }
            if (e.ColumnIndex == 8 && e.RowIndex < dgvpatientpayment.SelectedCells.Count)
            {
                selectedrowindex = dgvpatientpayment.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvpatientpayment.Rows[selectedrowindex];

                string patientname = (selectedRow.Cells[1].Value).ToString();
                string status = (selectedRow.Cells[9].Value).ToString();

                confirmcompletepayment1.Visible = true;
                ((Label)confirmcompletepayment1.Controls["lbmessage"]).Text = "Are you Sure you want to delete payment of patient " + patientname + " ?";
                confirmcompletepayment1.delete = true;
                ParentForm.Opacity = 0.92;
            }
        }

        private void newPayment1_Leave(object sender, EventArgs e)
        {
            newPayment1.Visible = false;
            ParentForm.Opacity = 1;
        }

        private void confirmcompletepayment1_Leave(object sender, EventArgs e)
        {
            confirmcompletepayment1.Visible = false;
            ParentForm.Opacity = 1;
        }
    }
}