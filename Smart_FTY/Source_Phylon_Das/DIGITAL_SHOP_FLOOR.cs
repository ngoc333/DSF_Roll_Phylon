using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.OracleClient;
using System.Collections;
namespace Smart_FTY
{
    public partial class DIGITAL_SHOP_FLOOR : Form
    {
        public DIGITAL_SHOP_FLOOR()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnon);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); 
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(IntPtr ZeroOnly, string lpWindowName);

        #region UserControl
        
        #endregion
        #region Variable
        int cCount = 0; 
        FORM_SMT_B_MOLD_LAYOUT _frmMoldLayout = new FORM_SMT_B_MOLD_LAYOUT("2");
        FORM_SMT_B_PHP_INV _frmInv = new FORM_SMT_B_PHP_INV("2");
        Form_Def_PHP _frmDef = new Form_Def_PHP();
        private Database _db = new Database();
        ArrayList _al = new ArrayList();

        #endregion
        #region Db



        Database Db = new Database();


        public DataTable SEL_PHP_HR_DATA(string V_P_DATE, string ARG_LINE, string V_P_SHIFT)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "PKG_OSP_SCREEN.LOAD_OS_TL_PIC";

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

                MyOraDB.Parameter_Values[0] = V_P_DATE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = V_P_SHIFT;
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
        public DataTable SEL_PHP_PRODUCTION_DATA(string ARG_QTYPE, string ARG_LINE, string ARG_LINE1)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_B1.PHP_PROD_WS_SELECT";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE";
                MyOraDB.Parameter_Name[2] = "ARG_LINE1";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_LINE1;
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
        public DataTable SEL_OS_PICTURE1(string ARG_QTYPE, string ARG_LINE)
        {
            string ARG_SHIFT = "011";

            if (int.Parse(DateTime.Now.ToString("HH")) >= 14)
                ARG_SHIFT = "012";
            else if (int.Parse(DateTime.Now.ToString("HH")) >= 23)
                ARG_SHIFT = "013";
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

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

        #endregion

        #region getPicture

        public void GetPicture(string _areaCd)
        {
            try
            {
                string StrSql, strShift;
                //StrSql = " select empid, photo ,AR to_char(UPD_DTTM,'yyyyMMddhh24miss') as upd_date ";
                //StrSql = StrSql + " from PW_HR_PHOTO_T ";
                //StrSql = StrSql + " where empid = '15090164' ";

                if (Convert.ToInt16(DateTime.Now.ToString("HH")) >= 14 && Convert.ToInt16(DateTime.Now.ToString("HH")) < 17)
                    strShift = "'012','001'";
                else if (Convert.ToInt16(DateTime.Now.ToString("HH")) >= 14 && Convert.ToInt16(DateTime.Now.ToString("HH")) < 22)
                    strShift = "'012'";
                else if (Convert.ToInt16(DateTime.Now.ToString("HH")) >= 6 && Convert.ToInt16(DateTime.Now.ToString("HH")) < 14)
                    strShift = "'011','001'";
                else
                    strShift = "'013'";

                StrSql = " SELECT NVL(A.REMARK,SUBSTR(B.NAME, INSTR(B.NAME,' ',1, REGEXP_COUNT(B.NAME,' ')) + 1, LENGTH(B.NAME))) NAME "
                       + "      , PHOTO "
                       + "   FROM HUBICVJ.SMT_PIC_LEADER A "
                       + "     , PW_HR_NAME_T B "
                       + "     , PW_HR_PHOTO_T C "
                       + "     , PW_TL_DAILY_T D "
                       + " WHERE     A.EMPID = B.EMPID "
                       + "       AND A.EMPID = C.EMPID "
                       + "       AND A.EMPID = D.EMPID "
                       + "       AND B.NAME_TYPE = 'ENG'"
                       + "       AND D.SHIFT_ID IN (" + strShift + ") "
                       + "       AND D.TL_DATE = TRUNC(SYSDATE)  "
                       + "       AND A.DEPT = 'OS' "
                       + "       AND A.AREA_CD = '" + _areaCd + "' ";

                _al = _db.getDataORA2(StrSql);

               
               
            }
            catch
            { }
            
        }

        #endregion Get Picture

        private DataTable ReadXML(string file)
        {
            DataTable table = new DataTable("Item");
            try
            {
                DataSet lstNode = new DataSet();
                lstNode.ReadXml(file);
                table = lstNode.Tables["Item"];
                return table;
            }
            catch (Exception ex)
            {
                return table;
            }
        }
        private void MoveToScreen2()
        {
            this.WindowState = FormWindowState.Normal;
            this.Bounds = Screen.AllScreens[1].Bounds;
            this.WindowState = FormWindowState.Maximized;
        }
        private DataTable dtPHPLayout()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LINE_CD");
            dt.Columns.Add("LINE_CD1");
            dt.Columns.Add("LINE_NM");
            dt.Columns.Add("LOC_ROW");
            dt.Columns.Add("LOC_COL");


            dt.Rows.Add("001", "006", "Line 1-6", "0", "0");
            dt.Rows.Add("007", "011", "Line 7-11", "0", "1");
            dt.Rows.Add("012", "016", "Line 12-16", "0", "2");
            dt.Rows.Add("017", "021", "Line 17-21", "0", "3");
            dt.Rows.Add("022", "026", "Line 22-26", "0", "4");

            dt.Rows.Add("027", "032", "Line 27-32", "1", "0");
            dt.Rows.Add("033", "038", "Line 33-38", "1", "1");
            dt.Rows.Add("039", "044", "Line 39-44", "1", "2");
            dt.Rows.Add("045", "050", "Line 45-50", "1", "3");
            dt.Rows.Add("051", "056", "Line 51-56", "1", "4");


            return dt;
        }
        private void DIGITAL_SHOP_FLOOR_Load(object sender, EventArgs e)
        {
            try
            {
                if (Screen.AllScreens.Length > 1)
                    MoveToScreen2();
                DataTable dtXML = ReadXML(Application.StartupPath + "\\Config.XML");
               
                if (tblMain.Controls.Count > 0)
                    tblMain.Controls.Clear();

                //splashScreenManager1.ShowWaitForm();
                //splashScreenManager1.SetWaitFormCaption("Creating Controls...");
                //uC_MENU_MAIN1.OnMenuClick += OnMenuMainClick;
                tblMain.Hide();

                DataTable dt = dtPHPLayout();
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DataTable dtOS = SEL_PHP_PRODUCTION_DATA("Q", dt.Rows[i]["LINE_CD"].ToString(), dt.Rows[i]["LINE_CD1"].ToString());
                      //  DataTable dtPicture = SEL_PHP_HR_DATA("", dt.Rows[i]["LINE_CD"].ToString(), "");

                        UC_MENU_WS MENU_WS = new UC_MENU_WS(dt.Rows[i]["LINE_NM"].ToString(), dt.Rows[i]["LINE_CD"].ToString(), dt.Rows[i]["LINE_CD1"].ToString()); 
                        tblMain.Controls.Add(MENU_WS, Convert.ToInt32(dt.Rows[i]["LOC_COL"]), Convert.ToInt32(dt.Rows[i]["LOC_ROW"]));
                        MENU_WS.BindingData(dtOS, i);

                        dtOS = null;
                      //  dtOS = SEL_PHP_HR_DATA("", dt.Rows[i]["LINE_CD"].ToString(), "");                       
                        MENU_WS.BindingImageData(dtOS, i); 

                        MENU_WS.OnMenuClick += OnMenuClicking;
                        MENU_WS.Dock = DockStyle.Fill;
                    }
                }
                              
               
                tblMain.Show();
              //  splashScreenManager1.CloseWaitForm();
            }
            catch {
               // splashScreenManager1.CloseWaitForm();
            }
        }

        void OnMenuMainClick(string MenuName, string BtnCD)
        {
            try
            { 
            }
            catch { this.Cursor = Cursors.Default; }
        }

        void OnMenuClicking(string MenuName, string toLine, string BtnCD)
        {
            try
            {
                //MessageBox.Show(MenuName + "_" + BtnCD);
                System.Windows.Forms.Form F = null;
                Form fc1 = null;
                this.Cursor = Cursors.WaitCursor;
                switch (Convert.ToInt32(BtnCD))
                {
                    case 1:
                        /*PHP PRODUCTION STATUS
                         Author: LUAN.IT*/
                        fc1 = Application.OpenForms["FRM_PH_PROD_DAILY_DAS"];
                        if (fc1 != null)
                            fc1.Close();
                        FRM_PH_PROD_DAILY_DAS FRM_PROD = new FRM_PH_PROD_DAILY_DAS();

                        FRM_PROD._frmLine = MenuName;
                        FRM_PROD._toLine = toLine;//(int.Parse(MenuName) +5).ToString("000");
                        F = FRM_PROD;
                        break;
                    case 2:
                        /*PHP TALLY SHEET
                        Author: LUAN.IT*/
                        fc1 = Application.OpenForms["FROM_CMP_TALLYSHEET"];
                        if (fc1 != null)
                            fc1.Close();
                        FROM_PH_TALLYSHEET FRM_TALLY = new FROM_PH_TALLYSHEET("CMP TallySheet", "PHP", MenuName, (int.Parse(MenuName) + 5).ToString("000"));
                        F = FRM_TALLY;
                        break;
                    case 3:
                        /*PHP TEMP
                        Author: LUAN.IT*/ 
                        FRM_PH_TEMP_DAS _frmTemp = new FRM_PH_TEMP_DAS("");
                        _frmTemp._frmLine =  int.Parse(MenuName);
                        _frmTemp._toLine = int.Parse(MenuName) + 5;
                        F = _frmTemp; 
                        break;
                    default:
                        break;
                }
                if (F != null)
                {
                    F.Show();
                    F.BringToFront();
                   // if (Db.INSERT_FRM_LOG("CMP_SMT_WS", this.Name + " (Workshop)", BtnCD, F.Name, "Open Form", GetIP() + "/" + System.Environment.MachineName)) { }
                    this.Cursor = Cursors.Default;
                }
                else
                    this.Cursor = Cursors.Default;
            }
            catch { this.Cursor = Cursors.Default; }
        }

        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();

        }

        private void lblDateTime_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                cCount++;
                if (cCount >= 30)
                { 
                    DataTable dt = dtPHPLayout();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int iLine = 0;
                        foreach (UserControl c in this.tblMain.Controls)
                        {
                            DataTable dtOS = SEL_PHP_PRODUCTION_DATA("Q", dt.Rows[iLine]["LINE_CD"].ToString(), dt.Rows[iLine]["LINE_CD1"].ToString());                        
                            UC_MENU_WS MENU_WS = null;
                            MENU_WS = (UC_MENU_WS)c;
                            MENU_WS.BindingData(dtOS, iLine);
                            iLine++;
                        }
                        cCount = 0;
                    }
                }   
            }
            catch { //splashScreenManager1.CloseWaitForm(); 
            }
        }

        private void lblTitle2_DoubleClick(object sender, EventArgs e)
        {
            //---------------DEBUG---------------
            //int iLine = 1;
            //foreach (UserControl c in this.tblMain.Controls)
            //{
            //    DataTable dtOS = Db.SEL_OS_PRODUCTION_DATA("Q", "LO10" + iLine);
            //    UC.UC_MENU_WS MENU_WS = null;
            //    MENU_WS = (UC.UC_MENU_WS)c;
            //    MENU_WS.BindingData(dtOS);
            //    iLine++;
            //}
            //---------------DEBUG---------------
            this.WindowState = FormWindowState.Minimized;
        }

        private void uC_MENU_MAIN1_Load(object sender, EventArgs e)
        {

        }

        //Kiem tra Program co dang chay hay chua?
        private bool ProgramIsRunning(string FullPath)
        {
            try
            {
                string FilePath = Path.GetDirectoryName(FullPath);
                string FileName = Path.GetFileNameWithoutExtension(FullPath).ToLower();
                bool isRunning = false;

                Process[] pList = Process.GetProcessesByName(FileName);
                foreach (Process p in pList)
                    if (p.MainModule.FileName.StartsWith(FilePath, StringComparison.InvariantCultureIgnoreCase))
                    {
                        isRunning = true;
                        break;
                    }

                return isRunning;
            }
            catch
            {

                return false;
            }

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            try 
	        {
                this.Hide();
                //SwitchToThisWindow(FindWindow(""
                
	         }
	        catch 
	        {

	        }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            try
            {
                foreach (UserControl c in this.tblMain.Controls)
                {
                    UC_MENU_WS MENU_WS = null;
                    MENU_WS = (UC_MENU_WS)c;
                    MENU_WS.changeColor();
                }
            }
            catch
            {
            }
        }

        private void cmdLayout_Click(object sender, EventArgs e)
        {
            _frmMoldLayout = new FORM_SMT_B_MOLD_LAYOUT("2");
            _frmMoldLayout.Show();
            
        }

        private void cmdDef_Click(object sender, EventArgs e)
        {
            _frmDef.Show();
        }

        private void cmdInv_Click(object sender, EventArgs e)
        {
            _frmInv.Show();
        }

        private void cmdPMSche_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(724, 286);
            pictureBox1.Visible = true;
        }

        private void cmdPMSche_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }


       

    }
}
