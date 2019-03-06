using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevExpress;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Links;
using DevExpress.XtraPrintingLinks;

namespace DevX.Helper
{

    public class GridviewHelper
    {
        #region Constuctor
        public GridviewHelper()
        {
            //TO DO :
        }
        #endregion

        #region Property

        public object Tag { get; set; }
        public string ReportPageTitle { get; set; }
        public string ReportPageDetail { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Register default view to use
        /// </summary>
        private GridView defaultView;
        public void RegisterView(GridView view)
        {
            defaultView = view;
        }

        /// <summary>
        /// Register temporary view to be use
        /// </summary>
        private GridView backUpView;
        public void RegisterTemporaryView(GridView view)
        {
            backUpView = defaultView;
            defaultView = view;
        }

        /// <summary>
        /// Dump temporary view and use the default view
        /// </summary>
        public void DumpTemporaryView()
        {
            defaultView = backUpView;
        }

        /// <summary>
        /// Gets the selected gridview item in any type and convert it to specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="colName"></param>
        /// <returns></returns>
        public T GetSelectedItem<T>(string colName)
        {

            object result;

            result = this.defaultView.GetRowCellValue(this.defaultView.FocusedRowHandle, this.defaultView.Columns[colName]);


            return (T)Convert.ChangeType(result, typeof(T));

        }

        /// <summary>
        /// Sets visibility of specified 1 column
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public void SetColumnVisibility(string colName, bool value)
        {
            defaultView.Columns[colName].Visible = value;
        }

        /// <summary>
        /// Sets visibility of specified columns
        /// </summary>
        /// <param name="value"></param>
        /// <param name="colNames"></param>
        public void SetColumnVisibility(bool value, params string[] colNames)
        {
            foreach (string col in colNames)
            {
                defaultView.Columns[col].Visible = value;
            }
        }

        /// <summary>
        /// Sets numeric formats N2 to specified column. for single column.
        /// </summary>
        /// <param name="colName"></param>
        public void SetNumericFormat(string colName)
        {
            this.defaultView.Columns[colName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            this.defaultView.Columns[colName].DisplayFormat.FormatString = "N2";

        }

        /// <summary>
        /// Sets numeric formats N2 to specified columns. Supports multiple columns.
        /// </summary>
        /// <param name="colNames"></param>
        public void SetNumericFormats(string[] colNames)
        {
            foreach (string col in colNames)
            {
                defaultView.Columns[col].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                defaultView.Columns[col].DisplayFormat.FormatString = "N2";
            }

        }

        /// <summary>
        /// Set datetime format so specified column, single column support only.
        /// </summary>
        /// <param name="colName"></param>
        public void SetDateTimeFormat(string colName)
        {
            this.defaultView.Columns[colName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.defaultView.Columns[colName].DisplayFormat.FormatString = "MM/dd/yyyy HH:mm:ss";
        }

        /// <summary>
        ///  Set datetime format so specified column. supports multiple columns.
        /// </summary>
        /// <param name="colNames"></param>
        public void SetDateTimeFormats(string[] colNames)
        {
            foreach (string col in colNames)
            {
                defaultView.Columns[col].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                defaultView.Columns[col].DisplayFormat.FormatString = "MM/dd/yyyy HH:mm:ss";
            }
        }

        /// <summary>
        /// Set accounting format to specified columns.
        /// </summary>
        /// <param name="colNames"></param>
        public void SetAccountingFormat(string colName)
        {
            defaultView.Columns[colName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            defaultView.Columns[colName].DisplayFormat.FormatString = "{0:#,###.00;(#,###.00);'0.00'}";
        }

        /// <summary>
        /// Set accounting format to specified columns. Supports multiple columns
        /// </summary>
        /// <param name="colNames"></param>
        public void SetAccountingFormats(params string[] colNames)
        {
            foreach (string col in colNames)
            {
                defaultView.Columns[col].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                defaultView.Columns[col].DisplayFormat.FormatString = "{0:#,###.00;(#,###.00);'0.00'}";
            }
        }

        /// <summary>
        /// Set custom format to specified colum, supports 1 column only
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="formatType"></param>
        /// <param name="displayFormat"></param>
        public void SetCustomFormat(string colName, DevExpress.Utils.FormatType formatType, string displayFormat)
        {
            defaultView.Columns[colName].DisplayFormat.FormatType = formatType;
            defaultView.Columns[colName].DisplayFormat.FormatString = displayFormat;
        }

        /// <summary>
        /// Set custom formats to specified columns, supports multiple columns
        /// </summary>
        /// <param name="colNames"></param>
        /// <param name="formatType"></param>
        /// <param name="displayFormat"></param>
        public void SetCustomFormats(string[] colNames, DevExpress.Utils.FormatType formatType, string displayFormat)
        {
            foreach (string col in colNames)
            {
                defaultView.Columns[col].DisplayFormat.FormatType = formatType;
                defaultView.Columns[col].DisplayFormat.FormatString = displayFormat;
            }
        }

        /// <summary>
        /// Sets summary footer format N2 to specified column. for single column
        /// </summary>
        /// <param name="colName"></param>
        public void SetSummaryFooterFormat(string colName)
        {
            this.defaultView.Columns[colName].AllowSummaryMenu = false;
            this.defaultView.Columns[colName].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.defaultView.Columns[colName].SummaryItem.DisplayFormat = "{0:n2}";
        }

        /// <summary>
        /// Sets summary footer format N2 to specified columns. Supports multiple columns
        /// </summary>
        /// <param name="colNames"></param>
        public void SetSummaryFooterFormats(params string[] colNames)
        {
            foreach (string col in colNames)
            {
                this.defaultView.Columns[col].AllowSummaryMenu = false;
                this.defaultView.Columns[col].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                this.defaultView.Columns[col].SummaryItem.DisplayFormat = "{0:n2}";
            }
        }

        /// <summary>
        /// Sets column width to specied column
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="width"></param>
        public void SetColumnWidth(string colName, int width)
        {
            this.defaultView.Columns[colName].Width = width;
        }

        /// <summary>
        /// Sets grouping in gridview
        /// </summary>
        /// <param name="colNames"></param>
        public void SetGrouping(params string[] colNames)
        {
            defaultView.OptionsView.ShowGroupPanel = true;

            int counter = 0;
            foreach (string col in colNames)
            {
                defaultView.Columns[col].GroupIndex = counter;
                counter++;
            }

            defaultView.ExpandAllGroups();
        }

        /// <summary>
        /// Set group footer summary
        /// </summary>
        /// <param name="summaryType"></param>
        /// <param name="colNames"></param>
        public void SetGroupFooterSummary(SummaryItemType summaryType, params string[] colNames)
        {

            defaultView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;

            defaultView.GroupSummary.Clear();

            foreach (string col in colNames)
            {
                GridGroupSummaryItem item = new GridGroupSummaryItem();
                item.FieldName = col;
                item.ShowInGroupColumnFooter = defaultView.Columns[col];
                item.SummaryType = summaryType;
                item.DisplayFormat = "{0:n2}";
                defaultView.GroupSummary.Add(item);
            }

        }

        /// <summary>
        /// Custom export to excel
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fileName"></param>
        public void ExportDataToExcel(GridControl grid, string fileName)
        {

            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            link.Component = grid;

            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeeaderArea);

            link.CreateDocument();

            link.ExportToXlsx(fileName);
        }

        /// <summary>
        /// Custom export to excel with page title and page details
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fileName"></param>
        /// <param name="title"></param>
        /// <param name="detail"></param>
        public void ExportDataToExcel(GridControl grid, string fileName, string title, string detail)
        {
            this.ReportPageTitle = title;
            this.ReportPageDetail = detail;

            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            link.Component = grid;

            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeeaderArea);

            link.CreateDocument();

            link.ExportToXlsx(fileName);

        }

        /// <summary>
        /// Set the cell horizontal alignment
        /// </summary>
        /// <param name="alignment"></param>
        /// <param name="colNames"></param>
        public void SetHAlignment(DevExpress.Utils.HorzAlignment alignment, params string[] colNames)
        {
            foreach (string col in colNames)
            {
                this.defaultView.Columns[col].AppearanceCell.TextOptions.HAlignment = alignment;
            }
        }

        public bool HasRow()
        {
            return defaultView.RowCount > 0;
        }

        public int Count()
        {
            return defaultView.RowCount;
        }

        public void ClearColumns()
        {
            defaultView.Columns.Clear();
        }

        public void SetFindPanelVisibility(bool value)
        {
            defaultView.OptionsFind.AlwaysVisible = value;
        }

        public void FitAllColumns()
        {
            defaultView.BestFitColumns();
        }

        #region EventHandler


        /// <summary>
        /// Event handler for creating marginal header area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Link_CreateMarginalHeeaderArea(Object sender, CreateAreaEventArgs e)
        {
            TextBrick b1 = new TextBrick();

            if (this.ReportPageTitle != null)
            {
                b1.Text = this.ReportPageTitle;
            }
            else
            {
                b1.Text = "Page Title";
            }

            b1.StringFormat = new BrickStringFormat(StringAlignment.Center);
            b1.Font = new Font("Tahoma", 17, FontStyle.Bold);
            b1.ForeColor = Color.Black;
            b1.Rect = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 30);
            b1.BorderWidth = 0;
            e.Graph.DrawBrick(b1);

            TextBrick b2 = new TextBrick();

            if (this.ReportPageDetail != null)
            {
                b2.Text = this.ReportPageDetail;
            }
            else
            {
                b2.Text = "Page Detail";
            }

            b2.StringFormat = new BrickStringFormat(StringAlignment.Center);
            b2.Font = new Font("Tahoma", 10, FontStyle.Regular);
            b2.ForeColor = Color.Black;
            b2.Rect = new RectangleF(0, 30, e.Graph.ClientPageSize.Width, 30);
            b2.BorderWidth = 0;
            e.Graph.DrawBrick(b2);
        }

        #endregion

        #endregion

    }


}
