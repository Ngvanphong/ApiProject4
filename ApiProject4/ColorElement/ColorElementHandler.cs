
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
            ColorCreate colorCreateNot = new ColorCreate();
            List<ElementValue> listElementColor = colorCreateNot.GetElementValue();
            List<string> listValue = new List<string>();
            foreach(var el in listElementColor)
            {
                if (!listValue.Exists(x => x == el.Value))
                {
                    listValue.Add(el.Value);
                }
            }
            listValue.OrderBy(x => x);
            ColorCreate colorCreateHas = new ColorCreate(listValue);
            List<ValueColor> listValueColor = colorCreateHas.GetColorValueDefault();
            foreach(var elclor in listElementColor)
            {
                using (Transaction t = new Transaction(doc, "setColor"))
                {
                    t.Start();
                    try
                    {
                        Autodesk.Revit.DB.Color color = null;
                        foreach(var co in listValueColor)
                        {
                            if (co.Value == elclor.Value)
                            {
                                color = co.Color;
                                break;
                            }
                        }
                        SetColor(color, doc, elclor.Element);
                        t.Commit();
                    }
                    catch { t.RollBack(); continue; }
                    
                }
            }
 
        }

        public string GetName()
        {
            return "ColorElementHandlers";
        }
        public void SetColor(Autodesk.Revit.DB.Color color, Document doc,Element element)
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
    public class ColorCreate
    {
        public List<string> ListValue { set; get; }
        public ColorCreate()
        {

        }
        public ColorCreate(List<string> listValue)
        {
            ListValue = listValue;
        }
       
        public List<ValueColor> GetColorValueDefault()
        {
            List<System.Drawing.Color> colors = Enum.GetValues(typeof(KnownColor)).Cast<KnownColor>().Select(System.Drawing.Color
            .FromKnownColor).ToList();
            List<ValueColor> listValueColor = new List<ValueColor>();
            int i = 0;
            foreach (string val in ListValue)
            {
                ValueColor valueColor = new ValueColor();
                valueColor.Value = val;
                System.Drawing.Color colorWin = colors[i];
                valueColor.Color = new Autodesk.Revit.DB.Color(colorWin.R, colorWin.G, colorWin.B);
                listValueColor.Add(valueColor);
                if (i < 254)
                {
                    i++;
                }
                else
                {
                    i--;
                }
            }
            return listValueColor;
        }

        public List<ElementValue> GetElementValue()
        {
            List<ElementValue> listResult = new List<ElementValue>();
            string nameParameter = AppPenalColorElement.myFormColorElement.listBoxParameter.SelectedItem.ToString();
            foreach (Element el in AppPenalColorElement.listElementCate)
            {
                foreach (Parameter parae in el.Parameters)
                {
                    if (parae.Definition.Name == nameParameter)
                    {
                        ElementValue elementValue = new ElementValue();
                        elementValue.Element = el;
                        elementValue.Value = ParameterRevit.ParameterToString(parae);
                        listResult.Add(elementValue);
                    }
                }
            }
            return listResult;
        }
    }
    public class ElementValue
    {
        public Element Element { set; get; }
        public string Value { set; get; }
    }
    public class ValueColor
    {
        public string Value { set; get; }
        public Autodesk.Revit.DB.Color Color { set; get; }
    }
}


