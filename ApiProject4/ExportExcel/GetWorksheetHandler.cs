using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using System.IO;
using OfficeOpenXml;
using System.Windows.Forms;

namespace ApiProject4.ExportExcel
{
  public class GetWorksheetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            string fullPath = AppPenalExportExcel.myFormExportExcel.textBoxInputFile.Text;
            FileInfo file = new FileInfo(fullPath);
            AppPenalExportExcel.myFormExportExcel.listViewInputFile.Items.Clear();
            using (var package = new ExcelPackage(file))
            {
                var workshets = package.Workbook.Worksheets;
                foreach(var worksheet in workshets)
                {
                    var row = new string[] { worksheet.Name };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = lvi;
                    AppPenalExportExcel.myFormExportExcel.listViewInputFile.Items.Add(lvi);
                }
            }
        }

        public string GetName()
        {
            return "GetWorkdsheet";
        }
    }
}
