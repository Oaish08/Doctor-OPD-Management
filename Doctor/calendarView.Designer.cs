namespace Doctor
{
    partial class calendarView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbselecteddate = new System.Windows.Forms.Label();
            this.calendar1 = new Calendar.NET.Calendar();
            this.panel_mainlist = new System.Windows.Forms.Panel();
            this.panel_appointments = new System.Windows.Forms.Panel();
            this.dgvappointments = new System.Windows.Forms.DataGridView();
            this.Columnicon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnnotice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnnoticedate = new System.Windows.Forms.DataGridViewImageColumn();
            this.Columntype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnappointmentlist = new System.Windows.Forms.Button();
            this.timer_appointment = new System.Windows.Forms.Timer(this.components);
            this.panel_mainlist.SuspendLayout();
            this.panel_appointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvappointments)).BeginInit();
            this.SuspendLayout();
            // 
            // lbselecteddate
            // 
            this.lbselecteddate.AutoSize = true;
            this.lbselecteddate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lbselecteddate.Location = new System.Drawing.Point(447, 14);
            this.lbselecteddate.Name = "lbselecteddate";
            this.lbselecteddate.Size = new System.Drawing.Size(75, 13);
            this.lbselecteddate.TabIndex = 25;
            this.lbselecteddate.Text = "Date Selected";
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
            this.calendar1.Location = new System.Drawing.Point(2, 0);
            this.calendar1.Name = "calendar1";
            this.calendar1.ShowArrowControls = true;
            this.calendar1.ShowDashedBorderOnDisabledEvents = true;
            this.calendar1.ShowDateInHeader = true;
            this.calendar1.ShowDisabledEvents = false;
            this.calendar1.ShowEventTooltips = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(629, 434);
            this.calendar1.TabIndex = 24;
            this.calendar1.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // panel_mainlist
            // 
            this.panel_mainlist.Controls.Add(this.panel_appointments);
            this.panel_mainlist.Controls.Add(this.btnappointmentlist);
            this.panel_mainlist.Location = new System.Drawing.Point(636, 0);
            this.panel_mainlist.Name = "panel_mainlist";
            this.panel_mainlist.Size = new System.Drawing.Size(481, 431);
            this.panel_mainlist.TabIndex = 26;
            // 
            // panel_appointments
            // 
            this.panel_appointments.Controls.Add(this.dgvappointments);
            this.panel_appointments.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_appointments.Location = new System.Drawing.Point(0, 36);
            this.panel_appointments.Name = "panel_appointments";
            this.panel_appointments.Size = new System.Drawing.Size(481, 395);
            this.panel_appointments.TabIndex = 1;
            // 
            // dgvappointments
            // 
            this.dgvappointments.AllowUserToAddRows = false;
            this.dgvappointments.AllowUserToDeleteRows = false;
            this.dgvappointments.AllowUserToResizeColumns = false;
            this.dgvappointments.AllowUserToResizeRows = false;
            this.dgvappointments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvappointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvappointments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvappointments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvappointments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvappointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvappointments.ColumnHeadersHeight = 35;
            this.dgvappointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvappointments.ColumnHeadersVisible = false;
            this.dgvappointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnicon,
            this.Columnnotice,
            this.Columnnoticedate,
            this.Columntype,
            this.Columnid});
            this.dgvappointments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvappointments.GridColor = System.Drawing.Color.Gray;
            this.dgvappointments.Location = new System.Drawing.Point(2, 1);
            this.dgvappointments.Name = "dgvappointments";
            this.dgvappointments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvappointments.RowHeadersVisible = false;
            this.dgvappointments.RowHeadersWidth = 100;
            this.dgvappointments.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvappointments.RowTemplate.Height = 100;
            this.dgvappointments.Size = new System.Drawing.Size(480, 395);
            this.dgvappointments.TabIndex = 36;
            this.dgvappointments.TabStop = false;
            this.dgvappointments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvappointments_CellClick);
            this.dgvappointments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvappointments_CellDoubleClick);
            // 
            // Columnicon
            // 
            this.Columnicon.HeaderText = "Time Slot";
            this.Columnicon.Name = "Columnicon";
            this.Columnicon.ReadOnly = true;
            this.Columnicon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnicon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Columnicon.Width = 145;
            // 
            // Columnnotice
            // 
            this.Columnnotice.HeaderText = "Appointments";
            this.Columnnotice.Name = "Columnnotice";
            this.Columnnotice.ReadOnly = true;
            this.Columnnotice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnnotice.Width = 260;
            // 
            // Columnnoticedate
            // 
            this.Columnnoticedate.HeaderText = "Cancel";
            this.Columnnoticedate.Name = "Columnnoticedate";
            this.Columnnoticedate.ReadOnly = true;
            this.Columnnoticedate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnnoticedate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Columnnoticedate.Width = 75;
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
            this.Columnid.HeaderText = "id";
            this.Columnid.Name = "Columnid";
            this.Columnid.Visible = false;
            this.Columnid.Width = 5;
            // 
            // btnappointmentlist
            // 
            this.btnappointmentlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(213)))), ((int)(((byte)(253)))));
            this.btnappointmentlist.BackgroundImage = global::Doctor.Properties.Resources.personal_info_button;
            this.btnappointmentlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnappointmentlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnappointmentlist.FlatAppearance.BorderSize = 0;
            this.btnappointmentlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnappointmentlist.ForeColor = System.Drawing.Color.White;
            this.btnappointmentlist.Image = global::Doctor.Properties.Resources.menubar;
            this.btnappointmentlist.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnappointmentlist.Location = new System.Drawing.Point(0, 0);
            this.btnappointmentlist.Name = "btnappointmentlist";
            this.btnappointmentlist.Size = new System.Drawing.Size(481, 36);
            this.btnappointmentlist.TabIndex = 0;
            this.btnappointmentlist.Text = "Appointments and Vaccinations";
            this.btnappointmentlist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnappointmentlist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnappointmentlist.UseVisualStyleBackColor = false;
            this.btnappointmentlist.Click += new System.EventHandler(this.btnappointmentlist_Click);
            // 
            // timer_appointment
            // 
            this.timer_appointment.Interval = 30;
            this.timer_appointment.Tick += new System.EventHandler(this.timer_appointment_Tick);
            // 
            // calendarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel_mainlist);
            this.Controls.Add(this.lbselecteddate);
            this.Controls.Add(this.calendar1);
            this.Name = "calendarView";
            this.Size = new System.Drawing.Size(1118, 441);
            this.Load += new System.EventHandler(this.calendarView_Load);
            this.panel_mainlist.ResumeLayout(false);
            this.panel_appointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvappointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbselecteddate;
        private Calendar.NET.Calendar calendar1;
        private System.Windows.Forms.Panel panel_mainlist;
        private System.Windows.Forms.Panel panel_appointments;
        private System.Windows.Forms.DataGridView dgvappointments;
        private System.Windows.Forms.Button btnappointmentlist;
        private System.Windows.Forms.Timer timer_appointment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnicon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnnotice;
        private System.Windows.Forms.DataGridViewImageColumn Columnnoticedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columntype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
    }
}
