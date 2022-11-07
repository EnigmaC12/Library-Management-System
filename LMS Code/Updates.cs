using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class Updates : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public void BindData()
        {
            cmd = new SqlCommand("select Id from Student_Librarian", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox4.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }

        public void BindData1()
        {
            cmd = new SqlCommand("select Book_ID from Book", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox6.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }
        public Updates()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Updates_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;

            cn = new SqlConnection(@"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True");
            cn.Open();

            BindData();
            BindData1();
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            con.Open();
            //  SqlDataReader dr = cmd1.ExecuteReader();
            cmd1.CommandText = @"update Student_Librarian set " + comboBox3.SelectedItem + " = @value where Id = @Id;";
            //cmd1.Parameters.AddWithValue("@col_name", );
            cmd1.Parameters.AddWithValue("@Id", comboBox4.Text);
            cmd1.Parameters.AddWithValue("@value", textBox1.Text);

            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record updated Succesfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            con.Open();
            //  SqlDataReader dr = cmd1.ExecuteReader();
            cmd1.CommandText = @"update Student_Librarian set " + comboBox5.SelectedItem + " = @value where Id = @Id;";
            //cmd1.Parameters.AddWithValue("@col_name", );
            cmd1.Parameters.AddWithValue("@Id", comboBox6.Text);
            cmd1.Parameters.AddWithValue("@value", textBox2.Text);

            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record updated Succesfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Librarian_HomePage obj1 = new Librarian_HomePage();
            obj1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Librarian_HomePage obj1 = new Librarian_HomePage();
            obj1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Student")
            {
                comboBox3.Items.Clear();
                panel1.Visible = true;
                panel2.Visible = false;
                comboBox3.Items.Add("Name");
                comboBox3.Items.Add("EmailID");
                comboBox3.Items.Add("Address");
                comboBox3.Items.Add("MobileNo");
                comboBox3.Items.Add("Department");
                comboBox3.Items.Add("Class");

            }
            else
            {
                if (comboBox1.Text == "Librarian")
                {
                    comboBox3.Items.Clear();
                    panel1.Visible = true;
                    panel2.Visible = false;
                    comboBox3.Items.Add("Name");
                    comboBox3.Items.Add("EmailID");
                    comboBox3.Items.Add("Address");
                    comboBox3.Items.Add("MobileNo");

                    // comboBox3.Items.Add("Name", "EmailID", "Address", "MobileNo");
                }
                else
                {
                    panel2.Visible = true;
                    panel1.Visible = false;
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Librarian_HomePage obj1 = new Librarian_HomePage();
            obj1.Show();
            this.Hide();
        }
    }
}
