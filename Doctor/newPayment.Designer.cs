namespace Doctor
{
    partial class newPayment
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newPayment));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbpatientpayment = new System.Windows.Forms.Label();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbpatientinformation = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbfirstname = new System.Windows.Forms.Label();
            this.lblastname = new System.Windows.Forms.Label();
            this.lbmobilenumber = new System.Windows.Forms.Label();
            this.lbduedate = new System.Windows.Forms.Label();
            this.lbamount = new System.Windows.Forms.Label();
            this.lbamountpaid = new System.Windows.Forms.Label();
            this.lbbaldue = new System.Windows.Forms.Label();
            this.tbfirstname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tblastname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbmobilenumber = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbduedate = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbamt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbamtpaid = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbbaldue = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnaddpayment = new MaterialSkin.Controls.MaterialRaisedButton();
            this.calenderduedate = new System.Windows.Forms.MonthCalendar();
            this.lberror = new System.Windows.Forms.Label();
            this.btnmorepaidamt = new System.Windows.Forms.Button();
            this.tbmoreamtpaid = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.panel1.Controls.Add(this.lbpatientpayment);
            this.panel1.Controls.Add(this.pbclose);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 56);
            this.panel1.TabIndex = 0;
            // 
            // lbpatientpayment
            // 
            this.lbpatientpayment.AutoSize = true;
            this.lbpatientpayment.ForeColor = System.Drawing.Color.White;
            this.lbpatientpayment.Location = new System.Drawing.Point(7, 18);
            this.lbpatientpayment.Name = "lbpatientpayment";
            this.lbpatientpayment.Size = new System.Drawing.Size(84, 13);
            this.lbpatientpayment.TabIndex = 27;
            this.lbpatientpayment.Text = "Patient Payment";
            // 
            // pbclose
            // 
            this.pbclose.Image = ((System.Drawing.Image)(resources.GetObject("pbclose.Image")));
            this.pbclose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbclose.Location = new System.Drawing.Point(265, 0);
            this.pbclose.Name = "pbclose";
            this.pbclose.Size = new System.Drawing.Size(15, 15);
            this.pbclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbclose.TabIndex = 5;
            this.pbclose.TabStop = false;
            this.pbclose.Click += new System.EventHandler(this.pbclose_Click);
            this.pbclose.MouseLeave += new System.EventHandler(this.pbclose_MouseLeave);
            this.pbclose.MouseHover += new System.EventHandler(this.pbclose_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbpatientinformation);
            this.panel2.Location = new System.Drawing.Point(5, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 40);
            this.panel2.TabIndex = 1;
            // 
            // lbpatientinformation
            // 
            this.lbpatientinformation.AutoSize = true;
            this.lbpatientinformation.ForeColor = System.Drawing.Color.DimGray;
            this.lbpatientinformation.Location = new System.Drawing.Point(7, 9);
            this.lbpatientinformation.Name = "lbpatientinformation";
            this.lbpatientinformation.Size = new System.Drawing.Size(95, 13);
            this.lbpatientinformation.TabIndex = 28;
            this.lbpatientinformation.Text = "Patient Information";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(5, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 340);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Location = new System.Drawing.Point(274, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 340);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Location = new System.Drawing.Point(6, 445);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(269, 1);
            this.panel5.TabIndex = 4;
            // 
            // lbfirstname
            // 
            this.lbfirstname.AutoSize = true;
            this.lbfirstname.Location = new System.Drawing.Point(12, 126);
            this.lbfirstname.Name = "lbfirstname";
            this.lbfirstname.Size = new System.Drawing.Size(57, 13);
            this.lbfirstname.TabIndex = 6;
            this.lbfirstname.Text = "First Name";
            // 
            // lblastname
            // 
            this.lblastname.AutoSize = true;
            this.lblastname.Location = new System.Drawing.Point(144, 126);
            this.lblastname.Name = "lblastname";
            this.lblastname.Size = new System.Drawing.Size(58, 13);
            this.lblastname.TabIndex = 8;
            this.lblastname.Text = "Last Name";
            // 
            // lbmobilenumber
            // 
            this.lbmobilenumber.AutoSize = true;
            this.lbmobilenumber.Location = new System.Drawing.Point(12, 191);
            this.lbmobilenumber.Name = "lbmobilenumber";
            this.lbmobilenumber.Size = new System.Drawing.Size(78, 13);
            this.lbmobilenumber.TabIndex = 10;
            this.lbmobilenumber.Text = "Mobile Number";
            // 
            // lbduedate
            // 
            this.lbduedate.AutoSize = true;
            this.lbduedate.Location = new System.Drawing.Point(144, 191);
            this.lbduedate.Name = "lbduedate";
            this.lbduedate.Size = new System.Drawing.Size(53, 13);
            this.lbduedate.TabIndex = 12;
            this.lbduedate.Text = "Due Date";
            // 
            // lbamount
            // 
            this.lbamount.AutoSize = true;
            this.lbamount.Location = new System.Drawing.Point(12, 264);
            this.lbamount.Name = "lbamount";
            this.lbamount.Size = new System.Drawing.Size(43, 13);
            this.lbamount.TabIndex = 25;
            this.lbamount.Text = "Amount";
            // 
            // lbamountpaid
            // 
            this.lbamountpaid.AutoSize = true;
            this.lbamountpaid.Location = new System.Drawing.Point(12, 301);
            this.lbamountpaid.Name = "lbamountpaid";
            this.lbamountpaid.Size = new System.Drawing.Size(67, 13);
            this.lbamountpaid.TabIndex = 16;
            this.lbamountpaid.Text = "Amount Paid";
            // 
            // lbbaldue
            // 
            this.lbbaldue.AutoSize = true;
            this.lbbaldue.Location = new System.Drawing.Point(12, 371);
            this.lbbaldue.Name = "lbbaldue";
            this.lbbaldue.Size = new System.Drawing.Size(69, 13);
            this.lbbaldue.TabIndex = 18;
            this.lbbaldue.Text = "Balance Due";
            // 
            // tbfirstname
            // 
            this.tbfirstname.Depth = 0;
            this.tbfirstname.Hint = "";
            this.tbfirstname.Location = new System.Drawing.Point(13, 147);
            this.tbfirstname.MaxLength = 32767;
            this.tbfirstname.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbfirstname.Name = "tbfirstname";
            this.tbfirstname.PasswordChar = '\0';
            this.tbfirstname.SelectedText = "";
            this.tbfirstname.SelectionLength = 0;
            this.tbfirstname.SelectionStart = 0;
            this.tbfirstname.Size = new System.Drawing.Size(119, 23);
            this.tbfirstname.TabIndex = 1;
            this.tbfirstname.TabStop = false;
            this.tbfirstname.Text = "First Name";
            this.tbfirstname.UseSystemPasswordChar = false;
            this.tbfirstname.Click += new System.EventHandler(this.tbfirstname_Click);
            this.tbfirstname.Leave += new System.EventHandler(this.tbfirstname_Leave);
            // 
            // tblastname
            // 
            this.tblastname.Depth = 0;
            this.tblastname.Hint = "";
            this.tblastname.Location = new System.Drawing.Point(147, 147);
            this.tblastname.MaxLength = 32767;
            this.tblastname.MouseState = MaterialSkin.MouseState.HOVER;
            this.tblastname.Name = "tblastname";
            this.tblastname.PasswordChar = '\0';
            this.tblastname.SelectedText = "";
            this.tblastname.SelectionLength = 0;
            this.tblastname.SelectionStart = 0;
            this.tblastname.Size = new System.Drawing.Size(119, 23);
            this.tblastname.TabIndex = 2;
            this.tblastname.TabStop = false;
            this.tblastname.Text = "Last Name";
            this.tblastname.UseSystemPasswordChar = false;
            this.tblastname.Click += new System.EventHandler(this.tblastname_Click);
            this.tblastname.Leave += new System.EventHandler(this.tblastname_Leave);
            // 
            // tbmobilenumber
            // 
            this.tbmobilenumber.Depth = 0;
            this.tbmobilenumber.Hint = "";
            this.tbmobilenumber.Location = new System.Drawing.Point(15, 211);
            this.tbmobilenumber.MaxLength = 10;
            this.tbmobilenumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbmobilenumber.Name = "tbmobilenumber";
            this.tbmobilenumber.PasswordChar = '\0';
            this.tbmobilenumber.SelectedText = "";
            this.tbmobilenumber.SelectionLength = 0;
            this.tbmobilenumber.SelectionStart = 0;
            this.tbmobilenumber.Size = new System.Drawing.Size(119, 23);
            this.tbmobilenumber.TabIndex = 3;
            this.tbmobilenumber.TabStop = false;
            this.tbmobilenumber.Text = "Number";
            this.tbmobilenumber.UseSystemPasswordChar = false;
            this.tbmobilenumber.Click += new System.EventHandler(this.tbmobilenumber_Click);
            this.tbmobilenumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbmobilenumber_KeyPress);
            this.tbmobilenumber.Leave += new System.EventHandler(this.tbmobilenumber_Leave);
            // 
            // tbduedate
            // 
            this.tbduedate.Depth = 0;
            this.tbduedate.Hint = "";
            this.tbduedate.Location = new System.Drawing.Point(147, 211);
            this.tbduedate.MaxLength = 32767;
            this.tbduedate.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbduedate.Name = "tbduedate";
            this.tbduedate.PasswordChar = '\0';
            this.tbduedate.SelectedText = "";
            this.tbduedate.SelectionLength = 0;
            this.tbduedate.SelectionStart = 0;
            this.tbduedate.Size = new System.Drawing.Size(119, 23);
            this.tbduedate.TabIndex = 4;
            this.tbduedate.TabStop = false;
            this.tbduedate.Text = "Date";
            this.tbduedate.UseSystemPasswordChar = false;
            this.tbduedate.Click += new System.EventHandler(this.tbduedate_Click);
            this.tbduedate.Leave += new System.EventHandler(this.tbduedate_Leave);
            this.tbduedate.TextChanged += new System.EventHandler(this.tbduedate_TextChanged);
            // 
            // tbamt
            // 
            this.tbamt.Depth = 0;
            this.tbamt.Hint = "";
            this.tbamt.Location = new System.Drawing.Point(94, 254);
            this.tbamt.MaxLength = 32767;
            this.tbamt.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbamt.Name = "tbamt";
            this.tbamt.PasswordChar = '\0';
            this.tbamt.SelectedText = "";
            this.tbamt.SelectionLength = 0;
            this.tbamt.SelectionStart = 0;
            this.tbamt.Size = new System.Drawing.Size(60, 23);
            this.tbamt.TabIndex = 14;
            this.tbamt.TabStop = false;
            this.tbamt.Text = "0.0";
            this.tbamt.UseSystemPasswordChar = false;
            this.tbamt.Click += new System.EventHandler(this.tbamt_Click);
            this.tbamt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbamt_KeyPress);
            this.tbamt.Leave += new System.EventHandler(this.tbamt_Leave);
            this.tbamt.TextChanged += new System.EventHandler(this.tbamt_TextChanged);
            // 
            // tbamtpaid
            // 
            this.tbamtpaid.Depth = 0;
            this.tbamtpaid.Hint = "";
            this.tbamtpaid.Location = new System.Drawing.Point(94, 291);
            this.tbamtpaid.MaxLength = 32767;
            this.tbamtpaid.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbamtpaid.Name = "tbamtpaid";
            this.tbamtpaid.PasswordChar = '\0';
            this.tbamtpaid.SelectedText = "";
            this.tbamtpaid.SelectionLength = 0;
            this.tbamtpaid.SelectionStart = 0;
            this.tbamtpaid.Size = new System.Drawing.Size(60, 23);
            this.tbamtpaid.TabIndex = 15;
            this.tbamtpaid.TabStop = false;
            this.tbamtpaid.Text = "0.0";
            this.tbamtpaid.UseSystemPasswordChar = false;
            this.tbamtpaid.Click += new System.EventHandler(this.tbamtpaid_Click);
            this.tbamtpaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbamtpaid_KeyDown);
            this.tbamtpaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbamtpaid_KeyPress);
            this.tbamtpaid.Leave += new System.EventHandler(this.tbamtpaid_Leave);
            this.tbamtpaid.TextChanged += new System.EventHandler(this.tbamtpaid_TextChanged);
            // 
            // tbbaldue
            // 
            this.tbbaldue.Depth = 0;
            this.tbbaldue.Enabled = false;
            this.tbbaldue.Hint = "";
            this.tbbaldue.Location = new System.Drawing.Point(94, 361);
            this.tbbaldue.MaxLength = 32767;
            this.tbbaldue.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbbaldue.Name = "tbbaldue";
            this.tbbaldue.PasswordChar = '\0';
            this.tbbaldue.SelectedText = "";
            this.tbbaldue.SelectionLength = 0;
            this.tbbaldue.SelectionStart = 0;
            this.tbbaldue.Size = new System.Drawing.Size(60, 23);
            this.tbbaldue.TabIndex = 16;
            this.tbbaldue.TabStop = false;
            this.tbbaldue.Text = "0.0";
            this.tbbaldue.UseSystemPasswordChar = false;
            this.tbbaldue.Click += new System.EventHandler(this.tbbaldue_Click);
            this.tbbaldue.Leave += new System.EventHandler(this.tbbaldue_Leave);
            // 
            // btnaddpayment
            // 
            this.btnaddpayment.AutoSize = true;
            this.btnaddpayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnaddpayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaddpayment.Depth = 0;
            this.btnaddpayment.Icon = null;
            this.btnaddpayment.Location = new System.Drawing.Point(94, 398);
            this.btnaddpayment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnaddpayment.Name = "btnaddpayment";
            this.btnaddpayment.Primary = true;
            this.btnaddpayment.Size = new System.Drawing.Size(116, 36);
            this.btnaddpayment.TabIndex = 17;
            this.btnaddpayment.Text = "Add Payment";
            this.btnaddpayment.UseVisualStyleBackColor = true;
            this.btnaddpayment.Click += new System.EventHandler(this.btnaddpayment_Click);
            // 
            // calenderduedate
            // 
            this.calenderduedate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.calenderduedate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calenderduedate.Location = new System.Drawing.Point(39, 237);
            this.calenderduedate.MaxSelectionCount = 1;
            this.calenderduedate.Name = "calenderduedate";
            this.calenderduedate.TabIndex = 13;
            this.calenderduedate.Visible = false;
            this.calenderduedate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calenderduedate_DateSelected);
            this.calenderduedate.MouseLeave += new System.EventHandler(this.calenderduedate_MouseLeave);
            // 
            // lberror
            // 
            this.lberror.AutoSize = true;
            this.lberror.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lberror.Location = new System.Drawing.Point(12, 108);
            this.lberror.Name = "lberror";
            this.lberror.Size = new System.Drawing.Size(58, 13);
            this.lberror.TabIndex = 26;
            this.lberror.Text = "*User Error";
            this.lberror.Visible = false;
            // 
            // btnmorepaidamt
            // 
            this.btnmorepaidamt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnmorepaidamt.FlatAppearance.BorderSize = 0;
            this.btnmorepaidamt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmorepaidamt.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmorepaidamt.ForeColor = System.Drawing.Color.DimGray;
            this.btnmorepaidamt.Location = new System.Drawing.Point(191, 309);
            this.btnmorepaidamt.Name = "btnmorepaidamt";
            this.btnmorepaidamt.Size = new System.Drawing.Size(75, 47);
            this.btnmorepaidamt.TabIndex = 28;
            this.btnmorepaidamt.Text = "MORE PAID AMOUNT";
            this.btnmorepaidamt.UseVisualStyleBackColor = false;
            this.btnmorepaidamt.Click += new System.EventHandler(this.btnmorepaidamt_Click);
            // 
            // tbmoreamtpaid
            // 
            this.tbmoreamtpaid.Depth = 0;
            this.tbmoreamtpaid.Hint = "";
            this.tbmoreamtpaid.Location = new System.Drawing.Point(94, 326);
            this.tbmoreamtpaid.MaxLength = 32767;
            this.tbmoreamtpaid.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbmoreamtpaid.Name = "tbmoreamtpaid";
            this.tbmoreamtpaid.PasswordChar = '\0';
            this.tbmoreamtpaid.SelectedText = "";
            this.tbmoreamtpaid.SelectionLength = 0;
            this.tbmoreamtpaid.SelectionStart = 0;
            this.tbmoreamtpaid.Size = new System.Drawing.Size(60, 23);
            this.tbmoreamtpaid.TabIndex = 29;
            this.tbmoreamtpaid.TabStop = false;
            this.tbmoreamtpaid.Text = "0.0";
            this.tbmoreamtpaid.UseSystemPasswordChar = false;
            this.tbmoreamtpaid.Visible = false;
            this.tbmoreamtpaid.Click += new System.EventHandler(this.tbmoreamtpaid_Click);
            this.tbmoreamtpaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbmoreamtpaid_KeyPress);
            this.tbmoreamtpaid.Leave += new System.EventHandler(this.tbmoreamtpaid_Leave);
            this.tbmoreamtpaid.TextChanged += new System.EventHandler(this.tbmoreamtpaid_TextChanged);
            // 
            // newPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.calenderduedate);
            this.Controls.Add(this.tbmoreamtpaid);
            this.Controls.Add(this.btnmorepaidamt);
            this.Controls.Add(this.lberror);
            this.Controls.Add(this.btnaddpayment);
            this.Controls.Add(this.tbbaldue);
            this.Controls.Add(this.tbamtpaid);
            this.Controls.Add(this.tbamt);
            this.Controls.Add(this.tbduedate);
            this.Controls.Add(this.tbmobilenumber);
            this.Controls.Add(this.tblastname);
            this.Controls.Add(this.tbfirstname);
            this.Controls.Add(this.lbbaldue);
            this.Controls.Add(this.lbamountpaid);
            this.Controls.Add(this.lbamount);
            this.Controls.Add(this.lbduedate);
            this.Controls.Add(this.lbmobilenumber);
            this.Controls.Add(this.lblastname);
            this.Controls.Add(this.lbfirstname);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "newPayment";
            this.Size = new System.Drawing.Size(280, 455);
            this.VisibleChanged += new System.EventHandler(this.newPayment_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbfirstname;
        private System.Windows.Forms.Label lblastname;
        private System.Windows.Forms.Label lbmobilenumber;
        private System.Windows.Forms.Label lbduedate;
        private System.Windows.Forms.Label lbamount;
        private System.Windows.Forms.Label lbamountpaid;
        private System.Windows.Forms.Label lbbaldue;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbfirstname;
        private MaterialSkin.Controls.MaterialSingleLineTextField tblastname;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbmobilenumber;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbduedate;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbamt;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbamtpaid;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbbaldue;
        private MaterialSkin.Controls.MaterialRaisedButton btnaddpayment;
        private System.Windows.Forms.Label lbpatientpayment;
        private System.Windows.Forms.Label lbpatientinformation;
        private System.Windows.Forms.MonthCalendar calenderduedate;
        private System.Windows.Forms.Label lberror;
        private System.Windows.Forms.Button btnmorepaidamt;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbmoreamtpaid;
    }
}
