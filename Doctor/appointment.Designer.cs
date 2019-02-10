namespace Doctor
{
    partial class appointment
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(appointment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.calenderappointment = new System.Windows.Forms.MonthCalendar();
            this.lbpatientname = new System.Windows.Forms.Label();
            this.btnnewappointment = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbsortby = new System.Windows.Forms.Label();
            this.cbsortby = new System.Windows.Forms.ComboBox();
            this.lbdatetime = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbdate = new System.Windows.Forms.Label();
            this.pbcalendar = new System.Windows.Forms.PictureBox();
            this.pbnextdate = new System.Windows.Forms.PictureBox();
            this.pblastdate = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnclear = new System.Windows.Forms.Button();
            this.tbsearchmobile = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbmobile = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.tbsearchpatientname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbappointments = new System.Windows.Forms.Label();
            this.timerDateTimeNow = new System.Windows.Forms.Timer(this.components);
            this.dgvpatientappointment = new System.Windows.Forms.DataGridView();
            this.Columndate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columntime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columngender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnappointmentstatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.Columnpaymentcompleted = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Columndcancel = new System.Windows.Forms.DataGridViewImageColumn();
            this.Columnappointmentstatustext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnappointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblistview = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbcalenderview = new System.Windows.Forms.Label();
            this.panelchangeview = new System.Windows.Forms.Panel();
            this.confirmmessage1 = new Doctor.confirmmessage();
            this.newAppointment1 = new Doctor.newAppointment();
            this.calendarView1 = new Doctor.calendarView();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbnextdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblastdate)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpatientappointment)).BeginInit();
            this.panelchangeview.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Location = new System.Drawing.Point(0, 201);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1118, 1);
            this.panel5.TabIndex = 15;
            // 
            // calenderappointment
            // 
            this.calenderappointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calenderappointment.Location = new System.Drawing.Point(743, 157);
            this.calenderappointment.MaxSelectionCount = 1;
            this.calenderappointment.Name = "calenderappointment";
            this.calenderappointment.TabIndex = 21;
            this.calenderappointment.Visible = false;
            this.calenderappointment.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calenderappointment_DateSelected);
            this.calenderappointment.MouseLeave += new System.EventHandler(this.calenderappointment_MouseLeave);
            // 
            // lbpatientname
            // 
            this.lbpatientname.AutoSize = true;
            this.lbpatientname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpatientname.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbpatientname.Location = new System.Drawing.Point(4, 5);
            this.lbpatientname.Name = "lbpatientname";
            this.lbpatientname.Size = new System.Drawing.Size(83, 13);
            this.lbpatientname.TabIndex = 0;
            this.lbpatientname.Text = "Patient Name";
            // 
            // btnnewappointment
            // 
            this.btnnewappointment.AutoSize = true;
            this.btnnewappointment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnnewappointment.BackColor = System.Drawing.Color.Black;
            this.btnnewappointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnnewappointment.Depth = 0;
            this.btnnewappointment.Icon = null;
            this.btnnewappointment.Location = new System.Drawing.Point(875, 617);
            this.btnnewappointment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnnewappointment.Name = "btnnewappointment";
            this.btnnewappointment.Primary = true;
            this.btnnewappointment.Size = new System.Drawing.Size(240, 36);
            this.btnnewappointment.TabIndex = 20;
            this.btnnewappointment.Text = "Add New Patient Appointment";
            this.btnnewappointment.UseVisualStyleBackColor = false;
            this.btnnewappointment.Click += new System.EventHandler(this.btnnewappointment_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbsortby);
            this.panel2.Controls.Add(this.cbsortby);
            this.panel2.Controls.Add(this.lbdatetime);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Location = new System.Drawing.Point(-1, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1118, 40);
            this.panel2.TabIndex = 16;
            // 
            // lbsortby
            // 
            this.lbsortby.AutoSize = true;
            this.lbsortby.Location = new System.Drawing.Point(930, 15);
            this.lbsortby.Name = "lbsortby";
            this.lbsortby.Size = new System.Drawing.Size(41, 13);
            this.lbsortby.TabIndex = 29;
            this.lbsortby.Text = "Sort By";
            // 
            // cbsortby
            // 
            this.cbsortby.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.cbsortby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsortby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbsortby.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsortby.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.cbsortby.FormattingEnabled = true;
            this.cbsortby.Items.AddRange(new object[] {
            "All",
            "completed",
            "cancelled",
            "upcoming"});
            this.cbsortby.Location = new System.Drawing.Point(1000, 13);
            this.cbsortby.Name = "cbsortby";
            this.cbsortby.Size = new System.Drawing.Size(114, 23);
            this.cbsortby.TabIndex = 28;
            this.cbsortby.TabStop = false;
            this.cbsortby.SelectedIndexChanged += new System.EventHandler(this.cbsortby_SelectedIndexChanged);
            // 
            // lbdatetime
            // 
            this.lbdatetime.AutoSize = true;
            this.lbdatetime.ForeColor = System.Drawing.Color.DimGray;
            this.lbdatetime.Location = new System.Drawing.Point(17, 9);
            this.lbdatetime.Name = "lbdatetime";
            this.lbdatetime.Size = new System.Drawing.Size(53, 13);
            this.lbdatetime.TabIndex = 2;
            this.lbdatetime.Text = "DateTime";
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.lbdate);
            this.panel6.Controls.Add(this.pbcalendar);
            this.panel6.Controls.Add(this.pbnextdate);
            this.panel6.Controls.Add(this.pblastdate);
            this.panel6.Location = new System.Drawing.Point(744, 16);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(170, 18);
            this.panel6.TabIndex = 27;
            // 
            // lbdate
            // 
            this.lbdate.AutoSize = true;
            this.lbdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lbdate.Location = new System.Drawing.Point(92, 2);
            this.lbdate.Name = "lbdate";
            this.lbdate.Size = new System.Drawing.Size(30, 13);
            this.lbdate.TabIndex = 26;
            this.lbdate.Text = "Date";
            this.lbdate.TextChanged += new System.EventHandler(this.lbdate_TextChanged);
            // 
            // pbcalendar
            // 
            this.pbcalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbcalendar.Image = global::Doctor.Properties.Resources.calendar;
            this.pbcalendar.Location = new System.Drawing.Point(14, 3);
            this.pbcalendar.Name = "pbcalendar";
            this.pbcalendar.Size = new System.Drawing.Size(15, 13);
            this.pbcalendar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcalendar.TabIndex = 24;
            this.pbcalendar.TabStop = false;
            this.pbcalendar.Click += new System.EventHandler(this.pbcalendar_Click);
            // 
            // pbnextdate
            // 
            this.pbnextdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbnextdate.Image = global::Doctor.Properties.Resources.rightarrow;
            this.pbnextdate.Location = new System.Drawing.Point(69, 4);
            this.pbnextdate.Name = "pbnextdate";
            this.pbnextdate.Size = new System.Drawing.Size(14, 10);
            this.pbnextdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbnextdate.TabIndex = 26;
            this.pbnextdate.TabStop = false;
            this.pbnextdate.Click += new System.EventHandler(this.pbnextdate_Click);
            // 
            // pblastdate
            // 
            this.pblastdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pblastdate.Image = global::Doctor.Properties.Resources.leftarrow;
            this.pblastdate.Location = new System.Drawing.Point(39, 4);
            this.pblastdate.Name = "pblastdate";
            this.pblastdate.Size = new System.Drawing.Size(14, 10);
            this.pblastdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pblastdate.TabIndex = 25;
            this.pblastdate.TabStop = false;
            this.pblastdate.Click += new System.EventHandler(this.pblastdate_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.panel3.Controls.Add(this.btnclear);
            this.panel3.Controls.Add(this.tbsearchmobile);
            this.panel3.Controls.Add(this.lbmobile);
            this.panel3.Controls.Add(this.btnsearch);
            this.panel3.Controls.Add(this.tbsearchpatientname);
            this.panel3.Controls.Add(this.lbpatientname);
            this.panel3.Location = new System.Drawing.Point(1, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1118, 62);
            this.panel3.TabIndex = 17;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnclear.FlatAppearance.BorderSize = 0;
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnclear.Location = new System.Drawing.Point(440, 21);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(50, 25);
            this.btnclear.TabIndex = 8;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // tbsearchmobile
            // 
            this.tbsearchmobile.Depth = 0;
            this.tbsearchmobile.ForeColor = System.Drawing.Color.DimGray;
            this.tbsearchmobile.Hint = "";
            this.tbsearchmobile.Location = new System.Drawing.Point(172, 23);
            this.tbsearchmobile.MaxLength = 32767;
            this.tbsearchmobile.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbsearchmobile.Name = "tbsearchmobile";
            this.tbsearchmobile.PasswordChar = '\0';
            this.tbsearchmobile.SelectedText = "";
            this.tbsearchmobile.SelectionLength = 0;
            this.tbsearchmobile.SelectionStart = 0;
            this.tbsearchmobile.Size = new System.Drawing.Size(152, 23);
            this.tbsearchmobile.TabIndex = 5;
            this.tbsearchmobile.TabStop = false;
            this.tbsearchmobile.Text = "Number";
            this.tbsearchmobile.UseSystemPasswordChar = false;
            this.tbsearchmobile.Click += new System.EventHandler(this.tbsearchmobile_Click);
            this.tbsearchmobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbsearchmobile_KeyPress);
            this.tbsearchmobile.Leave += new System.EventHandler(this.tbsearchmobile_Leave);
            // 
            // lbmobile
            // 
            this.lbmobile.AutoSize = true;
            this.lbmobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmobile.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbmobile.Location = new System.Drawing.Point(169, 5);
            this.lbmobile.Name = "lbmobile";
            this.lbmobile.Size = new System.Drawing.Size(44, 13);
            this.lbmobile.TabIndex = 4;
            this.lbmobile.Text = "Mobile";
            // 
            // btnsearch
            // 
            this.btnsearch.BackgroundImage = global::Doctor.Properties.Resources.search;
            this.btnsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.FlatAppearance.BorderSize = 0;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnsearch.Location = new System.Drawing.Point(332, 22);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(102, 23);
            this.btnsearch.TabIndex = 3;
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // tbsearchpatientname
            // 
            this.tbsearchpatientname.Depth = 0;
            this.tbsearchpatientname.ForeColor = System.Drawing.Color.DimGray;
            this.tbsearchpatientname.Hint = "";
            this.tbsearchpatientname.Location = new System.Drawing.Point(7, 23);
            this.tbsearchpatientname.MaxLength = 32767;
            this.tbsearchpatientname.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbsearchpatientname.Name = "tbsearchpatientname";
            this.tbsearchpatientname.PasswordChar = '\0';
            this.tbsearchpatientname.SelectedText = "";
            this.tbsearchpatientname.SelectionLength = 0;
            this.tbsearchpatientname.SelectionStart = 0;
            this.tbsearchpatientname.Size = new System.Drawing.Size(152, 23);
            this.tbsearchpatientname.TabIndex = 5;
            this.tbsearchpatientname.TabStop = false;
            this.tbsearchpatientname.Text = "Name";
            this.tbsearchpatientname.UseSystemPasswordChar = false;
            this.tbsearchpatientname.Click += new System.EventHandler(this.tbsearchpatientname_Click);
            this.tbsearchpatientname.Leave += new System.EventHandler(this.tbsearchpatientname_Leave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Location = new System.Drawing.Point(-1, 610);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1118, 1);
            this.panel4.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(1, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 1);
            this.panel1.TabIndex = 14;
            // 
            // lbappointments
            // 
            this.lbappointments.AutoSize = true;
            this.lbappointments.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbappointments.Location = new System.Drawing.Point(2, 3);
            this.lbappointments.Name = "lbappointments";
            this.lbappointments.Size = new System.Drawing.Size(71, 13);
            this.lbappointments.TabIndex = 18;
            this.lbappointments.Text = "Appointments";
            // 
            // timerDateTimeNow
            // 
            this.timerDateTimeNow.Tick += new System.EventHandler(this.timerDateTimeNow_Tick);
            // 
            // dgvpatientappointment
            // 
            this.dgvpatientappointment.AllowUserToAddRows = false;
            this.dgvpatientappointment.AllowUserToDeleteRows = false;
            this.dgvpatientappointment.AllowUserToResizeColumns = false;
            this.dgvpatientappointment.AllowUserToResizeRows = false;
            this.dgvpatientappointment.BackgroundColor = System.Drawing.Color.White;
            this.dgvpatientappointment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvpatientappointment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvpatientappointment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvpatientappointment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvpatientappointment.ColumnHeadersHeight = 35;
            this.dgvpatientappointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvpatientappointment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columndate,
            this.Columntime,
            this.dataGridViewTextBoxColumn1,
            this.Columngender,
            this.Columnage,
            this.dataGridViewTextBoxColumn2,
            this.Columnappointmentstatus,
            this.Columnpaymentcompleted,
            this.Columndcancel,
            this.Columnappointmentstatustext,
            this.ColumnappointmentID});
            this.dgvpatientappointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvpatientappointment.GridColor = System.Drawing.Color.LightGray;
            this.dgvpatientappointment.Location = new System.Drawing.Point(0, 166);
            this.dgvpatientappointment.Name = "dgvpatientappointment";
            this.dgvpatientappointment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvpatientappointment.RowHeadersVisible = false;
            this.dgvpatientappointment.RowHeadersWidth = 60;
            this.dgvpatientappointment.RowTemplate.Height = 30;
            this.dgvpatientappointment.Size = new System.Drawing.Size(1118, 434);
            this.dgvpatientappointment.TabIndex = 24;
            this.dgvpatientappointment.TabStop = false;
            this.dgvpatientappointment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpatientappointment_CellClick);
            this.dgvpatientappointment.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpatientappointment_CellContentDoubleClick);
            this.dgvpatientappointment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpatientappointment_CellDoubleClick);
            this.dgvpatientappointment.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvpatientappointment_Paint);
            // 
            // Columndate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.Columndate.DefaultCellStyle = dataGridViewCellStyle2;
            this.Columndate.HeaderText = "Date";
            this.Columndate.Name = "Columndate";
            this.Columndate.ReadOnly = true;
            this.Columndate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Columntime
            // 
            this.Columntime.HeaderText = "Time";
            this.Columntime.Name = "Columntime";
            this.Columntime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columntime.Width = 145;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 213;
            // 
            // Columngender
            // 
            this.Columngender.HeaderText = "Gender";
            this.Columngender.Name = "Columngender";
            this.Columngender.ReadOnly = true;
            this.Columngender.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columngender.Width = 110;
            // 
            // Columnage
            // 
            this.Columnage.HeaderText = "Age";
            this.Columnage.Name = "Columnage";
            this.Columnage.ReadOnly = true;
            this.Columnage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnage.Width = 110;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Mobile";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 110;
            // 
            // Columnappointmentstatus
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.NullValue = null;
            this.Columnappointmentstatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.Columnappointmentstatus.HeaderText = "Appointment Status";
            this.Columnappointmentstatus.Name = "Columnappointmentstatus";
            this.Columnappointmentstatus.ReadOnly = true;
            this.Columnappointmentstatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnappointmentstatus.Width = 160;
            // 
            // Columnpaymentcompleted
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.NullValue = "Completed";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.Columnpaymentcompleted.DefaultCellStyle = dataGridViewCellStyle5;
            this.Columnpaymentcompleted.HeaderText = "Completed";
            this.Columnpaymentcompleted.Name = "Columnpaymentcompleted";
            this.Columnpaymentcompleted.ReadOnly = true;
            this.Columnpaymentcompleted.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Columndcancel
            // 
            this.Columndcancel.HeaderText = "Cancel";
            this.Columndcancel.Image = global::Doctor.Properties.Resources.cancel;
            this.Columndcancel.Name = "Columndcancel";
            this.Columndcancel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columndcancel.Width = 70;
            // 
            // Columnappointmentstatustext
            // 
            this.Columnappointmentstatustext.HeaderText = "appointmentstatus";
            this.Columnappointmentstatustext.Name = "Columnappointmentstatustext";
            this.Columnappointmentstatustext.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnappointmentstatustext.Visible = false;
            this.Columnappointmentstatustext.Width = 5;
            // 
            // ColumnappointmentID
            // 
            this.ColumnappointmentID.HeaderText = "appointmentID";
            this.ColumnappointmentID.Name = "ColumnappointmentID";
            this.ColumnappointmentID.Visible = false;
            this.ColumnappointmentID.Width = 5;
            // 
            // lblistview
            // 
            this.lblistview.AutoSize = true;
            this.lblistview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblistview.Location = new System.Drawing.Point(101, 4);
            this.lblistview.Name = "lblistview";
            this.lblistview.Size = new System.Drawing.Size(49, 13);
            this.lblistview.TabIndex = 9;
            this.lblistview.Text = "List View";
            this.lblistview.Click += new System.EventHandler(this.lblistview_Click);
            this.lblistview.MouseLeave += new System.EventHandler(this.lblistview_MouseLeave);
            this.lblistview.MouseHover += new System.EventHandler(this.lblistview_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "|";
            // 
            // lbcalenderview
            // 
            this.lbcalenderview.AutoSize = true;
            this.lbcalenderview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbcalenderview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lbcalenderview.Location = new System.Drawing.Point(10, 4);
            this.lbcalenderview.Name = "lbcalenderview";
            this.lbcalenderview.Size = new System.Drawing.Size(75, 13);
            this.lbcalenderview.TabIndex = 8;
            this.lbcalenderview.Text = "Calendar View";
            this.lbcalenderview.Click += new System.EventHandler(this.lbcalenderview_Click);
            this.lbcalenderview.MouseLeave += new System.EventHandler(this.lbcalenderview_MouseLeave);
            this.lbcalenderview.MouseHover += new System.EventHandler(this.lbcalenderview_MouseHover);
            // 
            // panelchangeview
            // 
            this.panelchangeview.Controls.Add(this.lbcalenderview);
            this.panelchangeview.Controls.Add(this.label3);
            this.panelchangeview.Controls.Add(this.lblistview);
            this.panelchangeview.Location = new System.Drawing.Point(950, 20);
            this.panelchangeview.Name = "panelchangeview";
            this.panelchangeview.Size = new System.Drawing.Size(166, 21);
            this.panelchangeview.TabIndex = 12;
            // 
            // confirmmessage1
            // 
            this.confirmmessage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.confirmmessage1.Location = new System.Drawing.Point(0, 260);
            this.confirmmessage1.Name = "confirmmessage1";
            this.confirmmessage1.Size = new System.Drawing.Size(1118, 150);
            this.confirmmessage1.TabIndex = 26;
            this.confirmmessage1.Visible = false;
            this.confirmmessage1.Leave += new System.EventHandler(this.confirmmessage1_Leave);
            // 
            // newAppointment1
            // 
            this.newAppointment1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.newAppointment1.Location = new System.Drawing.Point(246, 48);
            this.newAppointment1.Name = "newAppointment1";
            this.newAppointment1.Size = new System.Drawing.Size(280, 451);
            this.newAppointment1.TabIndex = 25;
            this.newAppointment1.Visible = false;
            this.newAppointment1.Leave += new System.EventHandler(this.newAppointment1_Leave);
            // 
            // calendarView1
            // 
            this.calendarView1.Age = "";
            this.calendarView1.AppointmentID = "";
            this.calendarView1.BackColor = System.Drawing.Color.White;
            this.calendarView1.Date = "18-Jan-2019";
            this.calendarView1.FirstName = "";
            this.calendarView1.Gender = "";
            this.calendarView1.LastName = "";
            this.calendarView1.Location = new System.Drawing.Point(0, 166);
            this.calendarView1.Mobile = "";
            this.calendarView1.Name = "calendarView1";
            this.calendarView1.Size = new System.Drawing.Size(1118, 437);
            this.calendarView1.TabIndex = 27;
            this.calendarView1.TimeSlot = "";
            this.calendarView1.Type = "";
            this.calendarView1.VaccinationType = "";
            // 
            // appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.confirmmessage1);
            this.Controls.Add(this.newAppointment1);
            this.Controls.Add(this.calendarView1);
            this.Controls.Add(this.panelchangeview);
            this.Controls.Add(this.calenderappointment);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnnewappointment);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbappointments);
            this.Controls.Add(this.dgvpatientappointment);
            this.Name = "appointment";
            this.Size = new System.Drawing.Size(1118, 663);
            this.Load += new System.EventHandler(this.appointment_Load);
            this.VisibleChanged += new System.EventHandler(this.appointment_VisibleChanged);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbnextdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblastdate)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpatientappointment)).EndInit();
            this.panelchangeview.ResumeLayout(false);
            this.panelchangeview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MonthCalendar calenderappointment;
        private System.Windows.Forms.Label lbpatientname;
        private MaterialSkin.Controls.MaterialRaisedButton btnnewappointment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbdatetime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnclear;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbsearchmobile;
        private System.Windows.Forms.Label lbmobile;
        private System.Windows.Forms.Button btnsearch;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbsearchpatientname;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbappointments;
        private System.Windows.Forms.PictureBox pbcalendar;
        private System.Windows.Forms.PictureBox pbnextdate;
        private System.Windows.Forms.PictureBox pblastdate;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbdate;
        private System.Windows.Forms.Timer timerDateTimeNow;
        private System.Windows.Forms.DataGridView dgvpatientappointment;
        private newAppointment newAppointment1;
        private confirmmessage confirmmessage1;
        private System.Windows.Forms.Label lbsortby;
        private System.Windows.Forms.ComboBox cbsortby;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columndate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columntime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columngender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewImageColumn Columnappointmentstatus;
        private System.Windows.Forms.DataGridViewButtonColumn Columnpaymentcompleted;
        private System.Windows.Forms.DataGridViewImageColumn Columndcancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnappointmentstatustext;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnappointmentID;
        private System.Windows.Forms.Label lblistview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbcalenderview;
        private System.Windows.Forms.Panel panelchangeview;
        private calendarView calendarView1;
    }
}
