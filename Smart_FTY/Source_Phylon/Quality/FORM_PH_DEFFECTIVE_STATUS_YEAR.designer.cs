﻿namespace Smart_FTY
{
    partial class FORM_PH_DEFFECTIVE_STATUS_YEAR
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_PH_DEFFECTIVE_STATUS_YEAR));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdMonth = new DevExpress.XtraEditors.SimpleButton();
            this.cmdYear = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new ChartDirector.WinChartViewer();
            this.chart2 = new ChartDirector.WinChartViewer();
            this.chart3 = new ChartDirector.WinChartViewer();
            this.ucYear = new Smart_FTY.UC_YEAR_SELECTION();
            this.axfpSpread = new AxFPSpreadADO.AxfpSpread();
            this.axfDailyReport_Header = new AxFPSpreadADO.AxfpSpread();
            this.pnlCMP = new Smart_FTY.A1Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlPHP = new Smart_FTY.A1Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfDailyReport_Header)).BeginInit();
            this.pnlCMP.SuspendLayout();
            this.pnlPHP.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Turquoise;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.cmdMonth);
            this.panel1.Controls.Add(this.cmdYear);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 109);
            this.panel1.MinimumSize = new System.Drawing.Size(1920, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 109);
            this.panel1.TabIndex = 0;
            // 
            // cmdMonth
            // 
            this.cmdMonth.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdMonth.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdMonth.Appearance.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.cmdMonth.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.cmdMonth.Appearance.Options.UseBackColor = true;
            this.cmdMonth.Appearance.Options.UseFont = true;
            this.cmdMonth.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.cmdMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdMonth.ImageOptions.Image")));
            this.cmdMonth.Location = new System.Drawing.Point(1512, 4);
            this.cmdMonth.Name = "cmdMonth";
            this.cmdMonth.Size = new System.Drawing.Size(175, 48);
            this.cmdMonth.TabIndex = 66;
            this.cmdMonth.Text = "Day";
            this.cmdMonth.Click += new System.EventHandler(this.cmdMonth_Click);
            // 
            // cmdYear
            // 
            this.cmdYear.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdYear.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdYear.Appearance.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdYear.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.cmdYear.Appearance.Options.UseBackColor = true;
            this.cmdYear.Appearance.Options.UseFont = true;
            this.cmdYear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.cmdYear.Enabled = false;
            this.cmdYear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdYear.ImageOptions.Image")));
            this.cmdYear.Location = new System.Drawing.Point(1512, 55);
            this.cmdYear.Name = "cmdYear";
            this.cmdYear.Size = new System.Drawing.Size(175, 48);
            this.cmdYear.TabIndex = 67;
            this.cmdYear.Text = "Month";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.BackgroundImage = global::Smart_FTY.Properties.Resources.Back_Icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1314, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 101);
            this.button1.TabIndex = 52;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Turquoise;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDate.Location = new System.Drawing.Point(1661, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(254, 109);
            this.lblDate.TabIndex = 46;
            this.lblDate.Text = "lblDate";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Turquoise;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Calibri", 45.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1920, 103);
            this.label1.TabIndex = 0;
            this.label1.Text = "Defective Status by Process && Reason by Month";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.Location = new System.Drawing.Point(1221, 160);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(683, 285);
            this.chart1.TabIndex = 64;
            this.chart1.TabStop = false;
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart2.Location = new System.Drawing.Point(1221, 446);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(683, 304);
            this.chart2.TabIndex = 65;
            this.chart2.TabStop = false;
            // 
            // chart3
            // 
            this.chart3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart3.Location = new System.Drawing.Point(1221, 756);
            this.chart3.Name = "chart3";
            this.chart3.Size = new System.Drawing.Size(683, 292);
            this.chart3.TabIndex = 66;
            this.chart3.TabStop = false;
            // 
            // ucYear
            // 
            this.ucYear.AutoSize = true;
            this.ucYear.Location = new System.Drawing.Point(318, 113);
            this.ucYear.Name = "ucYear";
            this.ucYear.Size = new System.Drawing.Size(231, 40);
            this.ucYear.TabIndex = 0;
            this.ucYear.ValueChangeEvent += new System.EventHandler(this.ucYear_ValueChangeEvent);
            // 
            // axfpSpread
            // 
            this.axfpSpread.DataSource = null;
            this.axfpSpread.Location = new System.Drawing.Point(0, 160);
            this.axfpSpread.Name = "axfpSpread";
            this.axfpSpread.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread.OcxState")));
            this.axfpSpread.Size = new System.Drawing.Size(1207, 888);
            this.axfpSpread.TabIndex = 63;
            // 
            // axfDailyReport_Header
            // 
            this.axfDailyReport_Header.DataSource = null;
            this.axfDailyReport_Header.Location = new System.Drawing.Point(8, 162);
            this.axfDailyReport_Header.Name = "axfDailyReport_Header";
            this.axfDailyReport_Header.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfDailyReport_Header.OcxState")));
            this.axfDailyReport_Header.Size = new System.Drawing.Size(1912, 92);
            this.axfDailyReport_Header.TabIndex = 61;
            // 
            // pnlCMP
            // 
            this.pnlCMP.AccessibleDescription = "";
            this.pnlCMP.AccessibleName = "";
            this.pnlCMP.BorderColor = System.Drawing.Color.Empty;
            this.pnlCMP.BorderWidth = 2;
            this.pnlCMP.Controls.Add(this.label3);
            this.pnlCMP.GradientEndColor = System.Drawing.Color.Gray;
            this.pnlCMP.GradientStartColor = System.Drawing.Color.White;
            this.pnlCMP.Image = null;
            this.pnlCMP.ImageLocation = new System.Drawing.Point(4, 4);
            this.pnlCMP.Location = new System.Drawing.Point(0, 111);
            this.pnlCMP.Name = "pnlCMP";
            this.pnlCMP.RoundCornerRadius = 20;
            this.pnlCMP.ShadowOffSet = 3;
            this.pnlCMP.Size = new System.Drawing.Size(153, 49);
            this.pnlCMP.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 49);
            this.label3.TabIndex = 0;
            this.label3.Text = "CMP";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pnlPHP
            // 
            this.pnlPHP.AccessibleDescription = "";
            this.pnlPHP.AccessibleName = "";
            this.pnlPHP.BorderColor = System.Drawing.Color.Empty;
            this.pnlPHP.BorderWidth = 2;
            this.pnlPHP.Controls.Add(this.label2);
            this.pnlPHP.GradientEndColor = System.Drawing.Color.White;
            this.pnlPHP.GradientStartColor = System.Drawing.Color.White;
            this.pnlPHP.Image = null;
            this.pnlPHP.ImageLocation = new System.Drawing.Point(4, 4);
            this.pnlPHP.Location = new System.Drawing.Point(153, 111);
            this.pnlPHP.Name = "pnlPHP";
            this.pnlPHP.RoundCornerRadius = 20;
            this.pnlPHP.ShadowOffSet = 3;
            this.pnlPHP.Size = new System.Drawing.Size(153, 49);
            this.pnlPHP.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "PHYLON";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.lblEVA_Click);
            // 
            // FORM_PH_DEFFECTIVE_STATUS_YEAR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1916, 1054);
            this.Controls.Add(this.pnlCMP);
            this.Controls.Add(this.pnlPHP);
            this.Controls.Add(this.ucYear);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axfpSpread);
            this.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FORM_PH_DEFFECTIVE_STATUS_YEAR";
            this.Text = "FORM_OS_DEFFECTIVE_STATUS_YEAR";
            this.Load += new System.EventHandler(this.FORM_PH_DEFFECTIVE_STATUS_YEAR_Load);
            this.VisibleChanged += new System.EventHandler(this.FORM_PH_DEFFECTIVE_STATUS_YEAR_VisibleChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfDailyReport_Header)).EndInit();
            this.pnlCMP.ResumeLayout(false);
            this.pnlPHP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer2;
        private AxFPSpreadADO.AxfpSpread axfDailyReport_Header;
        private AxFPSpreadADO.AxfpSpread axfpSpread;
        private System.Windows.Forms.Timer timer1;
        private ChartDirector.WinChartViewer chart1;
        private ChartDirector.WinChartViewer chart2;
        private ChartDirector.WinChartViewer chart3;
        private System.Windows.Forms.Button button1;
        public DevExpress.XtraEditors.SimpleButton cmdMonth;
        public DevExpress.XtraEditors.SimpleButton cmdYear;
        private UC_YEAR_SELECTION ucYear;
        private A1Panel pnlCMP;
        private System.Windows.Forms.Label label3;
        private A1Panel pnlPHP;
        private System.Windows.Forms.Label label2;
    }
}

