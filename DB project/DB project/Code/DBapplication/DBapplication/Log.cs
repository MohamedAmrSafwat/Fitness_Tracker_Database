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
    public partial class Log : Form
    {
        Welcome welcomeForm;
        Controller controllerObj;
        public Log(Welcome welcomeForm)
        {
            InitializeComponent();
            this.welcomeForm = welcomeForm;
            controllerObj = new Controller();
        }

        private void Log_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.welcomeForm.Show();
        }

        private void LogInbutton_Click(object sender, EventArgs e)
        {

            string username = usernametextBox.Text;
            string password = passwordtextBox.Text;

            string userType = controllerObj.ValidateUser(username, password);

            if(userType != null)
            {
                MessageBox.Show("Log in successfull ! Welcome, " + username + "!");

                switch (userType)
                {
                    case "User":
                        Users userForm = new Users(this);
                        userForm.Show();
                        this.Hide();
                        break;

                    case "Coach":
                        Coach coachForm = new Coach(this);
                        coachForm.Show();
                        this.Hide();
                        break;

                    case "Nutritionist":
                        Nutritionist nutritionistForm = new Nutritionist(this);
                        nutritionistForm.Show();
                        this.Hide();
                        break;

                    default:
                        MessageBox.Show("Unknown user type!"); //, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again."); //, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                passwordtextBox.PasswordChar = '\0';

            }
            else {
                passwordtextBox.PasswordChar = '*';
            }
        }
    }
    }

