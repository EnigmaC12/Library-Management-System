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
    public partial class Book_Details : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Book_Details()
        {
            InitializeComponent();
        }

        private void Back_btn(object sender, EventArgs e)
        {
            Librarian_HomePage obj1 = new Librarian_HomePage();
            obj1.Show();
            this.Hide();
        }

        private void Book_Details_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = @"select distinct Book_ID from Book where Book_ID = @Book_ID;";
            cmd1.Parameters.AddWithValue("@Book_Id", textBox1.Text);
            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Book already exist , Please enter new Book_ID");
                dr.Close();
                con.Close();
            }
            else
            {
                dr.Close();
                
                
                cmd1.CommandText = @"Insert into Book values (@Book_ID1 ,  @Name , @Publisher ,  @Author , @Edition ,  @Price , @Qty, '', '', '', '', '') ;";
                cmd1.Parameters.AddWithValue("@Book_ID1", textBox1.Text);
                cmd1.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd1.Parameters.AddWithValue("@Publisher", textBox3.Text);
                cmd1.Parameters.AddWithValue("@Author", textBox4.Text);
                cmd1.Parameters.AddWithValue("@Edition", textBox5.Text);
                cmd1.Parameters.AddWithValue("@Price", double.Parse(textBox6.Text));
                cmd1.Parameters.AddWithValue("@Qty", textBox7.Text);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Book added successfully");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";

            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            con.Open();

            String str = "select Book_ID , Name, Publisher, Author, Edition, Price, Qty from Book;";
            //String str = "select* from Book WHERE IssueDate = '';";
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to 'delete' this record?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
                SqlConnection cn = new SqlConnection(CS);
                SqlCommand cmd;
                cmd = new SqlCommand("delete from Book where Book_ID= @Book_ID", cn);
                cmd.Parameters.AddWithValue("@Book_ID", textBox1.Text);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully !");
                cn.Close();

            }
        }
    }
}
