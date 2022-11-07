using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagement
{
    public partial class View_Student_Details : Form
    {
        public View_Student_Details()
        {
            InitializeComponent();
        }

        private void Back_btn(object sender, EventArgs e)
        {
            Student_Home_Page obj1 = new Student_Home_Page();
            obj1.Show();
            this.Hide();
        }

        private void Search_btn(object sender, EventArgs e)
        {



        }

        private void View_Student_Details_Load(object sender, EventArgs e)
        {
            

        }
    }
}
