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
    public partial class Return_Book : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public void BindData()
        {
            cmd = new SqlCommand("select ID from Student_Librarian where usertype='Student';", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }

        public void BindData1()
        {
            cmd = new SqlCommand("select Book_ID from Book;", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }
        public Return_Book()
        {
            InitializeComponent();
        }

        private void Back_btn(object sender, EventArgs e)
        {
            Librarian_HomePage obj1 = new Librarian_HomePage();
            obj1.Show();
            this.Hide();
        }

        private void Return_Book_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True");
            cn.Open();
            BindData();
            BindData1();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = @"select ReturnedDate from Book where Book_ID = @Book_ID AND Id =@Id;";
            cmd1.Parameters.AddWithValue("@Book_Id", comboBox2.Text);
            cmd1.Parameters.AddWithValue("@Id", comboBox1.Text);
            cmd1.Parameters.AddWithValue("@ReturnedDate", dateTimePicker3.Text);

            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString().Equals(String.Empty))
                {
                    dr.Close();


                    cmd1.CommandText = @"UPDATE Book SET ReturnedDate = @ReturnedDate where Book_ID = @Book_ID AND Id =@Id;";
                    cmd1.Parameters.AddWithValue("@Id5", comboBox1.Text);
                    cmd1.Parameters.AddWithValue("@Book_ID2", comboBox2.Text);
                    // cmd1.Parameters.AddWithValue("@IssueDate", dateTimePicker1.Text);
                    // cmd1.Parameters.AddWithValue("@DueDate", dateTimePicker2.Text);
                    cmd1.Parameters.AddWithValue("@ReturnedDate1", dateTimePicker3.Text);
                    // cmd1.Parameters.AddWithValue("@Fine", textBox6.Text);


                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Book returned successfully");

                   
                }


                else
                {
                    MessageBox.Show("Book already returned.");
                    dr.Close();
                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to 'delete' this record?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                cmd = new SqlCommand("delete from Book where Id=@Id", cn);
                cmd.Parameters.AddWithValue("@Id", comboBox1.Text);
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


            String str = "select  Book_ID , Id , ReturnedDate from Book WHERE ReturnedDate !='';";

            //select  Book_ID , Name , IssueDate from Book WHERE ReturnedDate !=''; 

            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
