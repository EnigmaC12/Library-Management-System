using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagement
{
    public partial class Add_Student_Details : Form
    {
        //SqlConnection cn;
        //SqlCommand cmd;
        //SqlDataReader dr;
        public Add_Student_Details()
        {
            InitializeComponent();
        }

        private void Back_btn(object sender, EventArgs e)
        {
            Librarian_HomePage obj1 = new Librarian_HomePage();
            obj1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = @"select distinct Id from Student_Librarian where Id = @Id;";
            cmd1.Parameters.AddWithValue("@Id", textBox1.Text);
            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Student already exist , Please select another user id");
                dr.Close();
                con.Close();
            }
            else
            {
                dr.Close();
                cmd1.CommandText = @"Insert into Student_Librarian values (@ID4 , @Password, @Name ,  @EmailID , @Address ,  @MobileNo , @Department , @Class, 'Student') ;";
                cmd1.Parameters.AddWithValue("@Id4", textBox1.Text);
                cmd1.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd1.Parameters.AddWithValue("@Address", textBox5.Text);
                cmd1.Parameters.AddWithValue("@MobileNo", textBox3.Text);
                cmd1.Parameters.AddWithValue("@EmailID", textBox4.Text);
                cmd1.Parameters.AddWithValue("@Department", comboBox1.Text);
                cmd1.Parameters.AddWithValue("@Class", comboBox2.Text);
                cmd1.Parameters.AddWithValue("@Password", textBox6.Text);


                cmd1.ExecuteNonQuery();
                MessageBox.Show("Student added Successfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to 'delete' this record?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //SqlConnection con = new SqlConnection(CS);
                //SqlCommand cmd1 = new SqlCommand();
                String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
                SqlConnection cn = new SqlConnection(CS);
                SqlCommand cmd;
                cmd = new SqlCommand("delete from Student_Librarian where Id=@Id", cn);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully !");
                cn.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";

            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            con.Open();


            String str = "select * from Student_Librarian WHERE usertype = 'Student';";

            //select  Book_ID , Name , IssueDate from Book WHERE ReturnedDate !=''; 

            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Add_Student_Details_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
            if (Class1.usertype=="Student")
            {
                panel2.Visible = true;
                panel1.Visible = false;
                label11.Text = Class1.userid;
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Student_Home_Page obj = new Student_Home_Page();
            obj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text=Class1.userid;
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";

            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            con.Open();


            String str = "select * from Student_Librarian WHERE Id = '" + label1.Text+"';";

            //select  Book_ID , Name , IssueDate from Book WHERE ReturnedDate !=''; 

            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";

                SqlConnection con = new SqlConnection(CS);
               // SqlCommand cmd = new SqlCommand();
                con.Open();


                String str = "select Book_ID , ID , IssueDate , ReturnedDate from Book WHERE ID = '" + label11.Text + "';";

                //select  Book_ID , Name , IssueDate from Book WHERE ReturnedDate !=''; 

                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }
    }
}
