using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ApiProject4.ScopeBox
{
    public class ScopeBoxHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var listItemView = AppPanelScopeBox.myFormScopeBox.listViewViewScopeBox.CheckedItems;
            List<ViewPlan> listViewPlan = new FilteredElementCollector(doc).OfClass(typeof(ViewPlan)).Cast<ViewPlan>().ToList();
            List<ViewPlan> listViewAdd = new List<ViewPlan>();
            foreach(ListViewItem item in listItemView)
            {
                var viewName = item.Text;
                foreach(var view in listViewPlan)
                {
                    var name= view.ViewType + "/Name: " + view.Name;
                    if (viewName == name)
                    {
                        listViewAdd.Add(view);
                    }
                }
            }

            var listScopeBox = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_VolumeOfInterest).WhereElementIsNotElementType().ToList();
            var listItemScope = AppPanelScopeBox.myFormScopeBox.listViewScopeBox.CheckedItems;
            Element scopeBox = null;
            foreach(ListViewItem item in listItemScope)
            {
                var name = item.Text;
                foreach(var scope in listScopeBox)
                {
                    if (name == scope.Name)
                    {
                        scopeBox = scope;
                        break;
                    }
                }
            }
            foreach(var viewAd in listViewAdd)
            {
                using(Transaction t= new Transaction(doc, "AssignScopeBox"))
                {
                    t.Start();
                    viewAd.get_Parameter(BuiltInParameter.VIEWER_VOLUME_OF_INTEREST_CROP).Set(scopeBox.Id);
                    t.Commit();
                }
            }

        }

        public string GetName()
        {
            return "ScopeBoxHandler";
        }
    }
}
