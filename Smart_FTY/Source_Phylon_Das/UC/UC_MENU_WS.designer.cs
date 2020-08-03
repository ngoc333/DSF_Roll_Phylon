namespace Smart_FTY
{
    partial class UC_MENU_WS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_MENU_WS));
            this.gbb = new System.Windows.Forms.GroupBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProduction = new System.Windows.Forms.Button();
            this.btnTemperature = new System.Windows.Forms.Button();
            this.btnTallySheet = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblName = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.labelGradient1 = new Smart_FTY.LabelGradient();
            this.axfpSpread1 = new AxFPUSpreadADO.AxfpSpread();
            this.gbb.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbb
            // 
            this.gbb.Controls.Add(this.axfpSpread1);
            this.gbb.Font = new System.Drawing.Font("Calibri", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbb.ForeColor = System.Drawing.Color.Black;
            this.gbb.Location = new System.Drawing.Point(0, 4);
            this.gbb.Name = "gbb";
            this.gbb.Size = new System.Drawing.Size(218, 433);
            this.gbb.TabIndex = 1;
            this.gbb.TabStop = false;
            this.gbb.Text = "Prod Status";
            // 
            // lblLine
            // 
            this.lblLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLine.Font = new System.Drawing.Font("Calibri", 21.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblLine.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblLine.Location = new System.Drawing.Point(8, 6);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(144, 54);
            this.lblLine.TabIndex = 0;
            this.lblLine.Tag = "L101";
            this.lblLine.Text = "LINE 12-12";
            this.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnProduction);
            this.panel1.Controls.Add(this.btnTemperature);
            this.panel1.Controls.Add(this.btnTallySheet);
            this.panel1.Location = new System.Drawing.Point(1, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 239);
            this.panel1.TabIndex = 1;
            // 
            // btnProduction
            // 
            this.btnProduction.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnProduction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProduction.FlatAppearance.BorderSize = 0;
            this.btnProduction.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnProduction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnProduction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnProduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduction.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnProduction.ForeColor = System.Drawing.Color.White;
            this.btnProduction.Location = new System.Drawing.Point(3, 6);
            this.btnProduction.Name = "btnProduction";
            this.btnProduction.Size = new System.Drawing.Size(149, 72);
            this.btnProduction.TabIndex = 4;
            this.btnProduction.Tag = "1";
            this.btnProduction.Text = "Production";
            this.btnProduction.UseVisualStyleBackColor = false;
            this.btnProduction.Click += new System.EventHandler(this.button_Click);
            // 
            // btnTemperature
            // 
            this.btnTemperature.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTemperature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTemperature.FlatAppearance.BorderSize = 0;
            this.btnTemperature.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnTemperature.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnTemperature.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnTemperature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemperature.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnTemperature.ForeColor = System.Drawing.Color.White;
            this.btnTemperature.Location = new System.Drawing.Point(3, 163);
            this.btnTemperature.Name = "btnTemperature";
            this.btnTemperature.Size = new System.Drawing.Size(149, 72);
            this.btnTemperature.TabIndex = 4;
            this.btnTemperature.Tag = "3";
            this.btnTemperature.Text = "Temperature";
            this.btnTemperature.UseVisualStyleBackColor = false;
            this.btnTemperature.Click += new System.EventHandler(this.btnTemperature_Click);
            // 
            // btnTallySheet
            // 
            this.btnTallySheet.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTallySheet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTallySheet.FlatAppearance.BorderSize = 0;
            this.btnTallySheet.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnTallySheet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnTallySheet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnTallySheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallySheet.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnTallySheet.ForeColor = System.Drawing.Color.White;
            this.btnTallySheet.Location = new System.Drawing.Point(3, 84);
            this.btnTallySheet.Name = "btnTallySheet";
            this.btnTallySheet.Size = new System.Drawing.Size(149, 72);
            this.btnTallySheet.TabIndex = 4;
            this.btnTallySheet.Tag = "2";
            this.btnTallySheet.Text = "Tally Sheet";
            this.btnTallySheet.UseVisualStyleBackColor = false;
            this.btnTallySheet.Click += new System.EventHandler(this.button_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 33);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblName);
            this.splitContainer1.Panel1.Controls.Add(this.picture);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.lblLine);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbb);
            this.splitContainer1.Size = new System.Drawing.Size(455, 440);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Black;
            this.lblName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Yellow;
            this.lblName.Location = new System.Drawing.Point(9, 173);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(99, 24);
            this.lblName.TabIndex = 3;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picture
            // 
            this.picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture.Location = new System.Drawing.Point(10, 62);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(98, 108);
            this.picture.TabIndex = 2;
            this.picture.TabStop = false;
            // 
            // labelGradient1
            // 
            this.labelGradient1.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.SlateGray;
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(396, 33);
            this.labelGradient1.TabIndex = 0;
            // 
            // axfpSpread1
            // 
            this.axfpSpread1.DataSource = null;
            this.axfpSpread1.Location = new System.Drawing.Point(3, 43);
            this.axfpSpread1.Name = "axfpSpread1";
            this.axfpSpread1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axfpSpread1.OcxState")));
            this.axfpSpread1.Size = new System.Drawing.Size(213, 421);
            this.axfpSpread1.TabIndex = 0;
            this.axfpSpread1.Advance += new AxFPUSpreadADO._DSpreadEvents_AdvanceEventHandler(this.axfpSpread1_Advance);
            // 
            // UC_MENU_WS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelGradient1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "UC_MENU_WS";
            this.Size = new System.Drawing.Size(396, 473);
            this.gbb.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axfpSpread1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelGradient labelGradient1;
        private DevExpress.XtraEditors.TileItem tileItem2;
        private DevExpress.XtraEditors.TileItem tileItem3;
        private DevExpress.XtraEditors.TileItem tileItem5;
        private DevExpress.XtraEditors.TileItem tileItem6;
        private DevExpress.XtraEditors.TileItem tileItem7;
        private DevExpress.XtraEditors.TileItem tileItem8;
        private DevExpress.XtraEditors.TileItem tileItem9;
        private DevExpress.XtraEditors.TileItem tileItem10;
        private DevExpress.XtraEditors.TileItem tileItem11;
        private DevExpress.XtraEditors.TileItem tileItem12;
        private AxFPUSpreadADO.AxfpSpread axfpSpread1;
        private System.Windows.Forms.GroupBox gbb;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProduction;
        private System.Windows.Forms.Button btnTemperature;
        private System.Windows.Forms.Button btnTallySheet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picture;

    }
}
