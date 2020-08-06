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
    public partial class FRM_ROLL_COLOR_INFO : SampleFrm1
    {
        public FRM_ROLL_COLOR_INFO()
        {
            InitializeComponent();
        }

        int cnt = 0;
        string str_op = "";
        static int  iTotal = 32;
        int currentPage = 1;
        int currentCode = 0;
        int iMaxPage = 10;
        ClassLib.GroupBoxEx[] array = new ClassLib.GroupBoxEx[iTotal];

        private void FRM_ROLL_COLOR_INFO_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            cmdDay.Visible = false;
            cmdMonth.Visible = false;
            cmdYear.Visible = false;
            innitColorArray();
          
            BindingData(currentPage);
            lblPage.Text = currentPage.ToString() + " / " + iMaxPage.ToString();
        }

        public DataSet SELECT_ROLL_COLOR_INFO(string _code)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_ROLL.SELECT_ROLL_COLOR_INFO"; //SP_SMT_ANDON_DAILY

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_CODE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR1";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = _code;
                MyOraDB.Parameter_Values[1] = "";
                MyOraDB.Parameter_Values[2] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();


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
            DataSet ds = SELECT_ROLL_COLOR_INFO((currentCode).ToString().PadLeft(2,'0'));
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            if (dt != null)
            {
                iMaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)dt.Rows.Count / (double)iTotal)));
                if (dt.Rows.Count <= iTotal)
                {

                    setColorArray(dt,dt1, 0, dt.Rows.Count, 1);
                   
                } 
                
                if (dt.Rows.Count >  (_page-1) * iTotal)
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
            for (int index = 0 ; index < iTotal; index++)
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
                array[index - (_page -1 )*iTotal].Text = _dt.Rows[index]["COLOR_NAME"].ToString();
                array[index - (_page - 1) * iTotal].Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                if (array[index - (_page - 1) * iTotal].HasChildren)
                {
                    System.Windows.Forms.DataGridView grdiview = (System.Windows.Forms.DataGridView)array[index - (_page - 1) * iTotal].Controls[0];
                    
                    grdiview.RowCount = 1;
                    DataRow[] tmpDT = _dtDetail.Select("COLOR_CD ='" + _dt.Rows[index]["COLOR_CD"].ToString() + "'", " CHEMICAL_NAME ASC");
                    if (tmpDT.Length > 0)
                    {
                        grdiview.RowCount = tmpDT.Length+1;

                    }
                    for (int i = 0; i < tmpDT.Length; i++)
                    {
                        grdiview.Rows[i].Cells[0].Value=tmpDT[i]["CHEMICAL_NAME"].ToString();
                        grdiview.Rows[i].Cells[1].Value = tmpDT[i]["WEIGHT"].ToString();
                        //grdiview.Rows.Add(tmpDT[i]["CHEMICAL_NAME"].ToString(), tmpDT[i]["WEIGHT"].ToString());
                        
                    }
                   // grdiview.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdiview.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    grdiview.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdiview.Columns[0].Width = 155;
                    grdiview.Columns[1].Width = 60;
                    grdiview.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    grdiview.AllowUserToAddRows = false;
                    grdiview.ScrollBars = ScrollBars.Vertical;
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

        private void FRM_ROLL_COLOR_INFO_VisibleChanged(object sender, EventArgs e)
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
                lblPage.Text = currentPage.ToString() + " / " + iMaxPage.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < iMaxPage)
            {
                currentPage ++;                
                BindingData(currentPage);
                lblPage.Text = currentPage.ToString() + " / " + iMaxPage.ToString();
            }
        }

        private void btnPrevCode_Click(object sender, EventArgs e)
        {
            if (currentCode > 0)
            {
                currentCode--;
                lblCode.Text = "C " + currentCode.ToString();
                currentPage = 1;                
                BindingData(currentPage);
                lblPage.Text = currentPage.ToString() + " / " + iMaxPage.ToString();
            }
        }

        private void btnNextCode_Click(object sender, EventArgs e)
        {
            if (currentCode < 10)
            {
                currentCode++;
                lblCode.Text = "C " + currentCode.ToString();
                currentPage = 1;
                
                BindingData(currentPage);
                lblPage.Text = currentPage.ToString() + " / " + iMaxPage.ToString();
            }
        }
                
        
    }
}
