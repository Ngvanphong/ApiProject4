using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ApiProject4.PrintSort
{
    public class PrintActionHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            PrintManager printManager = doc.PrintManager;
            printManager.PrintRange = PrintRange.Select;
            ViewSheetSetting vss = printManager.ViewSheetSetting;
            using (Transaction t = new Transaction(doc, "SetPrint"))
            {
                t.Start();
                vss.CurrentViewSheetSet.Views = AppPenalPrintSort.mySetAll;
                vss.Save();
                t.Commit();
            }
            AppPenalPrintSort.myFormPrintSort.Hide();
        }

        public string GetName()
        {
            return "PrintAction";
        }
    }
}
