using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using ApiProject4.Helper;

namespace ApiProject4.ColorElement
{
    [Transaction(TransactionMode.Manual)]
    public class ColorElementBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPenalColorElement.ShowFormColor();
                CategoryInfor(doc);
            }
            return Result.Succeeded;
        }

        public void CategoryInfor(Document doc)
        {
            //Create collector to collect all elements on active view
            var collector = new FilteredElementCollector(doc, doc.ActiveView.Id).ToElements();
            //get distinct categories of elements in the active view
            List<Category> categories = new List<Category>();
            foreach (Element ele in collector)
            {
                try
                {
                    Category cate = null;
                    cate = ele.Category;
                    if (cate != null)
                    {
                        if (!categories.Exists(x => x.Name == cate.Name))
                        {
                            categories.Add(cate);
                        }
                    }
                }
                catch { continue; }
            }

            foreach (var cate in categories.OrderBy(x => x.Name))
            {
                var name = cate.Name;
                AppPenalColorElement.myFormColorElement.listBoxCategory.Items.Add(name);
            }
        }
    }
}
