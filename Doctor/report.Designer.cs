namespace Doctor
{
    partial class report
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnmedication = new System.Windows.Forms.Panel();
            this.pbmedication = new System.Windows.Forms.PictureBox();
            this.lbmedication = new System.Windows.Forms.Label();
            this.btnpatients = new System.Windows.Forms.Panel();
            this.pbpatients = new System.Windows.Forms.PictureBox();
            this.lbpatients = new System.Windows.Forms.Label();
            this.btnpayment = new System.Windows.Forms.Panel();
            this.pbpayment = new System.Windows.Forms.PictureBox();
            this.lbpayment = new System.Windows.Forms.Label();
            this.btnappointment = new System.Windows.Forms.Panel();
            this.pbappoiment = new System.Windows.Forms.PictureBox();
            this.lbappointment = new System.Windows.Forms.Label();
            this.btnvaccination = new System.Windows.Forms.Panel();
            this.pbvaccinations = new System.Windows.Forms.PictureBox();
            this.lbvaccination = new System.Windows.Forms.Label();
            this.lbreports = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.calendar1 = new Calendar.NET.Calendar();
            this.lbselecteddate = new System.Windows.Forms.Label();
            this.panel_mainlist = new System.Windows.Forms.Panel();
            this.panel_notices = new System.Windows.Forms.Panel();
            this.lbnonotices = new System.Windows.Forms.Label();
            this.dgvnotices = new System.Windows.Forms.DataGridView();
            this.Columnicon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Columnnotice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnnoticedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columntype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnnotices = new System.Windows.Forms.Button();
            this.timer_notice = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3.SuspendLayout();
            this.btnmedication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbmedication)).BeginInit();
            this.btnpatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbpatients)).BeginInit();
            this.btnpayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbpayment)).BeginInit();
            this.btnappointment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbappoiment)).BeginInit();
            this.btnvaccination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbvaccinations)).BeginInit();
            this.panel_mainlist.SuspendLayout();
            this.panel_notices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvnotices)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.btnmedication);
            this.panel3.Controls.Add(this.btnpatients);
            this.panel3.Controls.Add(this.btnpayment);
            this.panel3.Controls.Add(this.btnappointment);
            this.panel3.Controls.Add(this.btnvaccination);
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1118, 112);
            this.panel3.TabIndex = 19;
            // 
            // btnmedication
            // 
            this.btnmedication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.btnmedication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnmedication.Controls.Add(this.pbmedication);
            this.btnmedication.Controls.Add(this.lbmedication);
            this.btnmedication.Location = new System.Drawing.Point(270, 15);
            this.btnmedication.Name = "btnmedication";
            this.btnmedication.Size = new System.Drawing.Size(160, 80);
            this.btnmedication.TabIndex = 25;
            this.btnmedication.Click += new System.EventHandler(this.btnmedication_Click);
            this.btnmedication.Leave += new System.EventHandler(this.btnmedication_Leave);
            this.btnmedication.MouseLeave += new System.EventHandler(this.btnmedication_MouseLeave);
            this.btnmedication.MouseHover += new System.EventHandler(this.btnmedication_MouseHover);
            // 
            // pbmedication
            // 
            this.pbmedication.Image = global::Doctor.Properties.Resources.medication;
            this.pbmedication.Location = new System.Drawing.Point(57, 13);
            this.pbmedication.Name = "pbmedication";
            this.pbmedication.Size = new System.Drawing.Size(40, 40);
            this.pbmedication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbmedication.TabIndex = 2;
            this.pbmedication.TabStop = false;
            this.pbmedication.Click += new System.EventHandler(this.pbmedication_Click);
            this.pbmedication.MouseLeave += new System.EventHandler(this.pbmedication_MouseLeave);
            this.pbmedication.MouseHover += new System.EventHandler(this.pbmedication_MouseHover);
            // 
            // lbmedication
            // 
            this.lbmedication.AutoSize = true;
            this.lbmedication.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmedication.ForeColor = System.Drawing.Color.White;
            this.lbmedication.Location = new System.Drawing.Point(36, 56);
            this.lbmedication.Name = "lbmedication";
            this.lbmedication.Size = new System.Drawing.Size(90, 18);
            this.lbmedication.TabIndex = 0;
            this.lbmedication.Text = "Medication";
            this.lbmedication.Click += new System.EventHandler(this.lbmedication_Click);
            this.lbmedication.MouseLeave += new System.EventHandler(this.lbmedication_MouseLeave);
            this.lbmedication.MouseHover += new System.EventHandler(this.lbmedication_MouseHover);
            // 
            // btnpatients
            // 
            this.btnpatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.btnpatients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnpatients.Controls.Add(this.pbpatients);
            this.btnpatients.Controls.Add(this.lbpatients);
            this.btnpatients.Location = new System.Drawing.Point(60, 15);
            this.btnpatients.Name = "btnpatients";
            this.btnpatients.Size = new System.Drawing.Size(160, 80);
            this.btnpatients.TabIndex = 22;
            this.btnpatients.Click += new System.EventHandler(this.btnpatients_Click);
            this.btnpatients.Leave += new System.EventHandler(this.btnpatients_Leave);
            this.btnpatients.MouseLeave += new System.EventHandler(this.btnpatients_MouseLeave);
            this.btnpatients.MouseHover += new System.EventHandler(this.btnpatients_MouseHover);
            // 
            // pbpatients
            // 
            this.pbpatients.Image = global::Doctor.Properties.Resources.patient;
            this.pbpatients.Location = new System.Drawing.Point(57, 13);
            this.pbpatients.Name = "pbpatients";
            this.pbpatients.Size = new System.Drawing.Size(40, 40);
            this.pbpatients.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbpatients.TabIndex = 1;
            this.pbpatients.TabStop = false;
            this.pbpatients.Click += new System.EventHandler(this.pbpatients_Click);
            this.pbpatients.MouseLeave += new System.EventHandler(this.pbpatients_MouseLeave);
            this.pbpatients.MouseHover += new System.EventHandler(this.pbpatients_MouseHover);
            // 
            // lbpatients
            // 
            this.lbpatients.AutoSize = true;
            this.lbpatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpatients.ForeColor = System.Drawing.Color.White;
            this.lbpatients.Location = new System.Drawing.Point(45, 56);
            this.lbpatients.Name = "lbpatients";
            this.lbpatients.Size = new System.Drawing.Size(69, 18);
            this.lbpatients.TabIndex = 0;
            this.lbpatients.Text = "Patients";
            this.lbpatients.Click += new System.EventHandler(this.lbpatients_Click);
            this.lbpatients.MouseLeave += new System.EventHandler(this.lbpatients_MouseLeave);
            this.lbpatients.MouseHover += new System.EventHandler(this.lbpatients_MouseHover);
            // 
            // btnpayment
            // 
            this.btnpayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.btnpayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnpayment.Controls.Add(this.pbpayment);
            this.btnpayment.Controls.Add(this.lbpayment);
            this.btnpayment.Location = new System.Drawing.Point(900, 15);
            this.btnpayment.Name = "btnpayment";
            this.btnpayment.Size = new System.Drawing.Size(160, 80);
            this.btnpayment.TabIndex = 24;
            this.btnpayment.Click += new System.EventHandler(this.btnpayment_Click);
            this.btnpayment.Leave += new System.EventHandler(this.btnpayment_Leave);
            this.btnpayment.MouseLeave += new System.EventHandler(this.btnpayment_MouseLeave);
            this.btnpayment.MouseHover += new System.EventHandler(this.btnpayment_MouseHover);
            // 
            // pbpayment
            // 
            this.pbpayment.Image = global::Doctor.Properties.Resources.payment;
            this.pbpayment.Location = new System.Drawing.Point(55, 13);
            this.pbpayment.Name = "pbpayment";
            this.pbpayment.Size = new System.Drawing.Size(40, 40);
            this.pbpayment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbpayment.TabIndex = 2;
            this.pbpayment.TabStop = false;
            this.pbpayment.Click += new System.EventHandler(this.pbpayment_Click);
            this.pbpayment.MouseLeave += new System.EventHandler(this.pbpayment_MouseLeave);
            this.pbpayment.MouseHover += new System.EventHandler(this.pbpayment_MouseHover);
            // 
            // lbpayment
            // 
            this.lbpayment.AutoSize = true;
            this.lbpayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpayment.ForeColor = System.Drawing.Color.White;
            this.lbpayment.Location = new System.Drawing.Point(42, 55);
            this.lbpayment.Name = "lbpayment";
            this.lbpayment.Size = new System.Drawing.Size(73, 18);
            this.lbpayment.TabIndex = 0;
            this.lbpayment.Text = "Payment";
            this.lbpayment.Click += new System.EventHandler(this.lbpayment_Click);
            this.lbpayment.MouseLeave += new System.EventHandler(this.lbpayment_MouseLeave);
            this.lbpayment.MouseHover += new System.EventHandler(this.lbpayment_MouseHover);
            // 
            // btnappointment
            // 
            this.btnappointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.btnappointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnappointment.Controls.Add(this.pbappoiment);
            this.btnappointment.Controls.Add(this.lbappointment);
            this.btnappointment.Location = new System.Drawing.Point(480, 15);
            this.btnappointment.Name = "btnappointment";
            this.btnappointment.Size = new System.Drawing.Size(160, 80);
            this.btnappointment.TabIndex = 21;
            this.btnappointment.Click += new System.EventHandler(this.btnappointment_Click);
            this.btnappointment.Leave += new System.EventHandler(this.btnappointment_Leave);
            this.btnappointment.MouseLeave += new System.EventHandler(this.btnappointment_MouseLeave);
            this.btnappointment.MouseHover += new System.EventHandler(this.btnappointment_MouseHover);
            // 
            // pbappoiment
            // 
            this.pbappoiment.Image = global::Doctor.Properties.Resources.appointment;
            this.pbappoiment.Location = new System.Drawing.Point(59, 13);
            this.pbappoiment.Name = "pbappoiment";
            this.pbappoiment.Size = new System.Drawing.Size(40, 40);
            this.pbappoiment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbappoiment.TabIndex = 2;
            this.pbappoiment.TabStop = false;
            this.pbappoiment.Click += new System.EventHandler(this.pbappoiment_Click);
            this.pbappoiment.MouseLeave += new System.EventHandler(this.pbappoiment_MouseLeave);
            this.pbappoiment.MouseHover += new System.EventHandler(this.pbappoiment_MouseHover);
            // 
            // lbappointment
            // 
            this.lbappointment.AutoSize = true;
            this.lbappointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbappointment.ForeColor = System.Drawing.Color.White;
            this.lbappointment.Location = new System.Drawing.Point(26, 56);
            this.lbappointment.Name = "lbappointment";
            this.lbappointment.Size = new System.Drawing.Size(110, 18);
            this.lbappointment.TabIndex = 0;
            this.lbappointment.Text = "Appointments";
            this.lbappointment.Click += new System.EventHandler(this.lbappointment_Click);
            this.lbappointment.MouseLeave += new System.EventHandler(this.lbappointment_MouseLeave);
            this.lbappointment.MouseHover += new System.EventHandler(this.lbappointment_MouseHover);
            // 
            // btnvaccination
            // 
            this.btnvaccination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.btnvaccination.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnvaccination.Controls.Add(this.pbvaccinations);
            this.btnvaccination.Controls.Add(this.lbvaccination);
            this.btnvaccination.Location = new System.Drawing.Point(690, 15);
            this.btnvaccination.Name = "btnvaccination";
            this.btnvaccination.Size = new System.Drawing.Size(160, 80);
            this.btnvaccination.TabIndex = 23;
            this.btnvaccination.Click += new System.EventHandler(this.btnvaccination_Click);
            this.btnvaccination.Leave += new System.EventHandler(this.btnvaccination_Leave);
            this.btnvaccination.MouseLeave += new System.EventHandler(this.btnvaccination_MouseLeave);
            this.btnvaccination.MouseHover += new System.EventHandler(this.btnvaccination_MouseHover);
            // 
            // pbvaccinations
            // 
            this.pbvaccinations.Image = global::Doctor.Properties.Resources.vaccination;
            this.pbvaccinations.Location = new System.Drawing.Point(57, 15);
            this.pbvaccinations.Name = "pbvaccinations";
            this.pbvaccinations.Size = new System.Drawing.Size(40, 40);
            this.pbvaccinations.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbvaccinations.TabIndex = 2;
            this.pbvaccinations.TabStop = false;
            this.pbvaccinations.Click += new System.EventHandler(this.pbvaccinations_Click);
            this.pbvaccinations.MouseLeave += new System.EventHandler(this.pbvaccinations_MouseLeave);
            this.pbvaccinations.MouseHover += new System.EventHandler(this.pbvaccinations_MouseHover);
            // 
            // lbvaccination
            // 
            this.lbvaccination.AutoSize = true;
            this.lbvaccination.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbvaccination.ForeColor = System.Drawing.Color.White;
            this.lbvaccination.Location = new System.Drawing.Point(28, 56);
            this.lbvaccination.Name = "lbvaccination";
            this.lbvaccination.Size = new System.Drawing.Size(104, 18);
            this.lbvaccination.TabIndex = 0;
            this.lbvaccination.Text = "Vaccinations";
            this.lbvaccination.Click += new System.EventHandler(this.lbvaccination_Click);
            this.lbvaccination.MouseLeave += new System.EventHandler(this.lbvaccination_MouseLeave);
            this.lbvaccination.MouseHover += new System.EventHandler(this.lbvaccination_MouseHover);
            // 
            // lbreports
            // 
            this.lbreports.AutoSize = true;
            this.lbreports.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbreports.Location = new System.Drawing.Point(1, 1);
            this.lbreports.Name = "lbreports";
            this.lbreports.Size = new System.Drawing.Size(59, 13);
            this.lbreports.TabIndex = 20;
            this.lbreports.Text = "Dashboard";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.panel1.Location = new System.Drawing.Point(0, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 5);
            this.panel1.TabIndex = 21;
            // 
            // calendar1
            // 
            this.calendar1.AllowEditingEvents = true;
            this.calendar1.CalendarDate = new System.DateTime(2019, 1, 4, 15, 58, 54, 276);
            this.calendar1.CalendarView = Calendar.NET.CalendarViews.Month;
            this.calendar1.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendar1.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar1.DimDisabledEvents = true;
            this.calendar1.HighlightCurrentDay = true;
            this.calendar1.LoadPresetHolidays = true;
            this.calendar1.Location = new System.Drawing.Point(0, 189);
            this.calendar1.Name = "calendar1";
            this.calendar1.ShowArrowControls = true;
            this.calendar1.ShowDashedBorderOnDisabledEvents = true;
            this.calendar1.ShowDateInHeader = true;
            this.calendar1.ShowDisabledEvents = false;
            this.calendar1.ShowEventTooltips = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(640, 440);
            this.calendar1.TabIndex = 22;
            this.calendar1.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // lbselecteddate
            // 
            this.lbselecteddate.AutoSize = true;
            this.lbselecteddate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lbselecteddate.Location = new System.Drawing.Point(448, 203);
            this.lbselecteddate.Name = "lbselecteddate";
            this.lbselecteddate.Size = new System.Drawing.Size(75, 13);
            this.lbselecteddate.TabIndex = 23;
            this.lbselecteddate.Text = "Date Selected";
            this.lbselecteddate.TextChanged += new System.EventHandler(this.lbselecteddate_TextChanged);
            // 
            // panel_mainlist
            // 
            this.panel_mainlist.Controls.Add(this.panel_notices);
            this.panel_mainlist.Controls.Add(this.btnnotices);
            this.panel_mainlist.Location = new System.Drawing.Point(637, 189);
            this.panel_mainlist.Name = "panel_mainlist";
            this.panel_mainlist.Size = new System.Drawing.Size(469, 461);
            this.panel_mainlist.TabIndex = 24;
            // 
            // panel_notices
            // 
            this.panel_notices.Controls.Add(this.lbnonotices);
            this.panel_notices.Controls.Add(this.dgvnotices);
            this.panel_notices.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_notices.Location = new System.Drawing.Point(0, 36);
            this.panel_notices.Name = "panel_notices";
            this.panel_notices.Size = new System.Drawing.Size(469, 422);
            this.panel_notices.TabIndex = 1;
            // 
            // lbnonotices
            // 
            this.lbnonotices.AutoSize = true;
            this.lbnonotices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lbnonotices.Location = new System.Drawing.Point(157, 4);
            this.lbnonotices.Name = "lbnonotices";
            this.lbnonotices.Size = new System.Drawing.Size(161, 13);
            this.lbnonotices.TabIndex = 37;
            this.lbnonotices.Text = "No Notice Available for this Date";
            this.lbnonotices.Visible = false;
            // 
            // dgvnotices
            // 
            this.dgvnotices.AllowUserToAddRows = false;
            this.dgvnotices.AllowUserToDeleteRows = false;
            this.dgvnotices.AllowUserToResizeColumns = false;
            this.dgvnotices.AllowUserToResizeRows = false;
            this.dgvnotices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvnotices.BackgroundColor = System.Drawing.Color.White;
            this.dgvnotices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvnotices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvnotices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvnotices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvnotices.ColumnHeadersHeight = 35;
            this.dgvnotices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvnotices.ColumnHeadersVisible = false;
            this.dgvnotices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnicon,
            this.Columnnotice,
            this.Columnnoticedate,
            this.Columntype,
            this.Columnid});
            this.dgvnotices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvnotices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvnotices.Location = new System.Drawing.Point(3, 3);
            this.dgvnotices.Name = "dgvnotices";
            this.dgvnotices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvnotices.RowHeadersVisible = false;
            this.dgvnotices.RowHeadersWidth = 100;
            this.dgvnotices.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvnotices.RowTemplate.Height = 100;
            this.dgvnotices.Size = new System.Drawing.Size(463, 416);
            this.dgvnotices.TabIndex = 36;
            this.dgvnotices.TabStop = false;
            this.dgvnotices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvnotices_CellDoubleClick);
            this.dgvnotices.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvnotices_Paint);
            // 
            // Columnicon
            // 
            this.Columnicon.HeaderText = "Icon";
            this.Columnicon.Name = "Columnicon";
            this.Columnicon.ReadOnly = true;
            this.Columnicon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnicon.Width = 50;
            // 
            // Columnnotice
            // 
            this.Columnnotice.HeaderText = "Notice";
            this.Columnnotice.Name = "Columnnotice";
            this.Columnnotice.ReadOnly = true;
            this.Columnnotice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnnotice.Width = 340;
            // 
            // Columnnoticedate
            // 
            this.Columnnoticedate.HeaderText = "Date";
            this.Columnnoticedate.Name = "Columnnoticedate";
            this.Columnnoticedate.ReadOnly = true;
            this.Columnnoticedate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnnoticedate.Width = 70;
            // 
            // Columntype
            // 
            this.Columntype.HeaderText = "type";
            this.Columntype.Name = "Columntype";
            this.Columntype.Visible = false;
            this.Columntype.Width = 5;
            // 
            // Columnid
            // 
            this.Columnid.HeaderText = "ID";
            this.Columnid.Name = "Columnid";
            this.Columnid.Visible = false;
            this.Columnid.Width = 5;
            // 
            // btnnotices
            // 
            this.btnnotices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(213)))), ((int)(((byte)(253)))));
            this.btnnotices.BackgroundImage = global::Doctor.Properties.Resources.personal_info_button;
            this.btnnotices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnnotices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnnotices.FlatAppearance.BorderSize = 0;
            this.btnnotices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnotices.ForeColor = System.Drawing.Color.White;
            this.btnnotices.Image = global::Doctor.Properties.Resources.menubar;
            this.btnnotices.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnnotices.Location = new System.Drawing.Point(0, 0);
            this.btnnotices.Name = "btnnotices";
            this.btnnotices.Size = new System.Drawing.Size(469, 36);
            this.btnnotices.TabIndex = 0;
            this.btnnotices.Text = "Noticeboard";
            this.btnnotices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnotices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnnotices.UseVisualStyleBackColor = false;
            this.btnnotices.Click += new System.EventHandler(this.btnnotices_Click);
            // 
            // timer_notice
            // 
            this.timer_notice.Interval = 20;
            this.timer_notice.Tick += new System.EventHandler(this.timer_notice_Tick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Cancel";
            this.dataGridViewImageColumn1.Image = global::Doctor.Properties.Resources.cancel;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 70;
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel_mainlist);
            this.Controls.Add(this.lbselecteddate);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbreports);
            this.Name = "report";
            this.Size = new System.Drawing.Size(1118, 663);
            this.Load += new System.EventHandler(this.report_Load);
            this.VisibleChanged += new System.EventHandler(this.report_VisibleChanged);
            this.panel3.ResumeLayout(false);
            this.btnmedication.ResumeLayout(false);
            this.btnmedication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbmedication)).EndInit();
            this.btnpatients.ResumeLayout(false);
            this.btnpatients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbpatients)).EndInit();
            this.btnpayment.ResumeLayout(false);
            this.btnpayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbpayment)).EndInit();
            this.btnappointment.ResumeLayout(false);
            this.btnappointment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbappoiment)).EndInit();
            this.btnvaccination.ResumeLayout(false);
            this.btnvaccination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbvaccinations)).EndInit();
            this.panel_mainlist.ResumeLayout(false);
            this.panel_notices.ResumeLayout(false);
            this.panel_notices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvnotices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbreports;
        private System.Windows.Forms.Panel btnmedication;
        private System.Windows.Forms.PictureBox pbmedication;
        private System.Windows.Forms.Label lbmedication;
        private System.Windows.Forms.Panel btnpatients;
        private System.Windows.Forms.PictureBox pbpatients;
        private System.Windows.Forms.Label lbpatients;
        private System.Windows.Forms.Panel btnpayment;
        private System.Windows.Forms.PictureBox pbpayment;
        private System.Windows.Forms.Label lbpayment;
        private System.Windows.Forms.Panel btnappointment;
        private System.Windows.Forms.PictureBox pbappoiment;
        private System.Windows.Forms.Label lbappointment;
        private System.Windows.Forms.Panel btnvaccination;
        private System.Windows.Forms.PictureBox pbvaccinations;
        private System.Windows.Forms.Label lbvaccination;
        private System.Windows.Forms.Panel panel1;
        private Calendar.NET.Calendar calendar1;
        private System.Windows.Forms.Label lbselecteddate;
        private System.Windows.Forms.Panel panel_mainlist;
        private System.Windows.Forms.Panel panel_notices;
        private System.Windows.Forms.DataGridView dgvnotices;
        private System.Windows.Forms.Button btnnotices;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Timer timer_notice;
        private System.Windows.Forms.DataGridViewImageColumn Columnicon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnnotice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnnoticedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columntype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
        private System.Windows.Forms.Label lbnonotices;
    }
}
