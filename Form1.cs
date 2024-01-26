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

namespace ConnectDatabaseC_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connecting sql server and database

            string ConnectionString = "Data Source=LAPTOP-JLE3IV2Q;Initial Catalog=MyDB;Integrated Security=True";

            //establish connection

            SqlConnection con = new SqlConnection(ConnectionString);

            //open connection

            con.Open();

            //prepare query

            string FirstName = tbFirstName.Text;
            string SecondName = tbSecondName.Text;

            string Query = "INSERT INTO Names (FirstName, SecondName) VALUES ('" + FirstName + "','" + SecondName + "')";

            //execute query

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            //close connection

            con.Close();

            MessageBox.Show("data has been saved!");
        }

        private void btShowData_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=LAPTOP-JLE3IV2Q;Initial Catalog=MyDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            string Query = "SELECT * FROM Names";


            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.ExecuteNonQuery();

            var reader = cmd.ExecuteReader();

            //2nd method is in 6:50
            while (reader.Read())

            { 
                dataGridView1.Rows.Add(reader["ID"], reader["FirstName"].ToString() + " " + reader["SecondName"].ToString());
            }
            con.Close();
        }
    }
}
