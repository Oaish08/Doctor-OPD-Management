using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class Image_Form : Form
    {
        public delegate void OverwriteImage(object sender);

        public event OverwriteImage imageChangeEvent;

        public event EventHandler imageEvent;

        string imagepath = string.Empty;

        public string ImagePath
        {
            get { return this.imagepath; }
        }

        List<string> images = new List<string>();
        List<string> dates = new List<string>();
        int index = -1;

        public Image_Form(List<string> path, int active, List<string> date)
        {
            InitializeComponent();
            this.Focus();
            images = path;
            index = active;
            dates = date;
            try
            {
                if (path[active] != "NA")
                {
                    pbreport.Image = Image.FromFile(path[active]);
                }
                else
                {
                    pbreport.Image = Properties.Resources.No_Image_Available;
                }
            }
            catch
            {
                pbreport.Image = Properties.Resources.No_Image_Available;
            }
           
            
            lbdate.Text = date[active];
            lbcurrent.Text = (index + 1).ToString() + "/" + images.Count.ToString();
            this.pbreport.MouseWheel += pbpage_MouseWheel;
        }

        private void pbpage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                pbreport.Width = pbreport.Width + 50;
                pbreport.Height = pbreport.Height + 50;
            }
            else
            {
                pbreport.Width = pbreport.Width - 50;
                pbreport.Height = pbreport.Height - 50;
            }
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            pbreport.Image.Dispose();
            this.Close();
            if(imageEvent != null)
            {
                imageEvent(null,null);
            }
        }

        private void pbclose_MouseHover(object sender, EventArgs e)
        {
            pbclose.Image = Properties.Resources.colorclose;
        }

        private void pbclose_MouseLeave(object sender, EventArgs e)
        {
            pbclose.Image = Properties.Resources._close;
        }

        private void pbminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbminimize_MouseHover(object sender, EventArgs e)
        {
            pbminimize.Image = Properties.Resources.colorminize;
        }

        private void pbminimize_MouseLeave(object sender, EventArgs e)
        {
            pbminimize.Image = Properties.Resources._minimize;
        }

        private void Image_Form_Leave(object sender, EventArgs e)
        {
            pbreport.Image.Dispose();
            this.Close();
            if (imageEvent != null)
            {
                imageEvent(null, null);
            }
        }

        private void Image_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                Image img = pbreport.Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipX);
                pbreport.Image = img;
            }
            if (e.KeyData == Keys.Left)
            {
                index--;
                if (index < 0)
                {
                    index = 0;
                }
                if (index >= 0)
                {
                    try
                    {
                        if (images[index] != "NA")
                        {
                            pbreport.Image = Image.FromFile(images[index]);
                        }
                        else
                        {
                            pbreport.Image = Properties.Resources.No_Image_Available;
                        }
                    }
                    catch
                    {
                        pbreport.Image = Properties.Resources.No_Image_Available;
                    }
                    
                    lbdate.Text = dates[index];
                    lbcurrent.Text = (index + 1).ToString() + "/" + images.Count.ToString();
                }
            }
            if (e.KeyData == Keys.Right)
            {
                index++;
                if (index == images.Count)
                {
                    index = images.Count - 1;
                }
                if (index <= (images.Count - 1))
                {
                    try
                    {
                        if (images[index] != "NA")
                        {
                            pbreport.Image = Image.FromFile(images[index]);
                        }
                        else
                        {
                            pbreport.Image = Properties.Resources.No_Image_Available;
                        }
                    }
                    catch
                    {
                        pbreport.Image = Properties.Resources.No_Image_Available;
                    }
                    lbdate.Text = dates[index];
                    lbcurrent.Text = (index + 1).ToString() + "/" + images.Count.ToString();
                }
            }
        }

        private void Image_Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void overwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pbreport.Image != Properties.Resources.No_Image_Available)
            {
                pbreport.Image.Dispose();
                this.Close();
                imagepath = images[index];
                if (imageChangeEvent != null)
                {
                    imageChangeEvent(images[index]);
                }
            }
        }

        private void addPrescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbreport.Image != Properties.Resources.No_Image_Available)
            {
                pbreport.Image.Dispose();
                this.Close();
                if (imageChangeEvent != null)
                {
                    imageChangeEvent(Properties.Settings.Default.prescriptionPage);
                }
            }
        }
    }
}
