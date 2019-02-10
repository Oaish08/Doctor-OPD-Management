using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class confirmmessage : UserControl
    {
        public event EventHandler ConfirmMessageEvent;

        public bool delete = false;

        public confirmmessage()
        {
            InitializeComponent();
        }

        private void btnno_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            if (ConfirmMessageEvent != null)
            {
                ConfirmMessageEvent(null, null);
            }
            this.Visible = false;
        }
    }
}
