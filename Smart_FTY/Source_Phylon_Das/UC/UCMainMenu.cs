using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Smart_FTY
{
    public partial class UCMainMenu : UserControl
    {
        public UCMainMenu( string argText, string argFrmLine, string argToLine, string argAreaCd)
        {
            InitializeComponent();
            cmdLine.Text = argText;
            _frmProd._frmLine = argFrmLine;
            _frmProd._toLine = argToLine;

            _frmTallySheet._SOPCD = "PHP";
            _frmTallySheet._SMCF = argFrmLine;
            _frmTallySheet._SMCT = argToLine;

            _areaCd = argAreaCd;
            int frm , to;
            int.TryParse(argFrmLine, out frm);
            int.TryParse(argToLine, out to);
            _frmTemp._frmLine = frm;
            _frmTemp._toLine = to;
            GetPicture();
            timer1.Start();
            
        }
        int _iCount=29;
        string _areaCd;
       // public static string _frmLine="", _toLine="";

        FRM_PH_PROD_DAILY_DAS _frmProd = new FRM_PH_PROD_DAILY_DAS();
        FROM_PH_TALLYSHEET _frmTallySheet = new FROM_PH_TALLYSHEET();

        FRM_PH_TEMP_DAS _frmTemp = new FRM_PH_TEMP_DAS("");
        private Database _db = new Database();
        ArrayList _al = new ArrayList();
        #region Get Picture
        public void GetPicture()
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _iCount++;
                if (_iCount >= 30)
                {
                    _iCount = 0;
                    if (_al != null && _al.Count > 0)
                    {
                        byte[] MyData = new byte[0];
                        foreach (object[] row in _al)
                        {
                            MyData = (byte[])row[1];
                            label1.Text = (string)row[0];
                        }
                        
                        using (System.IO.MemoryStream stream = new System.IO.MemoryStream(MyData))
                        {
                            pictureBox1.BackgroundImage = new Bitmap(stream);
                            
                        }
                    }
                    if (label1.Text == "") label1.Visible = false;
                    else label1.Visible = true;

                }
                else if (_iCount == 15)
                {
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(GetPicture));
                    t.Start();
                }
            }
            catch
            { }
        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            Button cmd = (Button)sender;
            cmd.BackColor = Color.DarkOrange;
            cmd.ForeColor = Color.White;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button cmd = (Button)sender;
            cmd.BackColor = Color.RoyalBlue;
            cmd.ForeColor = Color.White;
        }

        private void cmdLine_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
        }

        private void cmdProduction_Click(object sender, EventArgs e)
        {
            _frmProd.Show();
        }

        private void cmdTallySheet_Click(object sender, EventArgs e)
        {
            _frmTallySheet.Show();
        }

        private void cmdTemp_Click(object sender, EventArgs e)
        {
            _frmTemp.Show();
        }

        
    }
}
