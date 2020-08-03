namespace Smart_FTY.UC
{
    partial class User_Chart
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
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.HatchFillOptions hatchFillOptions2 = new DevExpress.XtraCharts.HatchFillOptions();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedLineSeriesLabel stackedLineSeriesLabel2 = new DevExpress.XtraCharts.StackedLineSeriesLabel();
            DevExpress.XtraCharts.StackedLineSeriesView stackedLineSeriesView2 = new DevExpress.XtraCharts.StackedLineSeriesView();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.chart_temp = new DevExpress.XtraCharts.ChartControl();
            this.lbl_noplan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_temp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_temp
            // 
            this.chart_temp.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chart_temp.CrosshairOptions.ArgumentLineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dash;
            this.chart_temp.CrosshairOptions.ArgumentLineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            this.chart_temp.DataBindings = null;
            xyDiagram2.AxisX.Label.Font = new System.Drawing.Font("Tahoma", 10F);
            xyDiagram2.AxisX.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram2.AxisX.Title.Text = "Date";
            xyDiagram2.AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.Label.Font = new System.Drawing.Font("Tahoma", 11F);
            xyDiagram2.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram2.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram2.AxisY.Title.Text = "Rate (%)";
            xyDiagram2.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            xyDiagram2.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chart_temp.Diagram = xyDiagram2;
            this.chart_temp.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart_temp.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Hatch;
            hatchFillOptions2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            hatchFillOptions2.HatchStyle = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
            this.chart_temp.FillStyle.Options = hatchFillOptions2;
            this.chart_temp.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chart_temp.Legend.Direction = DevExpress.XtraCharts.LegendDirection.BottomToTop;
            this.chart_temp.Legend.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.chart_temp.Legend.Name = "Default Legend";
            this.chart_temp.Legend.TextOffset = 5;
            this.chart_temp.Legend.Title.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart_temp.Legend.Title.Text = "Slab Test";
            this.chart_temp.Legend.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chart_temp.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chart_temp.Location = new System.Drawing.Point(0, 0);
            this.chart_temp.Name = "chart_temp";
            stackedLineSeriesLabel2.Font = new System.Drawing.Font("Tahoma", 12F);
            stackedLineSeriesLabel2.TextPattern = "{V:#,#}";
            series4.Label = stackedLineSeriesLabel2;
            series4.Name = "Max";
            stackedLineSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(105)))), ((int)(((byte)(58)))));
            stackedLineSeriesView2.LineStyle.Thickness = 3;
            series4.View = stackedLineSeriesView2;
            series5.Name = "Min";
            lineSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(105)))), ((int)(((byte)(58)))));
            lineSeriesView3.LineStyle.Thickness = 3;
            series5.View = lineSeriesView3;
            pointSeriesLabel2.Font = new System.Drawing.Font("Tahoma", 12F);
            pointSeriesLabel2.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            pointSeriesLabel2.TextPattern = "{V:#,0.0#}";
            series6.Label = pointSeriesLabel2;
            series6.Name = "Value";
            lineSeriesView4.Color = System.Drawing.Color.DodgerBlue;
            lineSeriesView4.LineMarkerOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            lineSeriesView4.LineMarkerOptions.Color = System.Drawing.Color.Yellow;
            lineSeriesView4.LineMarkerOptions.Size = 7;
            lineSeriesView4.LineStyle.Thickness = 3;
            lineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series6.View = lineSeriesView4;
            this.chart_temp.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4,
        series5,
        series6};
            this.chart_temp.Size = new System.Drawing.Size(884, 221);
            this.chart_temp.TabIndex = 12;
            chartTitle2.Alignment = System.Drawing.StringAlignment.Near;
            chartTitle2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            chartTitle2.Indent = 0;
            chartTitle2.Text = "Heat temperature °C";
            chartTitle2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            chartTitle2.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chart_temp.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // lbl_noplan
            // 
            this.lbl_noplan.AutoSize = true;
            this.lbl_noplan.BackColor = System.Drawing.Color.Transparent;
            this.lbl_noplan.Font = new System.Drawing.Font("Times New Roman", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_noplan.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbl_noplan.Location = new System.Drawing.Point(250, 50);
            this.lbl_noplan.Name = "lbl_noplan";
            this.lbl_noplan.Size = new System.Drawing.Size(359, 109);
            this.lbl_noplan.TabIndex = 13;
            this.lbl_noplan.Text = "No Plan";
            // 
            // User_Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_noplan);
            this.Controls.Add(this.chart_temp);
            this.Name = "User_Chart";
            this.Size = new System.Drawing.Size(884, 221);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_temp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chart_temp;
        private System.Windows.Forms.Label lbl_noplan;
    }
}
