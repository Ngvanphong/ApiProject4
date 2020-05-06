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
                    List<ViewSheetSet> coll = new FilteredElementCollector(doc).OfClass(typeof(ViewSheetSet)).Cast<ViewSheetSet>().ToList();
                    foreach(var print in coll)
                    {
                        if (print.Name == setName)
                        {
                            vss.CurrentViewSheetSet = print;
                            break;
                        }
                    }
                    t.Commit();
                }
            }
            if (AppPenalPrintSort.myFormPrintSort.radioButtonManualChoose.Checked)
            {
                var selectIds = app.ActiveUIDocument.Selection.GetElementIds().ToList();
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
                foreach (var viewAdd in listSheet)
                {
                    if (AppPenalPrintSort.listSheetPrint.Exists(x => x.SheetNumber == viewAdd.SheetNumber) == false)
                    {
                        AppPenalPrintSort.listSheetPrint.Add(viewAdd);
                    }
                }
                MessageBox.Show("You have added: " + selectIds.Count() + " sheets");
            }else if (AppPenalPrintSort.myFormPrintSort.radioButtonAutoSchedule.Checked)
            {
                List<ViewSheet> listSheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
                ViewSchedule viewSchedule = null;
                viewSchedule = doc.ActiveView as ViewSchedule;
                if (viewSchedule == null)
                {
                    MessageBox.Show("You must go to schedule sheet");
                    return;
                }
                TableData table = viewSchedule.GetTableData();
                TableSectionData section = table.GetSectionData(SectionType.Body);
                int nRows = section.NumberOfRows;
                int nColumns = section.NumberOfColumns;
                int indexSheetNumber = 1500;
                for( int c = 0; c < nColumns; c++)
                {
                    var defindField = viewSchedule.Definition;
                    string paramName = defindField.GetField(c).GetName();
                    if(paramName== "Sheet Number")
                    {
                        indexSheetNumber = c;
                        break;
                    }
                }
                if (indexSheetNumber == 1500)
                {
                    MessageBox.Show("You must add Sheet Number to Schedule Table");
                    return;
                }
                
                for(int r = 1; r < nRows; r++)
                {
                    try
                    {
                        string sheetNumber = null;
                        sheetNumber = viewSchedule.GetCellText(SectionType.Body,r, indexSheetNumber).ToString();
                        if (sheetNumber != null&&sheetNumber!="")
                        {
                            foreach(ViewSheet sheet in listSheets)
                            {
                                if (sheet.SheetNumber == sheetNumber)
                                {
                                    if (AppPenalPrintSort.listSheetPrint.Exists(x => x.SheetNumber == sheetNumber) == false)
                                    {
                                        AppPenalPrintSort.listSheetPrint.Add(sheet);
                                    }
                                }
                            }
                        }
                    }
                    catch { continue; }
                }
                MessageBox.Show("The setting is finished");

            }
           
        }

        public string GetName()
        {
            return "PrinterShort";
        }
    }
}
