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
{
    public partial class RoomReservation : Form
    {
        string connectionString = @"Data Source=it2;Initial Catalog=mari2;User ID=mari;Password=mari";
        public object BoxRoom { get; private set; }

        public RoomReservation()
        {
            InitializeComponent();

            GetContacts();
        }

        private void BoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxRoom.Items.Add("Room A");
            boxRoom.Items.Add("Room B");
        }

        private void ComboP_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboP.Items.Add("1");
            comboP.Items.Add("2");
            comboP.Items.Add("3");
            comboP.Items.Add("4");
            comboP.Items.Add("5");

        }

        private void BtnReserve_Click(object sender, EventArgs e)
        {
            txtID.Text = txtID.Text.Trim().Replace(";", "");
            txtFirstName.Text = txtFirstName.Text.Trim().Replace(";", "");
            txtLastName.Text = txtLastName.Text.Trim().Replace(";", "");
            txtAddress.Text = txtAddress.Text.Trim().Replace(";", "");
            txtCountry.Text = txtCountry.Text.Trim().Replace(";", "");
            txtPostCode.Text = txtPostCode.Text.Trim().Replace(";", "");
            txtPostCode.Text = txtPhoneNumber.Text.Trim().Replace(";", "");
            comboP.Text = comboP.Text.Trim().Replace(";", "");
            boxRoom.Text = boxRoom.Text.Trim().Replace(";", "");
            PickerCheckIn.Text = PickerCheckIn.Text.Trim().Replace(";", "");
            PickerCheckOut.Text = PickerCheckOut.Text.Trim().Replace(";", "");
            //CustomerInfo
            //if (txtID.Text == string.Empty)
            //{
             //   MessageBox.Show("Please enter ID number");
             //   return;
           // }
            if (txtFirstName.Text == string.Empty)
            {
                MessageBox.Show("Please enter a first name");
                return;
            }
            if (txtLastName.Text == string.Empty)
            {
                MessageBox.Show("Please enter a last name");
                return;
            }
            if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show("Please enter an address");
                return;
            }
            if (txtCountry.Text == string.Empty)
            {
                MessageBox.Show("Please enter a country");
                return;
            }
            if (txtPostCode.Text == string.Empty)
            {
                MessageBox.Show("Please enter a postcode");
                return;
            }
            if (txtPhoneNumber.Text == string.Empty)
            {
                MessageBox.Show("Please enter a phone number");
                return;
            }

            //room
            if (comboP.Text == string.Empty)
            {
                MessageBox.Show("Please choose a number of people");
                return;
            }
            if (boxRoom.Text == string.Empty)
            {
                MessageBox.Show("Please choose a room");
                return;
            }
            if (PickerCheckIn.Text == string.Empty)
            {
                MessageBox.Show("Please choose a Check In date");
                return;
            }
            if (PickerCheckOut.Text == string.Empty)
            {
                MessageBox.Show("Please choose a Check Out date");
                return;
            }
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;
            try
            {
                myConnection.Open();
                string query = "INSERT INTO dbo.Reservation VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";
                query = String.Format(query,
                    txtID.Text,
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtAddress.Text,
                    txtCountry.Text,
                    txtPostCode.Text,
                    txtPhoneNumber.Text,
                    comboP.Text,
                    boxRoom.Text,
                    PickerCheckIn.Text,
                    PickerCheckOut.Text
                    );
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }

            txtID.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPostCode.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            comboP.Text = string.Empty;
            boxRoom.Text = string.Empty;
            PickerCheckIn.Text = string.Empty;
            PickerCheckOut.Text = string.Empty;
            MessageBox.Show("Record updated successfully");




        }
        private void GetContacts()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;
            try
            {
                myConnection.Open();
                string query = "SELECT * FROM  dbo.Reservation ORDER BY CheckInDate";
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = query;
                DataTable myContacts = new DataTable();



                myContacts.Columns.Add(new DataColumn("ID"));
                myContacts.Columns.Add(new DataColumn("FirstName"));
                myContacts.Columns.Add(new DataColumn("LastName"));
                myContacts.Columns.Add(new DataColumn("Address"));
                myContacts.Columns.Add(new DataColumn("Country"));
                myContacts.Columns.Add(new DataColumn("PostCode"));
                myContacts.Columns.Add(new DataColumn("PhoneNumber"));
                myContacts.Columns.Add(new DataColumn("People"));
                myContacts.Columns.Add(new DataColumn("Room"));
                myContacts.Columns.Add(new DataColumn("CheckInDate"));
                myContacts.Columns.Add(new DataColumn("CheckOutDate"));

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    DataRow contact = myContacts.NewRow();


                    contact["ID"] = myReader["ID"];
                    contact["FirstName"] = myReader["FirstName"];
                    contact["LastName"] = myReader["LastName"];
                    contact["Address"] = myReader["Address"];
                    contact["Country"] = myReader["Country"];
                    contact["PostCode"] = myReader["PostCode"];
                    contact["PhoneNumber"] = myReader["Phonenumber"];
                    contact["People"] = myReader["People"];
                    contact["Room"] = myReader["Room"];
                    contact["CheckInDate"] = myReader["CheckInDate"];
                    contact["CheckOutDate"] = myReader["CheckOutDate"];
                    myContacts.Rows.Add(contact);
                }
                dataGridView1.DataSource = myContacts;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }

        }


        private void PickerCheckOut_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.Add(txtID.Text,
                  txtFirstName.Text,
                    txtLastName.Text,
                    txtAddress.Text,
                    txtCountry.Text,
                    txtPostCode.Text,
                    txtPhoneNumber.Text, comboP.Text, boxRoom.Text, PickerCheckIn.Text, PickerCheckOut.Text);

        }
        //UPDATE
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
           
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
        //DELETE
        private void BtnDelete_Click(object sender, EventArgs e)
        {
          
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
              dataGridView1.Rows.RemoveAt(item.Index);

            }
        }

        private void PickerCheckIn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void RoomReservation_Load(object sender, EventArgs e)
        {

        }
    }
}
