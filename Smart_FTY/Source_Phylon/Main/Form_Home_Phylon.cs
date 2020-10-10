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
using Smart_FTY.Source_Phylon;


namespace Smart_FTY
{
    public partial class Form_Home_Phylon : SampleFrm1 
    {

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); 
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnon);

        public Form_Home_Phylon( )
        {
            InitializeComponent();
            this.Text = "RunPH";
            //cmdBack.Visible = false;
        }
        
        //public static string This_Form = "Form_Home";
        //public static string This_Form_Type = "Month";
        //public static string Next_Form_Type = "Month";
        Process _procCMP = null;
        private int _timeLoad =0;
        bool _load = true;
        DataSet _ds;
        public const int SW_MAXIMIZE = 3;

        #region Add Form
        public static string _type = "CMP";

        public static Dictionary<string, string> Form_Group = new Dictionary<string, string>();
        public static Dictionary<string, string> Form_Type = new Dictionary<string, string>();
        public static string FrmEvaRub = "";

        public static FRM_SMT_BTS _frmBTS = new FRM_SMT_BTS();
        public static FRM_PH_PROD_DAILY _frmProd_Day = new FRM_PH_PROD_DAILY();
        public static FORM_SMT_PH_PROD_MONTH _frmProd_In_Month = new FORM_SMT_PH_PROD_MONTH();
        public static FORM_SMT_PH_PROD_YEAR _frmProd_In_Year = new FORM_SMT_PH_PROD_YEAR();
     
        public static FRM_PH_OSD_MONTH _frmQua_In_OSD_Month = new FRM_PH_OSD_MONTH();
        public static FRM_PH_OSD_YEAR _frmQua_In_OSD_Year = new FRM_PH_OSD_YEAR();

        public static FRM_PH_OSD_EXT_YEAR _frmQua_Ex_OSD_Year = new FRM_PH_OSD_EXT_YEAR();
        public static FRM_PH_OSD_EXT_MONTH _frmQua_Ex_OSD_Month = new FRM_PH_OSD_EXT_MONTH();



        public static FRM_SMT_PH_OEE _frmMc_OEE_Month = new FRM_SMT_PH_OEE();
        public static FRM_SMT_PH_OEE_YEAR _frmMc_OEE_Year = new FRM_SMT_PH_OEE_YEAR();

        public static FORM_PH_MOLD_REPAIR _frmQua_Mold = new FORM_PH_MOLD_REPAIR();

        public static FORM_SMT_B_MOLD_LAYOUT _frmPro_MoldLayout = new FORM_SMT_B_MOLD_LAYOUT("1");

        public static FORM_SMT_B_MOLD_ACTUAL_PLAN _frmPro_MoldActualPlan = new FORM_SMT_B_MOLD_ACTUAL_PLAN();

        public static FRM_PH_TEMP _frmMc_Temp = new FRM_PH_TEMP();

        public static FRM_SMT_B_PH_HR_ABSENT _frmHr_Absent = new FRM_SMT_B_PH_HR_ABSENT();

        public static FRM_SMT_PH_TOPO_DAILY _frmHr_TOPO = new FRM_SMT_PH_TOPO_DAILY();

        public static FRM_SMT_PH_TOPO_WEEKLY _frmTOPO_Week = new FRM_SMT_PH_TOPO_WEEKLY();

        public static FRM_SMT_PH_TOPO_DAILY _frmTOPO = new FRM_SMT_PH_TOPO_DAILY();

        public static FORM_SMT_B_PHP_INV _frmInv = new FORM_SMT_B_PHP_INV();
        //public static FORM_SMT_B_PHP_INV_TRACKING _frmInv_Tracking = new FORM_SMT_B_PHP_INV_TRACKING();
        public static FRM_BOTTOM_INV_SET_ANALYSIS _frmInv_Tracking = new FRM_BOTTOM_INV_SET_ANALYSIS();
        public static FORM_SMT_PH_LEADTIME _frmLeadTime = new FORM_SMT_PH_LEADTIME();

        FORM_PH_KPI_PERFOMANCE _frmKPI = new FORM_PH_KPI_PERFOMANCE();

        Form_Home_Phylon_Das _frmPhylonDas_1 = new Form_Home_Phylon_Das("A", "Digital Shop Floor For Phylon Workshop 1");
        Form_Home_Phylon_Das _frmPhylonDas_2 = new Form_Home_Phylon_Das("B", "Digital Shop Floor For Phylon Workshop 2");
        DIGITAL_SHOP_FLOOR _frmPhylonDas_3 = new DIGITAL_SHOP_FLOOR();

        //public static FRM_ROLL_SLABTEST_MONTH _frmQuality_SlabtestMonth = new FRM_ROLL_SLABTEST_MONTH();
        //public static FRM_ROLL_SLABTEST_YEAR _frmQuality_SlabtestYear = new FRM_ROLL_SLABTEST_YEAR();

        //public static FRM_ROLL_TALLY_SHEET _frmProduction_StatusDay = new FRM_ROLL_TALLY_SHEET();
        //public static FORM_SMT_B_PROD_MONTHLY _frmProduction_StatusMonth = new FORM_SMT_B_PROD_MONTHLY();
        //public static FORM_SMT_B_PROD_YEARLY _frmProduction_StatusYear = new FORM_SMT_B_PROD_YEARLY();

        //public static FRM_RUB_TEMP_TRACKING _frmMachinery_RubTemp = new FRM_RUB_TEMP_TRACKING();
        //public static FORM_EVA_TEMP_TRACKING _frmMachinery_EvaTemp = new FORM_EVA_TEMP_TRACKING();

        //public static FRM_ROLL_INV_TRACKING _frmInventory = new FRM_ROLL_INV_TRACKING();

        //public static FRM_SMT_B_HR_ABSENT _frmHRAbsent= new FRM_SMT_B_HR_ABSENT();

        private void addForm()
        {

            Form_Group.Add("FORM_SMT_PH_PROD_MONTH", "201");
            Form_Group.Add("FORM_SMT_PH_PROD_YEAR", "201");
            Form_Group.Add("FRM_PH_PROD_DAILY", "201");

          //  Form_Group.Add("FRM_PH_OSD_MONTH", "101");
           // Form_Group.Add("FRM_PH_OSD_YEAR", "101");

            Form_Group.Add("FRM_PH_OSD_EXT_MONTH", "102");
            Form_Group.Add("FRM_PH_OSD_EXT_YEAR", "102");

            Form_Group.Add("FRM_SMT_PH_OEE", "301");
            Form_Group.Add("FRM_SMT_PH_OEE_YEAR", "301");

            Form_Group.Add("FRM_SMT_PH_TOPO_DAILY", "401");
            Form_Group.Add("FRM_SMT_PH_TOPO_WEEKLY", "401");

            Form_Type.Add("FORM_SMT_PH_PROD_MONTH", "M");
            Form_Type.Add("FORM_SMT_PH_PROD_YEAR", "Y");
            Form_Type.Add("FRM_PH_PROD_DAILY", "D");

            Form_Type.Add("FRM_PH_OSD_MONTH", "M");
            Form_Type.Add("FRM_PH_OSD_EXT_YEAR", "Y");

            Form_Type.Add("FRM_PH_OSD_EXT_MONTH", "M");
            Form_Type.Add("FRM_PH_OSD_YEAR", "Y");

            Form_Type.Add("FRM_SMT_PH_OEE", "M");
            Form_Type.Add("FRM_SMT_PH_OEE_YEAR", "Y");

            Form_Type.Add("FRM_SMT_PH_TOPO_DAILY", "D");
            Form_Type.Add("FRM_SMT_PH_TOPO_WEEKLY", "W");



            //  List_Form("Form_Home", FormVar._frmHome);
            //  List_Form("Form_Home", FormVar._frmHome);
        }


        #endregion Add Form

        

        #region Proc

        private void getDataThread()
        {
            _ds = GET_DATA("B1");
        }
        private void loadData()
        {
            try
            {
                System.Data.DataSet ds;
                if (_ds == null || _ds.Tables.Count == 0)
                    ds = GET_DATA("B1");
                else
                    ds = _ds.Copy();
                //OSD

                

                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    lblOSDPlanCmp.Text = Convert.ToDouble(ds.Tables[0].Rows[1]["VALUE_DATA"].ToString()).ToString("###,###,###") + " Prs";
                    lblOSDCmp.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["VALUE_DATA"].ToString()).ToString("###,###,###") + " Prs";
                    chartOSD2(ds.Tables[0], arcScale_ValCmp, lbl_ScaleCmp);
                }
                if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                {
                    lblOSDPlanPh.Text = Convert.ToDouble(ds.Tables[1].Rows[1]["VALUE_DATA"].ToString()).ToString("###,###,###") + " Prs";
                    lblOSDPh.Text = Convert.ToDouble(ds.Tables[1].Rows[0]["VALUE_DATA"].ToString()).ToString("###,###,###") + " Prs";
                    chartOSD2(ds.Tables[1], arcScale_ValPh, lbl_ScalePh);
                }
                //Produciton
                if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0) 
                    chartGaugesProd(ds.Tables[2], false, arcProdRub, lblProdRub, arcScaleRangeBarComponent2, "CMP" );
                if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                    chartGaugesProd(ds.Tables[3], true, arcProdEva, lblProdEva, arcScaleRangeBarComponent3, "PHP");

                //POD
                if (ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0) 
                    chartPOD(arcScaleCompCmp, lblPodCmp, ds.Tables[4].Rows[0]["qty"].ToString()
                            , ds.Tables[4].Rows[0]["yellow_qty"].ToString(), ds.Tables[4].Rows[0]["Green_qty"].ToString(), ds.Tables[4].Rows[0]["max_qty"].ToString());
                if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0) 
                    chartPOD(arcScaleCompPhy, lblPodPhy, ds.Tables[5].Rows[0]["qty"].ToString()
                           , ds.Tables[5].Rows[0]["yellow_qty"].ToString(), ds.Tables[5].Rows[0]["green_qty"].ToString(), ds.Tables[5].Rows[0]["max_qty"].ToString());

                //Inventory
                if (ds.Tables[6] != null && ds.Tables[6].Rows.Count > 0) 
                    chartGaugesInv(ds.Tables[6], false, arcInvCmp, arcScaleRangeBarComponent4, lblInvRubDay, lblInvRubPlan, lblInvRubTon);
                if (ds.Tables[7] != null && ds.Tables[7].Rows.Count > 0) 
                    chartGaugesInv(ds.Tables[7], true, arcInvPhy, arcScaleRangeBarComponent6, lblInvEvaDay, lblInvEvaPlan, lblInvEvaTon);
                //Human Resource
                if (ds.Tables[8] != null && ds.Tables[8].Rows.Count > 0) 
                    chartHr(ds.Tables[8], chartHrCmp);
                if (ds.Tables[9] != null && ds.Tables[9].Rows.Count > 0) 
                chartHr(ds.Tables[9], chartHrPhy);
            }
            catch 
            {
               
            }
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
                                 ,DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent arcRangeBar
                                 , string arg_op_cd)
        {

            DataTable dt = LOAD_DATA_PRODUCTION(arg_op_cd);
             if (dt == null || dt.Rows.Count == 0) return;

            argArcScale.EnableAnimation = false;
            argArcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
            argArcScale.EasingFunction = new BackEase();
            argArcScale.MinValue = 0;
            
            //argArcScale.MaxValue = Convert.ToInt32(argDt.Rows[0]["VALUE_MAX"]) ;
            //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(10);
            //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(15);
            //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(20);
            argArcScale.Value = 0;
            argLabel.Text = "0";
            try
            {
            

                argArcScale.MinValue = 0;
                argArcScale.MaxValue = Convert.ToInt32(argDt.Rows[0]["VALUE_MAX"]);

                argArcScale.EnableAnimation = true;
                argArcScale.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                argArcScale.EasingFunction = new BackEase();
                double num;
                double.TryParse(dt.Rows[0]["TOT_RATE"].ToString().Replace("%",""), out num);
                argArcScale.Value = (float)num;
                argLabel.Text = num.ToString() + "%";

                if (argEva)
                {
                    lblProPhyDPlan.Text = dt.Rows[0]["TOT_PLAN"].ToString() + " Prs";
                    lblProPhyRPlan.Text = dt.Rows[0]["TOT_RPLAN"].ToString() + " Prs";
                    lblProPhyProd.Text = dt.Rows[0]["TOT_ACT"].ToString() + " Prs";
                }
                else
                {
                    lblProCmpDPlan.Text = dt.Rows[0]["TOT_PLAN"].ToString() + " Prs";
                    lblProCmpRPlan.Text = dt.Rows[0]["TOT_RPLAN"].ToString() + " Prs";
                    lblProCmpProd.Text = dt.Rows[0]["TOT_ACT"].ToString() + " Prs";
                }

                if (num>= 98)
                    arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Green;Style2:Green]");
                else if (num>= 95)
                    arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Yellow;Style2:Yellow]");
                else
                    arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Red;Style2:Red]");
               // lblTar.Text = argDt.Rows[0]["TARGET"].ToString();
               // lblProd.Text = argDt.Rows[0]["PROD_QTY"].ToString();
            }
            catch 
            { }
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

            //argArcScale.MaxValue = Convert.ToInt32(argDt.Rows[0]["VALUE_MAX"]);
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
                argLabelDay.Text = num.ToString("0.00");
                argLabePlan.Text = argDt.Rows[0]["PLAN_DATA"].ToString();
                argLabeTon.Text = argDt.Rows[0]["INV"].ToString();
                // lblTar.Text = argDt.Rows[0]["TARGET"].ToString();
                // lblProd.Text = argDt.Rows[0]["PROD_QTY"].ToString();
                
                if (argDt.Rows[0]["Factory"].ToString() =="CMP")
                    if (num > 1)
                        arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Red;Style2:Red]");
                    //else if (num >= 2)
                    //    arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Yellow;Style2:Yellow]");
                    else
                        arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Green;Style2:Green]");
                else if (argDt.Rows[0]["Factory"].ToString() =="PHP")
                    if (num > 2.5)
                        arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Red;Style2:Red]");
                    //else if (num >= 2)
                    //    arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Yellow;Style2:Yellow]");
                    else
                        arcRangeBar.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:Green;Style2:Green]");
                
            }
            catch
            { }
            // }
        }

        #endregion Inventory

        #region Human Resource

        private void chartHr(DataTable argDt, DevExpress.XtraCharts.ChartControl argChart)
        {
            try
            {
                double totalMain = 0;
                object sum1;
                string strTotal = "";

                DataTable dt = argDt.Clone();
                dt.Columns["VALUE_DATA"].DataType = typeof(double);
                foreach (DataRow row in argDt.Rows)
                    dt.ImportRow(row);

                argChart.DataSource = dt;
                argChart.Series[0].ArgumentDataMember = "CAPTION";
                argChart.Series[0].ValueDataMembers.AddRange(new string[] { "VALUE_DATA" });

                double iAbsent, iAttend;
                double.TryParse(dt.Rows[0][1].ToString(), out iAbsent);
                double.TryParse(dt.Rows[1][1].ToString(), out iAttend);


                totalMain = iAbsent + iAttend;

                //strTotal = "Total Absent :" + totalMain.ToString();
                //strTotal += "\n" + (Math.Round(totalMain / double.Parse(dt.Rows[1][1].ToString()), 1)).ToString() + "%";

                strTotal = "Total Absent\n"
                            + totalMain.ToString() + " Person(s)\n"
                            + (Math.Round(totalMain * 100 / (totalMain + double.Parse(dt.Rows[2][1].ToString())), 1)).ToString() + " %";



                if (argChart.Name == "chartHrCmp")
                {
                    lblCMPTongnguoi.Text = strTotal;
                }
                else
                {
                    lblSonguoi.Text = strTotal;   //PHP
                }
                 
                //if (iAbsent / (iAbsent + iAttend) * 100 >= 5)
                //    argChart.PaletteName = "Absent_Red";
                //else
                //    argChart.PaletteName = "Absent_Blue";
            }
            catch
            {
            }
            
            //argChart.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            //DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
           // chartTitle1.Font = new System.Drawing.Font("Tahoma", 20F);
            //this.argChart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1 });
        }

        #endregion Human Resource

        #region OSD

        private void chartOSD(DataTable argDt, DevExpress.XtraCharts.ChartControl argChart)
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
            }
            catch 
            {
            }
        }

        private void chartOSD2(DataTable argDt, DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent
                                    
                                    , DevExpress.XtraGauges.Win.Base.LabelComponent arglbl                                   
                                    )
        {
            try
            {
                //Chart Per

                
                if (argDt.Rows.Count > 0)
                {
                    arcScaleComponent.Ranges.Clear();

                    DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
                    arcScaleComponent.EnableAnimation = false;
                    arcScaleComponent.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                    arcScaleComponent.EasingFunction = new BackEase();
                    arglbl.Text = "0";
                    arcScaleComponent.Value = 0;

                    double dProd, dOsd;
                    double.TryParse(argDt.Rows[0][1].ToString(), out dOsd);
                    double.TryParse(argDt.Rows[1][1].ToString(), out dProd);
                    float fValue = Convert.ToSingle(Math.Round(dOsd / (dOsd + dProd)*100,0));

                    arcScaleComponent.EnableAnimation = true;
                    arcScaleComponent.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                    arcScaleComponent.EasingFunction = new BackEase();
                    arcScaleComponent.Value =fValue;

                    arglbl.Text = fValue + "%";


                    arcScaleRange.StartThickness = 18;
                    arcScaleRange.EndThickness = 18;
                    arcScaleRange.StartValue = 0;
                    arcScaleRange.Name = "Range0";
                    arcScaleRange.ShapeOffset = 29F;
                    if (fValue > 4)
                        arcScaleRange.EndValue = 4;
                    else
                        arcScaleRange.EndValue = fValue;
                    if (fValue < Convert.ToDouble(argDt.Rows[0]["Target"].ToString()))
                    {
                        arcScaleRange.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Green");
                       
                        arcScaleComponent.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] { arcScaleRange });
                        arglbl.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Green");
                    }
                    else
                    {
                        arcScaleRange.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
                        
                        arcScaleComponent.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] { arcScaleRange });
                        arglbl.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
                    }
                }
            }
            catch
            {
            }
        }
        

        #endregion OSD

        #region POD
        private void chartPOD(DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent
                                    , DevExpress.XtraGauges.Win.Base.LabelComponent arglbl
                                    , string argPer, string argYellow, string argGreen, string argMax)
        {
            try
            {

                //Chart Per
                arcScaleComponent.EnableAnimation = false;
                arcScaleComponent.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleComponent.EasingFunction = new BackEase();
                arglbl.Text = "0";
                arcScaleComponent.Value = 0;

                arcScaleComponent.EnableAnimation = true;
                arcScaleComponent.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleComponent.EasingFunction = new BackEase();
                arglbl.Text = argPer;

                arcScaleComponent.MaxValue = Convert.ToSingle(argMax);

                float fValue = Convert.ToSingle(argPer);
                arcScaleComponent.Value = fValue;


                DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
                arcScaleComponent.Ranges.Clear();
                arcScaleRange.StartThickness = 18;
                arcScaleRange.EndThickness = 18;
                arcScaleRange.Name = "Range0";
                arcScaleRange.ShapeOffset = -10F;
                arcScaleRange.EndValue = fValue;
                if (fValue >= Convert.ToDouble(argGreen))
                {
                    arcScaleRange.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Green");
                    
                    arcScaleComponent.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] { arcScaleRange });
                    arglbl.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Green");
                }
                else if (fValue > Convert.ToDouble(argYellow))
                {
                    arcScaleRange.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
                    arcScaleComponent.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] { arcScaleRange });
                    arglbl.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
                }
                else
                {
                    arcScaleRange.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
                    arcScaleComponent.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] { arcScaleRange });
                    arglbl.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
                }
                
               
            }
            catch 
            {
            }
        }
        #endregion POD


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
                string process_name = "MES.PKG_SMT_B1_DIGITAL.SEL_DATA_FORM_MAIN_PHYLON";

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

        private DataTable LOAD_DATA_PRODUCTION(string arg_op_cd)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_B1.SP_PH_PROD_DAILY_NEW";
                //ARGMODE
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "v_p_type";
                MyOraDB.Parameter_Name[1] = "v_p_op";
                MyOraDB.Parameter_Name[2] = "out_cursor";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = "Q";

                MyOraDB.Parameter_Values[1] = arg_op_cd;
                MyOraDB.Parameter_Values[2] = "";
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

        private DataTable LOAD_DATA()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "SEPHIROTH.PKG_CMMS_PDA.SEL_TBL_SYS_USER";
                //ARGMODE
                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
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
                //DataTable dt = LOAD_DATA();
               
               
                pnButton.Visible = false;
                // lblShift.Visible = true;
                GoFullscreen();
                addForm();
                Dictionary<string, string>[] dtn = Init_File_XML(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "form");

                cmdBack.Visible = Boolean.Parse(dtn[0]["cmdBack"]);
                //cmdPH1.Visible = !Boolean.Parse(dtn[0]["cmdBack"]);
                //cmdPH2.Visible = !Boolean.Parse(dtn[0]["cmdBack"]);
                cmdPH3.Visible = true;
                cmdCMP.Visible = true;
                
                
                
            }
            catch 
            {}
           
            
            
        }

        private void loadFrmFirst()
        {
            Dictionary<string, string>[] dtn = Init_File_XML(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "form");
            if (dtn[0]["monitor"] == "C" || dtn[0]["monitor"] == "B" || dtn[0]["monitor"] == "A")
            {
                cmdPH3_Click(null, null);
            }
            else if (dtn[0]["monitor"] == "CMP")
            {
                cmdCMP_Click(null, null);
            }
        }

        

        private void Form_Home_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    

                    // addUcMachinery();
                    lblTitle.Text = "Digital Shop Floor For Phylon";
                    _timeLoad = 29;
                    tmrLoad.Start();
                    tmrTime.Start();
                }
                else
                {
                    tmrLoad.Stop();
                    tmrTime.Start();
                }
            }
            catch 
            {}
            
        }



        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            try
            {
                _timeLoad++;
                if (_timeLoad == 30)
                {

                    loadData();
                    _timeLoad = 0;
                    if (_load)
                    {
                        _load = false;
                        loadFrmFirst();
                    }
                }
                if (_timeLoad == 15)
                {
                    Thread t = new Thread(new ThreadStart(getDataThread));
                    t.Start();
                }
            }
            catch 
            {
            }
            

            
        }



        #region Click Event

        

        private void cmdQuality1_Click(object sender, EventArgs e)
        {
            
            Cursor.Current = Cursors.WaitCursor;
            _type = "PHP";
            ComVar._frmDefective.Show();
        }

        private void cmdQuality2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "CMP";
            _frmQua_Ex_OSD_Month.Show();
            //this.Hide();
        }

        private void cmdQuality3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "PHP";
            _frmQua_Mold.Show();
            //this.Hide();
        }

        private void cmdProduction1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "CMP";
            _frmPro_MoldLayout.Show();
            Cursor.Current = Cursors.Default; 
           // this.Hide();
           // _frmProduction_StatusDay.Show();
           // _frmProduction_StatusDay.cmdDay.Enabled = false;
           // this.Hide();
        }

        private void cmdProduction2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "CMP";
            _frmPro_MoldActualPlan.Show();
            Cursor.Current = Cursors.Default; 
           // this.Hide();
        }

        private void cmdProduction3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "CMP";
            _frmProd_Day.Show();
            Cursor.Current = Cursors.Default; 
          //  this.Hide();
        }



        private void cmdMachinery2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "PHP";
            _frmMc_Temp.Show();
            Cursor.Current = Cursors.Default; 
           // _frmMachinery_RubTemp.Show();
           // this.Hide();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "CMP";
            _frmInv.Show();
            Cursor.Current = Cursors.Default; 
           // _frmInventory.Show();
          //  this.Hide();
        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "CMP";
            _frmHr_Absent.Show();
            Cursor.Current = Cursors.Default; 
           // this.Hide();
        }

        private void cmdMachinery1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "PHP";
            _frmMc_OEE_Month.Show();
            Cursor.Current = Cursors.Default; 
           // this.Hide();
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _type = "PHP";
            _frmBTS.Show();
            Cursor.Current = Cursors.Default; 
        }

        #endregion Click Event

        private void groupBoxEx1_Enter(object sender, EventArgs e)
        {

        }

        



        #endregion Event Form

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _frmInv_Tracking.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            _frmLeadTime.Show();
            //this.Hide();
        }

        private void groupBoxEx4_Enter(object sender, EventArgs e)
        {

        }

        private void cmdWH_Click(object sender, EventArgs e)
        {
            try
            {

                string patch = Application.StartupPath + "\\Mold\\MoldPH.exe";

                if (!ProgramIsRunning(patch))
                {
                    Process.Start(patch);
                }
                else
                {
                    System.Diagnostics.Process result = System.Diagnostics.Process.GetProcessesByName("MoldPH").FirstOrDefault();
                    //SetWindowPos(result.MainWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                    SwitchToThisWindow(result.MainWindowHandle, true);
                }

                
                //System.Diagnostics.Process result = System.Diagnostics.Process.GetProcessesByName("MoldPH").FirstOrDefault();
                //if (result == null)
                //    Process.Start(Application.StartupPath + "\\Mold\\MoldPH.exe");
                //else
                ////SetWindowPos(result.MainWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                //SwitchToThisWindow(result.MainWindowHandle, false);
            }
            catch
            { }
        }


        //Kiem tra Program co dang chay hay chua?
        private bool ProgramIsRunning(string FullPath)
        {
            try
            {
                string FilePath = Path.GetDirectoryName(FullPath);
                string FileName = Path.GetFileNameWithoutExtension(FullPath).ToLower();
                bool isRunning = false;

                Process[] pList = Process.GetProcessesByName(FileName);
                foreach (Process p in pList)
                    if (p.MainModule.FileName.StartsWith(FilePath, StringComparison.InvariantCultureIgnoreCase))
                    {
                        isRunning = true;
                        break;
                    }

                return isRunning;
            }
            catch
            {

                return false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _frmKPI.Show();
        }

        private void cmdPH1_Click(object sender, EventArgs e)
        {
            //_frmPhylonDas_1.Show();
        }

        private void cmdPH2_Click(object sender, EventArgs e)
        {
            //_frmPhylonDas_2.Show();
        }

        private void cmdPH3_Click(object sender, EventArgs e)
        {
            _frmPhylonDas_3.Show();
        }


      

        private void cmdCMP_Click(object sender, EventArgs e)
        {
            try
            {
                
                string strPath = Application.StartupPath + "\\CMP\\CMP_DSF_WS.exe";
                //try
                //{
                //    _procCMP = Process.GetProcessesByName(strPath).FirstOrDefault();
                //}
                //catch { }
               
                if (!ProgramIsRunning(strPath))
                {
                    _procCMP = Process.Start(strPath);
                }
                else
                {
                   // Process result = Process.GetProcessesByName("CMP_DSF_WS").FirstOrDefault();
                    //SetWindowPos(result.MainWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                    SwitchToThisWindow(_procCMP.MainWindowHandle, true);
                    //ShowWindow(_procCMP.MainWindowHandle, SW_MAXIMIZE);
                };

            }
            catch
            {

            }
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            try
            {
                _procCMP.Kill();
            }
            catch 
            {}
            
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            
            try
            {
                //switch
                SwitchToThisWindow(FindWindow(IntPtr.Zero, "Phylon_Dasboard"), false);
                ShowWindow(FindWindow(IntPtr.Zero, "Phylon_Dasboard"), SW_MAXIMIZE);
            }
            catch
            { }
        }

        private void cmdHr1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void cmdQuality1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Location = new Point(724, 286);
            this.pictureBox1.Visible = true;
        }

        private void pnHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bstLine1_Equip_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }

        private void Form_Home_Phylon_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _procCMP.Kill();

            }
            catch
            {
                
            }
        }

        private void btnTOPO_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Location = new Point(724, 286);
            this.pictureBox1.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            _frmHr_TOPO.Show();
            Cursor.Current = Cursors.Default; 
        }

        private void btnTOPO_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = false;
        }


       
       

        

        

        

        





    }
}
