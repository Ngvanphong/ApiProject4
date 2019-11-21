using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using ApiProject4.Helper;

namespace ApiProject4.KeynoteManager
{
    [Transaction(TransactionMode.Manual)]
    public class KeynoteManagerBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //if (CheckAccess.CheckLicense() == true)
            //{
                GetInformation.GetFileKeynote(doc);
                AppPenalKeynoteManager.ShowKeynoteManager();
                GetInformation.InformationDrop();

            //}
            return Result.Succeeded;
        }
    }

    public static class GetInformation
    {
        public static void GetFileKeynote(Document doc)
        {
            KeynoteTable knTable = Autodesk.Revit.DB.KeynoteTable.GetKeynoteTable(doc);
            var folder = KeynoteTable.GetKeynoteTable(doc).GetExternalResourceReference(ExternalResourceTypes.BuiltInExternalResourceTypes.KeynoteTable);
            var path = folder.InSessionPath;
            AppPenalKeynoteManager.pathTextNoteFile = path;
            var entryTable = knTable.GetKeyBasedTreeEntries();
            List<KeynoteEntry> listEntry = new List<KeynoteEntry>();
            foreach(var item in entryTable)
            {
                KeynoteEntry entry = item as KeynoteEntry;
                if (entry != null) listEntry.Add(entry);
            }
            AppPenalKeynoteManager.entryTableKeynote = listEntry;
           
        }
        public static void InformationDrop()
        {
            SearchItem item = new SearchItem();
            string[] sources = { item.ParentId, item.Id };
            AppPenalKeynoteManager.myFormKeynoteManager.comboBoxSearchKeynote.Items.AddRange(sources);
            AppPenalKeynoteManager.myFormKeynoteManager.comboBoxSearchKeynote.SelectedItem = item.ParentId;
            TypeKeynote type = new TypeKeynote();
            string[] sourcesType = { type.ElementKeynote, type.MaterialKeynote,type.UserKeynote };
            AppPenalKeynoteManager.myFormKeynoteManager.dropChangeTypeKeynote.Items.AddRange(sourcesType);
            AppPenalKeynoteManager.myFormKeynoteManager.dropChangeTypeKeynote.SelectedItem = type.ElementKeynote;
        }
    }
    public class SearchItem
    {
        public string Id { get { return "Id"; } }
        public string ParentId { get { return "ParentId"; } }
    }
    public class TypeKeynote
    {
        public string ElementKeynote { get { return "Element Keynote"; } }
        public string MaterialKeynote { get { return "Material Keynote"; } }
        public string UserKeynote { get { return "User Keynote"; } }
    }
}
