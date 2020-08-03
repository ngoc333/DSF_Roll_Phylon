namespace Smart_FTY
{
    partial class UCMainMenu
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
            this.components = new System.ComponentModel.Container();
            this.cmdProduction = new System.Windows.Forms.Button();
            this.cmdTallySheet = new System.Windows.Forms.Button();
            this.cmdTemp = new System.Windows.Forms.Button();
            this.cmdLine = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdProduction
            // 
            this.cmdProduction.BackColor = System.Drawing.Color.RoyalBlue;
            this.cmdProduction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdProduction.FlatAppearance.BorderSize = 0;
            this.cmdProduction.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.cmdProduction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.cmdProduction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cmdProduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdProduction.Font = new System.Drawing.Font("Calibri", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cmdProduction.ForeColor = System.Drawing.Color.White;
            this.cmdProduction.Location = new System.Drawing.Point(2, 176);
            this.cmdProduction.Name = "cmdProduction";
            this.cmdProduction.Size = new System.Drawing.Size(256, 114);
            this.cmdProduction.TabIndex = 5;
            this.cmdProduction.Tag = "1";
            this.cmdProduction.Text = "PRODUCTION\r\nSTATUS";
            this.cmdProduction.UseVisualStyleBackColor = false;
            this.cmdProduction.Click += new System.EventHandler(this.cmdProduction_Click);
            this.cmdProduction.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.cmdProduction.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // cmdTallySheet
            // 
            this.cmdTallySheet.BackColor = System.Drawing.Color.RoyalBlue;
            this.cmdTallySheet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdTallySheet.FlatAppearance.BorderSize = 0;
            this.cmdTallySheet.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.cmdTallySheet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.cmdTallySheet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cmdTallySheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTallySheet.Font = new System.Drawing.Font("Calibri", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cmdTallySheet.ForeColor = System.Drawing.Color.White;
            this.cmdTallySheet.Location = new System.Drawing.Point(260, 176);
            this.cmdTallySheet.Name = "cmdTallySheet";
            this.cmdTallySheet.Size = new System.Drawing.Size(259, 114);
            this.cmdTallySheet.TabIndex = 6;
            this.cmdTallySheet.Tag = "1";
            this.cmdTallySheet.Text = "TALLY SHEET";
            this.cmdTallySheet.UseVisualStyleBackColor = false;
            this.cmdTallySheet.Click += new System.EventHandler(this.cmdTallySheet_Click);
            this.cmdTallySheet.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.cmdTallySheet.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // cmdTemp
            // 
            this.cmdTemp.BackColor = System.Drawing.Color.RoyalBlue;
            this.cmdTemp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdTemp.FlatAppearance.BorderSize = 0;
            this.cmdTemp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.cmdTemp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.cmdTemp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cmdTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTemp.Font = new System.Drawing.Font("Calibri", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cmdTemp.ForeColor = System.Drawing.Color.White;
            this.cmdTemp.Location = new System.Drawing.Point(521, 176);
            this.cmdTemp.Name = "cmdTemp";
            this.cmdTemp.Size = new System.Drawing.Size(261, 114);
            this.cmdTemp.TabIndex = 7;
            this.cmdTemp.Tag = "1";
            this.cmdTemp.Text = "TEMPARATURE";
            this.cmdTemp.UseVisualStyleBackColor = false;
            this.cmdTemp.Click += new System.EventHandler(this.cmdTemp_Click);
            this.cmdTemp.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.cmdTemp.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // cmdLine
            // 
            this.cmdLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdLine.FlatAppearance.BorderSize = 0;
            this.cmdLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.cmdLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.cmdLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cmdLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLine.Font = new System.Drawing.Font("Calibri", 70F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cmdLine.ForeColor = System.Drawing.Color.MediumBlue;
            this.cmdLine.Location = new System.Drawing.Point(204, 0);
            this.cmdLine.Name = "cmdLine";
            this.cmdLine.Size = new System.Drawing.Size(577, 173);
            this.cmdLine.TabIndex = 8;
            this.cmdLine.Tag = "1";
            this.cmdLine.UseVisualStyleBackColor = false;
            this.cmdLine.MouseEnter += new System.EventHandler(this.cmdLine_MouseEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(34, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 137);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(34, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 34);
            this.label1.TabIndex = 10;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmdLine);
            this.Controls.Add(this.cmdTemp);
            this.Controls.Add(this.cmdTallySheet);
            this.Controls.Add(this.cmdProduction);
            this.Name = "UCMainMenu";
            this.Size = new System.Drawing.Size(781, 335);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdProduction;
        private System.Windows.Forms.Button cmdTallySheet;
        private System.Windows.Forms.Button cmdTemp;
        private System.Windows.Forms.Button cmdLine;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}
