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
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
//using ChartDirector;
using System.Threading;
//using IPEX_Monitor.ClassLib;


namespace Smart_FTY
{

    

    public partial class FORM_SMT_PU_LEADTIME : Form
    {
        public FORM_SMT_PU_LEADTIME()
        {
            InitializeComponent();
           
        }


        #region Init

        public int _time = 0, _timeReload = 40;

        #endregion Init

        #region Function

       
        
        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        public void loaddata()
        {
            try
            {
                double dWH = 0, dISO = 0;
                //Control cntrl;
                //cntrl = this.Controls.Find("ctrEVA4", true).FirstOrDefault();
                //cntrl.Text = "inspection\n10'"; 
                DataTable dt = SEL_PU_LEAD_TIME();
                 
                dWH = double.Parse( dt.Rows[0][1].ToString())  +  double.Parse(dt.Rows[1][1].ToString());
                dISO = double.Parse(dt.Rows[0][3].ToString()) + double.Parse(dt.Rows[1][3].ToString());

                if (dt != null)
                {
                    lblWH.Text = dt.Rows[0][0].ToString() + "   " + dt.Rows[1][0].ToString() + "   =>" + dWH.ToString();
                    lblISO.Text = dt.Rows[0][2].ToString() + "   " + dt.Rows[1][2].ToString() + "   =>" + dISO.ToString();

                    lblSG_INV.Text = dt.Rows[2][4].ToString();

                    lblWH_LT.Text = dWH.ToString();
                    lblISO_LT.Text = dISO.ToString();

                    btn_Tot_leadTime.Text = (dISO + dWH + 0.24 + double.Parse(dt.Rows[2][4].ToString().Substring(dt.Rows[2][4].ToString().IndexOf("=>") + 3).Replace(" days", ""))).ToString();

                    btnTotal_LeadTime.Text = btn_Tot_leadTime.Text;

                    lblSG_LT.Text = dt.Rows[2][4].ToString().Substring(dt.Rows[2][4].ToString().IndexOf("=>") + 3).Replace(" days", "");


                    lbl_daily_plan.Text ="Daily Plan: " + int.Parse(dt.Rows[2][3].ToString()).ToString("0,##0") + " Prs" ;
                }
                
            }
            catch
            { }
            finally
            {
            }
        }

        private void lineArrow_Paint(object sender, PaintEventArgs e)
        {
            LineShape line = (LineShape)sender;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
            pen.StartCap = LineCap.ArrowAnchor;
            pen.EndCap = LineCap.NoAnchor;
            e.Graphics.DrawLine(pen, line.EndPoint, line.StartPoint);
        }
    

        #endregion Fuction

        #region DB

        public DataTable SEL_PU_LEAD_TIME()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PU.SELECT_PU_LEADTIME";

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            Smart_FTY.ComVar._frm_home_phylon.Show();
            this.Hide();
        }

        private void customControlShape35_Click(object sender, EventArgs e)
        {
        }

        private void button57_Click(object sender, EventArgs e)
        {

        }

        private void customControlShape108_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        public void Frm_Load(object sender, EventArgs e)
        {
            GoFullscreen();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd")) + "\n\r" + string.Format(DateTime.Now.ToString("HH:mm:ss"));
                _time++;
                if (_time >= _timeReload)
                {
                    loaddata();                    
                    _time = 0;
                }
            }
            catch
            {}
        }


        private void Frm_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    _time = _timeReload -1;
                     timer1.Start();       
                }
                else
                {    
                    timer1.Stop();
                }              
            }
            catch 
            {}
        }

        
        
        #endregion Event

       







    }
}
