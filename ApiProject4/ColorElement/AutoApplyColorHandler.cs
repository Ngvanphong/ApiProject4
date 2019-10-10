using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace ApiProject4.ColorElement
{
    public class AutoApplyColorHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
           

        }
        public string GetName()
        {
            return "AutoApplyColorHandler";
        }
    }
}





