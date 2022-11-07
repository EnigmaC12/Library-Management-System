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
    public partial class ChangePin : Form
    {
        public int userid { get; set; }
        public ChangePin()
        {
            InitializeComponent();
        }

        private void Cancel_btn1(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            obj1.Show();
            this.Hide();
        }

        private void Cancel_btn2(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            obj1.Show();
            this.Hide();
        }

        private void ChangePin_Load(object sender, EventArgs e)
        {
            panel_setpassword.Visible = false;
            panel_Acceptforgotdata.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);

            SqlCommand cmd = new SqlCommand("select * from Student_Librarian where Id = @Id and EmailID = @EmailID and MobileNo = @MobileNo;", con);


            //select * from Employee where Id like @Id and password like @password;", con);

            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@EmailID", textBox2.Text);
            cmd.Parameters.AddWithValue("@MobileNo", textBox3.Text);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    panel_setpassword.Visible = true;
                }
                else
                {
                    MessageBox.Show("Record does not match");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel_setpassword_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == textBox5.Text)
            {
                String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
                SqlConnection con = new SqlConnection(CS);

                SqlCommand cmd = new SqlCommand("update Student_Librarian set  Password = @Password  where Id = @Id;", con);


                //select * from Employee where Id like @Id and password like @password;", con);

                cmd.Parameters.AddWithValue("@Password", textBox4.Text);
                // cmd.Parameters.AddWithValue("@confirmpass", textBox5.Text);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password updated Succesfully");
                con.Close();
            }
            else
            {
                MessageBox.Show("Password and Confirmpassword does not match");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student_Home_Page obj1 = new Student_Home_Page();
            obj1.Show();
            this.Hide();
        }
    }
}
