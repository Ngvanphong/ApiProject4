using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject4.NewSheets
{
  public static class AppPenalNewSheets
    {
        public static frmNewSheets myFormNewShees;
        public static void ShowNewSheet()
        {
            NewSheetsHandler handlerNewSheets = new NewSheetsHandler();
            ExternalEvent eventNewSheets = ExternalEvent.Create(handlerNewSheets);
            myFormNewShees = new frmNewSheets(eventNewSheets, handlerNewSheets);
            myFormNewShees.Show();
        }
    }
}
