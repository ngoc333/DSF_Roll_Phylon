using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Media;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace IPEX_Monitor.ClassLib
{
	/// <summary>
	/// ClassForm:  �޴��� �� ������ ���� Form�� ���� ����
	/// </summary>
    public class ClassForm
    {
        public ClassForm()
        {
            //
            // TODO: ���⿡ ������ ���� �߰��մϴ�.
            //
        }
        /// <summary>
        /// �ش� ���� Type ���� Return
        /// </summary>
        /// <param name="arg_FormName"> ���� ���ӽ����̽�.�̸�</param>
        public Type TypeForm(string arg_FormName)
        {

            Type tp = Type.GetType(arg_FormName);
            return tp;

        }
    }

    
}
