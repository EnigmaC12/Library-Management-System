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
    public partial class Form1 : Form
    {
        public string UserType = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.userid = textBox1.Text;
            Class1.usertype = comboBox1.Text;
            if (textBox1.Text != "" || textBox1.Text != " ")
            {
                if (textBox2.Text != "" || textBox2.Text != " ")
                {
                    String CS = @"Data Source=DESKTOP-1M2ITOM;Initial Catalog=LibraryManagement;Integrated Security=True";
                    SqlConnection con = new SqlConnection(CS);

                    SqlCommand cmd = new SqlCommand("select * from Student_Librarian where ID = @ID and Password = @Password and usertype = @usertype;", con);


                            //select * from Employee where Id like @Id and password like @password;", con);



                            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                            cmd.Parameters.AddWithValue("@usertype", comboBox1.SelectedItem);
                            try
                            {
                                con.Open();
                                SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            UserType = dr[8].ToString();
                            if(UserType == "Librarian")
                            {

                                Librarian_HomePage h = new Librarian_HomePage();
                                h.Show();
                                this.Hide();
                            }
                            else
                            {
                                Student_Home_Page a = new Student_Home_Page();
                                this.Hide();
                                a.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("User does Not Exit");
                        }
                        dr.Close();

                    }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                if (con.State == ConnectionState.Open)
                                    con.Close();
                            }
                    

                }
             }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            ChangePin obj1 = new ChangePin();
            obj1.Show();
            this.Hide();
        }
    }
}
