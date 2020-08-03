﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using JPlatform.Client.Controls;


namespace Smart_FTY
{
    public partial class FRM_PH_OSD_EXT_YEAR : Form_Parent
    {
        public FRM_PH_OSD_EXT_YEAR()
        {
            InitializeComponent();
            lblTitle.Text = "Phylon OS&&D by Year";
        }

        int cnt = 0;
        string str_op = "";
        public delegate void MenuHandler();
        public MenuHandler OnClick = null;
        FRM_PH_ANALYSIS FRMANA = new FRM_PH_ANALYSIS();

        private void FRM_ROLL_SLABTEST_MON_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            //cmdDay.Visible = false;
        }

        public DataTable SEL_DATA_SLABTEST(string Qtype, string arg_ymd, string arg_op)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_B1.SP_PH_OSD_YEAR_V2"; //SP_SMT_ANDON_DAILY

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

        private void formatband()
        {
            try
            {
                int n;
                DataTable dtsource = null;
                dtsource = SEL_DATA_SLABTEST("H", uc_year.GetValue().ToString(), "");
                if (dtsource != null && dtsource.Rows.Count > 0)
                {
                    string name;
                    //bandYear.Caption = dtsource.Rows[0]["MON"].ToString();
                    if (dtsource.Rows.Count > 0)
                    {
                        foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in gvwView.Bands[1].Children)
                        {
                            double num;
                            if (double.TryParse(band.Caption, out num))
                            {
                                for (int i = 0; i < dtsource.Rows.Count; i++)
                                {
                                    if (band.Name.Contains(dtsource.Rows[i][0].ToString().Substring(dtsource.Rows[i][0].ToString().Length - 2)))
                                    {
                                        band.Visible = true;
                                        break;
                                    }
                                    if (i == dtsource.Rows.Count - 1)
                                    {
                                        band.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void BindingData(string arg_op)
        {
            grdView.Refresh();
            DataTable dtsource = null;
            dtsource = SEL_DATA_SLABTEST("Q", uc_year.GetValue().ToString(), arg_op);
            //formatband();
            grdView.DataSource = dtsource;
            if (dtsource != null && dtsource.Rows.Count > 0)
            {

                bandYear.Caption = dtsource.Rows[0]["YYYY"].ToString();
                for (int i = 0; i < gvwView.Columns.Count; i++)
                {
                    gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                    gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                    gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                    gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 14, FontStyle.Bold);
                    
                }
            }
        }

        private void bindingdatachart(string arg_op)
        {
            try
            {
                DataTable dt = null;
                dt = SEL_DATA_SLABTEST("C", uc_year.GetValue().ToString(), arg_op);
                chartSlabtest.DataSource = dt;
                chartSlabtest.Series[0].ArgumentDataMember = "YMD";
                chartSlabtest.Series[0].ValueDataMembers.AddRange(new string[] { "OSD1" });
                chartSlabtest.Series[1].ArgumentDataMember = "YMD";
                chartSlabtest.Series[1].ValueDataMembers.AddRange(new string[] { "OSD2" });
                chartSlabtest.Series[2].ArgumentDataMember = "YMD";
                chartSlabtest.Series[2].ValueDataMembers.AddRange(new string[] { "RATE" });
            }
            catch
            {
            }
            //chartSlabtest.
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.ColumnHandle == 2)
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
                if (Form_Home_Phylon._type == "CMP")
                    lblCMP_Click(null, null);
                else
                    lblPhylon_Click(null, null);
                //    BindingData(str_op);
                //bindingdatachart(str_op);                
            }
        }

        private void FRM_ROLL_SLABTEST_MON_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    BindingData("PHP");
                    bindingdatachart("PHP");
                    str_op = "PHP";
                    
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

        private void lblCMP_Click(object sender, EventArgs e)
        {

            BindingData("CMP");
            bindingdatachart("CMP");
            str_op = "CMP";
            lblTitle.Text = "CMP OS&&D by Year";
            Form_Home_Phylon._type = "CMP";
        }

        private void lblPhylon_Click(object sender, EventArgs e)
        {
            BindingData("PHP");
            bindingdatachart("PHP");
            str_op = "PHP";
            lblTitle.Text = "Phylon OS&&D by Year";
            Form_Home_Phylon._type = "CMP";
        }

        private void uc_year_ValueChangeEvent(object sender, EventArgs e)
        {
            try
            {
                cnt = 0;
                if (Form_Home_Phylon._type == "CMP")
                    lblCMP_Click(null, null);
                else
                    lblPhylon_Click(null, null);
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRMANA.Show();
        }

       
    }
}
