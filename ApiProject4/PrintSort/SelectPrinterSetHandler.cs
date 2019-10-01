using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ApiProject4.PrintSort
{
    public class SelectPrinterSetHandler : IExternalEventHandler
    {
        void IExternalEventHandler.Execute(UIApplication app)
        {
            throw new NotImplementedException();
        }

        string IExternalEventHandler.GetName()
        {
            return "SelectPrinterSet";
        }
    }
}
