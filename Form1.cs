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

        private void btSave_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=LAPTOP-JLE3IV2Q;Initial Catalog=MyDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            string FirstName = tbFirstName.Text;
            string SecondName = tbSecondName.Text;
            string Phone = tbPhone.Text;
            string CEP = tbCep.Text;
            string Email = tbEmail.Text;
            string CpfCnpj = tbCpfCnpj.Text;
            DateTime dateTime = DateTime.Now;

            string Query = "INSERT INTO Pessoa (FirstName, SecondName, Phone, CEP, Email, [CPF/CNPJ], DataHora) VALUES " +
                " (' " + FirstName + "', '" + SecondName + "','" + Phone + "', '" + CEP + "', '" + Email + "', '" + CpfCnpj + "', '" + dateTime +"')";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data has been saved!");
        }

        private void btShowData_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=LAPTOP-JLE3IV2Q;Initial Catalog=MyDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            dataGridView1.Rows.Clear();

            string Query = "SELECT * FROM Pessoa";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.ExecuteNonQuery();

            var reader = cmd.ExecuteReader();

            while (reader.Read())

            {
                dataGridView1.Rows.Add(
                    reader["ID"], reader["FirstName"] + " " + reader["SecondName"], reader["Phone"], reader["CEP"], 
                    reader["Email"], reader["CPF/CNPJ"], reader["DataHora"]);
            }
            con.Close();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=LAPTOP-JLE3IV2Q;Initial Catalog=MyDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string NameID = tbID.Text;
            string FirstName = tbFirstName.Text;
            string SecondName = tbSecondName.Text;
            string Phone = tbPhone.Text;
            string CEP = tbCep.Text;
            string Email = tbEmail.Text;
            string CpfCnpj = tbCpfCnpj.Text;

            string Query = "UPDATE Pessoa " +
                            "SET FirstName = '"+FirstName+"', SecondName = '"+SecondName+"', Phone = '" +Phone+"' , CEP = '"+CEP+ "', Email = '"+Email+"', [CPF/CNPJ] = '" +CpfCnpj+ "' " +
                            "WHERE ID = "+ NameID;

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data has been updated !");

            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbID.Text = "";
            tbPhone.Text = "";
            tbCep.Text = "";
            tbEmail.Text = "";
            tbCpfCnpj.Text = "";
        }

        private void btSearch_Click(object sender, EventArgs e)
        {

            string ConnectionString = "Data Source=LAPTOP-JLE3IV2Q;Initial Catalog=MyDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            string NameID = tbID.Text;

            string Query = "SELECT * FROM Pessoa WHERE ID = "+ NameID;

            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                tbFirstName.Text = reader["FirstName"].ToString();
                tbSecondName.Text = reader["SecondName"].ToString();
                tbPhone.Text = reader["Email"].ToString();
                tbCep.Text = reader["Cep"].ToString();
                tbEmail.Text = reader["Email"].ToString();
                tbCpfCnpj.Text = reader["CPF/CNPJ"].ToString();
            }
            else
                MessageBox.Show("No records found");

            con.Close();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this record?" , "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ConnectionString = "Data Source=LAPTOP-JLE3IV2Q;Initial Catalog=MyDB;Integrated Security=True";

                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                string NameID = tbID.Text;

                string Query = "DELETE FROM Pessoa WHERE ID = " + NameID;

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Data has been deleted!");

                tbFirstName.Text = "";
                tbSecondName.Text = "";
                tbID.Text = "";
                tbPhone.Text = "";
                tbCep.Text = "";
                tbEmail.Text = "";
                tbCpfCnpj.Text = ""; ;

                btShowData_Click(null, null);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
