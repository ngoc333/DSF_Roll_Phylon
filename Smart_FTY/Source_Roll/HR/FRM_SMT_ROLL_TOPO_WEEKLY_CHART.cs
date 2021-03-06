﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.Globalization;
//using JPlatform.Client.Controls;


namespace Smart_FTY
{
    public partial class FRM_SMT_ROLL_TOPO_WEEKLY_CHART : Form
    {
        public FRM_SMT_ROLL_TOPO_WEEKLY_CHART()
        {
            InitializeComponent();
        }

        int cnt = 0;
        string strtype1 = "", strtype2 = "", strtype3 = "";

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

        #endregion
        #region UC
        UC.UC_DWMY uc = new UC.UC_DWMY(5);

        #endregion

        private void FRM_ROLL_SLABTEST_MON_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            strtype1 = "Q_T";
            strtype2 = "C1_T";
            strtype3 = "C2_T";
            pnYMD.Controls.Add(uc);
            uc.OnDWMYClick += DWMYClick; 
        }

        void DWMYClick(string ButtonCap, string ButtonCD)
        {
            //MessageBox.Show(ButtonCap + "    " + ButtonCD);
            switch (ButtonCD)
            {
                case "C":
                    this.Hide();
                    Form fc1 = Application.OpenForms["FRM_SMT_OS_TOPO_WEEKLY"];
                    if (fc1 != null)
                        fc1.Show();
                    else
                    {
                        FRM_SMT_ROLL_TOPO_WEEKLY f1 = new FRM_SMT_ROLL_TOPO_WEEKLY();
                        f1.Show();
                    }
                    break;
                case "D":
                    this.Hide();
                    Form fc = Application.OpenForms["FRM_SMT_ROLL_TOPO_WEEKLY_CHART"];
                    if (fc != null)
                        fc.Show();
                    else
                    {
                        FRM_SMT_ROLL_TOPO_WEEKLY_CHART f = new FRM_SMT_ROLL_TOPO_WEEKLY_CHART();
                        f.Show();
                    }
                    break;
                case "W":
                    this.Hide();
                    //Form fc1 = Application.OpenForms["FRM_SMT_OS_TOPO_WEEKLY"];
                    //if (fc1 != null)
                    //    fc1.Show();
                    //else
                    //{
                    //    FRM_SMT_ROLL_TOPO_WEEKLY f1 = new FRM_SMT_ROLL_TOPO_WEEKLY();
                    //    f1.Show();
                    //}
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
                dtsource = SEL_TOPO_WEEKLY_CHART(strtype1, arg_op);
                dtsource1 = SEL_TOPO_WEEKLY_CHART(strtype2, arg_op);
                dtsource2 = SEL_TOPO_WEEKLY_CHART(strtype3, arg_op);

                grdView.DataSource = dtsource;
                formatgrid();
                if (dtsource1.Rows.Count > 0)
                {
                    // RUBBER
                    if (dtsource1.Select("DEPT = 'C'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT = 'C'", "DIV").CopyToDataTable(), chart1);
                    }
                    else
                    {
                        bindingchart(null, chart1);
                    }
                    if (dtsource1.Select("DEPT = 'M'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT = 'M'", "DIV").CopyToDataTable(), chart2);
                    }
                    else
                    {
                        bindingchart(null, chart2);
                    }
                    if (dtsource1.Select("DEPT = 'R'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT = 'R'", "DIV").CopyToDataTable(), chart3);
                    }
                    else
                    {
                        bindingchart(null, chart3);
                    }
                    // EVA
                    if (dtsource1.Select("DEPT = 'E'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT = 'E'", "DIV").CopyToDataTable(), chart4);
                    }
                    else
                    {
                        bindingchart(null, chart4);
                    }
                    if (dtsource1.Select("DEPT = 'S'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT = 'S'", "DIV").CopyToDataTable(), chart5);
                    }
                    else
                    {
                        bindingchart(null, chart5);
                    }
                    
                    //TOTAL
                    if (dtsource1.Select("DEPT = 'T'", "DIV").Count() > 0)
                    {
                        bindingchart(dtsource1.Select("DEPT = 'T'", "DIV").CopyToDataTable(), chartTotal);
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
                    bindingchart(null, chart4);
                    bindingchart(null, chart5);
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
            _chart.Series.Clear();
            _chart.Series.Add("", ViewType.Bar);
            _chart.Series[0].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            _chart.Series[0].Label.Font = new System.Drawing.Font("Tahoma", 14F);
            _chart.DataSource = dt;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                _chart.Series[0].Points.Add(new SeriesPoint(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dt.Columns[i].ColumnName.ToLower()), dt.Rows[0][i]));
                if (Convert.ToDouble(dt.Rows[0][i]) < 100)
                {
                    _chart.Series[0].Points[i].Color = Color.FromArgb(0, 255, 0);
                }
                else
                {
                    _chart.Series[0].Points[i].Color = Color.Red;
                }

            }
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
            lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd")) + "\n\r" + string.Format(DateTime.Now.ToString("HH:mm:ss"));
            if (cnt < 40)
            {
                cnt++;                
            }
            else
            {
                cnt = 0;
                BindingData("ROLL");
            }
        }

        private void FRM_ROLL_SLABTEST_MON_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    uc.YMD_Change(12);
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

        private void lblRubber_Click(object sender, EventArgs e)
        {
            try
            {
                deActiveAll();
                lblRubber.ForeColor = Color.White;
                a1Panel5.GradientEndColor = a1Panel5.GradientStartColor = Color.Black;
                strtype1 = "Q_T";
                strtype2 = "C1_T";
                strtype3 = "C2_T";
                BindingData("ROLL");
            }
            catch
            {
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                deActiveAll();
                label1.ForeColor = Color.White;
                a1Panel1.GradientEndColor = a1Panel1.GradientStartColor = Color.Black;
                strtype1 = "Q_A";
                strtype2 = "C1_A";
                strtype3 = "C2_A";
                BindingData("ROLL");
            }
            catch
            {
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                deActiveAll();
                label2.ForeColor = Color.White;
                a1Panel2.GradientEndColor = a1Panel2.GradientStartColor = Color.Black;
                strtype1 = "Q_B";
                strtype2 = "C1_B";
                strtype3 = "C2_B";
                BindingData("ROLL");
            }
            catch
            {
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                deActiveAll();
                label3.ForeColor = Color.White;
                a1Panel3.GradientEndColor = a1Panel3.GradientStartColor = Color.Black;
                strtype1 = "Q_C";
                strtype2 = "C1_C";
                strtype3 = "C2_C";
                BindingData("ROLL");
            }
            catch
            {
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                deActiveAll();
                label4.ForeColor = Color.White;
                a1Panel4.GradientEndColor = a1Panel4.GradientStartColor = Color.Black;
                strtype1 = "Q_D";
                strtype2 = "C1_D";
                strtype3 = "C2_D";
                BindingData("ROLL");
            }
            catch
            {
            }
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
            label1.ForeColor =
            label2.ForeColor =
            label3.ForeColor =
            label4.ForeColor =
            Color.Black;

        }
    }
}
