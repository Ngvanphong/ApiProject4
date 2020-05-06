using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
namespace ApiProject4.ExportExcel
{
   public static class AppPenalExportExcel
    {
        public static frmExportExcel myFormExportExcel;
        public static void ShowFormExportExcel()
        {
            ExportExcelHandler handlerExcel = new ExportExcelHandler();
            ExternalEvent eventExport = ExternalEvent.Create(handlerExcel);
            ImportHandler handlerImport = new ImportHandler();
            ExternalEvent eventImport = ExternalEvent.Create(handlerImport);
            GetWorksheetHandler handlerGet = new GetWorksheetHandler();
            ExternalEvent eventGet = ExternalEvent.Create(handlerGet);
            myFormExportExcel = new frmExportExcel(eventExport, handlerExcel,eventImport,handlerImport,eventGet,handlerGet);
            myFormExportExcel.Show();
        }
    }
}
