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
    public partial class HomeForm : Form
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=libsys; SslMode=none";

        public HomeForm()
        {
            InitializeComponent();
        }

       

        private void HomeForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
            labelDate.Text = DateTime.Now.ToLongDateString();
            punchDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            countLabel.Text = "1";
        }

        private void ButIn_Click(object sender, EventArgs e)
        {
            GetData();
       
        }

        public void GetData()
        {
            String userIcNumber = textBoxScan.Text;
            String userKad = "NULL";
            String userFname = "NULL";

            string query = "SELECT * FROM `users` WHERE usrKad='"+userIcNumber+"'";

            // Prepare the connection
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = 60;

            try
            {
                conn.Open();

                using (MySqlDataReader baca = cmd.ExecuteReader() )
                {
                    while (baca.Read())
                    {
                        userKad = (baca["usrKad"].ToString());
                        userFname = (baca["firstName"].ToString());

                        userKadNo.Text = userKad;
                        StudentName.Text = userFname;

                        
                    }
                }

                if (userKadNo.Text!=textBoxScan.Text)
                {
                    
                    StudentName.Text = "Student not exist Please Register First";
                    punchStatus.Text = "No student found";
                }
                else
                {
                    GetDataPunch();
                }
             
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
        }

        public void GetDataPunch()
        {
      
            String userPunchKad = "NULL";
            String StudentIN = "NULL";
            
        
            string query = "SELECT * FROM `usrcount` WHERE userkadId='"+textBoxScan.Text+"' AND countDate='"+punchDate.Text+"'";

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
                        userPunchKad = (baca["userkadId"].ToString());
                        StudentIN = (baca["countDate"].ToString());

                        userKadlabel.Text = userPunchKad;
                        userPunchDate.Text = Convert.ToDateTime(baca["countDate"]).ToString("yyyy-MM-dd");
                    }

                    
                }
                if ((userKadlabel.Text==textBoxScan.Text) && (userPunchDate.Text==punchDate.Text))
                {
                    punchStatus.Text = "already punch";
                }
                else
                {
                    Punch();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Punch()
        {


            string query = "insert into usrcount(`userkadId`, `usrCounts`, `countDate`) values  ('" +userKadNo.Text + "','"+countLabel.Text+"','" + punchDate.Text +"') ";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                punchStatus.Text = "Successful Punch Welcome to Library";

                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
