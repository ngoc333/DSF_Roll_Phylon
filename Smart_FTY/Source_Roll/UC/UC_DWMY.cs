﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smart_FTY.UC
{
    public partial class UC_DWMY : UserControl
    {
        int _btnisDisable = 0;
        public UC_DWMY(int btnisDisable)
        {
            InitializeComponent();
            _btnisDisable = btnisDisable;

            //Choose a button to disable
            switch (_btnisDisable)
            { 
                case 1:
                    btnDay.Enabled = false;
                    break;
                case 2:
                    btnWeek.Enabled = false;
                    break;
                case 3:
                    btnMonth.Enabled = false;
                    break;
                case 4:
                    btnYear.Enabled = false;
                    break;
                case 5:
                    btnYear.Visible = false;
                    btnMonth.Visible = false;
                    btnWeek.Visible = false;
                    btnDay.Visible = false;
                    break;
                case 6:
                    btnYear.Visible = true;
                    btnMonth.Visible = true;
                    btnWeek.Visible = false;
                    btnDay.Visible = true;
                    break;
                case 7: //month
                    btnMonth.Enabled = false;
                    btnYear.Visible = true;
                    btnMonth.Visible = true;
                    btnWeek.Visible = false;
                    btnDay.Visible = false;
                    break;
                case 8: //year
                    btnYear.Enabled = false;
                    btnYear.Visible = true;
                    btnMonth.Visible = true;
                    btnWeek.Visible = false;
                    btnDay.Visible = false;
                    break; 
            }
        }
        public delegate void ButtonDWMYHandler(string ButtonCap, string ButtonCD);
        public ButtonDWMYHandler OnDWMYClick = null;

        public void YMD_Change(int btnisDisable)
        {
            switch (btnisDisable)
            {
                case 1:
                    btnDay.Enabled = false;
                    btnClose.Enabled = true;
                    break;
                case 2:
                    btnWeek.Enabled = false;
                    btnClose.Enabled = true;
                    break;
                case 3:
                    btnMonth.Enabled = false;
                    break;
                case 4:
                    btnYear.Enabled = false;
                    break;
                case 5:
                    btnYear.Visible = false;
                    btnMonth.Visible = false;
                    btnWeek.Visible = false;
                    btnDay.Visible = false;
                    break;
                case 6:
                    btnYear.Visible = true;
                    btnMonth.Visible = true;
                    btnWeek.Visible = false;
                    btnDay.Visible = true;
                    break;
                case 7:
                    btnYear.Visible = false;
                    btnMonth.Visible = false;
                    btnWeek.Visible = true;
                    btnDay.Visible = true;
                    btnWeek.Enabled = true;
                    btnDay.Enabled = true;
                    break;
                case 8:
                    btnYear.Visible = true;
                    btnMonth.Visible = true;
                    btnWeek.Visible = true;
                    btnDay.Visible = true;
                    btnYear.Enabled = true;
                    btnMonth.Enabled = true;
                    btnWeek.Enabled = true;
                    btnDay.Enabled = false;
                    break;
                case 9:
                    btnYear.Visible = true;
                    btnMonth.Visible = true;
                    btnWeek.Visible = true;
                    btnDay.Visible = true;
                    btnYear.Enabled = true;
                    btnMonth.Enabled = true;
                    btnWeek.Enabled = false;
                    btnDay.Enabled = true;
                    break;
                case 10:
                    btnYear.Visible = true;
                    btnMonth.Visible = true;
                    btnWeek.Visible = true;
                    btnDay.Visible = true;
                    btnYear.Enabled = true;
                    btnMonth.Enabled = false;
                    btnWeek.Enabled = true;
                    btnDay.Enabled = true;
                    break;
                case 11:
                    btnYear.Visible = true;
                    btnMonth.Visible = true;
                    btnWeek.Visible = true;
                    btnDay.Visible = true;
                    btnYear.Enabled = false;
                    btnMonth.Enabled = true;
                    btnWeek.Enabled = true;
                    btnDay.Enabled = true;
                    break;
                case 12:
                    btnYear.Visible = false;
                    btnMonth.Visible = false;
                    btnWeek.Visible = true;
                    btnDay.Visible = true;
                    btnYear.Enabled = true;
                    btnMonth.Enabled = true;
                    btnWeek.Enabled = true;
                    btnDay.Enabled = false;
                    break;
                case 13:
                    btnYear.Visible = false;
                    btnMonth.Visible = false;
                    btnWeek.Visible = true;
                    btnDay.Visible = true;
                    btnYear.Enabled = true;
                    btnMonth.Enabled = true;
                    btnWeek.Enabled = false;
                    btnDay.Enabled = true;
                    break;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (OnDWMYClick != null)
                OnDWMYClick(((DevExpress.XtraEditors.SimpleButton)sender).Name.ToString(), ((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString());

            btnDay.Enabled = true;
            btnWeek.Enabled = true;
            btnMonth.Enabled = true;
            btnYear.Enabled = true;
            ((DevExpress.XtraEditors.SimpleButton)sender).Enabled = false;

            
            //switch (((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString())
            //{
            //    case "D":
            //        ((DevExpress.XtraEditors.SimpleButton)sender).Enabled = false;
            //        break;
            //    case "W":
            //        break;
            //    case "M":
            //        break;
            //    case "Y":
            //        break;
            //}
        }
    }
}
