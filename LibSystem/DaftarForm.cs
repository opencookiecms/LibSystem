using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibSystem
{
    public partial class DaftarForm : Form
    {

        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=libsys; SslMode=none";

        public DaftarForm()
        {
            InitializeComponent();
        }

      
        private void DaftarForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            textkad.MaxLength = 5;
 
        }

        public void InsertData ()
        {

           
            string query = "insert into users(`icno`, `usrKad`, `firstName`, `lastName`, `usrdob`, `usrGender`, `usrForm`, `usrKelas`, `usrTahun`) values  ('" + textIcNo.Text + "', '" + textkad.Text + "', '" + textFName.Text + "', '" + textLname.Text + "', '" + dateTimePicker1.Text + "', '" + comboJantina.Text + "', '" + comboForm.Text + "', '" + comboKelas.Text + "', '" +textTahun.Text+ "') ";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("User succesfully registered");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textkad_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textkad.Text, "[^0-9]"))
            {
                MessageBox.Show("Hanya angka digit sahaja dibenarkan.");
                textkad.Text = textkad.Text.Remove(textkad.Text.Length - 1);
            }
        }
    }
}
