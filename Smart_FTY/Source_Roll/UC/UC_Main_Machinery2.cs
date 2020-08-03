using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smart_FTY.UC
{
    public partial class UC_Main_Machinery2 : UserControl
    {
        public UC_Main_Machinery2()
        {
            InitializeComponent();
        }


        
        public void setData(string[] argData)
        {            
            axGrid.Col = 1;
            axGrid.Row = 1;
            axGrid.Text = argData[0];
            //axGrid.BackColor = Color.FromName(argData[1]);
            //axGrid.ForeColor = Color.White;
            axGrid.Row = 2;
            axGrid.Text = argData[1];   
            if (argData[1] == "" || argData[1] == "0")
                axGrid.BackColor = Color.FromName("BLACK");
            else
                axGrid.BackColor = Color.FromName("GREEN");

            axGrid.ForeColor = Color.White;
 
        }
    }
}
