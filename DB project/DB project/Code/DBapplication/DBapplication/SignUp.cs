using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DBapplication
{
    public partial class SignUp : Form
    {
        Welcome f;
        Controller controllerObj;
        public SignUp(Welcome f)
        {
            InitializeComponent();
            this.f = f;
            controllerObj = new Controller();
        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.f.Show();
        }

        private void NutricheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UserradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (UserradioButton.Checked)
            {
                Agelabel.Visible = true;
                AgetextBox.Visible = true;
                GendergroupBox.Visible = true;
                Explabel.Visible = false;
                ExptextBox.Visible = false;
                Phonelabel.Visible = false;
                PhonetextBox.Visible = false;
            }
        }

        private void CoachradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CoachradioButton.Checked)
            {
                Explabel.Visible = true;
                ExptextBox.Visible = true;
                Phonelabel.Visible = true;
                PhonetextBox.Visible = true;
                Agelabel.Visible = false;
                AgetextBox.Visible = false;
                GendergroupBox.Visible = false;
            }
        }

        private void NutriradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NutriradioButton.Checked)
            {
                Explabel.Visible = true;
                ExptextBox.Visible = true;
                Phonelabel.Visible = true;
                PhonetextBox.Visible = true;
                Agelabel.Visible = false;
                AgetextBox.Visible = false;
                GendergroupBox.Visible = false;
            }

        }

        private void InsertUserbutton_Click(object sender, EventArgs e)
        {


            string GetGender()
            {
                if (MaleradioButton.Checked) return "Male";
                if (FemaleradioButton.Checked) return "Female";
                return string.Empty;
            }
            if (UserradioButton.Checked) {

                if (string.IsNullOrWhiteSpace(UsernametextBox.Text)|| string.IsNullOrWhiteSpace(PasswordtextBox.Text) || string.IsNullOrWhiteSpace(NametextBox.Text) || string.IsNullOrWhiteSpace(EmailtextBox.Text) || string.IsNullOrWhiteSpace(AgetextBox.Text) || string.IsNullOrEmpty(GetGender()))
                {
                    MessageBox.Show("Please fill the required fields to enter a new user !");
                    return;
                }
                if (!(AgetextBox.Text.Any(char.IsDigit)))
                {
                    MessageBox.Show("Enter a valid value for age !");
                    return;
                }

                controllerObj.InsertUser(UsernametextBox.Text , PasswordtextBox.Text , NametextBox.Text , EmailtextBox.Text , Convert.ToInt32(AgetextBox.Text), GetGender());
            
            }

            else if(CoachradioButton.Checked )
            {

                if (string.IsNullOrWhiteSpace(UsernametextBox.Text) || string.IsNullOrWhiteSpace(PasswordtextBox.Text) || string.IsNullOrWhiteSpace(NametextBox.Text) || string.IsNullOrWhiteSpace(EmailtextBox.Text) || string.IsNullOrWhiteSpace(ExptextBox.Text) || string.IsNullOrWhiteSpace(PhonetextBox.Text))
                {
                    MessageBox.Show("Please fill the required fields to enter a new Coach !");
                    return;
                }
                if (!(ExptextBox.Text.Any(char.IsDigit)))
                {
                    MessageBox.Show("Enter a valid value for experience years !");
                    return;
                }
                if (!(PhonetextBox.Text.Any(char.IsDigit)))
                {
                    MessageBox.Show("Enter a valid value for phone number !");
                    return;
                }


                controllerObj.InsertCoach(UsernametextBox.Text, PasswordtextBox.Text, NametextBox.Text, EmailtextBox.Text, Convert.ToInt32(ExptextBox.Text) , Convert.ToInt32(PhonetextBox.Text));
            }

            else if (NutriradioButton.Checked)
            {
                if (string.IsNullOrWhiteSpace(UsernametextBox.Text) || string.IsNullOrWhiteSpace(PasswordtextBox.Text) || string.IsNullOrWhiteSpace(NametextBox.Text) || string.IsNullOrWhiteSpace(EmailtextBox.Text) || string.IsNullOrWhiteSpace(ExptextBox.Text) || string.IsNullOrWhiteSpace(PhonetextBox.Text))
                {
                    MessageBox.Show("Please fill the required fields to enter a new nutritionist !");
                    return;
                }
                if (!(ExptextBox.Text.Any(char.IsDigit)))
                {
                    MessageBox.Show("Enter a valid value for experience years !");
                    return;
                }
                if (!(PhonetextBox.Text.Any(char.IsDigit)))
                {
                    MessageBox.Show("Enter a valid value for phone number !");
                    return;
                }

                controllerObj.InsertNutritionist(UsernametextBox.Text, PasswordtextBox.Text, NametextBox.Text, EmailtextBox.Text, Convert.ToInt32(ExptextBox.Text), Convert.ToInt32(PhonetextBox.Text));

            }

            else
            {
                MessageBox.Show("Please select a user type !");
                return;
            }
            MessageBox.Show("New user entered successfully !");

            string new_user = UsernametextBox.Text;

            MessageBox.Show(" Welcome to our Fitness App " + new_user  + "!");
        }
    }
}
