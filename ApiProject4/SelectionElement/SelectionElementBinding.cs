using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiProject4.Helper;
using Autodesk.Revit.UI.Selection;

namespace ApiProject4.SelectionElement
{
    [Transaction(TransactionMode.Manual)]
    public class SelectionElementBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //if (CheckAccess.CheckLicense() == true)
            //{
               try
                {
                    List<Element> listAll = new List<Element>();
                    List<Element> listSimilar = new List<Element>();
                    List<ElementId> listSelectIds = new List<ElementId>();
                    var selectionIds = uiApp.ActiveUIDocument.Selection.GetElementIds();
                    if (selectionIds == null)
                    {
                       return Result.Succeeded;
                    }
                    
                    if (selectionIds.Count <= 3)
                    {
                        foreach (ElementId id in selectionIds)
                        {
                            Element el = doc.GetElement(id);
                            listSimilar.Add(el);
                        }
                        var listElements = uiApp.ActiveUIDocument.Selection.PickElementsByRectangle();
                        foreach(Element ele in listElements)
                        {
                            try
                            {
                                if (listSimilar.Exists(x => x.Category.Name == ele.Category.Name))
                                {
                                    if(listSimilar.Exists(x => x.Name == ele.Name))
                                    {
                                        listSelectIds.Add(ele.Id);
                                    }
                                }
                            }
                            catch { continue; }
                        }

                    }
                    else
                    {
                        foreach (ElementId id in selectionIds)
                        {
                            Element el = doc.GetElement(id);
                            listAll.Add(el);
                        }
                        var refer = uiApp.ActiveUIDocument.Selection.PickObject(ObjectType.Element);
                        Element element = doc.GetElement(refer);
                        foreach (var  ele in listAll)
                        {
                            try
                            {
                                if (ele.Category.Name == element.Category.Name)
                                {
                                    if ( element.Name == ele.Name)
                                    {
                                        listSelectIds.Add(ele.Id);
                                    }
                                }
                            }
                            catch { continue; }
                        }

                    }
                    uiApp.ActiveUIDocument.Selection.SetElementIds(listSelectIds);
                    
                }
                catch {}
            //}
            return Result.Succeeded;
        }
    }
}
