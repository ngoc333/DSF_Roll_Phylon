﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Runtime.InteropServices;


namespace Smart_FTY
{
    public partial class Form_Home_Phylon_Das : Form
    {

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnon);

        public Form_Home_Phylon_Das()
        {
            InitializeComponent();

           // initForm();
        }

        public Form_Home_Phylon_Das(string argLocation, string argTitle)
        {
            InitializeComponent();
            _location = argLocation;
            lblTitle.Text = argTitle;
        }

        #region Variant
        
        FORM_SMT_B_MOLD_LAYOUT _frmMoldLayout = new FORM_SMT_B_MOLD_LAYOUT("2");
        FORM_SMT_B_PHP_INV _frmInv = new FORM_SMT_B_PHP_INV("2");
        Form_Def_PHP _frmDef = new Form_Def_PHP();
        private const int SW_MAXIMIZE = 3;        
        
        //Form_Home_Phylon _frmDigital = new Form_Home_Phylon();
        string _location ="";
        #endregion Variant

        #region Method
        private void initForm()
        {
            try
            {
                GoFullscreen();
                if (_location == "")
                {
                    Dictionary<string, string>[] dicLocated;
                    try
                    {
                        dicLocated = readFileXML(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "form");
                        _location = dicLocated[0]["monitor"];
                    }
                    catch
                    {}
                }

                if (_location == "A")
                {
                    UCMainMenu ucMenu1 = new UCMainMenu("Line 1-6", "001", "006", "1" );
                    UCMainMenu ucMenu2 = new UCMainMenu("Line 7-12", "007", "012", "2");
                    UCMainMenu ucMenu3 = new UCMainMenu("Line 13-18", "013", "018", "3");

                    UCGrid ucGrid1 = new UCGrid("A1");
                    UCGrid ucGrid2 = new UCGrid("A2");

                    tblMenu.Controls.Add(ucMenu1, 0, 0);
                    tblMenu.Controls.Add(ucMenu2, 0, 1);
                    tblMenu.Controls.Add(ucMenu3, 0, 2);

                    tblGrid.Controls.Add(ucGrid1, 0, 0);
                    tblGrid.Controls.Add(ucGrid2, 0, 1);
                }
                else if (_location == "B")
                {
                    UCMainMenu ucMenu1 = new UCMainMenu("Line 13-18", "013", "018", "4");
                    UCMainMenu ucMenu2 = new UCMainMenu("Line 19-24", "019", "024", "5");
                    UCMainMenu ucMenu3 = new UCMainMenu("Line 25-30", "025", "030", "6");

                    UCGrid ucGrid1 = new UCGrid("B1");
                    UCGrid ucGrid2 = new UCGrid("B2");


                    tblMenu.Controls.Add(ucMenu1, 0, 0);
                    tblMenu.Controls.Add(ucMenu2, 0, 1);
                    tblMenu.Controls.Add(ucMenu3, 0, 2);

                    tblGrid.Controls.Add(ucGrid1, 0, 0);
                    tblGrid.Controls.Add(ucGrid2, 0, 1);
                }
                else
                {
                    UCMainMenu ucMenu1 = new UCMainMenu("Line 27-32", "027", "032", "7");
                    UCMainMenu ucMenu2 = new UCMainMenu("Line 33-38", "033", "038", "8");
                    UCMainMenu ucMenu3 = new UCMainMenu("Line 39-44", "039", "044", "9");

                    UCGrid ucGrid1 = new UCGrid("C1");
                    UCGrid ucGrid2 = new UCGrid("C2");

                    tblMenu.Controls.Add(ucMenu1, 0, 0);
                    tblMenu.Controls.Add(ucMenu2, 0, 1);
                    tblMenu.Controls.Add(ucMenu3, 0, 2);

                    tblGrid.Controls.Add(ucGrid1, 0, 0);
                    tblGrid.Controls.Add(ucGrid2, 0, 1);
                }


                

                
            }
            catch 
            {}
            
        }

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

        public static Dictionary<string, string>[] readFileXML(string str_FileName, string arg_TagName)
        {
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(str_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                    xmldoc.Load(fs);

                    //Get Configuration OF Production Form
                    Dictionary<string, string>[] rtn_VarName = new Dictionary<string, string>[xmldoc.GetElementsByTagName(arg_TagName).Count];
                    int i = 0;
                    foreach (System.Xml.XmlNode xmlnode in xmldoc.GetElementsByTagName(arg_TagName))
                    {
                        rtn_VarName[i] = new Dictionary<string, string>();
                        foreach (System.Xml.XmlElement xmllist in xmlnode.ChildNodes)
                        {
                            rtn_VarName[i].Add(xmllist.Name, xmllist.InnerText);
                        }
                        i++;
                    }
                    return rtn_VarName;
                }
            }
            catch
            {
                return null;
            }

        }


       


        #endregion Method

      

        #region DB

        #endregion DB

        #region Event
        private void Form_Home_Phylon_Das_Load(object sender, EventArgs e)
        {
            
            initForm();
        }


        private void Form_Home_Phylon_Das_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                tmrDateTime.Enabled = true;
            }
            else
            {
                tmrDateTime.Enabled = false;
            }
        }

        private void tmrDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblDateTime_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion Event

        private void cmdLayout_Click(object sender, EventArgs e)
        {
            _frmMoldLayout.Show();
        }

        private void cmdInv_Click(object sender, EventArgs e)
        {
            _frmInv.Show();
        }

        private void cmdLine_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
        }

        private void cmdDef_Click(object sender, EventArgs e)
        {
            _frmDef.Show();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            SwitchToThisWindow(FindWindow(IntPtr.Zero,"RunPH"), false);
            ShowWindow(FindWindow(IntPtr.Zero, "RunPH"), SW_MAXIMIZE);
           
        }

        private void cmdPMSche_Click(object sender, EventArgs e)
        {

        }

        
        

        

        
    }
}
