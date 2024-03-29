﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OracleClient;
//using MaterialSetRate;
using System.Data.SqlClient;
//using ChartDirector;
using System.Threading;
using System.Diagnostics;
//using WarehouseMaterialSystem.ClassLib;


namespace Smart_FTY
{



    public partial class FORM_SMT_B_MOLD_ACTUAL_PLAN : Form_Parent
    {
        public FORM_SMT_B_MOLD_ACTUAL_PLAN()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }


        #region Init
        DataTable _dt_layout = null;
        string _status;
        public int _Izone = 1;
        // string _lbl1, _lbl2, _lbl3;
        public int _time = 0;
        int _time_auto = 0;
        DataTable _dt_row = null;
        DataTable _dt_layout_PH1 = null;
        DataTable _dt_layout_PH2 = null;
        DataTable _dt_layout_PH3 = null;
        DataTable _dtData = null;
        int iQtyDiff = 0;

        bool _loadDif = false;

        //  string[] str_yellow;
        int _iColor = 0;
        //bool _load_form = true;
        int _iCount = 0;
        //int _bf_clickRow=0, _bf_clickCol=0;
        string _shift;


        //FORM_MOLD_PRODUCTION_POP _pop_change = new FORM_MOLD_PRODUCTION_POP();
        //FORM_MOLD_PRODUCTION_POP_PRE _pop_change_pre = new FORM_MOLD_PRODUCTION_POP_PRE();
        //  Thread th;

        List<string> _Loc_change_DMC = new List<string>();
        List<string> _Loc_plan_DMC = new List<string>();
        List<string> _Loc_change_DMP = new List<string>();
        List<string> _Loc_plan_DMP = new List<string>();

        ArrayList a = new ArrayList();

        #endregion Init

        #region Function



        private void GoFullscreen()
        {

            //if (fullscreen)
            //{
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //}
        }
        //private void SetRow()
        //{
        //    if (arg_dt.Rows[i]["ZONE_CD"].ToString()) ;
        //}

        private void create_default()
        {
            try
            {
                int iRowHeight, iFontSize;
                double iColWidth;

                if (_status == "PH2")
                {
                    iColWidth = 3.5;
                }
                else
                {
                    iColWidth = 3.5;
                }

                //if (_status == "PH1")
                //{
                iRowHeight = 20;

                iFontSize = 11;
                //}
                //else
                //{
                //    iRowHeight = 32;
                //    iColWidth = 9.8;
                //    iFontSize = 15;
                //}
                axGrid.MaxRows = 1;
                axGrid.MaxRows = 200;

                axGrid.Reset();
                axGrid.DisplayColHeaders = false;
                axGrid.DisplayRowHeaders = false;
                axGrid.ActiveCellHighlightStyle = FPSpreadADO.ActiveCellHighlightStyleConstants.ActiveCellHighlightStyleOff;
                axGrid.ColHeaderRows = 0;
                axGrid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsVertical;
                axGrid.Font = new System.Drawing.Font("Calibri", iFontSize);
                axGrid.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleNone;
                axGrid.GrayAreaBackColor = Color.White;
                // axGrid.ScrollBarExtMode = true;
                // axGrid.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleNone;
                axGrid.set_RowHeight(1, 0.5);
                //axGrid.set_RowHeight(20, 9);
                //axGrid.set_ColWidth((int)WarehouseMaterialSystem.Cost.Form_Cost_Material_Unit_Price.G.S1_Blank, 5.37);
                axGrid.set_ColWidth(1, 0.5);
                //axGrid.set_ColWidth((int)G.S3_Blank, 5.37);
                //axGrid.set_ColWidth((int)G.Blank1, 13.62);
                //axGrid.set_ColWidth((int)G.Blank2, 13.62);
                axGrid.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                axGrid.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                axGrid.SetCellBorder(1, 1, 150, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                axGrid.SetCellBorder(1, 1, 150, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                // axGrid.SetCellBorder((int)G.S1_M1_L_Plan, 1, (int)G.S3_M2_R_Act, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);


                //  axGrid.SetCellBorder((int)G.S1_M1_L_Tar, 1, (int)G.S3_M2_R_Cur, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexOutline, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                
                for (int irow = 2; irow <= 70; irow++)
                    axGrid.set_RowHeight(irow, iRowHeight);

                for (int icol = 2; icol <= 150; icol++)
                    axGrid.set_ColWidth(icol, iColWidth);
            }
            catch (Exception)
            { }
        }

        #region CMP

        private void DisplayGrid(DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {

            create_default();
            _Loc_plan_DMP.Clear();
            axGrid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsNone;



            try
            {
                if (arg_dt == null || arg_dt.Rows.Count == 0) return;


                iQtyDiff = 0;
                int row_s = 3;
                int irow = row_s;
                int icol = 3;
                arg_grid.MaxRows = row_s + 25;
                MachineHead(icol, irow, 0, arg_dt, arg_grid);
                irow = row_s + 2;
                MachineBody(icol, irow, 0, arg_dt, arg_grid);
                for (int i = 1; i < arg_dt.Rows.Count; i++)
                {
                    if (arg_dt.Rows[i]["LINE_ID"].ToString() == arg_dt.Rows[i - 1]["LINE_ID"].ToString())
                    {
                        if (arg_dt.Rows[i]["MINI_LINE_ID"].ToString() == arg_dt.Rows[i - 1]["MINI_LINE_ID"].ToString())
                        {
                            irow++;
                        }
                        else
                        {
                            irow = row_s + 2;
                            icol += 3;
                        }
                        MachineBody(icol, irow, i, arg_dt, arg_grid);
                    }
                    else
                    {
                        arg_grid.set_ColWidth(icol + 3, 3.7);
                        icol += 4;
                        irow = row_s;
                        MachineHead(icol, irow, i, arg_dt, arg_grid);
                        irow = row_s + 2;
                        MachineBody(icol, irow, i, arg_dt, arg_grid);
                    }
                }
                arg_grid.MaxCols = icol + 3;
            }
            catch
            { }
            finally
            {
                // WarehouseMaterialSystem.ClassLib.WinAPI.AnimateWindow(arg_grid.Handle, 200, WarehouseMaterialSystem.ClassLib.WinAPI.getSlidType("2"));
                //   arg_grid.Visible = true;
            }
            set_qty_actual(arg_dt);
        }

        public DataTable SEL_TOTAL_PLAN_ACTUAL()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;


            string process_name = "PKG_SPB_MOLD_WMS_V2.SEL_QTY_ACTUAL";

            MyOraDB.ReDim_Parameter(2);
            MyOraDB.Process_Name = process_name;


            MyOraDB.Parameter_Name[0] = "ARG_WH_CD";
            MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = "40";
            MyOraDB.Parameter_Values[1] = "";

            MyOraDB.Add_Select_Parameter(true);

            ds_ret = MyOraDB.Exe_Select_Procedure();

            if (ds_ret == null) return null;
            return ds_ret.Tables[process_name];

        }

        private void MachineHead(int arg_icol, int arg_irow, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                int iRow = Convert.ToInt32(arg_dt.Rows[arg_idt]["NUM_MINI_LINE"]);
                arg_grid.Col = arg_icol;
                arg_grid.Row = arg_irow;
                arg_grid.Text = "Line " + arg_dt.Rows[arg_idt]["LINE_NAME"].ToString();
                arg_grid.FontSize = 20;
                arg_grid.FontBold = true;
                arg_grid.set_RowHeight(arg_irow, 30);


                arg_grid.BackColor = Color.DodgerBlue;
                arg_grid.ForeColor = Color.White;
                arg_grid.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                arg_grid.AddCellSpan(arg_icol, arg_irow, iRow * 3, 1);

                //arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexOutline, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                // arg_grid.SetCellBorder(icol, irow, icol + 3, irow + 1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow +1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);


                arg_irow++;
                arg_grid.Row = arg_irow;
                for (int i = 0; i < iRow; i++)
                {
                    if (arg_dt.Rows[arg_idt]["LINE_NAME"].ToString() == "E")
                        arg_grid.set_ColWidth(arg_icol + (i * 3), 6.0);

                    arg_grid.Col = arg_icol + (i * 3);
                    arg_grid.Text = "M/C";
                    arg_grid.BackColor = Color.LightSkyBlue;
                    //  arg_grid.ForeColor = Color.White;
                    arg_grid.FontSize = 18;
                    arg_grid.FontBold = true;

                    arg_grid.Col = arg_icol + (i * 3) + 1;
                    arg_grid.Text = "Plan";
                    arg_grid.BackColor = Color.Green;
                    arg_grid.ForeColor = Color.White;
                    arg_grid.FontSize = 18;
                    arg_grid.FontBold = true;

                    arg_grid.Col = arg_icol + (i * 3) + 2;
                    arg_grid.Text = "Act";
                    arg_grid.BackColor = Color.Orange;
                    arg_grid.ForeColor = Color.White;
                    arg_grid.FontSize = 18;
                    arg_grid.FontBold = true;
                }
                arg_grid.Col = -1;
                arg_grid.set_RowHeight(arg_irow, 30);

                //arg_grid.Col = arg_icol + 2;
                //arg_grid.Text = "R";
                //arg_grid.BackColor = Color.LightSkyBlue;
                ////  arg_grid.ForeColor = Color.White;
                //arg_grid.Font = new System.Drawing.Font("Calibri", 15, FontStyle.Bold);


            }
            catch
            { }

        }

        public void MachineBody(int arg_icol, int arg_irow, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                arg_grid.SetCellBorder(arg_icol + 1, arg_irow, arg_icol + 2, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol + 3, arg_irow, arg_icol + 3, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol + 1, arg_irow, arg_icol + 2, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                arg_grid.set_RowHeight(arg_irow, 25);
                arg_grid.set_ColWidth(arg_icol, 13);
                arg_grid.set_ColWidth(arg_icol + 1, 6);
                arg_grid.set_ColWidth(arg_icol + 2, 6);

                arg_grid.Col = arg_icol;
                arg_grid.Row = arg_irow;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MACHINE_NAME"].ToString();
                arg_grid.FontSize = 13;
                arg_grid.FontBold = true;
                arg_grid.BackColor = Color.LightGreen;

                ///Plan
                arg_grid.Col = arg_icol + 1;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MOLD_SIZE_CD"].ToString();
                arg_grid.FontSize = 15;
                if (arg_dt.Rows[arg_idt]["STATUS"].ToString() == "1")
                {
                    arg_grid.BackColor = Color.Yellow;
                    iQtyDiff++;
                }
                else
                {
                    arg_grid.BackColor = Color.White;
                }

                ///Act
                arg_grid.Col = arg_icol + 2;
                arg_grid.Text = arg_dt.Rows[arg_idt]["ACTUAL"].ToString();
                arg_grid.FontSize = 13;
                if (arg_dt.Rows[arg_idt]["STATUS"].ToString() == "1")
                {
                    arg_grid.BackColor = Color.Yellow;
                }
                else
                {
                    arg_grid.BackColor = Color.White;
                }


            }
            catch (Exception)
            { }

        }

        public void set_qty_actual(DataTable arg_dt)
        {

            int iPlan = (int)arg_dt.Compute("count(MOLD_SIZE_CD)", "");
            int iActual = (int)arg_dt.Compute("count(ACTUAL)", "");
            int iYellow = (int)arg_dt.Compute("count(STATUS)", "STATUS = '1'");
            

            lbl_Plan.Text = "Total Plan: " + iPlan;
            lbl_Actual.Text = "Total Actual: " + iActual;
          //  lblDiffPlan.Text = "Difference Plan: " + Math.Round(iQtyDiff / Convert.ToDouble(arg_dt.Rows[0]["PLAN"]) * 100,1).ToString() + "%";

            if (_shift == "1")
            {
                lbl_dif1.Text = (iYellow / (double)iPlan * 100).ToString("###,##0.#") + "%";
            }
            else if (_shift == "2")
            {
                lbl_dif2.Text = (iYellow / (double)iPlan * 100).ToString("###,##0.#") + "%";
            }
            else
            {
                lbl_dif3.Text = (iYellow / (double)iPlan * 100).ToString("###,##0.#") + "%";
            }

            if (!_loadDif) return;


            if (_shift == "1")
            {
                DataTable dtShif2 = SEL_APS_PLAN_ACTUAL("40", "2");
                SetTextDif(dtShif2, lbl_dif2);

                DataTable dtShif3 = SEL_APS_PLAN_ACTUAL("40", "3");
                SetTextDif(dtShif3, lbl_dif3);
            }
            else if (_shift == "2")
            {
                DataTable dtShif1 = SEL_APS_PLAN_ACTUAL("40", "1");
                SetTextDif(dtShif1, lbl_dif1);

                DataTable dtShif3 = SEL_APS_PLAN_ACTUAL("40", "3");
                SetTextDif(dtShif3, lbl_dif3);
            }
            else
            {
                DataTable dtShif2 = SEL_APS_PLAN_ACTUAL("40", "2");
                SetTextDif(dtShif2, lbl_dif2);

                DataTable dtShif1 = SEL_APS_PLAN_ACTUAL("40", "3");
                SetTextDif(dtShif1, lbl_dif1);
            }
        }

        private void SetTextDif(DataTable dtShift, Label lbl_dif)
        {
            try
            {
                if (dtShift == null || dtShift.Rows.Count == 0)
                {
                    lbl_dif.Text = "";
                    return;
                }
                int iPlan = (int)dtShift.Compute("count(MOLD_SIZE_CD)", "");
                if (iPlan ==0)
                {
                    lbl_dif.Text = "";
                    return;
                }
                int iYellow = (int)dtShift.Compute("count(STATUS)", "STATUS = '1'");
                
                lbl_dif.Text = ((double)iYellow / iPlan * 100.0).ToString("###,##0.#") + "%";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void MachineCenterText(int arg_col, int arg_row, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            int iColPlus = Convert.ToInt32(arg_dt.Rows[arg_idt]["col_cen"]);
            int iRowPlus = Convert.ToInt32(arg_dt.Rows[arg_idt]["row_cen"]);
            //arg_grid.AddCellSpan(arg_col + (iColPlus - 1), arg_row + (iRowPlus - 1), iColPlus, iRowPlus);
            arg_grid.AddCellSpan(arg_col + 1, arg_row - (iRowPlus - 1), iColPlus, iRowPlus);
            arg_grid.Col = arg_col + 1;
            arg_grid.Row = arg_row - (iRowPlus - 1);
            arg_grid.TypeEditMultiLine = true;
            arg_grid.FontBold = true;
            arg_grid.FontSize = 18f;
            arg_grid.BackColor = Color.FromArgb(242, 226, 213);

            if (arg_dt.Rows[arg_idt]["text_cen"] != null && arg_dt.Rows[arg_idt]["text_cen"].ToString() != "")
                arg_grid.SetText(arg_col + 1, arg_row - (iRowPlus - 1),
                                 arg_dt.Rows[arg_idt]["text_cen"].ToString().Replace("-", "\n"));


            //int c = Convert.ToInt32(arg_dt.Rows[arg_idt]["line"].ToString());

            //for (int i = 1; i <= c; i++)
            //{

            //    arg_grid.Row = arg_row;
            //    arg_grid.Col = arg_col + i;
            //    arg_grid.BackColor = Color.FromArgb(244, 140, 65);
            //}

            //arg_grid.SetCellBorder(arg_col + 1, arg_row, arg_col + c, arg_row
            //                          , FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0x418cf4
            //                          , FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
            //arg_grid.SetCellBorder(arg_col + 1, arg_row, arg_col + c, arg_row
            //                      , FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0x418cf4
            //                      , FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

        }

        //private void MachineCenterBG(int arg_col, int arg_row, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        //{
        //    int c = Convert.ToInt32(arg_dt.Rows[arg_idt]["line"].ToString());

        //    for (int i = 1; i <= c; i++)
        //    {

        //        arg_grid.Row = arg_row;
        //        arg_grid.Col = arg_col + i;
        //        arg_grid.BackColor = Color.FromArgb(242, 226, 213);
        //    }

        //    arg_grid.SetCellBorder(arg_col + 1, arg_row, arg_col + c, arg_row
        //                              , FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0xd5e2f2
        //                              , FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
        //    arg_grid.SetCellBorder(arg_col + 1, arg_row, arg_col + c, arg_row
        //                          , FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0xd5e2f2
        //                          , FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

        //}


        private void MachineHeadDMC(int arg_col, int arg_row, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                //axGrid.AddCellSpan(icol, irow
                //                    , Convert.ToInt32(_dt_layout.Rows[idt]["line"].ToString()) * 2
                //                    , 1);
                arg_grid.Col = arg_col;
                arg_grid.Row = arg_row;
                arg_grid.set_RowHeight(arg_row, 30);
                arg_grid.Text = arg_dt.Rows[arg_idt]["MACHINE_NAME"].ToString();
                arg_grid.Font = new System.Drawing.Font("Calibri", 20, FontStyle.Bold);
                arg_grid.BackColor = Color.DodgerBlue;
                arg_grid.ForeColor = Color.White;
                arg_grid.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;

                arg_grid.AddCellSpan(arg_col, arg_row
                                    , Convert.ToInt32(arg_dt.Rows[arg_idt]["line"].ToString())
                                    , 1);
            }
            catch
            {
            }
        }

        public void MachineBodyDMC(int arg_col, int arg_row, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {

                //  arg_grid.SetCellBorder(arg_col, arg_row, arg_col, arg_row, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //  arg_grid.SetCellBorder(arg_col + 1, arg_row, arg_col + 1, arg_row, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //  arg_grid.SetCellBorder(arg_col, arg_row, arg_col, arg_row, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //  arg_grid.SetCellBorder(arg_col, arg_row, arg_col, arg_row, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                arg_grid.Row = arg_row;
                arg_grid.Col = arg_col;
                arg_grid.Text = _dt_layout_PH1.Rows[arg_idt]["size_plan"].ToString();
                arg_grid.BackColor = Color.FromName(arg_dt.Rows[arg_idt]["color_B_value"].ToString());
                arg_grid.ForeColor = Color.FromName(arg_dt.Rows[arg_idt]["color_F_value"].ToString());
            }
            catch (Exception)
            { }

        }

      


        #endregion DMC


        #region PH1
        private void DisplayGridPH1(DataTable arg_dt, DataTable arg_dt2, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            // dt2 = SEL_APS_PLAN_ACTUAL_ROW("70_1");


            try
            {
                if (arg_dt == null || arg_dt.Rows.Count == 0) return;
                // axGrid.ClearRange(0, 0, 50, 50, true);

                create_default();
                _Loc_plan_DMP.Clear();
                //_row1 = Convert.ToInt32(arg_dt.Rows[0]["Row1"]);
                //_row2 = Convert.ToInt32(arg_dt.Rows[0]["Row2"]);
                //_row3 = Convert.ToInt32(arg_dt.Rows[0]["Row3"]);
                int row_s = 3, col_s = 2, row_max = 2;
                int irow = row_s;
                int icol = col_s;
                int iColMax = icol;
                int irow1 = 3 + Convert.ToInt32(arg_dt2.Rows[0]["MOLD_CD"].ToString());
                int irow2 = 3 + irow1 + Convert.ToInt32(arg_dt2.Rows[1]["MOLD_CD"].ToString()) + 1;
                int irow3 = 3 + Convert.ToInt32(arg_dt2.Rows[2]["MOLD_CD"].ToString());
                int irow4 = 3 + Convert.ToInt32(arg_dt2.Rows[3]["MOLD_CD"].ToString());
                int irow5 = 3 + irow4 + Convert.ToInt32(arg_dt2.Rows[4]["MOLD_CD"].ToString());
                int irow6 = 3 + irow5 + Convert.ToInt32(arg_dt2.Rows[5]["MOLD_CD"].ToString());

                
                if (_status == "PH3")
                    arg_grid.MaxRows = irow6 + 3;
                else if (_status == "PH1")
                    arg_grid.MaxRows = irow2 + 3;
                else
                    arg_grid.MaxRows = irow5 + 3;
                MachineHeadPH1(icol, irow, 0, arg_dt, arg_grid);
                irow += 2;
                MachineBodyPH1(icol, irow, irow1, 0, arg_dt, arg_grid);
                irow++;
                string zone = "";
                for (int i = 1; i < arg_dt.Rows.Count; i++)
                {
                    //iCount++;
                    //if (i==3) break;
                    zone = arg_dt.Rows[i]["ZONE_CD"].ToString();
                    if (arg_dt.Rows[i]["ZONE_CD"].ToString() == arg_dt.Rows[i - 1]["ZONE_CD"].ToString())
                    {
                        if (arg_dt.Rows[i]["ZONE_CD"].ToString() == "001")
                        {
                            if (arg_dt.Rows[i]["MACHINE_NAME"].ToString() == arg_dt.Rows[i - 1]["MACHINE_NAME"].ToString())
                            {
                                MachineBodyPH1(icol, irow, irow1, i, arg_dt, arg_grid);
                                //if (irow > row_max) row_max = irow;
                                irow++;
                            }
                            else
                            {
                                row_max = irow1;
                                ///Line Total
                                MachineLineTotal2(icol, irow1, irow, arg_grid);
                                ///new machine
                                arg_grid.set_ColWidth(icol + 5, 1.0);
                                //col_s += 5;
                                icol += 6;
                                irow = row_s;
                                MachineHeadPH1(icol, irow, i, arg_dt, arg_grid);
                                irow += 2;
                                MachineBodyPH1(icol, irow, irow1, i, arg_dt, arg_grid);
                                irow++;

                            }
                        }
                        else if (arg_dt.Rows[i]["ZONE_CD"].ToString() == "002")
                        {
                            if (arg_dt.Rows[i]["MACHINE_NAME"].ToString() == arg_dt.Rows[i - 1]["MACHINE_NAME"].ToString())
                            {
                                MachineBodyPH1(icol, irow, irow2, i, arg_dt, arg_grid);
                                //  if (irow > row_max) row_max = irow;
                                irow++;
                            }
                            else
                            {
                                row_max = irow2;
                                ///Line Total
                                MachineLineTotal2(icol, irow2, irow, arg_grid);
                                ///new machine
                                arg_grid.set_ColWidth(icol + 5, 1.0);
                                //col_s += 5;
                                icol += 6;
                                irow = row_s;
                                MachineHeadPH1(icol, irow, i, arg_dt, arg_grid);
                                irow += 2;
                                MachineBodyPH1(icol, irow, irow2, i, arg_dt, arg_grid);
                                irow++;

                            }
                        }
                        else if (arg_dt.Rows[i]["ZONE_CD"].ToString() == "003")
                        {
                            //if (i > 81) return;
                            
                            if (arg_dt.Rows[i]["MACHINE_NAME"].ToString() == arg_dt.Rows[i - 1]["MACHINE_NAME"].ToString())
                            {
                                if (arg_dt.Rows[i]["MACHINE_NAME"].ToString() == "CTM 26" && arg_dt.Rows[i]["MOLD_CD"].ToString() == "TOTAL")
                                {}

                                MachineBodyPH1(icol, irow, irow3, i, arg_dt, arg_grid);
                                // if (irow > row_max) row_max = irow;
                                irow++;
                                //if (arg_dt.Rows[i]["MOLD_CD"].ToString() == "TOTAL")
                                //{
                                //    MachineLineTotal2(icol, irow3, irow, arg_grid);
                                //    //  return;
                                //}

                            }
                            else
                            {
                                row_max = irow3;
                                ///Line Total
                                MachineLineTotal2(icol, irow3, irow, arg_grid);
                                ///new machine
                                arg_grid.set_ColWidth(icol + 5, 1.0);
                                //col_s += 5;
                                icol += 6;
                                irow = row_s;
                                MachineHeadPH1(icol, irow, i, arg_dt, arg_grid);
                                irow += 2;
                                MachineBodyPH1(icol, irow, irow3, i, arg_dt, arg_grid);
                                irow++;

                            }
                        }
                        else if (arg_dt.Rows[i]["ZONE_CD"].ToString() == "004")
                        {
                            if (arg_dt.Rows[i]["MACHINE_NAME"].ToString() == arg_dt.Rows[i - 1]["MACHINE_NAME"].ToString())
                            {
                                MachineBodyPH1(icol, irow, irow4, i, arg_dt, arg_grid);
                                // if (irow > row_max) row_max = irow;
                                irow++;
                            }
                            else
                            {
                                row_max = irow4;
                                ///Line Total
                                MachineLineTotal2(icol, irow4, irow, arg_grid);
                                ///new machine
                                arg_grid.set_ColWidth(icol + 5, 1.0);
                                //col_s += 5;
                                icol += 6;
                                irow = row_s;
                                MachineHeadPH1(icol, irow, i, arg_dt, arg_grid);
                                irow += 2;
                                MachineBodyPH1(icol, irow, irow4, i, arg_dt, arg_grid);
                                irow++;

                            }
                        }
                        else if (arg_dt.Rows[i]["ZONE_CD"].ToString() == "005")
                        {
                            if (arg_dt.Rows[i]["MACHINE_NAME"].ToString() == arg_dt.Rows[i - 1]["MACHINE_NAME"].ToString())
                            {
                                
                                MachineBodyPH1(icol, irow, irow5, i, arg_dt, arg_grid);
                                // if (irow > row_max) row_max = irow;
                                irow++;
                                //if (arg_dt.Rows[i]["MOLD_CD"].ToString() == "TOTAL")
                                //{
                                //    MachineLineTotal2(icol, irow5, irow, arg_grid);
                                //    //  return;
                                //}
                            }
                            else
                            {
                                row_max = irow5;
                                ///Line Total
                                MachineLineTotal2(icol, irow5, irow, arg_grid);
                                ///new machine
                                arg_grid.set_ColWidth(icol + 5, 1.0);
                                //col_s += 5;
                                icol += 6;
                                irow = row_s;
                                MachineHeadPH1(icol, irow, i, arg_dt, arg_grid);
                                irow += 2;
                                MachineBodyPH1(icol, irow, irow5, i, arg_dt, arg_grid);
                                irow++;

                            }
                        }
                        else if (arg_dt.Rows[i]["ZONE_CD"].ToString() == "006")
                        {
                            if (arg_dt.Rows[i]["MACHINE_NAME"].ToString() == arg_dt.Rows[i - 1]["MACHINE_NAME"].ToString())
                            {

                                MachineBodyPH1(icol, irow, irow6, i, arg_dt, arg_grid);
                                // if (irow > row_max) row_max = irow;
                                irow++;
                                //if (arg_dt.Rows[i]["MOLD_CD"].ToString() == "TOTAL")
                                //{
                                //    MachineLineTotal2(icol, irow6, irow, arg_grid);
                                //      return;
                                //}
                            }
                            else
                            {
                                row_max = irow6;
                                ///Line Total
                                MachineLineTotal2(icol, irow6, irow, arg_grid);
                                ///new machine
                                arg_grid.set_ColWidth(icol + 5, 1.0);
                                //col_s += 5;
                                icol += 6;
                                irow = row_s;
                                MachineHeadPH1(icol, irow, i, arg_dt, arg_grid);
                                irow += 2;
                                MachineBodyPH1(icol, irow, irow6, i, arg_dt, arg_grid);
                                irow++;

                            }
                        }
                    }
                    else
                    {
                        ///Line Total
                        if (arg_dt.Rows[0]["ZONE_CD"].ToString() == "001")
                        {
                            MachineLineTotal2(icol, irow1, irow, arg_grid);
                        }
                        if (arg_dt.Rows[0]["ZONE_CD"].ToString() == "004")
                        {
                            MachineLineTotal2(icol, irow4, irow, arg_grid);
                        }
                        if (arg_dt.Rows[0]["ZONE_CD"].ToString() == "003")
                        {
                            MachineLineTotal2(icol, irow3, irow, arg_grid);
                        }
                        if (zone == "006")
                        {
                            MachineLineTotal2(icol, irow5, irow, arg_grid);
                        }
                        //if (arg_dt.Rows[0]["ZONE_CD"].ToString() == "006")
                        //{
                        //    MachineLineTotal2(icol, irow6, irow, arg_grid);
                        //}

                        row_s = row_max + 2;
                        icol = col_s;
                        irow = row_s;
                        MachineHeadPH1(icol, irow, i, arg_dt, arg_grid);
                        irow += 2;
                        MachineBodyPH1(icol, irow, irow2, i, arg_dt, arg_grid);
                        irow++;

                    }

                    if (icol > iColMax) iColMax = icol;
                }
                ///Line Total
                if (zone == "002")
                {
                    MachineLineTotal2(icol, irow2, irow, arg_grid);
                }
                //if (arg_dt.Rows[0]["ZONE_CD"].ToString() == "003")
                //{
                //    MachineLineTotal2(icol, irow3, irow, arg_grid);
                //}
                //if (arg_dt.Rows[0]["ZONE_CD"].ToString() == "004")
                //{
                //    MachineLineTotal2(icol, irow5, irow, arg_grid);
                //}
                if (zone == "005")
                {
                    MachineLineTotal2(icol, irow5, irow, arg_grid);
                }
                if (zone == "006")
                {
                    MachineLineTotal2(icol, irow6, irow, arg_grid);
                }

                SetTextPH(arg_dt);

                if (_status == "PH3")
                {
                    arg_grid.MaxCols = iColMax + 5;
                    arg_grid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsBoth;
                }
                else
                {
                    arg_grid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsVertical;
                }
                // if (_Loc_yellow.Count > 0) tmr_blind.Start();
                // else tmr_blind.Stop();
                //////////////////////////////////////////////

            }
            catch (Exception ex)
            {
            }
        }


        private void SetTextPH(DataTable arg_dt)
        {
            double iPlan, iDiff;
            double.TryParse(_dtData.Compute("Sum(QTY_TAR)", "MOLD_CD <> 'TOTAL'").ToString(), out iPlan);
            double.TryParse(_dtData.Compute("Sum(ABS)", "MOLD_CD <> 'TOTAL'").ToString(), out iDiff);

            lbl_Plan.Text = "Total Plan: " + Convert.ToInt32(arg_dt.Compute("Sum(QTY_TAR)", "MOLD_CD <> 'TOTAL'")).ToString("###,###");
            lbl_Actual.Text = "Total Actual: " + Convert.ToInt32(arg_dt.Compute("Sum(QTY_ACT)", "MOLD_CD <> 'TOTAL'")).ToString("###,###");

            if (_shift == "1")
            {
                lbl_dif1.Text = Math.Round(iDiff / iPlan * 100, 1) + "%";
            }
            else if (_shift == "2")
            {
                lbl_dif2.Text = Math.Round(iDiff / iPlan * 100, 1) + "%";
            }
            else
            {
                lbl_dif3.Text = Math.Round(iDiff / iPlan * 100, 1) + "%";
            }

            if (!_loadDif) return;


            if (_shift == "1")
            {
                DataTable dtShif2 = SEL_APS_PLAN_ACTUAL("70", "2");
                SetTextDifPH(dtShif2, lbl_dif2);

                DataTable dtShif3 = SEL_APS_PLAN_ACTUAL("70", "3");
                SetTextDifPH(dtShif3, lbl_dif3);
            }
            else if (_shift == "2")
            {
                DataTable dtShif1 = SEL_APS_PLAN_ACTUAL("70", "1");
                SetTextDifPH(dtShif1, lbl_dif1);

                DataTable dtShif3 = SEL_APS_PLAN_ACTUAL("70" + _status.Substring(2, 1), "3");
                SetTextDifPH(dtShif3, lbl_dif3);
            }
            else
            {
                DataTable dtShif2 = SEL_APS_PLAN_ACTUAL("70", "2");
                SetTextDifPH(dtShif2, lbl_dif2);

                DataTable dtShif1 = SEL_APS_PLAN_ACTUAL("70", "1");
                SetTextDifPH(dtShif1, lbl_dif1);
            } 
        }

        private void SetTextDifPH(DataTable dtShift, Label lbl_dif, string text = "")
        {
            try
            {
                if (dtShift == null || dtShift.Rows.Count == 0)
                {
                    lbl_dif.Text = "";
                    return;
                }
                double iPlan, iDiff;
                double.TryParse(dtShift.Compute("Sum(QTY_TAR)", "MOLD_CD <> 'TOTAL'").ToString(), out iPlan);
                double.TryParse(dtShift.Compute("Sum(ABS)", "MOLD_CD <> 'TOTAL'").ToString(), out iDiff);
                lbl_dif.Text = text + Math.Round(iDiff / iPlan * 100, 1) + "%";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void SetTextPlanActualQty(DataTable dtShift, Label lbl_dif)
        {
            try
            {
                if (dtShift == null || dtShift.Rows.Count == 0)
                {
                    lbl_dif.Text = "";
                    return;
                }
                double iPlan, iActual;
                double.TryParse(dtShift.Compute("Sum(QTY_TAR)", "MOLD_CD <> 'TOTAL'").ToString(), out iPlan);
                double.TryParse(dtShift.Compute("Sum(QTY_ACT)", "MOLD_CD <> 'TOTAL'").ToString(), out iActual);
                lbl_dif.Text = "Total Plan     : " + iPlan.ToString("#,#") + "\nTotal Actual : " + iActual.ToString("#,#");
                              
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void MachineHeadPH1(int arg_icol, int arg_irow, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                arg_grid.Col = arg_icol;
                arg_grid.Row = arg_irow;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MACHINE_NAME"].ToString();
                arg_grid.Font = new System.Drawing.Font("Calibri", 16, FontStyle.Bold);
                arg_grid.BackColor = Color.DodgerBlue;
                arg_grid.ForeColor = Color.White;
                arg_grid.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                arg_grid.AddCellSpan(arg_icol, arg_irow, 5, 1);

                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow + 1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexOutline, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(icol, irow, icol + 3, irow + 1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow +1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);


                arg_grid.Row = arg_irow + 1;
                arg_grid.Col = arg_icol;
                arg_grid.Text = "Mold Code";
                arg_grid.BackColor = Color.PeachPuff;
                //  arg_grid.ForeColor = Color.White;
                arg_grid.FontSize = 10;
                arg_grid.FontBold = true;
                arg_grid.set_ColWidth(arg_icol, 10.0);

                arg_grid.Col = arg_icol + 1;
                arg_grid.Text = "Size";
                arg_grid.BackColor = Color.LightSkyBlue;
                //  arg_grid.ForeColor = Color.White;
                arg_grid.FontSize = 10;
                arg_grid.FontBold = true;

                arg_grid.Col = arg_icol + 2;
                arg_grid.Text = "Plan";
                arg_grid.BackColor = Color.Green;
                arg_grid.ForeColor = Color.White;
                arg_grid.FontSize = 9;
                arg_grid.FontBold = true;

                arg_grid.Col = arg_icol + 3;
                arg_grid.Text = "Act";
                arg_grid.BackColor = Color.Orange;
                arg_grid.ForeColor = Color.White;
                arg_grid.FontSize = 10;
                arg_grid.FontBold = true;

                arg_grid.Col = arg_icol + 4;
                arg_grid.Text = "Bal";
                arg_grid.BackColor = Color.Gray;
                arg_grid.ForeColor = Color.White;
                arg_grid.FontSize = 10;
                arg_grid.FontBold = true;


            }
            catch
            { }
        }

        private void MachineBodyPH1(int arg_icol, int arg_irow, int arg_irow1, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                arg_grid.SetCellBorder(arg_icol + 3, arg_irow, arg_icol + 5, arg_irow1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol + 4, arg_irow1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol + 4, arg_irow1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                arg_grid.set_RowHeight(arg_irow, 20);


                arg_grid.Col = arg_icol;
                arg_grid.Row = arg_irow;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MOLD_CD"].ToString();
                arg_grid.BackColor = Color.FromName(arg_dt.Rows[arg_idt]["B_COLOR"].ToString());
                arg_grid.ForeColor = Color.FromName(arg_dt.Rows[arg_idt]["F_COLOR"].ToString());

                arg_grid.Col = arg_icol + 1;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MOLD_SIZE_CD"].ToString();
                arg_grid.BackColor = Color.FromName(arg_dt.Rows[arg_idt]["B_COLOR2"].ToString());
                arg_grid.ForeColor = Color.FromName(arg_dt.Rows[arg_idt]["F_COLOR2"].ToString());

                arg_grid.Col = arg_icol + 2;
                arg_grid.Text = arg_dt.Rows[arg_idt]["QTY_TAR"].ToString();
                arg_grid.BackColor = Color.FromName(arg_dt.Rows[arg_idt]["B_COLOR3"].ToString());
                arg_grid.ForeColor = Color.FromName(arg_dt.Rows[arg_idt]["F_COLOR3"].ToString());

                arg_grid.Col = arg_icol + 3;
                arg_grid.Text = arg_dt.Rows[arg_idt]["QTY_ACT"].ToString();
                arg_grid.BackColor = Color.FromName(arg_dt.Rows[arg_idt]["B_COLOR4"].ToString());
                arg_grid.ForeColor = Color.FromName(arg_dt.Rows[arg_idt]["F_COLOR4"].ToString());

                arg_grid.Col = arg_icol + 4;
                arg_grid.Text = arg_dt.Rows[arg_idt]["BALANCE"].ToString();
                arg_grid.BackColor = Color.FromName(arg_dt.Rows[arg_idt]["B_COLOR5"].ToString());
                arg_grid.ForeColor = Color.FromName(arg_dt.Rows[arg_idt]["F_COLOR5"].ToString());

                //if (arg_dt.Rows[arg_idt]["L_Status"].ToString() == "1")
                //    _Loc_plan_DMP.Add((arg_icol + 1) + " " + arg_irow + " " + arg_dt.Rows[arg_idt]["machine_cd"].ToString());
                //if (arg_dt.Rows[arg_idt]["R_Status"].ToString() == "1")
                //    _Loc_plan_DMP.Add((arg_icol + 2) + " " + arg_irow + " " + arg_dt.Rows[arg_idt]["machine_cd"].ToString());

                //if (arg_dt.Rows[arg_idt]["L_Status"].ToString() == "2")
                //    _Loc_change_DMP.Add((arg_icol + 1) + " " + arg_irow + " " + arg_dt.Rows[arg_idt]["machine_cd"].ToString());
                //if (arg_dt.Rows[arg_idt]["R_Status"].ToString() == "2")
                //    _Loc_change_DMP.Add((arg_icol + 2) + " " + arg_irow + " " + arg_dt.Rows[arg_idt]["machine_cd"].ToString());

            }
            catch (Exception)
            { }

        }

        private void MachineLineTotal(int arg_icol, int arg_irow, AxFPSpreadADO.AxfpSpread arg_grid)
        {

            arg_grid.AddCellSpan(arg_icol, arg_irow, 2, 1);
            arg_grid.Row = arg_irow;
            for (int i = 0; i < 5; i++)
            {

                arg_grid.Col = arg_icol + i;
                arg_grid.BackColor = Color.PaleGreen;
                arg_grid.ForeColor = Color.Black;
                arg_grid.FontBold = true;
            }

        }

        private void MachineLineTotal2(int arg_icol, int arg_irow, int arg_irow2, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            arg_grid.AddCellSpan(arg_icol, arg_irow, 2, 1);
            arg_grid.Row = arg_irow;
            for (int i = 0; i < 5; i++)
            {

                arg_grid.Col = arg_icol + i;
                arg_grid.BackColor = Color.PaleGreen;
                arg_grid.ForeColor = Color.Black;
                arg_grid.FontBold = true;
            }
            for (int i = 0; i < 5; i++)
            {
                arg_grid.Col = arg_icol + i;
                arg_grid.Row = arg_irow2 - 1;
                arg_grid.SetText(arg_icol + i, arg_irow, arg_grid.Text);
                if (arg_irow == arg_irow2 - 1)
                {
                    return;
                }
                arg_grid.SetText(arg_icol + i, arg_irow2 - 1, "");
                arg_grid.Col = arg_icol + i;
                arg_grid.BackColor = Color.White;
                arg_grid.ForeColor = Color.Black;
                arg_grid.FontBold = true;



            }
            // blind();

        }


        #endregion PH1

        private void blind(List<string> arg_list)
        {
            try
            {
                if (arg_list.Count <= 0) return;
                string[] str;

                for (int i = _iColor; i < arg_list.Count; i += 3)
                {
                    str = arg_list[i].Split(' ');
                    axGrid.Col = Convert.ToInt32(str[0].ToString());
                    axGrid.Row = Convert.ToInt32(str[1].ToString());
                    if (axGrid.BackColor == Color.Yellow)
                    {
                        if (axGrid.Text == "")
                        {
                            axGrid.BackColor = Color.Gray;
                        }
                        else
                        {
                            axGrid.BackColor = Color.Green;
                        }

                        axGrid.ForeColor = Color.White;
                    }
                    else
                    {
                        axGrid.BackColor = Color.Yellow;
                        axGrid.ForeColor = Color.Black;
                    }
                }
                if (_iColor == 3) _iColor = 0;
                else _iColor++;
            }
            catch (Exception)
            { }
        }

        public void loaddata(bool arg_status)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                // if (arg_status)
                this.axGrid.Hide();
                DataTable dt = null;
                DataTable dt2 = null;
                // System.Da.DataSet ds = SEL_APS_PLAN_ACTUAL_ROW();
                //  DataTable _dt_row = ds.Tables[0];
               // dt2 = SEL_APS_PLAN_ACTUAL_ROW("70_1");
                if (_status != "CMP")
                {
                    _dtData = SEL_APS_PLAN_ACTUAL("70", _shift);
                    dt2 = GetDataRow(_dtData);
                    SetTextPlanActualQty(_dtData, lbl_Dif);
                    
                }
                    


                if (_status == "PH1")
                {
                    dt = _dtData.Select("PLANT_NAME = 'PLANT A'", "ZONE_CD, LINE_SEQ, ORD1, ORD2").CopyToDataTable();
                    
                   // dt = SEL_APS_PLAN_ACTUAL("70_1", _shift);
                    //_dt_row = SEL_APS_PLAN_ACTUAL_ROW("70_1");
                    if (dt != null && dt.Rows.Count > 0)
                        _dt_layout_PH1 = dt;
                    _dt_row = dt2;

                    this.axGrid.Hide();
                    DisplayGridPH1(_dt_layout_PH1, _dt_row, axGrid);
                }
                else if (_status == "PH2")
                {
                    //dt = SEL_APS_PLAN_ACTUAL("70_2",_shift);
                    dt = _dtData.Select("PLANT_NAME = 'PLANT B'", "ZONE_CD, LINE_SEQ, ORD1, ORD2").CopyToDataTable();
                    if (dt != null && dt.Rows.Count > 0)
                        _dt_layout_PH2 = dt;

                    DisplayGridPH1(_dt_layout_PH2, _dt_row, axGrid);
                }
                else if (_status == "PH3")
                {
                    //dt = SEL_APS_PLAN_ACTUAL("70_3", _shift);
                    dt = _dtData.Select("PLANT_NAME = 'PLANT C'", "ZONE_CD, LINE_SEQ, ORD1, ORD2").CopyToDataTable();
                    if (dt != null && dt.Rows.Count > 0)
                        _dt_layout_PH3 = dt;

                    DisplayGridPH1(_dt_layout_PH3, _dt_row, axGrid);
                }
                else if (_status == "CMP")
                {
                    dt = SEL_APS_PLAN_ACTUAL("40", _shift);
                    if (dt != null && dt.Rows.Count > 0)
                        _dt_layout = dt;

                    DisplayGrid(_dt_layout, axGrid);
                }
                //   DisplayGridPH1(_dt_row, axGrid);



                //autoClick();
                // if (arg_status)
                // {
                // WarehouseMaterialSystem.ClassLib.WinAPI.AnimateWindow(this.axGrid.Handle, 400, WarehouseMaterialSystem.ClassLib.WinAPI.getSlidType("2"));

                //}
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.axGrid.Show();
            }
        }

        private DataTable GetDataRow(DataTable argDt)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("ZONE_CD");
                dt.Columns.Add("MOLD_CD");
                Dictionary<string, int>[] dtnData = new Dictionary<string, int>[6];
                dtnData[0] = new Dictionary<string, int>();
                dtnData[1] = new Dictionary<string, int>();
                dtnData[2] = new Dictionary<string, int>();
                dtnData[3] = new Dictionary<string, int>();
                dtnData[4] = new Dictionary<string, int>();
                dtnData[5] = new Dictionary<string, int>();
                int zone = 0;

                foreach (DataRow row in argDt.Rows)
                {
                    string key = row["MACHINE_NAME"].ToString();
                    int.TryParse(row["ZONE_CD"].ToString(), out zone);

                    zone -= 1;
                    
                    if (dtnData[zone].ContainsKey(key))
                    {
                        dtnData[zone][key] += 1;
                    }
                    else
                    {
                        dtnData[zone][key] = 1;
                    }
                }
                for (int i= 0; i < 6;i ++)
                {
                    DataRow rowDt = dt.NewRow();
                    rowDt["ZONE_CD"] = (i+1).ToString("000");
                    rowDt["MOLD_CD"] = dtnData[i].Values.Max();
                    dt.Rows.Add(rowDt);
                }
              

                return dt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion Fuction

        #region DB
        public DataTable SEL_APS_PLAN_ACTUAL(string arg_wh, string argShift)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "PKG_SPB_MOLD_WMS_V2.SEL_MOLD_APS_ACTUAL_V2";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_SHIFT";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = arg_wh;
                MyOraDB.Parameter_Values[1] = dtpDate.DateTime.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[2] = argShift;
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

        public DataTable SEL_APS_PLAN_ACTUAL_ROW(string arg_wh)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "PKG_SPB_MOLD_WMS_V2.SEL_MOLD_WH_ACTUAL_V2";

                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;



                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";


                MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;


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

        #region Event

        bool _isLoad = true;
        public void Frm_Mold_WS_Change_By_Shift_Load(object sender, EventArgs e)
        {
            _isLoad = true;
            // GoFullscreen();
            //timer2.Start();
            //lblDmc_Click(lblDmc, null);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd")) + "\n\r" + string.Format(DateTime.Now.ToString("HH:mm:ss"));
                //blind();
                _time++;
                _time_auto++;
                // if (_time_auto == 10) _pop_change.Hide();
                //if (_time_auto >= 40)
                //{
                //    if (_status == "DMC") autoClick(_Loc_change_DMC);
                //    else autoClick(_Loc_change_DMP);
                //    _time_auto = 0;
                //}

                //if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 14) lbl_Shift1.Text = "Shift 1";
                //else if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 22) lbl_Shift1.Text = "Shift 2";
                //else lbl_Shift1.Text = "Shift 3";


                if (_time >= 60)
                {
                    _loadDif = false;
                   // _dtData = SEL_APS_PLAN_ACTUAL("70", _shift);
                    loaddata(true);

                    _time = 0;
                }

                //if (Convert.ToInt16(DateTime.Now.ToString("HH")) >= 14 && Convert.ToInt16(DateTime.Now.ToString("HH")) < 22)
                //    lblShift.Text = "SHIFT 2";
                //else if (Convert.ToInt16(DateTime.Now.ToString("HH")) >= 6 && Convert.ToInt16(DateTime.Now.ToString("HH")) < 14)
                //    lblShift.Text = "SHIFT 1";
                //else
                //    lblShift.Text = "SHIFT 3";
            }
            catch
            {
            }
        }


        private void tmr_blind_Tick(object sender, EventArgs e)
        {
            if (_status == "DMC") blind(_Loc_change_DMC);
            else blind(_Loc_change_DMP);
        }



        private void Frm_Mold_WS_Change_By_Shift_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            this.Dispose();
            base.Dispose(true);
        }


        private void Frm_Mold_WS_Change_By_Shift_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    //_time_auto = 10;
                    //if (_load_form)
                    //{

                    lbl_dif1.Text = "";
                    lbl_dif2.Text = "";
                    lbl_dif3.Text = "";

                    _isLoad = true;
                    dtpDate.EditValue = DateTime.Now;

                    _time = 0;
                    
                    if (Convert.ToInt16(DateTime.Now.ToString("HH")) >= 14 && Convert.ToInt16(DateTime.Now.ToString("HH")) < 22)
                    {
                        lbl_Shift_Click(lbl_Shift2, null);
                    }
                    else if (Convert.ToInt16(DateTime.Now.ToString("HH")) >= 6 && Convert.ToInt16(DateTime.Now.ToString("HH")) < 14)
                    {
                        lbl_Shift_Click(lbl_Shift1, null);
                    }
                    else
                    {
                        lbl_Shift_Click(lbl_Shift3, null);
                    }


                    lblPH1_Click(lblPH1, null);
                    timer1.Start();
                    tmrTime.Start();
                    
                    //lblDmp_Click(lblDmc, null);
                    //_load_form = false;
                    //}                 
                }
                else
                {
                    //_load_form = true;
                    timer1.Stop();
                    tmrTime.Stop();
                }

            }
            catch (Exception)
            { }
            finally
            {
                _isLoad = false;
            }
        }

        private void axGrid_BeforeEditMode(object sender, AxFPSpreadADO._DSpreadEvents_BeforeEditModeEvent e)
        {
            e.cancel = true;
        }

        private void lblPH3_Click(object sender, EventArgs e)
        {
            try
            {
                _iCount = 0;
                lblPH1.BackColor = Color.LightGray;
                lblPH3.BackColor = Color.White;
                lblPH2.BackColor = Color.LightGray;
                _status = "PH3";
                loaddata(true);
                //Form_Main.headText = "Phylon APS Plan && Actual ";

            }
            catch (Exception)
            { }

        }

        private void lblPH2_Click(object sender, EventArgs e)
        {
            try
            {
                _iCount = 0;
                lblPH1.BackColor = Color.LightGray;
                lblPH3.BackColor = Color.LightGray;
                lblPH2.BackColor = Color.White;
                _status = "PH2";
                loaddata(true);
                //Form_Main.headText = "Phylon APS Plan && Actual ";


            }
            catch (Exception)
            { }

        }

        private void lblPH1_Click(object sender, EventArgs e)
        {
            lblPH1.Visible = true;
            lblPH3.Visible = true;
            lblPH2.Visible = true;
            lblPH1.BackColor = Color.White;
            lblPH3.BackColor = Color.LightGray;
            lblPH2.BackColor = Color.LightGray;
            Form_Home_Phylon._type = "PH";
            _status = "PH1";
            _loadDif = true;
            
            loaddata(true);
            lblTitle.Text = "Phylon APS Plan && Actual ";

        }

        private void lblCMP_Click(object sender, EventArgs e)
        {
            lblPH1.Visible = false;
            lblPH3.Visible = false;
            lblPH2.Visible = false;
            lbl_Dif.Visible = false;
            Form_Home_Phylon._type = "CMP";
            _status = "CMP";
            _loadDif = true;
            loaddata(true);
            lblTitle.Text = "CMP APS Plan && Actual ";
            // Form_Main.headText = "CMP APS Plan && Actual ";
        }

        //private void lbl_plan_Click(object sender, EventArgs e)
        //{
        //    lblPH2_Click(lblPH2, null);
        //}

        //private void lbl_actual_Click(object sender, EventArgs e)
        //{
        //    lblPH3_Click(lblPH2, null);
        //}
        private void lbl_Shift_Click(object sender, EventArgs e)
        {
            Control cmd = (Control)sender;
            foreach (Control ctr in pnShift.Controls)
            {
                if (!ctr.Name.Contains("lbl_Shift")) continue;
                if (ctr.Name == cmd.Name)
                {
                    cmd.BackColor = Color.DodgerBlue;
                    cmd.ForeColor = Color.White;
                    _shift = cmd.Tag.ToString();
                    if (!_isLoad)
                    {
                        _loadDif = false;
                        loaddata(true);
                    }
                        
                    _time = 0;
                }
                else
                {
                    ctr.BackColor = Color.Gray;
                    ctr.ForeColor = Color.White;
                }
            }




        }

        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            if (_isLoad) return;
            _loadDif = true;
            loaddata(true);
            _time = 0;
        }

        #endregion Event



    }
}
