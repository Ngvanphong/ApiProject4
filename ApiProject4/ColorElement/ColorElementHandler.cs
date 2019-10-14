
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Drawing;
using System;
using ApiProject4.Helper;

namespace ApiProject4.ColorElement
{
    public class ColorElementHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            if (AppPenalColorElement.SetColor == true)
            {
                foreach (var elval in AppPenalColorElement.ListElementValue)
                {
                    using (Transaction t = new Transaction(doc, "setColor"))
                    {
                        t.Start();
                        try
                        {
                            Autodesk.Revit.DB.Color color = null;
                            foreach (var co in AppPenalColorElement.ListValueColor)
                            {
                                if (co.Value == elval.Value)
                                {
                                    color = co.Color;
                                    break;
                                }
                            }
                            SetColorElement.SetColor(color, doc, elval.Element);
                            t.Commit();
                        }
                        catch { t.RollBack(); continue; }

                    }
                }
            } else if(AppPenalColorElement.SetColor == false)
            {
                OverrideGraphicSettings orGsty = new OverrideGraphicSettings();  
                foreach (var elval in AppPenalColorElement.ListElementValue)
                {
                    using (Transaction t2 = new Transaction(doc, "ResetColor"))
                    {
                        t2.Start();
                        try
                        {
                            doc.ActiveView.SetElementOverrides(elval.Element.Id, orGsty);
                            t2.Commit();
                        }
                        catch { t2.RollBack(); continue; }
                    }
                }
            }            
        }

        public string GetName()
        {
            return "ColorElementHandlers";
        }
       
    }
    public static class SetColorElement
    {
        public static void SetColor(Autodesk.Revit.DB.Color color, Document doc, Element element)
        {
            var pSolidFillPattern = new FilteredElementCollector(doc).OfClass((typeof(FillPatternElement)))
                   .OfType<FillPatternElement>().Where<FillPatternElement>(p => p.GetFillPattern().IsSolidFill).ToList().First();
            OverrideGraphicSettings setting = new OverrideGraphicSettings();
            setting.SetSurfaceForegroundPatternColor(color);
            setting.SetSurfaceForegroundPatternId(pSolidFillPattern.Id);
            setting.SetCutForegroundPatternId(pSolidFillPattern.Id);
            setting.SetCutForegroundPatternColor(color);
            setting.SetSurfaceForegroundPatternVisible(true);
            setting.SetCutForegroundPatternVisible(true);
            setting.SetSurfaceTransparency(0);
            doc.ActiveView.SetElementOverrides(element.Id, setting);
        }
    }
    
}


