namespace Smart_FTY
{
    partial class DIGITAL_SHOP_FLOOR
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DIGITAL_SHOP_FLOOR));
            this.pnHeader = new System.Windows.Forms.Panel();
            this.cmdInv = new System.Windows.Forms.Button();
            this.cmdDef = new System.Windows.Forms.Button();
            this.cmdPMSche = new System.Windows.Forms.Button();
            this.cmdLayout = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnHeader.Controls.Add(this.cmdInv);
            this.pnHeader.Controls.Add(this.cmdDef);
            this.pnHeader.Controls.Add(this.cmdPMSche);
            this.pnHeader.Controls.Add(this.cmdLayout);
            this.pnHeader.Controls.Add(this.cmdBack);
            this.pnHeader.Controls.Add(this.lblDateTime);
            this.pnHeader.Controls.Add(this.lblTitle2);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1904, 100);
            this.pnHeader.TabIndex = 0;
            // 
            // cmdInv
            // 
            this.cmdInv.BackgroundImage = global::Smart_FTY.Properties.Resources.BtnMainG;
            this.cmdInv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdInv.FlatAppearance.BorderSize = 0;
            this.cmdInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdInv.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.cmdInv.ForeColor = System.Drawing.Color.Yellow;
            this.cmdInv.Location = new System.Drawing.Point(1452, 2);
            this.cmdInv.Name = "cmdInv";
            this.cmdInv.Size = new System.Drawing.Size(118, 98);
            this.cmdInv.TabIndex = 696;
            this.cmdInv.Text = "Inventory";
            this.cmdInv.UseVisualStyleBackColor = true;
            this.cmdInv.Click += new System.EventHandler(this.cmdInv_Click);
            // 
            // cmdDef
            // 
            this.cmdDef.BackgroundImage = global::Smart_FTY.Properties.Resources.BtnMainG;
            this.cmdDef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdDef.FlatAppearance.BorderSize = 0;
            this.cmdDef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDef.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.cmdDef.ForeColor = System.Drawing.Color.Yellow;
            this.cmdDef.Location = new System.Drawing.Point(1326, 3);
            this.cmdDef.Name = "cmdDef";
            this.cmdDef.Size = new System.Drawing.Size(118, 98);
            this.cmdDef.TabIndex = 695;
            this.cmdDef.Text = "Defective";
            this.cmdDef.UseVisualStyleBackColor = true;
            this.cmdDef.Click += new System.EventHandler(this.cmdDef_Click);
            // 
            // cmdPMSche
            // 
            this.cmdPMSche.BackgroundImage = global::Smart_FTY.Properties.Resources.BtnMainG;
            this.cmdPMSche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdPMSche.FlatAppearance.BorderSize = 0;
            this.cmdPMSche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPMSche.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.cmdPMSche.ForeColor = System.Drawing.Color.Yellow;
            this.cmdPMSche.Location = new System.Drawing.Point(1200, 1);
            this.cmdPMSche.Name = "cmdPMSche";
            this.cmdPMSche.Size = new System.Drawing.Size(118, 98);
            this.cmdPMSche.TabIndex = 694;
            this.cmdPMSche.Text = "PM\r\nSchedule";
            this.cmdPMSche.UseVisualStyleBackColor = true;
            this.cmdPMSche.Click += new System.EventHandler(this.cmdPMSche_Click);
            this.cmdPMSche.MouseLeave += new System.EventHandler(this.cmdPMSche_MouseLeave);
            // 
            // cmdLayout
            // 
            this.cmdLayout.BackgroundImage = global::Smart_FTY.Properties.Resources.BtnMainG;
            this.cmdLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdLayout.FlatAppearance.BorderSize = 0;
            this.cmdLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLayout.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.cmdLayout.ForeColor = System.Drawing.Color.Yellow;
            this.cmdLayout.Location = new System.Drawing.Point(1074, 1);
            this.cmdLayout.Name = "cmdLayout";
            this.cmdLayout.Size = new System.Drawing.Size(118, 98);
            this.cmdLayout.TabIndex = 693;
            this.cmdLayout.Text = "Machine\r\nLayout";
            this.cmdLayout.UseVisualStyleBackColor = true;
            this.cmdLayout.Click += new System.EventHandler(this.cmdLayout_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackgroundImage = global::Smart_FTY.Properties.Resources.website_home_button;
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdBack.Font = new System.Drawing.Font("Calibri", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Location = new System.Drawing.Point(955, -1);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(116, 102);
            this.cmdBack.TabIndex = 692;
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(1679, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(225, 100);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "20-10-2018\r\n00:00:00";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDateTime.DoubleClick += new System.EventHandler(this.lblDateTime_DoubleClick);
            // 
            // lblTitle2
            // 
            this.lblTitle2.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle2.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle2.ForeColor = System.Drawing.Color.White;
            this.lblTitle2.Location = new System.Drawing.Point(3, 0);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(1078, 100);
            this.lblTitle2.TabIndex = 0;
            this.lblTitle2.Text = " Digital Shop Floor For Phylon";
            this.lblTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle2.DoubleClick += new System.EventHandler(this.lblTitle2_DoubleClick);
            // 
            // tblMain
            // 
            this.tblMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tblMain.ColumnCount = 5;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 100);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.Size = new System.Drawing.Size(1904, 942);
            this.tblMain.TabIndex = 1;
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Smart_FTY.Properties.Resources.under_construction_2408061_960_7201;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(2724, 286);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(465, 379);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // DIGITAL_SHOP_FLOOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DIGITAL_SHOP_FLOOR";
            this.Text = "OutSole Digital Shop Floor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DIGITAL_SHOP_FLOOR_Load);
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Timer tmr;
        //private UCMainMenu uC_MENU_MAIN1;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button cmdInv;
        private System.Windows.Forms.Button cmdDef;
        private System.Windows.Forms.Button cmdPMSche;
        private System.Windows.Forms.Button cmdLayout;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

