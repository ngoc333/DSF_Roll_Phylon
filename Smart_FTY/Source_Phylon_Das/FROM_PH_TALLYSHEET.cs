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
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Reflection;

namespace Smart_FTY
{
     public partial class FROM_PH_TALLYSHEET : Form
    {
        public FROM_PH_TALLYSHEET()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public string _SOPCD="",_SMCF = "", _SMCT;
        //string OP_CD, string MOLD, string MC_F, string MC_T
        public FROM_PH_TALLYSHEET(string title, string opcd, string mc_f, string mc_t)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _SOPCD = opcd;
            _SMCF = mc_f;
            _SMCT = mc_t;
        }
        int col;
        int row;
        Color lastColor;
       
        private DataTable dtcalwork = null;
        private DataTable sharedData = null;
        Color colorActive = Color.LightSeaGreen;
        Color colordActive = Color.White;
        bool Model = true;
        string strCOL = "";
        string strLine_CD;
        int _start_column = 0;
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
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //}
        }

        private void create_default()
        {

        }

        private string GetShift(string arg_shift, string arg_date)
        {
            string str_shift, str_date;
            if (arg_date == DateTime.Now.ToString("yyyyMMdd")) str_date = " (Today)";
            else str_date = " (Yesterday)";
            if (arg_shift == "10") str_shift = "Shift 1";
            else if (arg_shift == "20") str_shift = "Shift 2";
            else str_shift = "Shift 3";
            return str_shift + str_date;
        }

        private string NVZ(string a)
        {
            if (a == "")
                a = "0";
            return a;
        }



        #endregion Fuction


        private void Set_Format_Grid()
        {
            gvwBase.BeginUpdate();
            for (int i = 0; i < gvwBase.Columns.Count; i++)
            {
                gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                
                gvwBase.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwBase.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;



                gvwBase.Columns[i].OptionsColumn.ReadOnly = true;
                gvwBase.Columns[i].OptionsColumn.AllowEdit = false;
                gvwBase.Columns[i].OptionsFilter.AllowFilter = false;
                gvwBase.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                //if (Model)
                //{
                //    gvwBase.Columns["MODEL_MOLD"].Width = 230;
                //}
                //else
                //{
                //    gvwBase.Columns["MODEL_MOLD"].Width = 200;
                //}
                if (i > 1)
                {
                    gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    // gvwBase.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    // gvwBase.Columns[i].DisplayFormat.FormatString = "#,#";
                }
                else
                {
                    gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                }
            }

            //gvwBase.BestFitColumns();
            gvwBase.OptionsView.ColumnAutoWidth = true;
            gvwBase.TopRowIndex = 0;
            gvwBase.RowHeight = 34;
            gvwBase.ColumnPanelRowHeight = 35;
            gvwBase.EndUpdate();
        }

        private DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] columns = null;
            if (Linqlist == null) return dt;
            foreach (T Record in Linqlist)
            {
                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void FormatBand(GridBand root)
        {
            root.AppearanceHeader.Options.UseTextOptions = true;
            root.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            root.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //root.AppearanceHeader.Font = new Font("Calibri", 14, FontStyle.Bold);
            root.OptionsBand.FixedWidth = true;
            if (root.Children.Count > 0)
            {
                foreach (GridBand child in root.Children)
                {
                    FormatBand(child);
                    child.Width = 55;
                }
            }
        }

        private bool CreateGrid(DataTable dt, GridControl gridControl, BandedGridView gridView)
        {
            try
            {
                gridControl.BeginUpdate();
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.OptionsView.AllowCellMerge = true;
                //gridView.BandPanelRowHeight = 35;
                gridView.Bands.Clear();
                gridView.Columns.Clear();
                gridControl.DataSource = null;
                gridView.OptionsView.ShowColumnHeaders = false;
                GridBand band = null;
                GridBand bandchlid1 = null;
                GridBand bandchlid2 = null;
                string distinct_row = "", sCol = "";
                _start_column = int.Parse(dt.Rows[0]["START_COLUMN"].ToString());

                var distinctValues = dt.AsEnumerable()
                                   .Select(row => new
                                   {
                                       YMD = row.Field<string>("YMD"),
                                       YMD_CAPTION = row.Field<string>("YMD_CAPTION"),
                                       SHIFT = row.Field<string>("SHIFT"),
                                       RN = row.Field<string>("RN"),
                                       HH = row.Field<string>("HH"),
                                       HH_CAPTION = row.Field<string>("HH_CAPTION")
                                   })
                                   .Distinct().OrderBy(r => r.YMD + r.SHIFT + r.RN + r.HH);
                DataTable dttmp = LINQResultToDataTable(distinctValues);
                string CAPTION = "";
                for (int i = 0; i < _start_column; i++)
                {
                    if (dt.Columns[i].ColumnName != "IE" && dt.Columns[i].ColumnName != "WS" && !dt.Columns[i].ColumnName.Contains("OSD"))
                    {
                        if (dt.Columns[i].ColumnName == "MC_NAME")
                        {
                            CAPTION = "Machine";
                        }
                        else if (dt.Columns[i].ColumnName == "STATION_CD")
                        {
                            CAPTION = "Station";
                        }
                        else if (dt.Columns[i].ColumnName == "MOLD_SIZE")
                        {
                            CAPTION = Model ? "Model" : "Mold";
                        }
                        else if (dt.Columns[i].ColumnName == "T_PLAN")
                        {
                            CAPTION = "S.Plan";
                        }
                        else if (dt.Columns[i].ColumnName == "T_RPLAN")
                        {
                            CAPTION = "R.Plan";
                        }
                        else if (dt.Columns[i].ColumnName == "T_ACT")
                        {
                            CAPTION = "Actual";
                        }
                        else if (dt.Columns[i].ColumnName == "RATE")
                        {
                            CAPTION = "Rate";
                        }
                        else if (dt.Columns[i].ColumnName == "QR")
                        {
                            CAPTION = "Def.";
                        }
                        else
                        {
                            CAPTION = dt.Columns[i].ColumnName;
                        }
                        band = new GridBand() { Caption = CAPTION };
                        gridView.Bands.Add(band);
                        band.RowCount = 2;
                        bandchlid2 = new GridBand() { Caption = "" };
                        band.Children.Add(bandchlid2);

                        BandedGridColumn col = new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = dt.Columns[i].ColumnName };
                        bandchlid2.Columns.Add(col);
                    }
                    else if (dt.Columns[i].ColumnName == "IE")
                    {
                        band = new GridBand() { Caption = "Cycle" };
                        gridView.Bands.Add(band);
                        bandchlid1 = new GridBand() { Caption = dt.Columns[i].ColumnName };
                        band.Children.Add(bandchlid1);
                        bandchlid2 = new GridBand() { Caption = "" };
                        bandchlid1.Children.Add(bandchlid2);
                        BandedGridColumn col = new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = dt.Columns[i].ColumnName };
                        bandchlid2.Columns.Add(col);
                        bandchlid2.Width = 45;
                    }
                    else if (dt.Columns[i].ColumnName == "OSD1")
                    {
                        band = new GridBand() { Caption = "OS&D (Left/Right)(Pcs)" };
                        gridView.Bands.Add(band);
                        bandchlid1 = new GridBand() { Caption = "Shift 1" };
                        band.Children.Add(bandchlid1);
                        bandchlid2 = new GridBand() { Caption = "" };
                        bandchlid1.Children.Add(bandchlid2);
                        BandedGridColumn col = new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = dt.Columns[i].ColumnName };
                        bandchlid2.Columns.Add(col);
                    }
                    else //if (dt.Columns[i].ColumnName == "WS" || dt.Columns[i].ColumnName.Contains("OSD1"))
                    {
                        if (dt.Columns[i].ColumnName == "WS")
                            bandchlid1 = new GridBand() { Caption = "W/S" };
                        else if (dt.Columns[i].ColumnName == "OSD2")
                            bandchlid1 = new GridBand() { Caption = "Shift 2" };
                        else if (dt.Columns[i].ColumnName == "OSD3")
                            bandchlid1 = new GridBand() { Caption = "Shift 3" };
                        band.Children.Add(bandchlid1);
                        bandchlid2 = new GridBand() { Caption = "" };
                        bandchlid1.Children.Add(bandchlid2);
                        BandedGridColumn col = new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = dt.Columns[i].ColumnName };
                        bandchlid2.Columns.Add(col);
                    }
                    band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    if (i <= 2)
                        band.Visible = false;
                }
                int cnt = 0;
                string shift = "";
                for (int i = 0; i < dttmp.Rows.Count; i++)
                {
                    if (!distinct_row.Equals(dttmp.Rows[i]["YMD"].ToString()))
                    {

                        distinct_row = dttmp.Rows[i]["YMD"].ToString();
                        band = new GridBand() { Caption = dttmp.Rows[i]["YMD_CAPTION"].ToString() };
                        gridView.Bands.Add(band);
                        //if (cnt == 0)
                        //{
                        //    band.AppearanceHeader.ForeColor = Color.Blue;
                        //    cnt = 1;
                        //}
                        //else
                        //{
                        //    band.AppearanceHeader.ForeColor = Color.DarkOrange;
                        //    cnt = 0;
                        //}
                    }

                    if (!shift.Equals(dttmp.Rows[i]["SHIFT"].ToString()))
                    {
                        shift = dttmp.Rows[i]["SHIFT"].ToString();
                    }

                    bandchlid1 = new GridBand() { Caption = dttmp.Rows[i]["HH_CAPTION"].ToString() };
                    band.Children.Add(bandchlid1);
                    bandchlid2 = new GridBand() { Caption = "", Name = string.Concat(dttmp.Rows[i]["YMD"].ToString(), dttmp.Rows[i]["HH"].ToString()) };
                    bandchlid1.Children.Add(bandchlid2);
                    BandedGridColumn col = new BandedGridColumn() { FieldName = string.Concat(dttmp.Rows[i]["YMD"].ToString(), dttmp.Rows[i]["HH"].ToString()), Visible = true, Caption = dttmp.Rows[i]["HH_CAPTION"].ToString() };
                    bandchlid2.Columns.Add(col);

                    //if (shift == "S001")
                    //{
                    //    bandchlid1.AppearanceHeader.ForeColor = Color.DodgerBlue;
                    //}
                    //else if (shift == "S002")
                    //{
                    //    bandchlid1.AppearanceHeader.ForeColor = Color.FromArgb(192, 0, 192);
                    //}
                    //else if (shift == "S003")
                    //{
                    //    bandchlid1.AppearanceHeader.ForeColor = Color.LightSeaGreen;
                    //}

                    if (dttmp.Rows[i]["HH"].ToString().Contains("S"))
                    {
                        bandchlid1 = new GridBand() { Caption = "Rate" };
                        band.Children.Add(bandchlid1);
                        bandchlid2 = new GridBand() { Caption = "", Name = string.Concat(dttmp.Rows[i]["YMD"].ToString(), dttmp.Rows[i]["HH"].ToString(), "RATE") };
                        bandchlid1.Children.Add(bandchlid2);
                        BandedGridColumn col1 = new BandedGridColumn() { FieldName = string.Concat(dttmp.Rows[i]["YMD"].ToString(), dttmp.Rows[i]["HH"].ToString(), "RATE"), Visible = true, Caption = "RATE" };
                        bandchlid2.Columns.Add(col1);
                    }

                    //if (shift == "S001")
                    //{
                    //    bandchlid1.AppearanceHeader.ForeColor = Color.DodgerBlue;
                    //}
                    //else if (shift == "S002")
                    //{
                    //    bandchlid1.AppearanceHeader.ForeColor = Color.FromArgb(192, 0, 192);
                    //}
                    //else if (shift == "S003")
                    //{
                    //    bandchlid1.AppearanceHeader.ForeColor = Color.LightSeaGreen;
                    //}
                }
                foreach (GridBand gb in gridView.Bands)
                {
                    FormatBand(gb);
                }
                gridControl.EndUpdate();
                return true;
            }
            catch (Exception EX) { return false; }
        }

        DataTable GetDataTable(GridView view)
        {
            DataTable dt = new DataTable();
            foreach (GridColumn c in view.Columns)
                dt.Columns.Add(c.FieldName, c.ColumnType);
            for (int r = 0; r < view.RowCount; r++)
            {
                object[] rowValues = new object[dt.Columns.Count];
                for (int c = 0; c < dt.Columns.Count; c++)
                    rowValues[c] = view.GetRowCellValue(r, dt.Columns[c].ColumnName);
                dt.Rows.Add(rowValues);
            }
            return dt;
        }

        private bool bindingData_Detail(DataTable dtSource, DataTable dt, int startcolumn)
        {
            try
            {
                int[] rowtotal = new int[dtSource.Columns.Count];
                string distinct_row = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!distinct_row.Equals(dt.Rows[i]["DISTINCTROW"].ToString()))
                    {
                        dtSource.Rows.Add();
                    }
                    distinct_row = dt.Rows[i]["DISTINCTROW"].ToString();
                    for (int col = 0; col < startcolumn; col++)
                    {
                        if (col >= 9 && col <= 13)
                        {
                            if (col >= 12)
                                dtSource.Rows[dtSource.Rows.Count - 1][dt.Columns[col].ColumnName] = dt.Rows[i][dt.Columns[col].ColumnName].ToString() == "" ? null : double.Parse(dt.Rows[i][dt.Columns[col].ColumnName].ToString()).ToString("#,0.#") + "%";
                            else
                                dtSource.Rows[dtSource.Rows.Count - 1][dt.Columns[col].ColumnName] = dt.Rows[i][dt.Columns[col].ColumnName] == null ? null : double.Parse(dt.Rows[i][dt.Columns[col].ColumnName].ToString()).ToString("#,0.#");
                        }
                        else
                        {
                            dtSource.Rows[dtSource.Rows.Count - 1][dt.Columns[col].ColumnName] = dt.Rows[i][dt.Columns[col].ColumnName].ToString();
                        }

                    }

                    dtSource.Rows[dtSource.Rows.Count - 1][string.Concat(dt.Rows[i]["YMD"].ToString(), dt.Rows[i]["HH"].ToString())] = dt.Rows[i]["QTY"];
                    if (dt.Rows[i]["HH"].ToString().Contains("S"))
                    {
                        double act = 0, plan = 0, rplan = 0;
                        if (dt.Rows[i]["QTY"] != null)
                        {
                            if (dt.Rows[i]["QTY"].ToString() != "" && dt.Rows[i]["QTY"].ToString().IndexOf('/') > 0)
                            {
                                act = double.Parse(dt.Rows[i]["QTY"].ToString().Split('/')[0]);
                                plan = double.Parse(dt.Rows[i]["QTY"].ToString().Split('/')[1]);
                                rplan = double.Parse(dt.Rows[i]["RPLAN"].ToString());
                            }
                        }
                        dtSource.Rows[dtSource.Rows.Count - 1][string.Concat(dt.Rows[i]["YMD"].ToString(), dt.Rows[i]["HH"].ToString(), "RATE")] = rplan == 0 ? "0%" : Math.Round(act / rplan * 100, 1).ToString() + "%";
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void formatgrid()
        {
            try
            {
                gvwBase.BeginUpdate();
                for (int i = 0; i < gvwBase.Columns.Count; i++)
                {
                    gvwBase.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwBase.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    gvwBase.Columns[i].OptionsColumn.ReadOnly = true;
                    gvwBase.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwBase.Columns[i].OwnerBand.Width = 100;
                    gvwBase.Columns[i].AppearanceCell.Font = new Font("Calibri", 10, FontStyle.Regular);
                    gvwBase.Columns[i].OwnerBand.AppearanceHeader.Font = new Font("Calibri", 10, FontStyle.Regular);
                    if (i < _start_column)
                    {
                        if (i == 5)
                        {
                            gvwBase.Columns[i].OwnerBand.Width = 110;
                            gvwBase.Columns[i].Width = 110;
                        }
                        else if (i == 4)
                        {
                            gvwBase.Columns[i].OwnerBand.Width = 90;
                            gvwBase.Columns[i].Width = 90;
                        }
                        else
                        {
                            gvwBase.Columns[i].OwnerBand.Width = 55;
                            gvwBase.Columns[i].Width = 55;
                        }

                        if (i == 3 || i == 4)
                        {
                            gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                            gvwBase.Columns[i].OwnerBand.Width = 65;
                            gvwBase.Columns[i].Width = 65;
                        }
                        //if (i >= 8 && i <= 10)
                        //{
                        //    gvwBase.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                        //    gvwBase.Columns[i].DisplayFormat.FormatString = "#,0.#";
                        //}
                        if ((i >= 12 && i <= 13) || i == _start_column - 1)
                        {
                            gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            gvwBase.Columns[i].OwnerBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        }
                        else
                            gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


                    }
                    else
                    {
                        //gvwBase.Columns[i].OwnerBand.Width = 30;
                        gvwBase.Columns[i].Width = 55;
                        gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }
                }
                gvwBase.EndUpdate();
                gvwBase.FocusedColumn = gvwBase.Columns[gvwBase.Columns.Count - 1];
            }
            catch { }
        }

        private void loadData(string line)
        {
            try
            {
                DataTable dt_main = new DataTable();
                DataTable dtSource = new DataTable();
                DataTable dtf = new DataTable();
                //return;
                dt_main = SEL_DATA_TALLY_SHEET("Q", dtpYMDF.Value.ToString("yyyyMMdd"), dtpYMDT.Value.ToString("yyyyMMdd"), _SOPCD,"MODEL",_SMCF,_SMCT);
               
                grdBase.DataSource = null;

                if (dt_main != null && dt_main.Rows.Count > 1)
                {
                    if (CreateGrid(dt_main, grdBase, gvwBase))
                    {
                        dtSource = GetDataTable(gvwBase);
                        if (bindingData_Detail(dtSource, dt_main, _start_column))
                        {
                            dtf = dtSource.Copy();
                            dtf.Rows.RemoveAt(0);
                            grdBase.DataSource = dtf;
                            

                            lbl_Plan.Text = "A. Shift Plan: " + (dtSource.Rows[0]["T_PLAN"] == null ? "0" : double.Parse(dt_main.Rows[0]["T_PLAN"].ToString()).ToString("#,0.#"));
                            lbl_Rplan.Text = "A. R.Plan: " + (dtSource.Rows[0]["T_RPLAN"] == null ? "0" : double.Parse(dt_main.Rows[0]["T_RPLAN"].ToString()).ToString("#,0.#"));
                            lbl_Act.Text = "A. Actual: " + (dtSource.Rows[0]["T_ACT"] == null ? "0" : double.Parse(dt_main.Rows[0]["T_ACT"].ToString()).ToString("#,0.#"));
                            lbl_Rate.Text = "A. P.Rate: " + dtSource.Rows[0]["RATE"].ToString();// (dt_main.Rows[0]["RATE"] == null ? "0%" : double.Parse(dt_main.Rows[0]["RATE"].ToString()).ToString("#,0.#") + "%"); 
                            lblDRate.Text = "A. D.Rate: " + dtSource.Rows[0]["QR"].ToString();
                            strCOL = dt_main.Rows[0]["COL"].ToString();

                            for (int i = 0; i < dtSource.Columns.Count; i++)
                            {
                                if (i >= 8 && i <= 12)
                                    gvwBase.Columns[i].OwnerBand.Caption = dtSource.Rows[0][dtSource.Columns[i]] == null ? null : dtSource.Rows[0][dtSource.Columns[i]].ToString();
                                else
                                    gvwBase.Columns[i].OwnerBand.Caption = dtSource.Rows[0][dtSource.Columns[i]].ToString();
                                gvwBase.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(255, 250, 179);
                            }
                            formatgrid();
                        }
                    }
                    lbl_header.Text = "Phylon Tally Sheet - Line " + int.Parse(_SMCF) + "-" + int.Parse(_SMCT);
                }
            }
            catch { }
        }
        private void Frm_Mold_WS_Change_By_Shift_Load(object sender, EventArgs e)
        {
            GoFullscreen();
            //timer1.Enabled = true;
            panel1.Visible = false;


            

            btnMold.BackColor = colordActive;
            btnModel.BackColor = colorActive;
            DataTable dt = new DataTable();
            string date1="";
            string LINE_CD="";
            string shift="";


            //strLine_CD = "LO101";
            //if(LINE_C !="")
            //    strLine_CD = LINE_C;
            
            date1 = DateTime.Now.ToString("yyyyMMdd");


            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 14)
                shift = "1";
            else if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 22)
                shift = "2";
            else
            {
                shift = "3";
                date1 = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            }

            dtpYMDF.Value = DateTime.Now;
            dtpYMDT.Value = DateTime.Now;


            loadData(strLine_CD);


           // dt = SEL_DATA_OS_PRO();
            panel1.Visible = true;
        }
        private DataTable SEL_DATA_TALLY_SHEET(string QTYPE, string ymd1, string ymd2, string OP_CD, string MOLD, string MC_F, string MC_T)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(8);
            MyOraDB.Process_Name = "MES.PKG_SMT_B1.SP_PH_TALLY_SHEET_V3";
            //  for (int i = 0; i < intParm; i++)
            MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
            MyOraDB.Parameter_Type[7] = (int)OracleType.Cursor;


         
            MyOraDB.Parameter_Name[0] = "V_P_TYPE";
            MyOraDB.Parameter_Name[1] = "V_P_YMDF";
            MyOraDB.Parameter_Name[2] = "V_P_YMDT";
            MyOraDB.Parameter_Name[3] = "V_P_OP";
            MyOraDB.Parameter_Name[4] = "V_P_MOLD";
            MyOraDB.Parameter_Name[5] = "V_P_MC_F";
            MyOraDB.Parameter_Name[6] = "V_P_MC_T";
            MyOraDB.Parameter_Name[7] = "OUT_CURSOR";


            MyOraDB.Parameter_Values[0] = QTYPE;
            MyOraDB.Parameter_Values[1] = ymd1;
            MyOraDB.Parameter_Values[2] = ymd2;
            MyOraDB.Parameter_Values[3] = OP_CD;
            MyOraDB.Parameter_Values[4] = Model == true ? "MODEL" : "MOLD"; 
            MyOraDB.Parameter_Values[5] = MC_F;
            MyOraDB.Parameter_Values[6] = MC_T;
            MyOraDB.Parameter_Values[7] = "";

            MyOraDB.Add_Select_Parameter(true);
            retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;
            return retDS.Tables[MyOraDB.Process_Name];
        }
        private void IniGridComponent(DataTable dt)
        {
           
        }
        
        private string GetText(AxFPUSpreadADO.AxfpSpread spread, int col, int row)
        {
            try
            {
                object data = null;
                spread.GetText(col, row, ref data);
                return data.ToString();
            }
            catch (Exception ex)
            {
                return "";
                //log.Error(ex);
            }

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
                    loadData(strLine_CD);
                    cnt = 0;
                }
            }
            catch
            {
            }


        }


        private void Frm_Mold_WS_Change_By_Shift_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

            }
            catch { }
        }

        private void axfpsView_Advance(object sender, AxFPUSpreadADO._DSpreadEvents_AdvanceEvent e)
        {

        }

        private void axfpsView_ClickEvent(object sender, AxFPUSpreadADO._DSpreadEvents_ClickEvent e)
        {
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void gvwBase_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.CellValue == null) return;
                if (e.CellValue.ToString().Contains("RED"))
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (e.CellValue.ToString().Contains("GREEN"))
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.Yellow;
                }
                else if (e.CellValue.ToString().Contains("YELLOW"))
                {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (e.CellValue.ToString().Contains("GREY"))
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (e.CellValue.ToString().Contains("NONE"))
                {
                    e.Appearance.BackColor = Color.Transparent;
                    e.Appearance.ForeColor = Color.Black;
                }


                if (e.Column.FieldName.Contains("OSD"))
                {
                    if (e.CellValue.ToString().Contains("RED"))
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (e.CellValue.ToString().Contains("GREEN"))
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.Yellow;
                    }
                    else if (e.CellValue.ToString().Contains("YELLOW"))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else if (e.CellValue.ToString().Contains("GREY"))
                    {
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else if (e.CellValue.ToString().Contains("NONE"))
                    {
                        e.Appearance.BackColor = Color.Transparent;
                        e.Appearance.ForeColor = Color.Black;
                    }

                }

                //string tomau_row = gvwBase.GetRowCellDisplayText(e.RowHandle, "MA");

                //if (e.Column.FieldName.Contains("S1") || e.Column.FieldName.Contains("S2") || e.Column.FieldName.Contains("S3"))
                //{
                //    e.Appearance.BackColor = Color.FromArgb(182, 217, 252);
                //}
                if (e.Column.FieldName.Contains("S1") || e.Column.FieldName.Contains("S2") || e.Column.FieldName.Contains("S3"))
                {
                    //if (gvwBase.Columns[e.Column.FieldName].OwnerBand.Caption.ToUpper().Equals("TOTAL"))
                    e.Appearance.BackColor = Color.FromArgb(255, 250, 179);
                    //else
                    //    e.Appearance.BackColor = Color.FromArgb(182, 217, 252);
                }

                if (e.Column.FieldName.Contains("S1RATE") || e.Column.FieldName.Contains("S2RATE") || e.Column.FieldName.Contains("S3RATE"))
                {
                    e.Appearance.BackColor = Color.FromArgb(250, 235, 210);
                }

                if (gvwBase.GetRowCellValue(e.RowHandle, "STATION_CD").ToString().Contains("TOTAL") && e.Column.ColumnHandle >= 4)
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 250, 179);
                    if (e.Column.FieldName.Contains("OSD"))
                        e.Appearance.ForeColor = Color.FromArgb(255, 250, 179);
                    //e.Appearance.Font = new System.Drawing.Font("Calibri", 12f, FontStyle.Regular);
                }
            }
            catch 
            { }
        }

        private void btnMold_Click(object sender, EventArgs e)
        {
            if (Model)
            {
                btnModel.BackColor = colordActive;
                btnModel.ForeColor = Color.Silver;   
                btnMold.BackColor = colorActive;
                btnMold.ForeColor = Color.Black;
                             
                Model = false;
                bandModel.Visible = false;
                bandMold.Visible = true;
                loadData(strLine_CD);
            }
            

        }
        private void btnModel_Click(object sender, EventArgs e)
        {
            if (!Model)
            {                
                btnMold.BackColor = colordActive;
                btnMold.ForeColor = Color.Silver;
                btnModel.BackColor = colorActive;
                btnModel.ForeColor = Color.Black;
                Model = true;
                bandMold.Visible = false;
                bandModel.Visible = true;
                loadData(strLine_CD);
            }

        }

        private void gvwBase_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                Rectangle rect = e.Bounds;
                rect.Inflate(new Size(1, 1));

                Brush brush = new SolidBrush(e.Appearance.BackColor);
                e.Graphics.FillRectangle(brush, rect);
                Pen pen_horizental = new Pen(Color.Blue, 3F);
                Pen pen_vertical = new Pen(Color.Blue, 4F);

                if (e.Column.ColumnHandle >= _start_column)
                {
                    if (e.Column.FieldName == strCOL)
                    {
                        // draw bottom
                        //e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y + rect.Height - 1, rect.X + rect.Width, rect.Y + rect.Height - 1);
                        //// draw top
                        //e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);

                        if (e.RowHandle == 0)
                        {
                            //e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                        }
                        else if (e.RowHandle == gvwBase.RowCount - 1)
                        {
                            e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y + rect.Height - 2, rect.X + rect.Width, rect.Y + rect.Height - 2);
                        }
                        // draw right
                        e.Graphics.DrawLine(pen_vertical, rect.X + rect.Width - 1, rect.Y, rect.X + rect.Width - 1, rect.Y + rect.Height);


                        // draw left
                        e.Graphics.DrawLine(pen_horizental, rect.X + 1, rect.Y, rect.X + 1, rect.Y + rect.Height);

                        string[] ls = e.DisplayText.Split('\n');
                        e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 10, FontStyle.Regular), new SolidBrush(e.Appearance.GetForeColor()), rect, e.Appearance.GetStringFormat());
                        e.Handled = true;
                    }

                }
            }
            catch 
            {
            }
        }

        private void btnModel_MouseClick(object sender, MouseEventArgs e)
        {
            //if(e.Clicks >1)
            //    loadData(strLine_CD);
        }

        private void gvwBase_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.AppearanceHeader.BackColor != Color.Empty)
            {
                //e.Appearance.BackColor = Color.Red;
                e.Info.AllowColoring = true;
                //e.Appearance.BackColor = Color.Red;
            }
            if (e.Column.AppearanceHeader.ForeColor != Color.Empty)
            {
                //e.Appearance.BackColor = Color.Red;
                e.Info.AllowColoring = true;
                //e.Appearance.BackColor = Color.Red;
            }
        }

        private void gvwBase_CustomDrawBandHeader(object sender, DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs e)
        {
            try
            {
                if (e.Band == null)
                    return;
                Rectangle rect = e.Bounds;
                rect.Inflate(new Size(1, 1));

                Brush brush = new SolidBrush(e.Appearance.BackColor);
                e.Graphics.FillRectangle(brush, rect);
                Pen pen_horizental = new Pen(Color.Blue, 3F);
                Pen pen_vertical = new Pen(Color.Blue, 4F);
                Pen line = new Pen(Color.White, 2F);
                bool boBorder = false;
                string[] ls = e.Band.Caption.Split('\n');

                if (e.Band.HasChildren)
                {
                    if (e.Band.Children[0].Columns.Count > 0)
                        if (e.Band.Children[0].Columns[0].Name.ToUpper().Replace("COL", "") == strCOL)
                        {
                            boBorder = true;
                        }
                }
                else
                {
                    if (e.Band.Columns.Count > 0)
                        if (e.Band.Columns[0].Name.ToUpper().Replace("COL", "") == strCOL)
                        {
                            boBorder = true;
                        }
                }

                if (boBorder)
                {
                    if (e.Band.HasChildren)
                        e.Graphics.DrawLine(pen_horizental, rect.X + 1, rect.Y, rect.X + rect.Width - 2, rect.Y);
                    else
                    {
                        //e.Graphics.DrawLine(line, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                    }
                    // draw right
                    e.Graphics.DrawLine(pen_vertical, rect.X + rect.Width - 3, rect.Y, rect.X + rect.Width - 3, rect.Y + rect.Height);


                    // draw left
                    e.Graphics.DrawLine(pen_horizental, rect.X + 2, rect.Y, rect.X + 2, rect.Y + rect.Height);

                    e.Graphics.DrawString(ls[0], new System.Drawing.Font("Calibri", 11, FontStyle.Regular), new SolidBrush(e.Appearance.GetForeColor()), rect, e.Appearance.GetStringFormat());
                    //e.Graphics.DrawString(ls[0], new System.Drawing.Font("Tahoma", 10.5F, FontStyle.Regular), new SolidBrush(e.Appearance.GetForeColor()), rect, e.Appearance.GetStringFormat());
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadData(strLine_CD);
        }

        private void dtpYMDF_ValueChanged(object sender, EventArgs e)
        {
            loadData(strLine_CD);
        }

        private void dtpYMDT_ValueChanged(object sender, EventArgs e)
        {
            loadData(strLine_CD);
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
            if (!Model)
            {
                pn1.GradientEndColor = Color.White;
                pn2.GradientEndColor = Color.Gray;
                pn2.Enabled = true;
                pn1.Enabled = false;
                Model = true;
                bandModel.Visible = true;
                bandMold.Visible = false;
                loadData(strLine_CD);
            }            
        }

        private void lbl2_Click(object sender, EventArgs e)
        {            
            if (Model)
            {
                pn2.GradientEndColor = Color.White;
                pn1.GradientEndColor = Color.Gray;
                pn2.Enabled = false;
                pn1.Enabled = true;
                Model = false;
                bandModel.Visible = false;
                bandMold.Visible = true;
                loadData(strLine_CD);
            }    
        }
       
    }
}
