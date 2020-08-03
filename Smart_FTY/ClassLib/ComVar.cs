using System;
using System.Data;
using System.Drawing;
using System.Data.OracleClient;


namespace Smart_FTY
{
	/// <summary>
	/// ComVar에 대한 요약 설명입니다.
	/// </summary>
	public class ComVar 
	{
		public ComVar()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
		}
        public static string Form_Type = "1";

        public static Form_Home_Phylon _frm_home_phylon = new Form_Home_Phylon();
        public static FORM_PH_DEFFECTIVE_STATUS_YEAR _frYear = new FORM_PH_DEFFECTIVE_STATUS_YEAR();
        public static FORM_PH_DEFFECTIVE_STATUS _frmDefective = new FORM_PH_DEFFECTIVE_STATUS();
         


        //public static string This_Action;
        //public static string This_Win_ID;
        //public static string This_PGM = "MOLD";
        //public static string This_Packages;
        //public static string This_REF1 = "";
        //public static string This_REF2 = "";
        //public static string This_REF3 = "";
        ////public static string This_User = "admin";
        //// 공통사용
        //public const string Insert = "I";
        //public const string Update = "U";
        //public const string Delete = "D";
	}
}
