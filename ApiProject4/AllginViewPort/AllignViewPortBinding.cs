using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ApiProject4.Helper;
using System.Windows.Forms;

namespace ApiProject4.AllginViewPort
{
    [Transaction(TransactionMode.Manual)]
    public class AllignViewPortBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //if (CheckAccess.CheckLicense() == true)
            //{
                AppPenalAlignViewport.ShowAlignViewport();
                GetSheetAll(doc);
            //}
            return Result.Succeeded;
        }
        public void GetSheetAll(Document doc)
        {
            var listAllSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
            foreach(ViewSheet sheet in listAllSheet.OrderByDescending(x => x.SheetNumber))
            {
                var item = new string[] { sheet.SheetNumber, sheet.Name };
                var lvi = new ListViewItem(item);
                lvi.Tag = lvi;
                AppPenalAlignViewport.myFromAlignViewport.listViewChooseSheet.Items.Add(lvi);
            }
        }
    }
}
