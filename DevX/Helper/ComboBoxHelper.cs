using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace DevX.Helper
{
    public class ComboBoxHelper
    {
        /// <summary>
        /// Load the data in specifed ComboBoxEdit control using List<string>
        /// </summary>
        /// <param name="cmb">Name of ComboBoxedit control</param>
        /// <param name="list">The list of string to be added in controls data</param>
        public void Load(ComboBoxEdit cmb, List<string> list)
        {
            cmb.Properties.Items.Clear();

            foreach (string item in list)
            {
                cmb.Properties.Items.Add(item);
            }
        }

        /// <summary>
        /// Load the data in specified ComboBoxEdit control using Datatable
        /// </summary>
        /// <param name="cmb">Name of ComboBoxEdit control</param>
        /// <param name="dt">Source of data</param>
        /// <param name="col">Column name in source to be display in control</param>
        public void Load(ComboBoxEdit cmb, DataTable dt, string col)
        {
            cmb.Properties.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                cmb.Properties.Items.Add(row[col].ToString());
            }
        }

    }
}
