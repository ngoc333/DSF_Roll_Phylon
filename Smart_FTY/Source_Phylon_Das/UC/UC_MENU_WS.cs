using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Smart_FTY
{
    public partial class UC_MENU_WS : UserControl
    {
        public UC_MENU_WS(string LineTitle,string LineCD, string ToLineCd)
        {
            InitializeComponent();
            lblLine.Text = LineTitle;
            _Line_cd = LineCD;
            _ToLine_cd = ToLineCd;
        }
        #region Variable
        public delegate void ButtonMenuhandler(string ButtonCap, string toLineCd, string ButtonCD);
        public ButtonMenuhandler OnMenuClick = null;
        string _Line_cd, _ToLine_cd;
        #endregion
        ArrayList _al = new ArrayList();

        private Database _db = new Database();


        #region Get Picture
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


        private void Clear()
        {
            for (int iRow = 1; iRow <= axfpSpread1.MaxRows; iRow++)
            {
                axfpSpread1.SetText(2, iRow, "");
            }
        }
        public void changeColor()
        {
            axfpSpread1.Col = 2;
            axfpSpread1.Row = 4;
            if (axfpSpread1.BackColor == Color.Red)
            {
                axfpSpread1.BackColor = Color.Black;
                axfpSpread1.ForeColor = Color.White;
            }
            else if (axfpSpread1.BackColor == Color.Black)
            {
                axfpSpread1.BackColor = Color.Red;
                axfpSpread1.ForeColor = Color.White;
            }
            else
            {
                axfpSpread1.ForeColor = Color.Black;
            }
            axfpSpread1.Row = 5;
            if (axfpSpread1.BackColor == Color.Red)
            {
                axfpSpread1.BackColor = Color.Black;
                axfpSpread1.ForeColor = Color.White;
            }
            else if (axfpSpread1.BackColor == Color.Black)
            {
                axfpSpread1.BackColor = Color.Red;
                axfpSpread1.ForeColor = Color.White;
            }
            else
            {
                axfpSpread1.ForeColor = Color.Black;
            }
        }
        public void BindingData(DataTable dt, int i)
        {
            try
            {

                GetPicture((i + 1).ToString());


                if (_al != null && _al.Count > 0)
                {
                    byte[] MyData = new byte[0];
                    foreach (object[] row in _al)
                    {
                        MyData = (byte[])row[1];
                        lblName.Text = (string)row[0];
                    }

                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(MyData))
                    {
                        picture.BackgroundImage = new Bitmap(stream);

                    }
                }

                Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j <= 2)
                            axfpSpread1.SetText(2, j + 1, Convert.ToDouble(dt.Rows[0][j]).ToString("#,0") + " PRS");
                        else if(j==3)
                        {
                            Color clrRate = Color.White;
                            if (double.Parse(dt.Rows[0][j].ToString()) > 97)
                                clrRate = Color.Green;
                            else if (double.Parse(dt.Rows[0][j].ToString()) < 94)
                                clrRate = Color.Red;
                            else
                                clrRate = Color.Yellow;
                            axfpSpread1.SetText(2, j + 1, Convert.ToDouble(dt.Rows[0][j]).ToString("#0.0") + "%");
                            axfpSpread1.Col = 2;
                            axfpSpread1.Row = j + 1;
                            axfpSpread1.BackColor = clrRate; 
                        }
                        else
                        {
                            Color clrRate = Color.White;
                            if (double.Parse(dt.Rows[0][j].ToString()) <  0.43)
                                clrRate = Color.Green;
                            else 
                                clrRate = Color.Red;
                            axfpSpread1.SetText(2, j + 1, Convert.ToDouble(dt.Rows[0][j]).ToString("#0.00") + "%");
                            axfpSpread1.Col = 2;
                            axfpSpread1.Row = j + 1;
                            axfpSpread1.BackColor = clrRate; 

                        }
                    }
                }
            }
            catch { }
        }

        public void BindingImageData(DataTable dt, int i)
        {
            try
            {
                
                if (dt != null && dt.Rows.Count > 0)
                {

                    GetImage(dt, i);
                    picture.BackgroundImageLayout = ImageLayout.Stretch;
                    lblName.Text = dt.Rows[0]["REMARK1"].ToString();
                }
                else
                {
                   // this.picture.BackgroundImage = global::CMP_DSF_WS.Properties.Resources.dfAvatar;
                   // picture.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            catch { }
        }

        private void GetImage(DataTable dtf, int i)
        {
            try
            { 
                if (dtf.Rows.Count == 0)

                    return;
                 
                if (dtf.Rows[0][0] != null)
                { 
                    byte[] data = (byte[])dtf.Rows[0][0];
                    int ArraySize = new int();
                    ArraySize = data.GetUpperBound(0);  
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(data))
                    {
                        picture.BackgroundImage = new Bitmap(stream); 
                    }
                } 
            }
            catch
            { 
            }
        }


        protected bool SaveData(string FileName, byte[] Data, int ArraySize)
        {
            BinaryWriter Writer = null;
            try
            {
                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(FileName));

                // Writer raw data                
                Writer.Write(Data, 0, ArraySize);
                Writer.Flush();
                Writer.Close();
            }
            catch
            {
                //...
                return false;
            }

            return true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (OnMenuClick != null)
                OnMenuClick(_Line_cd, _ToLine_cd , ((Button)sender).Tag.ToString());
        }

        private void axfpSpread1_Advance(object sender, AxFPUSpreadADO._DSpreadEvents_AdvanceEvent e)
        {

        }

        private void btnTemperature_Click(object sender, EventArgs e)
        {
            if (OnMenuClick != null)
                OnMenuClick(_Line_cd, _ToLine_cd, ((Button)sender).Tag.ToString());
        }
    }
}
