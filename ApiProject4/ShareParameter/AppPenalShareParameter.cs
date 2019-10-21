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

        public static void ShowFormShareParameter()
        {
            ShareParameterHandler handlerShareParameter = new ShareParameterHandler();
            ExternalEvent eventShareParameter = ExternalEvent.Create(handlerShareParameter);
            myFormShareParameter = new frmShareParameter(eventShareParameter, handlerShareParameter);
            myFormShareParameter.Show();
        }

    }
}
