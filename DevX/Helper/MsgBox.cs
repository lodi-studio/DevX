using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace DevX.Helper
{
    #region WinForms MessageBox

   public class WinMsgBox
    {

        public void ShowInfo(string message, string title = "Information")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowWarning(string message, string title = "Warning")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult ShowConfirm(string message, string title = "Confirmation")
        {
            DialogResult result;

            if (MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                result = DialogResult.Yes;
            }
            else
            {
                result = DialogResult.No;
            }

            return result;
        }

        public DialogResult ShowConfirmWarning(string message, string title = "Confirmation")
        {
            DialogResult result;

            if (MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                result = DialogResult.Yes;
            }
            else
            {
                result = DialogResult.No;
            }

            return result;
        }

    }
        #endregion

    #region DevX MessageBox

    public class DevXMsgBox
    {
        public void ShowInfo(string message, string title = "Information",  bool allowHtmlText = false)
        {
            DevExpress.Utils.DefaultBoolean isAllowed = allowHtmlText ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, isAllowed);
        }

        public void ShowWarning(string message, string title = "Warning", bool allowHtmlText = false)
        {
            DevExpress.Utils.DefaultBoolean isAllowed = allowHtmlText ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning, isAllowed);
        }

        public void ShowError(string message, string title = "Error", bool allowHtmlText = false)
        {
            DevExpress.Utils.DefaultBoolean isAllowed = allowHtmlText ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error, isAllowed);
        }

        public DialogResult ShowConfirm(string message, string title = "Confirmation", bool allowHtmlText = false)
        {
            DialogResult result;
            DevExpress.Utils.DefaultBoolean isAllowed = allowHtmlText ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

            if (XtraMessageBox.Show(message, title, MessageBoxButtons.YesNo,isAllowed) == DialogResult.Yes)
            {
                result = DialogResult.Yes;
            }
            else
            {
                result = DialogResult.No;
            }

            return result;
        }

        public DialogResult ShowConfirmWarning(string message, string title = "Confirmation Warning", bool allowHtmlText = false)
        {
            DialogResult result;
            DevExpress.Utils.DefaultBoolean isAllowed = allowHtmlText ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

            if (XtraMessageBox.Show(message, title, MessageBoxButtons.YesNo, isAllowed) == DialogResult.Yes)
            {
                result = DialogResult.Yes;
            }
            else
            {
                result = DialogResult.No;
            }

            return result;
        }

    }

    #endregion
}
