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
    public partial class studenForm : Form
    {
        DataTable table = new DataTable();
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=libsys; SslMode=none";
        public studenForm()
        {
            InitializeComponent();
        }

 

        private void studenForm_Load(object sender, EventArgs e)
        {
            DataShow();
         
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        public void DataSeach()
        {
         
       
   
            string query = "SELECT `usrId` as id,`icno` as IC,`usrKad` as KadNo, `firstName` as FirstName,`lastName` as LastName,`usrdob` as DateOfBirth,`usrGender` as Gender,`usrForm` as Form,`usrKelas` as Class,`usrTahun` as Years ,`usrRegDate` as RegisterDate FROM `users` WHERE (usrKad = '" + textBox1.Text+ "') OR (usrTahun = '"+comboBox1.Text+"') OR (usrKelas = '"+comboBox2.Text+"')";

            // Prepare the connection
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            table = new DataTable();
            adapter.Fill(table);
            dataGridViewStudent.DataSource = table;
            dataGridViewStudent.RowTemplate.Height = 60;
            dataGridViewStudent.AllowUserToAddRows = false;

            dataGridViewStudent.DataSource = table;
            dataGridViewStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmd.CommandTimeout = 60;
            dataGridViewStudent.Columns["id"].HeaderText = "No ID";
            dataGridViewStudent.Columns["IC"].HeaderText = "No Kad Pengenalan";
            dataGridViewStudent.Columns["KadNo"].HeaderText = "No Kad";
            dataGridViewStudent.Columns["FirstName"].HeaderText = "Nama Mula";
            dataGridViewStudent.Columns["LastName"].HeaderText = "Nama Akhir";
            dataGridViewStudent.Columns["DateOfBirth"].HeaderText = "Tarikh Lahir";
            dataGridViewStudent.Columns["Gender"].HeaderText = "Jantina";
            dataGridViewStudent.Columns["Form"].HeaderText = "Tingkatan";
            dataGridViewStudent.Columns["Class"].HeaderText = "Kelas";
            dataGridViewStudent.Columns["Years"].HeaderText = "Tahun";
            dataGridViewStudent.Columns["RegisterDate"].HeaderText = "Tarikh Daftar";




        }

        public void DataShow()
        {

            string query = "SELECT `usrId` as id,`icno` as IC,`usrKad` as KadNo, `firstName` as FirstName,`lastName` as LastName,`usrdob` as DateOfBirth,`usrGender` as Gender,`usrForm` as Form,`usrKelas` as Class,`usrTahun` as Years ,`usrRegDate` as RegisterDate FROM `users`";

            // Prepare the connection
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            table = new DataTable();
            adapter.Fill(table);
            dataGridViewStudent.DataSource = table;
            dataGridViewStudent.RowTemplate.Height = 60;
            dataGridViewStudent.AllowUserToAddRows = false;

            dataGridViewStudent.DataSource = table;
            dataGridViewStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmd.CommandTimeout = 60;
            dataGridViewStudent.Columns["id"].HeaderText = "No ID";
            dataGridViewStudent.Columns["IC"].HeaderText = "No Kad Pengenalan";
            dataGridViewStudent.Columns["KadNo"].HeaderText = "No Kad";
            dataGridViewStudent.Columns["FirstName"].HeaderText = "Nama Mula";
            dataGridViewStudent.Columns["LastName"].HeaderText = "Nama Akhir";
            dataGridViewStudent.Columns["DateOfBirth"].HeaderText = "Tarikh Lahir";
            dataGridViewStudent.Columns["Gender"].HeaderText = "Jantina";
            dataGridViewStudent.Columns["Form"].HeaderText = "Tingkatan";
            dataGridViewStudent.Columns["Class"].HeaderText = "Kelas";
            dataGridViewStudent.Columns["Years"].HeaderText = "Tahun";
            dataGridViewStudent.Columns["RegisterDate"].HeaderText = "Tarikh Daftar";
        }


        private void dataGridViewStudent_Click(object sender, EventArgs e)
        {   
            lblid.Text = dataGridViewStudent.CurrentRow.Cells[0].Value.ToString();
            textkad.Text = dataGridViewStudent.CurrentRow.Cells[2].Value.ToString();
            textIcNo.Text = dataGridViewStudent.CurrentRow.Cells[1].Value.ToString();
            textFName.Text = dataGridViewStudent.CurrentRow.Cells[3].Value.ToString();
            textLname.Text = dataGridViewStudent.CurrentRow.Cells[4].Value.ToString();
            comboForm.Text = dataGridViewStudent.CurrentRow.Cells[7].Value.ToString();
            comboKelas.Text = dataGridViewStudent.CurrentRow.Cells[8].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridViewStudent.CurrentRow.Cells[5].Value.ToString());
            comboJantina.Text = dataGridViewStudent.CurrentRow.Cells[6].Value.ToString();
            textTahun.Text = dataGridViewStudent.CurrentRow.Cells[9].Value.ToString();
        }

        public void DataUpdate()
        {
            string query = ("UPDATE users SET icno=@sicNO, usrKad=@susrKad, firstName=@sFN, lastName=@sLN, usrdob=@sDob, usrGender=@sGender, usrForm=@sForm, usrKelas=@sKelas, usrTahun=@sThn   WHERE usrId=@sID");

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);



            cmd.Parameters.AddWithValue("@sID", lblid.Text);
            cmd.Parameters.AddWithValue("@sicNO", textIcNo.Text);
            cmd.Parameters.AddWithValue("@susrKad", textkad.Text);
            cmd.Parameters.AddWithValue("@sFN", textFName.Text);
            cmd.Parameters.AddWithValue("@sLN", textLname.Text);
            cmd.Parameters.AddWithValue("@sDob", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@sGender", comboJantina.Text);
            cmd.Parameters.AddWithValue("@sForm", comboForm.Text);
            cmd.Parameters.AddWithValue("@sKelas", comboKelas.Text);
            cmd.Parameters.AddWithValue("@sThn", textTahun.Text);

            try
            {
                conn.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();
                MessageBox.Show("User succesfully registered");
                conn.Close();
                DataShow();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataUpdate();
            dataGridViewStudent.Update();
            dataGridViewStudent.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        public void DeleteData()
        {
            String IdDelete = lblid.Text;
            string query = ("DELETE FROM `users` WHERE usrId=@sID");

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@sID", lblid.Text);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Deleteing Data Succesfull");

                conn.Close();
                DataShow();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
          
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSeach();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataShow();
            
        }
    }
}
