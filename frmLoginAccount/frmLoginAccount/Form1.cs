using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmLoginAccount
{
    public partial class Form1 : Form
    {
        private Cashier cashier;
        public Form1()
        {
            InitializeComponent();

            cashier = new Cashier("John Paul", "kambal123", "John Paul", "BSCS2.1A");
        }

        public class UserAccount
        {
            protected string Username { get; set; }
            protected string Password { get; set; }
            public string FullName { get; set; }
            public string Department { get; set; }

            public UserAccount(string username, string password, string fullName, string department)
            {
                Username = username;
                Password = password;
                FullName = fullName;
                Department = department;
            }

            // Method to validate login credentials
            public bool ValidateLogin(string username, string password)
            {
                return Username == username && Password == password;
            }
        }

        public class Cashier : UserAccount
        {
            public Cashier(string username, string password, string fullName, string department)
                : base(username, password, fullName, department)
            {
            }

            // Additional cashier-specific methods could go here if needed
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate user credentials
            if (cashier.ValidateLogin(username, password))
            {
                MessageBox.Show($"Welcome {cashier.FullName} from {cashier.Department}!",
                                "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open the main purchase form and hide the login form
                Form1 purchaseForm = new Form1();
                purchaseForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}
