using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using LibSystem.Properties;

namespace LibSystem
{
    public partial class Form1 : Form
    {
        public DateTime TrialTime;
        public const int num = 10;
        bool Dragform = false; // Windows Drag declaration
        Point start_point = new Point(0, 0); //mouse point to drag
        private Form LoadForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            LoadForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            if ((this.WindowState == FormWindowState.Maximized) && (LoadForm.WindowState == FormWindowState.Maximized))
            {
                button1.Visible = false;
                button8.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            LoadForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            LoadForm = new DaftarForm();
           LoadForm.TopLevel = false;
           button8.Visible = false;
            this.panel3.Controls.Add(LoadForm);
           LoadForm.Show();
           if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
           {
               LoadForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
           }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            LoadForm.Dispose();
            LoadForm = new UT();
            LoadForm.TopLevel = false;

            this.panel3.Controls.Add(LoadForm);
            //LoadForm.Dock = DockStyle.Fill;
            LoadForm.Show();

            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                LoadForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            LoadForm.Dispose();
            LoadForm = new AnalsisForm();
            LoadForm.TopLevel = false;

            this.panel3.Controls.Add(LoadForm);
            //LoadForm.Dock = DockStyle.Fill;
            LoadForm.Show();

            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                LoadForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
        }

        private void HomeBut_Click(object sender, EventArgs e)
        {
            LoadForm.Dispose();
            LoadForm = new DaftarForm();
            LoadForm.TopLevel = false;

            this.panel3.Controls.Add(LoadForm);
           LoadForm.Show();

           if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                LoadForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
           }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Dragform = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragform)//draggable
            {
                Point p = PointToScreen(e.Location);//draggable
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);//draggable
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragform = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //TrialTime = DateTime.Now;

            //if (!Settings.Default.Tanda)
            //    {
            //        Settings.Default.TrialTime = TrialTime;
            //        Settings.Default.Tanda = true;
            //        Settings.Default.Save();
            //        MessageBox.Show("Welcome to the Attandance system, This is first run application");
            //     }
            //else
            //{
            //     if (Settings.Default.TrialTime.Add(new TimeSpan(1095, 0, 0, 0)) > DateTime.Now)
            // {
            //        //MessageBox.Show("P");
            //        LoadForm.Dispose();
            //        LoadForm = new DaftarForm();
            //        LoadForm.TopLevel = false;

            //        this.panel3.Controls.Add(LoadForm);
            //        //LoadForm.Dock = DockStyle.Fill;
            //        LoadForm.Show();

            //        if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            //        {
            //            LoadForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //        }
            //    }
            //else
            //    {
            //         MessageBox.Show("This Program version has expired, Please contact the administrator to active this application, Thank You");
            //    }
            //}
      

        }

        private void button4_Click(object sender, EventArgs e)
        {

            LoadForm.Dispose();
            LoadForm = new pinjamForm();
            LoadForm.TopLevel = false;

            this.panel3.Controls.Add(LoadForm);
            //LoadForm.Dock = DockStyle.Fill;
            LoadForm.Show();

            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                LoadForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadForm.Dispose();
            LoadForm = new studenForm();
            LoadForm.TopLevel = false;

            this.panel3.Controls.Add(LoadForm);
            //LoadForm.Dock = DockStyle.Fill;
            LoadForm.Show();

            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                LoadForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttClose_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            LoadForm.WindowState = System.Windows.Forms.FormWindowState.Normal;

            if ((this.WindowState == FormWindowState.Normal) && (LoadForm.WindowState == FormWindowState.Normal))
            {
                button1.Visible = true;
                button8.Visible = false;
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
