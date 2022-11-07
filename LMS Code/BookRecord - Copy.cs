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
    public partial class BookRecord : Form
    {
        
        public BookRecord()
        {
            InitializeComponent();
        }

        private void Back_btn(object sender, EventArgs e)
        {
            Student_Home_Page obj1 = new Student_Home_Page();
            obj1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";

            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            con.Open();


            String str = "select Name from Book WHERE Name like '" + textBox1.Text + "%' order by Name ;";

            //select  Book_ID , Name , IssueDate from Book WHERE ReturnedDate !=''; 

            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
