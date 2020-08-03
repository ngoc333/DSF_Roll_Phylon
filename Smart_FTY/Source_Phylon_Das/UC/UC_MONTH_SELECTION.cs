﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smart_FTY.Source_Roll.UC
{
    public partial class UC_MONTH_SELECTION : UserControl
    {
        private string sValue = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00");
        private string sYearValue = DateTime.Now.Year.ToString();
        private string sMonthValue = DateTime.Now.Month.ToString("00");
        private string[] _arrMonthValue = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        private string[] _arrMonthShortName = {"Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
        private string[] _arrMonthLongName = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novvember", "December" };

        [Browsable(true)]   
        public event EventHandler ValueChangeEvent;
       // public event EventHandler ValueYearChangeEvent;
       // public event EventHandler ValueMonthChangeEvent;
       

        public UC_MONTH_SELECTION()
        {
            InitializeComponent();
            lblYear.Text = sYearValue.ToString();
            lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) - 1].ToString();
        }
        public UC_MONTH_SELECTION(string _sYearValue, string _sMonthValue)
        {
            InitializeComponent();
            sValue = _sYearValue + _sMonthValue;
            lblYear.Text = _sYearValue.ToString();
            lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) - 1].ToString();
        }
   
        private void SetValue()
        {
            lblYear.Text = sValue.ToString();
        }
        public void EnableControl(bool _b)
        {
            btnPrevYear.Enabled = _b;
            btnNextYear.Enabled = _b;
            btnPrevMonth.Enabled = _b;
            btnNextMonth.Enabled = _b;
        }
        public void SetValue(string _sYearValue, string _sMonthValue)
        {
            sYearValue = _sYearValue;
            sMonthValue = _sMonthValue;
            lblYear.Text = sYearValue.ToString();
            lblMonth.Text = _arrMonthValue[Convert.ToInt32(sMonthValue) - 1].ToString();
        }
        public void SetShortName(string _sYearValue, string _sMonthValue)
        {
            sYearValue = _sYearValue;
            sMonthValue = _sMonthValue;
            lblYear.Text = sYearValue.ToString();
            lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) -1 ].ToString();
        }

        public void SetLongName(string _sYearValue, string _sMonthValue)
        {
            sYearValue = _sYearValue;
            sMonthValue = _sMonthValue;
            lblYear.Text = sYearValue.ToString();
            lblMonth.Text = _arrMonthLongName[Convert.ToInt32(sMonthValue) - 1].ToString();
        }
        public string GetValue()
        {
            return sValue;
        }
        public string GetYearValue()
        {
            return sYearValue;
        }

        public string GetMonthValue()
        {
            return sMonthValue;
        }

        private void lblYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EnableControl(false);
                if (this.ValueChangeEvent != null)
                {
                    this.ValueChangeEvent(this, e);
                }
                EnableControl(true);
            } catch(Exception ex)
            {
                EnableControl(true);
            }

        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            
            if (Convert.ToInt32(sMonthValue) == 1)
            {
                sMonthValue = "12";
            }
            else
            {
                sMonthValue = (Convert.ToInt32(sMonthValue) - 1).ToString("00");
            }
            sValue = sYearValue + sMonthValue;
            SetShortName(sYearValue, sMonthValue);
            this.btnPrevMonth.Focus();
            
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(sMonthValue) == 12)
            {
                sMonthValue = "01";               
                
            }
            else
            {
                sMonthValue = (Convert.ToInt32(sMonthValue) + 1).ToString("00");
            }
            sValue = sYearValue + sMonthValue;
            SetShortName(sYearValue, sMonthValue);
            this.btnNextMonth.Focus();
        }

        private void lblMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EnableControl(false);
                if (this.ValueChangeEvent != null)
                {
                    this.ValueChangeEvent(this, e);
                }
                EnableControl(true);
            }
            catch (Exception ex)
            {
                EnableControl(true);
            }
        }

        private void btnPrevYear_Click(object sender, EventArgs e)
        {
            
            sYearValue = (Convert.ToInt32(sYearValue) - 1).ToString();
            sValue = sYearValue + sMonthValue;
            SetShortName(sYearValue, sMonthValue);
            this.btnPrevYear.Focus();
        }

        private void btnNextYear_Click(object sender, EventArgs e)
        {
            
            sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();
            sValue = sYearValue + sMonthValue;
            SetShortName(sYearValue, sMonthValue);
            this.btnNextYear.Focus();
        }

        

        
    }
}
