using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelDBCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True;");
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Insertbutton_Click(object sender, EventArgs e) //Create or Insert
        {
            string query = "insert into DemoHotel Values ('{idBox.Text.ToString()}','{nameBox.Text}','{addressBox.Text.ToString()}'.'{facilityBox.Text.ToString}')";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            cleardata();
            conn.Close();
            displaydata();
        }
        private void cleardata()
        {
            idBox.Clear();
            nameBox.Clear();
            addressBox.Clear();
            facilityBox.Clear();
        }

        private void updateButton_Click(object sender, EventArgs e) //Update data
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update DemoHotel set name='" + nameBox.Text + "', Address='" + addressBox.Text.ToString() + "', Facility='" + facilityBox.Text.ToString() + "' where Hotel_No='" + idBox.Text.ToString() + "' ";
            cmd.ExecuteNonQuery();
            conn.Close();
            displaydata();
            cleardata();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            displaydata();
        }
        private void displaydata() //Read and show all data
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from DemoHotel";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e) //Delete data
        {
            string query = "delete DemoHotel where Hotel_No='{idBox.Text.ToString()}'";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            dataGridView1.DataSource = query;
            cleardata();
            conn.Close();
            displaydata();
        }
    }
}
