using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Text.RegularExpressions;
using ChartDirector;
using System.Threading;
using System.Drawing;
using System.IO;


//using COM.eBiz.Framework.Data;
//using COM.eBiz.Framework.Lib;


namespace Smart_FTY
{
    public partial class FRM_ROLL_TALLY_SHEET : SampleFrm1
    {
        #region Declare
        int iNumRow = 0;
        
        DataTable dt_Daily_Report = null;
        Thread th;
        int _time = 0;
		int cnt_load = 0;
        
        private int idx_form;
        #endregion

        #region Creation
        public FRM_ROLL_TALLY_SHEET(int arg_idx = 0)
        {
            InitializeComponent();
            idx_form = arg_idx;
        }

        int indexScreen;
        int int_count = 0;
        string str_op = "", strCOL = "";
        public FRM_ROLL_TALLY_SHEET(string title, int _indexScreen)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
        }

        #endregion

        #region Method

        private void nextForm()
        {

            //Application.Run(new MaterialSetRate.IPP_MACHINE_LAYOUT());
        }
        private void previousForm()
        {

            //Application.Run(new MaterialSetRate.Frm_Mold_WS_Change_By_Shift());
        }
        protected bool SaveData(string FileName, byte[] Data, int ArraySize)
        {
            BinaryWriter Writer = null;
            try
            {
                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(FileName));

                // Writer raw data                
                Writer.Write(Data, 0, ArraySize);
                Writer.Flush();
                Writer.Close();
            }
            catch
            {
                //...
                return false;
            }

            return true;
        }
        private Image GetImage(DataTable dtf, int i)
        {
            try
            {

                if (dtf.Rows.Count == 0)
                    return null;
                if (dtf.Rows[0][0] != null)
                {
                    string fileName = Application.StartupPath + @"\Hinh" + dtf.Rows[0][2].ToString() + i.ToString();
                    byte[] data = (byte[])dtf.Rows[0][0];
                    int ArraySize = new int();
                    ArraySize = data.GetUpperBound(0);

                    fileName += ".jpg";

                    if(File.Exists(fileName))
                        return Image.FromFile(fileName);

                    if (data != null)
                    {
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }
                        if (SaveData(fileName, data, ArraySize))
                        {
                            if (File.Exists(fileName))
                                return Image.FromFile(fileName);
                            else
                                return null;
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void Load3Pic(string Line)
        {
            DataRow[] Colect;
            DataTable dtPicAll = null;
            DataTable dtPic1 = null;
            DataTable dtPic2 = null;
            DataTable dtPic3 = null;

            dtPicAll = SEL_OS_PICTURE1("Q", Line, "ALL");
            if( dtPicAll.Select(" SHIFT = 011 ").Length > 0)
                dtPic1 = dtPicAll.Select(" SHIFT = 011 ").CopyToDataTable();
            if (dtPicAll.Select(" SHIFT = 012 ").Length > 0)
                dtPic2 = dtPicAll.Select(" SHIFT = 012").CopyToDataTable();
            if (dtPicAll.Select(" SHIFT = 013 ").Length > 0)
                dtPic3 = dtPicAll.Select(" SHIFT = 013 ").CopyToDataTable();
             

            // PIC1
            if (dtPic1 != null && dtPic1.Rows.Count > 0)
            {
                pbxShift1.BackgroundImage = GetImage(dtPic1, 0);
                lblName_Shift1.Text = dtPic1.Rows[0]["REMARK1"].ToString();
            }
            else
            {
                pbxShift1.BackgroundImage = global::Smart_FTY.Properties.Resources.dfAvatar12;
                lblName_Shift1.Text = "";
            }
            //PIC2
            if (dtPic2 != null && dtPic2.Rows.Count > 0)
            {
                pbxShift2.BackgroundImage = GetImage(dtPic2, 1);
                lblName_Shift2.Text = dtPic2.Rows[0]["REMARK1"].ToString();
            }
            else
            {
                pbxShift2.BackgroundImage = global::Smart_FTY.Properties.Resources.dfAvatar12;
                lblName_Shift2.Text = "";
            }
            //PIC3
            if (dtPic3 != null && dtPic3.Rows.Count > 0)
            {
                pbxShift3.BackgroundImage = GetImage(dtPic3, 2);
                lblName_Shift3.Text = dtPic3.Rows[0]["REMARK1"].ToString();
            }
            else
            {
                pbxShift3.BackgroundImage = global::Smart_FTY.Properties.Resources.dfAvatar12;
                lblName_Shift3.Text = "";
            }

        }

        private void FORM_WORK_TALLY_SHEET_Load(object sender, EventArgs e)
        {
            try{
                //Com_Base.Functions.Form_Maximized(this, int.Parse(Com_Base.Variables.Form[idx_form]["monitor"]));
                GoFullscreen(true);
                str_op = "OS";
                //lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
           
				//panel1.BackColor = Color.FromArgb(255, 165, 0);
				//this.lblDate.BackColor = Color.FromArgb(255, 165,0);
				//panel1.BackColor = Color.DarkOrange;
				//this.lblDate.BackColor = Color.DarkOrange;
                DataTable dt = null; 
                dt = SELECT_ASSY_DATE(str_op);
                 
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblWrkDate.Text = dt.Rows[0]["TODATE"].ToString();
                    lblAssyDate.Text = dt.Rows[0]["ASSY_DATE"].ToString();
                }
                else
                {
                    lblAssyDate.Text = "";
                    lblWrkDate.Text = "";
                } 


                lblWrkDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                lblAssyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                timer2.Interval = 1000;
                timer2.Start();
                timer1.Interval = 1000;
                timer1.Start();
                //Load3Pic("OSR");
              
            }
            catch (System.Exception ex)
            {
               
            }

        }
        

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
      
        private Color SetColorGrid(string strValue)
        {           
            try
            {         
                switch (strValue)
                {
                    case "RED" :
                        return Color.Red;
                        break;
                    case "WHITE":
                        return Color.White;
                        break;
                    case "YELLOW":
                        return Color.Yellow;
                        break;
                    case "GREEN":
                        return Color.Green;
                        break;
                    case "BLUE":
                        return Color.Blue;
                        break;
                    case  "DodgerBlue":
                        return Color.DodgerBlue;
                        break;

                    case "BLACK":
                        return Color.Black;
                        break;
                    case "TOTAL_COL":
                        return Color.FromArgb(255,255,196) ;
                        break;
                }
                return Color.White;
                 
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return Color.Red;
            }
        }
        private Color getColor(string strValue)
        {

            try
            {
                if (strValue.Trim().Equals(""))
                    return Color.Red;

                string[] s = strValue.Split('/');

                if (s[0].ToString().Trim() == s[1].ToString().Trim())
                {
                    return Color.SeaGreen;
                }
                return Color.SkyBlue;
            }
            catch (Exception ex)
            {
                
                //MessageBox.Show(ex.ToString());
                return Color.Red;
            }
        }

        private void menu1_Load(object sender, EventArgs e)
        {

        }

        private void menu1_buttonClicked()
        {

        }

        private void Search_Data(string arg_op)
        {
            try
            {
                double t_plan_1 = 0, t_plan_2 = 0, t_plan_3 = 0, t_act_1 = 0, t_act_2 = 0, t_act_3 = 0, t_plan = 0, t_rplan = 0, t_act = 0;
                DataTable dt = null;
                dt = SELECT_WORK_TALLY_SHEET("H", arg_op);
                if (dt != null && dt.Rows.Count > 0)
                {                   
                    lblWrkDate.Text = dt.Rows[0]["TODATE"].ToString();
                    lblAssyDate.Text = dt.Rows[0]["ASSY_DATE"].ToString();
                    lblS1Plan.Text = "0";
                    lblS1Weight.Text = "0";
                    lblS1RPlan.Text = "0";
                    lblS1Rate.Text = "0";
                    lblS2Plan.Text = "0";
                    lblS2Weight.Text = "0";
                    lblS2RPlan.Text = "0";
                    lblS2Rate.Text = "0";
                    lblS3Plan.Text = "0";
                    lblS3Weight.Text = "0";
                    lblS3RPlan.Text = "0";
                    lblS3Rate.Text = "0";
                    lblPlan.Text = "0";
                    lblWeight.Text = "0";
                    lblRPlan.Text = "0";
                    lblRate.Text = "0"; 
                    for (int i_row = 0; i_row < dt.Rows.Count; i_row++)
                    {
                        switch (dt.Rows[i_row]["SHIFT"].ToString())
                        {
                            case "1":
                                lblS1Plan.Text = dt.Rows[i_row]["PLAN"].ToString();
                                lblS1Weight.Text = dt.Rows[i_row]["ACT"].ToString();
                                lblS1RPlan.Text = dt.Rows[i_row]["RPLAN"].ToString();
                                lblS1Rate.Text = dt.Rows[i_row]["RPLAN"].ToString() == "0" ? "0" :
                                                 (Convert.ToDouble(dt.Rows[i_row]["ACT"]) / Convert.ToDouble(dt.Rows[i_row]["RPLAN"]) * 100).ToString("#,0.0");
                                t_plan += Convert.ToDouble(dt.Rows[i_row]["PLAN"]);
                                t_rplan += Convert.ToDouble(dt.Rows[i_row]["RPLAN"]);
                                t_act += Convert.ToDouble(dt.Rows[i_row]["ACT"]);
                                break;
                            case "2":
                                lblS2Plan.Text = dt.Rows[i_row]["PLAN"].ToString();
                                lblS2Weight.Text = dt.Rows[i_row]["ACT"].ToString();
                                lblS2RPlan.Text = dt.Rows[i_row]["RPLAN"].ToString();
                                lblS2Rate.Text = dt.Rows[i_row]["RPLAN"].ToString() == "0" ? "0" :
                                                 (Convert.ToDouble(dt.Rows[i_row]["ACT"]) / Convert.ToDouble(dt.Rows[i_row]["RPLAN"]) * 100).ToString("#,0.0");
                                t_plan += Convert.ToDouble(dt.Rows[i_row]["PLAN"]);
                                t_rplan += Convert.ToDouble(dt.Rows[i_row]["RPLAN"]);
                                t_act += Convert.ToDouble(dt.Rows[i_row]["ACT"]);
                                break;
                            case "3":
                                lblS3Plan.Text = dt.Rows[i_row]["PLAN"].ToString();
                                lblS3Weight.Text = dt.Rows[i_row]["ACT"].ToString();
                                lblS3RPlan.Text = dt.Rows[i_row]["RPLAN"].ToString();
                                lblS3Rate.Text = dt.Rows[i_row]["RPLAN"].ToString() == "0" ? "0" :
                                                 (Convert.ToDouble(dt.Rows[i_row]["ACT"]) / Convert.ToDouble(dt.Rows[i_row]["RPLAN"]) * 100).ToString("#,0.0");
                                t_plan += Convert.ToDouble(dt.Rows[i_row]["PLAN"]);
                                t_rplan += Convert.ToDouble(dt.Rows[i_row]["RPLAN"]);
                                t_act += Convert.ToDouble(dt.Rows[i_row]["ACT"]);
                                break;
                            default:
                                break;
                        }
                    }
                    lblPlan.Text = t_plan.ToString(); ;
                    lblWeight.Text = t_act.ToString();
                    lblRPlan.Text = t_rplan.ToString();
                    lblRate.Text = t_rplan == 0 ? "0" : ((t_act / t_rplan) * 100).ToString("#,0.0");
                    //axfpSpread.SetText(3, 1, "Shift 1 ( 06:00- 14:00 )"); //(" + dt.Rows[0]["YESTERDAY"].ToString() +")");
                    //axfpSpread.SetText(13, 1, "Shift 2 ( 14:00- 22:00 )");// (" + dt.Rows[0]["TODAY"].ToString() + ")");
                    //axfpSpread.SetText(23, 1, "Shift 3 ( 22:00- 06:00 )");// (" + dt.Rows[0]["TODAY"].ToString() + ")");                    
                }
                else
                {
                    lblAssyDate.Text = "";
                    lblWrkDate.Text = "";
                }
                dt = null;
                dt = SELECT_WORK_TALLY_SHEET("Q",arg_op);
                grdView.DataSource = dt;
                if (dt != null & dt.Rows.Count > 1)
                {
                    strCOL = dt.Rows[0]["CUR_COL"].ToString();
                    //if (dt.Rows[dt.Rows.Count - 1]["TOT_S1"].ToString().IndexOf("/") > 0)
                    //{
                    //    t_act_1 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S1"].ToString().Split('/')[0]);
                    //    t_plan_1 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S1"].ToString().Split('/')[1]);
                    //}
                    //else if (dt.Rows[dt.Rows.Count - 1]["TOT_S1"].ToString() != "")
                    //{
                    //    t_act_1 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S1"].ToString());
                    //    t_plan_1 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S1"].ToString());
                    //}
                    //if (dt.Rows[dt.Rows.Count - 1]["TOT_S2"].ToString().IndexOf("/") > 0)
                    //{
                    //    t_act_2 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S2"].ToString().Split('/')[0]);
                    //    t_plan_2 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S2"].ToString().Split('/')[1]);
                    //}
                    //else if (dt.Rows[dt.Rows.Count - 1]["TOT_S2"].ToString() != "")
                    //{
                    //    t_act_2 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S2"].ToString());
                    //    t_plan_2 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S2"].ToString());
                    //}
                    //if (dt.Rows[dt.Rows.Count - 1]["TOT_S3"].ToString().IndexOf("/") > 0)
                    //{
                    //    t_act_3 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S3"].ToString().Split('/')[0]);
                    //    t_plan_3 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S3"].ToString().Split('/')[1]);
                    //}
                    //else if (dt.Rows[dt.Rows.Count - 1]["TOT_S3"].ToString() != "")
                    //{
                    //    t_act_3 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S3"].ToString());
                    //    t_plan_3 = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["TOT_S3"].ToString());
                    //}
                    //lblS1Weight.Text = t_act_1.ToString();
                    //lblS1Plan.Text = t_plan_1.ToString();
                    //lblS1Rate.Text = t_plan_1 == 0 ? "0" : t_act_1 == 0 ? "0" : (t_act_1 / t_plan_1 * 100).ToString("#,#.#");
                    //lblS2Weight.Text = t_act_2.ToString();
                    //lblS2Plan.Text = t_plan_2.ToString();
                    //lblS2Rate.Text = t_plan_2 == 0 ? "0" : t_act_2 == 0 ? "0" : (t_act_2 / t_plan_2 * 100).ToString("#,#.#");
                    //lblS3Weight.Text = t_act_3.ToString();
                    //lblS3Plan.Text = t_plan_3.ToString();
                    //lblS3Rate.Text = t_plan_3 == 0 ? "0" : t_act_3 == 0 ? "0" : (t_act_3 / t_plan_3 * 100).ToString("#,#.#");
                    //lblWeight.Text = (t_act_1 + t_act_2 + t_act_3).ToString();
                    //lblPlan.Text = (t_plan_1 + t_plan_2 + t_plan_3).ToString();
                    //lblRate.Text = (t_plan_1 + t_plan_2 + t_plan_3) == 0 ? "0" : (t_act_1 + t_act_2 + t_act_3)== 0 ? "0" :((t_act_1 + t_act_2 + t_act_3) / (t_plan_1 + t_plan_2 + t_plan_3) * 100).ToString("#,#.#");

                    for (int i = 0; i < gvwView.Columns.Count; i++)
                    {
                        gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                        gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                        gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                        gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 14, FontStyle.Regular);
                        if (i == 0)
                        {
                            gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                        }

                    }
                }
            }
            catch { }
        }

        private void Search_Daily_Report(string arg_op)
        {
            try
            { 
              
                DataTable dt = null;
                dt = SELECT_WORK_TALLY_SHEET("H",arg_op);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblWrkDate.Text = dt.Rows[0]["TODATE"].ToString();
                    lblAssyDate.Text = dt.Rows[0]["ASSY_DATE"].ToString();
					axfpSpread.SetText(3, 1, "Shift 1 ( 06:00- 14:00 )"); //(" + dt.Rows[0]["YESTERDAY"].ToString() +")");
					axfpSpread.SetText(13, 1, "Shift 2 ( 14:00- 22:00 )");// (" + dt.Rows[0]["TODAY"].ToString() + ")");
					axfpSpread.SetText(23, 1, "Shift 3 ( 22:00- 06:00 )");// (" + dt.Rows[0]["TODAY"].ToString() + ")");
                }
                else
                {
                    lblAssyDate.Text = "";
                    lblWrkDate.Text = "";
                }

                dt = null;
                dt = SELECT_WORK_TALLY_SHEET("Q",arg_op);
                if (dt != null & dt.Rows.Count > 1)
                {
                    iNumRow = dt.Rows.Count;
                    dt_Daily_Report = dt;

                    axfpSpread.Visible = false;
                    axfDailyReport_Header.Visible = false;
                  

                    if (dt_Daily_Report != null && dt_Daily_Report.Rows.Count > 1)
                    {
                        for (int i = 0; i < dt_Daily_Report.Rows.Count; i++)
                        {
                            axfpSpread.Row = i + 3;
                            //axfpSpread.set_RowHeight(i + 3, 40.0);
                            axfpSpread.set_RowHeight(i + 3, 36);
                            if (i != dt_Daily_Report.Rows.Count - 1)
                            {
                                this.axfpSpread.SetText(1, i + 3, dt_Daily_Report.Rows[i]["MC"].ToString());
                            }

                            this.axfpSpread.SetText(2, i + 3, dt_Daily_Report.Rows[i]["MCS_NAME"].ToString());


                            this.axfpSpread.SetText(3, i + 3, dt_Daily_Report.Rows[i]["S1H1"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 3;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S1H1_COLOR"].ToString());

                            this.axfpSpread.SetText(4, i + 3, dt_Daily_Report.Rows[i]["S1H2"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 4;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S1H2_COLOR"].ToString());

                            this.axfpSpread.SetText(5, i + 3, dt_Daily_Report.Rows[i]["S1H3"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 5;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S1H3_COLOR"].ToString());

                            this.axfpSpread.SetText(6, i + 3, dt_Daily_Report.Rows[i]["S1H4"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 6;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S1H4_COLOR"].ToString());

                            this.axfpSpread.SetText(7, i + 3, dt_Daily_Report.Rows[i]["S1H5"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 7;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S1H5_COLOR"].ToString());

                            this.axfpSpread.SetText(8, i + 3, dt_Daily_Report.Rows[i]["S1H6"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 8;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S1H6_COLOR"].ToString());

                            this.axfpSpread.SetText(9, i + 3, dt_Daily_Report.Rows[i]["S1H7"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 9;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S1H7_COLOR"].ToString());

                            this.axfpSpread.SetText(10, i + 3, dt_Daily_Report.Rows[i]["S1H8"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 10;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S1H8_COLOR"].ToString());


                            this.axfpSpread.SetText(11, i + 3, dt_Daily_Report.Rows[i]["S1_TOTAL"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 11;
                            axfpSpread.BackColor = SetColorGrid("TOTAL_COL");

                            this.axfpSpread.SetText(12, i + 3, "");
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 12;
                            axfpSpread.BackColor = SetColorGrid("BLACK");

                            this.axfpSpread.SetText(13, i + 3, dt_Daily_Report.Rows[i]["S2H1"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 13;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S2H1_COLOR"].ToString());

                            this.axfpSpread.SetText(14, i + 3, dt_Daily_Report.Rows[i]["S2H2"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 14;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S2H2_COLOR"].ToString());

                            this.axfpSpread.SetText(15, i + 3, dt_Daily_Report.Rows[i]["S2H3"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 15;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S2H3_COLOR"].ToString());

                            this.axfpSpread.SetText(16, i + 3, dt_Daily_Report.Rows[i]["S2H4"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 16;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S2H4_COLOR"].ToString());

                            this.axfpSpread.SetText(17, i + 3, dt_Daily_Report.Rows[i]["S2H5"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 17;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S2H5_COLOR"].ToString());

                            this.axfpSpread.SetText(18, i + 3, dt_Daily_Report.Rows[i]["S2H6"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 18;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S2H6_COLOR"].ToString());

                            this.axfpSpread.SetText(19, i + 3, dt_Daily_Report.Rows[i]["S2H7"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 19;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S2H7_COLOR"].ToString());

                            this.axfpSpread.SetText(20, i + 3, dt_Daily_Report.Rows[i]["S2H8"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 20;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S2H8_COLOR"].ToString());


                            this.axfpSpread.SetText(21, i + 3, dt_Daily_Report.Rows[i]["S2_TOTAL"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 21;
                            axfpSpread.BackColor = SetColorGrid("TOTAL_COL");

                            this.axfpSpread.SetText(22, i + 3, "");
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 22;
                            axfpSpread.BackColor = SetColorGrid("BLACK");


                            this.axfpSpread.SetText(23, i + 3, dt_Daily_Report.Rows[i]["S3H1"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 23;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S3H1_COLOR"].ToString());

                            this.axfpSpread.SetText(24, i + 3, dt_Daily_Report.Rows[i]["S3H2"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 24;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S3H2_COLOR"].ToString());

                            this.axfpSpread.SetText(25, i + 3, dt_Daily_Report.Rows[i]["S3H3"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 25;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S3H3_COLOR"].ToString());

                            this.axfpSpread.SetText(26, i + 3, dt_Daily_Report.Rows[i]["S3H4"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 26;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S3H4_COLOR"].ToString());


                            this.axfpSpread.SetText(27, i + 3, dt_Daily_Report.Rows[i]["S3H5"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 27;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S3H5_COLOR"].ToString());

                            this.axfpSpread.SetText(28, i + 3, dt_Daily_Report.Rows[i]["S3H6"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 28;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S3H6_COLOR"].ToString());

                            this.axfpSpread.SetText(29, i + 3, dt_Daily_Report.Rows[i]["S3H7"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 29;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S3H7_COLOR"].ToString());

                            this.axfpSpread.SetText(30, i + 3, dt_Daily_Report.Rows[i]["S3H8"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 30;
                            axfpSpread.BackColor = SetColorGrid(dt_Daily_Report.Rows[i]["S3H8_COLOR"].ToString());

                            this.axfpSpread.SetText(31, i + 3, dt_Daily_Report.Rows[i]["S3_TOTAL"].ToString());
                            axfpSpread.Row = i + 3;
                            axfpSpread.Col = 31;
                            axfpSpread.BackColor = SetColorGrid("TOTAL_COL");
                   
                            

                        }
                        
                        //if (getCurrentHHLocation() != 0)
                        //{

                        //    this.panel2.Location = new System.Drawing.Point(getCurrentHHLocation(), 340);
                        //    //this.panel2.Location = new System.Drawing.Point(242, 268);
                        //    panel2.Size = new Size(75, 905);
                        //    panel2.Refresh();
                        //}
                        string[] s = new string[2];
                        int iElement1 = 0;
                        int iElement2 = 0;
                        double dPlan  = 0;
                        double dWeight = 0;
                        char[] delimiterChars = {  '/' };
                        s = dt.Rows[dt.Rows.Count - 1]["S2_TOTAL"].ToString().Split(delimiterChars);
                        if (s.Length > 1)
                        {
                            iElement2 = 1;
                        }
                        else
                        {
                            iElement2 = 0;
                        }

                        dWeight = dWeight + Convert.ToDouble(s[iElement1].ToString());
                        dPlan = dPlan + Convert.ToDouble(s[iElement2].ToString());
                        lblS2Weight.Text = s[iElement1].ToString();
                        lblS2Plan.Text = s[iElement2].ToString();
                        if (Convert.ToDouble(s[iElement2].ToString()) == 0)
                        {
                            lblS2Rate.Text = "0";
                        }
                        else
                        {
                            lblS2Rate.Text = Math.Round(Convert.ToDouble(s[iElement1].ToString()) / Convert.ToDouble(s[iElement2].ToString()) * 100, 1).ToString();
                        }

                        s = null;
                        s = dt.Rows[dt.Rows.Count - 1]["S3_TOTAL"].ToString().Split(delimiterChars);
                        if (s.Length> 1)
                        {
                            iElement2 = 1;
                        }
                        else
                        {
                            iElement2 = 0;
                        }
                        lblS3Plan.Text = s[iElement2].ToString();
                        lblS3Weight.Text = s[iElement1].ToString();
                        dWeight = dWeight + Convert.ToDouble(s[iElement1].ToString());
                        dPlan = dPlan + Convert.ToDouble(s[iElement2].ToString());
                        if (Convert.ToDouble(s[iElement2].ToString()) == 0)
                        {
                            lblS3Rate.Text = "0";

                        } else
                        {
                            lblS3Rate.Text = Math.Round(Convert.ToDouble(s[iElement1].ToString()) / Convert.ToDouble(s[iElement2].ToString()) * 100, 1).ToString();
                        }

                        s = null;
                        s = dt.Rows[dt.Rows.Count - 1]["S1_TOTAL"].ToString().Split(delimiterChars);
                        if (s.Length > 1)
                        {
                            iElement2 = 1;
                        }
                        else
                        {
                            iElement2 = 0;
                        }
                        lblS1Plan.Text = s[iElement2].ToString();
                        lblS1Weight.Text = s[iElement1].ToString();
                        dWeight = dWeight + Convert.ToDouble(s[iElement1].ToString());
                        dPlan = dPlan + Convert.ToDouble(s[iElement2].ToString());
                        if (Convert.ToDouble(s[iElement2].ToString()) == 0)
                        {
                            lblS1Rate.Text = "0";
                        }
                        else
                        {
                            lblS1Rate.Text = Math.Round(Convert.ToDouble(s[iElement1].ToString()) / Convert.ToDouble(s[iElement2].ToString()) * 100, 1).ToString();
                        }

                        lblPlan.Text = dPlan.ToString();
                        lblWeight.Text = dWeight.ToString();
                        lblRate.Text = Math.Round(dWeight/dPlan*100,2).ToString() ;

                        for (int i = dt.Rows.Count + 3; i < axfpSpread.MaxRows + 1; i++)
                        {
                            axfpSpread.set_RowHeight(i, 0);
                        }
                        MergeCol(axfpSpread, 3, 1);
                        MergeCol(axfpSpread, 3, 2);
                        panel2.Visible = false;
                        //showAnimation(axfpSpread);
                        panel2.Visible = true;
                        if (getCurrentHHLocation() != 0)
                        {

                            this.panel2.Location = new System.Drawing.Point(getCurrentHHLocation(), 330);
							//this.panel2.Location = new System.Drawing.Point(238, 268);
                            panel2.Size = new Size(75, 905);
                            panel2.Refresh();
                            panel2.BringToFront();
                        }
                    }
                    else
                    {
                        //for (int i = dt.Rows.Count + 3; i < axfDailyReport.MaxRows + 1; i++)
                        //{
                        //    axfDailyReport.set_RowHeight(i, 0);
                        //}
                    }
                }
                else
                {

                    axfDailyReport_Header.Visible = true;
                    //axfDailyReport.Visible = false;

                    for (int i = 3; i <= axfpSpread.MaxRows; i++)
                    {
                        axfpSpread.set_RowHeight(i, 0);
                    }
               
                    iNumRow = 0;
                    if (getCurrentHHLocation() != 0)
                    {

                        this.panel2.Location = new System.Drawing.Point(getCurrentHHLocation(), 330);
                        panel2.Size = new Size(75, 905);
                        panel2.Refresh();
                    }

                }
                axfpSpread.Visible = true;
                
              
            }
            catch (Exception ex)
            {

            }

        }
        private int getCurrentHH ()
        {
            string sHH = "";
            sHH = DateTime.Now.ToString("HH");
            try
            {
                switch (sHH)
                {
                    case "14":
                        return 10;
                        break;
                    case "15":
                        return 10;
                        break;
                    case "16":
                        return 11;
                        break;         
                    case "17":
                        return 11;
                        break;
                    case "18":
                        return 12;
                        break;
                    case "19":
                        return 12;
                        break;
                    case "20":
                        return 13;
                        break;
                    case "21":
                        return 13;
                        break;
                    case "22":
                        return 15;
                        break;
                    case "23":
                        return 15;
                        break;
                    case "00":
                        return 16;
                        break;
                    case "01":
                        return 16;
                        break;
                    case "02":
                        return 17;
                        break;
                    case "03":
                        return 17;
                        break;
                    case "04":
                        return 18;
                        break;
                    case "05":
                        return 18;
                        break;
                    case "06":
                        return 20;
                        break;
                    case "07":
                        return 20;
                        break;

                    case "08":
                        return 21;
                        break;
                    case "09":
                        return 21;
                        break;
                    case "10":
                        return 22;
                        break;
                    case "11":
                        return 22;
                        break;
                    case "12":
                        return 23;
                        break;
                    case "13":
                        return 23;
                        break;
                }
                return 0;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return 0;
            }
            return 0;
        }

        private int getCurrentHHLocation()
        {
            string sHH = "";
            sHH = DateTime.Now.ToString("HH");
            try
            {
                switch (sHH)
                {
                    case "06":
                        return 238;
                        break;
                    case "07":
                        return 299;
                        break;
                    case "08":
                        return 360;
                        break;
                    case "09":
                        return 421;
                        break;
                    case "10":
                        return 482;
                        break;
                    case "11":
                        return 541;
                        break;
                    case "12":
                        return 602;
                        break;
                    case "13":
						return 664;
                        break;
                    case "14":
                        return 794;
                        break;
                    case "15":
						return 855;
                        break;
                    case "16":
						return 917;
                        break;
                    case "17":
						return 977;
                        break;
                    case "18":
						return 1039;
                        break;
                    case "19":
						return 1100;
                        break;
                    case "20":
						return 1161;
                        break;
                    case "21":
						return 1222;
                        break;
                    case "22":
						return 1352;
                        break;
                    case "23":
						return 1412;
                        break;
                    case "00":
						return 1474;
                        break;
                    case "01":
						return 1534;
                        break;
                    case "02":
						return 1596;
                        break;
                    case "03":
						return 1657;
                        break;
                    case "04":
                        return 1718;
                        break;
                    case "05":
                        return 1779;
                        break;
                }
                return 0;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return 0;
            }
            return 0;
        }
        
        private DataTable SELECT_WORK_TALLY_SHEET(string arg_type, string arg_op) 
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();
            MyOraDB.ReDim_Parameter(3);
            MyOraDB.Process_Name = "MES.PKG_SMT_ROLL.SP_ROLL_TALLY_SHEET";

            //02.ARGURMENT ¢¬i
            MyOraDB.Parameter_Name[0] = "V_P_TYPE";
            MyOraDB.Parameter_Name[1] = "V_P_OP";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

            //03.DATA TYPE A¢´AC
            MyOraDB.Parameter_Type[0] = (int)OracleType.NVarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.NVarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = arg_type;
            MyOraDB.Parameter_Values[1] = arg_op;
            MyOraDB.Parameter_Values[2] = "";

            MyOraDB.Add_Select_Parameter(true);

            retDS = MyOraDB.Exe_Select_Procedure();

            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }


        private DataTable SELECT_ASSY_DATE(string OP_CD)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();
            MyOraDB.ReDim_Parameter(2);
            MyOraDB.Process_Name = "MES.PKG_SFC_ROLL_SO.SELECT_ASSY_DATE";

            //02.ARGURMENT ¢¬i
            MyOraDB.Parameter_Name[0] = "ARG_OP_CD";
            MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

            //03.DATA TYPE A¢´AC
            MyOraDB.Parameter_Type[0] = (int)OracleType.NVarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = "OS";
            MyOraDB.Parameter_Values[1] = "";

            MyOraDB.Add_Select_Parameter(true);

            retDS = MyOraDB.Exe_Select_Procedure();

            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }
        public DataTable SEL_OS_PICTURE1(string ARG_QTYPE, string ARG_LINE, string ARG_SHIFT)
        { 
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            { 
                string process_name = "SEPHIROTH.PKG_OSP_SCREEN.LOAD_OS_TL_PIC";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_DATE";
                MyOraDB.Parameter_Name[1] = "V_P_LINE";
                MyOraDB.Parameter_Name[2] = "V_P_SHIFT";
                MyOraDB.Parameter_Name[3] = "CV_1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_SHIFT;
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

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MergeCol(AxFPSpreadADO.AxfpSpread gridObject, int iStartRow, int iCol)
        {
            try
            {
                string sTemp1 = "";
                string sTemp2 = "";
                int iRow = iStartRow;
                gridObject.Row = iStartRow;
                gridObject.Col = iCol;
                sTemp1 = gridObject.Value;
                for (int i = iStartRow; i < gridObject.MaxRows + 4; i++)
                {
                    gridObject.Row = i;
                    gridObject.Col = iCol;
                    sTemp2 = gridObject.Value;
                    if (sTemp1 != sTemp2)
                    {
                        gridObject.AddCellSpan(iCol, iRow, 1, i - iRow);
                        sTemp1 = sTemp2;
                        sTemp2 = "";
                        iRow = i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        public bool IsNumeric(string text)
        {
            return Regex.IsMatch(text,"^\\d+$");
        }
        private void timer2_Tick(object sender, EventArgs e)
        {              
			cnt_load++;
			if (cnt_load >= 30)
			{
                Search_Data(str_op);

				cnt_load = 0;
			}
           
        }

        private void FORM_WORK_TALLY_SHEET_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private bool checkWindowOpen(string windowName)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name.Equals(windowName))
                {
                    Application.OpenForms[i].Show();
                    return false;
                }
            }
            return true;
        }
                
        private void panel2_Paint(object sender, PaintEventArgs e)
        {         
               Size size = new Size(58, iNumRow*52 + 52);
              // Size size = new Size(58, 5 * 57 + 49);
                System.Drawing.Point location = new System.Drawing.Point(10, 20 + 50 * 0);               
                Pen pen = new Pen(Color.Blue, 5);
                e.Graphics.DrawRectangle(pen, new System.Drawing.Rectangle(location, size));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {			
        }

		private void FORM_WORK_TALLY_SHEET_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible)
			{
				try
				{
                    //Util.Animate(axfpSpread, Util.Effect.Slide, 1, 180);
                    timer2.Start();
                    if (ComVar.Form_Type == "2")
                        lblEVA_Click(null, null);
                    else
                        lblRubber_Click(null, null);

				}
				catch (Exception)
				{

				}
			}
			else
			{
				timer2.Stop();
                cnt_load = 0;
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lblRubber_Click(object sender, EventArgs e)
        {            
            str_op = "OS";
            ComVar.Form_Type = "1";
            Search_Data(str_op);
            lblTitle.Text = "Rubber Tallysheet";
            cnt_load = 0;
            //Util.Animate(axfpSpread, Util.Effect.Slide, 1, 180);
            pnRubber.GradientEndColor = Color.White;//Color.FromArgb(255, 128, 128);
            pnEVA.GradientEndColor = Color.Gray;
            pnRubber.Enabled = false;
            pnEVA.Enabled = true;
            Load3Pic("OSR");
        }

        private void lblEVA_Click(object sender, EventArgs e)
        {           
            str_op = "EVA";
            ComVar.Form_Type = "2";
            Search_Data(str_op);
            lblTitle.Text = "EVA Tallysheet";
            cnt_load = 0;
            //Util.Animate(axfpSpread, Util.Effect.Slide, 1, 180);
            pnRubber.GradientEndColor = Color.Gray;//Color.FromArgb(255, 128, 128);
            pnEVA.GradientEndColor = Color.White;
            pnRubber.Enabled = true;
            pnEVA.Enabled = false;
            Load3Pic("EVA");
        }

        private void gvwView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                //return;
                Rectangle rect = e.Bounds;
                rect.Inflate(new Size(1, 1));

                Brush brush = new SolidBrush(e.Appearance.BackColor);
                e.Graphics.FillRectangle(brush, rect);
                Pen pen_horizental = new Pen(Color.Blue, 3F);
                Pen pen_vertical = new Pen(Color.Blue, 4F);

                if (e.Column.FieldName.Contains("COL"))
                {
                    if (e.Column.FieldName == strCOL)
                    {                        
                        if (e.RowHandle == 0)
                        {
                            //e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                        }
                        else if (e.RowHandle == gvwView.RowCount - 1)
                        {
                            e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y + rect.Height - 1, rect.X + rect.Width, rect.Y + rect.Height - 1);
                        }
                        // draw right
                        e.Graphics.DrawLine(pen_vertical, rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                        // draw left
                        e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X, rect.Y + rect.Height);


                    }

                    string[] ls = e.DisplayText.Split('\n');

                    if (e.RowHandle < gvwView.RowCount - 1)
                    {
                        if (e.Appearance.BackColor == Color.Red || e.Appearance.BackColor == Color.Green)
                        {
                            e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 14, FontStyle.Regular), new SolidBrush(e.Appearance.ForeColor), rect, e.Appearance.GetStringFormat());
                        }
                        else
                        {
                            e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 14, FontStyle.Regular), new SolidBrush(Color.Black), rect, e.Appearance.GetStringFormat());
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 14, FontStyle.Bold), new SolidBrush(Color.Black), rect, e.Appearance.GetStringFormat());
                    }

                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                if (e.RowHandle < 0)
                    return;
                if (e.Column.FieldName.Contains("TOT"))
                {
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                    e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, 14, FontStyle.Bold);

                }
                else if (e.Column.FieldName.Contains("COL"))
                {
                    if (e.CellValue.ToString().Contains("GREEN"))
                    {
                        e.Appearance.ForeColor = Color.Black;
                        e.Appearance.BackColor = Color.Green;
                    }
                    else if (e.CellValue.ToString().Contains("RED"))
                    {
                        e.Appearance.ForeColor = Color.White;
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (e.CellValue.ToString().Contains("GREY"))
                    {
                        e.Appearance.ForeColor = Color.White;
                        e.Appearance.BackColor = Color.Gray;
                    }
                    else if (e.CellValue.ToString().Contains("YELLOW"))
                    {
                        e.Appearance.ForeColor = Color.Black;
                        e.Appearance.BackColor = Color.Yellow;
                    }
                    //else if (e.CellValue.ToString().Contains("TOTCOLOR"))
                    //{
                    //    e.Appearance.ForeColor = Color.Black;
                    //    e.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                    //    e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, 12, FontStyle.Bold);
                    //}
                }

                if (e.RowHandle == gvwView.RowCount - 1)
                {
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                    e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, 14, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gvwView_CustomDrawBandHeader(object sender, DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs e)
        {
            try
            {
                //return;
                Rectangle rect = e.Bounds;
                rect.Inflate(new Size(1, 1));

                Brush brush = new SolidBrush(e.Appearance.BackColor);
                e.Graphics.FillRectangle(brush, rect);
                Pen pen_horizental = new Pen(Color.Blue, 3F);
                Pen pen_vertical = new Pen(Color.Blue, 4F);
                Pen line = new Pen(Color.White, 3F);
                bool boBorder = false;
                string[] ls = e.Band.Caption.Split('\n');

                if (e.Band.HasChildren)
                {
                    if (e.Band.Children[0].Columns.Count > 0)
                        if (e.Band.Children[0].Columns[0].Caption == strCOL)
                        {
                            boBorder = true;
                        }
                }
                else
                {
                    if (e.Band.Columns.Count > 0)
                        if (e.Band.Columns[0].Caption == strCOL)
                        {
                            boBorder = true;
                        }
                }

                if (boBorder)
                {
                    if (e.Band.HasChildren)
                    {   //e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                    }
                    else
                    {
                        e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                        // draw right
                        e.Graphics.DrawLine(pen_vertical, rect.X + rect.Width - 2, rect.Y, rect.X + rect.Width - 2, rect.Y + rect.Height);


                        // draw left
                        e.Graphics.DrawLine(pen_horizental, rect.X + 1, rect.Y, rect.X + 1, rect.Y + rect.Height);
                        e.Graphics.DrawString(ls[0], e.Appearance.GetFont(), new SolidBrush(e.Appearance.GetForeColor()), rect, e.Appearance.GetStringFormat());
                        e.Handled = true;
                    }
                    //e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                    
                   


                    
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
