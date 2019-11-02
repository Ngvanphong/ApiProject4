using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Subro.Controls;
using System.Windows.Forms;
using Autodesk.Revit.UI.Selection;
using System.Collections.ObjectModel;

namespace ApiProject4.KeynoteManager
{
    public class KeynoteManagerHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            int row = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.CurrentRow.Index;
            string id = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[row].Cells[1].Value.ToString();
            //Element elementTag = null;
            //Reference refTag = null;
            var collectSymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_KeynoteTags).ToElements();
            ICollection<ElementId> collectionSet = new Collection<ElementId>();
            KeynoteEntry entry = null;
            foreach(var item in AppPenalKeynoteManager.entryTableKeynote)
            {
                if (item.Key == id)
                {
                    entry = item;
                    break;
                }
            }
            if (collectSymbol.Count == 0)
            {
                MessageBox.Show("You must load family of keynote.");
                return;
            }
            FamilySymbol symbol = collectSymbol.First() as FamilySymbol;
            //XYZ point = null;
            //try
            //{
            //    refTag = app.ActiveUIDocument.Selection.PickObject(ObjectType.Element);
            //    elementTag = doc.GetElement(refTag);
            //}
            //catch { }
            //if (elementTag == null)
            //{
            //    MessageBox.Show("You must chosse element to assgin keynote");
            //    return;
            //}
            //try
            //{
            //    point = app.ActiveUIDocument.Selection.PickPoint();
            //}
            //catch { }
            //if (point == null)
            //{
            //    MessageBox.Show("You must chosse point on view");
            //    return;
            //}
            Autodesk.Revit.DB.View view = doc.ActiveView;
            using (Transaction t = new Transaction(doc, "Create WorkPlane"))
            {
                t.Start();
                Plane plane = Plane.CreateByNormalAndOrigin(doc.ActiveView.ViewDirection, doc.ActiveView.Origin);
                SketchPlane sp = SketchPlane.Create(doc, plane);
                doc.ActiveView.SketchPlane = sp;
                t.Commit();

            }

            TagOrientation tagorn = TagOrientation.Horizontal;
            using(Transaction t2= new Transaction(doc, "createKeynote"))
            {
                t2.Start();
                try
                {
                    RevitCommandId id_built_in;
                    id_built_in = RevitCommandId.LookupPostableCommandId(PostableCommand.UserKeynote);
                    app.PostCommand(id_built_in);

                }
                catch(Exception ex) { }
               
                t2.Commit();
            }
        }

        public string GetName()
        {
            return "KeynoteManagerHandlers";
        }

    }
}
