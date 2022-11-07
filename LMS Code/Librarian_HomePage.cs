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
    public partial class Librarian_HomePage : Form
    {
        public Librarian_HomePage()
        {
            InitializeComponent();
        }

        private void Logout_Btn(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            obj1.Show();
            this.Hide();
        }

        private void BookDetails_btn(object sender, EventArgs e)
        {
            Book_Details obj = new Book_Details();
            obj.Show();
            this.Hide();
        }

        private void Lib_Details(object sender, EventArgs e)
        {
            Staff_Register obj = new Staff_Register();
            obj.Show();
            this.Hide();
        }

        private void Issue_Book(object sender, EventArgs e)
        {
            Issue_Book obj = new Issue_Book();
            obj.Show();
            this.Hide();
        }

        private void Return_book_btn(object sender, EventArgs e)
        {
            Return_Book obj = new Return_Book();
            obj.Show();
            this.Hide();
        }

        private void Add_Student_btn(object sender, EventArgs e)
        {
            Add_Student_Details obj = new Add_Student_Details();
            obj.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Updates obj = new Updates();
            obj.Show();
            this.Hide();
        }

        private void Librarian_HomePage_Load(object sender, EventArgs e)
        {
           
        }
    }
}
