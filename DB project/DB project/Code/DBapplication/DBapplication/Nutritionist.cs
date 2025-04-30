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
    public partial class Nutritionist : Form
    {
        Log logForm;
        public Nutritionist(Log logForm)
        {
            InitializeComponent();
            this.logForm = logForm;
        }

        private void Nutritionist_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.logForm.Show();
        }
    }
}
