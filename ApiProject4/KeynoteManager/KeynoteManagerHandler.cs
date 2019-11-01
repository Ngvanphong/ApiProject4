using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Subro.Controls;
using System.Windows.Forms;

namespace ApiProject4.KeynoteManager
{
    public class KeynoteManagerHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            string value = string.Empty;
            value = AppPenalKeynoteManager.myFormKeynoteManager.textBoxSearchKeynote.Text;
            string type = AppPenalKeynoteManager.myFormKeynoteManager.comboBoxSearchKeynote.SelectedItem.ToString();
            SearchItem itemSearch = new SearchItem();
            int count = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.RowCount;

            if (itemSearch.ParentId == type)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        string parentId = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[i].Cells[0].Value.ToString();
                        if (parentId == value)
                        {
                            AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.FirstDisplayedScrollingRowIndex = i;
                            AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[i].Selected = true;
                            break;
                        }
                    }
                    catch { continue; }
                   
                }
            }
            else if (itemSearch.Id == type)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        string Id = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[i].Cells[1].Value.ToString();
                        if (Id == value)
                        {
                            AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.FirstDisplayedScrollingRowIndex = i;
                            AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[i].Selected = true;
                            break;
                        }
                    }
                    catch { continue; }
                   
                }

            }


        }

        public string GetName()
        {
            return "KeynoteManagerHandlers";
        }
    }
}
