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
    public partial class Issue_Book : Form
    {

        DataTable table = new DataTable();

        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public void BindData()
        {
            cmd = new SqlCommand("select Id from Student_Librarian where usertype='Student'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }

        public void BindData1()
        {
            cmd = new SqlCommand("select Book_ID from Book", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }
        public Issue_Book()
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
            cmd1.CommandText = @"select ReturnedDate , IssueDate  from Book where Book_ID = @Book_ID AND ID = @ID ;";
            cmd1.Parameters.AddWithValue("@Book_Id", comboBox2.Text);
            cmd1.Parameters.AddWithValue("@Id", comboBox1.Text);

            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {

                if (dr[0].ToString().Equals(String.Empty) && dr[1].ToString().Equals(String.Empty))
                {
                    cmd1.CommandText = @"Insert into Book values (@Book_ID2 , '', '', '', '', '','',@IssueDate ,'',@DueDate ,'',@Id1) ;";
                    cmd1.Parameters.AddWithValue("@Id1", comboBox1.Text);
                    cmd1.Parameters.AddWithValue("@Book_ID2", comboBox2.Text);
                    cmd1.Parameters.AddWithValue("@IssueDate", dateTimePicker2.Text);
                    cmd1.Parameters.AddWithValue("@DueDate", dateTimePicker1.Text);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Book issued successfully");
                    dr.Close();
                    con.Close();

                }
                else
                {
                    if(dr[0].ToString().Equals(String.Empty))
                    {
                        MessageBox.Show("Book already issued , to this member");
                        dr.Close();
                        con.Close();
                    }
                    //else
                    //{
                    //    cmd1.CommandText = @"Insert into Book values (@Book_ID2 , '', '', '', '', '','',@IssueDate ,'',@DueDate ,'',@Id1) ;";
                    //    cmd1.Parameters.AddWithValue("@Id1", comboBox1.Text);
                    //    cmd1.Parameters.AddWithValue("@Book_ID2", comboBox2.Text);
                    //    cmd1.Parameters.AddWithValue("@IssueDate", dateTimePicker2.Text);
                    //    cmd1.Parameters.AddWithValue("@DueDate", dateTimePicker1.Text);
                    //    cmd1.ExecuteNonQuery();
                    //    MessageBox.Show("Book issued successfully");
                    //    dr.Close();
                    //    con.Close();
                    //}
                }

                   
             }
                else 
                {
                    dr.Close();
                    cmd1.CommandText = @"Insert into Book values (@Book_ID2 , '', '', '', '', '','',@IssueDate ,'',@DueDate ,'',@Id1) ;";
                    cmd1.Parameters.AddWithValue("@Id1", comboBox1.Text);
                    cmd1.Parameters.AddWithValue("@Book_ID2", comboBox2.Text);
                    cmd1.Parameters.AddWithValue("@IssueDate", dateTimePicker2.Text);
                    cmd1.Parameters.AddWithValue("@DueDate", dateTimePicker1.Text);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Book issued successfully");
                    dr.Close();
                    con.Close();
                }
                
            //}
            
            //{
               

                //MessageBox.Show("Book already issued , to this member");
                //dr.Close();
                //con.Close();

          //  }
        }

        private void Issue_Book_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True");
            cn.Open();
            BindData();
            BindData1();
            cn.Close();
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


            String str = "select  ID, Book_ID, Name , IssueDate from Book WHERE IssueDate !='';";

            //select  ,Book_ID , Name , IssueDate from Book WHERE ReturnedDate !=''; 

            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
