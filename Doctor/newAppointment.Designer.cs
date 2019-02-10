namespace Doctor
{
    partial class newAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newAppointment));
            this.calenderdate = new System.Windows.Forms.MonthCalendar();
            this.lberror = new System.Windows.Forms.Label();
            this.btnaddappointment = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tbdate = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbmobilenumber = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tblastname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbfirstname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbdate = new System.Windows.Forms.Label();
            this.lbmobilenumber = new System.Windows.Forms.Label();
            this.lblastname = new System.Windows.Forms.Label();
            this.lbfirstname = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbpatientinformation = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbpatientappointment = new System.Windows.Forms.Label();
            this.lbtimeslot = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.cbtimeslot = new System.Windows.Forms.ComboBox();
            this.tbage = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbgender = new System.Windows.Forms.Label();
            this.rbmale = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbfemale = new MaterialSkin.Controls.MaterialRadioButton();
            this.lbage = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            this.SuspendLayout();
            // 
            // calenderdate
            // 
            this.calenderdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.calenderdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calenderdate.Location = new System.Drawing.Point(42, 236);
            this.calenderdate.MaxSelectionCount = 1;
            this.calenderdate.Name = "calenderdate";
            this.calenderdate.TabIndex = 43;
            this.calenderdate.Visible = false;
            this.calenderdate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calenderdate_DateSelected);
            this.calenderdate.MouseLeave += new System.EventHandler(this.calenderdate_MouseLeave);
            // 
            // lberror
            // 
            this.lberror.AutoSize = true;
            this.lberror.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lberror.Location = new System.Drawing.Point(13, 108);
            this.lberror.Name = "lberror";
            this.lberror.Size = new System.Drawing.Size(58, 13);
            this.lberror.TabIndex = 51;
            this.lberror.Text = "*User Error";
            this.lberror.Visible = false;
            // 
            // btnaddappointment
            // 
            this.btnaddappointment.AutoSize = true;
            this.btnaddappointment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnaddappointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaddappointment.Depth = 0;
            this.btnaddappointment.Icon = null;
            this.btnaddappointment.Location = new System.Drawing.Point(95, 381);
            this.btnaddappointment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnaddappointment.Name = "btnaddappointment";
            this.btnaddappointment.Primary = true;
            this.btnaddappointment.Size = new System.Drawing.Size(147, 36);
            this.btnaddappointment.TabIndex = 48;
            this.btnaddappointment.Text = "Add Appointment";
            this.btnaddappointment.UseVisualStyleBackColor = true;
            this.btnaddappointment.Click += new System.EventHandler(this.btnaddpayment_Click);
            // 
            // tbdate
            // 
            this.tbdate.Depth = 0;
            this.tbdate.Hint = "";
            this.tbdate.Location = new System.Drawing.Point(150, 285);
            this.tbdate.MaxLength = 32767;
            this.tbdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbdate.Name = "tbdate";
            this.tbdate.PasswordChar = '\0';
            this.tbdate.SelectedText = "";
            this.tbdate.SelectionLength = 0;
            this.tbdate.SelectionStart = 0;
            this.tbdate.Size = new System.Drawing.Size(119, 23);
            this.tbdate.TabIndex = 7;
            this.tbdate.TabStop = false;
            this.tbdate.Text = "Select Date";
            this.tbdate.UseSystemPasswordChar = false;
            this.tbdate.Click += new System.EventHandler(this.tbdate_Click);
            this.tbdate.Leave += new System.EventHandler(this.tbdate_Leave);
            this.tbdate.TextChanged += new System.EventHandler(this.tbdate_TextChanged);
            // 
            // tbmobilenumber
            // 
            this.tbmobilenumber.Depth = 0;
            this.tbmobilenumber.Hint = "";
            this.tbmobilenumber.Location = new System.Drawing.Point(15, 285);
            this.tbmobilenumber.MaxLength = 10;
            this.tbmobilenumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbmobilenumber.Name = "tbmobilenumber";
            this.tbmobilenumber.PasswordChar = '\0';
            this.tbmobilenumber.SelectedText = "";
            this.tbmobilenumber.SelectionLength = 0;
            this.tbmobilenumber.SelectionStart = 0;
            this.tbmobilenumber.Size = new System.Drawing.Size(119, 23);
            this.tbmobilenumber.TabIndex = 6;
            this.tbmobilenumber.TabStop = false;
            this.tbmobilenumber.Text = "Number";
            this.tbmobilenumber.UseSystemPasswordChar = false;
            this.tbmobilenumber.Click += new System.EventHandler(this.tbmobilenumber_Click);
            this.tbmobilenumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbmobilenumber_KeyPress);
            this.tbmobilenumber.Leave += new System.EventHandler(this.tbmobilenumber_Leave);
            // 
            // tblastname
            // 
            this.tblastname.Depth = 0;
            this.tblastname.Hint = "";
            this.tblastname.Location = new System.Drawing.Point(148, 147);
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
            // tbfirstname
            // 
            this.tbfirstname.Depth = 0;
            this.tbfirstname.Hint = "";
            this.tbfirstname.Location = new System.Drawing.Point(14, 147);
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
            // lbdate
            // 
            this.lbdate.AutoSize = true;
            this.lbdate.Location = new System.Drawing.Point(147, 265);
            this.lbdate.Name = "lbdate";
            this.lbdate.Size = new System.Drawing.Size(30, 13);
            this.lbdate.TabIndex = 42;
            this.lbdate.Text = "Date";
            // 
            // lbmobilenumber
            // 
            this.lbmobilenumber.AutoSize = true;
            this.lbmobilenumber.Location = new System.Drawing.Point(12, 265);
            this.lbmobilenumber.Name = "lbmobilenumber";
            this.lbmobilenumber.Size = new System.Drawing.Size(78, 13);
            this.lbmobilenumber.TabIndex = 41;
            this.lbmobilenumber.Text = "Mobile Number";
            // 
            // lblastname
            // 
            this.lblastname.AutoSize = true;
            this.lblastname.Location = new System.Drawing.Point(145, 126);
            this.lblastname.Name = "lblastname";
            this.lblastname.Size = new System.Drawing.Size(58, 13);
            this.lblastname.TabIndex = 40;
            this.lblastname.Text = "Last Name";
            // 
            // lbfirstname
            // 
            this.lbfirstname.AutoSize = true;
            this.lbfirstname.Location = new System.Drawing.Point(13, 126);
            this.lbfirstname.Name = "lbfirstname";
            this.lbfirstname.Size = new System.Drawing.Size(57, 13);
            this.lbfirstname.TabIndex = 39;
            this.lbfirstname.Text = "First Name";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Location = new System.Drawing.Point(7, 442);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(269, 1);
            this.panel5.TabIndex = 38;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Location = new System.Drawing.Point(275, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 337);
            this.panel4.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(6, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 337);
            this.panel3.TabIndex = 33;
            // 
            // lbpatientinformation
            // 
            this.lbpatientinformation.AutoSize = true;
            this.lbpatientinformation.ForeColor = System.Drawing.Color.DimGray;
            this.lbpatientinformation.Location = new System.Drawing.Point(7, 5);
            this.lbpatientinformation.Name = "lbpatientinformation";
            this.lbpatientinformation.Size = new System.Drawing.Size(95, 13);
            this.lbpatientinformation.TabIndex = 28;
            this.lbpatientinformation.Text = "Patient Information";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbpatientinformation);
            this.panel2.Location = new System.Drawing.Point(6, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 40);
            this.panel2.TabIndex = 31;
            // 
            // lbpatientappointment
            // 
            this.lbpatientappointment.AutoSize = true;
            this.lbpatientappointment.ForeColor = System.Drawing.Color.White;
            this.lbpatientappointment.Location = new System.Drawing.Point(7, 14);
            this.lbpatientappointment.Name = "lbpatientappointment";
            this.lbpatientappointment.Size = new System.Drawing.Size(102, 13);
            this.lbpatientappointment.TabIndex = 27;
            this.lbpatientappointment.Text = "Patient Appointment";
            // 
            // lbtimeslot
            // 
            this.lbtimeslot.AutoSize = true;
            this.lbtimeslot.Location = new System.Drawing.Point(13, 344);
            this.lbtimeslot.Name = "lbtimeslot";
            this.lbtimeslot.Size = new System.Drawing.Size(51, 13);
            this.lbtimeslot.TabIndex = 50;
            this.lbtimeslot.Text = "Time Slot";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.panel1.Controls.Add(this.lbpatientappointment);
            this.panel1.Controls.Add(this.pbclose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 56);
            this.panel1.TabIndex = 30;
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
            // cbtimeslot
            // 
            this.cbtimeslot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.cbtimeslot.DropDownHeight = 75;
            this.cbtimeslot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtimeslot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbtimeslot.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtimeslot.FormattingEnabled = true;
            this.cbtimeslot.IntegralHeight = false;
            this.cbtimeslot.ItemHeight = 14;
            this.cbtimeslot.Location = new System.Drawing.Point(95, 336);
            this.cbtimeslot.Name = "cbtimeslot";
            this.cbtimeslot.Size = new System.Drawing.Size(122, 22);
            this.cbtimeslot.TabIndex = 8;
            this.cbtimeslot.Click += new System.EventHandler(this.cbtimeslot_Click);
            // 
            // tbage
            // 
            this.tbage.Depth = 0;
            this.tbage.Hint = "";
            this.tbage.Location = new System.Drawing.Point(150, 210);
            this.tbage.MaxLength = 3;
            this.tbage.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbage.Name = "tbage";
            this.tbage.PasswordChar = '\0';
            this.tbage.SelectedText = "";
            this.tbage.SelectionLength = 0;
            this.tbage.SelectionStart = 0;
            this.tbage.Size = new System.Drawing.Size(119, 23);
            this.tbage.TabIndex = 5;
            this.tbage.TabStop = false;
            this.tbage.Text = "Age";
            this.tbage.UseSystemPasswordChar = false;
            this.tbage.Click += new System.EventHandler(this.tbage_Click);
            this.tbage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbage_KeyPress);
            this.tbage.Leave += new System.EventHandler(this.tbage_Leave);
            // 
            // lbgender
            // 
            this.lbgender.AutoSize = true;
            this.lbgender.Location = new System.Drawing.Point(17, 194);
            this.lbgender.Name = "lbgender";
            this.lbgender.Size = new System.Drawing.Size(42, 13);
            this.lbgender.TabIndex = 54;
            this.lbgender.Text = "Gender";
            // 
            // rbmale
            // 
            this.rbmale.AutoSize = true;
            this.rbmale.Depth = 0;
            this.rbmale.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbmale.Location = new System.Drawing.Point(7, 210);
            this.rbmale.Margin = new System.Windows.Forms.Padding(0);
            this.rbmale.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbmale.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbmale.Name = "rbmale";
            this.rbmale.Ripple = true;
            this.rbmale.Size = new System.Drawing.Size(59, 30);
            this.rbmale.TabIndex = 3;
            this.rbmale.TabStop = true;
            this.rbmale.Text = "Male";
            this.rbmale.UseVisualStyleBackColor = true;
            // 
            // rbfemale
            // 
            this.rbfemale.AutoSize = true;
            this.rbfemale.Depth = 0;
            this.rbfemale.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbfemale.Location = new System.Drawing.Point(66, 210);
            this.rbfemale.Margin = new System.Windows.Forms.Padding(0);
            this.rbfemale.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbfemale.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbfemale.Name = "rbfemale";
            this.rbfemale.Ripple = true;
            this.rbfemale.Size = new System.Drawing.Size(74, 30);
            this.rbfemale.TabIndex = 4;
            this.rbfemale.TabStop = true;
            this.rbfemale.Text = "Female";
            this.rbfemale.UseVisualStyleBackColor = true;
            // 
            // lbage
            // 
            this.lbage.AutoSize = true;
            this.lbage.Location = new System.Drawing.Point(147, 190);
            this.lbage.Name = "lbage";
            this.lbage.Size = new System.Drawing.Size(26, 13);
            this.lbage.TabIndex = 57;
            this.lbage.Text = "Age";
            // 
            // newAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.calenderdate);
            this.Controls.Add(this.lbage);
            this.Controls.Add(this.rbfemale);
            this.Controls.Add(this.rbmale);
            this.Controls.Add(this.tbage);
            this.Controls.Add(this.lbgender);
            this.Controls.Add(this.cbtimeslot);
            this.Controls.Add(this.lberror);
            this.Controls.Add(this.btnaddappointment);
            this.Controls.Add(this.tbdate);
            this.Controls.Add(this.tbmobilenumber);
            this.Controls.Add(this.tblastname);
            this.Controls.Add(this.tbfirstname);
            this.Controls.Add(this.lbdate);
            this.Controls.Add(this.lbmobilenumber);
            this.Controls.Add(this.lblastname);
            this.Controls.Add(this.lbfirstname);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbtimeslot);
            this.Controls.Add(this.panel1);
            this.Name = "newAppointment";
            this.Size = new System.Drawing.Size(280, 455);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calenderdate;
        private System.Windows.Forms.Label lberror;
        private MaterialSkin.Controls.MaterialRaisedButton btnaddappointment;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbdate;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbmobilenumber;
        private MaterialSkin.Controls.MaterialSingleLineTextField tblastname;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbfirstname;
        private System.Windows.Forms.Label lbdate;
        private System.Windows.Forms.Label lbmobilenumber;
        private System.Windows.Forms.Label lblastname;
        private System.Windows.Forms.Label lbfirstname;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbpatientinformation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbpatientappointment;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.Label lbtimeslot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbtimeslot;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbage;
        private System.Windows.Forms.Label lbgender;
        private MaterialSkin.Controls.MaterialRadioButton rbmale;
        private MaterialSkin.Controls.MaterialRadioButton rbfemale;
        private System.Windows.Forms.Label lbage;
    }
}
