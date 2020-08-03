using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
//using JPlatform.Client.Controls;


namespace Smart_FTY
{
    public partial class FRM_SMT_PH_TOPO_DAILY : SampleFrm3
    {
        public FRM_SMT_PH_TOPO_DAILY()
        {
            InitializeComponent();
        }

        public FRM_SMT_PH_TOPO_DAILY(string strChart)
        {
            week = true;
            InitializeComponent();
        }
        bool week = false;
        int cnt = 0, i_max = 0, i_min = 0;
        string str_op = "";
        string strCol = "";
        string strGroup = "";

        #region db
        public DataTable SEL_TOPO_WEEKLY_CHART(string ARG_QTYPE, string ARG_OP)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_B1.SEL_TOPO_WEEKLY_CHART";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[2] = "ARG_YMD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_OP;
                MyOraDB.Parameter_Values[2] = "";
                MyOraDB.Parameter_Values[3] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        public DataTable SEL_OS_TOPO_DAILY(string ARG_QTYPE, string ARG_OP, string ARG_GROUP)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_B1.SEL_TOPO_DAILY_NEW";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[2] = "ARG_YMD";
                MyOraDB.Parameter_Name[3] = "ARG_GROUP";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_OP;
                if (week)
                { 
                    MyOraDB.Parameter_Values[2] = "WEEK";
                }
                else
                { 
                    MyOraDB.Parameter_Values[2] = "";
                }
                MyOraDB.Parameter_Values[3] = ARG_GROUP;
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        #endregion
        #region UC
        UC.UC_DWMY uc = new UC.UC_DWMY(1);

        #endregion

        private void FRM_ROLL_SLABTEST_MON_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;


            lblTitle.Text = "TO/PO Tracking by Day";
            if (week)
            {
                this.cmdDay.Visible = false;
                this.btnWeek.Visible = false;
                lblTitle.Text = "TO/PO Tracking by Week";
            }

            uc.OnDWMYClick += DWMYClick;
            uc.YMD_Change(8);
        }

        void DWMYClick(string ButtonCap, string ButtonCD)
        {
            //MessageBox.Show(ButtonCap + "    " + ButtonCD);
            switch (ButtonCD)
            {
                case "C":
                    this.Hide();
                    break;
                case "D":
                    this.Hide();
                    Form fc = Application.OpenForms["FRM_SMT_PH_TOPO_DAILY"];
                    if (fc != null)
                        fc.Show();
                    else
                    {
                        FRM_SMT_PH_TOPO_DAILY f = new FRM_SMT_PH_TOPO_DAILY();
                        f.Show();
                    }
                    break;
                case "W":
                    this.Hide();
                    Form fc1 = Application.OpenForms["FRM_SMT_OS_TOPO_WEEKLY"];
                    if (fc1 != null)
                        fc1.Show();
                    else
                    {
                        FRM_SMT_PH_TOPO_WEEKLY f1 = new FRM_SMT_PH_TOPO_WEEKLY();
                        f1.Show();
                    }
                    break;
                case "M":
                    
                    break;
                case "Y":
                   
                    break;
            }
        }

        private void formatgrid()
        {
            for (int i = 0; i < gvwView.Columns.Count; i++)
            {
                gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 16, FontStyle.Regular);
                gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                if (i == 0)
                {
                    gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                }
                else
                {
                    gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                }
                if (i > 1)
                {
                    gvwView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gvwView.Columns[i].DisplayFormat.FormatString = "#,0";
                }
            }
        }
        
        private void BindingData(string arg_op)
        {
            try
            {
                grdView.Refresh();
                DataTable dtsource = null, dtsource1 = null, dtsource2 = null;

                if (week)
                {   
                    dtsource = SEL_OS_TOPO_DAILY("Q", arg_op, strGroup);
                    dtsource1 = SEL_OS_TOPO_DAILY("C", arg_op, strGroup);
                    dtsource2 = SEL_OS_TOPO_DAILY("C1", arg_op, strGroup);                
                }
                else
                {
                    dtsource = SEL_OS_TOPO_DAILY("Q", arg_op, strGroup);
                    dtsource1 = SEL_OS_TOPO_DAILY("C", arg_op, strGroup);
                    dtsource2 = SEL_OS_TOPO_DAILY("C1", arg_op, strGroup);     
                }

                grdView.DataSource = dtsource;
                formatgrid();
                if (dtsource1.Rows.Count > 0)
                {
                    // CMP
                    if (dtsource1.Select("DEPT LIKE 'CMP PRESS%'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT LIKE 'CMP PRESS%'", "DIV").CopyToDataTable(), chart1);
                    }
                    else
                    {
                        bindingchart(null, chart1);
                    }
                    if (dtsource1.Select("DEPT LIKE 'CMP SUPPORT%'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT LIKE 'CMP SUPPORT%'", "DIV").CopyToDataTable(), chart2);
                    }
                    else
                    {
                        bindingchart(null, chart2);
                    }
                     
                    // PHYLON
                    if (dtsource1.Select("DEPT LIKE 'PHYLON PRESS%'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT LIKE 'PHYLON PRESS%'", "DIV").CopyToDataTable(), chart3);
                    }
                    else
                    {
                        bindingchart(null, chart3);
                    }

                    if (dtsource1.Select("DEPT LIKE 'PHYLON PAD PRINTING%'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT LIKE 'PHYLON PAD PRINTING%'", "DIV").CopyToDataTable(), chart4);
                    }
                    else
                    {
                        bindingchart(null, chart4);
                    }

                    if (dtsource1.Select("DEPT LIKE 'PHYLON UV%'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT LIKE 'PHYLON UV%'", "DIV").CopyToDataTable(), chart5);
                    }
                    else
                    {
                        bindingchart(null, chart5);
                    }


                    if (dtsource1.Select("DEPT LIKE 'PHYLON SPRAY%'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT LIKE 'PHYLON SPRAY%'", "DIV").CopyToDataTable(), chart6);
                    }
                    else
                    {
                        bindingchart(null, chart6);
                    }

                    if (dtsource1.Select("DEPT LIKE 'PHYLON SUPPORT%'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT LIKE 'PHYLON SUPPORT%'", "DIV").CopyToDataTable(), chart7);
                    }
                    else
                    {
                        bindingchart(null, chart7);
                    }   
                    //TOTAL
                    if (dtsource1.Select("DEPT = 'Total'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT = 'Total'", "DIV").CopyToDataTable(), chartTotal);
                    }
                    else
                    {
                        bindingchart(null, chartTotal);
                    }
                }
                else
                {
                    bindingchart(null, chart1);
                    bindingchart(null, chart2);
                    bindingchart(null, chart3);
                    bindingchart(null, chartTotal);
                }
                bindingchart2(dtsource2, chartRatio);

            }
            catch { }
        }

        private void bindingchart(DataTable dt, ChartControl _chart )
        {
            _chart.DataSource = dt;
            _chart.Series[0].ArgumentDataMember = "DIV";
            _chart.Series[0].ValueDataMembers.AddRange(new string[] { "TO_QTY" });
            _chart.Series[1].ArgumentDataMember = "DIV";
            _chart.Series[1].ValueDataMembers.AddRange(new string[] { "PO_QTY" });            
        }

        private void bindingchart2(DataTable dt, ChartControl _chart)
        {
            //_chart.DataSource = dt;
            //_chart.Series[0].ArgumentDataMember = "SHIFT";
            //_chart.Series[0].ValueDataMembers.AddRange(new string[] { "PO_QTY" });


            _chart.Series.Clear();
            Series series2 = new Series("Ratio", ViewType.Bar);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                series2.Points.Add(new SeriesPoint(dt.Columns[i].ColumnName, dt.Rows[0][i].ToString()));

                if (double.Parse(dt.Rows[0][i].ToString()) > 100.0)
                {
                    series2.Points[i].Color = Color.Red;
                }
                else
                {
                    series2.Points[i].Color = Color.Green;
                }

            }

            _chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series2 };
            //series2.Label = sideBySideBarSeriesLabel1;
            series2.Label.Font = new Font("Calibri", 12.25F, System.Drawing.FontStyle.Regular);
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvwView.GetRowCellValue(e.RowHandle, "DIV").ToString().ToUpper().Contains("TOTAL"))
            {
                e.Appearance.BackColor = Color.FromArgb(255, 224, 192);
                e.Appearance.ForeColor = Color.Black;
            }
            
            if (e.Column.FieldName.Contains("BAL"))
            {
                if (e.CellValue.ToString() != "")
                {
                    if (Convert.ToDouble(e.CellValue.ToString()) < 0)
                    {
                        e.Appearance.BackColor = Color.FromArgb(0, 255, 0);
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else if (Convert.ToDouble(e.CellValue.ToString()) > 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            else
            {
                
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd")) + "\n\r" + string.Format(DateTime.Now.ToString("HH:mm:ss"));
            if (cnt < 40)
            {
                cnt++;                
            }
            else
            {
                cnt = 0;
                BindingData("PHP");
            }
        }

        private void FRM_ROLL_SLABTEST_MON_VisibleChanged(object sender, EventArgs e)
        {
            try
            {

                uc.YMD_Change(8);
                if (this.Visible)
                {
                    strGroup = "TOTAL";
                    timer1.Start();
                    cnt = 40;
                }
                else
                    timer1.Stop();
            }
            catch
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            strGroup = "A";
            cnt = 40;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            strGroup = "B";
            cnt = 40;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            strGroup = "C";
            cnt = 40;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            strGroup = "DAY";
            cnt = 40;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            strGroup = "TOTAL";
            cnt = 40;
        }

        private void lblRubber_Click(object sender, EventArgs e)
        {
            deActiveAll();
            a1Panel5.GradientEndColor = a1Panel5.GradientStartColor = Color.Black;
            lblRubber.ForeColor = Color.White;
            strGroup = "TOTAL";
            cnt = 40;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            deActiveAll();
            a1Panel1.GradientEndColor = a1Panel1.GradientStartColor = Color.Black;
            label9.ForeColor = Color.White;
                
            strGroup = "A";
            cnt = 40;
        }

        private void label8_Click(object sender, EventArgs e)
        {

            deActiveAll();
            a1Panel2.GradientEndColor = a1Panel2.GradientStartColor = Color.Black;
            label8.ForeColor = Color.White;
            strGroup = "B";
            cnt = 40;
        }

        private void label7_Click(object sender, EventArgs e)
        {

            deActiveAll();
            a1Panel3.GradientEndColor = a1Panel3.GradientStartColor = Color.Black;
            label7.ForeColor = Color.White;
            strGroup = "C";
            cnt = 40;
        }

        private void label6_Click(object sender, EventArgs e)
        {

            deActiveAll();
            a1Panel4.GradientEndColor = a1Panel4.GradientStartColor = Color.Black;
            label6.ForeColor = Color.White;
            strGroup = "DAY";
            cnt = 40;
        }


        private void deActiveAll()
        {
            a1Panel1.GradientEndColor = a1Panel1.GradientStartColor =
            a1Panel2.GradientEndColor = a1Panel2.GradientStartColor =
            a1Panel3.GradientEndColor = a1Panel3.GradientStartColor =
            a1Panel4.GradientEndColor = a1Panel4.GradientStartColor =
            a1Panel5.GradientEndColor = a1Panel5.GradientStartColor =
            Color.White;

            lblRubber.ForeColor =
            label9.ForeColor =
            label8.ForeColor =
            label7.ForeColor =
            label6.ForeColor =
            Color.Black;

        }
    }
}
