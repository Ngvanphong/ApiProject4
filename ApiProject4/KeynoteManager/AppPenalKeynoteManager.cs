using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace ApiProject4.KeynoteManager
{
   public static class AppPenalKeynoteManager
    {
        public static frmKeynoteManager myFormKeynoteManager;
        public static void ShowKeynoteManager()
        {
            KeynoteManagerHandler handlerKeynote = new KeynoteManagerHandler();
            ExternalEvent eventKeynote = ExternalEvent.Create(handlerKeynote);
            myFormKeynoteManager = new frmKeynoteManager(eventKeynote, handlerKeynote);
            myFormKeynoteManager.Show();
        }
    }
}
