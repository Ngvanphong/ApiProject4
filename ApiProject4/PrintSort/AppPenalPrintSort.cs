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
        public static void ShowFormPrint()
        {
            PrintSortHandler handlerPrint = new PrintSortHandler();
            ExternalEvent eventPrint = ExternalEvent.Create(handlerPrint);
            SelectPrinterSetHandler handlerSelect = new SelectPrinterSetHandler();
            ExternalEvent eventSelect = ExternalEvent.Create(handlerSelect);
            myFormPrintSort = new frmPrintSort(eventPrint, handlerPrint, eventSelect, handlerSelect);
            myFormPrintSort.Show();
        }
    }
}
