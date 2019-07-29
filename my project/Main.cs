using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
           RoomReservation Reservation = new RoomReservation();
            Reservation.Show();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomCondition Conversion = new RoomCondition();
            Conversion.Show();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomReservation Conversion = new RoomReservation();
            Conversion.Show();
        }
    }
}
