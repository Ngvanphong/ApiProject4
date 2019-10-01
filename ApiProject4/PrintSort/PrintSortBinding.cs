using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiProject4.Helper;
using System.Windows.Forms;

namespace ApiProject4.PrintSort
{
    [Transaction(TransactionMode.Manual)]
    public class PrintSortBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPenalPrintSort.ShowFormPrint();
                Information.GetInforForm(doc);
            }
            return Result.Succeeded;
        }

       
    }
    public class Information
    {
        public static void GetInforForm(Document doc)
        {
            PrintManager printManager = doc.PrintManager;
            List<ViewSheetSet> coll = new FilteredElementCollector(doc).OfClass(typeof(ViewSheetSet)).Cast<ViewSheetSet>().ToList();
            if (coll.Count() > 0)
            {
                foreach (ViewSheetSet viewSet in coll)
                {
                    AppPenalPrintSort.myFormPrintSort.listBoxSetPrinter.Items.Add(viewSet.Name);
                }
                AppPenalPrintSort.myFormPrintSort.textBoxNamePrinterSet.Text = coll.First().Name;
            }       
        }
    }
}
