using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Diagnostics;
using System.IO;
using DevExpress.Utils;
using System.Runtime.InteropServices;
using System.Threading;
using DevExpress.XtraGauges.Core.Model;
using System.Threading;

namespace Smart_FTY
{
    public partial class Form_Home_Roll : SampleFrm1 
    {
        public Form_Home_Roll()
        {
            InitializeComponent();
            this.Text = "RunRoll";
            cmdBack.Visible = false;
        }
       
        //public static string This_Form = "Form_Home";
        //public static string This_Form_Type = "Month";
        //public static string Next_Form_Type = "Month";
        System.Data.DataSet _ds;
        private int _timeLoad =0;
        
        #region Form
        public static Dictionary<string, string> Form_Group = new Dictionary<string, string>();
        public static Dictionary<string, string> Form_Type = new Dictionary<string, string>();
        public static string FrmEvaRub = "";

        public static FRM_ROLL_SLABTEST_MONTH _frmQuality_SlabtestMonth = new FRM_ROLL_SLABTEST_MONTH();
        public static FRM_ROLL_SLABTEST_YEAR _frmQuality_SlabtestYear = new FRM_ROLL_SLABTEST_YEAR();

        public static FRM_ROLL_TALLY_SHEET _frmProduction_StatusDay = new FRM_ROLL_TALLY_SHEET();
        public static FORM_SMT_ROLL_PROD_MONTH _frmProduction_StatusMonth = new FORM_SMT_ROLL_PROD_MONTH();
        public static FORM_SMT_ROLL_PROD_YEAR _frmProduction_StatusYear = new FORM_SMT_ROLL_PROD_YEAR();

        public static FRM_RUB_TEMP_TRACKING _frmMachinery_RubTemp = new FRM_RUB_TEMP_TRACKING();
        public static FORM_EVA_TEMP_TRACKING _frmMachinery_EvaTemp = new FORM_EVA_TEMP_TRACKING();

        public static FRM_ROLL_INV_TRACKING _frmInventory = new FRM_ROLL_INV_TRACKING();

        public static FRM_SMT_B_HR_ABSENT _frmHRAbsent = new FRM_SMT_B_HR_ABSENT();

        public static FRM_SMT_ROLL_TOPO_DAILY _frmTOPO = new FRM_SMT_ROLL_TOPO_DAILY();

        public static FRM_ROLL_LEADTIME _frmLeadTime = new FRM_ROLL_LEADTIME();
        public static FRM_ROLL_COLOR_INFO_V02 _frmColorInfo = new FRM_ROLL_COLOR_INFO_V02();



        #endregion Form

        #region UC
        UC.UC_Main_Machinery2 UC_Rub1 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Rub2 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Rub3 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Rub4 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Rub5 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Rub6 = new UC.UC_Main_Machinery2();

        UC.UC_Main_Machinery2 UC_Eva1 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Eva2 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Eva3 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Eva4 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Eva5 = new UC.UC_Main_Machinery2();
        UC.UC_Main_Machinery2 UC_Eva6 = new UC.UC_Main_Machinery2();
        #endregion UC

        #region Proc

        private void addForm()
        {
            Form_Group.Add("FRM_ROLL_SLABTEST_MONTH", "101");
            Form_Group.Add("FRM_ROLL_SLABTEST_YEAR", "101");

            Form_Group.Add("FRM_ROLL_TALLY_SHEET", "201");
            Form_Group.Add("FORM_SMT_ROLL_PROD_MONTH", "201");
            Form_Group.Add("FORM_SMT_ROLL_PROD_YEAR", "201");

            
            Form_Type.Add("FRM_ROLL_SLABTEST_MONTH", "M");
            Form_Type.Add("FRM_ROLL_SLABTEST_YEAR", "Y");

            Form_Type.Add("FRM_ROLL_TALLY_SHEET", "D");
            Form_Type.Add("FORM_SMT_ROLL_PROD_MONTH", "M");
            Form_Type.Add("FORM_SMT_ROLL_PROD_YEAR", "Y");

          //  List_Form("Form_Home", FormVar._frmHome);
          //  List_Form("Form_Home", FormVar._frmHome);
        }

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

        #region Production
        private void chartGaugesProd(DataTable argDt, bool argEva, DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent argArcScale
                                 ,DevExpress.XtraGauges.Win.Base.LabelComponent argLabel
                                 ,DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent arcRangeBar)
        {
            try
            {
                argArcScale.EnableAnimation = false;
                argArcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
                argArcScale.EasingFunction = new BackEase();
                argArcScale.MinValue = 0;

                argArcScale.MaxValue = Convert.ToInt32(argDt.Rows[0]["VALUE_MAX"]);
                //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(10);
                //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(15);
                //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(20);
                argArcScale.Value = 0;
                argLabel.Text = "0";
                try
                {


                    argArcScale.MinValue = 0;
                    argArcScale.MaxValue = Convert.ToSingle(argDt.Rows[0]["VALUE_MAX"]);

                    argArcScale.EnableAnimation = true;
                    argArcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                    argArcScale.EasingFunction = new BackEase();
                    double num;
                    double.TryParse(argDt.Rows[0]["VALUE_DATA"].ToString(), out num);
                    argArcScale.Value = (float)num;
                    argLabel.Text = num.ToString() + "%";

                    if (argEva)
                    {
                        lblProEvaDPlan.Text = argDt.Rows[0]["D_PLAN"].ToString();
                        lblProEvaRPlan.Text = argDt.Rows[0]["R_PLAN"].ToString();
                        lblProEvaProd.Text = argDt.Rows[0]["PROD"].ToString();
                    }
                    else
                    {
                        lblProRubDPlan.Text = argDt.Rows[0]["D_PLAN"].ToString();
                        lblProRubRPlan.Text = argDt.Rows[0]["R_PLAN"].ToString();
                        lblProRubProd.Text = argDt.Rows[0]["PROD"].ToString();
                    }

                    if (num > 97)
                        arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Green;Style2:Green]");
                    else if (num >= 94)
                        arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Yellow;Style2:Yellow]");
                    else
                        arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Red;Style2:Red]");
                    // lblTar.Text = argDt.Rows[0]["TARGET"].ToString();
                    // lblProd.Text = argDt.Rows[0]["PROD_QTY"].ToString();
                }
                catch
                { }
            }
            catch 
            {}
            // DataTable dt = SEL_FG_DAYS_INV("014", Mline);
            
            // }
        }



        #endregion Production

        #region Inventory
        private void chartGaugesInv(DataTable argDt, bool argEva
                                     , DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent argArcScale
                                     , DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent arcRangeBar
                                     , DevExpress.XtraGauges.Win.Base.LabelComponent argLabelDay
                                     , DevExpress.XtraGauges.Win.Base.LabelComponent argLabePlan
                                     , DevExpress.XtraGauges.Win.Base.LabelComponent argLabeTon)
        {
            try
            {
            // DataTable dt = SEL_FG_DAYS_INV("014", Mline);
            argArcScale.EnableAnimation = false;
            argArcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
            argArcScale.EasingFunction = new BackEase();
            argArcScale.MinValue = 0;

           // argArcScale.MaxValue = Convert.ToInt32(argDt.Rows[0]["VALUE_MAX"]);
            //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(10);
            //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(15);
            //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(20);
            argArcScale.Value = 0;
            argLabelDay.Text = "";
            argLabePlan.Text = "";
            argLabeTon.Text = "";
            


                argArcScale.MinValue = 0;
                argArcScale.MaxValue = Convert.ToSingle(argDt.Rows[0]["VALUE_MAX"]);

                argArcScale.EnableAnimation = true;
                argArcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                argArcScale.EasingFunction = new BackEase();
                double num;
                double.TryParse(argDt.Rows[0]["VALUE_DATA"].ToString(), out num);
                argArcScale.Value = (float)num;
                argLabelDay.Text = num.ToString();
                argLabePlan.Text = argDt.Rows[0]["PLAN_DATA"].ToString();
                argLabeTon.Text = argDt.Rows[0]["INV"].ToString();

                if (num > 0.5)
                    arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Red;Style2:Red]");
                //else if (num >= 2)
                //    arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Yellow;Style2:Yellow]");
                else
                    arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Green;Style2:Green]");

                // lblTar.Text = argDt.Rows[0]["TARGET"].ToString();
                // lblProd.Text = argDt.Rows[0]["PROD_QTY"].ToString();
            }
            catch
            { }
            // }
        }

        #endregion Inventory

        #region Human Resource

        private void chartHr(DataTable argDt, DevExpress.XtraCharts.ChartControl argChart, System.Windows.Forms.Label argLbl)
        {
            try
            {
                DataTable dt = argDt.Clone();
                dt.Columns["VALUE_DATA"].DataType = typeof(double);
                foreach (DataRow row in argDt.Rows)
                    dt.ImportRow(row);

                
                argChart.DataSource = dt;
                argChart.Series[0].ArgumentDataMember = "CAPTION";
                argChart.Series[0].ValueDataMembers.AddRange(new string[] { "VALUE_DATA" });

                double iAbsentP, iAbsentN, iAttend;
                double.TryParse(dt.Rows[0][1].ToString(), out iAbsentP);
                double.TryParse(dt.Rows[1][1].ToString(), out iAbsentN);
                double.TryParse(dt.Rows[2][1].ToString(), out iAttend);
                argLbl.Text = "Total Absent\n" 
                            + (iAbsentP + iAbsentN).ToString() + " Person(s)\n"
                            + ((iAbsentP + iAbsentN) / (iAttend + iAbsentP + iAbsentN)).ToString("##0.#%");
                

                //if (iAbsent / (iAbsent + iAttend) * 100 >= 5)
                //    argChart.PaletteName = "Absent_Red";
                //else
                //    argChart.PaletteName = "Absent_Blue";
            }
            catch 
            {}
            
            //argChart.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            //DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
           // chartTitle1.Font = new System.Drawing.Font("Tahoma", 20F);
            //this.argChart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1 });
        }

        #endregion Human Resource

        #region Quality

        private void chartQuality(DataTable argDt, DevExpress.XtraCharts.ChartControl argChart)
        {
            try
            {
                if (argDt == null || argDt.Rows.Count <= 0) return;

                DataTable dt = argDt.Clone();
                dt.Columns["VALUE_DATA"].DataType = typeof(double);
                foreach (DataRow row in argDt.Rows)
                    dt.ImportRow(row);

                argChart.DataSource = dt;
                argChart.Series[0].ArgumentDataMember = "CAPTION";
                argChart.Series[0].ValueDataMembers.AddRange(new string[] { "VALUE_DATA" });
                argChart.Series[0].Points[0].Color = Color.Green;
                argChart.Series[0].Points[1].Color = Color.Red;

                
            }
            catch 
            {}

            //argChart.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            //DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            // chartTitle1.Font = new System.Drawing.Font("Tahoma", 20F);
            //this.argChart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1 });
        }

        private void setDataGridQuality(DataTable argDt, int argCol)
        {
            try
            {
                int a, b;
                int.TryParse(argDt.Rows[0]["VALUE_DATA"].ToString(), out a);
                int.TryParse(argDt.Rows[1]["VALUE_DATA"].ToString(), out b);
                axGridQuality.Col = argCol;
                axGridQuality.Row = 2;
                axGridQuality.Text = (a + b).ToString();
                axGridQuality.Row = 3;
                axGridQuality.Text = argDt.Rows[0]["VALUE_DATA"].ToString();
                axGridQuality.Row = 4;
                axGridQuality.Text = argDt.Rows[1]["VALUE_DATA"].ToString();
                axGridQuality.Row = 5;
                if (a + b == 0) axGridQuality.Text = "";
                else
                    axGridQuality.Text = Math.Round((float)b / (a + b) * 100).ToString();
            }
            catch 
            {
            }
            
        }

        #endregion Quality

        #region Machinery

        private void addUcMachinery()
        {

            try
            {
                pnMcRub1.Controls.Add(UC_Rub1);
                pnMcRub2.Controls.Add(UC_Rub2);
                pnMcRub3.Controls.Add(UC_Rub3);
                pnMcRub4.Controls.Add(UC_Rub4);
                pnMcRub5.Controls.Add(UC_Rub5);
                pnMcRub6.Controls.Add(UC_Rub6);

                pnMcEva1.Controls.Add(UC_Eva1);
                pnMcEva2.Controls.Add(UC_Eva2);
                pnMcEva3.Controls.Add(UC_Eva3);
                pnMcEva4.Controls.Add(UC_Eva4);
                pnMcEva5.Controls.Add(UC_Eva5);
                pnMcEva6.Controls.Add(UC_Eva6);
            }
            catch 
            {}
            
        }

        private string[] setArrRubber(string argName, DataTable argDt, string argMline, string argOPCD, string argMcId)
        {
            try
            {
                string[] arr = new string[3];
                string[] str_column = { "MC_ID", "VALUE" };
                DataTable dt = null;
                try
                {
                    dt = argDt.Select("MLINE_CD = '" + argMline + "' and ROLL_OP_CD = '" + argOPCD + "' and MC_ID ='" + argMcId + "'"
                                        , "MC_ID ASC").CopyToDataTable().DefaultView.ToTable(true, str_column);
                    arr[0] = argName;
                    // arr[1] = "LightGray";
                    arr[1] = dt.Rows[0]["VALUE"].ToString();
                      arr[2] = "Green";
                    //  arr[4] = dt.Rows[1]["VALUE"].ToString();
                    // arr[5] = "Green";
                }
                catch
                {
                    arr[0] = argName;
                    //arr[1] = "LightGray";
                    arr[1] = "";
                    // arr[3] = "Green";
                    //arr[4] = "";
                    // arr[5] = "Green";
                }

                return arr;
            }
            catch
            { return null; }
            
        }

        private void setDataMachineryRubber(DataTable argDt)
        {
            try
            {
                UC_Rub1.setData(setArrRubber("1st Banbury", argDt, "BB101", "BANB","001"));
                UC_Rub2.setData(setArrRubber("2nd Banbury", argDt, "BB102", "BANB", "001"));
                UC_Rub3.setData(setArrRubber("1st Roll", argDt, "BB101", "ROLL", "003"));
                UC_Rub4.setData(setArrRubber("1st Calender", argDt, "BB101", "CALD","008"));
                UC_Rub5.setData(setArrRubber("2st Calender", argDt, "BB102", "CALD", "008"));
                UC_Rub6.setData(setArrRubber("2nd Roll", argDt, "BB101", "ROLL", "007"));

                /*
                string[] str_column = { "MC_ID", "VALUE" };
                DataTable dt;
                dt = select_Data(argDt, "MLINE_CD = 'BB101' and ROLL_OP_CD = 'BANB'", "MC_ID ASC", str_column);
                UC_Rub1.setData(setArr("Banbury 1", nullToString(dt.Rows[0]["VALUE"]), "Green", dt.Rows[1]["VALUE"].ToString(), "Green"));

                dt = select_Data(argDt, "MLINE_CD = 'BB102' and ROLL_OP_CD = 'BANB'", "MC_ID ASC", str_column);
                UC_Rub2.setData(setArr("Banbury 2", dt.Rows[0]["VALUE"].ToString(), "Green", dt.Rows[1]["VALUE"].ToString(), "Green"));

                dt = select_Data(argDt, "MLINE_CD = 'BB101' and ROLL_OP_CD = 'ROLL'", "MC_ID ASC", str_column);
                UC_Rub3.setData(setArr("Roll No1", dt.Rows[0]["VALUE"].ToString(), "Green", dt.Rows[1]["VALUE"].ToString(), "Green"));

                dt = select_Data(argDt, "MLINE_CD = 'BB101' and ROLL_OP_CD = 'CALD'", "MC_ID ASC", str_column);
                UC_Rub4.setData(setArr("Calender 1", dt.Rows[0]["VALUE"].ToString(), "Green", dt.Rows[1]["VALUE"].ToString(), "Green"));

                dt = select_Data(argDt, "MLINE_CD = 'BB102' and ROLL_OP_CD = 'CALD'", "MC_ID ASC", str_column);
                UC_Rub5.setData(setArr("Calender 2", nullToString(dt.Rows[0]["VALUE"]), "Green", nullToString(dt.Rows[1]["VALUE"]), "Green"));

                dt = select_Data(argDt, "MLINE_CD = 'BB102' and ROLL_OP_CD = 'ROLL'", "MC_ID ASC", str_column);
                UC_Rub6.setData(setArr("Roll No2", nullToString(dt.Rows[0]["VALUE"]), "Green", nullToString(dt.Rows[1]["VALUE"]), "Green"));
                */
            }
            catch
            {}           
        }

        private void setDataMachineryEva(DataTable argDt)
        {
          
                string[] arr7 = { "1st Kneader", argDt.Rows[0]["KNEADER_MC"].ToString(), "Green", argDt.Rows[0]["KNEADER_MAT"].ToString(), "Black" };
                UC_Eva1.setData(arr7);
                string[] arr8 = { "2nd Kneader", argDt.Rows[1]["KNEADER_MC"].ToString(), "Black", argDt.Rows[1]["KNEADER_MAT"].ToString(), "Black" };
                UC_Eva2.setData(arr8);
                string[] arr9 = { "Roll", argDt.Rows[0]["ROLL"].ToString(), "Black", argDt.Rows[0]["ROLL"].ToString(), "Black" };
                UC_Eva3.setData(arr9);
                string[] arr10 = { "Extruder", argDt.Rows[0]["EXTRUDER"].ToString(), "Black", argDt.Rows[0]["EXTRUDER"].ToString(), "Black" };
                UC_Eva4.setData(arr10);
                string[] arr11 = { "Palletizing", argDt.Rows[0]["PELLET_SEED"].ToString(), "Black", argDt.Rows[0]["PELLET_SEED"].ToString(), "Black" };
                UC_Eva5.setData(arr11);
                string[] arr12 = { "Calender", argDt.Rows[1]["CALD_MC"].ToString(), "Black", argDt.Rows[1]["CALD_MC"].ToString(), "Black" };
                UC_Eva6.setData(arr12);
          

            
        }


        #endregion Machinery


        private void loadData()
        {
            try
            {
                System.Data.DataSet ds;
                if (_ds == null || _ds.Tables.Count == 0)
                    ds = GET_DATA("B1");
                else
                    ds = _ds.Copy();
                chartQuality(ds.Tables[0], chartQualityRub);
                setDataGridQuality(ds.Tables[0], 2);
                chartQuality(ds.Tables[1], chartQualityEva);
                setDataGridQuality(ds.Tables[1], 3);
                chartGaugesProd(ds.Tables[2], false, arcProdRub, lblProdRub, arcScaleRangeBarComponent2);
                chartGaugesProd(ds.Tables[3], true, arcProdEva, lblProdEva, arcScaleRangeBarComponent3);
                chartGaugesInv(ds.Tables[6], false, arcInvRub, arcScaleRangeBarComponent4, lblInvRubDay, lblInvRubPlan, lblInvRubTon);
                chartGaugesInv(ds.Tables[7], true, arcInvEva, arcScaleRangeBarComponent6, lblInvEvaDay, lblInvEvaPlan, lblInvEvaTon);
                chartHr(ds.Tables[8], chartHrRub, lblTotRub);
                chartHr(ds.Tables[9], chartHrEva, lblTotEva);
                setDataMachineryRubber(ds.Tables[4]);
                setDataMachineryEva(ds.Tables[5]);
            }
            catch
            {}
            //string[] arr = new string[6];
            
        }


            
    

        private void GetData()
        {
            _ds = GET_DATA("B1");

            //_t.Suspend();
        }

        #region Read File XML
        public static Dictionary<string, string>[] Init_File_XML(string str_FileName, string arg_TagName)
        {
            try
            {
                using (FileStream fs = new FileStream(str_FileName, FileMode.Open, FileAccess.Read))
                {
                    System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                    xmldoc.Load(fs);

                    //Get Configuration OF Production Form
                    Dictionary<string, string>[] rtn_VarName = new Dictionary<string, string>[xmldoc.GetElementsByTagName(arg_TagName).Count];
                    int i = 0;
                    foreach (System.Xml.XmlNode xmlnode in xmldoc.GetElementsByTagName(arg_TagName))
                    {
                        rtn_VarName[i] = new Dictionary<string, string>();
                        foreach (System.Xml.XmlElement xmllist in xmlnode.ChildNodes)
                        {
                            rtn_VarName[i].Add(xmllist.Name, xmllist.InnerText);
                        }
                        i++;
                    }
                    return rtn_VarName;
                }
            }
            catch
            {

                return null;
            }

        }

        #endregion Read File XML
       
        #endregion Proc

        #region DB
        private System.Data.DataSet GET_DATA(string argWH)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_B1_DIGITAL.SEL_DATA_FORM_MAIN";

                MyOraDB.ReDim_Parameter(11);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR2";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR3";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR4";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR5";
                MyOraDB.Parameter_Name[7] = "OUT_CURSOR6";
                MyOraDB.Parameter_Name[8] = "OUT_CURSOR7";
                MyOraDB.Parameter_Name[9] = "OUT_CURSOR8";
                MyOraDB.Parameter_Name[10] = "OUT_CURSOR9";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[6] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[7] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[8] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[9] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[10] = (int)OracleType.Cursor;


                MyOraDB.Parameter_Values[0] = argWH;
                MyOraDB.Parameter_Values[1] = "";
                MyOraDB.Parameter_Values[2] = "";
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";
                MyOraDB.Parameter_Values[5] = "";
                MyOraDB.Parameter_Values[6] = "";
                MyOraDB.Parameter_Values[7] = "";
                MyOraDB.Parameter_Values[8] = "";
                MyOraDB.Parameter_Values[9] = "";
                MyOraDB.Parameter_Values[10] = "";

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

        private DataTable LOAD_DATA_TEMP_RUB()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_OS_RUB_TEMP_TRACKING.SP_RUB_TEMP_TRACKING";
                //ARGMODE
                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "CV_1";
                MyOraDB.Parameter_Type[0] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = "";
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

        #endregion DB

        #region Event Form

        private void Form_Home_Load(object sender, EventArgs e)
        {
            try
            {
                
                pnButton.Visible = false;
                lblShift.Visible = false;
                

                GoFullscreen();
                addForm();

                Dictionary<string, string>[] dtn = Init_File_XML(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "form");
                cmdBack.Visible = Boolean.Parse(dtn[0]["cmdBack"]);

                

            }
            catch
            {
               
            }
        }
        

        private void Form_Home_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                addUcMachinery();
                lblTitle.Text = "Digital Shop Floor For Rubber Roll";
                _timeLoad = 29;
                tmrLoad.Start();
                
            }
            else
                tmrLoad.Stop();
        }



        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            _timeLoad++;
            if (_timeLoad == 30)
            {
                
                
               
                loadData();
                _timeLoad = 0;
            }
            else if (_timeLoad == 15)
            {
                try
                {
                    Thread t = new Thread(new ThreadStart(GetData));
                    t.Start();
                }
                catch
                { }
            }
            
        }



        #region Click Event

        private void cmdQuality1_Click(object sender, EventArgs e)
        {
           // showForm("FRM_ROLL_SLABTEST_MONTH");
           // _frmQuality_SlabtestMonth.Show();
            //Form_Main.Next_Form = "FRM_ROLL_SLABTEST_MONTH";
            //Form_Main.This_Form_Type = "M";
            _frmQuality_SlabtestMonth.Show();
          //  _frmQuality_SlabtestMonth.cmdMonth.Enabled = false;
            //this.Hide();
        }

        private void cmdProduction1_Click(object sender, EventArgs e)
        {
            _frmProduction_StatusDay.Show();
         //   _frmProduction_StatusDay.cmdDay.Enabled = false;
           // this.Hide();
        }

        private void cmdMachinery2_Click(object sender, EventArgs e)
        {
            _frmMachinery_RubTemp.Show();
            //this.Hide();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            _frmInventory.Show();
           // this.Hide();
        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            _frmHRAbsent.Show();
            //this.Hide();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            _frmLeadTime.Show();
        }

        #endregion Click Event

        private void groupBoxEx1_Enter(object sender, EventArgs e)
        {

        }

        



        #endregion Event Form

        private void cmdBack_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
            this.pictureBox1.Location = new Point(724, 286);
        }

        private void simpleButton4_Leave(object sender, EventArgs e)
        {
           
        }

        private void simpleButton4_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void simpleButton4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = false;
        }

        private void btnTOPO_Click(object sender, EventArgs e)
        {
            _frmTOPO.Show();
        }

        private void simpleButton46_Click(object sender, EventArgs e)
        {
            _frmColorInfo.Show();
        }

        

       
        

    }
}
