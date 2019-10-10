using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject4.ColorElement
{

   public static class AppPenalColorElement
    {
        public static frmColorElement myFormColorElement;
        public static bool CancelHandlerAuto = false;
        public static bool SetColor = true;
        public static void ShowFormColor()
        {
            ColorElementHandler handlerColor = new ColorElementHandler();
            ExternalEvent eventColor = ExternalEvent.Create(handlerColor);
            ParameterLoadHandler handlerParameter = new ParameterLoadHandler();
            ExternalEvent eventParameter = ExternalEvent.Create(handlerParameter);
            AutoApplyColorHandler handlerAutoApply = new AutoApplyColorHandler();
            ExternalEvent eventAutoApply = ExternalEvent.Create(handlerAutoApply);
            myFormColorElement = new frmColorElement(eventColor, handlerColor, eventParameter, handlerParameter, eventAutoApply, handlerAutoApply);
            myFormColorElement.Show();
        }
    }
}
