using System;
using System.Data;
using System.Drawing;
using System.Data.OracleClient;


namespace Smart_FTY
{
	/// <summary>
	/// ComVar�� ���� ��� �����Դϴ�.
	/// </summary>
	public class ComVar 
	{
		public ComVar()
		{
			//
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
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
        //// ������
        //public const string Insert = "I";
        //public const string Update = "U";
        //public const string Delete = "D";
	}
}
