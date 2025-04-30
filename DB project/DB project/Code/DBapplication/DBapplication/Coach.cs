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
    public partial class Coach : Form
    {
        Log logForm;
        public Coach(Log logForm)
        {
            InitializeComponent();
            this.logForm = logForm;
        }

        private void Coach_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.logForm.Show();
        }
    }
}
