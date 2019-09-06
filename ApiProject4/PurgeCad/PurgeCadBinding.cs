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

namespace ApiProject4.PurgeCad
{
    [Transaction(TransactionMode.Manual)]
    public class PurgeCadBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                var fileredCad = new FilteredElementCollector(doc).OfClass(typeof(ImportInstance)).Cast<ImportInstance>().Where(i => i.IsLinked == false).ToList();
                foreach(var item in fileredCad)
                {
                    using(Transaction t= new Transaction(doc, "DeleteCad"))
                    {
                        t.Start();
                        try
                        {
                            doc.Delete(item.Id);
                            t.Commit();
                        }
                        catch
                        {
                            t.Commit();
                            continue;
                        }
                        
                    }
                }
                MessageBox.Show("Purging cad is finished");
            }
            return Result.Succeeded;
        }  
    }
}
