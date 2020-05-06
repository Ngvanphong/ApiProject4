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
using OfficeOpenXml.Table;

namespace ApiProject4.PrintSort
{
    public class ExportPrintHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            List<ExcelSheet> listExcel = new List<ExcelSheet>();
            foreach (ViewSheet sheet in AppPenalPrintSort.listSheetPrint)
            {
                ExcelSheet itemExcel = new ExcelSheet(sheet.SheetNumber, sheet.Name);
                listExcel.Add(itemExcel);
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            savefile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs =(System.IO.FileStream)savefile.OpenFile();
                using (ExcelPackage package = new ExcelPackage(fs))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("SheetPrinter");
                    worksheet.Cells["A1"].LoadFromCollection(listExcel, true, TableStyles.Light1);
                    worksheet.Cells.AutoFitColumns();
                    package.Save();
                }
                fs.Close();
            }
        }

        public string GetName()
        {
            return "ExportPrinter";
        }
    }
}
