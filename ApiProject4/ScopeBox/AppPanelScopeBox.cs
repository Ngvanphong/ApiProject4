using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject4.ScopeBox
{
   public static class AppPanelScopeBox
    {
        public static frmScopeBox myFormScopeBox;
        public static void ShowScopeBox()
        {
            ScopeBoxHandler scopeHandler = new ScopeBoxHandler();
            ExternalEvent scopeEvent = ExternalEvent.Create(scopeHandler);
            myFormScopeBox = new frmScopeBox(scopeEvent, scopeHandler);
            myFormScopeBox.Show();
        }
    }
}
