using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using System.IO;
using OfficeOpenXml;
using System.Windows.Forms;

namespace ApiProject4.ShareParameter
{
    public class ShareParameterHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "ShareParameterHandler";
        }
    }
}
