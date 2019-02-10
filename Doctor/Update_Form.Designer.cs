namespace Doctor
{
    partial class Update_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Update_Form));
            this.panel_flash = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pblogo = new System.Windows.Forms.PictureBox();
            this.panel_checkingupdates = new System.Windows.Forms.Panel();
            this.lbchecking = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbminimize = new System.Windows.Forms.PictureBox();
            this.pblogo1 = new System.Windows.Forms.PictureBox();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.panel_downloadingupdates = new System.Windows.Forms.Panel();
            this.lbupdating = new System.Windows.Forms.Label();
            this.lbstatus = new System.Windows.Forms.Label();
            this.pbdownloadbar = new MaterialSkin.Controls.MaterialProgressBar();
            this.cpbchecking = new CircularProgressBar.CircularProgressBar();
            this.timer_tochange = new System.Windows.Forms.Timer(this.components);
            this.panel_flash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).BeginInit();
            this.panel_checkingupdates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbminimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            this.panel_downloadingupdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_flash
            // 
            this.panel_flash.BackgroundImage = global::Doctor.Properties.Resources.background3;
            this.panel_flash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_flash.Controls.Add(this.label2);
            this.panel_flash.Controls.Add(this.label1);
            this.panel_flash.Controls.Add(this.pblogo);
            this.panel_flash.Location = new System.Drawing.Point(0, 0);
            this.panel_flash.Name = "panel_flash";
            this.panel_flash.Size = new System.Drawing.Size(280, 440);
            this.panel_flash.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(112, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Always at your Fingertips.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(14, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Medical Records.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pblogo
            // 
            this.pblogo.BackColor = System.Drawing.Color.Transparent;
            this.pblogo.Image = ((System.Drawing.Image)(resources.GetObject("pblogo.Image")));
            this.pblogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pblogo.Location = new System.Drawing.Point(56, 140);
            this.pblogo.Name = "pblogo";
            this.pblogo.Size = new System.Drawing.Size(151, 54);
            this.pblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pblogo.TabIndex = 6;
            this.pblogo.TabStop = false;
            // 
            // panel_checkingupdates
            // 
            this.panel_checkingupdates.BackgroundImage = global::Doctor.Properties.Resources.background_next;
            this.panel_checkingupdates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_checkingupdates.Controls.Add(this.cpbchecking);
            this.panel_checkingupdates.Controls.Add(this.lbchecking);
            this.panel_checkingupdates.Controls.Add(this.label3);
            this.panel_checkingupdates.Controls.Add(this.label4);
            this.panel_checkingupdates.Controls.Add(this.pbminimize);
            this.panel_checkingupdates.Controls.Add(this.pblogo1);
            this.panel_checkingupdates.Controls.Add(this.pbclose);
            this.panel_checkingupdates.Location = new System.Drawing.Point(300, 0);
            this.panel_checkingupdates.Name = "panel_checkingupdates";
            this.panel_checkingupdates.Size = new System.Drawing.Size(280, 440);
            this.panel_checkingupdates.TabIndex = 28;
            // 
            // lbchecking
            // 
            this.lbchecking.AutoSize = true;
            this.lbchecking.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbchecking.Location = new System.Drawing.Point(101, 204);
            this.lbchecking.Name = "lbchecking";
            this.lbchecking.Size = new System.Drawing.Size(110, 13);
            this.lbchecking.TabIndex = 48;
            this.lbchecking.Text = "Checking for Updates";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(112, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Always at your Fingertips.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(14, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Medical Records.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbminimize
            // 
            this.pbminimize.Image = global::Doctor.Properties.Resources._minimize;
            this.pbminimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbminimize.Location = new System.Drawing.Point(250, 0);
            this.pbminimize.Name = "pbminimize";
            this.pbminimize.Size = new System.Drawing.Size(15, 15);
            this.pbminimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbminimize.TabIndex = 3;
            this.pbminimize.TabStop = false;
            this.pbminimize.Click += new System.EventHandler(this.pbminimize_Click);
            this.pbminimize.MouseLeave += new System.EventHandler(this.pbminimize_MouseLeave);
            this.pbminimize.MouseHover += new System.EventHandler(this.pbminimize_MouseHover);
            // 
            // pblogo1
            // 
            this.pblogo1.BackColor = System.Drawing.Color.Transparent;
            this.pblogo1.Image = ((System.Drawing.Image)(resources.GetObject("pblogo1.Image")));
            this.pblogo1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pblogo1.Location = new System.Drawing.Point(66, 102);
            this.pblogo1.Name = "pblogo1";
            this.pblogo1.Size = new System.Drawing.Size(139, 47);
            this.pblogo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pblogo1.TabIndex = 9;
            this.pblogo1.TabStop = false;
            // 
            // pbclose
            // 
            this.pbclose.Image = ((System.Drawing.Image)(resources.GetObject("pbclose.Image")));
            this.pbclose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbclose.Location = new System.Drawing.Point(265, 0);
            this.pbclose.Name = "pbclose";
            this.pbclose.Size = new System.Drawing.Size(15, 15);
            this.pbclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbclose.TabIndex = 2;
            this.pbclose.TabStop = false;
            this.pbclose.Click += new System.EventHandler(this.pbclose_Click);
            this.pbclose.MouseLeave += new System.EventHandler(this.pbclose_MouseLeave);
            this.pbclose.MouseHover += new System.EventHandler(this.pbclose_MouseHover);
            // 
            // panel_downloadingupdates
            // 
            this.panel_downloadingupdates.BackColor = System.Drawing.Color.Transparent;
            this.panel_downloadingupdates.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_downloadingupdates.BackgroundImage")));
            this.panel_downloadingupdates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_downloadingupdates.Controls.Add(this.lbupdating);
            this.panel_downloadingupdates.Controls.Add(this.lbstatus);
            this.panel_downloadingupdates.Controls.Add(this.pbdownloadbar);
            this.panel_downloadingupdates.Location = new System.Drawing.Point(600, 170);
            this.panel_downloadingupdates.Name = "panel_downloadingupdates";
            this.panel_downloadingupdates.Size = new System.Drawing.Size(280, 270);
            this.panel_downloadingupdates.TabIndex = 29;
            // 
            // lbupdating
            // 
            this.lbupdating.AutoSize = true;
            this.lbupdating.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbupdating.Location = new System.Drawing.Point(17, 50);
            this.lbupdating.Name = "lbupdating";
            this.lbupdating.Size = new System.Drawing.Size(95, 13);
            this.lbupdating.TabIndex = 34;
            this.lbupdating.Text = "Updating Software";
            // 
            // lbstatus
            // 
            this.lbstatus.AutoSize = true;
            this.lbstatus.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbstatus.Location = new System.Drawing.Point(17, 11);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(67, 13);
            this.lbstatus.TabIndex = 33;
            this.lbstatus.Text = "Downloaded";
            // 
            // pbdownloadbar
            // 
            this.pbdownloadbar.Depth = 0;
            this.pbdownloadbar.ForeColor = System.Drawing.Color.DarkCyan;
            this.pbdownloadbar.Location = new System.Drawing.Point(20, 33);
            this.pbdownloadbar.MouseState = MaterialSkin.MouseState.HOVER;
            this.pbdownloadbar.Name = "pbdownloadbar";
            this.pbdownloadbar.Size = new System.Drawing.Size(248, 5);
            this.pbdownloadbar.TabIndex = 32;
            // 
            // cpbchecking
            // 
            this.cpbchecking.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cpbchecking.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cpbchecking.AnimationSpeed = 1000;
            this.cpbchecking.BackColor = System.Drawing.Color.Transparent;
            this.cpbchecking.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.cpbchecking.ForeColor = System.Drawing.Color.Silver;
            this.cpbchecking.InnerColor = System.Drawing.Color.Transparent;
            this.cpbchecking.InnerMargin = -10;
            this.cpbchecking.InnerWidth = -10;
            this.cpbchecking.Location = new System.Drawing.Point(55, 194);
            this.cpbchecking.MarqueeAnimationSpeed = 2000;
            this.cpbchecking.Name = "cpbchecking";
            this.cpbchecking.OuterColor = System.Drawing.Color.Gainsboro;
            this.cpbchecking.OuterMargin = -10;
            this.cpbchecking.OuterWidth = 1;
            this.cpbchecking.ProgressColor = System.Drawing.Color.DarkCyan;
            this.cpbchecking.ProgressWidth = 5;
            this.cpbchecking.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpbchecking.Size = new System.Drawing.Size(40, 40);
            this.cpbchecking.StartAngle = 270;
            this.cpbchecking.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.cpbchecking.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbchecking.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpbchecking.SubscriptText = "";
            this.cpbchecking.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbchecking.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpbchecking.SuperscriptText = "";
            this.cpbchecking.TabIndex = 49;
            this.cpbchecking.TextMargin = new System.Windows.Forms.Padding(0);
            this.cpbchecking.UseWaitCursor = true;
            this.cpbchecking.Value = 30;
            // 
            // timer_tochange
            // 
            this.timer_tochange.Tick += new System.EventHandler(this.timer_tochange_Tick);
            // 
            // Update_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(880, 440);
            this.Controls.Add(this.panel_downloadingupdates);
            this.Controls.Add(this.panel_flash);
            this.Controls.Add(this.panel_checkingupdates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Update_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update_Form";
            this.Load += new System.EventHandler(this.Update_Form_Load);
            this.panel_flash.ResumeLayout(false);
            this.panel_flash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).EndInit();
            this.panel_checkingupdates.ResumeLayout(false);
            this.panel_checkingupdates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbminimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            this.panel_downloadingupdates.ResumeLayout(false);
            this.panel_downloadingupdates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_flash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pblogo;
        private System.Windows.Forms.Panel panel_checkingupdates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbminimize;
        private System.Windows.Forms.PictureBox pblogo1;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.Panel panel_downloadingupdates;
        private System.Windows.Forms.Label lbupdating;
        private System.Windows.Forms.Label lbstatus;
        private MaterialSkin.Controls.MaterialProgressBar pbdownloadbar;
        private System.Windows.Forms.Label lbchecking;
        private CircularProgressBar.CircularProgressBar cpbchecking;
        private System.Windows.Forms.Timer timer_tochange;
    }
}