using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;

namespace ApiProject4.ColorElement
{
    public class UpdateAllHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var categoryChecked = AppPenalColorElement.myFormColorElement.listBoxCategory.SelectedItem.ToString();
            List<Element> listElementAll = new FilteredElementCollector(doc, doc.ActiveView.Id).ToElements().ToList();
            List<Element> listElementCatego = new List<Element>();
            foreach (Element el in listElementAll)
            {
                try
                {
                    if (el.Category.Name == categoryChecked)
                    {
                        listElementCatego.Add(el);
                    }
                }
                catch { continue; }
            }
            AppPenalColorElement.listElementCate = listElementCatego;

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
            listValue = listValue.OrderBy(x => x).ToList();
            ColorCreate colorCreateHas = new ColorCreate(listValue);
            List<ValueColor> listValueColor = colorCreateHas.GetColorValueDefault();
            AppPenalColorElement.ListValueColor = listValueColor;
            BindingSource bindingSource = new BindingSource();
            foreach (var value in listValueColor)
            {
                bindingSource.Add(new { value.Value });
            }
            AppPenalColorElement.myFormColorElement.dataGridViewValueParameter.DataSource = bindingSource;
            for (int i = 0; i < AppPenalColorElement.myFormColorElement.dataGridViewValueParameter.Rows.Count; i++)
            {
                AppPenalColorElement.myFormColorElement.dataGridViewValueParameter.Rows[i].DefaultCellStyle.BackColor = listValueColor[i].ColorSystem;
            }

        }

        public string GetName()
        {
            return "UpdateAllHandler";
        }
    }
}
