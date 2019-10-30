using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using ApiProject4.Helper;

namespace ApiProject4.KeynoteManager
{
    [Transaction(TransactionMode.Manual)]
    public class KeynoteManagerBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPenalKeynoteManager.ShowKeynoteManager();
            }
            return Result.Succeeded;
        }
    }
}
