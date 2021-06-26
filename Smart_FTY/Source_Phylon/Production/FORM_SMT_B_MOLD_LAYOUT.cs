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
//using MaterialSetRate;
using System.Data.SqlClient;
//using ChartDirector;
using System.Threading;
using Smart_FTY.ClassLib;
//using WarehouseMaterialSystem.ClassLib;


namespace Smart_FTY
{



    public partial class FORM_SMT_B_MOLD_LAYOUT : Form_Parent
    {
        public FORM_SMT_B_MOLD_LAYOUT( string argType)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

           // initForm(argType);
        }

        public FORM_SMT_B_MOLD_LAYOUT()
        {
            // TODO: Complete member initialization
        }
        int _iPlan = 0, _iNoPlan = 0, _iNoUse = 0, _iMoldChange = 0;
        string _shift = "1";

        #region Init
        DataTable _dt_layout = null;
        Dictionary<string, string> _dicChange = new Dictionary<string, string>();
        Dictionary<string, string> _Dic_Location = new Dictionary<string, string>();
        string[] keysForValues = { };
        string _status ;
        public int _Izone = 1;
        string _lbl1, _lbl2, _lbl3;
        public int _time = 0;
        int _time_load = 40;
        int _time_auto = 0;
        DataTable _dt_layout_PH1 = null;
        DataTable _dt_layout_PH2 = null;
        DataTable _dt_layout_PH3 = null;
        string[] str_yellow;
        int _iColor = 0;
        bool _load_form = true;
        int _iCount = 0;
        int _bf_clickRow=0, _bf_clickCol=0;
        DataTable _dt_row = null;
        

        
       // FORM_MOLD_PRODUCTION_POP _pop_change = new FORM_MOLD_PRODUCTION_POP();
      //  FORM_MOLD_PRODUCTION_POP_PRE _pop_change_pre = new FORM_MOLD_PRODUCTION_POP_PRE();
      //  Thread th;
         
        List<string> _Loc_change_DMC = new List<string>();
        List<string> _Loc_plan_DMC = new List<string>();
        List<string> _Loc_change = new List<string>();
        List<string> _Loc_plan_DMP = new List<string>();

        ArrayList a = new ArrayList();

        #endregion Init

        #region Function

        private void initForm(string argForm)
        {
            if (argForm == "2")
            {
                pnFormType.Visible = false;
                this.Text = "Mold2";
                _load_form = false;
                lblCMP_Click(null, null);
                pnHeader.BackColor = Color.RoyalBlue;
            }
            
        }
        
        
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

        private void create_default()
        {
            try
            {
                int iRowHeight, iFontSize;
                double iColWidth;

                //if (_status == "PH1")
                //{
                    iRowHeight = 15;
                    iColWidth = 2.3; //SET COLLUM WIDTH
                    iFontSize = 7; //SET FONT BODY

               // }
                //else
                //{
                //    iRowHeight = 32;
                //    iColWidth = 5.8;
                //    iFontSize = 15;
                //}

                axGrid.Reset();
                axGrid.GrayAreaBackColor = Color.White;
                axGrid.DisplayColHeaders = false;
                axGrid.DisplayRowHeaders = false;
                axGrid.ActiveCellHighlightStyle = FPSpreadADO.ActiveCellHighlightStyleConstants.ActiveCellHighlightStyleOff;
                axGrid.ColHeaderRows = 0;
                //if (_status=="PH3")
                //    axGrid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsVertical;
                //else
                    axGrid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsNone;
                axGrid.Font = new System.Drawing.Font("Calibri", iFontSize);
                axGrid.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleNone;

                // axGrid.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleNone;
                axGrid.set_RowHeight(1, 0.5);
                //axGrid.set_RowHeight(20, 9);
                //axGrid.set_ColWidth((int)G.S1_Blank, 5.37);
                axGrid.set_ColWidth(1, 0.5);
                //axGrid.set_ColWidth((int)G.S3_Blank, 5.37);
                //axGrid.set_ColWidth((int)G.Blank1, 13.62);
                //axGrid.set_ColWidth((int)G.Blank2, 13.62);
                axGrid.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                axGrid.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                axGrid.SetCellBorder(1, 1, 200, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                axGrid.SetCellBorder(1, 1, 200, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                //  axGrid.SetCellBorder((int)G.S1_M1_L_Plan, 1, (int)G.S3_M2_R_Act, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);


                //  axGrid.SetCellBorder((int)G.S1_M1_L_Tar, 1, (int)G.S3_M2_R_Cur, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexOutline, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                

                for (int irow = 2; irow <= 50; irow++)
                    axGrid.set_RowHeight(irow, iRowHeight);

                for (int icol = 2; icol <= 200; icol++)
                    axGrid.set_ColWidth(icol, iColWidth);
            }
            catch (Exception)
            {}            
        }
        private void SetModelCMP(int arg_icol, int arg_irow, string arg_text, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            if (arg_icol == 2)
                arg_grid.set_ColWidth(arg_icol, 4.0);
            else
                arg_grid.set_ColWidth(arg_icol, 7.0);
            arg_grid.AddCellSpan(arg_icol, arg_irow, 1, 16);
            arg_grid.Col = arg_icol;
            arg_grid.Row = arg_irow;
            arg_grid.Text = arg_text;
            arg_grid.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignRight;
            arg_grid.TypeTextOrient = FPSpreadADO.TypeTextOrientConstants.TypeTextOrientUp;
            arg_grid.FontBold = true;
            arg_grid.FontSize = 20;


        }
        #region CMP
        private void DisplayGridCMP(DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {

            _Dic_Location = new Dictionary<string, string>();
            create_default();
            _Loc_change.Clear();
            _dicChange.Clear();
           // Form_Main.headText = "";
            _iNoUse = 0; _iNoPlan = 0; _iMoldChange = 0; _iPlan = 0;

            grdviewMachine.Visible = true;
            gridModel.Visible = true;
            DataTable _dtMachineCMP = null;
            DataTable _dtModelCMP = null;

            _dtMachineCMP = SEL_APS_PLAN_ACTUAL("40", "Q", "");
            _dtModelCMP = SEL_APS_PLAN_ACTUAL("40", "Q1", "");

            lblCapacity.Text = "Mold Capacity: " + _dtMachineCMP.Rows[0]["MOLD"].ToString().Trim() + " Set";

            if (_dtMachineCMP != null)
            {
                grdviewMachine.DataSource = _dtMachineCMP.Select("MACHINE_NAME <>'TOTAL'").CopyToDataTable();
                gvwviewMachine.Columns[2].OwnerBand.Caption = _dtMachineCMP.Rows[0]["MOLD"].ToString();
                gvwviewMachine.Columns[3].OwnerBand.Caption = _dtMachineCMP.Rows[0]["INPUT"].ToString();
                gvwviewMachine.Columns[4].OwnerBand.Caption = _dtMachineCMP.Rows[0]["BALANCE"].ToString();
                gvwviewMachine.Columns[5].OwnerBand.Caption = _dtMachineCMP.Rows[0]["QTY"].ToString();
            }
            if (_dtModelCMP != null)
            {
                gridModel.DataSource = _dtModelCMP.Select("SHORT_NAME <>'TOTAL'").CopyToDataTable();
                bandedGridModel.Columns[5].OwnerBand.Caption = _dtModelCMP.Rows[0]["QTY"].ToString();
                bandedGridModel.Columns[6].OwnerBand.Caption = _dtModelCMP.Rows[0]["MOLD_INPUT"].ToString();
            }


            for (int i = 0; i < gvwviewMachine.Columns.Count; i++)
            {

                gvwviewMachine.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwviewMachine.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                gvwviewMachine.Columns[i].OptionsColumn.ReadOnly = true;
                gvwviewMachine.Columns[i].OptionsColumn.AllowEdit = false;
                gvwviewMachine.Columns[i].OptionsFilter.AllowFilter = false;
                gvwviewMachine.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gvwviewMachine.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
                gvwviewMachine.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //if (i > 0)
                //{
                //    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                //    grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //    grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                //}
            }

            for (int i = 0; i < bandedGridModel.Columns.Count; i++)
            {
                bandedGridModel.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                bandedGridModel.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                bandedGridModel.Columns[i].OptionsColumn.ReadOnly = true;
                bandedGridModel.Columns[i].OptionsColumn.AllowEdit = false;
                bandedGridModel.Columns[i].OptionsFilter.AllowFilter = false;
                bandedGridModel.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                bandedGridModel.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
                bandedGridModel.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //if (i > 0)
                //{
                //    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                //    grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //    grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                //}
            }

            try
            {
                if (arg_dt == null || arg_dt.Rows.Count == 0) return;



                int row_s = 2;
                int irow = row_s;
                int icol = 4;

                MachineHeadCMP(icol, irow, 0, arg_dt, arg_grid);
                irow = row_s + 2;
                MachineBodyCMP(icol, irow, 0, arg_dt, arg_grid);
                _Dic_Location.Add(irow.ToString() + "-" + icol.ToString(), arg_dt.Rows[0]["MODEL_NM"].ToString());
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
                            icol += 1;
                        }
                        MachineBodyCMP(icol, irow, i, arg_dt, arg_grid);

                        SetModelCMP(icol -1, row_s + 1, arg_dt.Rows[i]["MODEL_NAME"].ToString(), axGrid);
                    }
                    else
                    {
                       // SetModelCMP(2, row_s + 1, arg_dt.Rows[i]["MODEL_NAME"].ToString(), axGrid);
                        arg_grid.set_ColWidth(icol + 3, 0.7);
                        icol += 3;
                        irow = row_s;
                        MachineHeadCMP(icol, irow, i, arg_dt, arg_grid);
                        irow = row_s + 2;
                        MachineBodyCMP(icol, irow, i, arg_dt, arg_grid);
                    }
                    string loc = irow.ToString() + "-" + icol.ToString();
                    _Dic_Location.Add(loc, arg_dt.Rows[i]["MODEL_NM"].ToString());
                }

                if (_Loc_change.Count > 0) tmr_blind.Start();
                else tmr_blind.Stop();

                arg_grid.MaxRows = irow;
                //arg_grid.MaxCols = icol;
            }
            catch
            { }
            finally
            {
               // Smart_FTY.ClassLib.WinAPI.AnimateWindow(arg_grid.Handle, 200, Smart_FTY.ClassLib.WinAPI.getSlidType("2"));
                arg_grid.Visible = true;
            }
        }

        private void MachineHeadCMP(int arg_icol, int arg_irow, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                int iRow = Convert.ToInt32(arg_dt.Rows[arg_idt]["NUM_MINI_LINE"]);
                arg_grid.Col = arg_icol;
                arg_grid.Row = arg_irow;
                arg_grid.Text = "Line " + arg_dt.Rows[arg_idt]["LINE_NAME"].ToString();
                arg_grid.FontSize = 20;
                arg_grid.FontBold = true;
                arg_grid.set_RowHeight(arg_irow, 25);

                arg_grid.BackColor = Color.DodgerBlue;
                arg_grid.ForeColor = Color.White;
                arg_grid.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                arg_grid.AddCellSpan(arg_icol, arg_irow, iRow * 2, 1);

                //arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexOutline, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                // arg_grid.SetCellBorder(icol, irow, icol + 3, irow + 1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow +1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);


                arg_irow++;
                arg_grid.Row = arg_irow;
                for (int i = 0; i < iRow; i++)
                {
                    //if (arg_dt.Rows[arg_idt]["LINE_NAME"].ToString() == "E")
                    //    arg_grid.set_ColWidth(arg_icol + (i * 2), 6.0);

                    arg_grid.Col = arg_icol + (i * 2);
                    arg_grid.Text = "M/C";
                    arg_grid.BackColor = Color.LightSkyBlue;
                    //  arg_grid.ForeColor = Color.White;
                    arg_grid.FontSize = 18;
                    arg_grid.FontBold = true;

                    arg_grid.Col = arg_icol + (i * 2) + 1;
                    arg_grid.Text = "Size";
                    arg_grid.BackColor = Color.LightSkyBlue;
                    //arg_grid.ForeColor = Color.White;
                    arg_grid.FontSize = 18;
                    arg_grid.FontBold = true;
                }
                arg_grid.Col = -1;
                arg_grid.set_RowHeight(arg_irow, 25);

                //arg_grid.Col = arg_icol + 2;
                //arg_grid.Text = "R";
                //arg_grid.BackColor = Color.LightSkyBlue;
                ////  arg_grid.ForeColor = Color.White;
                //arg_grid.Font = new System.Drawing.Font("Calibri", 15, FontStyle.Bold);


            }
            catch
            { }

        }

        public void MachineBodyCMP(int arg_icol, int arg_irow, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol + 1, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol + 2, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol + 1, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                arg_grid.set_RowHeight(arg_irow, 20);
                arg_grid.set_ColWidth(arg_icol, 13);
                arg_grid.set_ColWidth(arg_icol + 1, 8);

                arg_grid.Col = arg_icol;
                arg_grid.Row = arg_irow;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MACHINE_NAME"].ToString();
                arg_grid.FontSize = 15;
                //for (int ic = 2; ic <= 150; ic++)
                //    arg_grid.set_ColWidth(ic, 10.2);


                arg_grid.Col = arg_icol + 1;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MOLD_SIZE_CD"].ToString();
                arg_grid.FontSize = 15;

                if (arg_dt.Rows[arg_idt]["USE_YN"].ToString() == "N")
                {
                    arg_grid.BackColor = Color.LightGray;
                    _iNoUse++;
                    //for (int ic = 2; ic <= 150; ic++)
                    //    arg_grid.set_ColWidth(ic, 10.2);
                    //_dtColor.Rows[row_index][column_index] = "5";
                }
                else if (arg_dt.Rows[arg_idt]["MOLD_SIZE_CD"].ToString() == "")
                {
                    arg_grid.BackColor = Color.Red;

                    _iNoPlan++;
                    //if (arg_dt.Rows[arg_idt]["PLAN_FIX_YN"].ToString() == "N")
                    //{
                    //    arg_grid.BackColor = Color.Red;

                    //    _iNoPlan++;
                    //}
                    //if (arg_dt.Rows[arg_idt]["PLAN_FIX_YN"].ToString() == "Y")
                    //{
                    //    arg_grid.BackColor = Color.LightCyan;
                    //    // _dtColor.Rows[row_index][column_index] = "8";
                    //}
                    //else
                    //{
                    //    arg_grid.BackColor = Color.Red;
                    //    //_dtColor.Rows[row_index][column_index] = "4";
                    //}
                }
                else if (arg_dt.Rows[arg_idt]["MOLD_CHANGE"].ToString() != "")
                {
                    arg_grid.BackColor = Color.Yellow;
                    _dicChange.Add((arg_icol + 1).ToString("00") + arg_irow.ToString("00"), arg_dt.Rows[arg_idt]["MACHINE_ID"].ToString());
                    if (arg_dt.Rows[arg_idt]["MOLD_CHANGE"].ToString() == "N")
                        _Loc_change.Add((arg_icol + 1).ToString() + " " + arg_irow.ToString());
                    _iMoldChange++;
                    //_dtColo.Rows[row_index][column_index] = "6";
                }
                else
                {
                    _iPlan++;
                    arg_grid.BackColor = Color.FromArgb(0, 255, 0);
                    //_dtColor.Rows[row_index][column_index] = "3";
                }

            }
            catch (Exception)
            { }

        }

        #endregion CMP

        #region No Use
        private void MachineCenter(int arg_col, int arg_row, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            int c = Convert.ToInt32(arg_dt.Rows[arg_idt]["line"].ToString());
            //if (arg_dt.Rows[arg_idt]["STATION_CD"].ToString() != "01" && arg_dt.Rows[arg_idt]["STATION_CD"].ToString() != "04")
            //{

            for (int i = 1; i <= c; i++)
            {

                arg_grid.Row = arg_row;
                arg_grid.Col = arg_col + i;
                arg_grid.BackColor = Color.FromArgb(255, 137, 119);
            }

            //}
            arg_grid.SetCellBorder(arg_col + 1, arg_row, arg_col + c, arg_row
                                      , FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0x7789ff
                                      , FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
            arg_grid.SetCellBorder(arg_col + 1, arg_row, arg_col + c, arg_row
                                  , FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0x7789ff
                                  , FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

        }

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

                //arg_grid.SetCellBorder(arg_col, arg_row, arg_col, arg_row, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(arg_col + 1, arg_row, arg_col + 1, arg_row, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(arg_col, arg_row, arg_col, arg_row, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(arg_col, arg_row, arg_col, arg_row, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                arg_grid.Row = arg_row;
                arg_grid.Col = arg_col;
                arg_grid.Text = _dt_layout_PH1.Rows[arg_idt]["size_plan"].ToString();
                arg_grid.BackColor = Color.FromName(arg_dt.Rows[arg_idt]["color_B_value"].ToString());
                arg_grid.ForeColor = Color.FromName(arg_dt.Rows[arg_idt]["color_F_value"].ToString());


                //if (arg_dt.Rows[arg_idt]["Status"].ToString() == "1")
                //    _Loc_plan_DMC.Add(arg_col + " " + arg_row + " " + arg_dt.Rows[arg_idt]["machine_id"].ToString());
                //if (arg_dt.Rows[arg_idt]["Status"].ToString() == "2")
                //    _Loc_change_DMC.Add(arg_col  + " " + arg_row + " " + arg_dt.Rows[arg_idt]["machine_id"].ToString());

                //if (arg_dt.Rows[arg_idt]["direction"].ToString() == "1")
                //{
                //    arg_col++;
                //}
                //else if (arg_dt.Rows[arg_idt]["direction"].ToString() == "2")
                //{
                //    arg_row++;
                //}
                //else if (arg_dt.Rows[arg_idt]["direction"].ToString() == "3")
                //{
                //    arg_col--;
                //}
                //else if (arg_dt.Rows[arg_idt]["direction"].ToString() == "4")
                //{
                //    arg_row--;
                //}

                //arg_grid.Row = arg_row;
                //arg_grid.Col = arg_col;

                //switch (_dt_layout_DMC.Rows[arg_idt]["STATION_CD"].ToString())
                //{
                //    case "05":
                //    case "09":
                //    case "13":
                //    case "16":
                //        arg_grid.Text += "/" + _dt_layout_DMC.Rows[arg_idt]["STATION_CD"].ToString();
                //        break;
                //    default:
                //        arg_grid.Text = _dt_layout_DMC.Rows[arg_idt]["STATION_CD"].ToString();
                //        break;
                //}
            }
            catch (Exception)
            { }

        }

        private void DisplayGridDMC(DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                if (arg_dt == null || arg_dt.Rows.Count == 0) return;
                axGrid.ClearRange(0, 0, 50, 50, true);
                create_default();
                _Loc_change_DMC.Clear();
                int row_s2 = 15;
                int row_s1 = 7;
                int row_s3 = 23;
                int col_s3 = 6;
                int irow = row_s2;
                int icol = 4;

                MachineBodyDMC(icol, irow, 0, arg_dt, arg_grid);
                MachineCenter(icol, irow, 0, arg_dt, arg_grid);
                for (int i = 1; i < arg_dt.Rows.Count; i++)
                {

                    if (arg_dt.Rows[i]["machine_cd"].ToString() == arg_dt.Rows[i - 1]["machine_cd"].ToString())
                    {
                        if (arg_dt.Rows[i]["direction"].ToString() == arg_dt.Rows[i - 1]["direction"].ToString())
                        {
                            if (arg_dt.Rows[i]["direction"].ToString() == "1")
                            {
                                irow--;
                                MachineCenter(icol, irow, i, arg_dt, arg_grid);
                            }
                            else if (arg_dt.Rows[i]["direction"].ToString() == "2") icol++;
                            else if (arg_dt.Rows[i]["direction"].ToString() == "3") irow++;
                            else icol--;
                            MachineBodyDMC(icol, irow, i, arg_dt, arg_grid);

                        }
                        else
                        {
                            if (arg_dt.Rows[i]["direction"].ToString() == "2")
                            {
                                irow--;
                                icol++;
                                MachineHeadDMC(icol, irow - 1, i, arg_dt, arg_grid);
                            }
                            else if (arg_dt.Rows[i]["direction"].ToString() == "3")
                            {
                                icol++;
                                irow++;
                            }
                            else if (arg_dt.Rows[i]["direction"].ToString() == "4")
                            {
                                irow++;
                                icol--;
                            }
                            MachineBodyDMC(icol, irow, i, arg_dt, arg_grid);
                        }
                    }
                    else
                    {
                        if (arg_dt.Rows[i]["line_id"].ToString() == "2")
                        {
                            irow = row_s2;
                            icol = icol + 6;
                            //  axGrid.SetText(icol, irow, "2");
                        }
                        else if (arg_dt.Rows[i]["line_id"].ToString() == "1")
                        {
                            irow = row_s1;
                            icol--;
                            //   axGrid.SetText(icol, irow,"1");
                        }
                        else
                        {
                            irow = row_s3;
                            col_s3 += 8;
                            icol = col_s3;
                        }
                        MachineBodyDMC(icol, irow, i, arg_dt, arg_grid);
                        MachineCenter(icol, irow, i, arg_dt, arg_grid);
                    }
                }

                //if (_Loc_change.Count > 0) tmr_blind.Start();
                // else tmr_blind.Stop();
            }
            catch
            { }
        }
        #endregion No Use

        #region PH1

        public DataTable SEL_APS_PLAN_ACTUAL(string WH,string TYPE,string NO)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "PKG_SPB_MOLD_WMS_V2.SEL_MOLD_PROD_LAYOUT_PH";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;


                MyOraDB.Parameter_Name[0] = "ARG_WH";
                MyOraDB.Parameter_Name[1] = "ARG_TYPE";
                MyOraDB.Parameter_Name[2] = "ARG_DATE";
                MyOraDB.Parameter_Name[3] = "ARG_SHIFT";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = WH;
                MyOraDB.Parameter_Values[1] = TYPE;
                MyOraDB.Parameter_Values[2] = dtpDate.DateTime.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[3] = _shift;
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


        private void DisplayGridPH1(DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {

            //Form_Main.headText = "Phylon Loaded Status";
            try
            {

                _Dic_Location = new Dictionary<string, string>();

                if (arg_dt == null || arg_dt.Rows.Count == 0) return;
                // axGrid.ClearRange(0, 0, 50, 50, true);
                create_default();
                _Loc_plan_DMP.Clear();
                _iNoUse = 0; _iNoPlan = 0; _iMoldChange = 0; _iPlan = 0;
                //_row1 = Convert.ToInt32(arg_dt.Rows[0]["Row1"]);
                //_row2 = Convert.ToInt32(arg_dt.Rows[0]["Row2"]);
                //_row3 = Convert.ToInt32(arg_dt.Rows[0]["Row3"]);
                int row_s = 2, col_s =3;
                int irow = row_s;
                int icol = col_s, iCount = 1;

                //SetModelPH1(2, row_s + 1, arg_dt.Rows[0]["MODEL_NAME"].ToString(), axGrid);
                MachineHeadPH1(icol, irow, 0, arg_dt, arg_grid);
                irow ++;
                MachineBodyPH1(icol, irow, 0, arg_dt, arg_grid);
                icol++;
                _Dic_Location.Add(irow.ToString() + "-" + icol.ToString(), arg_dt.Rows[0]["MODEL_NM"].ToString());
                for (int i = 1; i < arg_dt.Rows.Count; i++)
                {
                    iCount++;
                    //if (i==46) break;

                    if (arg_dt.Rows[i]["ZONE_CD"].ToString() == arg_dt.Rows[i - 1]["ZONE_CD"].ToString())
                    {
                        if (arg_dt.Rows[i]["MACHINE_NAME"].ToString() == arg_dt.Rows[i - 1]["MACHINE_NAME"].ToString())
                        {
                            if (iCount > 4)
                            {
                                irow ++;
                                icol = col_s;
                                iCount = 1;
                            }
                            
                            MachineBodyPH1(icol, irow, i, arg_dt, arg_grid);
                            icol++;
                        }
                        else
                        {

                            //if (arg_dt.Rows[i]["MACHINE_NAME"].ToString() == "KM- 39")
                            //{
                            //    SetModelPH1(col_s + 54, row_s + 1, arg_dt.Rows[i]["MODEL_NAME"].ToString(), axGrid);
                            //    col_s += 55;
                            //}
                            //else
                            //{
                                //SetModelPH1(col_s + 4, row_s + 1, arg_dt.Rows[i]["MODEL_NAME"].ToString(), axGrid);
                                col_s += 5;
                            //}
                            icol = col_s;
                            irow = row_s;
                            MachineHeadPH1(icol, irow, i, arg_dt, arg_grid);
                            irow++;
                            MachineBodyPH1(icol, irow, i, arg_dt, arg_grid);
                            icol++;
                            iCount = 1;
                        }
                    }
                    else
                    {
                        row_s += 14;
                        col_s = 3;
                        icol = col_s;
                        irow = row_s;
                        //SetModelPH1(2, row_s + 1, arg_dt.Rows[i]["MODEL_NAME"].ToString(), axGrid);

                        MachineHeadPH1(icol, irow, i, arg_dt, arg_grid);
                        irow++;
                        MachineBodyPH1(icol, irow, i, arg_dt, arg_grid);
                        icol++;
                        iCount = 1;
                    }

                    string loc = irow.ToString() + "-" + icol.ToString();

                    _Dic_Location.Add(loc, arg_dt.Rows[i]["MODEL_NM"].ToString());
                }
                arg_grid.MaxRows = irow;
                arg_grid.MaxCols = 170;
                //arg_grid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsHorizontal;
               // if (_Loc_yellow.Count > 0) tmr_blind.Start();
               // else tmr_blind.Stop();
            }
            catch
            {
            }
        }

        private void MachineHeadPH1(int arg_icol, int arg_irow, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                arg_grid.Col = arg_icol;
                arg_grid.Row = arg_irow;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MACHINE_NAME"].ToString();
                arg_grid.Font = new System.Drawing.Font("Calibri",9, FontStyle.Bold);
                arg_grid.BackColor = Color.DodgerBlue;
                arg_grid.ForeColor = Color.White;
                arg_grid.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                arg_grid.AddCellSpan(arg_icol, arg_irow, 4, 1);

                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow + 1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexOutline, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                // arg_grid.SetCellBorder(icol, irow, icol + 3, irow + 1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow +1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                //arg_grid.SetCellBorder(icol, irow, icol + 2, irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);


                //arg_irow++;
                //arg_grid.Row = arg_irow;
                //arg_grid.Col = arg_icol;
                //arg_grid.Text = "STA";
                //arg_grid.BackColor = Color.LightSkyBlue;
                ////  arg_grid.ForeColor = Color.White;
                //arg_grid.Font = new System.Drawing.Font("Calibri", 15, FontStyle.Bold);

                //arg_grid.Col = arg_icol + 1;
                //arg_grid.Text = "L";
                //arg_grid.BackColor = Color.LightSkyBlue;
                ////  arg_grid.ForeColor = Color.White;
                //arg_grid.Font = new System.Drawing.Font("Calibri", 15, FontStyle.Bold);

                //arg_grid.Col = arg_icol + 2;
                //arg_grid.Text = "R";
                //arg_grid.BackColor = Color.LightSkyBlue;
                ////  arg_grid.ForeColor = Color.White;
                //arg_grid.Font = new System.Drawing.Font("Calibri", 15, FontStyle.Bold);


            }
            catch
            {}
        }

        public void MachineBodyPH1(int arg_icol, int arg_irow, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                arg_grid.SetCellBorder(arg_icol + 1, arg_irow, arg_icol + 1, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol, arg_irow, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                arg_grid.set_RowHeight(arg_irow, 9);  //SET COLLUM HEIGHT


                arg_grid.Col = arg_icol;
                arg_grid.Row = arg_irow;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MOLD_SIZE_CD"].ToString();
                arg_grid.BackColor = Color.FromName(arg_dt.Rows[arg_idt]["B_COLOR"].ToString());
                arg_grid.ForeColor = Color.FromName(arg_dt.Rows[arg_idt]["F_COLOR"].ToString());

                if (arg_dt.Rows[arg_idt]["B_COLOR"].ToString().ToLower() == "red")
                {
                    _iNoPlan++;
                }
                else if (arg_dt.Rows[arg_idt]["B_COLOR"].ToString().ToLower() == "lightgray")
                {
                    _iNoUse++;
                }
                else if (arg_dt.Rows[arg_idt]["B_COLOR"].ToString().ToLower() == "lime")
                {
                    _iPlan++;
                }
                
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
            {}

        }

        private void SetModelPH1(int arg_icol, int arg_irow, string arg_text, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            if (arg_icol == 2)
                arg_grid.set_ColWidth(arg_icol, 4.0);
            else
                arg_grid.set_ColWidth(arg_icol, 7.0);
            arg_grid.AddCellSpan(arg_icol, arg_irow, 1, 11);
            arg_grid.Col = arg_icol;
            arg_grid.Row = arg_irow;
            arg_grid.Text = arg_text;
            arg_grid.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignRight;
            arg_grid.TypeTextOrient = FPSpreadADO.TypeTextOrientConstants.TypeTextOrientUp;
            arg_grid.FontBold = true;
            arg_grid.FontSize = 15;
            

        }
        
        #endregion PH1


        private void blind( List<string> arg_list)
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
                            axGrid.BackColor = Color.Lime;
                        }

                        axGrid.ForeColor = Color.Black;
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
            {}          
        }

        public void loaddata( bool arg_status)
        {
            try
            {
                
                //if (arg_status)
                //    this.axGrid.Hide();
                axGrid.Visible = false;
                DataTable dt = null;
                if (_status == "PH1")
                {
                    dt = SEL_APS_PLAN_ACTUAL("70_1");
                    if (dt != null && dt.Rows.Count > 0)
                        _dt_layout_PH1 = dt;

                    grdviewMachine.Visible = true;
                    gridModel.Visible = true;



                    
                    DisplayGridPH1(dt, axGrid);
                    lblPlan.Text = "Plan: " + _iPlan.ToString() + " Set";
                    lblNoPlan.Text = "No Plan: " +  _iNoPlan.ToString() + " Set";
                    lblNoUse.Text = "No Use: " + _iNoUse.ToString() + " Set";
                    lblMoldChange.Text = "Mold Change: " + _iMoldChange.ToString() + " Set";
                    

                    DataTable _dtMachine = SEL_APS_PLAN_ACTUAL("70", "Q", "A");
                    DataTable _dtModel = SEL_APS_PLAN_ACTUAL("70", "Q1", "A");

                    lblCapacity.Text = "Mold Capacity: " + _dtMachine.Rows[0]["MOLD"].ToString().Trim() + " Set";

                    if (_dtMachine != null)
                    {
                        grdviewMachine.DataSource = _dtMachine.Select("MACHINE_NAME <>'TOTAL'","LINE_NO").CopyToDataTable();
                        gvwviewMachine.Columns[2].OwnerBand.Caption = _dtMachine.Rows[0]["MOLD"].ToString();
                        gvwviewMachine.Columns[3].OwnerBand.Caption = _dtMachine.Rows[0]["INPUT"].ToString();
                        gvwviewMachine.Columns[4].OwnerBand.Caption = _dtMachine.Rows[0]["BALANCE"].ToString();
                        gvwviewMachine.Columns[5].OwnerBand.Caption = _dtMachine.Rows[0]["QTY"].ToString();
                    }
                    if (_dtModel != null)
                    {
                        gridModel.DataSource = _dtModel.Select("SHORT_NAME <>'TOTAL'").CopyToDataTable(); 
                        bandedGridModel.Columns[5].OwnerBand.Caption = _dtModel.Rows[0]["QTY"].ToString();
                        bandedGridModel.Columns[6].OwnerBand.Caption = _dtModel.Rows[0]["MOLD_INPUT"].ToString();
                    }

                    for (int i = 0; i < gvwviewMachine.Columns.Count; i++)
                    {

                        gvwviewMachine.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gvwviewMachine.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                        gvwviewMachine.Columns[i].OptionsColumn.ReadOnly = true;
                        gvwviewMachine.Columns[i].OptionsColumn.AllowEdit = false;
                        gvwviewMachine.Columns[i].OptionsFilter.AllowFilter = false;
                        gvwviewMachine.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gvwviewMachine.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
                        gvwviewMachine.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //if (i > 0)
                        //{
                        //    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        //    grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //    grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                        //}
                    }

                    for (int i = 0; i < bandedGridModel.Columns.Count; i++)
                    {

                        bandedGridModel.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        bandedGridModel.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                        bandedGridModel.Columns[i].OptionsColumn.ReadOnly = true;
                        bandedGridModel.Columns[i].OptionsColumn.AllowEdit = false;
                        bandedGridModel.Columns[i].OptionsFilter.AllowFilter = false;
                        bandedGridModel.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        bandedGridModel.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
                        bandedGridModel.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //if (i > 0)
                        //{
                        //    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        //    grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //    grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                        //}
                    }
                }
                else if (_status == "PH2")
                {
                    dt = SEL_APS_PLAN_ACTUAL("70_2");
                    if (dt != null && dt.Rows.Count > 0)
                        _dt_layout_PH2 = dt;

                    grdviewMachine.Visible = true;
                    gridModel.Visible = true;

                    DisplayGridPH1(_dt_layout_PH2, axGrid);
                    lblPlan.Text = "Plan: " + _iPlan.ToString() + " Set";
                    lblNoPlan.Text = "No Plan: " +  _iNoPlan.ToString() + " Set";
                    lblNoUse.Text = "No Use: " + _iNoUse.ToString() + " Set";
                    lblMoldChange.Text = "Mold Change: " + _iMoldChange.ToString() + " Set";

                    DataTable _dtMachine = SEL_APS_PLAN_ACTUAL("70", "Q", "B");
                    DataTable _dtModel = SEL_APS_PLAN_ACTUAL("70", "Q1", "B");

                    lblCapacity.Text = "Mold Capacity: " + _dtMachine.Rows[0]["MOLD"].ToString().Trim() + " Set";


                    if (_dtMachine != null)
                    {
                        grdviewMachine.DataSource = _dtMachine;
                    }
                    if (_dtModel != null)
                    {
                        gridModel.DataSource = _dtModel;
                    }

                    for (int i = 0; i < gvwviewMachine.Columns.Count; i++)
                    {

                        gvwviewMachine.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gvwviewMachine.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                        gvwviewMachine.Columns[i].OptionsColumn.ReadOnly = true;
                        gvwviewMachine.Columns[i].OptionsColumn.AllowEdit = false;
                        gvwviewMachine.Columns[i].OptionsFilter.AllowFilter = false;
                        gvwviewMachine.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gvwviewMachine.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
                        gvwviewMachine.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //if (i > 0)
                        //{
                        //    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        //    grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //    grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                        //}
                    }

                    for (int i = 0; i < bandedGridModel.Columns.Count; i++)
                    {

                        bandedGridModel.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        bandedGridModel.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                        bandedGridModel.Columns[i].OptionsColumn.ReadOnly = true;
                        bandedGridModel.Columns[i].OptionsColumn.AllowEdit = false;
                        bandedGridModel.Columns[i].OptionsFilter.AllowFilter = false;
                        bandedGridModel.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        bandedGridModel.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
                        bandedGridModel.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //if (i > 0)
                        //{
                        //    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        //    grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //    grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                        //}
                    }
                }
                else if (_status == "PH3")
                {
                    dt = SEL_APS_PLAN_ACTUAL("70_3");
                    if (dt != null && dt.Rows.Count > 0)
                        _dt_layout_PH3 = dt;

                    grdviewMachine.Visible = true;
                    gridModel.Visible = true;

                    DisplayGridPH1(_dt_layout_PH3, axGrid);
                    lblPlan.Text = "Plan: " + _iPlan.ToString() + " Set";
                    lblNoPlan.Text = "No Plan: " +  _iNoPlan.ToString() + " Set";
                    lblNoUse.Text = "No Use: " + _iNoUse.ToString() + " Set";
                    lblMoldChange.Text = "Mold Change: " + _iMoldChange.ToString() + " Set";

                    DataTable _dtMachine = SEL_APS_PLAN_ACTUAL("70", "Q", "C");
                    DataTable _dtModel = SEL_APS_PLAN_ACTUAL("70", "Q1", "C");

                    lblCapacity.Text = "Mold Capacity: " + _dtMachine.Rows[0]["MOLD"].ToString().Trim() + " Set";

                    if (_dtMachine != null)
                    {
                        grdviewMachine.DataSource = _dtMachine;
                    }
                    if (_dtModel != null)
                    {
                        gridModel.DataSource = _dtModel;
                    }

                    for (int i = 0; i < gvwviewMachine.Columns.Count; i++)
                    {

                        gvwviewMachine.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gvwviewMachine.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                        gvwviewMachine.Columns[i].OptionsColumn.ReadOnly = true;
                        gvwviewMachine.Columns[i].OptionsColumn.AllowEdit = false;
                        gvwviewMachine.Columns[i].OptionsFilter.AllowFilter = false;
                        gvwviewMachine.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gvwviewMachine.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
                        gvwviewMachine.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //if (i > 0)
                        //{
                        //    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        //    grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //    grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                        //}
                    }

                    for (int i = 0; i < bandedGridModel.Columns.Count; i++)
                    {

                        bandedGridModel.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        bandedGridModel.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                        bandedGridModel.Columns[i].OptionsColumn.ReadOnly = true;
                        bandedGridModel.Columns[i].OptionsColumn.AllowEdit = false;
                        bandedGridModel.Columns[i].OptionsFilter.AllowFilter = false;
                        bandedGridModel.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        bandedGridModel.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
                        bandedGridModel.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //if (i > 0)
                        //{
                        //    grdView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        //    grdView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //    grdView.Columns[i].DisplayFormat.FormatString = "#,0.##";
                        //}
                    }
                }
                else if (_status == "CMP")
                {
                    //try
                    //{

                    //    if (_dt_layout == null) _dt_layout = SEL_APS_PLAN_ACTUAL("40");
                    //    DisplayGrid(_dt_layout, axGrid);
                    //}
                    //catch (Exception)
                    //{ }
                    //finally
                    //{
                    //    WarehouseMaterialSystem.ClassLib.WinAPI.AnimateWindow(axGrid.Handle, 500, WarehouseMaterialSystem.ClassLib.WinAPI.getSlidType("2"));
                    //    axGrid.Visible = true;
                    //}



                    dt = SEL_APS_PLAN_ACTUAL("40");
                    if (dt != null && dt.Rows.Count > 0)
                        _dt_layout = dt;

                    DisplayGridCMP(_dt_layout, axGrid);
                    lblPlan.Text = "Plan: " + _iPlan.ToString() + " Set";
                    lblNoPlan.Text = "No Plan: " + _iNoPlan.ToString() + " Set";
                    lblNoUse.Text = "No Use: " + _iNoUse.ToString() + " Set";
                    lblMoldChange.Text = "Mold Change: " + _iMoldChange.ToString() + " Set";

                  //  lblCapacity.Text = "Mold Capacity: " + _dtMachine.Rows[0]["MOLD"].ToString().Trim() + " Set";
                }


                //autoClick();
                //if (arg_status)
                //{
                //    WarehouseMaterialSystem.ClassLib.WinAPI.AnimateWindow(this.axGrid.Handle, 400, WarehouseMaterialSystem.ClassLib.WinAPI.getSlidType("2"));
                    
                //}
            }
            catch (Exception)
            { }
            finally
            {
               // Smart_FTY.ClassLib.WinAPI.AnimateWindow(this.axGrid.Handle, 400, Smart_FTY.ClassLib.WinAPI.getSlidType("2"));
                axGrid.Visible = true;
            }
        }

        private void autoClick(List<string> arg_list)
        {
            try
            {
                if (arg_list.Count > 0)
                {
                    string str = arg_list.ElementAt(_iCount);
                    string[] st = str.Split(' ');
                    AxFPSpreadADO._DSpreadEvents_ClickEvent ev = new AxFPSpreadADO._DSpreadEvents_ClickEvent(Convert.ToInt32(st[0]), Convert.ToInt32(st[1]));
                    axGrid_ClickEvent(axGrid, ev);
                    if (_iCount == arg_list.Count - 1) _iCount = 0;
                    else _iCount++;
                }
            }
            catch (Exception)
            {}
        }
                

        #endregion Fuction

        #region DB
        public DataTable SEL_APS_PLAN_ACTUAL(string arg_wh)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "PKG_SPB_MOLD_WMS_V2.SEL_MOLD_PROD_LAYOUT_SHIFT";

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
                MyOraDB.Parameter_Values[2] = _shift;
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

    


        #endregion DB

        #region Event

        public void Frm_Mold_WS_Change_By_Shift_Load(object sender, EventArgs e)
        {
            GoFullscreen();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            try
            {               
                Application.Exit();
            }
            catch (Exception)
            {}
            
        }


       

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
                //blind();
                _time++;
                //_time_auto++;
                //if (_time_auto >= 20)
                //{
                //    if (_status == "DMC") autoClick(_Loc_change_DMC);
                //    else autoClick(_Loc_change_DMP);
                //    _time_auto = 0;
                //}
                

                if (_time >= _time_load)
                {
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
            //if (_status == "PHP")
                //blind(_Loc_change);
        }



        private void Frm_Mold_WS_Change_By_Shift_FormClosed(object sender, FormClosedEventArgs e)
        {
            lblShift.Visible = true;
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
                    dtpDate.EditValue = DateTime.Now;
                    tmrTime.Start();
                    _time_auto = 10;
                    
                    if (_load_form)
                    {
                        timer1.Start();
                        LoadShift();
                        lblCMP_Click(null, null);
                       // 
                        _load_form = false;
                    }                 
                }
                else
                {
                    _load_form = true;
                    timer1.Stop();
                    tmrTime.Stop();
                }
                
            }
            catch (Exception)
            {}
        }


        private void axGrid_BeforeEditMode(object sender, AxFPSpreadADO._DSpreadEvents_BeforeEditModeEvent e)
        {
            e.cancel = true;
        }
        
        private void axGrid_ClickEvent(object sender, AxFPSpreadADO._DSpreadEvents_ClickEvent e)
        {
            try
            {
                string str ;
                string str1 ;
                string[] st;
                //string[] st1;

                if (_status == "DMC")
                {
                    str = _Loc_change_DMC.Find(x => x.StartsWith(e.col + " " + e.row));
                    str1 = _Loc_plan_DMC.Find(x => x.StartsWith(e.col + " " + e.row));
                   // _pop_change_pre._wh = "90_1";
                }
                else
                {
                    str = _Loc_change.Find(x => x.StartsWith(e.col + " " + e.row));
                    str1 = _Loc_plan_DMP.Find(x => x.StartsWith(e.col + " " + e.row));
                //    _pop_change_pre._wh = "90";
                }

                if (str != null)
                {
                    st = str.Split(' ');
                 //   _pop_change._machine = st[2];
                  //  _pop_change.Hide();
                   // _pop_change.Show();

                }
                else if (str1 != null)
                {
                    //st1 = str1.Split(' ');
                    //_pop_change_pre._machine = st1[2];
                    
                    //_pop_change_pre.Hide();
                    //_pop_change_pre.Show();

                    //if (_bf_clickCol == 0 && _bf_clickRow == 0)
                    //{
                    //    _bf_clickCol = e.col;
                    //    _bf_clickRow = e.row;
                    //    axGrid.Col = e.col;
                    //    axGrid.Row = e.row;
                    //    axGrid.BackColor = Color.Blue;
                    //}
                    //else
                    //{
                    //    axGrid.Col = _bf_clickCol;
                    //    axGrid.Row = _bf_clickRow;
                    //    axGrid.BackColor = Color.Green;
                    //    axGrid.Col = e.col;
                    //    axGrid.Row = e.row;
                    //    axGrid.BackColor = Color.Blue;
                    //    _bf_clickCol = e.col;
                    //    _bf_clickRow = e.row;
                    //}

                }
                else
                {
                  //  _pop_change.Hide();
                 //   _pop_change_pre.Hide();
                }
            }
            catch (Exception)
            {}          
        }
        #endregion Event
        /// <summary>
        
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPH3_Click(object sender, EventArgs e)
        {
            try 
	        {
                _iCount = 0;
		        lblPH3.BackColor = Color.White;
               // lblPH3.ForeColor = Color.White;
                lblPH2.BackColor = Color.LightGray;
               // lblPH2.ForeColor = Color.White;
                lblPH1.BackColor = Color.LightGray;
                blTotal.BackColor = Color.LightGray;
              //  lblPH1.ForeColor = Color.White;
                label3.Visible = false;
                label4.Visible = false;
                lbl_Actual.Visible = false;
                lbl_Plan.Visible = false;
                lblbalace.Visible = false;

                
               // lblCMP2.BackColor = Color.DeepSkyBlue;
               // lblCMP2.ForeColor = Color.White;
                _status = "PH3";
                loaddata(true);
                lblTitle.Text = "Phylon Mold Layout";
               // Form_Main.headText = "Phylon Loaded Status";
                
	        }
	        catch (Exception)
	        {}
            
        }

        private void lblPH2_Click(object sender, EventArgs e)
        {
            try
            {
                _iCount = 0;
                lblPH2.BackColor = Color.White;
              //  lblPH2.ForeColor = Color.Black;
                lblPH3.BackColor = Color.LightGray ;
               // lblPH3.ForeColor = Color.White;
                lblPH1.BackColor = Color.LightGray;
                blTotal.BackColor = Color.LightGray;
              //  lblPH1.ForeColor = Color.White;
               // lblCMP2.BackColor = Color.DeepSkyBlue;
               // lblCMP2.ForeColor = Color.White;
                _status = "PH2";
                loaddata(true);
                lblTitle.Text = "Phylon Mold Layout";
                label3.Visible = false;
                label4.Visible = false;
                lbl_Actual.Visible = false;
                lbl_Plan.Visible = false;
                lblbalace.Visible = false;
              //  Form_Main.headText = "Phylon Loaded Status";
                

            }
            catch (Exception)
            {}

        }

        private void lblPH1_Click(object sender, EventArgs e)
        {
            _iCount = 0;
            //lblPH1.Visible = true;
            //lblPH2.Visible = true;
            //lblPH3.Visible = true;
           // lblPH1.BackColor = Color.Gray;
            lblPH1.BackColor = Color.White;
            lblPH3.BackColor = Color.LightGray;
          //  lblPH3.ForeColor = Color.White;
            lblPH2.BackColor = Color.LightGray;
            blTotal.BackColor = Color.LightGray;
           // lblPH2.ForeColor = Color.White;
           // lblCMP2.BackColor = Color.DeepSkyBlue;
           // lblCMP2.ForeColor = Color.White;
            _status = "PH1";
            lblTitle.Text = "Phylon Mold Layout";
            loaddata(true);
            label3.Visible = false;
            label4.Visible = false;


            lbl_Actual.Visible = false;
            lbl_Plan.Visible = false;
            lblbalace.Visible = false;
            //blTotal.Visible = true;
          //  Form_Main.headText = "Phylon Loaded Status";
        }

        private void lblCMP_Click(object sender, EventArgs e)
        {
            _iCount = 0;
            lblPH1.Visible = false;
            lblPH2.Visible = false;
            lblPH3.Visible = false;
            lbl_Actual.Visible = false;
            lbl_Plan.Visible = false;
            lblbalace.Visible = false;
            blTotal.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            // lblCMP2.BackColor = Color.White;
            //  lblCMP2.ForeColor = Color.White;
            //  lblPH3.BackColor = Color.LightGray;
            //lblPH3.ForeColor = Color.White;
            //lblPH2.BackColor = Color.LightGray;
            //lblPH2.ForeColor = Color.White;
            //lblPH1.BackColor = Color.Coral;
            //lblPH1.ForeColor = Color.White;
            _status = "CMP";
            lblTitle.Text = "CMP Mold Layout";
            loaddata(true);
            //   Form_Main.headText = "CMP Loaded Status";
            
           

        }

        private void axGrid_Advance(object sender, AxFPSpreadADO._DSpreadEvents_AdvanceEvent e)
        {

        }
        /// <summary>
        /// //////////////////////////////////////////////TOTAL////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blTotal_Click(object sender, EventArgs e)
        {
            loaddata();
            grdviewMachine.Visible = false;
            gridModel.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            blTotal.BackColor = Color.White;
            lblPH1.BackColor = Color.LightGray;
            lblPH2.BackColor = Color.LightGray;
            lblPH3.BackColor = Color.LightGray;
            lbl_Actual.Visible = true;
            lbl_Plan.Visible = true;
            lblbalace.Visible = true;
            

        }
    
        public void loaddata()
        {
            try
            {

               
                this.axGrid.Hide();
                DataTable dt = null;
                DataTable dt2 = null;
              
                dt2 = SEL_APS_PLAN_ACTUAL_ROW("70");


              
                dt = SEL_APS_PLAN_ACTUAL2("70");
                //_dt_row = SEL_APS_PLAN_ACTUAL_ROW("70_1");
                if (dt != null && dt.Rows.Count > 0)
                    _dt_layout_PH1 = dt;
                _dt_row = dt2;

                this.axGrid.Hide();
                DisplayGridPH1(_dt_layout_PH1, _dt_row, axGrid);
                
            }
            catch
            { }
            finally
            {
                this.axGrid.Show();
            }
        }

        public DataTable SEL_APS_PLAN_ACTUAL_ROW(string arg_wh)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {//PKG_SPB_MODEL_TEMP.SEL_PHYLON_MOLD_ROW
                string process_name = "PKG_SPB_MODEL_TEMP.SEL_PHYLON_MOLD_ROW";
                // string process_name = "PKG_SPB_MOLD_WMS_V2.SEL_MOLD_WH_ACTUAL_V2";


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


        public DataTable SEL_APS_PLAN_ACTUAL2(string arg_wh)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "PKG_SPB_MODEL_TEMP.SEL_PHYLON_MOLD_LAYOUT";
                //string process_name = "PKG_SPB_MOLD_WMS_V2.SEL_MOLD_APS_ACTUAL";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;


                MyOraDB.Parameter_Name[0] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = arg_wh;
                MyOraDB.Parameter_Values[1] = "";

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


        private void DisplayGridPH1(DataTable arg_dt, DataTable arg_dt2, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            // dt2 = SEL_APS_PLAN_ACTUAL_ROW("70_1");


            try
            {
                if (arg_dt == null || arg_dt.Rows.Count == 0) return;
                // axGrid.ClearRange(0, 0, 50, 50, true);

                create_default2();
                //  _Loc_plan_DMP.Clear();
                //_row1 = Convert.ToInt32(arg_dt.Rows[0]["Row1"]);
                //_row2 = Convert.ToInt32(arg_dt.Rows[0]["Row2"]);
                //_row3 = Convert.ToInt32(arg_dt.Rows[0]["Row3"]);
                int row_s = 2, col_s = 2, row_max = 2;
                int irow = row_s;
                int icol = col_s;
                

                int irow1 = 2 + Convert.ToInt32(arg_dt2.Rows[0]["MACHINE"].ToString());
               // arg_grid.set_RowHeight(irow, 40);
                //arg_grid.MaxRows = irow1 + 3;
                MachineHeadPH11(icol, irow, 0, arg_dt, arg_grid);
                irow += 1;

                for (int i = 0; i < arg_dt.Rows.Count; i++)
                {
                    MachineBodyPH1(icol, irow, irow1, i, arg_dt, arg_grid);
                    axGrid.set_RowHeight(irow, 40);
                    irow++; 
 
                    if ((i + 1) % 12 == 0)
                    {
                        irow = 2;
                        icol += 5;
                        MachineHeadPH11(icol, irow, 0, arg_dt, arg_grid);
                        irow++;
                    }
                }
                for (int i = 0; i < arg_dt.Columns.Count; i++)
                {
                    if ((i + 1) % 6 == 0)
                    {
                        icol += 6;
                        axGrid.set_ColWidth(icol, 5);
                        icol++;
                    }
                }
                //Line Total
                //if (arg_dt.Rows[0]["ZONE_CD"].ToString() == "001")
                //{
                //    MachineLineTotal2(icol, irow2, irow, arg_grid);
                //}
                //if (arg_dt.Rows[0]["ZONE_CD"].ToString() == "003")
                //{
                //    MachineLineTotal2(icol, irow3, irow, arg_grid);
                //}
                //if (arg_dt.Rows[0]["ZONE_CD"].ToString() == "004")
                //{
                //    MachineLineTotal2(icol, irow5, irow, arg_grid);
                //}

                axGrid.Visible = false;
                //   axGridDetail2.Visible = false;
              //  WarehouseMaterialSystem.ClassLib.WinAPI.AnimateWindow(this.axGrid.Handle, 400, WarehouseMaterialSystem.ClassLib.WinAPI.getSlidType("5"));
                axGrid.Visible = true;
                axGrid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsVertical;

                lbl_Plan.Text = "Total Mold: " + Convert.ToInt32(arg_dt.Compute("Sum(MOLD)", "")).ToString("###,###");
                lbl_Actual.Text = "Total Input: " + Convert.ToInt32(arg_dt.Compute("Sum(INPUT)", "")).ToString("###,###");
                double d;
                int x = Convert.ToInt32(arg_dt.Compute("Sum(MOLD)", ""));
                int y = Convert.ToInt32(arg_dt.Compute("Sum(INPUT)", ""));
                d = (float)x - y;
                lblbalace.Text = "Total Balance: " + d.ToString("###,###");
                // if (_Loc_yellow.Count > 0) tmr_blind.Start();
                // else tmr_blind.Stop();
                //////////////////////////////////////////////

            }
            catch
            {
            }
        }

        private void MachineBodyPH1(int arg_icol, int arg_irow, int arg_irow1, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            {
                //arg_grid.SetCellBorder(arg_icol + 3, arg_irow, arg_icol + 5, arg_irow1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol + 4, arg_irow1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                arg_grid.SetCellBorder(arg_icol, arg_irow, arg_icol + 3, arg_irow1, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                arg_grid.set_RowHeight(arg_irow, 20);


                arg_grid.Col = arg_icol;
                arg_grid.Row = arg_irow;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MACHINE"].ToString();
                arg_grid.FontBold = true;
                arg_grid.BackColor = Color.LightGray;

                arg_grid.Col = arg_icol + 1;
                arg_grid.Text = arg_dt.Rows[arg_idt]["MOLD"].ToString();               

                arg_grid.Col = arg_icol + 2;
                arg_grid.Text = arg_dt.Rows[arg_idt]["INPUT"].ToString();   

                arg_grid.Col = arg_icol + 3;
                arg_grid.Text = arg_dt.Rows[arg_idt]["BALANCE"].ToString();               

            }
            catch (Exception)
            { }

        }

        private void MachineHeadPH11(int arg_icol, int arg_irow, int arg_idt, DataTable arg_dt, AxFPSpreadADO.AxfpSpread arg_grid)
        {
            try
            { 
                arg_grid.Row = arg_irow;
                arg_grid.Col = arg_icol;
                arg_grid.Text = "Machine";
                arg_grid.BackColor = Color.DodgerBlue;
                arg_grid.ForeColor = Color.White;              
                arg_grid.FontSize = 14;
                arg_grid.FontBold = true;
                arg_grid.set_ColWidth(arg_icol, 10.0);

                arg_grid.Col = arg_icol + 1;
                arg_grid.Text = "Mold";
                arg_grid.BackColor = Color.DodgerBlue;
                arg_grid.ForeColor = Color.White;  
                arg_grid.FontSize = 14;
                arg_grid.FontBold = true;

                arg_grid.Col = arg_icol + 2;
                arg_grid.Text = "Input";
                arg_grid.BackColor = Color.DodgerBlue;
                arg_grid.ForeColor = Color.White;  
                arg_grid.FontSize = 14;
                arg_grid.FontBold = true;

                arg_grid.Col = arg_icol + 3;
                arg_grid.Text = "Balance";
                arg_grid.BackColor = Color.DodgerBlue;
                arg_grid.ForeColor = Color.White;  
                arg_grid.FontSize = 14;
                arg_grid.FontBold = true;

            }
            catch
            { }
        }



        private void create_default2()
        {
            try
            {
                int iRowHeight, iFontSize;
                double iColWidth;
                
                iRowHeight = 40;
                iColWidth = 12.5;
                iFontSize = 16;

                
                axGrid.Reset();
                axGrid.GrayAreaBackColor = Color.White;
                axGrid.DisplayColHeaders = false;
                axGrid.DisplayRowHeaders = false;
                axGrid.ActiveCellHighlightStyle = FPSpreadADO.ActiveCellHighlightStyleConstants.ActiveCellHighlightStyleOff;
                axGrid.ColHeaderRows = 0;
                //if (_status=="PH3")
                //    axGrid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsVertical;
                //else
                //axGrid.ScrollBars = FPSpreadADO.ScrollBarsConstants.ScrollBarsVertical;
                axGrid.Font = new System.Drawing.Font("Calibri", iFontSize);
                axGrid.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleNone;

                // axGrid.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleNone;
                axGrid.set_RowHeight(1, 10);
                //axGrid.set_RowHeight(20, 9);
                //axGrid.set_ColWidth((int)G.S1_Blank, 5.37);
                axGrid.set_ColWidth(1, 3);
                //axGrid.set_ColWidth((int)G.S3_Blank, 5.37);
                //axGrid.set_ColWidth((int)G.Blank1, 13.62);
                //axGrid.set_ColWidth((int)G.Blank2, 13.62);
                axGrid.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                axGrid.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                axGrid.SetCellBorder(1, 1, 150, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                axGrid.SetCellBorder(1, 1, 150, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                //  axGrid.SetCellBorder((int)G.S1_M1_L_Plan, 1, (int)G.S3_M2_R_Act, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                
                //  axGrid.SetCellBorder((int)G.S1_M1_L_Tar, 1, (int)G.S3_M2_R_Cur, axGrid.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexOutline, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);


                for (int irow = 0; irow <= 50; irow++)
                {
                    axGrid.set_RowHeight(irow, iRowHeight);
                    irow++;
                }     

                    for (int icol = 2; icol <= 150; icol++)
                        axGrid.set_ColWidth(icol, iColWidth);                  
                
            }
            catch (Exception)
            { }
        }

        private void gvwviewMachine_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (gvwviewMachine.GetRowCellValue(e.RowHandle, "MACHINE_NAME").ToString().Equals("TOTAL"))
            //{
            //    e.Appearance.BackColor = Color.Lime;
            //    e.Appearance.ForeColor = Color.Black;
            //}
        }

        private void bandedGridModel_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (bandedGridModel.GetRowCellValue(e.RowHandle, "SHORT_NAME").ToString().Equals("TOTAL"))
            //{
            //    e.Appearance.BackColor = Color.Lime;
            //    e.Appearance.ForeColor = Color.Black;
            //}
        }

        private void bandedGridModel_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (keysForValues.Length > 0)
            {
                for (int i = 0; i < keysForValues.Length; i++)
                {
                    string[] str = keysForValues[i].ToString().Split('-');
                    axGrid.Row = Convert.ToInt32(str[0]);
                    if (_status == "CMP")
                    {
                        axGrid.Col = Convert.ToInt32(str[1]) + 1;
                    }
                    else
                        axGrid.Col = Convert.ToInt32(str[1]) - 1;

                    axGrid.BackColor = Color.FromArgb(0, 255, 0);
                    axGrid.ForeColor = Color.Black;

                }
            }
            //DisplayGridTop(dtLayout, axGridTop);

            string Name = bandedGridModel.GetRowCellValue(bandedGridModel.FocusedRowHandle, "SHORT_NAME").ToString();

            keysForValues = _Dic_Location.Where(pair => pair.Value.Equals(Name))
                          .Select(pair => pair.Key).ToArray();
            //loaddata();

            for (int i = 0; i < keysForValues.Length; i++)
            {
                string[] str = keysForValues[i].ToString().Split('-');

                axGrid.Row = Convert.ToInt32(str[0]);
                if (_status == "CMP")
                {
                    axGrid.Col = Convert.ToInt32(str[1]) + 1;
                }
                else
                    axGrid.Col = Convert.ToInt32(str[1]) - 1;
                axGrid.BackColor = Color.DarkOrange;
                axGrid.ForeColor = Color.White;
            }

            //e.CellValue.BackColor = Color.Lime;
            //e.Appearance.ForeColor = Color.Black;

            _time = 0;
        }

        private void LoadShift()
        {
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
        }

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
                    
                    if (!_load_form)
                    {
          
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
            if (_load_form) return;
            loaddata(true);
            _time = 0;
        }










    }
}
