using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;

namespace ApiProject4.KeynoteManager
{
    public class EditKeynoteHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            try
            {
                var elementId = app.ActiveUIDocument.Selection.GetElementIds().First();
                Element element = doc.GetElement(elementId);
                int row = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.CurrentRow.Index;
                string id = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[row].Cells[1].Value.ToString();
                using(Transaction t3= new Transaction(doc, "EditKeynote"))
                {
                    t3.Start();
                    try
                    {
                        Parameter para = element.LookupParameter("Key Value");
                        para.Set(id);
                        t3.Commit();
                    }
                    catch
                    {
                        t3.Commit();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error: You must choose a keynote");
            }
        }

        public string GetName()
        {
            return "EditKeynoteHandler";
        }
    }
}
