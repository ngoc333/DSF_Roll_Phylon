using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using System.IO;
using System.Drawing;

using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;
using System.Globalization;

namespace Smart_FTY.Source_PU.Shortage
{
    class GMES0009_GRID_MANAGER
    {
        public DataTable dt_get = new DataTable();
        public GMES0009_GRID_MANAGER()
        {
        }
        public void CreateSizeGrid(GridControl gridControl, BandedGridView gridView, DataTable dt)
        {
            //gridControl.Hide();
            gridView.BeginDataUpdate();
            try
            {
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.OptionsView.AllowCellMerge = true;
                gridView.Bands.Clear();
                gridView.OptionsView.ShowColumnHeaders = false;
                int _start_col = Convert.ToInt32(dt.Rows[0]["START_COL"]);
               GridBand[] band = new GridBand[_start_col + (dt.Columns.Count - _start_col - 1) / 2];
                int i_arr = _start_col;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i < _start_col)
                    {
                        band[i] = new GridBand() { Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dt.Columns[i].ColumnName.Replace("_", " ").ToLower()) };
                        gridView.Bands.Add(band[i]);
                        band[i].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = band[i].Caption });
                        band[i].Fixed = FixedStyle.Left;
                        if (dt.Columns[i].ColumnName.Equals("OP_CD") || dt.Columns[i].ColumnName.Equals("LINE_CD"))
                        {
                            band[i].Visible = false;
                        }
                    }
                    else if (i > _start_col)
                    {
                        if (dt.Columns[i].ColumnName.Contains("TOT"))
                        {
                            band[i_arr] = new GridBand() { Caption = "Total" };
                            gridView.Bands.Add(band[i_arr]);
                            band[i_arr].Children.Add(new GridBand() { Caption = "Prod" });
                            band[i_arr].Children[0].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "Prod" });
                            band[i_arr].Children.Add(new GridBand() { Caption = "Out" });
                            band[i_arr].Children[1].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i + 1].ColumnName, Visible = true, Caption = "Out" });

                            band[i_arr].Fixed = FixedStyle.Left;
                        }
                        else
                        {
                            band[i_arr] = new GridBand() { Caption = dt.Columns[i].ColumnName.Substring(5, 2) + "-" + dt.Columns[i].ColumnName.Substring(7, 2) };
                            gridView.Bands.Add(band[i_arr]);
                            band[i_arr].Children.Add(new GridBand() { Caption = "Prod" });
                            band[i_arr].Children[0].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName, Visible = true, Caption = "Prod" });
                            band[i_arr].Children.Add(new GridBand() { Caption = "Out" });
                            band[i_arr].Children[1].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i + 1].ColumnName, Visible = true, Caption = "Out" });
                        }
                        if (i + 1 < dt.Columns.Count)
                            i++;
                        i_arr++;
                    }
                }

                foreach (GridBand gb in gridView.Bands)
                {
                    FormatBand(gb);

                }
                gridView.OptionsView.ColumnAutoWidth = false;

                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    if (i >= _start_col)
                    {
                        gridView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gridView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridView.Columns[i].DisplayFormat.FormatString = "#,#.#";
                        gridView.Columns[i].Width = 60;
                    }
                    else
                    {
                        gridView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }
                    if (i < _start_col - 2)
                    {
                        gridView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    }
                    gridView.Columns[i].OptionsColumn.FixedWidth = false;
                    gridView.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView.Columns[i].OptionsColumn.AllowEdit = false;
                }
                gridView.Columns["LINE_NAME"].Width = 80;
                gridView.Columns["STYLE_NAME"].Width = 140;
                gridView.Columns["STYLE_CODE"].Width = 90;
                gridView.Columns["COMPONENT"].Width = 120;

            }
            catch (Exception EX)
            {
                //throw EX;
            }
            //gridControl.Show();
            gridView.EndDataUpdate();
            gridView.ExpandAllGroups();
        }
        public bool Get_DataTable(DataTable dt_table)
        {
            if (dt_get.Rows.Count > 0)
            {
                dt_table = dt_get.Copy();
                return true;
            }
            return false;
        }
        private void SetBandWidth(GridBand band, int width)
        {
            band.OptionsBand.FixedWidth = true;
            band.Width = width;
        }
        private int FindColSize(string[] coloum, string size)
        {

            for (int i = 0; i < coloum.Length; i++)
            {
                if (size == coloum[i].Trim())
                {
                    return i;
                }
            }
            return -1;
        }
        private double[] ClearArr(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;

            }
            return arr;
        }
        private void FormatColumText(GridColumn col)
        {
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.DisplayFormat.FormatString = "{0:n0}";
        }
        public void FormatBand(GridBand root)
        {
            root.AppearanceHeader.Options.UseTextOptions = true;
            root.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            root.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            root.AppearanceHeader.Font = new Font("Calibri", 12);
            root.OptionsBand.FixedWidth = true;
            if (root.Children.Count > 0)
            {
                foreach (GridBand child in root.Children)
                {
                    FormatBand(child);
                }
            }
        }
    }
}
