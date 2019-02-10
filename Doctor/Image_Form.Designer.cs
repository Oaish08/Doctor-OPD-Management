namespace Doctor
{
    partial class Image_Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Form));
            this.pbminimize = new System.Windows.Forms.PictureBox();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.pbreport = new System.Windows.Forms.PictureBox();
            this.lbdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsOverwrite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.overwriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPrescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbcurrent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbminimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbreport)).BeginInit();
            this.cmsOverwrite.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbminimize
            // 
            this.pbminimize.Image = global::Doctor.Properties.Resources._minimize;
            this.pbminimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbminimize.Location = new System.Drawing.Point(509, 0);
            this.pbminimize.Name = "pbminimize";
            this.pbminimize.Size = new System.Drawing.Size(17, 17);
            this.pbminimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbminimize.TabIndex = 7;
            this.pbminimize.TabStop = false;
            this.pbminimize.Click += new System.EventHandler(this.pbminimize_Click);
            this.pbminimize.MouseLeave += new System.EventHandler(this.pbminimize_MouseLeave);
            this.pbminimize.MouseHover += new System.EventHandler(this.pbminimize_MouseHover);
            // 
            // pbclose
            // 
            this.pbclose.Image = ((System.Drawing.Image)(resources.GetObject("pbclose.Image")));
            this.pbclose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbclose.Location = new System.Drawing.Point(526, 0);
            this.pbclose.Name = "pbclose";
            this.pbclose.Size = new System.Drawing.Size(17, 17);
            this.pbclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbclose.TabIndex = 6;
            this.pbclose.TabStop = false;
            this.pbclose.Click += new System.EventHandler(this.pbclose_Click);
            this.pbclose.MouseLeave += new System.EventHandler(this.pbclose_MouseLeave);
            this.pbclose.MouseHover += new System.EventHandler(this.pbclose_MouseHover);
            // 
            // pbreport
            // 
            this.pbreport.Location = new System.Drawing.Point(0, 27);
            this.pbreport.Name = "pbreport";
            this.pbreport.Size = new System.Drawing.Size(541, 691);
            this.pbreport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbreport.TabIndex = 8;
            this.pbreport.TabStop = false;
            // 
            // lbdate
            // 
            this.lbdate.AutoSize = true;
            this.lbdate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lbdate.Location = new System.Drawing.Point(281, 2);
            this.lbdate.Name = "lbdate";
            this.lbdate.Size = new System.Drawing.Size(53, 22);
            this.lbdate.TabIndex = 9;
            this.lbdate.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.label1.Location = new System.Drawing.Point(188, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dated =>";
            // 
            // cmsOverwrite
            // 
            this.cmsOverwrite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overwriteToolStripMenuItem,
            this.addPrescriptionToolStripMenuItem});
            this.cmsOverwrite.Name = "cmsOverwrite";
            this.cmsOverwrite.Size = new System.Drawing.Size(163, 48);
            this.cmsOverwrite.Text = "Overwrite";
            // 
            // overwriteToolStripMenuItem
            // 
            this.overwriteToolStripMenuItem.Name = "overwriteToolStripMenuItem";
            this.overwriteToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.overwriteToolStripMenuItem.Text = "Overwrite";
            this.overwriteToolStripMenuItem.Click += new System.EventHandler(this.overwriteToolStripMenuItem_Click);
            // 
            // addPrescriptionToolStripMenuItem
            // 
            this.addPrescriptionToolStripMenuItem.Name = "addPrescriptionToolStripMenuItem";
            this.addPrescriptionToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addPrescriptionToolStripMenuItem.Text = "Add Prescription";
            this.addPrescriptionToolStripMenuItem.Click += new System.EventHandler(this.addPrescriptionToolStripMenuItem_Click);
            // 
            // lbcurrent
            // 
            this.lbcurrent.AutoSize = true;
            this.lbcurrent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lbcurrent.Location = new System.Drawing.Point(236, 673);
            this.lbcurrent.Name = "lbcurrent";
            this.lbcurrent.Size = new System.Drawing.Size(80, 22);
            this.lbcurrent.TabIndex = 13;
            this.lbcurrent.Text = "Current";
            // 
            // Image_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(546, 720);
            this.ContextMenuStrip = this.cmsOverwrite;
            this.Controls.Add(this.lbcurrent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbdate);
            this.Controls.Add(this.pbminimize);
            this.Controls.Add(this.pbclose);
            this.Controls.Add(this.pbreport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Image_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PictureBOX";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Image_Form_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Image_Form_KeyPress);
            this.Leave += new System.EventHandler(this.Image_Form_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pbminimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbreport)).EndInit();
            this.cmsOverwrite.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbminimize;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.PictureBox pbreport;
        private System.Windows.Forms.Label lbdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsOverwrite;
        private System.Windows.Forms.ToolStripMenuItem overwriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPrescriptionToolStripMenuItem;
        private System.Windows.Forms.Label lbcurrent;
    }
}