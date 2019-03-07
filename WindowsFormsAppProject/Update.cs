using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsAppProject
{
    public partial class Update : Form
    {
        string Username;
        string username2;
        public Update(string username)
        {
            InitializeComponent();
            Username = username;
        }
        public Update(string username, string labelt)
        {
            InitializeComponent();
            Username = username;
            label18.Text = labelt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            if (Username == null)
            {
                this.Hide();
                Form1 f = new Form1();
                f.ShowDialog();
            }
            label16.Text = Username;
            comboBox1.Items.Add("Beylikduzu");
            comboBox1.Items.Add("Avcilar");
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con = oleDbConnection1;
            username2 = textBox4.Text;
            string selectSql = "select * from Users where username = '" + textBox4.Text + "'";
            OleDbCommand cmd = new OleDbCommand(selectSql, con);
            try
            {
                con.Open();

                using (OleDbDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        textBox1.Text = (read["fname"].ToString());
                        textBox2.Text = (read["lname"].ToString());
                        textBox3.Text = (read["username"].ToString());

                        if (read["address"].ToString() == "Avcilar")
                        {
                            comboBox1.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox1.SelectedIndex = 1;
                        }

                        if(read["RegStatus"].ToString() == "0")
                        {
                            checkBox1.Checked = false;
                        }
                        else
                        {
                            checkBox1.Checked = true;
                        }
                    }
                }

            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            string username = textBox3.Text;
            string address = comboBox1.GetItemText(comboBox1.SelectedItem);
            int regstatus = 0;
            if (checkBox1.Checked)
                regstatus = 1;
            else
                regstatus = 0;

            OleDbConnection con = new OleDbConnection();
            con = oleDbConnection1;
            con.Open();
            string selectSql = "UPDATE Users SET fname='" + fname + "',lname='" + lname + "',username='" + username + "',address='" + address + "',RegStatus ='" + regstatus + "'WHERE username = '" + username2 + "'";
            OleDbCommand cmd = new OleDbCommand(selectSql, con);
            int result = cmd.ExecuteNonQuery();
            if(result > 0)
            {
                MessageBox.Show("data was updated successfully");
                this.Hide();
                Dashboard d = new Dashboard(username, "from update");
                d.ShowDialog();
            }
            else
            {
                MessageBox.Show("data was not found");
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con = oleDbConnection1;
            con.Open();
            string selectSql = "DELETE FROM Users WHERE username = '" + textBox4.Text + "'";
            OleDbCommand cmd = new OleDbCommand(selectSql, con);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("data was deleted successfully");
            }
            else
            {
                MessageBox.Show("data was not found");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard d = new Dashboard(Username);
            d.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard d = new Dashboard(Username, "from update");
            d.ShowDialog();
        }
    }
}
