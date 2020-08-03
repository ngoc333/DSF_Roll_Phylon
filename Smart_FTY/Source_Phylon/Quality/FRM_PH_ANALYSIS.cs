using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using JPlatform.Client.Controls;


namespace Smart_FTY
{
    public partial class FRM_PH_ANALYSIS : Form_Parent
    {
        public FRM_PH_ANALYSIS()
        {
            InitializeComponent();
            lblTitle.Text = "";
        }

        int cnt = 0;
        string str_op = "";

        private void FRM_ROLL_SLABTEST_MON_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            cmdDay.Visible = false;

        }

        public DataTable SEL_DATA_SLABTEST(string Qtype, string arg_ymd, string arg_op)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_B1.SP_PH_OSD_MONTH_V2"; //SP_SMT_ANDON_DAILY

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

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        public DataSet SEL_DATA_ANALYSIS(string Qtype, string arg_ymd, string arg_op)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_B1.SP_PH_ANALYSIS_MONTH_V2"; //SP_SMT_ANDON_DAILY

                MyOraDB.ReDim_Parameter(9);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMD";
                MyOraDB.Parameter_Name[2] = "V_P_OP";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR2";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR3";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR4";
                MyOraDB.Parameter_Name[7] = "OUT_CURSOR5";
                MyOraDB.Parameter_Name[8] = "OUT_CURSOR6";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[6] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[7] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[8] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = arg_ymd;
                MyOraDB.Parameter_Values[2] = arg_op;
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";
                MyOraDB.Parameter_Values[5] = "";
                MyOraDB.Parameter_Values[6] = "";
                MyOraDB.Parameter_Values[7] = "";
                MyOraDB.Parameter_Values[8] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch
            {
                return null;
            }
        }

        private void formatband()
        {
            
        }

        private void BindingData(string arg_op)
        {
            
        }

        private void bindingdatachart(string arg_op,DataTable dt, DevExpress.XtraCharts.ChartControl chart)
        {
            chart.DataSource = dt;
            chart.Series[0].ArgumentDataMember = "DIV";
            chart.Series[0].ValueDataMembers.AddRange(new string[] { "QTY_I" });

            chart.Series[1].ArgumentDataMember = "DIV";
            chart.Series[1].ValueDataMembers.AddRange(new string[] { "QTY_E" });
            ((DevExpress.XtraCharts.XYDiagram)chart.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
            
        }

        private void bindingdatachartV2(string arg_op, DataTable dt, DevExpress.XtraCharts.ChartControl chart)
        {
            chart.DataSource = dt;
            chart.Series[0].ArgumentDataMember = "DIV";
            chart.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
            ((DevExpress.XtraCharts.XYDiagram)chart.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;

            

        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
        //    if (e.Column.ColumnHandle == 1)
        //    {
        //        e.Appearance.BackColor = Color.LightGray;//Color.FromArgb(80, 209, 244);
        //        e.Appearance.ForeColor = Color.Black;
        //        e.Appearance.Font = new System.Drawing.Font("Calibri", 16, FontStyle.Bold);
        //    }
        //    else
        //    {
                
        //    }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitle.Text = "Phylon Analysis by Month";
            if (cnt < 120)
            {
                cnt++;                
            }
            else
            {
                cnt = 0;
                //if (Form_Home_Phylon._type == "CMP")
                //    lblCMP_Click(null, null);
                //else
                    lblPhylon_Click(null, null);
                //BindingData(str_op);
                //bindingdatachart(str_op);
            }
        }

        private void FRM_ROLL_SLABTEST_MON_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    //lblRubber_Click(sender, e);
                    //BindingData("PHP");
                    //bindingdatachart("PHP");
                    //str_op = "PHP";
                    //lblTitle.Text = "Phylon External OS&&D by Month";
                    //timer1.Start();
                    cnt = 120;
                }
                else
                    timer1.Stop();
            }
            catch
            {

            }
        }

        private void lblCMP_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "CMP Analysis by Month";
            BindingData("CMP");
            //bindingdatachart("CMP", SEL_DATA_ANALYSIS("C1", uc_month.GetValue().ToString(), "CMP"), chartModel);
            //bindingdatachart("CMP", SEL_DATA_ANALYSIS("C2", uc_month.GetValue().ToString(), "CMP"), chartType);
            //bindingdatachartV2("CMP", SEL_DATA_ANALYSIS("C3", uc_month.GetValue().ToString(), "CMP"), chartPlant);
            //bindingdatachartV2("CMP", SEL_DATA_ANALYSIS("C4", uc_month.GetValue().ToString(), "CMP"), chartMachine);
            //bindingdatachartV2("CMP", SEL_DATA_ANALYSIS("C5", uc_month.GetValue().ToString(), "CMP"), chartShift);
            //bindingdatachartV2("CMP", SEL_DATA_ANALYSIS("C6", uc_month.GetValue().ToString(), "CMP"), chartHour);
            //bindingdatachart("CMP");
            str_op = "CMP";
            Form_Home_Phylon._type = "CMP";

        }

        private void lblPhylon_Click(object sender, EventArgs e)
        {
            //lblTitle.Text = "Phylon Analysis by Month";
            //BindingData("PHP");
            DataSet ds = SEL_DATA_ANALYSIS("C1", uc_month.GetValue().ToString(), "PHP");
            if (ds != null)
            {
                bindingdatachart("PHP", ds.Tables[0], chartModel);
                bindingdatachart("PHP", ds.Tables[1], chartType);
                bindingdatachartV2("PHP", ds.Tables[2], chartPlant);
                bindingdatachartV2("PHP", ds.Tables[3], chartMachine);
                bindingdatachartV2("PHP", ds.Tables[4], chartShift);
                bindingdatachartV2("PHP", ds.Tables[5], chartHour);
            }
            str_op = "PHP";
            //lblTitle.Text = "Phylon Analysis by Month";
            Form_Home_Phylon._type = "PHP";
        }

        private void cmdMonth_Click(object sender, EventArgs e)
        {

        }

        private void cmdYear_Click(object sender, EventArgs e)
        {
            //FRM_PH_OSD_EXT_YEAR OSD_Y = new 
        }

        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {
            try
            {
                cnt = 0;
                //if (Form_Home_Phylon._type == "CMP")
                //    lblCMP_Click(null, null);
                //else
                    lblPhylon_Click(null, null);
            }
            catch
            {
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //private void lblRubber_Click(object sender, EventArgs e)
        //{
        //    //lblTitle.Text = "Rubber Slabtest Tracking by Month";
        //    BindingData("OS");
        //    bindingdatachart("OS");
        //    str_op = "OS";
        //    pnRubber.GradientEndColor = Color.White;//Color.FromArgb(255, 128, 128);
        //    pnEVA.GradientEndColor = Color.Gray;
        //}

        //private void lblEVA_Click(object sender, EventArgs e)
        //{
        //    //lblTitle.Text = "EVA Slabtest Tracking by Month";
        //    BindingData("PH");
        //    bindingdatachart("PH");
        //    str_op = "PH";
        //    pnEVA.GradientEndColor = Color.White; //Color.FromArgb(255, 128, 128);
        //    pnRubber.GradientEndColor = Color.Gray;
        //}

        //private void cmdYear_Click(object sender, EventArgs e)
        //{

        //}
    }
}
