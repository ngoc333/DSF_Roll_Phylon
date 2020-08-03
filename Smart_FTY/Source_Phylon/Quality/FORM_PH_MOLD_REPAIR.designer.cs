namespace Smart_FTY
{
    partial class FORM_PH_MOLD_REPAIR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_PH_MOLD_REPAIR));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pn_defective = new System.Windows.Forms.Panel();
            this.axGridModel = new AxFPSpreadADO.AxfpSpread();
            this.chartStyle = new ChartDirector.WinChartViewer();
            this.chartModel = new ChartDirector.WinChartViewer();
            this.axfpHeaderData = new AxFPSpreadADO.AxfpSpread();
            this.chartErrorCounter = new ChartDirector.WinChartViewer();
            this.tmr_style = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pnHeader.SuspendLayout();
            this.pnButton.SuspendLayout();
            this.pnFormType.SuspendLayout();
            this.pn2.SuspendLayout();
            this.pn1.SuspendLayout();
            this.pn_defective.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGridModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpHeaderData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartErrorCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.button1);
            this.pnHeader.Size = new System.Drawing.Size(1914, 106);
            this.pnHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.pnHeader.Controls.SetChildIndex(this.pnButton, 0);
            this.pnHeader.Controls.SetChildIndex(this.cmdBack, 0);
            this.pnHeader.Controls.SetChildIndex(this.lblShift, 0);
            this.pnHeader.Controls.SetChildIndex(this.lblTitle, 0);
            this.pnHeader.Controls.SetChildIndex(this.button1, 0);
            // 
            // lblDate
            // 
            this.lblDate.Size = new System.Drawing.Size(258, 106);
            this.lblDate.Text = "2020-05-19\n08:31:52";
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
            // pnButton
            // 
            this.pnButton.Location = new System.Drawing.Point(1217, 1);
            // 
            // cmdBack
            // 
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.Location = new System.Drawing.Point(1159, -1);
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lblShift
            // 
            this.lblShift.Size = new System.Drawing.Size(413, 53);
            this.lblShift.Text = "Shift 1 (06:00 ~ 14:00)";
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1434, 106);
            // 
            // pnFormType
            // 
            this.pnFormType.Size = new System.Drawing.Size(1914, 57);
            // 
            // lblPhylon
            // 
            this.lblPhylon.Click += new System.EventHandler(this.lblPhylon_Click);
            // 
            // lblCMP
            // 
            this.lblCMP.Click += new System.EventHandler(this.lblCMP_Click);
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
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pn_defective
            // 
            this.pn_defective.Controls.Add(this.axGridModel);
            this.pn_defective.Controls.Add(this.chartStyle);
            this.pn_defective.Controls.Add(this.chartModel);
            this.pn_defective.Controls.Add(this.axfpHeaderData);
            this.pn_defective.Controls.Add(this.chartErrorCounter);
            this.pn_defective.Location = new System.Drawing.Point(1, 168);
            this.pn_defective.Name = "pn_defective";
            this.pn_defective.Size = new System.Drawing.Size(1913, 888);
            this.pn_defective.TabIndex = 661;
            // 
            // axGridModel
            // 
            this.axGridModel.DataSource = null;
            this.axGridModel.Location = new System.Drawing.Point(910, 705);
            this.axGridModel.Name = "axGridModel";
            this.axGridModel.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGridModel.OcxState")));
            this.axGridModel.Size = new System.Drawing.Size(995, 180);
            this.axGridModel.TabIndex = 668;
            this.axGridModel.Visible = false;
            // 
            // chartStyle
            // 
            this.chartStyle.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartStyle.Location = new System.Drawing.Point(0, 611);
            this.chartStyle.Name = "chartStyle";
            this.chartStyle.Size = new System.Drawing.Size(30, 21);
            this.chartStyle.TabIndex = 667;
            this.chartStyle.TabStop = false;
            // 
            // chartModel
            // 
            this.chartModel.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartModel.Location = new System.Drawing.Point(909, 3);
            this.chartModel.Name = "chartModel";
            this.chartModel.Size = new System.Drawing.Size(999, 686);
            this.chartModel.TabIndex = 665;
            this.chartModel.TabStop = false;
            // 
            // axfpHeaderData
            // 
            this.axfpHeaderData.DataSource = null;
            this.axfpHeaderData.Location = new System.Drawing.Point(3, 703);
            this.axfpHeaderData.Name = "axfpHeaderData";
            this.axfpHeaderData.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpHeaderData.OcxState")));
            this.axfpHeaderData.Size = new System.Drawing.Size(901, 182);
            this.axfpHeaderData.TabIndex = 664;
            this.axfpHeaderData.Visible = false;
            // 
            // chartErrorCounter
            // 
            this.chartErrorCounter.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartErrorCounter.Location = new System.Drawing.Point(3, 3);
            this.chartErrorCounter.Name = "chartErrorCounter";
            this.chartErrorCounter.Size = new System.Drawing.Size(900, 686);
            this.chartErrorCounter.TabIndex = 660;
            this.chartErrorCounter.TabStop = false;
            // 
            // tmr_style
            // 
            this.tmr_style.Interval = 50;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.BackgroundImage = global::Smart_FTY.Properties.Resources.Back_Icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1540, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 101);
            this.button1.TabIndex = 688;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FORM_PH_MOLD_REPAIR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 1054);
            this.Controls.Add(this.pn_defective);
            this.Name = "FORM_PH_MOLD_REPAIR";
            this.Text = "FORM_MOLD_REPAIR_WEEKLY";
            this.Load += new System.EventHandler(this.Frm_Mold_Show_TV_Load);
            this.VisibleChanged += new System.EventHandler(this.FORM_MOLD_REPAIR_WEEKLY_VisibleChanged);
            this.Controls.SetChildIndex(this.pn_defective, 0);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.pnFormType, 0);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnButton.ResumeLayout(false);
            this.pnFormType.ResumeLayout(false);
            this.pn2.ResumeLayout(false);
            this.pn1.ResumeLayout(false);
            this.pn_defective.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axGridModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpHeaderData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartErrorCounter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel pn_defective;
        private ChartDirector.WinChartViewer chartErrorCounter;
        private AxFPSpreadADO.AxfpSpread axfpHeaderData;
        private System.Windows.Forms.Timer tmr_style;
        private ChartDirector.WinChartViewer chartModel;
        private ChartDirector.WinChartViewer chartStyle;
        private AxFPSpreadADO.AxfpSpread axGridModel;
        private System.Windows.Forms.Button button1;
    }
}