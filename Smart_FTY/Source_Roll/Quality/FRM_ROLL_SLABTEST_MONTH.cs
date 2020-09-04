using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.XtraCharts;
using System.Globalization;

namespace Smart_FTY
{
    public partial class FRM_ROLL_SLABTEST_MONTH : Form
    {
        public FRM_ROLL_SLABTEST_MONTH()
        {
            InitializeComponent();
            lblTitle.Text = "Rubber Slab Test Tracking By Month";
           
        }

        public static string _sProcess = "PH";
        public int iCount = 0;

        private void FORM_SMT_PH_PROD_MONTH_Load(object sender, EventArgs e)
        {
            //lblRubber_Click(null, null);
            //Search_Data();
            tmr_Load.Interval = 1000;
            //tmr_Load.Start();
            GoFullscreen();
        }

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

        public DataTable SEL_DATA_SLABTEST(string Qtype, string arg_ymd, string arg_op)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_ROLL.SP_ROLL_SLABTEST_MONTH_V2"; //SP_SMT_ANDON_DAILY

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMD";
                MyOraDB.Parameter_Name[2] = "V_P_OP";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = arg_ymd;
                MyOraDB.Parameter_Values[2] = arg_op;
                MyOraDB.Parameter_Values[3] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();


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

        private void formatband()
        {
            try
            {
                int n;
                DataTable dtsource = null;
                dtsource = SEL_DATA_SLABTEST("H", uc_month.GetValue().ToString(), "");
                if (dtsource != null && dtsource.Rows.Count > 0)
                {
                    string name;
                    bandMon.Caption = dtsource.Rows[0]["MON"].ToString();
                    if (dtsource.Rows.Count > 0)
                    {
                        foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in gvwView.Bands[1].Children)
                        {
                            double num;
                            if (double.TryParse(band.Caption, out num))
                            {
                                for (int i = 0; i < dtsource.Rows.Count; i++)
                                {
                                    if (band.Name.Contains(dtsource.Rows[i][0].ToString().Substring(dtsource.Rows[i][0].ToString().Length - 2)))
                                    {
                                        band.Visible = true;
                                        break;
                                    }
                                    if (i == dtsource.Rows.Count - 1)
                                    {
                                        band.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void BindingData(string arg_op)
        {
            grdView.Refresh();
            DataTable dtsource = null;
            dtsource = SEL_DATA_SLABTEST("Q", uc_month.GetValue().ToString(), arg_op);
            formatband();
            grdView.DataSource = dtsource;
            if (dtsource != null && dtsource.Rows.Count > 0)
            {

                for (int i = 0; i < gvwView.Columns.Count; i++)
                {
                    gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                    gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                    gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                }
            }
            bindingdatachart(arg_op);
        }

        private void bindingdatachart(string arg_op)
        {
            DataTable dt = null;
            dt = SEL_DATA_SLABTEST("C", uc_month.GetValue().ToString(), arg_op);
            chartSlabtest.DataSource = dt;
            chartSlabtest.Series[0].ArgumentDataMember = "YMD";
            chartSlabtest.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
            //chartControl1.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.ColumnHandle == 1)
            {
                e.Appearance.BackColor = Color.LightGray;//Color.FromArgb(80, 209, 244);
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new System.Drawing.Font("Calibri", 16, FontStyle.Bold);
            }
            else
            {

            }
        }

        private void tmr_Load_Tick(object sender, EventArgs e)
        {
            iCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (iCount >= 40)
            {
                iCount = 0;
                BindingData(_sProcess);
                //bindingdatachart(_sProcess);
            }

          
        }

       

        private void FORM_SMT_PH_PROD_MONTH_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible)
            {
                iCount = 39;
               
                if (Form_Home_Roll.FrmEvaRub == "2")
                    lbl_EVA_Click(sender, e);
                else
                    lbl_Rubber_Click(sender, e);
                tmr_Load.Start();
                //cnt = 0;
                // tmrTime.Start();
            }
            else
            {
                tmr_Load.Stop();
             //   tmrTime.Stop();
            }
        }

        private void chartSlabtest_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_", "\n");
                }
            }
            catch
            {

            }
        }

        //private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{
        //    //if (e.Column.ColumnHandle == 1)
        //    //{
        //    //    e.Appearance.BackColor = Color.LightGray;//Color.FromArgb(80, 209, 244);
        //    //    e.Appearance.ForeColor = Color.Black;
        //    //    e.Appearance.Font = new System.Drawing.Font("Calibri", 16, FontStyle.Bold);
        //    //}
        //    //else
        //    //{

        //    //}
        //}

        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {
            try
            {
                BindingData(_sProcess);
                iCount = 0;
            }
            catch
            { 
            }
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmdDay_Click(object sender, EventArgs e)
        {
            //Form fc = Application.OpenForms["FRM_ROLL_SLABTEST_MONTH"];
            //if (fc != null)
            //{
            //    fc.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    FRM_ROLL_SLABTEST_MONTH f = new FRM_ROLL_SLABTEST_MONTH();
            //    f.Show();
            //    this.Hide();
            //}
        }

        private void cmdWeek_Click(object sender, EventArgs e)
        {
            //Form fc = Application.OpenForms["FORM_SMT_ROLL_LEADTIME_WEEK"];
            //if (fc != null)
            //{

            //    fc.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    FORM_SMT_ROLL_LEADTIME_WEEK f = new FORM_SMT_ROLL_LEADTIME_WEEK();
            //    f.Show();
            //    this.Hide();
            //}
        }

        private void cmdMonth_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["FRM_ROLL_SLABTEST_MONTH"];
            if (fc != null)
            {

                fc.Show();
                this.Hide();
            }
            else
            {
                FRM_ROLL_SLABTEST_MONTH f = new FRM_ROLL_SLABTEST_MONTH();
                f.Show();
                this.Hide();
            }
        }

        private void cmdYear_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["FRM_ROLL_SLABTEST_YEAR"];
            if (fc != null)
            {

                fc.Show();
                this.Hide();
            }
            else
            {
                FRM_ROLL_SLABTEST_YEAR f = new FRM_ROLL_SLABTEST_YEAR();
                f.Show();
                this.Hide();
            }
        }

        private void lbl_Rubber_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Rubber Slab Test Tracking by Month";
            pn1.GradientEndColor = Color.White;
            pn2.GradientEndColor = Color.Gray;
            pn1.Enabled = false;
            pn2.Enabled = true;
            _sProcess = "OS";
            BindingData(_sProcess);


            ComVar.Form_Type = "1";
          
           // BindingData("OS");
           // bindingdatachart("OS");
         //   str_op = "OS";
          //  pnRubber.GradientEndColor = Color.White;//Color.FromArgb(255, 128, 128);
         //   pnEVA.GradientEndColor = Color.Gray;
          //  pnRubber.Enabled = false;
          //  pnEVA.Enabled = true;
            Form_Home_Roll.FrmEvaRub = "1";
        }

        private void lbl_EVA_Click(object sender, EventArgs e)
        {
            ComVar.Form_Type = "2";
            lblTitle.Text = "EVA Slab Test Tracking by Month";
            pn1.GradientEndColor = Color.Gray;
            pn2.GradientEndColor = Color.White;
            pn1.Enabled = true;
            pn2.Enabled = false;
            _sProcess = "PH";
            BindingData(_sProcess);

          
           // BindingData("PH");
          //  bindingdatachart("PH");
           // str_op = "PH";
          //  pnEVA.GradientEndColor = Color.White; //Color.FromArgb(255, 128, 128);
           // pnRubber.GradientEndColor = Color.Gray;
          //  pnRubber.Enabled = true;
          //  pnEVA.Enabled = false;
        }
    }
}
