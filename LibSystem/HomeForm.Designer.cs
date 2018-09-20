namespace LibSystem
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxScan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StudentName = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.punchStatus = new System.Windows.Forms.Label();
            this.ButIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDate = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.userKadNo = new System.Windows.Forms.Label();
            this.punchDate = new System.Windows.Forms.Label();
            this.userKadlabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.countLabel = new System.Windows.Forms.Label();
            this.userPunchDate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxScan
            // 
            this.textBoxScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxScan.Location = new System.Drawing.Point(97, 227);
            this.textBoxScan.Multiline = true;
            this.textBoxScan.Name = "textBoxScan";
            this.textBoxScan.Size = new System.Drawing.Size(305, 33);
            this.textBoxScan.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(152, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scan Your Identity Card";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.StudentName);
            this.panel1.Controls.Add(this.welcomeLabel);
            this.panel1.Controls.Add(this.punchStatus);
            this.panel1.Controls.Add(this.ButIn);
            this.panel1.Controls.Add(this.textBoxScan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(252, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 376);
            this.panel1.TabIndex = 5;
            // 
            // StudentName
            // 
            this.StudentName.AutoSize = true;
            this.StudentName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StudentName.Location = new System.Drawing.Point(184, 282);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(0, 22);
            this.StudentName.TabIndex = 7;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(93, 282);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(90, 22);
            this.welcomeLabel.TabIndex = 6;
            this.welcomeLabel.Text = "Welcome :";
            // 
            // punchStatus
            // 
            this.punchStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.punchStatus.AutoSize = true;
            this.punchStatus.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.punchStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.punchStatus.Location = new System.Drawing.Point(222, 331);
            this.punchStatus.Name = "punchStatus";
            this.punchStatus.Size = new System.Drawing.Size(100, 18);
            this.punchStatus.TabIndex = 9;
            this.punchStatus.Text = "Status Message";
            // 
            // ButIn
            // 
            this.ButIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButIn.Location = new System.Drawing.Point(408, 225);
            this.ButIn.Name = "ButIn";
            this.ButIn.Size = new System.Drawing.Size(75, 35);
            this.ButIn.TabIndex = 5;
            this.ButIn.Text = "IN";
            this.ButIn.UseVisualStyleBackColor = true;
            this.ButIn.Click += new System.EventHandler(this.ButIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::LibSystem.Properties.Resources.semua;
            this.pictureBox1.Location = new System.Drawing.Point(142, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Controls.Add(this.timeLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1021, 46);
            this.panel2.TabIndex = 6;
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelDate.Location = new System.Drawing.Point(825, 12);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(130, 22);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Sunday 12:00PM";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timeLabel.Location = new System.Drawing.Point(18, 12);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(130, 22);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Sunday 12:00PM";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // userKadNo
            // 
            this.userKadNo.AutoSize = true;
            this.userKadNo.Location = new System.Drawing.Point(18, 16);
            this.userKadNo.Name = "userKadNo";
            this.userKadNo.Size = new System.Drawing.Size(60, 13);
            this.userKadNo.TabIndex = 7;
            this.userKadNo.Text = "userKadNo";
            // 
            // punchDate
            // 
            this.punchDate.AutoSize = true;
            this.punchDate.Location = new System.Drawing.Point(11, 56);
            this.punchDate.Name = "punchDate";
            this.punchDate.Size = new System.Drawing.Size(60, 13);
            this.punchDate.TabIndex = 8;
            this.punchDate.Text = "punchDate";
            // 
            // userKadlabel
            // 
            this.userKadlabel.AutoSize = true;
            this.userKadlabel.Location = new System.Drawing.Point(11, 30);
            this.userKadlabel.Name = "userKadlabel";
            this.userKadlabel.Size = new System.Drawing.Size(67, 13);
            this.userKadlabel.TabIndex = 10;
            this.userKadlabel.Text = "userkadlabel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userKadNo);
            this.groupBox1.Location = new System.Drawing.Point(22, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "user";
            this.groupBox1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.countLabel);
            this.groupBox2.Controls.Add(this.userPunchDate);
            this.groupBox2.Controls.Add(this.userKadlabel);
            this.groupBox2.Controls.Add(this.punchDate);
            this.groupBox2.Location = new System.Drawing.Point(22, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(107, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "punch";
            this.groupBox2.Visible = false;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(11, 16);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(34, 13);
            this.countLabel.TabIndex = 13;
            this.countLabel.Text = "count";
            // 
            // userPunchDate
            // 
            this.userPunchDate.AutoSize = true;
            this.userPunchDate.Location = new System.Drawing.Point(11, 80);
            this.userPunchDate.Name = "userPunchDate";
            this.userPunchDate.Size = new System.Drawing.Size(81, 13);
            this.userPunchDate.TabIndex = 13;
            this.userPunchDate.Text = "userPunchDate";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1021, 679);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ButIn;
        private System.Windows.Forms.Label userKadNo;
        private System.Windows.Forms.Label punchDate;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label punchStatus;
        private System.Windows.Forms.Label userKadlabel;
        private System.Windows.Forms.Label StudentName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label userPunchDate;
        private System.Windows.Forms.Label countLabel;
    }
}