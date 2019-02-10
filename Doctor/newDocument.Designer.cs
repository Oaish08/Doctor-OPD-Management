namespace Doctor
{
    partial class newDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newDocument));
            this.calenderdate = new System.Windows.Forms.MonthCalendar();
            this.lbpatientdocument = new System.Windows.Forms.Label();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.lbpatientinformation = new System.Windows.Forms.Label();
            this.lbage = new System.Windows.Forms.Label();
            this.rbfemale = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbmale = new MaterialSkin.Controls.MaterialRadioButton();
            this.tbage = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbgender = new System.Windows.Forms.Label();
            this.lberror = new System.Windows.Forms.Label();
            this.btnadddocument = new MaterialSkin.Controls.MaterialRaisedButton();
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
            this.lbdocument = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbdocuments = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.tbugcid = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbugcid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calenderdate
            // 
            this.calenderdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.calenderdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calenderdate.Location = new System.Drawing.Point(42, 287);
            this.calenderdate.MaxSelectionCount = 1;
            this.calenderdate.Name = "calenderdate";
            this.calenderdate.TabIndex = 75;
            this.calenderdate.Visible = false;
            this.calenderdate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calenderdate_DateSelected);
            this.calenderdate.MouseLeave += new System.EventHandler(this.calenderdate_MouseLeave);
            // 
            // lbpatientdocument
            // 
            this.lbpatientdocument.AutoSize = true;
            this.lbpatientdocument.ForeColor = System.Drawing.Color.White;
            this.lbpatientdocument.Location = new System.Drawing.Point(7, 14);
            this.lbpatientdocument.Name = "lbpatientdocument";
            this.lbpatientdocument.Size = new System.Drawing.Size(92, 13);
            this.lbpatientdocument.TabIndex = 27;
            this.lbpatientdocument.Text = "Patient Document";
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
            // lbage
            // 
            this.lbage.AutoSize = true;
            this.lbage.Location = new System.Drawing.Point(147, 241);
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
            this.rbfemale.Location = new System.Drawing.Point(66, 261);
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
            this.rbmale.Location = new System.Drawing.Point(7, 261);
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
            this.tbage.Location = new System.Drawing.Point(150, 261);
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
            this.lbgender.Location = new System.Drawing.Point(17, 245);
            this.lbgender.Name = "lbgender";
            this.lbgender.Size = new System.Drawing.Size(42, 13);
            this.lbgender.TabIndex = 79;
            this.lbgender.Text = "Gender";
            // 
            // lberror
            // 
            this.lberror.AutoSize = true;
            this.lberror.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lberror.Location = new System.Drawing.Point(13, 108);
            this.lberror.Name = "lberror";
            this.lberror.Size = new System.Drawing.Size(58, 13);
            this.lberror.TabIndex = 78;
            this.lberror.Text = "*User Error";
            this.lberror.Visible = false;
            // 
            // btnadddocument
            // 
            this.btnadddocument.AutoSize = true;
            this.btnadddocument.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnadddocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadddocument.Depth = 0;
            this.btnadddocument.Icon = null;
            this.btnadddocument.Location = new System.Drawing.Point(66, 429);
            this.btnadddocument.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnadddocument.Name = "btnadddocument";
            this.btnadddocument.Primary = true;
            this.btnadddocument.Size = new System.Drawing.Size(126, 36);
            this.btnadddocument.TabIndex = 76;
            this.btnadddocument.Text = "Add Document";
            this.btnadddocument.UseVisualStyleBackColor = true;
            this.btnadddocument.Click += new System.EventHandler(this.btnadddocument_Click);
            // 
            // tbdate
            // 
            this.tbdate.Depth = 0;
            this.tbdate.Hint = "";
            this.tbdate.Location = new System.Drawing.Point(150, 328);
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
            this.tbmobilenumber.Location = new System.Drawing.Point(15, 328);
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
            this.tblastname.Location = new System.Drawing.Point(148, 207);
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
            this.tbfirstname.Location = new System.Drawing.Point(14, 207);
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
            this.lbdate.Location = new System.Drawing.Point(147, 308);
            this.lbdate.Name = "lbdate";
            this.lbdate.Size = new System.Drawing.Size(30, 13);
            this.lbdate.TabIndex = 74;
            this.lbdate.Text = "Date";
            // 
            // lbmobilenumber
            // 
            this.lbmobilenumber.AutoSize = true;
            this.lbmobilenumber.Location = new System.Drawing.Point(12, 308);
            this.lbmobilenumber.Name = "lbmobilenumber";
            this.lbmobilenumber.Size = new System.Drawing.Size(78, 13);
            this.lbmobilenumber.TabIndex = 73;
            this.lbmobilenumber.Text = "Mobile Number";
            // 
            // lblastname
            // 
            this.lblastname.AutoSize = true;
            this.lblastname.Location = new System.Drawing.Point(145, 186);
            this.lblastname.Name = "lblastname";
            this.lblastname.Size = new System.Drawing.Size(58, 13);
            this.lblastname.TabIndex = 72;
            this.lblastname.Text = "Last Name";
            // 
            // lbfirstname
            // 
            this.lbfirstname.AutoSize = true;
            this.lbfirstname.Location = new System.Drawing.Point(13, 186);
            this.lbfirstname.Name = "lbfirstname";
            this.lbfirstname.Size = new System.Drawing.Size(57, 13);
            this.lbfirstname.TabIndex = 71;
            this.lbfirstname.Text = "First Name";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Location = new System.Drawing.Point(7, 473);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(269, 1);
            this.panel5.TabIndex = 70;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Location = new System.Drawing.Point(275, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 368);
            this.panel4.TabIndex = 69;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(6, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 368);
            this.panel3.TabIndex = 68;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbpatientinformation);
            this.panel2.Location = new System.Drawing.Point(6, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 40);
            this.panel2.TabIndex = 67;
            // 
            // lbdocument
            // 
            this.lbdocument.AutoSize = true;
            this.lbdocument.Location = new System.Drawing.Point(14, 365);
            this.lbdocument.Name = "lbdocument";
            this.lbdocument.Size = new System.Drawing.Size(56, 13);
            this.lbdocument.TabIndex = 77;
            this.lbdocument.Text = "Document";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.panel1.Controls.Add(this.lbpatientdocument);
            this.panel1.Controls.Add(this.pbclose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 56);
            this.panel1.TabIndex = 66;
            // 
            // tbdocuments
            // 
            this.tbdocuments.Depth = 0;
            this.tbdocuments.Hint = "";
            this.tbdocuments.Location = new System.Drawing.Point(14, 391);
            this.tbdocuments.MaxLength = 32767;
            this.tbdocuments.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbdocuments.Name = "tbdocuments";
            this.tbdocuments.PasswordChar = '\0';
            this.tbdocuments.SelectedText = "";
            this.tbdocuments.SelectionLength = 0;
            this.tbdocuments.SelectionStart = 0;
            this.tbdocuments.Size = new System.Drawing.Size(172, 23);
            this.tbdocuments.TabIndex = 81;
            this.tbdocuments.TabStop = false;
            this.tbdocuments.Text = "Browse";
            this.tbdocuments.UseSystemPasswordChar = false;
            this.tbdocuments.Click += new System.EventHandler(this.tbdocuments_Click);
            this.tbdocuments.Leave += new System.EventHandler(this.tbdocuments_Leave);
            // 
            // btnbrowse
            // 
            this.btnbrowse.BackgroundImage = global::Doctor.Properties.Resources.personal_info_button;
            this.btnbrowse.FlatAppearance.BorderSize = 0;
            this.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowse.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowse.ForeColor = System.Drawing.Color.White;
            this.btnbrowse.Location = new System.Drawing.Point(192, 391);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(75, 23);
            this.btnbrowse.TabIndex = 82;
            this.btnbrowse.Text = "Browse";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // tbugcid
            // 
            this.tbugcid.Depth = 0;
            this.tbugcid.Hint = "";
            this.tbugcid.Location = new System.Drawing.Point(15, 148);
            this.tbugcid.MaxLength = 32767;
            this.tbugcid.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbugcid.Name = "tbugcid";
            this.tbugcid.PasswordChar = '\0';
            this.tbugcid.SelectedText = "";
            this.tbugcid.SelectionLength = 0;
            this.tbugcid.SelectionStart = 0;
            this.tbugcid.Size = new System.Drawing.Size(119, 23);
            this.tbugcid.TabIndex = 83;
            this.tbugcid.TabStop = false;
            this.tbugcid.Text = "UGC ID";
            this.tbugcid.UseSystemPasswordChar = false;
            this.tbugcid.Click += new System.EventHandler(this.tbugcid_Click);
            this.tbugcid.Leave += new System.EventHandler(this.tbugcid_Leave);
            // 
            // lbugcid
            // 
            this.lbugcid.AutoSize = true;
            this.lbugcid.Location = new System.Drawing.Point(14, 127);
            this.lbugcid.Name = "lbugcid";
            this.lbugcid.Size = new System.Drawing.Size(44, 13);
            this.lbugcid.TabIndex = 84;
            this.lbugcid.Text = "UGC ID";
            // 
            // newDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.calenderdate);
            this.Controls.Add(this.tbugcid);
            this.Controls.Add(this.lbugcid);
            this.Controls.Add(this.btnbrowse);
            this.Controls.Add(this.tbdocuments);
            this.Controls.Add(this.lbage);
            this.Controls.Add(this.rbfemale);
            this.Controls.Add(this.rbmale);
            this.Controls.Add(this.tbage);
            this.Controls.Add(this.lbgender);
            this.Controls.Add(this.lberror);
            this.Controls.Add(this.btnadddocument);
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
            this.Controls.Add(this.lbdocument);
            this.Controls.Add(this.panel1);
            this.Name = "newDocument";
            this.Size = new System.Drawing.Size(283, 484);
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calenderdate;
        private System.Windows.Forms.Label lbpatientdocument;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.Label lbpatientinformation;
        private System.Windows.Forms.Label lbage;
        private MaterialSkin.Controls.MaterialRadioButton rbfemale;
        private MaterialSkin.Controls.MaterialRadioButton rbmale;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbage;
        private System.Windows.Forms.Label lbgender;
        private System.Windows.Forms.Label lberror;
        private MaterialSkin.Controls.MaterialRaisedButton btnadddocument;
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
        private System.Windows.Forms.Label lbdocument;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbdocuments;
        private System.Windows.Forms.Button btnbrowse;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbugcid;
        private System.Windows.Forms.Label lbugcid;
    }
}
