namespace Smart_FTY
{
    partial class FRM_ROLL_TALLY_SHEET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ROLL_TALLY_SHEET));
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblWrkDate = new System.Windows.Forms.Label();
            this.lblAssyDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new Smart_FTY.ClassLib.TransparentPanel();
            this.axfpSpread = new AxFPSpreadADO.AxfpSpread();
            this.axfDailyReport_Header = new AxFPSpreadADO.AxfpSpread();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnEVA = new Smart_FTY.A1Panel();
            this.lblEVA = new System.Windows.Forms.Label();
            this.pnRubber = new Smart_FTY.A1Panel();
            this.lblRubber = new System.Windows.Forms.Label();
            this.grdView = new DevExpress.XtraGrid.GridControl();
            this.gvwView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.bandDate = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.MC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.MCS_CD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandMon = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.band01 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL06 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band02 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL07 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band03 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL08 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band04 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL09 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band05 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band06 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band07 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.band08 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TOT_S1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL19 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL20 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL21 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TOT_S2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand16 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL22 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand17 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL23 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand18 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL00 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand19 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL01 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand20 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL02 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand21 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL03 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand22 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL04 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand23 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.COL05 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand24 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TOT_S3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblRPlan = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblName_Shift1 = new System.Windows.Forms.Label();
            this.pbxShift1 = new System.Windows.Forms.PictureBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblS1Rate = new System.Windows.Forms.Label();
            this.lblS1RPlan = new System.Windows.Forms.Label();
            this.lblS1Weight = new System.Windows.Forms.Label();
            this.lblS1Plan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblName_Shift3 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.pbxShift3 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblS3Rate = new System.Windows.Forms.Label();
            this.lblS3Weight = new System.Windows.Forms.Label();
            this.lblS3Plan = new System.Windows.Forms.Label();
            this.lblS3RPlan = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblName_Shift2 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.pbxShift2 = new System.Windows.Forms.PictureBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblS2Rate = new System.Windows.Forms.Label();
            this.lblS2Weight = new System.Windows.Forms.Label();
            this.lblS2RPlan = new System.Windows.Forms.Label();
            this.lblS2Plan = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnHeader.SuspendLayout();
            this.pnButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfDailyReport_Header)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnEVA.SuspendLayout();
            this.pnRubber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShift1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShift3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShift2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.Text = "2019-03-13\n16:02:30";
            // 
            // cmdYear
            // 
            this.cmdYear.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdYear.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdYear.Appearance.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdYear.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.cmdYear.Appearance.Options.UseBackColor = true;
            this.cmdYear.Appearance.Options.UseFont = true;
            this.cmdYear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdYear.ImageOptions.Image")));
            // 
            // cmdMonth
            // 
            this.cmdMonth.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdMonth.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdMonth.Appearance.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.cmdMonth.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.cmdMonth.Appearance.Options.UseBackColor = true;
            this.cmdMonth.Appearance.Options.UseFont = true;
            this.cmdMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdMonth.ImageOptions.Image")));
            // 
            // cmdDay
            // 
            this.cmdDay.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdDay.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdDay.Appearance.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.cmdDay.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.cmdDay.Appearance.Options.UseBackColor = true;
            this.cmdDay.Appearance.Options.UseFont = true;
            this.cmdDay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdDay.ImageOptions.Image")));
            // 
            // cmdBack
            // 
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Calibri", 50F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(1, 13);
            // 
            // lblShift
            // 
            this.lblShift.Size = new System.Drawing.Size(413, 53);
            this.lblShift.Text = "Shift 2 (14:00 ~ 22:00)";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 38);
            this.label5.TabIndex = 53;
            this.label5.Text = "WORKING DATE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWrkDate
            // 
            this.lblWrkDate.BackColor = System.Drawing.Color.White;
            this.lblWrkDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWrkDate.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.lblWrkDate.Location = new System.Drawing.Point(270, 241);
            this.lblWrkDate.Name = "lblWrkDate";
            this.lblWrkDate.Size = new System.Drawing.Size(187, 38);
            this.lblWrkDate.TabIndex = 54;
            this.lblWrkDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAssyDate
            // 
            this.lblAssyDate.BackColor = System.Drawing.Color.White;
            this.lblAssyDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAssyDate.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.lblAssyDate.Location = new System.Drawing.Point(270, 289);
            this.lblAssyDate.Name = "lblAssyDate";
            this.lblAssyDate.Size = new System.Drawing.Size(187, 38);
            this.lblAssyDate.TabIndex = 56;
            this.lblAssyDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(9, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(255, 38);
            this.label8.TabIndex = 55;
            this.label8.Text = "ASSY DATE";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(462, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(67, 39);
            this.panel2.TabIndex = 62;
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // axfpSpread
            // 
            this.axfpSpread.DataSource = null;
            this.axfpSpread.Location = new System.Drawing.Point(5, 541);
            this.axfpSpread.Name = "axfpSpread";
            this.axfpSpread.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread.OcxState")));
            this.axfpSpread.Size = new System.Drawing.Size(1911, 536);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.pnEVA);
            this.panel3.Controls.Add(this.pnRubber);
            this.panel3.Location = new System.Drawing.Point(0, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(481, 57);
            this.panel3.TabIndex = 68;
            // 
            // pnEVA
            // 
            this.pnEVA.AccessibleDescription = "";
            this.pnEVA.AccessibleName = "";
            this.pnEVA.BorderColor = System.Drawing.Color.Empty;
            this.pnEVA.BorderWidth = 2;
            this.pnEVA.Controls.Add(this.lblEVA);
            this.pnEVA.GradientEndColor = System.Drawing.Color.White;
            this.pnEVA.GradientStartColor = System.Drawing.Color.White;
            this.pnEVA.Image = null;
            this.pnEVA.ImageLocation = new System.Drawing.Point(4, 4);
            this.pnEVA.Location = new System.Drawing.Point(160, 5);
            this.pnEVA.Name = "pnEVA";
            this.pnEVA.RoundCornerRadius = 20;
            this.pnEVA.ShadowOffSet = 3;
            this.pnEVA.Size = new System.Drawing.Size(153, 49);
            this.pnEVA.TabIndex = 0;
            // 
            // lblEVA
            // 
            this.lblEVA.BackColor = System.Drawing.Color.Transparent;
            this.lblEVA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEVA.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEVA.Location = new System.Drawing.Point(0, 0);
            this.lblEVA.Name = "lblEVA";
            this.lblEVA.Size = new System.Drawing.Size(153, 49);
            this.lblEVA.TabIndex = 1;
            this.lblEVA.Text = "EVA";
            this.lblEVA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEVA.Click += new System.EventHandler(this.lblEVA_Click);
            // 
            // pnRubber
            // 
            this.pnRubber.AccessibleDescription = "";
            this.pnRubber.AccessibleName = "";
            this.pnRubber.BorderColor = System.Drawing.Color.Empty;
            this.pnRubber.BorderWidth = 2;
            this.pnRubber.Controls.Add(this.lblRubber);
            this.pnRubber.GradientEndColor = System.Drawing.Color.Gray;
            this.pnRubber.GradientStartColor = System.Drawing.Color.White;
            this.pnRubber.Image = null;
            this.pnRubber.ImageLocation = new System.Drawing.Point(4, 4);
            this.pnRubber.Location = new System.Drawing.Point(3, 5);
            this.pnRubber.Name = "pnRubber";
            this.pnRubber.RoundCornerRadius = 20;
            this.pnRubber.ShadowOffSet = 3;
            this.pnRubber.Size = new System.Drawing.Size(153, 49);
            this.pnRubber.TabIndex = 0;
            // 
            // lblRubber
            // 
            this.lblRubber.BackColor = System.Drawing.Color.Transparent;
            this.lblRubber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRubber.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRubber.Location = new System.Drawing.Point(0, 0);
            this.lblRubber.Name = "lblRubber";
            this.lblRubber.Size = new System.Drawing.Size(153, 49);
            this.lblRubber.TabIndex = 0;
            this.lblRubber.Text = "Rubber";
            this.lblRubber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRubber.Click += new System.EventHandler(this.lblRubber_Click);
            // 
            // grdView
            // 
            this.grdView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdView.Location = new System.Drawing.Point(0, 378);
            this.grdView.MainView = this.gvwView;
            this.grdView.Name = "grdView";
            this.grdView.Size = new System.Drawing.Size(1916, 676);
            this.grdView.TabIndex = 69;
            this.grdView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwView});
            // 
            // gvwView
            // 
            this.gvwView.Appearance.BandPanel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvwView.Appearance.BandPanel.ForeColor = System.Drawing.Color.White;
            this.gvwView.Appearance.BandPanel.Options.UseFont = true;
            this.gvwView.Appearance.BandPanel.Options.UseForeColor = true;
            this.gvwView.Appearance.BandPanel.Options.UseTextOptions = true;
            this.gvwView.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwView.Appearance.BandPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwView.Appearance.HorzLine.BackColor = System.Drawing.Color.Black;
            this.gvwView.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwView.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14F);
            this.gvwView.Appearance.Row.Options.UseFont = true;
            this.gvwView.Appearance.Row.Options.UseTextOptions = true;
            this.gvwView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwView.Appearance.VertLine.BackColor = System.Drawing.Color.Black;
            this.gvwView.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwView.BandPanelRowHeight = 40;
            this.gvwView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.bandDate,
            this.gridBand1,
            this.bandMon,
            this.gridBand5,
            this.gridBand15});
            this.gvwView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gvwView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.MC,
            this.MCS_CD,
            this.COL06,
            this.COL07,
            this.COL08,
            this.COL09,
            this.COL10,
            this.COL11,
            this.COL12,
            this.COL13,
            this.TOT_S1,
            this.COL14,
            this.COL15,
            this.COL16,
            this.COL17,
            this.COL18,
            this.COL19,
            this.COL20,
            this.COL21,
            this.TOT_S2,
            this.COL22,
            this.COL23,
            this.COL00,
            this.COL01,
            this.COL02,
            this.COL03,
            this.COL04,
            this.COL05,
            this.TOT_S3});
            this.gvwView.GridControl = this.grdView;
            this.gvwView.Name = "gvwView";
            this.gvwView.OptionsCustomization.AllowBandMoving = false;
            this.gvwView.OptionsCustomization.AllowBandResizing = false;
            this.gvwView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvwView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvwView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvwView.OptionsView.AllowCellMerge = true;
            this.gvwView.OptionsView.ColumnAutoWidth = false;
            this.gvwView.OptionsView.ShowColumnHeaders = false;
            this.gvwView.OptionsView.ShowGroupPanel = false;
            this.gvwView.OptionsView.ShowIndicator = false;
            this.gvwView.PaintStyleName = "Flat";
            this.gvwView.RowHeight = 35;
            this.gvwView.CustomDrawBandHeader += new DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventHandler(this.gvwView_CustomDrawBandHeader);
            this.gvwView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvwView_CustomDrawCell);
            this.gvwView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvwView_RowCellStyle);
            // 
            // bandDate
            // 
            this.bandDate.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.bandDate.AppearanceHeader.Options.UseBackColor = true;
            this.bandDate.Caption = "M/C";
            this.bandDate.Columns.Add(this.MC);
            this.bandDate.Name = "bandDate";
            this.bandDate.VisibleIndex = 0;
            this.bandDate.Width = 58;
            // 
            // MC
            // 
            this.MC.Caption = "MC";
            this.MC.FieldName = "MC";
            this.MC.Name = "MC";
            this.MC.Visible = true;
            this.MC.Width = 58;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand1.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand1.Caption = "MCS";
            this.gridBand1.Columns.Add(this.MCS_CD);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 1;
            this.gridBand1.Width = 190;
            // 
            // MCS_CD
            // 
            this.MCS_CD.Caption = "MCS_CD";
            this.MCS_CD.FieldName = "MCS_CD";
            this.MCS_CD.Name = "MCS_CD";
            this.MCS_CD.Visible = true;
            this.MCS_CD.Width = 190;
            // 
            // bandMon
            // 
            this.bandMon.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.bandMon.AppearanceHeader.Options.UseBackColor = true;
            this.bandMon.Caption = "Shift 1 (06:00 - 14:00)";
            this.bandMon.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.band01,
            this.band02,
            this.band03,
            this.band04,
            this.band05,
            this.band06,
            this.band07,
            this.band08,
            this.gridBand4});
            this.bandMon.Name = "bandMon";
            this.bandMon.VisibleIndex = 2;
            this.bandMon.Width = 550;
            // 
            // band01
            // 
            this.band01.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.band01.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.band01.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.band01.AppearanceHeader.Options.UseBackColor = true;
            this.band01.AppearanceHeader.Options.UseFont = true;
            this.band01.AppearanceHeader.Options.UseForeColor = true;
            this.band01.Caption = "06-07";
            this.band01.Columns.Add(this.COL06);
            this.band01.Name = "band01";
            this.band01.VisibleIndex = 0;
            this.band01.Width = 60;
            // 
            // COL06
            // 
            this.COL06.Caption = "COL06";
            this.COL06.FieldName = "COL06";
            this.COL06.Name = "COL06";
            this.COL06.Visible = true;
            this.COL06.Width = 60;
            // 
            // band02
            // 
            this.band02.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.band02.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.band02.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.band02.AppearanceHeader.Options.UseBackColor = true;
            this.band02.AppearanceHeader.Options.UseFont = true;
            this.band02.AppearanceHeader.Options.UseForeColor = true;
            this.band02.Caption = "07-08";
            this.band02.Columns.Add(this.COL07);
            this.band02.Name = "band02";
            this.band02.VisibleIndex = 1;
            this.band02.Width = 60;
            // 
            // COL07
            // 
            this.COL07.Caption = "COL07";
            this.COL07.FieldName = "COL07";
            this.COL07.Name = "COL07";
            this.COL07.Visible = true;
            this.COL07.Width = 60;
            // 
            // band03
            // 
            this.band03.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.band03.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.band03.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.band03.AppearanceHeader.Options.UseBackColor = true;
            this.band03.AppearanceHeader.Options.UseFont = true;
            this.band03.AppearanceHeader.Options.UseForeColor = true;
            this.band03.Caption = "08-09";
            this.band03.Columns.Add(this.COL08);
            this.band03.Name = "band03";
            this.band03.VisibleIndex = 2;
            this.band03.Width = 60;
            // 
            // COL08
            // 
            this.COL08.Caption = "COL08";
            this.COL08.FieldName = "COL08";
            this.COL08.Name = "COL08";
            this.COL08.Visible = true;
            this.COL08.Width = 60;
            // 
            // band04
            // 
            this.band04.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.band04.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.band04.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.band04.AppearanceHeader.Options.UseBackColor = true;
            this.band04.AppearanceHeader.Options.UseFont = true;
            this.band04.AppearanceHeader.Options.UseForeColor = true;
            this.band04.Caption = "09-10";
            this.band04.Columns.Add(this.COL09);
            this.band04.Name = "band04";
            this.band04.VisibleIndex = 3;
            this.band04.Width = 60;
            // 
            // COL09
            // 
            this.COL09.Caption = "COL09";
            this.COL09.FieldName = "COL09";
            this.COL09.Name = "COL09";
            this.COL09.Visible = true;
            this.COL09.Width = 60;
            // 
            // band05
            // 
            this.band05.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.band05.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.band05.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.band05.AppearanceHeader.Options.UseBackColor = true;
            this.band05.AppearanceHeader.Options.UseFont = true;
            this.band05.AppearanceHeader.Options.UseForeColor = true;
            this.band05.Caption = "10-11";
            this.band05.Columns.Add(this.COL10);
            this.band05.Name = "band05";
            this.band05.VisibleIndex = 4;
            this.band05.Width = 60;
            // 
            // COL10
            // 
            this.COL10.Caption = "COL10";
            this.COL10.FieldName = "COL10";
            this.COL10.Name = "COL10";
            this.COL10.Visible = true;
            this.COL10.Width = 60;
            // 
            // band06
            // 
            this.band06.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.band06.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.band06.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.band06.AppearanceHeader.Options.UseBackColor = true;
            this.band06.AppearanceHeader.Options.UseFont = true;
            this.band06.AppearanceHeader.Options.UseForeColor = true;
            this.band06.Caption = "11-12";
            this.band06.Columns.Add(this.COL11);
            this.band06.Name = "band06";
            this.band06.VisibleIndex = 5;
            this.band06.Width = 60;
            // 
            // COL11
            // 
            this.COL11.Caption = "COL11";
            this.COL11.FieldName = "COL11";
            this.COL11.Name = "COL11";
            this.COL11.Visible = true;
            this.COL11.Width = 60;
            // 
            // band07
            // 
            this.band07.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.band07.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.band07.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.band07.AppearanceHeader.Options.UseBackColor = true;
            this.band07.AppearanceHeader.Options.UseFont = true;
            this.band07.AppearanceHeader.Options.UseForeColor = true;
            this.band07.Caption = "12-13";
            this.band07.Columns.Add(this.COL12);
            this.band07.Name = "band07";
            this.band07.VisibleIndex = 6;
            this.band07.Width = 60;
            // 
            // COL12
            // 
            this.COL12.Caption = "COL12";
            this.COL12.FieldName = "COL12";
            this.COL12.Name = "COL12";
            this.COL12.Visible = true;
            this.COL12.Width = 60;
            // 
            // band08
            // 
            this.band08.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.band08.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.band08.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.band08.AppearanceHeader.Options.UseBackColor = true;
            this.band08.AppearanceHeader.Options.UseFont = true;
            this.band08.AppearanceHeader.Options.UseForeColor = true;
            this.band08.Caption = "13-14";
            this.band08.Columns.Add(this.COL13);
            this.band08.Name = "band08";
            this.band08.VisibleIndex = 7;
            this.band08.Width = 60;
            // 
            // COL13
            // 
            this.COL13.Caption = "COL13";
            this.COL13.FieldName = "COL13";
            this.COL13.Name = "COL13";
            this.COL13.Visible = true;
            this.COL13.Width = 60;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.Caption = "Total";
            this.gridBand4.Columns.Add(this.TOT_S1);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 8;
            // 
            // TOT_S1
            // 
            this.TOT_S1.Caption = "TOT_S1";
            this.TOT_S1.FieldName = "TOT_S1";
            this.TOT_S1.Name = "TOT_S1";
            this.TOT_S1.Visible = true;
            this.TOT_S1.Width = 70;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand5.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand5.Caption = "Shift 2 (14:00 - 22:00)";
            this.gridBand5.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9,
            this.gridBand10,
            this.gridBand11,
            this.gridBand12,
            this.gridBand13,
            this.gridBand14});
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 3;
            this.gridBand5.Width = 550;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand6.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.Caption = "14-15";
            this.gridBand6.Columns.Add(this.COL14);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 0;
            this.gridBand6.Width = 60;
            // 
            // COL14
            // 
            this.COL14.Caption = "COL14";
            this.COL14.FieldName = "COL14";
            this.COL14.Name = "COL14";
            this.COL14.Visible = true;
            this.COL14.Width = 60;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand7.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.Caption = "15-16";
            this.gridBand7.Columns.Add(this.COL15);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 1;
            this.gridBand7.Width = 60;
            // 
            // COL15
            // 
            this.COL15.Caption = "COL15";
            this.COL15.FieldName = "COL15";
            this.COL15.Name = "COL15";
            this.COL15.Visible = true;
            this.COL15.Width = 60;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand8.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand8.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand8.AppearanceHeader.Options.UseFont = true;
            this.gridBand8.Caption = "16-17";
            this.gridBand8.Columns.Add(this.COL16);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 2;
            this.gridBand8.Width = 60;
            // 
            // COL16
            // 
            this.COL16.Caption = "COL16";
            this.COL16.FieldName = "COL16";
            this.COL16.Name = "COL16";
            this.COL16.Visible = true;
            this.COL16.Width = 60;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand9.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand9.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand9.AppearanceHeader.Options.UseFont = true;
            this.gridBand9.Caption = "17-18";
            this.gridBand9.Columns.Add(this.COL17);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 3;
            this.gridBand9.Width = 60;
            // 
            // COL17
            // 
            this.COL17.Caption = "COL17";
            this.COL17.FieldName = "COL17";
            this.COL17.Name = "COL17";
            this.COL17.Visible = true;
            this.COL17.Width = 60;
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand10.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand10.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand10.AppearanceHeader.Options.UseFont = true;
            this.gridBand10.Caption = "18-19";
            this.gridBand10.Columns.Add(this.COL18);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.VisibleIndex = 4;
            this.gridBand10.Width = 60;
            // 
            // COL18
            // 
            this.COL18.Caption = "COL18";
            this.COL18.FieldName = "COL18";
            this.COL18.Name = "COL18";
            this.COL18.Visible = true;
            this.COL18.Width = 60;
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand11.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand11.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand11.AppearanceHeader.Options.UseFont = true;
            this.gridBand11.Caption = "19-20";
            this.gridBand11.Columns.Add(this.COL19);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.VisibleIndex = 5;
            this.gridBand11.Width = 60;
            // 
            // COL19
            // 
            this.COL19.Caption = "COL19";
            this.COL19.FieldName = "COL19";
            this.COL19.Name = "COL19";
            this.COL19.Visible = true;
            this.COL19.Width = 60;
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand12.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand12.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand12.AppearanceHeader.Options.UseFont = true;
            this.gridBand12.Caption = "20-21";
            this.gridBand12.Columns.Add(this.COL20);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.VisibleIndex = 6;
            this.gridBand12.Width = 60;
            // 
            // COL20
            // 
            this.COL20.Caption = "COL20";
            this.COL20.FieldName = "COL20";
            this.COL20.Name = "COL20";
            this.COL20.Visible = true;
            this.COL20.Width = 60;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand13.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand13.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand13.AppearanceHeader.Options.UseFont = true;
            this.gridBand13.Caption = "21-22";
            this.gridBand13.Columns.Add(this.COL21);
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.VisibleIndex = 7;
            this.gridBand13.Width = 60;
            // 
            // COL21
            // 
            this.COL21.Caption = "COL21";
            this.COL21.FieldName = "COL21";
            this.COL21.Name = "COL21";
            this.COL21.Visible = true;
            this.COL21.Width = 60;
            // 
            // gridBand14
            // 
            this.gridBand14.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand14.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand14.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand14.AppearanceHeader.Options.UseFont = true;
            this.gridBand14.Caption = "Total";
            this.gridBand14.Columns.Add(this.TOT_S2);
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.VisibleIndex = 8;
            // 
            // TOT_S2
            // 
            this.TOT_S2.Caption = "TOT_S2";
            this.TOT_S2.FieldName = "TOT_S2";
            this.TOT_S2.Name = "TOT_S2";
            this.TOT_S2.Visible = true;
            this.TOT_S2.Width = 70;
            // 
            // gridBand15
            // 
            this.gridBand15.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.gridBand15.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand15.Caption = "Shift 3 (22:00 - 06:00)";
            this.gridBand15.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand16,
            this.gridBand17,
            this.gridBand18,
            this.gridBand19,
            this.gridBand20,
            this.gridBand21,
            this.gridBand22,
            this.gridBand23,
            this.gridBand24});
            this.gridBand15.Name = "gridBand15";
            this.gridBand15.VisibleIndex = 4;
            this.gridBand15.Width = 550;
            // 
            // gridBand16
            // 
            this.gridBand16.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand16.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand16.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand16.AppearanceHeader.Options.UseFont = true;
            this.gridBand16.Caption = "22-23";
            this.gridBand16.Columns.Add(this.COL22);
            this.gridBand16.Name = "gridBand16";
            this.gridBand16.VisibleIndex = 0;
            this.gridBand16.Width = 60;
            // 
            // COL22
            // 
            this.COL22.Caption = "COL22";
            this.COL22.FieldName = "COL22";
            this.COL22.Name = "COL22";
            this.COL22.Visible = true;
            this.COL22.Width = 60;
            // 
            // gridBand17
            // 
            this.gridBand17.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand17.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand17.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand17.AppearanceHeader.Options.UseFont = true;
            this.gridBand17.Caption = "23-24";
            this.gridBand17.Columns.Add(this.COL23);
            this.gridBand17.Name = "gridBand17";
            this.gridBand17.VisibleIndex = 1;
            this.gridBand17.Width = 60;
            // 
            // COL23
            // 
            this.COL23.Caption = "COL23";
            this.COL23.FieldName = "COL23";
            this.COL23.Name = "COL23";
            this.COL23.Visible = true;
            this.COL23.Width = 60;
            // 
            // gridBand18
            // 
            this.gridBand18.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand18.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand18.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand18.AppearanceHeader.Options.UseFont = true;
            this.gridBand18.Caption = "00-01";
            this.gridBand18.Columns.Add(this.COL00);
            this.gridBand18.Name = "gridBand18";
            this.gridBand18.VisibleIndex = 2;
            this.gridBand18.Width = 60;
            // 
            // COL00
            // 
            this.COL00.Caption = "COL00";
            this.COL00.FieldName = "COL00";
            this.COL00.Name = "COL00";
            this.COL00.Visible = true;
            this.COL00.Width = 60;
            // 
            // gridBand19
            // 
            this.gridBand19.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand19.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand19.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand19.AppearanceHeader.Options.UseFont = true;
            this.gridBand19.Caption = "01-02";
            this.gridBand19.Columns.Add(this.COL01);
            this.gridBand19.Name = "gridBand19";
            this.gridBand19.VisibleIndex = 3;
            this.gridBand19.Width = 60;
            // 
            // COL01
            // 
            this.COL01.Caption = "COL01";
            this.COL01.FieldName = "COL01";
            this.COL01.Name = "COL01";
            this.COL01.Visible = true;
            this.COL01.Width = 60;
            // 
            // gridBand20
            // 
            this.gridBand20.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand20.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand20.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand20.AppearanceHeader.Options.UseFont = true;
            this.gridBand20.Caption = "02-03";
            this.gridBand20.Columns.Add(this.COL02);
            this.gridBand20.Name = "gridBand20";
            this.gridBand20.VisibleIndex = 4;
            this.gridBand20.Width = 60;
            // 
            // COL02
            // 
            this.COL02.Caption = "COL02";
            this.COL02.FieldName = "COL02";
            this.COL02.Name = "COL02";
            this.COL02.Visible = true;
            this.COL02.Width = 60;
            // 
            // gridBand21
            // 
            this.gridBand21.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand21.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand21.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand21.AppearanceHeader.Options.UseFont = true;
            this.gridBand21.Caption = "03-04";
            this.gridBand21.Columns.Add(this.COL03);
            this.gridBand21.Name = "gridBand21";
            this.gridBand21.VisibleIndex = 5;
            this.gridBand21.Width = 60;
            // 
            // COL03
            // 
            this.COL03.Caption = "COL03";
            this.COL03.FieldName = "COL03";
            this.COL03.Name = "COL03";
            this.COL03.Visible = true;
            this.COL03.Width = 60;
            // 
            // gridBand22
            // 
            this.gridBand22.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand22.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand22.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand22.AppearanceHeader.Options.UseFont = true;
            this.gridBand22.Caption = "04-05";
            this.gridBand22.Columns.Add(this.COL04);
            this.gridBand22.Name = "gridBand22";
            this.gridBand22.VisibleIndex = 6;
            this.gridBand22.Width = 60;
            // 
            // COL04
            // 
            this.COL04.Caption = "COL04";
            this.COL04.FieldName = "COL04";
            this.COL04.Name = "COL04";
            this.COL04.Visible = true;
            this.COL04.Width = 60;
            // 
            // gridBand23
            // 
            this.gridBand23.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand23.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand23.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand23.AppearanceHeader.Options.UseFont = true;
            this.gridBand23.Caption = "05-06";
            this.gridBand23.Columns.Add(this.COL05);
            this.gridBand23.Name = "gridBand23";
            this.gridBand23.VisibleIndex = 7;
            this.gridBand23.Width = 60;
            // 
            // COL05
            // 
            this.COL05.Caption = "COL05";
            this.COL05.FieldName = "COL05";
            this.COL05.Name = "COL05";
            this.COL05.Visible = true;
            this.COL05.Width = 60;
            // 
            // gridBand24
            // 
            this.gridBand24.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridBand24.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.gridBand24.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand24.AppearanceHeader.Options.UseFont = true;
            this.gridBand24.Caption = "Total";
            this.gridBand24.Columns.Add(this.TOT_S3);
            this.gridBand24.Name = "gridBand24";
            this.gridBand24.VisibleIndex = 8;
            // 
            // TOT_S3
            // 
            this.TOT_S3.Caption = "TOT_S3";
            this.TOT_S3.FieldName = "TOT_S3";
            this.TOT_S3.Name = "TOT_S3";
            this.TOT_S3.Visible = true;
            this.TOT_S3.Width = 70;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.lblRate);
            this.groupBox4.Controls.Add(this.lblWeight);
            this.groupBox4.Controls.Add(this.lblPlan);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.lblRPlan);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox4.Location = new System.Drawing.Point(1575, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(341, 162);
            this.groupBox4.TabIndex = 73;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TOTAL";
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Blue;
            this.label30.Location = new System.Drawing.Point(242, 128);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(90, 29);
            this.label30.TabIndex = 80;
            this.label30.Text = "%";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label37.ForeColor = System.Drawing.Color.Blue;
            this.label37.Location = new System.Drawing.Point(242, 63);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(90, 29);
            this.label37.TabIndex = 79;
            this.label37.Text = "Batch";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Blue;
            this.label22.Location = new System.Drawing.Point(242, 96);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 29);
            this.label22.TabIndex = 79;
            this.label22.Text = "Batch";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Blue;
            this.label23.Location = new System.Drawing.Point(242, 30);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 29);
            this.label23.TabIndex = 78;
            this.label23.Text = "Batch";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRate
            // 
            this.lblRate.BackColor = System.Drawing.Color.White;
            this.lblRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRate.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate.Location = new System.Drawing.Point(133, 129);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(108, 29);
            this.lblRate.TabIndex = 75;
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeight
            // 
            this.lblWeight.BackColor = System.Drawing.Color.White;
            this.lblWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeight.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(133, 96);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(108, 29);
            this.lblWeight.TabIndex = 74;
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlan
            // 
            this.lblPlan.BackColor = System.Drawing.Color.White;
            this.lblPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlan.Location = new System.Drawing.Point(133, 30);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(108, 29);
            this.lblPlan.TabIndex = 73;
            this.lblPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label27.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(8, 129);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 29);
            this.label27.TabIndex = 72;
            this.label27.Text = "RATE";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRPlan
            // 
            this.lblRPlan.BackColor = System.Drawing.Color.White;
            this.lblRPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRPlan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblRPlan.Location = new System.Drawing.Point(133, 63);
            this.lblRPlan.Name = "lblRPlan";
            this.lblRPlan.Size = new System.Drawing.Size(108, 29);
            this.lblRPlan.TabIndex = 74;
            this.lblRPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label28.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(8, 96);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(124, 29);
            this.label28.TabIndex = 71;
            this.label28.Text = "ACTUAL";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label29.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(8, 30);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(124, 29);
            this.label29.TabIndex = 70;
            this.label29.Text = "S.PLAN";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label35.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(8, 63);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(124, 29);
            this.label35.TabIndex = 71;
            this.label35.Text = "R.PLAN";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblName_Shift1);
            this.groupBox3.Controls.Add(this.pbxShift1);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.lblS1Rate);
            this.groupBox3.Controls.Add(this.lblS1RPlan);
            this.groupBox3.Controls.Add(this.lblS1Weight);
            this.groupBox3.Controls.Add(this.lblS1Plan);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Location = new System.Drawing.Point(534, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 267);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SHIFT 1";
            // 
            // lblName_Shift1
            // 
            this.lblName_Shift1.BackColor = System.Drawing.Color.Black;
            this.lblName_Shift1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.lblName_Shift1.ForeColor = System.Drawing.Color.Yellow;
            this.lblName_Shift1.Location = new System.Drawing.Point(6, 101);
            this.lblName_Shift1.Name = "lblName_Shift1";
            this.lblName_Shift1.Size = new System.Drawing.Size(124, 29);
            this.lblName_Shift1.TabIndex = 74;
            this.lblName_Shift1.Text = "Unknown";
            this.lblName_Shift1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxShift1
            // 
            this.pbxShift1.BackgroundImage = global::Smart_FTY.Properties.Resources.dfAvatar12;
            this.pbxShift1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxShift1.Location = new System.Drawing.Point(131, 13);
            this.pbxShift1.Name = "pbxShift1";
            this.pbxShift1.Size = new System.Drawing.Size(100, 117);
            this.pbxShift1.TabIndex = 74;
            this.pbxShift1.TabStop = false;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.Blue;
            this.label26.Location = new System.Drawing.Point(239, 229);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(90, 29);
            this.label26.TabIndex = 80;
            this.label26.Text = "%";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(241, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 29);
            this.label3.TabIndex = 79;
            this.label3.Text = "Batch";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(241, 200);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 29);
            this.label20.TabIndex = 79;
            this.label20.Text = "Batch";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.Blue;
            this.label21.Location = new System.Drawing.Point(241, 134);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(90, 29);
            this.label21.TabIndex = 78;
            this.label21.Text = "Batch";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS1Rate
            // 
            this.lblS1Rate.BackColor = System.Drawing.Color.White;
            this.lblS1Rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS1Rate.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblS1Rate.Location = new System.Drawing.Point(131, 233);
            this.lblS1Rate.Name = "lblS1Rate";
            this.lblS1Rate.Size = new System.Drawing.Size(108, 29);
            this.lblS1Rate.TabIndex = 75;
            this.lblS1Rate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS1RPlan
            // 
            this.lblS1RPlan.BackColor = System.Drawing.Color.White;
            this.lblS1RPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS1RPlan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblS1RPlan.Location = new System.Drawing.Point(131, 167);
            this.lblS1RPlan.Name = "lblS1RPlan";
            this.lblS1RPlan.Size = new System.Drawing.Size(108, 29);
            this.lblS1RPlan.TabIndex = 74;
            this.lblS1RPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS1Weight
            // 
            this.lblS1Weight.BackColor = System.Drawing.Color.White;
            this.lblS1Weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS1Weight.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblS1Weight.Location = new System.Drawing.Point(131, 200);
            this.lblS1Weight.Name = "lblS1Weight";
            this.lblS1Weight.Size = new System.Drawing.Size(108, 29);
            this.lblS1Weight.TabIndex = 74;
            this.lblS1Weight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS1Plan
            // 
            this.lblS1Plan.BackColor = System.Drawing.Color.White;
            this.lblS1Plan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS1Plan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblS1Plan.Location = new System.Drawing.Point(131, 134);
            this.lblS1Plan.Name = "lblS1Plan";
            this.lblS1Plan.Size = new System.Drawing.Size(108, 29);
            this.lblS1Plan.TabIndex = 73;
            this.lblS1Plan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 71;
            this.label1.Text = "R.PLAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(6, 233);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 29);
            this.label13.TabIndex = 72;
            this.label13.Text = "RATE";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label14.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(6, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 29);
            this.label14.TabIndex = 71;
            this.label14.Text = "ACTUAL";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label15.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(6, 134);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 29);
            this.label15.TabIndex = 70;
            this.label15.Text = "S.PLAN";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblName_Shift3);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.pbxShift3);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblS3Rate);
            this.groupBox2.Controls.Add(this.lblS3Weight);
            this.groupBox2.Controls.Add(this.lblS3Plan);
            this.groupBox2.Controls.Add(this.lblS3RPlan);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(1228, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 267);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SHIFT 3";
            // 
            // lblName_Shift3
            // 
            this.lblName_Shift3.BackColor = System.Drawing.Color.Black;
            this.lblName_Shift3.ForeColor = System.Drawing.Color.Yellow;
            this.lblName_Shift3.Location = new System.Drawing.Point(7, 101);
            this.lblName_Shift3.Name = "lblName_Shift3";
            this.lblName_Shift3.Size = new System.Drawing.Size(124, 29);
            this.lblName_Shift3.TabIndex = 74;
            this.lblName_Shift3.Text = "Unknown";
            this.lblName_Shift3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Blue;
            this.label25.Location = new System.Drawing.Point(240, 233);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(90, 29);
            this.label25.TabIndex = 78;
            this.label25.Text = "%";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label34.ForeColor = System.Drawing.Color.Blue;
            this.label34.Location = new System.Drawing.Point(240, 168);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(90, 29);
            this.label34.TabIndex = 79;
            this.label34.Text = "Batch";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxShift3
            // 
            this.pbxShift3.BackgroundImage = global::Smart_FTY.Properties.Resources.dfAvatar12;
            this.pbxShift3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxShift3.Location = new System.Drawing.Point(131, 13);
            this.pbxShift3.Name = "pbxShift3";
            this.pbxShift3.Size = new System.Drawing.Size(100, 117);
            this.pbxShift3.TabIndex = 74;
            this.pbxShift3.TabStop = false;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Blue;
            this.label19.Location = new System.Drawing.Point(240, 201);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 29);
            this.label19.TabIndex = 77;
            this.label19.Text = "Batch";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(240, 135);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 29);
            this.label18.TabIndex = 76;
            this.label18.Text = "Batch";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS3Rate
            // 
            this.lblS3Rate.BackColor = System.Drawing.Color.White;
            this.lblS3Rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS3Rate.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS3Rate.Location = new System.Drawing.Point(131, 234);
            this.lblS3Rate.Name = "lblS3Rate";
            this.lblS3Rate.Size = new System.Drawing.Size(108, 29);
            this.lblS3Rate.TabIndex = 75;
            this.lblS3Rate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS3Weight
            // 
            this.lblS3Weight.BackColor = System.Drawing.Color.White;
            this.lblS3Weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS3Weight.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS3Weight.Location = new System.Drawing.Point(131, 201);
            this.lblS3Weight.Name = "lblS3Weight";
            this.lblS3Weight.Size = new System.Drawing.Size(108, 29);
            this.lblS3Weight.TabIndex = 74;
            this.lblS3Weight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS3Plan
            // 
            this.lblS3Plan.BackColor = System.Drawing.Color.White;
            this.lblS3Plan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS3Plan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS3Plan.Location = new System.Drawing.Point(131, 135);
            this.lblS3Plan.Name = "lblS3Plan";
            this.lblS3Plan.Size = new System.Drawing.Size(108, 29);
            this.lblS3Plan.TabIndex = 73;
            this.lblS3Plan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS3RPlan
            // 
            this.lblS3RPlan.BackColor = System.Drawing.Color.White;
            this.lblS3RPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS3RPlan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblS3RPlan.Location = new System.Drawing.Point(131, 168);
            this.lblS3RPlan.Name = "lblS3RPlan";
            this.lblS3RPlan.Size = new System.Drawing.Size(108, 29);
            this.lblS3RPlan.TabIndex = 74;
            this.lblS3RPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(6, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 29);
            this.label10.TabIndex = 72;
            this.label10.Text = "RATE";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(6, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 29);
            this.label11.TabIndex = 71;
            this.label11.Text = "ACTUAL";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label32.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(6, 168);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(124, 29);
            this.label32.TabIndex = 71;
            this.label32.Text = "R.PLAN";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(6, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 29);
            this.label12.TabIndex = 70;
            this.label12.Text = "S.PLAN";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblName_Shift2);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.pbxShift2);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblS2Rate);
            this.groupBox1.Controls.Add(this.lblS2Weight);
            this.groupBox1.Controls.Add(this.lblS2RPlan);
            this.groupBox1.Controls.Add(this.lblS2Plan);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(881, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 267);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SHIFT 2";
            // 
            // lblName_Shift2
            // 
            this.lblName_Shift2.BackColor = System.Drawing.Color.Black;
            this.lblName_Shift2.ForeColor = System.Drawing.Color.Yellow;
            this.lblName_Shift2.Location = new System.Drawing.Point(6, 101);
            this.lblName_Shift2.Name = "lblName_Shift2";
            this.lblName_Shift2.Size = new System.Drawing.Size(124, 29);
            this.lblName_Shift2.TabIndex = 74;
            this.lblName_Shift2.Text = "Unknown";
            this.lblName_Shift2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(239, 233);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(90, 29);
            this.label24.TabIndex = 73;
            this.label24.Text = "%";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxShift2
            // 
            this.pbxShift2.BackgroundImage = global::Smart_FTY.Properties.Resources.dfAvatar12;
            this.pbxShift2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxShift2.Location = new System.Drawing.Point(131, 13);
            this.pbxShift2.Name = "pbxShift2";
            this.pbxShift2.Size = new System.Drawing.Size(100, 117);
            this.pbxShift2.TabIndex = 74;
            this.pbxShift2.TabStop = false;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.Blue;
            this.label31.Location = new System.Drawing.Point(239, 167);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(90, 29);
            this.label31.TabIndex = 79;
            this.label31.Text = "Batch";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(239, 200);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 29);
            this.label17.TabIndex = 72;
            this.label17.Text = "Batch";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(239, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 29);
            this.label16.TabIndex = 71;
            this.label16.Text = "Batch";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS2Rate
            // 
            this.lblS2Rate.BackColor = System.Drawing.Color.White;
            this.lblS2Rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS2Rate.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS2Rate.Location = new System.Drawing.Point(130, 233);
            this.lblS2Rate.Name = "lblS2Rate";
            this.lblS2Rate.Size = new System.Drawing.Size(108, 29);
            this.lblS2Rate.TabIndex = 70;
            this.lblS2Rate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS2Weight
            // 
            this.lblS2Weight.BackColor = System.Drawing.Color.White;
            this.lblS2Weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS2Weight.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS2Weight.Location = new System.Drawing.Point(130, 200);
            this.lblS2Weight.Name = "lblS2Weight";
            this.lblS2Weight.Size = new System.Drawing.Size(108, 29);
            this.lblS2Weight.TabIndex = 68;
            this.lblS2Weight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS2RPlan
            // 
            this.lblS2RPlan.BackColor = System.Drawing.Color.White;
            this.lblS2RPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS2RPlan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblS2RPlan.Location = new System.Drawing.Point(130, 167);
            this.lblS2RPlan.Name = "lblS2RPlan";
            this.lblS2RPlan.Size = new System.Drawing.Size(108, 29);
            this.lblS2RPlan.TabIndex = 74;
            this.lblS2RPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblS2Plan
            // 
            this.lblS2Plan.BackColor = System.Drawing.Color.White;
            this.lblS2Plan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblS2Plan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS2Plan.Location = new System.Drawing.Point(130, 134);
            this.lblS2Plan.Name = "lblS2Plan";
            this.lblS2Plan.Size = new System.Drawing.Size(108, 29);
            this.lblS2Plan.TabIndex = 67;
            this.lblS2Plan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 29);
            this.label9.TabIndex = 69;
            this.label9.Text = "RATE";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 71;
            this.label2.Text = "R.PLAN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 29);
            this.label7.TabIndex = 68;
            this.label7.Text = "ACTUAL";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 29);
            this.label4.TabIndex = 67;
            this.label4.Text = "S.PLAN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRM_ROLL_TALLY_SHEET
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1916, 1054);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblAssyDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblWrkDate);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FRM_ROLL_TALLY_SHEET";
            this.Text = "FORM_WORK_TALLY_SHEET";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FORM_WORK_TALLY_SHEET_FormClosing);
            this.Load += new System.EventHandler(this.FORM_WORK_TALLY_SHEET_Load);
            this.VisibleChanged += new System.EventHandler(this.FORM_WORK_TALLY_SHEET_VisibleChanged);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblWrkDate, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblAssyDate, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.grdView, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfDailyReport_Header)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pnEVA.ResumeLayout(false);
            this.pnRubber.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxShift1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxShift3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxShift2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWrkDate;
        private System.Windows.Forms.Label lblAssyDate;
        private System.Windows.Forms.Label label8;
        private AxFPSpreadADO.AxfpSpread axfDailyReport_Header;
        private ClassLib.TransparentPanel panel2;
        private AxFPSpreadADO.AxfpSpread axfpSpread;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private A1Panel pnEVA;
        private System.Windows.Forms.Label lblEVA;
        private A1Panel pnRubber;
        private System.Windows.Forms.Label lblRubber;
        private DevExpress.XtraGrid.GridControl grdView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvwView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL01;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL17;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL02;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL03;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL04;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL05;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL06;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL07;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL08;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL09;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL16;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL18;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL19;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL20;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL21;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL22;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL23;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn COL00;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TOT_S1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TOT_S2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TOT_S3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn MC;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn MCS_CD;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandDate;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandMon;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band01;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band02;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band03;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band04;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band05;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band06;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band07;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand band08;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand14;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand15;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand16;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand17;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand18;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand19;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand20;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand21;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand22;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand23;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand24;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblRPlan;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblS1Rate;
        private System.Windows.Forms.Label lblS1RPlan;
        private System.Windows.Forms.Label lblS1Weight;
        private System.Windows.Forms.Label lblS1Plan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblS3Rate;
        private System.Windows.Forms.Label lblS3Weight;
        private System.Windows.Forms.Label lblS3Plan;
        private System.Windows.Forms.Label lblS3RPlan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblS2Rate;
        private System.Windows.Forms.Label lblS2Weight;
        private System.Windows.Forms.Label lblS2RPlan;
        private System.Windows.Forms.Label lblS2Plan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbxShift1;
        private System.Windows.Forms.Label lblName_Shift1;
        private System.Windows.Forms.Label lblName_Shift3;
        private System.Windows.Forms.PictureBox pbxShift3;
        private System.Windows.Forms.Label lblName_Shift2;
        private System.Windows.Forms.PictureBox pbxShift2;
    }
}

