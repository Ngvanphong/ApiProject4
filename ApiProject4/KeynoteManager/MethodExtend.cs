using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiProject4.KeynoteManager
{
    public static class MethodExtend
    {
        public static bool CheckParentAndId(List<KeynoteEntry> entryTables, string parentId, string id)
        {
            bool result = true;
            foreach (KeynoteEntry entry in entryTables)
            {
            
                if (parentId != string.Empty && parentId != "" && parentId != null)
                {
                    if (!entryTables.Exists(x => x.Key == parentId))
                    {
                        result = false;
                        MessageBox.Show("Error: ParentId not found. You must input parent id agian.");
                        return result;
                    }
                }

                if (entryTables.Exists(x => x.Key == id))
                {
                    result = false;
                    MessageBox.Show("Error: Id is existed. You must input id again.");
                    return result;
                }
            }
            return result;
        }
       
    }
}
