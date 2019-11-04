using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Events;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Threading;

namespace ApiProject4.KeynoteManager
{
    public abstract class DefaultValueKeynote : IExternalEventHandler
    {

        private void PostCommand(UIApplication revitUiApplication, PostableCommand PostableCommand)
        {
            var commandMonitor = new RevitCommandEndedMonitor(revitUiApplication);
            revitUiApplication.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand));
        }


        public void Execute(UIApplication app)
        {
            TypeKeynote type = new TypeKeynote();
            string typeKe = AppPenalKeynoteManager.myFormKeynoteManager.dropChangeTypeKeynote.SelectedItem.ToString();
            PostableCommand postCommand = PostableCommand.ElementKeynote;
            if (typeKe == type.UserKeynote)
            {
                postCommand = PostableCommand.UserKeynote;
            }
            else if (typeKe == type.MaterialKeynote)
            {
                postCommand = PostableCommand.MaterialKeynote;
            }
            PostCommand(app, postCommand);
            if (AppPenalKeynoteManager._updater == null)
            {
                AppPenalKeynoteManager._updater = new ElevationWatcherUpdaterKeynote(app.ActiveAddInId);
                UpdaterRegistry.RegisterUpdater(AppPenalKeynoteManager._updater);
                ElementCategoryFilter f = new ElementCategoryFilter(BuiltInCategory.OST_KeynoteTags);
                UpdaterRegistry.AddTrigger(AppPenalKeynoteManager._updater.GetUpdaterId(), f, Element.GetChangeTypeElementAddition());
            }

        }

        public string GetName()
        {
            return "DisableDialog";
        }
    }

    public class RevitCommandEndedMonitor
    {
        private readonly UIApplication _revitUiApplication;

        public RevitCommandEndedMonitor(UIApplication revituiApplication)
        {
            _revitUiApplication = revituiApplication;

            _revitUiApplication.DialogBoxShowing += new EventHandler<DialogBoxShowingEventArgs>(OnRevitUiApplicationDialog);

        }

        private void OnRevitUiApplicationDialog(object sender, DialogBoxShowingEventArgs diaLogEventArgs)
        {
            DialogBoxShowingEventArgs t = diaLogEventArgs as DialogBoxShowingEventArgs;
            var id = t.DialogId;
            if (t != null && id == @"Dialog_Revit_KeynoteData")
            {
                diaLogEventArgs.OverrideResult(1);
                
            }
        }


    }

}
