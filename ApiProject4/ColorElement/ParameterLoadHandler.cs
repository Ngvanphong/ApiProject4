using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace ApiProject4.ColorElement
{
    public class ParameterLoadHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            AppPenalColorElement.myFormColorElement.listBoxParameter.Items.Clear();
            Document doc = app.ActiveUIDocument.Document;
            var categoryChecked = AppPenalColorElement.myFormColorElement.listBoxCategory.SelectedItem.ToString();
            List<Element> listElementAll = new FilteredElementCollector(doc,doc.ActiveView.Id).ToElements().ToList();
            List<ElementType> listType = new List<ElementType>();
            List<Element> listElementChoose = new List<Element>();
            List<Element> listElementCatego = new List<Element>();
            foreach (Element el in listElementAll)
            {
                try
                {
                    if (el.Category.Name == categoryChecked)
                    {
                        listElementCatego.Add(el);
                        ElementType elmentTyp = doc.GetElement(el.GetTypeId()) as ElementType;
                        if (!listType.Exists(x =>x.Name == elmentTyp.Name))
                        {
                            listType.Add(elmentTyp);
                            listElementChoose.Add(el);
                        }
                    }
                }
                catch { continue; }
            }
            AppPenalColorElement.listElementCate = listElementCatego;
            List<string> listParameterName = new List<string>();
            foreach (Element element in listElementChoose)
            {
                foreach (Parameter parae in element.Parameters)
                {
                    string name = parae.Definition.Name;
                    if (!listParameterName.Exists(x => x == name))
                    {
                        listParameterName.Add(name);
                    }
                }
            }
            foreach (string name in listParameterName.OrderBy(x=>x))
            {
                AppPenalColorElement.myFormColorElement.listBoxParameter.Items.Add(name);
            }
        }

        public string GetName()
        {
            return "ParameterLoadhaler";
        }
    }
}
