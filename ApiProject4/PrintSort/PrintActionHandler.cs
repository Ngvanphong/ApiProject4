using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

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
                using (Transaction t = new Transaction(doc, "SetPrint"))
                {
                    t.Start();
                    vss.CurrentViewSheetSet.Views = AppPenalPrintSort.mySetAll;
                    vss.Save();
                    t.Commit();
                }
            }
            catch{}
            foreach (ViewSheet sheetPrint in AppPenalPrintSort.listSheetPrint)
            {
             printManager.SubmitPrint(sheetPrint);
             Thread.Sleep(300);
            }
            printManager.Dispose();
            AppPenalPrintSort.myFormPrintSort.Hide(); 
        }

        public string GetName()
        {
            return "PrintAction";
        }   
    }
    public class ExcelSheet
    {
        public ExcelSheet(string number,string name)
        {
            SheetNumber = number;
            SheetName = name;
        }
        public string SheetNumber { get; set; }
        public string SheetName { get; set; }

    }
}
