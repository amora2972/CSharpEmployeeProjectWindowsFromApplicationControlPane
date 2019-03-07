using System;
using System.Drawing;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
namespace WindowsFormsAppProject
{
    public partial class Dashboard : Form
    {
        string Username;
        string username;
        string fname;
        string lname;
        string address;
        string checkers;
        public Dashboard(string username)
        {
            InitializeComponent();
            Username = username;
        }

        public Dashboard(string username, string x)
        {
            InitializeComponent();
            Username = username;
            if(x == "from update")
            {
                checkers = x;
                panel5.Visible = true;
                label18.Visible = true;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            if (Username == null)
            {
                this.Hide();
                Form1 f = new Form1();
                f.ShowDialog();
            }


            comboBox1.Items.Add("Beylikduzu");
            comboBox1.Items.Add("Avcilar");
            styling();
            fillingAvcilarData();
            fillingBeylikduzuData();
            if(checkers != "from update")
            {
                panel5.Visible = false;
                label18.Visible = false;
            }
            label16.Text = Username;

            OleDbConnection con = new OleDbConnection();
            con = oleDbConnection1;
            string query = "select * from Users where userType = false";

            OleDbDataAdapter da = new OleDbDataAdapter(query,con);
            DataTable d = new DataTable();
            da.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        }

        private void styling()
        {

        }

        private void fillingAvcilarData()
        {
            OleDbConnection con = oleDbConnection1;
            con.Open();
            string query = "SELECT * FROM Users WHERE address = 'Avcilar' AND RegStatus = True AND userType = False";
            OleDbCommand cmd = new OleDbCommand(query, con);
            int counter = 0;
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                counter++;
            }
            label8.Text = counter.ToString();

            query = "SELECT * FROM Users WHERE address = 'Avcilar' AND RegStatus = False AND userType = False";
            cmd = new OleDbCommand(query, con);
            counter = 0;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                counter++;
            }
            label9.Text = counter.ToString();
            con.Close();
        }

        private void fillingBeylikduzuData()
        {
            OleDbConnection con = oleDbConnection1;
            con.Open();
            string query = "SELECT * FROM Users WHERE address = 'Beylikduzu' AND RegStatus = True AND userType = False";
            OleDbCommand cmd = new OleDbCommand(query, con);
            int counter = 0;
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                counter++;
            }
            label10.Text = counter.ToString();

            query = "SELECT * FROM Users WHERE address = 'Beylikduzu' AND RegStatus = False AND userType = False";
            cmd = new OleDbCommand(query, con);
            counter = 0;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                counter++;
            }
            label11.Text = counter.ToString();
            con.Close();
        }

        private void addbtn_MouseEnter(object sender, EventArgs e)
        {
            addbtn.ForeColor = Color.White;
        }

        private void addbtn_MouseLeave(object sender, EventArgs e)
        {
            addbtn.ForeColor = Color.Black;
        }

        private void updatebtn_MouseEnter(object sender, EventArgs e)
        {
            updatebtn.ForeColor = Color.White;

        }

        private void updatebtn_MouseLeave(object sender, EventArgs e)
        {
            updatebtn.ForeColor = Color.Black;
        }

        private void deletebtn_MouseLeave(object sender, EventArgs e)
        {
            deletebtn.ForeColor = Color.Black;
        }

        private void deletebtn_MouseEnter(object sender, EventArgs e)
        {
            deletebtn.ForeColor = Color.White;

        }

        private void approvebtn_MouseLeave(object sender, EventArgs e)
        {
            approvebtn.ForeColor = Color.Black;
        }

        private void approvebtn_MouseEnter(object sender, EventArgs e)
        {
            approvebtn.ForeColor = Color.White;

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = false;
            label18.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = true;
            label18.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            int checked1 = 0;
            if (checkBox1.Checked) {
                checked1 = 1;
            }

            username = textBox3.Text;
            fname = textBox1.Text;
            lname = textBox2.Text;
            address = comboBox1.GetItemText(comboBox1.SelectedItem);
            OleDbConnection con = oleDbConnection1;
            con.Open();

            string query = "INSERT INTO Users(fname,lname,username,address,RegStatus) VALUES('" + fname + "','" + lname + "','" + username + "','" + address + "','" + checked1 + "')";
            OleDbCommand cmd = new OleDbCommand(query, con);
            int result = cmd.ExecuteNonQuery();
            if(result > 0)
            {
                MessageBox.Show("Employee inserted");
                OleDbConnection con2 = new OleDbConnection();
                con2 = oleDbConnection1;
                string query2 = "select * from Users where userType = false";

                OleDbDataAdapter da = new OleDbDataAdapter(query2, con2);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;
                con2.Close();
            }
            else
            {
                MessageBox.Show("Employee was not inserted");
            }
            con.Close();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update upad = new Update(Username);
            upad.ShowDialog();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update u = new Update(Username, "Deleting");
            u.ShowDialog();
        }

        private void approvebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update u = new Update(Username, "Approving");
            u.ShowDialog();
        }
    }
}
