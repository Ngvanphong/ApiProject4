using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using OfficeOpenXml;

namespace ApiProject4.PrintSort
{
  public  class ImportPrintHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            List<ViewSheet> listAllSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
            string fullPath = AppPenalPrintSort.myFormPrintSort.textBoxPathExcel.Text;
            FileInfo file = new FileInfo(fullPath);
            using (var package = new ExcelPackage(file))
            {
                var worksheets = package.Workbook.Worksheets;
                ExcelWorksheet worksheet = worksheets.First();
               
                for(int i = 2; i < 2000; i++)
                {
                    string text = string.Empty;
                    text = worksheet.Cells[i, 1].Value.ToString();
                    if (string.IsNullOrEmpty(text) || text == "")
                    {
                        break;
                    }
                    foreach(ViewSheet sheet in listAllSheet)
                    {
                        if (sheet.SheetNumber == text)
                        {
                            AppPenalPrintSort.listSheetPrint.Add(sheet);
                        }
                    }

                }
                
            }

        }

        public string GetName()
        {
            return "ImportPrinter";
        }
    }
}
