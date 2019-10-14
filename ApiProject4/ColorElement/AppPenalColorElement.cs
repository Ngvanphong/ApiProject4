using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
namespace ApiProject4.ColorElement
{

   public static class AppPenalColorElement
    {
        public static frmColorElement myFormColorElement;
        public static bool SetColor = true;
        public static List<Element> listElementCate = new List<Element>();
        public static List<ValueColor> ListValueColor = new List<ValueColor>();
        public static List<ElementValue> ListElementValue = new List<ElementValue>();
        public static ElevationWatcherUpdater _updater = null;
        public static bool CancelAutoHandler = false;
        public static void ShowFormColor()
        {
            ColorElementHandler handlerColor = new ColorElementHandler();
            ExternalEvent eventColor = ExternalEvent.Create(handlerColor);
            ParameterLoadHandler handlerParameter = new ParameterLoadHandler();
            ExternalEvent eventParameter = ExternalEvent.Create(handlerParameter);
            AutoApplyColorHandler handlerAutoApply = new AutoApplyColorHandler();
            ExternalEvent eventAutoApply = ExternalEvent.Create(handlerAutoApply);
            ValueParamrterHandler handlerValueParameter = new ValueParamrterHandler();
            ExternalEvent eventValueParameter = ExternalEvent.Create(handlerValueParameter);
            UpdateAllHandler handlerUpdate = new UpdateAllHandler();
            ExternalEvent eventUpdate = ExternalEvent.Create(handlerUpdate);
            myFormColorElement = new frmColorElement(eventColor, handlerColor, eventParameter,
                handlerParameter, eventAutoApply, handlerAutoApply, eventValueParameter, handlerValueParameter,
                eventUpdate,handlerUpdate);
            myFormColorElement.Show();
        }
    }
}
