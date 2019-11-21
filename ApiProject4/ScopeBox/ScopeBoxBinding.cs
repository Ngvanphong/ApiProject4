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

namespace ApiProject4.ScopeBox
{
    [Transaction(TransactionMode.Manual)]
    public class ScopeBoxBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //if (CheckAccess.CheckLicense() == true)
            //{
                AppPanelScopeBox.ShowScopeBox();
                UpdateDataGridView(doc);
            //}
            return Result.Succeeded;
        }

        public void UpdateDataGridView(Document doc)
        {           
            var listViewPlan = new FilteredElementCollector(doc).OfClass(typeof(ViewPlan)).Cast<ViewPlan>().ToList();           
            foreach (var item  in listViewPlan.OrderBy(x => x.ViewType + "/Name: " + x.Name))
            {
                var row = new string[] { item.ViewType + "/Name: " + item.Name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelScopeBox.myFormScopeBox.listViewViewScopeBox.Items.Add(lvi);
            }
            var listScopeBox = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_VolumeOfInterest).WhereElementIsNotElementType().ToList();
            foreach (var item in listScopeBox.OrderBy(x=>x.Name))
            {
                var row = new string[] { item.Name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelScopeBox.myFormScopeBox.listViewScopeBox.Items.Add(lvi);
            }
        }
    }

   
}
