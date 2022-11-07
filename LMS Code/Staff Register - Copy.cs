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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagement
{
    public partial class Staff_Register : Form
    {
        public Staff_Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Back_btn(object sender, EventArgs e)
        {
            Librarian_HomePage obj1 = new Librarian_HomePage();
            obj1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = @"select distinct Id from Student_Librarian where Id = @Id;";
            cmd1.Parameters.AddWithValue("@Id", textBox4.Text);
            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("User already exist , Please select another user id");
                dr.Close();
                con.Close();
            }
            else
            {
                dr.Close();
                //SqlCommand cmd = new SqlCommand("Insert into Employee values (@Id , @name , @address , @gender , @position , @birthdate , @education , @phone , @mail , @salary , @password  , @usertype) ;", con);
                cmd1.CommandText = @"Insert into Student_Librarian values (@Id1 ,  @Password , @Name ,  @EmailID , @Address ,  @MobileNo ,'' ,'' , 'Librarian') ;";
                cmd1.Parameters.AddWithValue("@Id1", textBox4.Text);
                cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd1.Parameters.AddWithValue("@Address", textBox2.Text);
                cmd1.Parameters.AddWithValue("@MobileNo", textBox3.Text);
                cmd1.Parameters.AddWithValue("@EmailID", textBox5.Text);
                cmd1.Parameters.AddWithValue("@Password", textBox6.Text);
               
                cmd1.ExecuteNonQuery();
                MessageBox.Show("User added Successfully");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to 'delete' this record?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
                SqlConnection cn = new SqlConnection(CS);
                SqlCommand cmd;
                cmd = new SqlCommand("delete from Student_Librarian where Id=@Id", cn);
                cmd.Parameters.AddWithValue("@Id", textBox4.Text);
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


            String str = "select Name, ID, Password, EmailID, Address, MobileNo, usertype from Student_Librarian WHERE usertype = 'Librarian';";

            //select  Book_ID , Name , IssueDate from Book WHERE ReturnedDate !=''; 

            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
