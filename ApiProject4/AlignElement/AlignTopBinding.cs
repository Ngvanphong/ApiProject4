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

namespace ApiProject4.AlignElement
{
    [Transaction(TransactionMode.Manual)]
    public class AlignTopBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //if (CheckAccess.CheckLicense() == true)
            //{
                var selectionIds = uiApp.ActiveUIDocument.Selection.GetElementIds();
                List<IndependentTag> listTags = new List<IndependentTag>();
                foreach (ElementId id in selectionIds)
                {
                    Element el = doc.GetElement(id);
                    IndependentTag tag = null;
                    tag = el as IndependentTag;
                    if (tag != null)
                    {
                        listTags.Add(tag);
                    }
                }
                if (listTags.Count() > 0)
                {
                    TagAllgin(doc, listTags);
                }
            //}
            return Result.Succeeded;
        }
        private void TagAllgin(Document doc, List<IndependentTag> listTags)
        {
            XYZ location = listTags.First().TagHeadPosition;
            var id = listTags.First().OwnerViewId;
            View view = doc.GetElement(id) as View;
            var vUp = view.UpDirection;
            foreach (IndependentTag tag in listTags)
            {
                using (Transaction t = new Transaction(doc, "AlginTopTag"))
                {
                    t.Start();
                    XYZ locationOld = tag.TagHeadPosition;
                    XYZ newLocation = null;
                    if (vUp.IsAlmostEqualTo(XYZ.BasisX) || vUp.IsAlmostEqualTo(-XYZ.BasisX))
                    {
                        newLocation = new XYZ(location.X, locationOld.Y, locationOld.Z);
                    }
                    else if (vUp.IsAlmostEqualTo(XYZ.BasisY) || vUp.IsAlmostEqualTo(-XYZ.BasisY))
                    {
                        newLocation = new XYZ(locationOld.X, location.Y, locationOld.Z);
                    }
                    else if (vUp.IsAlmostEqualTo(XYZ.BasisZ) || vUp.IsAlmostEqualTo(-XYZ.BasisZ))
                    {
                        newLocation = new XYZ(locationOld.X, locationOld.Y, location.Z);
                    }
                    if (newLocation != null)
                    {
                        tag.TagHeadPosition = newLocation;
                    }
                    t.Commit();
                }
            }
        }
    }
}
