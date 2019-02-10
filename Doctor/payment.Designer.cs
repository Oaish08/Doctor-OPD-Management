namespace Doctor
{
    partial class payment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbpayments = new System.Windows.Forms.RadioButton();
            this.lbpaymenttypes = new System.Windows.Forms.Label();
            this.rball = new System.Windows.Forms.RadioButton();
            this.rbdues = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnclear = new System.Windows.Forms.Button();
            this.tbsearchduedate = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbduedate = new System.Windows.Forms.Label();
            this.tbsearchmobile = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbmobile = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.tbsearchpatientname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbpatientname = new System.Windows.Forms.Label();
            this.lbpayments = new System.Windows.Forms.Label();
            this.btnnewpayment = new MaterialSkin.Controls.MaterialRaisedButton();
            this.calenderduedate = new System.Windows.Forms.MonthCalendar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvpatientpayment = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.confirmcompletepayment1 = new Doctor.confirmmessage();
            this.newPayment1 = new Doctor.newPayment();
            this.Columnduedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnamountpaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBalDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnpaymentstatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.Columnpaymentcompleted = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Columnddelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.paymentstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnpaymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpatientpayment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.panel2.Controls.Add(this.rbpayments);
            this.panel2.Controls.Add(this.lbpaymenttypes);
            this.panel2.Controls.Add(this.rball);
            this.panel2.Controls.Add(this.rbdues);
            this.panel2.Location = new System.Drawing.Point(-2, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1118, 37);
            this.panel2.TabIndex = 2;
            // 
            // rbpayments
            // 
            this.rbpayments.AutoSize = true;
            this.rbpayments.ForeColor = System.Drawing.Color.White;
            this.rbpayments.Location = new System.Drawing.Point(982, 9);
            this.rbpayments.Name = "rbpayments";
            this.rbpayments.Size = new System.Drawing.Size(71, 17);
            this.rbpayments.TabIndex = 3;
            this.rbpayments.TabStop = true;
            this.rbpayments.Text = "Payments";
            this.rbpayments.UseVisualStyleBackColor = true;
            this.rbpayments.Click += new System.EventHandler(this.rbpayments_Click);
            // 
            // lbpaymenttypes
            // 
            this.lbpaymenttypes.AutoSize = true;
            this.lbpaymenttypes.ForeColor = System.Drawing.Color.White;
            this.lbpaymenttypes.Location = new System.Drawing.Point(3, 7);
            this.lbpaymenttypes.Name = "lbpaymenttypes";
            this.lbpaymenttypes.Size = new System.Drawing.Size(75, 13);
            this.lbpaymenttypes.TabIndex = 2;
            this.lbpaymenttypes.Text = "Payment Type";
            this.lbpaymenttypes.TextChanged += new System.EventHandler(this.lbpaymenttypes_TextChanged);
            // 
            // rball
            // 
            this.rball.AutoSize = true;
            this.rball.ForeColor = System.Drawing.Color.White;
            this.rball.Location = new System.Drawing.Point(1070, 9);
            this.rball.Name = "rball";
            this.rball.Size = new System.Drawing.Size(36, 17);
            this.rball.TabIndex = 1;
            this.rball.TabStop = true;
            this.rball.Text = "All";
            this.rball.UseVisualStyleBackColor = true;
            this.rball.Click += new System.EventHandler(this.rball_Click);
            // 
            // rbdues
            // 
            this.rbdues.AutoSize = true;
            this.rbdues.ForeColor = System.Drawing.Color.White;
            this.rbdues.Location = new System.Drawing.Point(925, 9);
            this.rbdues.Name = "rbdues";
            this.rbdues.Size = new System.Drawing.Size(50, 17);
            this.rbdues.TabIndex = 0;
            this.rbdues.TabStop = true;
            this.rbdues.Text = "Dues";
            this.rbdues.UseVisualStyleBackColor = true;
            this.rbdues.Click += new System.EventHandler(this.rbdues_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.panel3.Controls.Add(this.btnclear);
            this.panel3.Controls.Add(this.tbsearchduedate);
            this.panel3.Controls.Add(this.lbduedate);
            this.panel3.Controls.Add(this.tbsearchmobile);
            this.panel3.Controls.Add(this.lbmobile);
            this.panel3.Controls.Add(this.btnsearch);
            this.panel3.Controls.Add(this.tbsearchpatientname);
            this.panel3.Controls.Add(this.lbpatientname);
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1118, 62);
            this.panel3.TabIndex = 3;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnclear.FlatAppearance.BorderSize = 0;
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnclear.Location = new System.Drawing.Point(605, 22);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(50, 25);
            this.btnclear.TabIndex = 8;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // tbsearchduedate
            // 
            this.tbsearchduedate.Depth = 0;
            this.tbsearchduedate.ForeColor = System.Drawing.Color.DimGray;
            this.tbsearchduedate.Hint = "";
            this.tbsearchduedate.Location = new System.Drawing.Point(333, 23);
            this.tbsearchduedate.MaxLength = 32767;
            this.tbsearchduedate.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbsearchduedate.Name = "tbsearchduedate";
            this.tbsearchduedate.PasswordChar = '\0';
            this.tbsearchduedate.SelectedText = "";
            this.tbsearchduedate.SelectionLength = 0;
            this.tbsearchduedate.SelectionStart = 0;
            this.tbsearchduedate.Size = new System.Drawing.Size(152, 23);
            this.tbsearchduedate.TabIndex = 10;
            this.tbsearchduedate.TabStop = false;
            this.tbsearchduedate.Text = "Select Date";
            this.tbsearchduedate.UseSystemPasswordChar = false;
            this.tbsearchduedate.Click += new System.EventHandler(this.tbsearchduedate_Click);
            this.tbsearchduedate.Leave += new System.EventHandler(this.tbsearchduedate_Leave);
            // 
            // lbduedate
            // 
            this.lbduedate.AutoSize = true;
            this.lbduedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbduedate.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbduedate.Location = new System.Drawing.Point(330, 5);
            this.lbduedate.Name = "lbduedate";
            this.lbduedate.Size = new System.Drawing.Size(61, 13);
            this.lbduedate.TabIndex = 6;
            this.lbduedate.Text = "Due Date";
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
            this.tbsearchmobile.Click += new System.EventHandler(this.tbsearchlastvisited_Click);
            this.tbsearchmobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbsearchmobile_KeyPress);
            this.tbsearchmobile.Leave += new System.EventHandler(this.tbsearchlastvisited_Leave);
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
            this.btnsearch.Location = new System.Drawing.Point(497, 23);
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
            this.tbsearchpatientname.TabIndex = 1;
            this.tbsearchpatientname.TabStop = false;
            this.tbsearchpatientname.Text = "Name";
            this.tbsearchpatientname.UseSystemPasswordChar = false;
            this.tbsearchpatientname.Click += new System.EventHandler(this.tbsearchpatientname_Click);
            this.tbsearchpatientname.Leave += new System.EventHandler(this.tbsearchpatientname_Leave);
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
            // lbpayments
            // 
            this.lbpayments.AutoSize = true;
            this.lbpayments.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbpayments.Location = new System.Drawing.Point(1, 3);
            this.lbpayments.Name = "lbpayments";
            this.lbpayments.Size = new System.Drawing.Size(53, 13);
            this.lbpayments.TabIndex = 4;
            this.lbpayments.Text = "Payments";
            // 
            // btnnewpayment
            // 
            this.btnnewpayment.AutoSize = true;
            this.btnnewpayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnnewpayment.BackColor = System.Drawing.Color.Black;
            this.btnnewpayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnnewpayment.Depth = 0;
            this.btnnewpayment.Icon = null;
            this.btnnewpayment.Location = new System.Drawing.Point(895, 610);
            this.btnnewpayment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnnewpayment.Name = "btnnewpayment";
            this.btnnewpayment.Primary = true;
            this.btnnewpayment.Size = new System.Drawing.Size(208, 36);
            this.btnnewpayment.TabIndex = 6;
            this.btnnewpayment.Text = "Add New Patient Payment";
            this.btnnewpayment.UseVisualStyleBackColor = false;
            this.btnnewpayment.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // calenderduedate
            // 
            this.calenderduedate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calenderduedate.Location = new System.Drawing.Point(331, 90);
            this.calenderduedate.MaxSelectionCount = 1;
            this.calenderduedate.Name = "calenderduedate";
            this.calenderduedate.TabIndex = 10;
            this.calenderduedate.Visible = false;
            this.calenderduedate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            this.calenderduedate.Leave += new System.EventHandler(this.monthCalendar2_Leave);
            this.calenderduedate.MouseLeave += new System.EventHandler(this.monthCalendar2_MouseLeave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Location = new System.Drawing.Point(-2, 603);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1118, 1);
            this.panel4.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(0, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 1);
            this.panel1.TabIndex = 1;
            // 
            // dgvpatientpayment
            // 
            this.dgvpatientpayment.AllowUserToAddRows = false;
            this.dgvpatientpayment.AllowUserToDeleteRows = false;
            this.dgvpatientpayment.AllowUserToResizeColumns = false;
            this.dgvpatientpayment.AllowUserToResizeRows = false;
            this.dgvpatientpayment.BackgroundColor = System.Drawing.Color.White;
            this.dgvpatientpayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvpatientpayment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvpatientpayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvpatientpayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvpatientpayment.ColumnHeadersHeight = 35;
            this.dgvpatientpayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvpatientpayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnduedate,
            this.Columnname,
            this.Columnmobile,
            this.ColumnAmount,
            this.Columnamountpaid,
            this.ColumnBalDue,
            this.Columnpaymentstatus,
            this.Columnpaymentcompleted,
            this.Columnddelete,
            this.paymentstatus,
            this.ColumnpaymentID});
            this.dgvpatientpayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvpatientpayment.GridColor = System.Drawing.Color.LightGray;
            this.dgvpatientpayment.Location = new System.Drawing.Point(0, 163);
            this.dgvpatientpayment.Name = "dgvpatientpayment";
            this.dgvpatientpayment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvpatientpayment.RowHeadersVisible = false;
            this.dgvpatientpayment.RowHeadersWidth = 60;
            this.dgvpatientpayment.RowTemplate.Height = 30;
            this.dgvpatientpayment.Size = new System.Drawing.Size(1118, 434);
            this.dgvpatientpayment.TabIndex = 12;
            this.dgvpatientpayment.TabStop = false;
            this.dgvpatientpayment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpatientpayment_CellClick);
            this.dgvpatientpayment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpatientpayment_CellDoubleClick);
            this.dgvpatientpayment.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvpatientpayment_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Location = new System.Drawing.Point(0, 197);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1118, 1);
            this.panel5.TabIndex = 2;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Cancel";
            this.dataGridViewImageColumn1.Image = global::Doctor.Properties.Resources.colorclose;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 70;
            // 
            // confirmcompletepayment1
            // 
            this.confirmcompletepayment1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.confirmcompletepayment1.Location = new System.Drawing.Point(0, 229);
            this.confirmcompletepayment1.Name = "confirmcompletepayment1";
            this.confirmcompletepayment1.Size = new System.Drawing.Size(1118, 150);
            this.confirmcompletepayment1.TabIndex = 13;
            this.confirmcompletepayment1.Visible = false;
            this.confirmcompletepayment1.Leave += new System.EventHandler(this.confirmcompletepayment1_Leave);
            // 
            // newPayment1
            // 
            this.newPayment1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.newPayment1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newPayment1.Location = new System.Drawing.Point(246, 48);
            this.newPayment1.Name = "newPayment1";
            this.newPayment1.ParentForm = null;
            this.newPayment1.Size = new System.Drawing.Size(280, 455);
            this.newPayment1.TabIndex = 11;
            this.newPayment1.Visible = false;
            this.newPayment1.Leave += new System.EventHandler(this.newPayment1_Leave);
            // 
            // Columnduedate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.Columnduedate.DefaultCellStyle = dataGridViewCellStyle2;
            this.Columnduedate.HeaderText = "Due Date";
            this.Columnduedate.Name = "Columnduedate";
            this.Columnduedate.ReadOnly = true;
            this.Columnduedate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Columnname
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Columnname.DefaultCellStyle = dataGridViewCellStyle3;
            this.Columnname.HeaderText = "Name";
            this.Columnname.Name = "Columnname";
            this.Columnname.ReadOnly = true;
            this.Columnname.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Columnname.Width = 230;
            // 
            // Columnmobile
            // 
            this.Columnmobile.HeaderText = "Mobile";
            this.Columnmobile.Name = "Columnmobile";
            this.Columnmobile.ReadOnly = true;
            this.Columnmobile.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnmobile.Width = 120;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnAmount.Width = 120;
            // 
            // Columnamountpaid
            // 
            this.Columnamountpaid.HeaderText = "Amount Paid";
            this.Columnamountpaid.Name = "Columnamountpaid";
            this.Columnamountpaid.ReadOnly = true;
            this.Columnamountpaid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnamountpaid.Width = 120;
            // 
            // ColumnBalDue
            // 
            this.ColumnBalDue.HeaderText = "Balance Due";
            this.ColumnBalDue.Name = "ColumnBalDue";
            this.ColumnBalDue.ReadOnly = true;
            this.ColumnBalDue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnBalDue.Width = 120;
            // 
            // Columnpaymentstatus
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.NullValue = null;
            this.Columnpaymentstatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.Columnpaymentstatus.HeaderText = "Payment Status";
            this.Columnpaymentstatus.Name = "Columnpaymentstatus";
            this.Columnpaymentstatus.ReadOnly = true;
            this.Columnpaymentstatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnpaymentstatus.Width = 138;
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
            // Columnddelete
            // 
            this.Columnddelete.HeaderText = "Delete";
            this.Columnddelete.Image = global::Doctor.Properties.Resources.cancel;
            this.Columnddelete.Name = "Columnddelete";
            this.Columnddelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columnddelete.Width = 60;
            // 
            // paymentstatus
            // 
            this.paymentstatus.HeaderText = "Columnpaymentstatustext";
            this.paymentstatus.Name = "paymentstatus";
            this.paymentstatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.paymentstatus.Visible = false;
            this.paymentstatus.Width = 5;
            // 
            // ColumnpaymentID
            // 
            this.ColumnpaymentID.HeaderText = "paymentID";
            this.ColumnpaymentID.Name = "ColumnpaymentID";
            this.ColumnpaymentID.Visible = false;
            this.ColumnpaymentID.Width = 5;
            // 
            // payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.confirmcompletepayment1);
            this.Controls.Add(this.newPayment1);
            this.Controls.Add(this.calenderduedate);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnnewpayment);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lbpayments);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvpatientpayment);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "payment";
            this.Size = new System.Drawing.Size(1118, 663);
            this.Load += new System.EventHandler(this.payment_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpatientpayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbpaymenttypes;
        private System.Windows.Forms.RadioButton rball;
        private System.Windows.Forms.RadioButton rbdues;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbpayments;
        private System.Windows.Forms.Label lbpatientname;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbsearchpatientname;
        private System.Windows.Forms.Button btnsearch;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbsearchduedate;
        private System.Windows.Forms.Label lbduedate;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbsearchmobile;
        private System.Windows.Forms.Label lbmobile;
        private System.Windows.Forms.Button btnclear;
        private MaterialSkin.Controls.MaterialRaisedButton btnnewpayment;
        private System.Windows.Forms.RadioButton rbpayments;
        private System.Windows.Forms.MonthCalendar calenderduedate;
        private newPayment newPayment1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvpatientpayment;
        private System.Windows.Forms.Panel panel5;
        private confirmmessage confirmcompletepayment1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnduedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnamountpaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBalDue;
        private System.Windows.Forms.DataGridViewImageColumn Columnpaymentstatus;
        private System.Windows.Forms.DataGridViewButtonColumn Columnpaymentcompleted;
        private System.Windows.Forms.DataGridViewImageColumn Columnddelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnpaymentID;
    }
}
