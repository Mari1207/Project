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

namespace my_project
{  //username: mari  /  password: 123
    public partial class Login : Form
    {
        string connectionString = @"Data Source=it2;Initial Catalog=mari2;User ID=mari;Password=mari";
        public Login()
        {
            InitializeComponent();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SqlConnection myconnection = new SqlConnection();

            myconnection.ConnectionString = connectionString;
            try
            {
                
                myconnection.Open();
                
                SqlCommand myCommand = new SqlCommand();
                myCommand.CommandText = string.Format("SELECT * FROM  Login WHERE UserId ='{0}' AND Password='{1}'",
                txtUserName.Text.Trim().Replace("\"", "").Replace(";", ""),
                txtPassword.Text.Trim().Replace("\"", "").Replace(";", "")
                );
                myCommand.Connection = myconnection;
                SqlDataReader myDataReader = myCommand.ExecuteReader();
               

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                if (myconnection.State == ConnectionState.Open)
                {
                    myconnection.Close();
                }
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 Main = new Form1();
            Main.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
         
        }
      }
}
