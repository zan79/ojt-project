using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OJTProject.Core
{
    public class MsgBox
    {
        public static void Information(string Message)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(Message, PublicVariables.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Warning(string Message)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(Message, PublicVariables.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Error(string Message)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(Message, PublicVariables.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool IsYes = false;
        public static void Question(string Message)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show(Message, PublicVariables.ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                IsYes = true;
            else
                IsYes = false;
        }
        public static void QuestionWarning(string Message)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show(Message, PublicVariables.ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                IsYes = true;
            else
                IsYes = false;
        }
    }
}
