namespace Doctor
{
    partial class newVaccination
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newVaccination));
            this.lbpatientinformation = new System.Windows.Forms.Label();
            this.lbpatientvaccination = new System.Windows.Forms.Label();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.calenderdate = new System.Windows.Forms.MonthCalendar();
            this.lbage = new System.Windows.Forms.Label();
            this.rbfemale = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbmale = new MaterialSkin.Controls.MaterialRadioButton();
            this.tbage = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbgender = new System.Windows.Forms.Label();
            this.cbtimeslot = new System.Windows.Forms.ComboBox();
            this.lberror = new System.Windows.Forms.Label();
            this.btnaddvaccination = new MaterialSkin.Controls.MaterialRaisedButton();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbtimeslot = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbvaccinationtype = new System.Windows.Forms.Label();
            this.cbvaccinationtype = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // lbpatientvaccination
            // 
            this.lbpatientvaccination.AutoSize = true;
            this.lbpatientvaccination.ForeColor = System.Drawing.Color.White;
            this.lbpatientvaccination.Location = new System.Drawing.Point(7, 14);
            this.lbpatientvaccination.Name = "lbpatientvaccination";
            this.lbpatientvaccination.Size = new System.Drawing.Size(99, 13);
            this.lbpatientvaccination.TabIndex = 27;
            this.lbpatientvaccination.Text = "Patient Vaccination";
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
            // calenderdate
            // 
            this.calenderdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.calenderdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calenderdate.Location = new System.Drawing.Point(42, 231);
            this.calenderdate.MaxSelectionCount = 1;
            this.calenderdate.Name = "calenderdate";
            this.calenderdate.TabIndex = 75;
            this.calenderdate.Visible = false;
            this.calenderdate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calenderdate_DateSelected);
            this.calenderdate.MouseLeave += new System.EventHandler(this.calenderdate_MouseLeave);
            this.calenderdate.MouseHover += new System.EventHandler(this.calenderdate_MouseHover);
            // 
            // lbage
            // 
            this.lbage.AutoSize = true;
            this.lbage.Location = new System.Drawing.Point(147, 183);
            this.lbage.Name = "lbage";
            this.lbage.Size = new System.Drawing.Size(26, 13);
            this.lbage.TabIndex = 80;
            this.lbage.Text = "Age";
            // 
            // rbfemale
            // 
            this.rbfemale.AutoSize = true;
            this.rbfemale.Depth = 0;
            this.rbfemale.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbfemale.Location = new System.Drawing.Point(66, 203);
            this.rbfemale.Margin = new System.Windows.Forms.Padding(0);
            this.rbfemale.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbfemale.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbfemale.Name = "rbfemale";
            this.rbfemale.Ripple = true;
            this.rbfemale.Size = new System.Drawing.Size(74, 30);
            this.rbfemale.TabIndex = 61;
            this.rbfemale.TabStop = true;
            this.rbfemale.Text = "Female";
            this.rbfemale.UseVisualStyleBackColor = true;
            // 
            // rbmale
            // 
            this.rbmale.AutoSize = true;
            this.rbmale.Depth = 0;
            this.rbmale.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbmale.Location = new System.Drawing.Point(7, 203);
            this.rbmale.Margin = new System.Windows.Forms.Padding(0);
            this.rbmale.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbmale.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbmale.Name = "rbmale";
            this.rbmale.Ripple = true;
            this.rbmale.Size = new System.Drawing.Size(59, 30);
            this.rbmale.TabIndex = 60;
            this.rbmale.TabStop = true;
            this.rbmale.Text = "Male";
            this.rbmale.UseVisualStyleBackColor = true;
            // 
            // tbage
            // 
            this.tbage.Depth = 0;
            this.tbage.Hint = "";
            this.tbage.Location = new System.Drawing.Point(150, 203);
            this.tbage.MaxLength = 3;
            this.tbage.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbage.Name = "tbage";
            this.tbage.PasswordChar = '\0';
            this.tbage.SelectedText = "";
            this.tbage.SelectionLength = 0;
            this.tbage.SelectionStart = 0;
            this.tbage.Size = new System.Drawing.Size(119, 23);
            this.tbage.TabIndex = 62;
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
            this.lbgender.Location = new System.Drawing.Point(17, 187);
            this.lbgender.Name = "lbgender";
            this.lbgender.Size = new System.Drawing.Size(42, 13);
            this.lbgender.TabIndex = 79;
            this.lbgender.Text = "Gender";
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
            this.cbtimeslot.Location = new System.Drawing.Point(95, 306);
            this.cbtimeslot.Name = "cbtimeslot";
            this.cbtimeslot.Size = new System.Drawing.Size(122, 22);
            this.cbtimeslot.TabIndex = 65;
            this.cbtimeslot.Click += new System.EventHandler(this.cbtimeslot_Click);
            // 
            // lberror
            // 
            this.lberror.AutoSize = true;
            this.lberror.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lberror.Location = new System.Drawing.Point(13, 109);
            this.lberror.Name = "lberror";
            this.lberror.Size = new System.Drawing.Size(58, 13);
            this.lberror.TabIndex = 78;
            this.lberror.Text = "*User Error";
            this.lberror.Visible = false;
            // 
            // btnaddvaccination
            // 
            this.btnaddvaccination.AutoSize = true;
            this.btnaddvaccination.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnaddvaccination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaddvaccination.Depth = 0;
            this.btnaddvaccination.Icon = null;
            this.btnaddvaccination.Location = new System.Drawing.Point(95, 401);
            this.btnaddvaccination.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnaddvaccination.Name = "btnaddvaccination";
            this.btnaddvaccination.Primary = true;
            this.btnaddvaccination.Size = new System.Drawing.Size(142, 36);
            this.btnaddvaccination.TabIndex = 76;
            this.btnaddvaccination.Text = "Add Vaccination";
            this.btnaddvaccination.UseVisualStyleBackColor = true;
            this.btnaddvaccination.Click += new System.EventHandler(this.btnaddvaccination_Click);
            // 
            // tbdate
            // 
            this.tbdate.Depth = 0;
            this.tbdate.Hint = "";
            this.tbdate.Location = new System.Drawing.Point(150, 267);
            this.tbdate.MaxLength = 32767;
            this.tbdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbdate.Name = "tbdate";
            this.tbdate.PasswordChar = '\0';
            this.tbdate.SelectedText = "";
            this.tbdate.SelectionLength = 0;
            this.tbdate.SelectionStart = 0;
            this.tbdate.Size = new System.Drawing.Size(119, 23);
            this.tbdate.TabIndex = 64;
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
            this.tbmobilenumber.Location = new System.Drawing.Point(15, 267);
            this.tbmobilenumber.MaxLength = 10;
            this.tbmobilenumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbmobilenumber.Name = "tbmobilenumber";
            this.tbmobilenumber.PasswordChar = '\0';
            this.tbmobilenumber.SelectedText = "";
            this.tbmobilenumber.SelectionLength = 0;
            this.tbmobilenumber.SelectionStart = 0;
            this.tbmobilenumber.Size = new System.Drawing.Size(119, 23);
            this.tbmobilenumber.TabIndex = 63;
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
            this.tblastname.Location = new System.Drawing.Point(148, 148);
            this.tblastname.MaxLength = 32767;
            this.tblastname.MouseState = MaterialSkin.MouseState.HOVER;
            this.tblastname.Name = "tblastname";
            this.tblastname.PasswordChar = '\0';
            this.tblastname.SelectedText = "";
            this.tblastname.SelectionLength = 0;
            this.tblastname.SelectionStart = 0;
            this.tblastname.Size = new System.Drawing.Size(119, 23);
            this.tblastname.TabIndex = 59;
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
            this.tbfirstname.Location = new System.Drawing.Point(14, 148);
            this.tbfirstname.MaxLength = 32767;
            this.tbfirstname.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbfirstname.Name = "tbfirstname";
            this.tbfirstname.PasswordChar = '\0';
            this.tbfirstname.SelectedText = "";
            this.tbfirstname.SelectionLength = 0;
            this.tbfirstname.SelectionStart = 0;
            this.tbfirstname.Size = new System.Drawing.Size(119, 23);
            this.tbfirstname.TabIndex = 58;
            this.tbfirstname.TabStop = false;
            this.tbfirstname.Text = "First Name";
            this.tbfirstname.UseSystemPasswordChar = false;
            this.tbfirstname.Click += new System.EventHandler(this.tbfirstname_Click);
            this.tbfirstname.Leave += new System.EventHandler(this.tbfirstname_Leave);
            // 
            // lbdate
            // 
            this.lbdate.AutoSize = true;
            this.lbdate.Location = new System.Drawing.Point(147, 247);
            this.lbdate.Name = "lbdate";
            this.lbdate.Size = new System.Drawing.Size(30, 13);
            this.lbdate.TabIndex = 74;
            this.lbdate.Text = "Date";
            // 
            // lbmobilenumber
            // 
            this.lbmobilenumber.AutoSize = true;
            this.lbmobilenumber.Location = new System.Drawing.Point(12, 247);
            this.lbmobilenumber.Name = "lbmobilenumber";
            this.lbmobilenumber.Size = new System.Drawing.Size(78, 13);
            this.lbmobilenumber.TabIndex = 73;
            this.lbmobilenumber.Text = "Mobile Number";
            // 
            // lblastname
            // 
            this.lblastname.AutoSize = true;
            this.lblastname.Location = new System.Drawing.Point(145, 127);
            this.lblastname.Name = "lblastname";
            this.lblastname.Size = new System.Drawing.Size(58, 13);
            this.lblastname.TabIndex = 72;
            this.lblastname.Text = "Last Name";
            // 
            // lbfirstname
            // 
            this.lbfirstname.AutoSize = true;
            this.lbfirstname.Location = new System.Drawing.Point(13, 127);
            this.lbfirstname.Name = "lbfirstname";
            this.lbfirstname.Size = new System.Drawing.Size(57, 13);
            this.lbfirstname.TabIndex = 71;
            this.lbfirstname.Text = "First Name";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Location = new System.Drawing.Point(7, 443);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(269, 1);
            this.panel5.TabIndex = 70;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Location = new System.Drawing.Point(275, 106);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 337);
            this.panel4.TabIndex = 69;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(6, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 337);
            this.panel3.TabIndex = 68;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbpatientinformation);
            this.panel2.Location = new System.Drawing.Point(6, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 40);
            this.panel2.TabIndex = 67;
            // 
            // lbtimeslot
            // 
            this.lbtimeslot.AutoSize = true;
            this.lbtimeslot.Location = new System.Drawing.Point(13, 314);
            this.lbtimeslot.Name = "lbtimeslot";
            this.lbtimeslot.Size = new System.Drawing.Size(51, 13);
            this.lbtimeslot.TabIndex = 77;
            this.lbtimeslot.Text = "Time Slot";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.panel1.Controls.Add(this.lbpatientvaccination);
            this.panel1.Controls.Add(this.pbclose);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 56);
            this.panel1.TabIndex = 66;
            // 
            // lbvaccinationtype
            // 
            this.lbvaccinationtype.AutoSize = true;
            this.lbvaccinationtype.Location = new System.Drawing.Point(15, 345);
            this.lbvaccinationtype.Name = "lbvaccinationtype";
            this.lbvaccinationtype.Size = new System.Drawing.Size(90, 13);
            this.lbvaccinationtype.TabIndex = 82;
            this.lbvaccinationtype.Text = "Vaccination Type";
            // 
            // cbvaccinationtype
            // 
            this.cbvaccinationtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbvaccinationtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbvaccinationtype.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbvaccinationtype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.cbvaccinationtype.FormattingEnabled = true;
            this.cbvaccinationtype.Items.AddRange(new object[] {
            "All",
            "Hepatitis B (Hep – B1)",
            "Diptheria, Tetanus and Pertussis vaccine (DTwP 1)",
            "Inactivated polio vaccine (IPV 1)",
            "Hepatitis B  (Hep – B2)",
            "Haemophilus influenzae type B (Hib 1)",
            "Rotavirus 1",
            "Pneumococcal conjugate vaccine (PCV 1)",
            "Diptheria, Tetanus and Pertussis vaccine (DTwP 2)",
            "Inactivated polio vaccine (IPV 2)",
            "Haemophilus influenzae type B (Hib 2)",
            "Rotavirus 2",
            "Pneumococcal conjugate vaccine (PCV 2)",
            "Diptheria, Tetanus and Pertussis vaccine (DTwP 3)",
            "Inactivated polio vaccine (IPV 3)",
            "Haemophilus influenzae type B (Hib 3)",
            "Rotavirus 3",
            "Pneumococcal conjugate vaccine (PCV 3)",
            "Oral polio vaccine (OPV 1)",
            "Hepatitis B (Hep – B3)",
            "Oral polio vaccine (OPV 2)",
            "Measles, Mumps, and Rubella (MMR – 1)",
            "Typhoid Conjugate Vaccine",
            "Hepatitis A (Hep – A1)",
            "Measles, Mumps, and Rubella (MMR 2)",
            "Varicella 1",
            "PCV booster",
            "Diphtheria, Perussis, and Tetanus (DTwP B1/DTaP B1)",
            "Inactivated polio vaccine (IPV B1)",
            "Haemophilus influenzae type B (Hib B1)",
            "Hepatitis A (Hep – A2)",
            "Booster of Typhoid Conjugate Vaccine",
            "Diphtheria, Perussis, and Tetanus (DTwP B2/DTaP B2)",
            "Oral polio vaccine (OPV 3)",
            "Varicella 2",
            "Measles, Mumps, and Rubella (MMR 3)",
            "Tdap/Td",
            "Human Papilloma Virus (HPV)"});
            this.cbvaccinationtype.Location = new System.Drawing.Point(16, 370);
            this.cbvaccinationtype.Name = "cbvaccinationtype";
            this.cbvaccinationtype.Size = new System.Drawing.Size(251, 23);
            this.cbvaccinationtype.TabIndex = 81;
            this.cbvaccinationtype.TabStop = false;
            this.cbvaccinationtype.Click += new System.EventHandler(this.cbvaccinationtype_Click);
            // 
            // newVaccination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.calenderdate);
            this.Controls.Add(this.lbvaccinationtype);
            this.Controls.Add(this.cbvaccinationtype);
            this.Controls.Add(this.lbage);
            this.Controls.Add(this.rbfemale);
            this.Controls.Add(this.rbmale);
            this.Controls.Add(this.tbage);
            this.Controls.Add(this.lbgender);
            this.Controls.Add(this.cbtimeslot);
            this.Controls.Add(this.lberror);
            this.Controls.Add(this.btnaddvaccination);
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
            this.Name = "newVaccination";
            this.Size = new System.Drawing.Size(280, 445);
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbpatientinformation;
        private System.Windows.Forms.Label lbpatientvaccination;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.MonthCalendar calenderdate;
        private System.Windows.Forms.Label lbage;
        private MaterialSkin.Controls.MaterialRadioButton rbfemale;
        private MaterialSkin.Controls.MaterialRadioButton rbmale;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbage;
        private System.Windows.Forms.Label lbgender;
        private System.Windows.Forms.ComboBox cbtimeslot;
        private System.Windows.Forms.Label lberror;
        private MaterialSkin.Controls.MaterialRaisedButton btnaddvaccination;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbtimeslot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbvaccinationtype;
        private System.Windows.Forms.ComboBox cbvaccinationtype;
    }
}
