#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiProject4.Button;
#endregion

namespace ApiProject4
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            PurgeCadButton purgeCadClass = new PurgeCadButton();
            purgeCadClass.PurgeCad(a);
            ScopeBoxButton scopeBoxclass = new ScopeBoxButton();
            scopeBoxclass.ScopeBox(a);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
