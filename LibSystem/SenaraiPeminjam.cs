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
    public partial class SenaraiPeminjam : Form
    {
        DataTable table = new DataTable();
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=libsys; SslMode=none";
        public SenaraiPeminjam()
        {
            InitializeComponent();
        }

        private void SenaraiPeminjam_Load(object sender, EventArgs e)
        {
            DataShow("");
        }

        public void DataShow(string toSearch)
        {

            //String userKAD = usrKadidsearchText.Text;
            string querys = "SELECT * FROM `borrowbook` WHERE CONCAT(`usrKadId`, `FirstName`, `LastName`,`TajukBuku`,`NoPerolehan`) like '%" + toSearch + "%'";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string toSearch = textBox1.Text.ToString();
            DataShow(toSearch);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application ExelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook ExelWork = ExelApp.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet ExelWorksheet = null;
            ExelWorksheet = ExelWork.Sheets["sheet1"];
            ExelWorksheet = ExelWork.ActiveSheet;
            ExelWorksheet.Name = "Staff";

            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                ExelWorksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    ExelWorksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
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
