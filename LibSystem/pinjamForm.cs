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
    public partial class pinjamForm : Form
    {
        DataTable table = new DataTable();
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=libsys; SslMode=none";
        public pinjamForm()
        {
            InitializeComponent();
        }


        private void usrKadidsearchText_TextChanged(object sender, EventArgs e)
        {
           
            
        }

  
        private void pinjamForm_Load(object sender, EventArgs e)
        {

            textDenda.Text = "0.00";
            buttDelete.Visible = false;
            button4.Visible = false;
            label16.Visible = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            Searching();
           
        }

        public void InsertData()
        {


            string query = "insert into borrowbook(`usrKadId`, `FirstName`, `LastName`, `BTingkatan`, `BKelas`, `TajukBuku`, `NoPerolehan`, `TarikhPnjam`, `TarikhPulang`, `BStatus`, `Denda`, `Disahkan`) values  ('" + usrKadtext.Text + "', '" + textFirstName.Text + "', '" + textLastName.Text + "', '" + textTingkatan.Text + "', '" +textKelas.Text + "', '" + textTBuku.Text + "', '" + textPerolehan.Text + "', '" + dateTimePicker1.Text + "' , '" + dateTimePicker2.Text + "', '" + comboStatus.Text + "', '" + textDenda.Text + "', '" + textSah.Text + "') ";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Pinjam Buku Selesai");
               

                databaseConnection.Close();
                DataShow();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
              
            }
        }

        public void Searching()
        {

          
            
            String userIcKadSearch = usrKadidsearchText.Text;

            string query = "SELECT * FROM `users` WHERE usrKad='" + userIcKadSearch + "'";


            // Prepare the connection

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = 60;

            try
            {
                conn.Open();

                using (MySqlDataReader baca = cmd.ExecuteReader())
                {
                    while (baca.Read())
                    {
                        usrKadtext.Text = (baca["usrKad"].ToString());
                        textFirstName.Text = (baca["firstName"].ToString());
                        textLastName.Text = (baca["lastName"].ToString());
                        textTingkatan.Text = (baca["usrForm"].ToString());
                        textKelas.Text = (baca["usrKelas"].ToString());






                    }
                }

                if (usrKadtext.Text != usrKadidsearchText.Text )
                {

                    label14.Text = "Student not exist Please Register First";
                    dataGridView1.DataSource = null;
                   

                }
                else
                {
                    label14.Text = "Student are eligible to borrow book";
                    DataShow();
                    
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
             
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Searching();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usrKadtext.Text.Trim().Length == 0)
            {
                MessageBox.Show("No Tidak Dimasukkan atau tidak bedaftar");

            }
            else
            {
                if (textBox1.Text == "")
                {
                    InsertData();
                    textTBuku.Clear();
                    textPerolehan.Clear();

                    textDenda.Clear();
                    textSah.Clear();

                }
                else
                {

                    DataUpdate();
                    
                }
                    
            }
            


       
           
            
        }

        public void DataShow()
        {

            //String userKAD = usrKadidsearchText.Text;
            string querys = "SELECT * FROM `borrowbook` WHERE borrowbook.usrKadId='"+usrKadtext.Text+ "'";
            // Prepare the connection
            MySqlConnection conns = new MySqlConnection(connectionString);
            MySqlCommand cmds = new MySqlCommand(querys, conns);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmds);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.RowTemplate.Height = 60;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmds.CommandTimeout = 60;
            dataGridView1.Columns["borrowId"].HeaderText = "No ID";
            dataGridView1.Columns["usrKadId"].HeaderText = "No Ahli/Kad";
            dataGridView1.Columns["FirstName"].HeaderText = "Nama Mula";
            dataGridView1.Columns["LastName"].HeaderText = "Nama Akhir";
            dataGridView1.Columns["BTingkatan"].HeaderText = "Tingkatan";
            dataGridView1.Columns["BKelas"].HeaderText = "Kelas";
            dataGridView1.Columns["TajukBuku"].HeaderText = "Tajuk Buku";
            dataGridView1.Columns["NoPerolehan"].HeaderText = "No Perolehan";
            dataGridView1.Columns["TarikhPnjam"].HeaderText = "T/Pinjam";
            dataGridView1.Columns["TarikhPulang"].HeaderText = "T/Pulang";
            dataGridView1.Columns["BStatus"].HeaderText = "Status Pinjaman";
            dataGridView1.Columns["Denda"].HeaderText = "Denda";
            dataGridView1.Columns["Disahkan"].HeaderText = "DiSahkan";

        }


        public void DataUpdate()
        {
            string query = ("UPDATE borrowbook SET usrKadId=@bKad, FirstName=@bFN, LastName=@bLN, BTingkatan=@bT, BKelas=@bK, TajukBuku=@bTB, NoPerolehan=@bNP, TarikhPnjam=@bPJ, TarikhPulang=@bP, BStatus=@bSt, Denda=@bd, Disahkan=@bSah   WHERE borrowId=@sID");

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);



            cmd.Parameters.AddWithValue("@sID", label15.Text);
            cmd.Parameters.AddWithValue("@bKad", usrKadtext.Text);
            cmd.Parameters.AddWithValue("@bFN", textFirstName.Text);
            cmd.Parameters.AddWithValue("@bLN", textLastName.Text);
            cmd.Parameters.AddWithValue("@bT", textTingkatan.Text);
            cmd.Parameters.AddWithValue("@bK", textKelas.Text);
            cmd.Parameters.AddWithValue("@bTB", textTBuku.Text);
            cmd.Parameters.AddWithValue("@bNP", textPerolehan.Text);
            cmd.Parameters.AddWithValue("@bPJ", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@bP", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@bSt", comboStatus.Text);
            cmd.Parameters.AddWithValue("@bd", textDenda.Text);
            cmd.Parameters.AddWithValue("@bSah", textSah.Text);



            try
            {
                conn.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();
                MessageBox.Show("User succesfully Update");
                
                conn.Close();
                DataShow();
                textBox1.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label15.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            usrKadtext.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textFirstName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textLastName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textTingkatan.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textKelas.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textTBuku.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textPerolehan.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value.ToString());
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[9].Value.ToString());
            comboStatus.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textDenda.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textSah.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

           
            button4.Visible = true;
            label16.Visible = true;
            buttDelete.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataUpdate();
        }

        private void textDenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && textDenda.Text.IndexOf('1') != -1)
            {
                e.Handled = true;
                return;
            }

            if(!Char.IsDigit(ch) && ch != 8 && ch !=46)
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            textTBuku.Clear();
            textPerolehan.Clear();

            textDenda.Clear();
            textSah.Clear();
        }

        private void buttDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        public void DeleteData()
        {
            String IdDelete = label5.Text;
            string query = ("DELETE FROM `borrowbook` WHERE borrowId=@sID");

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@sID", label15.Text);
         

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

        private void butAlldata_Click(object sender, EventArgs e)
        {
            SenaraiPeminjam formsenarai = new SenaraiPeminjam();
            formsenarai.Show();
        }

       
    }
}
