using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OracleClient;
using C1.Win.C1FlexGrid;
using FlexQuality.ClassLib;
using System.Globalization;
using System.IO;
using System.Diagnostics;


namespace FlexQuality.ClassLib
{
	/// <summary>
	/// ComCtl�� ���� ��� �����Դϴ�.
	/// </summary>
	public class ComCtl : COM.ComCtl
	{
		public ComCtl()
		{
			//
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
			//
        }


        /// <summary>
        /// Set_ComboList : DataTable�� ������ �޺�����Ʈ�� �߰�
        /// </summary>
        /// <param name="dtcmb_list">�޺� �ڽ��� �߰��� ����Ʈ</param>
        /// <param name="arg_cmb">���� ��� �޺� �ڽ���</param>
        /// <param name="arg_cd_ix">�ڵ�� ���� �ʵ� �ε���</param>
        /// <param name="arg_name_ix">�ڵ������ ���� �ʵ� �ε���</param>
        public static void Set_ComboList(DataTable dtcmb_list, C1.Win.C1List.C1Combo arg_cmb, int arg_cd_ix, int arg_name_ix)
        {
            Set_ComboList(dtcmb_list, arg_cmb, arg_cd_ix, arg_name_ix, false);
        }


        /// <summary>
        /// Set_ComboList : DataTable�� ������ �޺�����Ʈ�� �߰�
        /// </summary>
        /// <param name="dtcmb_list">�޺� �ڽ��� �߰��� ����Ʈ</param>
        /// <param name="arg_cmb">���� ��� �޺� �ڽ���</param>
        /// <param name="arg_cd_ix">�ڵ�� ���� �ʵ� �ε���</param>
        /// <param name="arg_name_ix">�ڵ������ ���� �ʵ� �ε���</param>
        /// <param name="arg_emptyrow">��ܿ� ���� ������ ����</param>
        public static void Set_ComboList(DataTable dtcmb_list, C1.Win.C1List.C1Combo arg_cmb, int arg_cd_ix, int arg_name_ix, bool arg_emptyrow)
        {

            DataTable temp_datatable = new DataTable("Combo List");
            DataRow newrow;


            try
            {

                temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
                temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));

                if (arg_emptyrow == true)
                {
                    newrow = temp_datatable.NewRow();
                    newrow["Code"] = " ";
                    newrow["Name"] = "ALL";
                    temp_datatable.Rows.Add(newrow);
                }

                for (int i = 0; i < dtcmb_list.Rows.Count; i++)
                {

                    newrow = temp_datatable.NewRow();
                    newrow["Code"] = dtcmb_list.Rows[i].ItemArray[arg_cd_ix];
                    newrow["Name"] = dtcmb_list.Rows[i].ItemArray[arg_name_ix];
                    temp_datatable.Rows.Add(newrow);

                }


                arg_cmb.DataSource = null;
                arg_cmb.DataSource = temp_datatable;

                arg_cmb.ValueMember = "Code";
                arg_cmb.DisplayMember = "Name";

                arg_cmb.SelectedIndex = -1;
                arg_cmb.MaxDropDownItems = 10;
                arg_cmb.Splits[0].DisplayColumns["Code"].Width = 50;
                arg_cmb.Splits[0].DisplayColumns["Name"].Width = 150;
                arg_cmb.ExtendRightColumn = true;
                arg_cmb.CellTips = C1.Win.C1List.CellTipEnum.Anchored;


            }
            catch
            {
                //MessageBox.Show(ex.Message.ToString(),"Set_ComboList",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }


        }


        /// <summary>
        /// Set_ComboList : DataTable�� ������ �޺�����Ʈ�� �߰�
        /// </summary>
        /// <param name="dtcmb_list">�޺� �ڽ��� �߰��� ����Ʈ</param>
        /// <param name="arg_cmb">���� ��� �޺� �ڽ���</param>
        /// <param name="arg_cd_ix">�ڵ�� ���� �ʵ� �ε���</param>
        /// <param name="arg_name_ix">�ڵ������ ���� �ʵ� �ε���</param>
        /// <param name="arg_emptyrow">��ܿ� ���� ������ ����</param> 
        /// <param name="arg_visible">������ �÷� ����</param>
        public static void Set_ComboList(DataTable dtcmb_list, C1.Win.C1List.C1Combo arg_cmb, int arg_cd_ix, int arg_name_ix, bool arg_emptyrow, COM.ComVar.ComboList_Visible arg_visible)
        {

            DataTable temp_datatable = new DataTable("Combo List");
            DataRow newrow;


            try
            {

                temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
                temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));

                if (arg_emptyrow)
                {
                    newrow = temp_datatable.NewRow();
                    newrow["Code"] = " ";
                    newrow["Name"] = "ALL";
                    temp_datatable.Rows.Add(newrow);
                }

                for (int i = 0; i < dtcmb_list.Rows.Count; i++)
                {

                    newrow = temp_datatable.NewRow();
                    newrow["Code"] = dtcmb_list.Rows[i].ItemArray[arg_cd_ix];
                    newrow["Name"] = dtcmb_list.Rows[i].ItemArray[arg_name_ix];
                    temp_datatable.Rows.Add(newrow);

                }


                arg_cmb.DataSource = null;
                arg_cmb.DataSource = temp_datatable;

                arg_cmb.ValueMember = "Code";
                arg_cmb.DisplayMember = "Name";

                arg_cmb.SelectedIndex = -1;
                arg_cmb.MaxDropDownItems = 10;
                arg_cmb.Splits[0].DisplayColumns["Code"].Width = 50;
                arg_cmb.Splits[0].DisplayColumns["Name"].Width = 150;
                arg_cmb.ExtendRightColumn = true;
                arg_cmb.CellTips = C1.Win.C1List.CellTipEnum.Anchored;

                switch (arg_visible)
                {
                    case COM.ComVar.ComboList_Visible.Code:
                        arg_cmb.Splits[0].DisplayColumns["Name"].Visible = false;
                        arg_cmb.DisplayMember = "Code";
                        break;

                    case COM.ComVar.ComboList_Visible.Name:
                        arg_cmb.Splits[0].DisplayColumns["Code"].Visible = false;
                        break;

                    //case COM.ComVar.ComboList_Visible.Code_Name:
                    //break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Set_ComboList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        /// <summary>
        /// Set_ComboList : DataTable�� ������ �޺�����Ʈ�� �߰�
        /// </summary>
        /// <param name="dtcmb_list">�޺� �ڽ��� �߰��� ����Ʈ</param>
        /// <param name="arg_cmb">���� ��� �޺� �ڽ���</param>
        /// <param name="arg_cd_ix">�ڵ�� ���� �ʵ� �ε���</param>
        /// <param name="arg_name_ix">�ڵ������ ���� �ʵ� �ε���</param>
        /// <param name="arg_emptyrow">��ܿ� ���� ������ ����</param>
        /// <param name="arg_visible_code">�ڵ� �÷� ������ ����</param>
        public static void Set_ComboList(DataTable dtcmb_list, C1.Win.C1List.C1Combo arg_cmb, int arg_cd_ix, int arg_name_ix, bool arg_emptyrow, bool arg_visible_code)
        {

            DataTable temp_datatable = new DataTable("Combo List");
            DataRow newrow;


            try
            {

                temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
                temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));

                if (arg_emptyrow)
                {
                    newrow = temp_datatable.NewRow();
                    newrow["Code"] = " ";
                    newrow["Name"] = "ALL";
                    temp_datatable.Rows.Add(newrow);
                }

                for (int i = 0; i < dtcmb_list.Rows.Count; i++)
                {

                    newrow = temp_datatable.NewRow();
                    newrow["Code"] = dtcmb_list.Rows[i].ItemArray[arg_cd_ix];
                    newrow["Name"] = dtcmb_list.Rows[i].ItemArray[arg_name_ix];
                    temp_datatable.Rows.Add(newrow);

                }


                arg_cmb.DataSource = null;
                arg_cmb.DataSource = temp_datatable;

                arg_cmb.ValueMember = "Code";
                arg_cmb.DisplayMember = "Name";

                arg_cmb.SelectedIndex = -1;
                arg_cmb.MaxDropDownItems = 10;
                arg_cmb.Splits[0].DisplayColumns["Code"].Width = 50;
                arg_cmb.Splits[0].DisplayColumns["Name"].Width = 150;
                arg_cmb.ExtendRightColumn = true;
                arg_cmb.CellTips = C1.Win.C1List.CellTipEnum.Anchored;

                if (!arg_visible_code) arg_cmb.Splits[0].DisplayColumns["Code"].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Set_ComboList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }




        /// <summary>
        /// Set_ComboList : DataTable�� ������ �޺�����Ʈ�� �߰�
        /// </summary>
        /// <param name="dtcmb_list">�޺� �ڽ��� �߰��� ����Ʈ</param>
        /// <param name="arg_cmb">���� ��� �޺� �ڽ���</param>
        /// <param name="arg_cd_ix">�ڵ�� ���� �ʵ� �ε���</param>
        /// <param name="arg_name_ix">�ڵ������ ���� �ʵ� �ε���</param>
        /// <param name="arg_emptyrow">��ܿ� ���� ������ ����</param>
        /// <param name="arg_codewidth">Code Width ��</param>
        /// <param name="arg_namewidth">Name Width ��</param>
        public static void Set_ComboList(DataTable dtcmb_list, C1.Win.C1List.C1Combo arg_cmb, int arg_cd_ix, int arg_name_ix, bool arg_emptyrow,
            int arg_codewidth, int arg_namewidth)
        {

            DataTable temp_datatable = new DataTable("Combo List");
            DataRow newrow;
            int dropdownwidth = arg_codewidth + arg_namewidth;
            if (arg_cmb.Width > dropdownwidth)
            {
                dropdownwidth = arg_cmb.Width;
            }

            try
            {

                temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
                temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));

                if (arg_emptyrow == true)
                {
                    newrow = temp_datatable.NewRow();
                    newrow["Code"] = " ";
                    newrow["Name"] = "ALL";
                    temp_datatable.Rows.Add(newrow);
                }

                for (int i = 0; i < dtcmb_list.Rows.Count; i++)
                {

                    newrow = temp_datatable.NewRow();
                    newrow["Code"] = dtcmb_list.Rows[i].ItemArray[arg_cd_ix];
                    newrow["Name"] = dtcmb_list.Rows[i].ItemArray[arg_name_ix];
                    temp_datatable.Rows.Add(newrow);

                }


                arg_cmb.DataSource = null;
                arg_cmb.DataSource = temp_datatable;

                arg_cmb.ValueMember = "Code";
                arg_cmb.DisplayMember = "Name";

                arg_cmb.SelectedIndex = -1;
                arg_cmb.MaxDropDownItems = 10;
                arg_cmb.DropDownWidth = dropdownwidth;
                arg_cmb.Splits[0].DisplayColumns["Code"].Width = arg_codewidth;
                arg_cmb.Splits[0].DisplayColumns["Name"].Width = arg_namewidth - 25;//��ũ�� ����
                arg_cmb.ExtendRightColumn = true;
                arg_cmb.CellTips = C1.Win.C1List.CellTipEnum.Anchored;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Set_ComboList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }




        /// <summary>
        /// Set_ComboList : DataTable�� ������ �޺�����Ʈ�� �߰�
        /// </summary>
        /// <param name="dtcmb_list">�޺� �ڽ��� �߰��� ����Ʈ</param>
        /// <param name="arg_cmb">���� ��� �޺� �ڽ���</param>
        /// <param name="arg_cd_ix">�ڵ�� ���� �ʵ� �ε���</param>
        /// <param name="arg_name_ix">�ڵ������ ���� �ʵ� �ε���</param>
        /// <param name="arg_emptyrow">��ܿ� ���� ������ ����</param>
        public static void Set_ComboList(DataTable dtcmb_list, C1.Win.C1List.C1Combo arg_cmb, int arg_cd_ix, int arg_name_ix, string arg_name1, string arg_name2, bool arg_emptyrow)
        {

            DataTable temp_datatable = new DataTable("Combo List");
            DataRow newrow;


            try
            {

                temp_datatable.Columns.Add(new DataColumn(arg_name1, Type.GetType("System.String")));
                temp_datatable.Columns.Add(new DataColumn(arg_name2, Type.GetType("System.String")));

                if (arg_emptyrow == true)
                {
                    newrow = temp_datatable.NewRow();
                    newrow[arg_name1] = " ";
                    newrow[arg_name2] = "ALL";
                    temp_datatable.Rows.Add(newrow);
                }

                for (int i = 0; i < dtcmb_list.Rows.Count; i++)
                {

                    newrow = temp_datatable.NewRow();
                    newrow[arg_name1] = dtcmb_list.Rows[i].ItemArray[arg_cd_ix];
                    newrow[arg_name2] = dtcmb_list.Rows[i].ItemArray[arg_name_ix];
                    temp_datatable.Rows.Add(newrow);

                }


                arg_cmb.DataSource = null;
                arg_cmb.DataSource = temp_datatable;

                arg_cmb.ValueMember = arg_name1;
                arg_cmb.DisplayMember = arg_name2;

                arg_cmb.SelectedIndex = -1;
                arg_cmb.MaxDropDownItems = 10;
                arg_cmb.Splits[0].DisplayColumns[arg_name1].Width = 50;
                arg_cmb.Splits[0].DisplayColumns[arg_name2].Width = 150;
                arg_cmb.ExtendRightColumn = true;
                arg_cmb.CellTips = C1.Win.C1List.CellTipEnum.Anchored;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Set_ComboList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Set_ComboList_3 : �÷� 3��¥�� �޺�����Ʈ
        /// </summary>
        /// <param name="dtcmb_list"></param>
        /// <param name="arg_cmb"></param>
        /// <param name="arg_1_pos"></param>
        /// <param name="arg_2_pos"></param>
        /// <param name="arg_3_pos"></param>
        public static void Set_ComboList_3(DataTable dtcmb_list, C1.Win.C1List.C1Combo arg_cmb, int arg_1_pos, int arg_2_pos, int arg_3_pos)
        {
            DataSet temp_dataset = new System.Data.DataSet();
            DataTable temp_datatable;
            DataRow newrow;
            int i;

            temp_datatable = temp_dataset.Tables.Add("Combo List");
            temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
            temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
            temp_datatable.Columns.Add(new DataColumn("Desc", Type.GetType("System.String")));


            for (i = 0; i < dtcmb_list.Rows.Count; i++)
            {
                newrow = temp_datatable.NewRow();
                newrow[0] = dtcmb_list.Rows[i].ItemArray[arg_1_pos];
                newrow[1] = dtcmb_list.Rows[i].ItemArray[arg_2_pos];
                newrow[2] = dtcmb_list.Rows[i].ItemArray[arg_3_pos];
                temp_datatable.Rows.Add(newrow);
            }



            //			arg_cmb.ClearItems();  

            // 			arg_cmb.DataSource = null; 

            arg_cmb.DataSource = temp_datatable;

            arg_cmb.ValueMember = "Code";
            arg_cmb.DisplayMember = "Name";

            arg_cmb.SelectedIndex = -1;

            arg_cmb.MaxDropDownItems = 10;
            arg_cmb.Splits[0].DisplayColumns[0].Width = 50;
            arg_cmb.Splits[0].DisplayColumns[1].Width = 150;
            arg_cmb.Splits[0].DisplayColumns[2].Width = 150;
            arg_cmb.ExtendRightColumn = true;
            arg_cmb.CellTips = C1.Win.C1List.CellTipEnum.Anchored;

        }
	}
}
