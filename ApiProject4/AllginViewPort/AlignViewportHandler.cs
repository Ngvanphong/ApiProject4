using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;

namespace ApiProject4.AllginViewPort
{
    public class AlignViewportHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var selectionIds = app.ActiveUIDocument.Selection.GetElementIds();
            Viewport viewPortChoose = null;
            foreach (ElementId id in selectionIds)
            {
                Element elementChoose = doc.GetElement(id);
                try
                {
                    viewPortChoose = elementChoose as Viewport;
                }
                catch { continue; }
            }
            if (viewPortChoose == null)
            {
                MessageBox.Show("Error: you must chose a view on sheet.");
                return;
            }
            var listItemChoose = AppPenalAlignViewport.myFromAlignViewport.listViewChooseSheet.CheckedItems;
            List<ViewSheet> listAllSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
            List<ViewSheet> listSheetChoose = new List<ViewSheet>();
            List<Viewport> listAlginView = new List<Viewport>();
            foreach (ListViewItem viewItem in listItemChoose)
            {
                foreach (ViewSheet sheet in listAllSheet)
                {
                    if (sheet.SheetNumber == viewItem.Text)
                    {
                        listSheetChoose.Add(sheet);
                        break;
                    }
                }
            }
            Autodesk.Revit.DB.View viewOrigin = doc.GetElement(viewPortChoose.ViewId) as Autodesk.Revit.DB.View;
            if (viewOrigin.ViewType == ViewType.Legend)
            {
                foreach (ViewSheet sheet in listSheetChoose)
                {
                    try
                    {
                        Viewport viewPortAlign = getViewportOnSheet(doc, sheet, viewOrigin);
                        using (Transaction t3 = new Transaction(doc, "AlignViewLegend"))
                        {
                            t3.Start();
                            viewPortAlign.SetBoxCenter(viewPortChoose.GetBoxCenter());
                            t3.Commit();
                        }
                    }
                    catch { continue; }

                }
            }
            else
            {
                BoundingBoxXYZ box = new BoundingBoxXYZ();
                box.Min = viewOrigin.CropBox.Min;
                box.Max = viewOrigin.CropBox.Max;
                using (Transaction t2 = new Transaction(doc, "ShowLine"))
                {
                    t2.Start();
                    viewOrigin.CropBoxActive = true;
                    viewOrigin.CropBoxVisible = true;
                    t2.Commit();
                }
                foreach (ViewSheet sheet in listSheetChoose)
                {
                    try
                    {
                        Viewport viewPortAlign = getViewportOnSheet(doc, sheet, viewOrigin);
                        Autodesk.Revit.DB.View viewAlgin = doc.GetElement(viewPortAlign.ViewId) as Autodesk.Revit.DB.View;
                        BoundingBoxXYZ boxOld = new BoundingBoxXYZ();
                        boxOld.Min = viewAlgin.CropBox.Min;
                        boxOld.Max = viewAlgin.CropBox.Max;
                        using (Transaction t = new Transaction(doc, "AlignViewPorts"))
                        {
                            t.Start();
                            viewAlgin.CropBoxActive = true;
                            viewAlgin.CropBoxVisible = true;
                            viewAlgin.CropBox = box;
                            viewPortAlign.SetBoxCenter(viewPortChoose.GetBoxCenter());
                            viewAlgin.CropBox = boxOld;
                            t.Commit();
                        }
                    }
                    catch { continue; }
                }
            }
        }

        public string GetName()
        {
            return "AlignViewportHandler";
        }

        public Viewport getViewportOnSheet(Document doc, ViewSheet sheet, Autodesk.Revit.DB.View viewOrigin)
        {
            ViewType type = viewOrigin.ViewType;
            Viewport result = null;
            var viewPortIds = sheet.GetAllViewports();
            foreach (ElementId id in viewPortIds)
            {
                Viewport viewPort = doc.GetElement(id) as Viewport;
                Autodesk.Revit.DB.View view = doc.GetElement(viewPort.ViewId) as Autodesk.Revit.DB.View;
                if (type == ViewType.Legend)
                {
                    if (view.ViewType == ViewType.Legend&&viewOrigin.Name==view.Name)
                    {
                        result = viewPort;
                        return result;
                    }
                }
                if ((type == ViewType.AreaPlan || type == ViewType.CeilingPlan || type == ViewType.FloorPlan))
                {    
                    if ((view.ViewType == ViewType.AreaPlan || view.ViewType == ViewType.CeilingPlan || view.ViewType == ViewType.FloorPlan) && view.Scale == viewOrigin.Scale)
                    {
                        result = viewPort;
                        return result;
                    }
                }
                if (type == ViewType.Section || type == ViewType.Elevation)
                {   
                    if ((view.ViewType == ViewType.Section || view.ViewType == ViewType.Elevation) && view.Scale == viewOrigin.Scale)
                    {
                        result = viewPort;
                        return result;
                    }
                }
            }
            return result;
        }

    }


}
