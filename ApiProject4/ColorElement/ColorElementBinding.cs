using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using ApiProject4.Helper;

namespace ApiProject4.ColorElement
{
    [Transaction(TransactionMode.Manual)]
    public class ColorElementBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPenalColorElement.ShowFormColor();
            }
            return Result.Succeeded;
        }
    }
}
