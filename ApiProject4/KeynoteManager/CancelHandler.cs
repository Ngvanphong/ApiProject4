using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject4.KeynoteManager
{
    public class CancelHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            var commandMonitor = new RevitCommandEndedMonitor(app);
            try
            {
                UpdaterRegistry.UnregisterUpdater(AppPenalKeynoteManager._updater.GetUpdaterId());
                AppPenalKeynoteManager._updater = null;
            }
            catch { AppPenalKeynoteManager._updater = null; }
        }
        public string GetName()
        {
            return "DisableDialogCancel";
        }
    }

    


}
