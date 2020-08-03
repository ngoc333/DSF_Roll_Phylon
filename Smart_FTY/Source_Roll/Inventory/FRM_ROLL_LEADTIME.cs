using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing.Drawing2D;
//using JPlatform.Client.Controls;


namespace Smart_FTY
{
    public partial class FRM_ROLL_LEADTIME : Form
    {
        public FRM_ROLL_LEADTIME()
        {
            InitializeComponent();
        }

        int cnt = 0, line_width = 5;
        string str_op = "";

        private void FRM_ROLL_SLABTEST_MON_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
           // pnButton.Visible = false;
            lblTitle.Text = "Roll Lead Time";
        }

        public DataTable SEL_DATA_ROLL_LT(string Qtype, string arg_op)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_ROLL.SP_ROLL_LT"; //SP_SMT_ANDON_DAILY

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_OP";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = arg_op;
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

        

        private void BindingData_OSR(string arg_op)
        {
            
            DataTable dt = null;
            dt = SEL_DATA_ROLL_LT("Q", arg_op);
            Control cntrl;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cntrl = this.Controls.Find(dt.Rows[i]["DIV"].ToString(), true).FirstOrDefault();
                    if (cntrl != null)
                    {
                        cntrl.Text = dt.Rows[i]["VAL1"].ToString();

                        //switch (dt.Rows[i]["COLOR"].ToString())
                        //{
                        //    case "RED":
                        //        cntrl.ForeColor = Color.Red;
                        //        break;
                        //    case "BLACK":
                        //        cntrl.ForeColor = Color.Black;
                        //        break;
                        //    case "YELLOW":
                        //        cntrl.ForeColor = Color.Yellow;
                        //        break;
                        //    default:
                        //        cntrl.ForeColor = Color.Black;
                        //        break;
                        //}
                        cntrl = this.Controls.Find(dt.Rows[i]["DIV"].ToString() + "_1", true).FirstOrDefault();
                        if (dt.Rows[i]["VAL1"].ToString().IndexOf("'") > 0)
                        {
                            cntrl.Text = dt.Rows[i]["VAL1"].ToString().Replace("'", "") + " min";
                        }
                        else
                        {
                            cntrl.Text = dt.Rows[i]["VAL1"].ToString();
                        }
                    }

                }
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
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cnt < 40)
            {
                cnt++;                
            }
            else
            {
                cnt = 0;
                BindingData_OSR("OSR");
                BindingData_OSR("EVA");
            }
        }

        private void FRM_ROLL_SLABTEST_MON_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {                    
                    timer1.Start();
                    cnt = 0;
                    BindingData_OSR("OSR");
                    BindingData_OSR("EVA");
                }
                else
                    timer1.Stop();
            }
            catch
            {

            }
        }

        private void lineShape1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphicsObject = e.Graphics;
            LineShape line = (LineShape)sender;
            Pen pen = new Pen(Color.Black, line_width);



            //Pen pen = new Pen (new System.Drawing.Drawing2D.LinearGradientBrush(line.StartPoint,line.EndPoint,Color.Red,Color.Green),5);
            pen.StartCap = LineCap.ArrowAnchor;
            pen.EndCap = LineCap.NoAnchor;
            e.Graphics.DrawLine(pen, line.EndPoint, line.StartPoint);
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmdDay_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["FORM_SMT_PH_LEADTIME"];
            if (fc != null)
            {

                fc.Show();
                this.Hide();
            }
            else
            {
                FORM_SMT_PH_LEADTIME f = new FORM_SMT_PH_LEADTIME();
                f.Show();
                this.Hide();
            }
        }

        private void cmdWeek_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["FORM_SMT_ROLL_LEADTIME_WEEK"];
            if (fc != null)
            {

                fc.Show();
                this.Hide();
            }
            else
            {
                FORM_SMT_ROLL_LEADTIME_WEEK f = new FORM_SMT_ROLL_LEADTIME_WEEK();
                f.Show();
                this.Hide();
            }
        }

        private void cmdYear_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["FORM_SMT_ROLL_LEADTIME_YEAR"];
            if (fc != null)
            {

                fc.Show();
                this.Hide();
            }
            else
            {
                FORM_SMT_ROLL_LEADTIME_YEAR f = new FORM_SMT_ROLL_LEADTIME_YEAR();
                f.Show();
                this.Hide();
            }
        }

        private void cmdMonth_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["FORM_SMT_ROLL_LEADTIME_MONTH"];
            if (fc != null)
            {

                fc.Show();
                this.Hide();
            }
            else
            {
                FORM_SMT_ROLL_LEADTIME_MONTH f = new FORM_SMT_ROLL_LEADTIME_MONTH();
                f.Show();
                this.Hide();
            }
        }
    }
}
