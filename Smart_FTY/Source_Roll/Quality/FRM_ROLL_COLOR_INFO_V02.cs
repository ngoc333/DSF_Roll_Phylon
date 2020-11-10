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
    public partial class FRM_ROLL_COLOR_INFO_V02 : SampleFrm1
    {
        public FRM_ROLL_COLOR_INFO_V02()
        {
            InitializeComponent();
        }

        int cnt = 0;
        string str_op = "";
        static int iTotal = 32;
        int currentPage = 1;
        int currentCode = 0;
        int iMaxPage = 10;
        ClassLib.GroupBoxEx[] array = new ClassLib.GroupBoxEx[iTotal];
        string[] array_L = new string[iTotal];

        private void FRM_ROLL_COLOR_INFO_V02_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            cmdDay.Visible = false;
            cmdMonth.Visible = false;
            cmdYear.Visible = false;
            innitColorArray();
            BindingCombo_MCS();
            BindingCombo_MODEL();
            BindingCombo_STYLE();
            BindingCombo_COLOR();
            BindingData(currentPage);
            lblPage.Text = "Page " + currentPage.ToString() + " / " + iMaxPage.ToString();



        }
        private void BindingCombo_MCS()
        {
            cboMCS.DataSource = SELECT_ROLL_COLOR_SETCBO_MCS("OR");
            cboMCS.ValueMember = "CODE";
            cboMCS.DisplayMember = "NAME";
        }
        private void BindingCombo_STYLE()
        {
            string model = cboModel.SelectedValue.ToString();
            cboStyle.DataSource = SELECT_ROLL_COLOR_SET_CBOSTYLE(model);
            cboStyle.ValueMember = "CODE";
            cboStyle.DisplayMember = "NAME";
        }

        private void BindingCombo_MODEL()
        {
            cboModel.DataSource = SELECT_ROLL_COLOR_SET_CBOMODEL("Q");
            cboModel.ValueMember = "CODE";
            cboModel.DisplayMember = "NAME";
        }
        private void BindingCombo_COLOR()
        {
            cboColor.DataSource = SELECT_ROLL_COLOR_SET_CBOCOLOR("Q");
            cboColor.ValueMember = "CODE";
            cboColor.DisplayMember = "NAME";
        }

        public DataTable SELECT_ROLL_COLOR_SETCBO_MCS(string TYPE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_ROLL.SELECT_ROLL_COLOR_SET_CBOMCS";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                //MyOraDB.Parameter_Name[2] = "OUT_CURSOR1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                //MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = TYPE;
                MyOraDB.Parameter_Values[1] = "";
                //MyOraDB.Parameter_Values[2] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[0];

            }
            catch
            {
                return null;
            }
        }
        public DataTable SELECT_ROLL_COLOR_SET_CBOSTYLE(string TYPE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_ROLL.SELECT_ROLL_COLOR_SET_CBOSTYLE";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_MODEL";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                //MyOraDB.Parameter_Name[2] = "OUT_CURSOR1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                //MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = TYPE;
                MyOraDB.Parameter_Values[1] = "";
                //MyOraDB.Parameter_Values[2] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[0];

            }
            catch
            {
                return null;
            }
        }
        public DataTable SELECT_ROLL_COLOR_SET_CBOMODEL(string TYPE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_ROLL.SELECT_ROLL_COLOR_SET_CBOMODEL";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                //MyOraDB.Parameter_Name[2] = "OUT_CURSOR1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                //MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = TYPE;
                MyOraDB.Parameter_Values[1] = "";
                //MyOraDB.Parameter_Values[2] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[0];

            }
            catch
            {
                return null;
            }
        }
        public DataTable SELECT_ROLL_COLOR_SET_CBOCOLOR(string TYPE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_ROLL.SELECT_ROLL_COLOR_SET_CBOCOLOR";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                //MyOraDB.Parameter_Name[2] = "OUT_CURSOR1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                //MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = TYPE;
                MyOraDB.Parameter_Values[1] = "";
                //MyOraDB.Parameter_Values[2] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[0];

            }
            catch
            {
                return null;
            }
        }

        public DataSet SELECT_ROLL_COLOR_INFO(string mcs, string style, string color)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_ROLL.SELECT_ROLL_COLOR_INFO_1"; //SP_SMT_ANDON_DAILY

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_MCS";
                MyOraDB.Parameter_Name[1] = "ARG_STYLE";
                MyOraDB.Parameter_Name[2] = "ARG_COLOR";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = mcs;
                MyOraDB.Parameter_Values[1] = style;
                MyOraDB.Parameter_Values[2] = color;
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";

                //MyOraDB.Add_Select_Parameter(true);
                //ds_ret = MyOraDB.Exe_Select_Procedure();


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



        private void BindingData(int _page)
        {
            //DataSet ds = SELECT_ROLL_COLOR_INFO((currentCode).ToString().PadLeft(2,'0'));
            if (cboMCS.Text =="" ) return;
            string strMCS = cboMCS.SelectedValue.ToString();
            if (cboStyle.Text== "") return;
            string strStyle = cboStyle.SelectedValue.ToString();
            if (cboColor.Text == "") return;
            string strColor = cboColor.SelectedValue.ToString();

            DataSet ds = SELECT_ROLL_COLOR_INFO(strMCS, strStyle, strColor);
            //DataSet ds = SELECT_ROLL_COLOR_INFO("", "", "");
            if (ds == null)
                return;
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            if (dt != null)
            {
                iMaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)dt.Rows.Count / (double)iTotal)));
                if (dt.Rows.Count <= iTotal)
                {

                    setColorArray(dt, dt1, 0, dt.Rows.Count, 1);

                }

                if (dt.Rows.Count > (_page - 1) * iTotal)
                {
                    if (dt.Rows.Count - (_page - 1) * iTotal < iTotal)
                    {
                        setColorArray(dt, dt1, (_page - 1) * iTotal, dt.Rows.Count, _page);
                    }
                    else
                    {
                        setColorArray(dt, dt1, (_page - 1) * iTotal, _page * iTotal, _page);
                    }
                }


            }
        }
        private void setColorArray(DataTable _dt, DataTable _dtDetail, int _indexFrom, int _indexTo, int _page)
        {
            Label[] label = new Label[] { lblColor1, lblColor2, lblColor3, lblColor4, lblColor5, lblColor6, lblColor7, lblColor8, lblColor9, lblColor10, lblColor11, lblColor12, lblColor13, lblColor14, lblColor15, lblColor16, lblColor17, lblColor18, lblColor19, lblColor20, lblColor21, lblColor22, lblColor23, lblColor24, lblColor25, lblColor26, lblColor27, lblColor28, lblColor29, lblColor30, lblColor31, lblColor32 };
            lblColor1.Text = "";
            lblColor2.Text = "";
            lblColor3.Text = "";
            lblColor4.Text = "";
            lblColor5.Text = "";
            lblColor6.Text = "";
            lblColor7.Text = "";
            lblColor8.Text = "";
            lblColor9.Text = "";
            lblColor10.Text = "";
            lblColor11.Text = "";
            lblColor12.Text = "";
            lblColor13.Text = "";
            lblColor14.Text = "";
            lblColor15.Text = "";
            lblColor16.Text = "";
            lblColor17.Text = "";
            lblColor18.Text = "";
            lblColor19.Text = "";
            lblColor20.Text = "";
            lblColor21.Text = "";
            lblColor22.Text = "";
            lblColor23.Text = "";
            lblColor24.Text = "";
            lblColor25.Text = "";
            lblColor26.Text = "";
            lblColor27.Text = "";

            lblColor28.Text = "";
            lblColor29.Text = "";
            lblColor30.Text = "";
            lblColor31.Text = "";
            lblColor32.Text = "";

            for (int index = 0; index < iTotal; index++)
            {
                
                array[index].Text = "";
                if (array[index].HasChildren)
                {
                    System.Windows.Forms.DataGridView grdiview = (System.Windows.Forms.DataGridView)array[index].Controls[0];
                    grdiview.RowCount = 1;
                    grdiview.Rows[0].Cells[0].Value = "";
                    grdiview.Rows[0].Cells[1].Value = "";
                }
            }
            for (int index = _indexFrom; index < _indexTo; index++)
            {
                //_dt.Rows[index]["STYLE_NAME"].ToString() + "\n" + _dt.Rows[index]["STYLE_CD"].ToString() + "\n" + _dt.Rows[index]["MCS_CD"].ToString() + "\n" + _dt.Rows[index]["COLOR_NAME"].ToString();
                array[index - (_page - 1) * iTotal].Text = _dt.Rows[index]["MCS_CD"].ToString() + "-" + _dt.Rows[index]["COLOR_NAME"].ToString();
              //  if (index <= 1)
                label[index - (_page - 1) * iTotal].Text = _dt.Rows[index]["STYLE_NAME"].ToString() + "\n" + _dt.Rows[index]["STYLE_CD"].ToString();

                array[index - (_page - 1) * iTotal].Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                int iColorRed = 255, iColorGreen = 255, iColorBlue = 255;
                int.TryParse(_dt.Rows[index]["COLOR_RED"].ToString(), out iColorRed);
                int.TryParse(_dt.Rows[index]["COLOR_GREEN"].ToString(), out iColorGreen);
                int.TryParse(_dt.Rows[index]["COLOR_BLUE"].ToString(), out iColorBlue);

                int iTextColorRed = 0, iTextColorGreen = 0, iTextColorBlue = 0;
                int.TryParse(_dt.Rows[index]["TEXT_COLOR_RED"].ToString(), out iTextColorRed);
                int.TryParse(_dt.Rows[index]["TEXT_COLOR_GREEN"].ToString(), out iTextColorGreen);
                int.TryParse(_dt.Rows[index]["TEXT_COLOR_BLUE"].ToString(), out iTextColorBlue);

                array[index - (_page - 1) * iTotal].TextBackColor = Color.FromArgb(iColorRed, iColorGreen, iColorBlue);
                array[index - (_page - 1) * iTotal].ForeColor = Color.FromArgb(iTextColorRed, iTextColorGreen, iTextColorBlue);


                if (array[index - (_page - 1) * iTotal].HasChildren)
                {
                    System.Windows.Forms.DataGridView grdiview = (System.Windows.Forms.DataGridView)array[index - (_page - 1) * iTotal].Controls[0];

                    grdiview.RowCount = 1;
                    DataRow[] tmpDT = _dtDetail.Select("COLOR_CD ='" + _dt.Rows[index]["COLOR_CD"].ToString() + "'", " CHEMICAL_NAME ASC");
                    if (tmpDT.Length > 0)
                    {
                        grdiview.RowCount = tmpDT.Length + 1;

                    }
                    for (int i = 0; i < tmpDT.Length; i++)
                    {
                        grdiview.Rows[i].Cells[0].Value = tmpDT[i]["CHEMICAL_NAME"].ToString();
                        grdiview.Rows[i].Cells[1].Value = tmpDT[i]["WEIGHT"].ToString();
                        grdiview.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                        grdiview.Rows[i].Cells[1].Style.ForeColor = Color.Black;


                    }

                    grdiview.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    grdiview.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdiview.Columns[0].Width = 155;
                    grdiview.Columns[1].Width = 60;
                    grdiview.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    grdiview.AllowUserToAddRows = false;
                    grdiview.ScrollBars = ScrollBars.Vertical;
                    grdiview.ClearSelection();
                    grdiview.CurrentCell = null;
                }

            }


        }
        private void innitColorArray()
        {

            array[0] = groupBoxEx1;
            array[1] = groupBoxEx2;
            array[2] = groupBoxEx3;
            array[3] = groupBoxEx4;
            array[4] = groupBoxEx5;
            array[5] = groupBoxEx6;
            array[6] = groupBoxEx7;
            array[7] = groupBoxEx8;
            array[8] = groupBoxEx9;
            array[9] = groupBoxEx10;

            array[10] = groupBoxEx11;
            array[11] = groupBoxEx12;
            array[12] = groupBoxEx13;
            array[13] = groupBoxEx14;
            array[14] = groupBoxEx15;
            array[15] = groupBoxEx16;
            array[16] = groupBoxEx17;
            array[17] = groupBoxEx18;
            array[18] = groupBoxEx19;
            array[19] = groupBoxEx20;

            array[20] = groupBoxEx21;
            array[21] = groupBoxEx22;
            array[22] = groupBoxEx23;
            array[23] = groupBoxEx24;
            array[24] = groupBoxEx25;
            array[25] = groupBoxEx26;
            array[26] = groupBoxEx27;
            array[27] = groupBoxEx28;
            array[28] = groupBoxEx29;
            array[29] = groupBoxEx30;

            array[30] = groupBoxEx31;
            array[31] = groupBoxEx32;

            for (int i = 0; i < iTotal; i++)
            {
                array[i].Text = "";
            }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cnt < 40)
            {
                cnt++;
            }
            else
            {
                cnt = 0;
                BindingData(currentPage);

            }
        }

        private void FRM_ROLL_COLOR_INFO_V02_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {

                    timer1.Start();
                    cnt = 0;
                }
                else
                    timer1.Stop();
            }
            catch
            {

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                BindingData(currentPage);
                lblPage.Text = "Page " + currentPage.ToString() + " / " + iMaxPage.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < iMaxPage)
            {
                currentPage++;
                BindingData(currentPage);
                lblPage.Text = "Page " + currentPage.ToString() + " / " + iMaxPage.ToString();
            }
        }

        private void btnPrevCode_Click(object sender, EventArgs e)
        {
            if (currentCode > 0)
            {
                currentCode--;
                lblCode.Text = "Code " + currentCode.ToString();
                currentPage = 1;
                BindingData(currentPage);
                lblPage.Text = "Page " + currentPage.ToString() + " / " + iMaxPage.ToString();
            }
        }

        private void btnNextCode_Click(object sender, EventArgs e)
        {
            if (currentCode < 10)
            {
                currentCode++;
                lblCode.Text = "Code " + currentCode.ToString();
                currentPage = 1;

                BindingData(currentPage);
                lblPage.Text = "Page " + currentPage.ToString() + " / " + iMaxPage.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingData(currentPage);
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingCombo_STYLE();
       
        }


    }
}
