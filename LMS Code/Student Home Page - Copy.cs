using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class Student_Home_Page : Form
    {
        public Student_Home_Page()
        {
            InitializeComponent();

        }

        private void Logout_btn(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            obj1.Show();
            this.Hide();
        }

        private void StudDetails_btn(object sender, EventArgs e)
        {
            Add_Student_Details obj1 = new Add_Student_Details();
            obj1.Show();
            this.Hide();
        }

        private void eBookLibrary_btn(object sender, EventArgs e)
        {
            BookRecord obj1 = new BookRecord();
            obj1.Show();
            this.Hide();
        }

        private void ChangePin_btn(object sender, EventArgs e)
        {
            ChangePin obj1 = new ChangePin();
            obj1.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
