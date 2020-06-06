using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
namespace ApiProject4.PrintSort
{
    public class SaveSetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            PrintManager printManager = doc.PrintManager;
            ViewSheetSetting vss = printManager.ViewSheetSetting;
            foreach (ViewSheet vprint in AppPenalPrintSort.listSheetPrint)
            {
                try
                {
                    AppPenalPrintSort.mySetAll.Insert(vprint);
                }
                catch { continue; }
            }
            try
            {
                using (Transaction t = new Transaction(doc, "SetPrint2"))
                {
                    t.Start();
                    vss.CurrentViewSheetSet.Views = AppPenalPrintSort.mySetAll;
                    vss.Save();
                    t.Commit();
                }
            }
            catch { }
        }

        public string GetName()
        {
            return "SaveSetHandler";
        }
    }
}
