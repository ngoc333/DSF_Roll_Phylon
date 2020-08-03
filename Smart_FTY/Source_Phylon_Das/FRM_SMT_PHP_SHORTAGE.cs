using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OracleClient;
//using Com_Base;
using System.Data.SqlClient;
//using ChartDirector;
using System.Threading;
using Smart_FTY.Source_PU.Shortage;
using System.IO;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;
using System.Globalization;


namespace Smart_FTY
{
     public partial class FRM_SMT_PHP_SHORTAGE : Form
    {
        public FRM_SMT_PHP_SHORTAGE()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
      //  public string _zone="",_SMCF = "", _SMCT;
        public string _machine, _opcd = "";
        //string OP_CD, string MOLD, string MC_F, string MC_T


        public FRM_SMT_PHP_SHORTAGE(string argZone)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _machine =  argZone;

        }     
       
      
        Color colorActive = Color.LightSeaGreen;
        Color colordActive = Color.White;
        bool _Model = true;
      

            // Dictionary<string, GridBandEx> dictGridNo = new Dictionary<string, GridBandEx>();
        int _start_column = 0, _START_COL = 0;
        string strLine, strMLine, strStyle, strOP_CD, strCMP_CD, strymd = "", strFlow;

        #region Init
        

        #endregion Init
        #region Function

        private void GoFullscreen()
        {
            //if (fullscreen)
            //{
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            
        }
        



        #endregion Fuction
       

        private void loadData()
        {
            try
            {
                //panel1.Visible = false;
                //pcwait.Visible = false;
                //pcwait.BringToFront();             
                fn_GetDataSource("PHP", "", "P", "");            
            }
            catch { }
        }

   
        private void Frm_Mold_WS_Change_By_Shift_Load(object sender, EventArgs e)
        {
            GoFullscreen();          
            DataTable dt = new DataTable();
            pcwait.Visible = false;
            pcwait.BringToFront();
            cnt = 29;
            //loadData();
           
        }
      
        
      
        private void lblDate_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int cnt = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd")) + "\n\r" + string.Format(DateTime.Now.ToString("HH:mm:ss"));
                cnt++;
                if (cnt > 30)
                {
                    loadData();
                    cnt = 0;
                }
            }
            catch
            {
            }
        }     

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
       

         //====================================================================================
        private DataTable SEL_DATA_TALLY_SHEET()
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(12);
            MyOraDB.Process_Name = "MES.SP_GMES0267_2_Q";

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[7] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[8] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[9] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[10] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[11] = (int)OracleType.Cursor;


            //V_P_TYPE,V_P_OPTION
            MyOraDB.Parameter_Name[0] = "ARG_TYPE";
            MyOraDB.Parameter_Name[1] = "ARG_VERSION_ID";
            MyOraDB.Parameter_Name[2] = "ARG_MACHINE";
            MyOraDB.Parameter_Name[3] = "ARG_MOLD";
            MyOraDB.Parameter_Name[4] = "V_P_ERROR_CODE";
            MyOraDB.Parameter_Name[5] = "V_P_ROW_COUNT";
            MyOraDB.Parameter_Name[6] = "V_P_ERROR_NOTE";
            MyOraDB.Parameter_Name[7] = "V_P_RETURN_STR";
            MyOraDB.Parameter_Name[8] = "V_P_ERROR_STR";
            MyOraDB.Parameter_Name[9] = "V_ERRORSTATE";
            MyOraDB.Parameter_Name[10] = "V_ERRORPROCEDURE";
            MyOraDB.Parameter_Name[11] = "CV_1";


            MyOraDB.Parameter_Values[0] = "";
            MyOraDB.Parameter_Values[1] = dtpYMD.Value.ToString("yyyyMMdd");
            MyOraDB.Parameter_Values[2] = "MC" + _machine;
            MyOraDB.Parameter_Values[3] = _Model == true ? "MODEL" : "MOLD";
            MyOraDB.Parameter_Values[4] = "";
            MyOraDB.Parameter_Values[5] = "";
            MyOraDB.Parameter_Values[6] = "";
            MyOraDB.Parameter_Values[7] = "";
            MyOraDB.Parameter_Values[8] = "";
            MyOraDB.Parameter_Values[9] = "";
            MyOraDB.Parameter_Values[10] = "";
            MyOraDB.Parameter_Values[11] = "";

            MyOraDB.Add_Select_Parameter(true);
            retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;
            return retDS.Tables[MyOraDB.Process_Name];
        }


        private DataTable SEL_DATA_MAIN(string STROP_CD, string STRCMP_CD, string STRDIV, string STRLINE)
        {
            try
            {
                System.Data.DataSet retDS;
                COM.OraDB MyOraDB = new COM.OraDB();

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = "MES.SP_GMES0009_12_Q";
                //  for (int i = 0; i < intParm; i++)

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                //MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
                //MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
                //MyOraDB.Parameter_Type[7] = (char)OracleType.VarChar;
                //MyOraDB.Parameter_Type[8] = (char)OracleType.VarChar;
                //MyOraDB.Parameter_Type[9] = (char)OracleType.VarChar;
                //MyOraDB.Parameter_Type[10] = (char)OracleType.VarChar;
                //MyOraDB.Parameter_Type[11] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                //V_P_TYPE,V_P_OPTION
                MyOraDB.Parameter_Name[0] = "STROP_CD";
                MyOraDB.Parameter_Name[1] = "STRCMP_CD";
                MyOraDB.Parameter_Name[2] = "STRDIV";
                MyOraDB.Parameter_Name[3] = "STRLINE";
                MyOraDB.Parameter_Name[4] = "STRD_D";
                //MyOraDB.Parameter_Name[5] = "V_P_ERROR_CODE";
                //MyOraDB.Parameter_Name[6] = "V_P_ROW_COUNT";
                //MyOraDB.Parameter_Name[7] = "V_P_ERROR_NOTE";
                //MyOraDB.Parameter_Name[8] = "V_P_RETURN_STR";
                //MyOraDB.Parameter_Name[9] = "V_P_ERROR_STR";
                //MyOraDB.Parameter_Name[10] = "V_ERRORSTATE";
                //MyOraDB.Parameter_Name[11] = "V_ERRORPROCEDURE";
                MyOraDB.Parameter_Name[5] = "CV_1";

                // STROP_CD = 'PUP' AND STRDIV = 'PO' THEN 'PUP','','P','','20190826'
                MyOraDB.Parameter_Values[0] = _opcd;// "PUP";
                MyOraDB.Parameter_Values[1] = "";// STRCMP_CD;
                MyOraDB.Parameter_Values[2] = "P";// STRDIV; // "PO";
                MyOraDB.Parameter_Values[3] = "";// STRLINE;
                MyOraDB.Parameter_Values[4] = dtpYMD.Value.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[5] = "";
                //MyOraDB.Parameter_Values[6] = "";
                //MyOraDB.Parameter_Values[7] = "";
                //MyOraDB.Parameter_Values[8] = "";
                //MyOraDB.Parameter_Values[9] = "";
                //MyOraDB.Parameter_Values[10] = "";
                //MyOraDB.Parameter_Values[11] = "";
                //MyOraDB.Parameter_Values[12] = "";

                MyOraDB.Add_Select_Parameter(true);
                retDS = MyOraDB.Exe_Select_Procedure();
                if (retDS == null) return null;
                return retDS.Tables[MyOraDB.Process_Name];
            }
            catch (Exception)
            {
                return null;
            }

        }


        private DataTable SEL_DATA_DETAIL(string STROP_CD,string  STRCMP_CD,string STRDIV,string CHKSTYLE,string STRLINE,string STRMLINE,string STRSTYLE,string STRYMD)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(17);
            MyOraDB.Process_Name = "MES.SP_GMES0009_5_Q";
            //  for (int i = 0; i < intParm; i++)

            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[7] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[8] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[9] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[10] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[11] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[12] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[13] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[14] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[15] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[16] = (int)OracleType.Cursor;

            //('PUP','PUP','PU AIRBAG','P','N','004','003','CU4919100','20190827'
            //V_P_TYPE,V_P_OPTION
            MyOraDB.Parameter_Name[0] = "PROCESS_CD";
            MyOraDB.Parameter_Name[1] = "STROP_CD";
            MyOraDB.Parameter_Name[2] = "STRCMP_CD";
            MyOraDB.Parameter_Name[3] = "STRDIV";
            MyOraDB.Parameter_Name[4] = "CHKSTYLE";
            MyOraDB.Parameter_Name[5] = "STRLINE";
            MyOraDB.Parameter_Name[6] = "STRMLINE";
            MyOraDB.Parameter_Name[7] = "STRSTYLE";
            MyOraDB.Parameter_Name[8] = "STRYMD";
            MyOraDB.Parameter_Name[9] = "V_P_ERROR_CODE";
            MyOraDB.Parameter_Name[10] = "V_P_ROW_COUNT";
            MyOraDB.Parameter_Name[11] = "V_P_ERROR_NOTE";
            MyOraDB.Parameter_Name[12] = "V_P_RETURN_STR";
            MyOraDB.Parameter_Name[13] = "V_P_ERROR_STR";
            MyOraDB.Parameter_Name[14] = "V_ERRORSTATE";
            MyOraDB.Parameter_Name[15] = "V_ERRORPROCEDURE";
            MyOraDB.Parameter_Name[16] = "CV_1";


            MyOraDB.Parameter_Values[0] = _opcd;
            MyOraDB.Parameter_Values[1] = STROP_CD;   //PUP          //
            MyOraDB.Parameter_Values[2] = STRCMP_CD;// "PU AIRBAG";
            MyOraDB.Parameter_Values[3] = STRDIV;//P
            MyOraDB.Parameter_Values[4] = CHKSTYLE;//N
            MyOraDB.Parameter_Values[5] = STRLINE;// "013";
            MyOraDB.Parameter_Values[6] = STRMLINE;// "007";
            MyOraDB.Parameter_Values[7] = STRSTYLE;// "CT1618400";
            MyOraDB.Parameter_Values[8] = STRYMD; //20190830
            MyOraDB.Parameter_Values[9] = "";
            MyOraDB.Parameter_Values[10] = "";
            MyOraDB.Parameter_Values[11] = "";
            MyOraDB.Parameter_Values[12] = "";
            MyOraDB.Parameter_Values[13] = "";
            MyOraDB.Parameter_Values[14] = "";
            MyOraDB.Parameter_Values[15] = "";
            MyOraDB.Parameter_Values[16] = "";


            MyOraDB.Add_Select_Parameter(true);
            retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;
            return retDS.Tables[MyOraDB.Process_Name];
        }

        public void CreateSizeGrid(GridControl gridControl, BandedGridView gridView, DataTable dt)
        {
            gridView.BeginDataUpdate();
            try
            {
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.OptionsView.AllowCellMerge = true;
                gridView.Bands.Clear();
                gridView.OptionsView.ShowColumnHeaders = false;
                int _start_col = Convert.ToInt32(dt.Rows[0]["START_COL"]);
                GridBand[] band = new GridBand[_start_col + (dt.Columns.Count - _start_col - 1) / 2];
                int i_arr = _start_col;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i < _start_col)
                    {
                        band[i] = new GridBand() { Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dt.Columns[i].ColumnName.Replace("_", " ").ToLower()) };
                        gridView.Bands.Add(band[i]);
                        band[i].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = band[i].Caption });
                        band[i].Fixed = FixedStyle.Left;
                        if (dt.Columns[i].ColumnName.Equals("OP_CD") || dt.Columns[i].ColumnName.Equals("LINE_CD"))
                        {
                            band[i].Visible = false;
                        }
                    }
                    else if (i > _start_col)
                    {
                        if (dt.Columns[i].ColumnName.Contains("TOT"))
                        {
                            band[i_arr] = new GridBand() { Caption = "Total" };
                            gridView.Bands.Add(band[i_arr]);
                            band[i_arr].Children.Add(new GridBand() { Caption = "Prod" });
                            band[i_arr].Children[0].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "Prod" });
                            band[i_arr].Children.Add(new GridBand() { Caption = "Out" });
                            band[i_arr].Children[1].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i + 1].ColumnName, Visible = true, Caption = "Out" });

                            band[i_arr].Fixed = FixedStyle.Left;
                        }
                        else
                        {
                            band[i_arr] = new GridBand() { Caption = dt.Columns[i].ColumnName.Substring(5, 2) + "-" + dt.Columns[i].ColumnName.Substring(7, 2) };
                            gridView.Bands.Add(band[i_arr]);
                            band[i_arr].Children.Add(new GridBand() { Caption = "Prod" });
                            band[i_arr].Children[0].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "Prod" });
                            band[i_arr].Children.Add(new GridBand() { Caption = "Out" });
                            band[i_arr].Children[1].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i + 1].ColumnName, Visible = true, Caption = "Out" });
                        }
                        if (i + 1 < dt.Columns.Count)
                            i++;
                        i_arr++;
                    }
                }

                foreach (GridBand gb in gridView.Bands)
                {
                    FormatBand(gb);

                }
                gridView.OptionsView.ColumnAutoWidth = false;

                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    if (i >= _start_col)
                    {
                        gridView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gridView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridView.Columns[i].DisplayFormat.FormatString = "#,#.#";
                        gridView.Columns[i].Width = 60;
                    }
                    else
                    {
                        gridView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }
                    if (i < _start_col - 2)
                    {
                        gridView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    gridView.Columns[i].OptionsColumn.FixedWidth = false;
                    gridView.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView.Columns[i].OptionsColumn.AllowEdit = false;
                }
                gridView.Columns["LINE_NAME"].Width = 80;
                gridView.Columns["STYLE_NAME"].Width = 140;
                gridView.Columns["STYLE_CODE"].Width = 90;
                gridView.Columns["COMPONENT"].Width = 120;

            }
            catch (Exception EX)
            {
                //throw EX;
            }
            //gridControl.Show();
            gridView.EndDataUpdate();
            gridView.ExpandAllGroups();
        }


        public void FormatBand(GridBand root)
        {
            root.AppearanceHeader.Options.UseTextOptions = true;
            root.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            root.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            root.AppearanceHeader.Font = new Font("Calibri", 12);
            root.OptionsBand.FixedWidth = true;
            if (root.Children.Count > 0)
            {
                foreach (GridBand child in root.Children)
                {
                    FormatBand(child);
                }
            }
        }
        private void fn_GetDataSource(string STROP_CD, string STRCMP_CD, string STRDIV, string STRLINE)
        {
            try
            {
                while (gvwBase_Master.Columns.Count > 0)  
                {
                    gvwBase_Master.Columns.RemoveAt(0);
                }
                string cmp = "", op = "", line = "";
                pcwait.Visible = true;
                DataTable dtData = null;
                 dtData = SEL_DATA_MAIN(_opcd, "", "P", "");
                if (dtData != null && dtData.DataSet != null && dtData.DataSet.Tables.Count > 0 && dtData.DataSet.Tables[0].Rows.Count > 0)
                {
                    DataTable dtf = SEL_DATA_MAIN(_opcd, "", "P", "");
                    DataTable dtResult = dtf.Copy();
                    dtResult.Rows.Clear();
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    double[] m = new double[dtf.Columns.Count];
                    double[] l = new double[dtf.Columns.Count];
                    double[] c = new double[dtf.Columns.Count];
                    double[] o = new double[dtf.Columns.Count];
                    double[] total = new double[dtf.Columns.Count];
                    double[] rowtotal = new double[dtf.Columns.Count];
                    int begin = 7;
                    double temp = 0;
                     dtResult.Rows.Add(op, "", "G-Total", " ", "  ");
                     for (int i = 0; i < dtf.Rows.Count; i++)
                        {

                            for (int j = begin; j < dtf.Columns.Count; j++)
                            {
                                if (line != dtf.Rows[i]["LINE_CD"].ToString().ToUpper().Trim()) // neu khac line dong i-1
                                {                                   
                                        if (line != "")
                                        {
                                            dtResult.Rows.Add(op, line, "Total", "", "");
                                            for (int k = begin; k < dtf.Columns.Count; k++)
                                            {
                                                dtResult.Rows[dtResult.Rows.Count - 1][k] = l[k];
                                                l[k] = 0;
                                            }
                                        }
                                        line = dtf.Rows[i]["LINE_CD"].ToString().ToUpper();                                  
                                }
                                //------------------------------
                                if (cmp != dtf.Rows[i]["CMP_CD"].ToString().ToUpper().Trim())
                                {                                   
                                    cmp = dtf.Rows[i]["CMP_CD"].ToString().ToUpper();
                                }
                                //------------------------------
                                if (op != dtf.Rows[i]["OP_CD"].ToString().ToUpper().Trim())
                                {
                                   
                                    op = dtf.Rows[i]["OP_CD"].ToString().ToUpper();
                                }
                                //------------------------------
                                double.TryParse(dtf.Rows[i][j].ToString(), out temp);
                                if (temp != 0)
                                {
                                    m[j] += temp;
                                    l[j] += temp;
                                    c[j] += temp;
                                    o[j] += temp;
                                    total[j] += temp;
                                    rowtotal[j] += temp;
                                }

                                //value = 0 then :=null
                                if (dtf.Rows[i][j].ToString() == "0")
                                {
                                    dtf.Rows[i][j] = DBNull.Value;
                                }

                            }
                            dtResult.Rows.Add(dtf.Rows[i].ItemArray.ToArray());
                        }
                    //----------TOTAL CHO DONG CUOI----------//
                     dtResult.Rows.Add(op, line, "Total", "", "");
                     for (int k = begin; k < dtf.Columns.Count; k++)
                     {

                         dtResult.Rows[dtResult.Rows.Count - 1][k] = l[k];
                         l[k] = 0;
                     }
                     line = dtf.Rows[dtf.Rows.Count-1]["LINE_CD"].ToString().ToUpper();
                    if (line != "" && cmp != "" && op != "")//mline != "" 
                    {
                        for (int k = begin; k < dtf.Columns.Count; k++)
                        {
                            dtResult.Rows[0][k] = rowtotal[k];
                            rowtotal[k] = 0;
                        }
                    }                
                    grdBase_Master.DataSource = dtResult;
                    Set_Format_Grid_Master();
                    pcwait.Visible = false;
                }
                else
                {
                    pcwait.Visible = false;
                    return ;
                }
            }
            catch (Exception ex)
            {            
                return ;
            }

            return;
        }


        private void Set_Format_Grid_Master()
        {
            try
            {
                gvwBase_Master.BeginUpdate();
                gvwBase_Master.BestFitColumns();
                int begin = 7;
                for (int i = 0; i < gvwBase_Master.Columns.Count; i++)
                {
                    gvwBase_Master.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    gvwBase_Master.Columns[i].Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gvwBase_Master.Columns[i].GetCaption().Replace("_", " ").Replace("'", "").ToLower());
                    gvwBase_Master.Columns[i].Caption = gvwBase_Master.Columns[i].GetCaption().Replace("Op Cd", "Process");
                    gvwBase_Master.Columns[i].Caption = gvwBase_Master.Columns[i].GetCaption().Replace("Cmp Cd", "Component");
                    gvwBase_Master.Columns[i].Caption = gvwBase_Master.Columns[i].GetCaption().Replace("Mline Cd", "Mline");
                    gvwBase_Master.Columns[i].Caption = gvwBase_Master.Columns[i].GetCaption().Replace("Style Cd", "Style Code");
                    gvwBase_Master.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase_Master.Columns[i].AppearanceCell.Options.UseTextOptions = true;

                    if (i < 7)
                    {
                        if (i == 5)
                        {
                            gvwBase_Master.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gvwBase_Master.Columns[i].Width = 150;
                        }
                        else
                        {
                            gvwBase_Master.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        }
                    }
                    else
                    gvwBase_Master.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    gvwBase_Master.Columns[i].OptionsColumn.ReadOnly = true;
                    gvwBase_Master.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwBase_Master.Columns[i].OptionsFilter.AllowFilter = false;
                    gvwBase_Master.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


                    if (gvwBase_Master.Columns[i].AbsoluteIndex >= begin)
                    {
                        if (gvwBase_Master.Columns[i].AbsoluteIndex > begin)
                        {
                            string CAPTION1 = gvwBase_Master.Columns[i].GetCaption().Substring(4, 2);
                            string CAPTION2 = gvwBase_Master.Columns[i].GetCaption().Substring(6, 2);

                            gvwBase_Master.Columns[i].Caption = CAPTION1 + "-" + CAPTION2;
                        }
                        gvwBase_Master.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gvwBase_Master.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gvwBase_Master.Columns[i].DisplayFormat.FormatString = "#,#.#";

                        if (gvwBase_Master.Columns[i].Summary.Count > 0)
                        {
                            gvwBase_Master.Columns[i].Summary.RemoveAt(0);
                        }

                    }
                    else if (gvwBase_Master.Columns[i].AbsoluteIndex < 5)
                    {
                        gvwBase_Master.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    //   gvwBase_Master.Columns[i].Width = i == 6 ? 120 : i == 5?210:i == 3?100:80;
                    if (i < 8)
                    {
                        gvwBase_Master.Columns[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        gvwBase_Master.Columns[i].Width = 200;
                    }
                }

                // ---width--

                for (int i = begin; i < gvwBase_Master.Columns.Count; i++)
                {
                    gvwBase_Master.Columns[i].Width = 130;
                }
                gvwBase_Master.Columns["TOTAL"].Width = 180;
                gvwBase_Master.Columns["LINE_CD"].Visible = false;
                gvwBase_Master.Columns["OP_CD"].Visible = false;
                gvwBase_Master.OptionsView.ColumnAutoWidth = false;
                gvwBase_Master.TopRowIndex = 0;
                gvwBase_Master.EndUpdate();
            }
            catch (Exception ex)
            {

            }
        }

      //  #endregion

        int columns = 0;
        string count = "";
      
        private void fnExcelSize(DataTable dta)
        {            
            //init size run
            double i;
            int k = 0;
            DataTable dt = new DataTable();
            dt.Rows.Add();
            dt.Rows.Add();
            dt.Rows.Add();
            for(i=0;i<45;i++)
            dt.Columns.Add();

            dt.Rows[0][8] = "TD";
            dt.Rows[1][8] = "TS";
            dt.Rows[2][8] = "ME/WO";
            k = 0;
            for (i = 2; i <= 15.5; i += 0.5)
            {
                dt.Rows[0][9+k] = i.ToString().Replace(".5","T");
                k++;
            }
            for (i = 16; i <= 21; i ++)
            {
                dt.Rows[0][9 + k] = i.ToString();
                k++;
            }

            k = 0;
            for (i = 10; i <= 13.5; i += 0.5)
            {
                dt.Rows[1][9 + k] = i.ToString().Replace(".5", "T");
                k++;
            }
            for (i = 1; i <= 10; i++)
            {
                dt.Rows[1][9 + k] = i.ToString();
                k++;
            }

            k = 0;
            for (i = 1; i <= 12.5; i += 0.5)
            {
                dt.Rows[2][9 + k] = i.ToString().Replace(".5", "T");
                k++;
            }
            for (i = 13; i <= 22; i++)
            {
                dt.Rows[2][9 + k] = i.ToString();
                k++;
            }           

            //setdata
            string tmp="";
            int rNum=2;
            int rSizeNum;
            foreach (DataRow r in dta.Rows)
            {
                //0457
                if (tmp != r[0].ToString() + r[4].ToString() + r[5].ToString() + r[7].ToString())
                {
                    dt.Rows.Add();           
                    rNum++;
                    dt.Rows[rNum][0] = r[0].ToString();
                    dt.Rows[rNum][1] = r[1].ToString();
                    dt.Rows[rNum][2] = r[2].ToString();
                    dt.Rows[rNum][3] = r[3].ToString();
                    dt.Rows[rNum][4] = r[4].ToString();
                    dt.Rows[rNum][5] = r[5].ToString();
                    dt.Rows[rNum][6] = r[6].ToString();
                    dt.Rows[rNum][7] = r[7].ToString();
                    dt.Rows[rNum][8] = r[8].ToString();
                }
                if (r[8].ToString() == "ME")             rSizeNum = 2;
                else if (r[8].ToString() == "WO")        rSizeNum = 2;
                else                                     rSizeNum = 1;
                for (int j = 7; j < dt.Columns.Count - 1; j++)
                {
                    if (r[9].ToString().Equals(dt.Rows[rSizeNum][j].ToString()))
                    {
                        dt.Rows[rNum][j] = r[10].ToString();
                        break;
                    }
                }
                tmp = r[0].ToString() + r[4].ToString() + r[5].ToString() + r[7].ToString();
            }

            //export DT to excel

         //   SetData(gridControlEx1, dt);
            gridControlEx1.DataSource = dt;

            if ( openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                
                gridViewEx1.OptionsView.AllowCellMerge = false;
                gridViewEx1.ExportToXlsx(openFileDialog1.FileName);                                
            }
            gridControlEx1.Visible = false;

        }

        public void ExportToExcel(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {                

            }
        }

        private void fn_GetDataSource_Detail(string STROP_CD, string STRCMP_CD, string STRDIV, string CHKSTYLE, string STRLINE, string STRMLINE, string STRSTYLE, string STRYMD)
        {
            try
            {
                while (gvwBase_Detail.Columns.Count > 0)
                {
                    gvwBase_Detail.Columns.RemoveAt(0);
                }
                pcwait.Visible = true;
                DataTable dt = null;
                dt = SEL_DATA_DETAIL(STROP_CD, STRCMP_CD, STRDIV, CHKSTYLE, STRLINE, STRMLINE, STRSTYLE, STRYMD);
                if (dt.Rows.Count > 0)
                {
                    DataTable dtSource = new DataTable();
                    if (!buildHeader(dtSource, dt)) return;
                    if (!bindingDataSource(dtSource, dt)) return;

                    grdBase_Detail.DataSource = dtSource;
                    Set_Format_Grid_Detail();
                }
                pcwait.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void Set_Format_Grid_Detail()
        {
            gvwBase_Detail.BeginUpdate();
            for (int i = 0; i < gvwBase_Detail.Columns.Count; i++)
            {
                gvwBase_Detail.Columns[i].Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gvwBase_Detail.Columns[i].GetCaption().Replace("_", " ").ToLower()); ;
                gvwBase_Detail.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase_Detail.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                gvwBase_Detail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                if (i == 0)
                {
                    gvwBase_Detail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    gvwBase_Detail.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 16, FontStyle.Bold);
              //      gvwBase_Detail.Columns[i].AppearanceCell.Font = new Font(FontFamily, FontStyle.Bold);
                   // 
                }
                if (i == 1)
                {
                    gvwBase_Detail.Columns[i].Width = 150;
                    gvwBase_Detail.Columns[i].AppearanceCell.ForeColor = Color.Red;
                    gvwBase_Detail.Columns[i].VisibleIndex = 99;
                }

                gvwBase_Detail.Columns[i].OptionsColumn.ReadOnly = true;
                gvwBase_Detail.Columns[i].OptionsColumn.AllowEdit = false;
                gvwBase_Detail.Columns[i].OptionsFilter.AllowFilter = false;
                gvwBase_Detail.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


                if (gvwBase_Detail.Columns[i].AbsoluteIndex >= _start_column - 1)
                {
                    gvwBase_Detail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    gvwBase_Detail.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gvwBase_Detail.Columns[i].DisplayFormat.FormatString = "n0";
                    gvwBase_Detail.Columns[i].MinWidth = 90;
                    if (gvwBase_Detail.Columns[i].Summary.Count > 0)
                    {
                        gvwBase_Detail.Columns[i].Summary.RemoveAt(0);
                    }

                }
            }

            gvwBase_Detail.BestFitColumns();
            gvwBase_Detail.OptionsView.ColumnAutoWidth = false;
            gvwBase_Detail.TopRowIndex = 0;
            gvwBase_Detail.EndUpdate();
        }

        private bool buildHeader(DataTable dtSource, DataTable dt)
        {
            try
            {
                int.TryParse(dt.Rows[0]["START_COLUMN"].ToString(), out _start_column);
                for (int i = 0; i < _start_column - 1; i++)
                {
                    dtSource.Columns.Add(dt.Columns[i].Caption);
                }
                dtSource.Columns.Add("TOTAL", typeof(double));
                DataRow[] row = dt.Select("", "SIZE_NUM ASC");
                double min = 1, max = 22;
                double.TryParse(row[0]["SIZE_NUM"].ToString(), out min);
                double.TryParse(row[row.Length - 1]["SIZE_NUM"].ToString(), out max);
                for (double i = min; i <= max; i = i + 0.5)
                {
                    dtSource.Columns.Add(i.ToString().Replace(".5", "T"), typeof(double));
                }

                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        private bool bindingDataSource(DataTable dtSource, DataTable dt)
        {
            try
            {
                int[] rowtotal = new int[dtSource.Columns.Count];
                string distinct_row = "";
                int temp1, temp2;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (distinct_row != dt.Rows[i]["DISTINCT_ROW"].ToString())
                    {
                        dtSource.Rows.Add();
                    }
                    distinct_row = dt.Rows[i]["DISTINCT_ROW"].ToString();

                    for (int j = 0; j < _start_column - 1; j++)
                    {
                        dtSource.Rows[dtSource.Rows.Count - 1][j] = dt.Rows[i][j];
                    }

                    int.TryParse(dt.Rows[i]["QTY"].ToString(), out temp1);
                    int.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][dt.Rows[i]["SIZE_CD"].ToString()].ToString(), out temp2);
                    dtSource.Rows[dtSource.Rows.Count - 1][dt.Rows[i]["SIZE_CD"].ToString()] = (temp1 + temp2).ToString();

                    int.TryParse(dtSource.Rows[dtSource.Rows.Count - 1][_start_column - 1].ToString(), out temp2);
                    dtSource.Rows[dtSource.Rows.Count - 1][_start_column - 1] = (temp1 + temp2).ToString();
                }
                return true;

            }
            catch (Exception ex)
            {
               // this.MessageBoxW("bindingDataSource(): " + ex.Message);
                return false;
            }
        }

      
        int clicks = 0;

      
        string strOpcd;
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            //if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    gvwBase_Master.ExportToXlsx(saveFileDialog1.FileName);
            //    //gridControlEx1.Visible = false;
            //}


           // pcwait.Visible = true;

            //SP_GMES0009_6_Q cProc = new SP_GMES0009_6_Q("SP_GMES0009_6_Q");
            //DataTable dtData = null;

            //strOP_CD = "4";
            //if (cboProcess.EditValue.ToString() == "GB1")
            //    strOP_CD = "1";
            //else if (cboProcess.EditValue.ToString() == "GB2")
            //    strOP_CD = "2";
            //else
            //    if (cboProcess.EditValue.ToString() + cbo_Flow.EditValue.ToString() == "FSSP" || cboProcess.EditValue.ToString() == "FGA")
            //        strOP_CD = "3";
            //    else
            //        strOP_CD = "4";

            ////fn_GetDataSource(cboProcess.EditValue.ToString(), cbo_Comp.EditValue.ToString(), cbo_Flow.EditValue.ToString(), cbo_Line.EditValue.ToString());
            //dtData = cProc.SetParamData(dtData, cboProcess.EditValue.ToString(), cbo_Comp.EditValue.ToString(), cbo_Flow.EditValue.ToString(), "", strOP_CD, cbo_Line.EditValue.ToString(), ymd_Proc_Date.DateTime.ToString("yyyyMM" + "01"), ymd_Proc_Date.DateTime.ToString("yyyyMMdd"));
            //ResultSet rs = CommonCallQuery(ServiceInfo.LMESBizDB, dtData, cProc.ProcName, cProc.GetParamInfo(), false, 90000, "", false);

            //if (rs != null && rs.ResultDataSet != null && rs.ResultDataSet.Tables.Count > 0 && rs.ResultDataSet.Tables[0].Rows.Count > 0)
            //{
            //    DataTable dtf = rs.ResultDataSet.Tables[0];
            //    gridControlEx1.Visible = true;
            //    fnExcelSize(dtf);
            //}
            //pcwait.Visible = false;
        }

        
        

         private void gvwBase_Master_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
         {
          try
            {
                if (e.RowHandle < 0)
                    return;

                //tomau row
                string tomau_row = gvwBase_Master.GetRowCellDisplayText(e.RowHandle, "OP_CD");
                string tomau_row1 = gvwBase_Master.GetRowCellDisplayText(e.RowHandle, "CMP_CD");
                string tomau_row2 = gvwBase_Master.GetRowCellDisplayText(e.RowHandle, "LINE_NAME");
                string tomau_row3 = gvwBase_Master.GetRowCellDisplayText(e.RowHandle, "MLINE_CD");

                if (tomau_row.Contains("Total"))
                {
                    e.Appearance.BackColor = Color.BurlyWood;
                }
                if (tomau_row1.Contains("Total") && e.Column.AbsoluteIndex > 0)
                {
                    e.Appearance.BackColor = Color.LightSkyBlue;
                }
                if (tomau_row2.Contains("Total") && e.Column.AbsoluteIndex > 1)
                {
                    e.Appearance.BackColor = Color.SkyBlue;

                }
                if (tomau_row2.Contains("G-Total") && e.Column.AbsoluteIndex > 1)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if (tomau_row3.Contains("Total") && e.Column.AbsoluteIndex > 2)
                {
                    e.Appearance.BackColor = Color.CadetBlue;
                }

            }
            catch (Exception ex)
            {
              
            }
         }

         private void gvwBase_Detail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
         {
         
         }


         //private void gvw_marter_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
         //{
         //columns = e.Column.AbsoluteIndex;
         //   count = e.CellValue.ToString();
         //   if (e.Column.AbsoluteIndex > 7)
         //   {
         //       strLine = gvw_marter.GetRowCellDisplayText(e.RowHandle, gvw_marter.Columns["LINE_CD"]).Trim();
         //       strMLine = gvw_marter.GetRowCellDisplayText(e.RowHandle, gvw_marter.Columns["MINI_LINE"]).Trim();
         //       strStyle = gvw_marter.GetRowCellDisplayText(e.RowHandle, gvw_marter.Columns["STYLE_CODE"]).Trim().Replace("-","");
         //       strOP_CD = gvw_marter.GetRowCellDisplayText(e.RowHandle, gvw_marter.Columns["OP_CD"]).Trim();
         //       strCMP_CD = gvw_marter.GetRowCellDisplayText(e.RowHandle, gvw_marter.Columns["COMPONENT"]).Trim();
         //       strFlow = e.Column.Caption.Substring(0, 1); 
         //       process_op = "PUP";//cboProcess.EditValue.ToString();  
         //       string aaa = e.Column.Name.ToString().Replace("'", "");
         //       strymd = aaa.Substring(3, 8);

         //       //if (process_op == "PUP")// && cbo_Flow.EditValue.ToString() == "P")
         //       //{
         //       //    strCMP_CD = strCMP_CD.ToString().Split('-')[1];
         //       //}


         //       fn_GetDataSource_Detail(strOP_CD, strCMP_CD, strFlow, "N", strLine, strMLine, strStyle, strymd);
         //   }
         //}

         private void gvw_marter_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
         {
              try
            {
                if (e.RowHandle < 0)
                    return;

                //tomau row
                string tomau_row = gvw_marter.GetRowCellDisplayText(e.RowHandle, "LINE_NAME");

                if (tomau_row.Contains("Total"))
                {
                    e.Appearance.BackColor = Color.SkyBlue;
                }
                
                if (tomau_row.Contains("G-Total") && e.Column.AbsoluteIndex > 1)
                {
                    e.Appearance.BackColor = Color.Pink;
                }                
            }
            catch (Exception ex)
            {             
            }
         }

         private void gvwBase_Master_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
         {
             columns = e.Column.AbsoluteIndex;
             count = e.CellValue.ToString();
             if (e.Column.AbsoluteIndex > 7)
             {
                 strLine = gvwBase_Master.GetRowCellDisplayText(e.RowHandle, gvwBase_Master.Columns["LINE_CD"]).Trim();
                 strMLine = gvwBase_Master.GetRowCellDisplayText(e.RowHandle, gvwBase_Master.Columns["MLINE_CD"]).Trim();
                 strStyle = gvwBase_Master.GetRowCellDisplayText(e.RowHandle, gvwBase_Master.Columns["STYLE_CD"]).Trim();
                 strOP_CD = gvwBase_Master.GetRowCellDisplayText(e.RowHandle, gvwBase_Master.Columns["OP_CD"]).Trim();
                 strCMP_CD = gvwBase_Master.GetRowCellDisplayText(e.RowHandle, gvwBase_Master.Columns["CMP_CD"]).Trim();
                 string aaa = e.Column.Name.ToString().Replace("'", "");
                 strymd = aaa.Substring(3, 8);              
                 fn_GetDataSource_Detail(strOP_CD, strCMP_CD, "P", "N", strLine, strMLine, strStyle, strymd);
                
             }
         }

         private void gvwBase_Master_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
         {
             try
             {
                 if (e.RowHandle1 < 0 || gvw_marter.RowCount == 0)
                     return;

                 e.Merge = false;
                 e.Handled = true;


                 if (e.Column.FieldName == "LINE_NAME")
                 {
                     string line1 = gvwBase_Master.GetRowCellValue(e.RowHandle1, "LINE_NAME").ToString().Trim();
                     string line2 = gvwBase_Master.GetRowCellValue(e.RowHandle2, "LINE_NAME").ToString().Trim();
                     if (line1 == line2)
                     {
                         e.Merge = true;
                     }
                     else
                     {
                         e.Merge = false;
                     }
                 }

                 if (e.Column.FieldName == "MINI_LINE")
                 {
                     string Mline1 = gvwBase_Master.GetRowCellValue(e.RowHandle1, "MINI_LINE").ToString().Trim();
                     string Mline2 = gvwBase_Master.GetRowCellValue(e.RowHandle2, "MINI_LINE").ToString().Trim();

                     string line1 = gvwBase_Master.GetRowCellValue(e.RowHandle1, "LINE_NAME").ToString().Trim();
                     string line2 = gvwBase_Master.GetRowCellValue(e.RowHandle2, "LINE_NAME").ToString().Trim();
                     if (Mline1 == Mline2 && line1 == line2)
                     {
                         e.Merge = true;
                     }
                     else
                     {
                         e.Merge = false;
                     }
                 }

                 if (e.Column.FieldName == "STYLE_NAME")
                 {
                     string model1 = gvwBase_Master.GetRowCellValue(e.RowHandle1, "STYLE_NAME").ToString().Trim();
                     string model2 = gvwBase_Master.GetRowCellValue(e.RowHandle2, "STYLE_NAME").ToString().Trim();

                     string line1 = gvwBase_Master.GetRowCellValue(e.RowHandle1, "MINI_LINE").ToString().Trim();
                     string line2 = gvwBase_Master.GetRowCellValue(e.RowHandle2, "MINI_LINE").ToString().Trim();
                     if (model1 == model2 && line1 == line2)
                     {
                         e.Merge = true;
                     }
                     else
                     {
                         e.Merge = false;
                     }
                 }
             }
             catch (Exception ex)
             {
                 // this.MessageBoxW("gvwBase_CellMerge() \n " + ex.Message);
             }
         }

         private void grdBase_Master_VisibleChanged(object sender, EventArgs e)
         {
             try
             {
                 _opcd = "PHP";
                 lbl_header.Text = "Phylon Shortage Summary";

             }
             catch
             {
             }
         }

    }



         //====================================================================================
       
    
}
