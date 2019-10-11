using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiProject4.Helper;

namespace ApiProject4.ColorElement
{
    public class ValueParamrterHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            ColorCreate colorCreateNot = new ColorCreate();
            List<ElementValue> listElementValue = colorCreateNot.GetElementValue();
            AppPenalColorElement.ListElementValue = listElementValue;
            List<string> listValue = new List<string>();
            foreach (var el in listElementValue)
            {
                if (!listValue.Exists(x => x == el.Value))
                {
                    listValue.Add(el.Value);
                }
            }
            listValue=listValue.OrderBy(x => x).ToList();
            ColorCreate colorCreateHas = new ColorCreate(listValue);
            List<ValueColor> listValueColor = colorCreateHas.GetColorValueDefault();
            AppPenalColorElement.ListValueColor = listValueColor;
        }

        public string GetName()
        {
            return "ValueParameterLoads";
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
            List<System.Drawing.Color> colors = new ColorSystem().ColorUser;
            List<ValueColor> listValueColor = new List<ValueColor>();
            int i = 0;
            foreach (string val in ListValue)
            {
                ValueColor valueColor = new ValueColor();
                valueColor.Value = val;
                System.Drawing.Color colorWin = colors[i];
                valueColor.Color = new Autodesk.Revit.DB.Color(colorWin.R, colorWin.G, colorWin.B);
                listValueColor.Add(valueColor);
                if (i < 20)
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
