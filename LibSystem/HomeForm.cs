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
using LibSystem.Properties;
using System.Xml;

namespace LibSystem
{
    public partial class HomeForm : Form
    {
        public DateTime TrialTime;
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=libsys; SslMode=none";

        public HomeForm()
        {
            InitializeComponent();
        }

       

        private void HomeForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            button3.Visible = false;
    
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
       

            if (this.WindowState == FormWindowState.Normal)
            {
                button1.Visible = true;
                button8.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        

            if (this.WindowState == FormWindowState.Maximized)
            {
                button1.Visible = false;
                button8.Visible = true;
            }
        }

        private void buttClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            Form1 j = new Form1();
            j.Show();
            



        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null && textBox1.Text.Length > 3)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("libresource.xml");

                foreach(XmlNode node in doc.DocumentElement)
                {
                    string name = node.Attributes[0].InnerText;

                    if(name == textBox1.Text)
                    {
                        MessageBox.Show("Welcome to the system");
                        TrialTime = DateTime.Now;

                        if (!Settings.Default.Tanda)
                        {
                            Settings.Default.TrialTime = TrialTime;
                            Settings.Default.Tanda = true;
                            Settings.Default.Save();
                            MessageBox.Show("Welcome to the  system, This is first run application");
                  
                        }
                        else
                        {
                            if (Settings.Default.TrialTime.Add(new TimeSpan(2000, 0, 0, 0)) > DateTime.Now)
                            {
                                //MessageBox.Show("This is trial version");

                                label2.Visible = false;
                                textBox1.Visible = false;
                                button4.Visible = false;
                                button3.Visible = true;

                            }
                            else
                            {
                                MessageBox.Show("this product has expired, Please contact the administrator to active this application, Thank You");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kata laluan id salah sila cuba lagi");
                        textBox1.Text = string.Empty;
                        textBox1.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Kata laluan id salah sila cuba lagi");
                textBox1.Text = string.Empty;
                textBox1.Focus();
            }
        }
    }
}
