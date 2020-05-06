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
    public class KeynoteManagerHandler : DefaultValueKeynote
    {

    }
    public class ElevationWatcherUpdaterKeynote : IUpdater
    {
        static AddInId _appId;
        static UpdaterId _updaterId;
        public ElevationWatcherUpdaterKeynote(AddInId id)
        {
            _appId = id;
            _updaterId = new UpdaterId(_appId, new Guid("8a5b141a-cd9e-4c12-9f99-168c3ddb1de9"));
        }

        public static bool breakEvent = false;
        public void Execute(UpdaterData data)
        {
            Document doc = data.GetDocument();
            Autodesk.Revit.ApplicationServices.Application app = doc.Application;
            var listElementIdAdd = data.GetAddedElementIds().ToList();
            if (listElementIdAdd.Count == 1)
            {
                CreateKeynote(doc, listElementIdAdd.First());
            }
        }

        public string GetAdditionalInformation()
        {
            return "ngvanphong2012@gmail.com";
        }

        public UpdaterId GetUpdaterId()
        {
            return _updaterId;
        }

        public string GetUpdaterName()
        {
            return "KeynoteManager";
        }

        public ChangePriority GetChangePriority()
        {
            return ChangePriority.Annotations;
        }

        void CreateKeynote(Document doc, ElementId elementId)
        {
            int row = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.CurrentRow.Index;
            string id = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[row].Cells[1].Value.ToString();
            Element el = doc.GetElement(elementId);
            Parameter para = el.LookupParameter("Key Value");
            para.Set(id);
        }
    }
}
