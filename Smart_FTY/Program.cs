using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Smart_FTY
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            //Application.Run(new Form_Home_Roll());
             //   Application.Run(new FORM_SMT_PU_LEADTIME());

           //   Application.Run(new FORM_SMT_PH_LEADTIME());

            Application.Run(new Form_Home_Roll());

          //  Application.Run(new Form_Home_Phylon());

            //Application.Run(new FORM_SMT_B_MOLD_LAYOUT());
            //Application.Run(new FRM_PH_ANALYSIS());

           // Application.Run(new DIGITAL_SHOP_FLOOR());
          //Application.Run(new FORM_PH_MOLD_REPAIR());
          //  Application.Run(new DIGITAL_SHOP_FLOOR());  //phylon workshop
          //  Application.Run(new FRM_RUB_TEMP_TRACKING());
             //Application.Run(new Form_Home_Phylon_Das());
           // Application.Run(new FRM_PH_TEMP_DAS(""));
           // Application.Run(new FRM_SMT_B_PH_HR_ABSENT());
          //  Application.Run(new FORM_EVA_TEMP_TRACKING()); 
        }
    }
}
   