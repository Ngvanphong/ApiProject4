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
    public class PrintSortHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            PrintManager printManager = doc.PrintManager;
            printManager.PrintRange = PrintRange.Select;
            ViewSheetSetting vss = null;
            vss = printManager.ViewSheetSetting;
            string setName = AppPenalPrintSort.myFormPrintSort.textBoxNamePrinterSet.Text;
            if (setName == "" || setName == string.Empty)
            {
                MessageBox.Show("You must input name set");
                return;
            }

            using (Transaction t = new Transaction(doc, "SaveSetSheet"))
            {
                t.Start();
                try
                {
                    vss.SaveAs(setName);
                    t.Commit();
                }
                catch
                {
                    List<ViewSheetSet> viewSets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheetSet)).Cast<ViewSheetSet>().ToList();
                    foreach(ViewSheetSet viewSet in viewSets)
                    {
                        if (viewSet.Name == setName)
                        {
                            vss.CurrentViewSheetSet = viewSet;
                            break;
                        }
                    }
                    t.Commit();
                }
            }
            var selectIds = app.ActiveUIDocument.Selection.GetElementIds();
            List<ViewSheet> listSheet = new List<ViewSheet>();
            foreach (ElementId id in selectIds)
            {
                try
                {
                    ViewSheet view = doc.GetElement(id) as ViewSheet;
                    if (view != null)
                    {
                        listSheet.Add(view);
                    }
                }
                catch { continue; }
            }
            if (listSheet.Count() == 0)
            {
                MessageBox.Show("You must choose sheets");
                return;

            }
            listSheet = (from ViewSheet vp in listSheet orderby vp.SheetNumber ascending select vp).ToList();
            foreach (ViewSheet vprint in listSheet)
            {
                try
                {
                    AppPenalPrintSort.mySetAll.Insert(vprint);
                }
                catch (Exception ex) { continue; }
            }
            MessageBox.Show("You have added: " + listSheet.Count() + " sheets");
        }

        public string GetName()
        {
            return "PrinterShort";
        }
    }
}
