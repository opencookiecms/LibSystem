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
using Excel = Microsoft.Office.Interop.Excel;

namespace LibSystem
{
    public partial class AnalsisForm : Form
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=libsys; SslMode=none";
        public AnalsisForm()
        {
            InitializeComponent();
        }

        private void AnalsisForm_Load(object sender, EventArgs e)
        {
            DataShow();
            GraphBulan();
            GraphTahunan();
            GraphTingkatan();
        }

        public void DataShow()
        {
            string query = "SELECT users.usrKad as Kad_No, CONCAT_WS(' ',users.firstName, users.lastName) AS Name, users.usrForm as Form, users.usrKelas as Class, SUM(usrcount.usrCounts) as Rangking FROM users, usrcount WHERE users.usrKad=usrcount.userkadId AND YEAR (usrcount.countDate) = 2018  GROUP BY usrcount.userkadId ORDER BY Rangking DESC";

            // Prepare the connection
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridRangking.RowTemplate.Height = 60;
            DataGridRangking.AllowUserToAddRows = false;
            


            DataGridRangking.DataSource = table;
            DataGridRangking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmd.CommandTimeout = 60;
        }

        public void GraphBulan()
        {
            String Jan = "Null";
            String Feb = "Null";
            String Mac = "Null";
            String Apr = "Null";
            String Mei = "Null";
            String Jun = "Null";
            String Jul = "Null";
            String Ogs = "Null";
            String Sep = "Null";
            String Okt = "Null";
            String Nov = "Null";
            String Dis = "Null";

            string grapquery = "SELECT SUM( MONTH (usrcount.countDate)=1) as Januari, SUM( MONTH (usrcount.countDate)=2) as Febuari, SUM( MONTH (usrcount.countDate)=3) as Mac, SUM( MONTH (usrcount.countDate)=4) as April, SUM( MONTH (usrcount.countDate)=5) as Mei, SUM( MONTH (usrcount.countDate)=6) as Jun, SUM( MONTH (usrcount.countDate)=7) as July, SUM( MONTH (usrcount.countDate)=8) as August, SUM( MONTH (usrcount.countDate)=9) as September, SUM( MONTH (usrcount.countDate)=10) as Oktober, SUM( MONTH (usrcount.countDate)=11) as November, SUM( MONTH (usrcount.countDate)=12) as Disember FROM `usrcount` WHERE YEAR (usrcount.countDate) = 2018";

            MySqlConnection koon = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(grapquery, koon);
            command.CommandTimeout = 60;

            try
            {
                koon.Open();

                using (MySqlDataReader bacaGraph = command.ExecuteReader())
                {
                    while (bacaGraph.Read())
                    {
                        Jan = (bacaGraph["Januari"].ToString());
                        Feb = (bacaGraph["Febuari"].ToString());
                        Mac = (bacaGraph["Mac"].ToString());
                        Apr = (bacaGraph["April"].ToString());
                        Mei = (bacaGraph["Mei"].ToString());
                        Jun = (bacaGraph["Jun"].ToString());
                        Jul = (bacaGraph["July"].ToString());
                        Ogs = (bacaGraph["August"].ToString());
                        Sep = (bacaGraph["September"].ToString());
                        Okt = (bacaGraph["Oktober"].ToString());
                        Nov = (bacaGraph["November"].ToString());
                        Dis = (bacaGraph["Disember"].ToString());

                        //label2.Text = Jan;

                       
                        chart1.Series["Kedatangan"].Points.AddXY("Jan", Jan);
                        chart1.Series["Kedatangan"].Points.AddXY("Feb", Feb);
                        chart1.Series["Kedatangan"].Points.AddXY("Mac", Mac);
                        chart1.Series["Kedatangan"].Points.AddXY("Apr", Apr);
                        chart1.Series["Kedatangan"].Points.AddXY("Mei", Mei);
                        chart1.Series["Kedatangan"].Points.AddXY("Jun", Jun);
                        chart1.Series["Kedatangan"].Points.AddXY("Jul", Jul);
                        chart1.Series["Kedatangan"].Points.AddXY("Aug", Ogs);
                        chart1.Series["Kedatangan"].Points.AddXY("Sep", Sep);
                        chart1.Series["Kedatangan"].Points.AddXY("Okt", Okt);
                        chart1.Series["Kedatangan"].Points.AddXY("Nov", Nov);
                        chart1.Series["Kedatangan"].Points.AddXY("Dis", Dis);
                    
                        
                        chart1.Titles.Add("Analisis Bulanan");
                       

                       




                    }
                    koon.Close();

                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void GraphTahunan()
        {
            string grapquery = "SELECT YEAR(usrcount.countDate) as YEARS, sum(usrcount.usrCounts) as S FROM `usrcount` GROUP BY YEAR(usrcount.countDate)";

            DataSet ds = new DataSet();
            MySqlConnection koonw = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(grapquery, koonw);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(ds);
            chart2.DataSource = ds;
            command.CommandTimeout = 60;

            try
            {
                koonw.Open();

                using (MySqlDataReader bacaGraph = command.ExecuteReader())
                {
                    while (bacaGraph.Read())
                    {
                    
                       
                       

                        chart2.Series["Tahunan"].XValueMember = "YEARS";
                        chart2.Series["Tahunan"].YValueMembers = "S";
                        chart2.Series["Tahunan"].BorderWidth = 3;


                    }
                    koonw.Close();

                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void GraphTingkatan()
        {
            string grapquery = "SELECT users.usrForm as KELAS,SUM(usrcount.usrCounts) as Total FROM users, usrcount WHERE users.usrKad = usrcount.userkadId AND YEAR (usrcount.countDate) = 2018 GROUP BY KELAS";

            DataSet ds = new DataSet();
            MySqlConnection koonw = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(grapquery, koonw);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(ds);
            chart3.DataSource = ds;
            command.CommandTimeout = 60;

            try
            {
                koonw.Open();

                using (MySqlDataReader bacaGraph = command.ExecuteReader())
                {
                    while (bacaGraph.Read())
                    {


                        chart3.Series["Tingkatan"].XValueMember = "KELAS";
                        chart3.Series["Tingkatan"].YValueMembers = "Total";
                        chart3.Series["Tingkatan"].BorderWidth = 3;
                        chart3.Series["Tingkatan"].IsValueShownAsLabel = true;

                    }
                    koonw.Close();

                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Printing.PrintPreview();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart3.Printing.PrintPreview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart2.Printing.PrintPreview();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application ExelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook ExelWork = ExelApp.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet ExelWorksheet = null;
            ExelWorksheet = ExelWork.Sheets["sheet1"];
            ExelWorksheet = ExelWork.ActiveSheet;
            ExelWorksheet.Name = "Staff";

            for (int i = 1; i < DataGridRangking.Columns.Count + 1; i++)
            {
                ExelWorksheet.Cells[1, i] = DataGridRangking.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < DataGridRangking.Rows.Count; i++)
            {
                for (int j = 0; j < DataGridRangking.Columns.Count; j++)
                {
                    ExelWorksheet.Cells[i + 2, j + 1] = DataGridRangking.Rows[i].Cells[j].Value.ToString();
                }
            }

            var dialogSave = new SaveFileDialog();
            dialogSave.FileName = "output";
            dialogSave.DefaultExt = ".xlsx";
            if (dialogSave.ShowDialog() == DialogResult.OK)
            {
                ExelWork.SaveAs(dialogSave.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            ExelApp.Quit();

        }

        
    }
}
