using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsAppProject
{
    public partial class Form1 : Form
    {
        private string username;
        private string password;
            
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.FlatAppearance.BorderSize = 0;
            textBox1.Text = "username";
            passtxt.Text = "password";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //exit button customization
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.Transparent;
        }
        
        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.FromArgb(41, 53, 65);
        }

        //log in button customization
        private void logIn_MouseEnter(object sender, EventArgs e)
        {
            logIn.BackColor = Color.FromArgb(41, 53, 65);
            logIn.ForeColor = Color.White;
        }

        private void logIn_MouseLeave(object sender, EventArgs e)
        {
            logIn.BackColor = Color.Transparent;
            logIn.ForeColor = Color.Black;
        }

        private void usernametxt_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void usernametxt_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "username";
                textBox1.ForeColor = Color.DarkGray;
            }
        }

        private void passtxt_Enter(object sender, EventArgs e)
        {
            if (passtxt.Text == "password")
            {
                passtxt.Text = "";
                passtxt.ForeColor = Color.Black;
            }
        }

        private void passtxt_Leave(object sender, EventArgs e)
        {
            if (passtxt.Text == "")
            {
                passtxt.Text = "password";
                passtxt.ForeColor = Color.DarkGray;
            }
        }

        private void logIn_Click(object sender, EventArgs e)
        {
            Username = textBox1.Text;
            Password = passtxt.Text;
            OleDbConnection con = oleDbConnection1;
            con.Open();
            string query = "SELECT * FROM Users WHERE username = '" + Username + "' AND password = '" + Password + "' AND userType = True";
            OleDbCommand cmd = new OleDbCommand(query,con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                this.Hide();
                Dashboard d1 = new Dashboard(Username);
                d1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Credentials, Please Re-Enter");
            }
            con.Close();
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
