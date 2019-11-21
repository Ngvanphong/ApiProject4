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
    public class ArrangeBinding : IExternalCommand
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
                    ArrangeTag(doc, listTags);
                }
            //}
            return Result.Succeeded;
        }

        public void ArrangeTag(Document doc, List<IndependentTag> listTags)
        {
            var tagCurrent = listTags.First();
            View view = doc.GetElement(tagCurrent.OwnerViewId) as View;
            var vRight = view.RightDirection;
            double offset = Constant.distance;
            double scale = double.Parse(view.Scale.ToString())/100;
            offset = offset * scale;
            if (vRight.IsAlmostEqualTo(XYZ.BasisX) || vRight.IsAlmostEqualTo(-XYZ.BasisX))
            {
                listTags = listTags.OrderByDescending(x => x.TagHeadPosition.Y).OrderBy(x => x.TagHeadPosition.X).ToList();
                XYZ newLocation = null;
                int middle = int.Parse(Math.Floor(decimal.Parse((listTags.Count() / 2).ToString())).ToString());
                XYZ point1 = listTags[middle - 1].TagHeadPosition;
                XYZ point2 = listTags[middle].TagHeadPosition;
                double dx = Math.Abs(point1.X - point2.X) / 2;
                for (int i = middle - 1; i >= 0; i--)
                {
                    if (i != middle - 1)
                    {
                        var locationBefore = listTags[i + 1].TagHeadPosition;
                        var locationContinue = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationBefore.X - offset, locationContinue.Y, locationContinue.Z);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }
                    else if (i == middle - 1)
                    {
                        var locationBefore = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationBefore.X + dx - offset / 2, locationBefore.Y, locationBefore.Z);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }

                }
                for (int i = middle; i < listTags.Count(); i++)
                {
                    if (i != middle)
                    {
                        var locationBefore = listTags[i - 1].TagHeadPosition;
                        var locationContinue = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationBefore.X + offset, locationContinue.Y, locationContinue.Z);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }
                    else if (i == middle)
                    {
                        var locationBefore = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationBefore.X - dx + offset / 2, locationBefore.Y, locationBefore.Z);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }
                }

            }
            else if (vRight.IsAlmostEqualTo(XYZ.BasisY) || vRight.IsAlmostEqualTo(-XYZ.BasisY))
            {
                listTags = listTags.OrderByDescending(x => x.TagHeadPosition.X).OrderBy(x => x.TagHeadPosition.Y).ToList();
                XYZ newLocation = null;
                int middle = int.Parse(Math.Floor(decimal.Parse((listTags.Count() / 2).ToString())).ToString());
                XYZ point1 = listTags[middle - 1].TagHeadPosition;
                XYZ point2 = listTags[middle].TagHeadPosition;
                double dy = Math.Abs(point1.Y - point2.Y) / 2;
                for (int i = middle - 1; i >= 0; i--)
                {
                    if (i != middle - 1)
                    {
                        var locationBefore = listTags[i + 1].TagHeadPosition;
                        var locationContinue = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationContinue.X, locationBefore.Y - offset, locationContinue.Z);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }
                    else if (i == middle - 1)
                    {
                        var locationBefore = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationBefore.X, locationBefore.Y + dy - offset / 2, locationBefore.Z);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }

                }
                for (int i = middle; i < listTags.Count(); i++)
                {
                    if (i != middle)
                    {
                        var locationBefore = listTags[i - 1].TagHeadPosition;
                        var locationContinue = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationContinue.X, locationBefore.Y + offset, locationContinue.Z);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }
                    else if (i == middle)
                    {
                        var locationBefore = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationBefore.X, locationBefore.Y - dy + offset / 2, locationBefore.Z);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }
                }
            }
            else if (vRight.IsAlmostEqualTo(XYZ.BasisZ) || vRight.IsAlmostEqualTo(-XYZ.BasisZ))
            {
                listTags = listTags.OrderBy(x => x.TagHeadPosition.Z).ToList();
                XYZ newLocation = null;
                int middle = int.Parse(Math.Floor(decimal.Parse((listTags.Count() / 2).ToString())).ToString());
                XYZ point1 = listTags[middle - 1].TagHeadPosition;
                XYZ point2 = listTags[middle].TagHeadPosition;
                double dz = Math.Abs(point1.Z - point2.Z) / 2;
                for (int i = middle - 1; i >= 0; i--)
                {
                    if (i != middle - 1)
                    {
                        var locationBefore = listTags[i + 1].TagHeadPosition;
                        var locationContinue = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationContinue.X, locationContinue.Y, locationBefore.Z - offset);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }
                    else if (i == middle - 1)
                    {
                        var locationBefore = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationBefore.X, locationBefore.Y, locationBefore.Z + dz - offset / 2);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }

                }
                for (int i = middle; i < listTags.Count(); i++)
                {
                    if (i != middle)
                    {
                        var locationBefore = listTags[i - 1].TagHeadPosition;
                        var locationContinue = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationContinue.X, locationContinue.Y, locationBefore.Z + offset);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }
                    else if (i == middle)
                    {
                        var locationBefore = listTags[i].TagHeadPosition;
                        using (Transaction t = new Transaction(doc, "ArragneLeftTag"))
                        {
                            t.Start();
                            newLocation = new XYZ(locationBefore.X, locationBefore.Y, locationBefore.Z - dz + offset / 2);
                            listTags[i].TagHeadPosition = newLocation;
                            t.Commit();
                        }
                    }
                }

            }         
        }
    }
}
