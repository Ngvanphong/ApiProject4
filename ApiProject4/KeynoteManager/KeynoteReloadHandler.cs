using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Subro.Controls;
using Autodesk.Revit.UI;
using System.IO;

namespace ApiProject4.KeynoteManager
{
    public class KeynoteReloadHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            int count = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.RowCount;
            string newLine = string.Empty;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    var id = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[i].Cells[1].Value.ToString();
                    var parentId = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[i].Cells[0].Value.ToString();
                    var discription = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[i].Cells[2].Value.ToString();
                        if (newLine == string.Empty)
                        {
                            newLine = id + "\t" + discription + "\t" + parentId + "\t";
                        }
                        else
                        {
                            newLine = newLine + "\n" + id + "\t" + discription + "\t" + parentId + "\t";
                        }
                }
                catch { continue; }
            }

            using (StreamWriter sw = File.CreateText(AppPenalKeynoteManager.pathTextNoteFile))
            {
                sw.WriteLine(newLine);
            }
            using (Transaction t= new Transaction(doc, "ReloadKeynote"))
            {
                t.Start();
                KeynoteTable.GetKeynoteTable(doc).Reload(null);
                t.Commit();
            }
            GetInformation.GetFileKeynote(doc);
        }

        public string GetName()
        {
            return "ReloadKeynoteHandler";
        }
    }
}
