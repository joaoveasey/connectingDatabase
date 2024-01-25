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

        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
