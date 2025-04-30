using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.Gray;
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            Form f = new Log(this);
            f.Show();
            this.Hide();
        }

        private void SignUpbutton_Click(object sender, EventArgs e)
        {
            Form f = new SignUp(this);
            f.Show();
            this.Hide();
        }
    }
}
