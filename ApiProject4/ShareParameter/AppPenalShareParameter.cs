using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject4.ShareParameter
{
   public static class AppPenalShareParameter
    {
        public static frmShareParameter myFormShareParameter;
        public static frmAddGroup myFormAddgroup;
        public static frmRenameGroup myFormRenameGroup;
        public static frmAddSharedParameter myFormAddShareParameter;
        public static frmModifyParameter myFormModifyParameter;
        public static string nameParameterModify;
        public static void ShowFormShareParameter()
        {
            nameParameterModify = string.Empty;
            ShareParameterHandler handlerShareParameter = new ShareParameterHandler();
            ExternalEvent eventShareParameter = ExternalEvent.Create(handlerShareParameter);
            AddParameterHandler handlerAddParameter = new AddParameterHandler();
            ExternalEvent eventAddParameter = ExternalEvent.Create(handlerAddParameter);
            myFormShareParameter = new frmShareParameter(eventShareParameter, handlerShareParameter, eventAddParameter, handlerAddParameter);
            myFormShareParameter.Show();
        }

        public static void ShowFormAddGroup()
        {
            myFormAddgroup = new frmAddGroup();
            myFormAddgroup.Owner = myFormShareParameter;
            myFormAddgroup.Show();
        }

        public static void ShowFormRenameGroup()
        {
            myFormRenameGroup = new frmRenameGroup();
            myFormRenameGroup.Show();
        }

        public static void ShowFormAddParameter()
        {
            myFormAddShareParameter = new frmAddSharedParameter();
            myFormAddShareParameter.Show();
        }
        public static void ShowFormModify()
        {
            myFormModifyParameter = new frmModifyParameter();
            myFormModifyParameter.Show();
        }

    }
}
