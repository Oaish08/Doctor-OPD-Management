namespace Doctor
{
    partial class PenMemory_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PenMemory_Form));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cpbmainpleasewait = new CircularProgressBar.CircularProgressBar();
            this.lbmessage = new System.Windows.Forms.Label();
            this.timer_toclose = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(111, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(39, 17);
            this.listBox1.TabIndex = 41;
            this.listBox1.UseWaitCursor = true;
            this.listBox1.Visible = false;
            // 
            // cpbmainpleasewait
            // 
            this.cpbmainpleasewait.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cpbmainpleasewait.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cpbmainpleasewait.AnimationSpeed = 1000;
            this.cpbmainpleasewait.BackColor = System.Drawing.Color.Transparent;
            this.cpbmainpleasewait.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.cpbmainpleasewait.ForeColor = System.Drawing.Color.Silver;
            this.cpbmainpleasewait.InnerColor = System.Drawing.Color.Transparent;
            this.cpbmainpleasewait.InnerMargin = -10;
            this.cpbmainpleasewait.InnerWidth = -10;
            this.cpbmainpleasewait.Location = new System.Drawing.Point(14, 9);
            this.cpbmainpleasewait.MarqueeAnimationSpeed = 2000;
            this.cpbmainpleasewait.Name = "cpbmainpleasewait";
            this.cpbmainpleasewait.OuterColor = System.Drawing.Color.Gainsboro;
            this.cpbmainpleasewait.OuterMargin = -10;
            this.cpbmainpleasewait.OuterWidth = 1;
            this.cpbmainpleasewait.ProgressColor = System.Drawing.Color.White;
            this.cpbmainpleasewait.ProgressWidth = 5;
            this.cpbmainpleasewait.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpbmainpleasewait.Size = new System.Drawing.Size(31, 31);
            this.cpbmainpleasewait.StartAngle = 270;
            this.cpbmainpleasewait.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.cpbmainpleasewait.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbmainpleasewait.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpbmainpleasewait.SubscriptText = "";
            this.cpbmainpleasewait.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbmainpleasewait.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpbmainpleasewait.SuperscriptText = "";
            this.cpbmainpleasewait.TabIndex = 46;
            this.cpbmainpleasewait.TextMargin = new System.Windows.Forms.Padding(0);
            this.cpbmainpleasewait.UseWaitCursor = true;
            this.cpbmainpleasewait.Value = 30;
            // 
            // lbmessage
            // 
            this.lbmessage.AutoSize = true;
            this.lbmessage.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmessage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbmessage.Location = new System.Drawing.Point(54, 15);
            this.lbmessage.Name = "lbmessage";
            this.lbmessage.Size = new System.Drawing.Size(60, 17);
            this.lbmessage.TabIndex = 47;
            this.lbmessage.Text = "Message";
            this.lbmessage.UseWaitCursor = true;
            // 
            // timer_toclose
            // 
            this.timer_toclose.Interval = 45000;
            this.timer_toclose.Tick += new System.EventHandler(this.timer_toclose_Tick);
            // 
            // PenMemory_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.ClientSize = new System.Drawing.Size(295, 50);
            this.Controls.Add(this.lbmessage);
            this.Controls.Add(this.cpbmainpleasewait);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(690, 270);
            this.Name = "PenMemory_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "penMemory";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private CircularProgressBar.CircularProgressBar cpbmainpleasewait;
        private System.Windows.Forms.Label lbmessage;
        private System.Windows.Forms.Timer timer_toclose;
    }
}