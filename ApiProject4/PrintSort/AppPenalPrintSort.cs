using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

namespace ApiProject4.PrintSort
{
   public static class AppPenalPrintSort
    {
        public static frmPrintSort myFormPrintSort;
        public static ViewSet mySetAll;
        public static List<ViewSheet> listSheetPrint;
        public static void ShowFormPrint()
        {
            mySetAll = new ViewSet();
            listSheetPrint = new List<ViewSheet>();
            PrintSortHandler handlerPrint = new PrintSortHandler();
            ExternalEvent eventPrint = ExternalEvent.Create(handlerPrint);
            PrintActionHandler handlerPrintAction = new PrintActionHandler();
            ExternalEvent eventPrintAction = ExternalEvent.Create(handlerPrintAction);
            ExportPrintHandler handlerExport = new ExportPrintHandler();
            ExternalEvent eventExportPrint = ExternalEvent.Create(handlerExport);
            ImportPrintHandler handlerImport = new ImportPrintHandler();
            ExternalEvent eventImportPrint = ExternalEvent.Create(handlerImport);
            myFormPrintSort = new frmPrintSort(eventPrint, handlerPrint, eventPrintAction, handlerPrintAction,
               eventExportPrint, handlerExport, eventImportPrint, handlerImport);
            myFormPrintSort.Show();
        }
    }
}
