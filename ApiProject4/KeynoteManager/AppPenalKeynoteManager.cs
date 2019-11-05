﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace ApiProject4.KeynoteManager
{
   public static class AppPenalKeynoteManager
    {
        public static frmKeynoteManager myFormKeynoteManager;
        public static List<KeynoteEntry> entryTableKeynote = new List<KeynoteEntry>();
        public static Subro.Controls.DataGridViewGrouper groupKeyNoteTree = null;
        public static bool isSearchKeynote = true;
        public static frmAddKeyNote myFormAddKeynote;
        public static int indexRowCurrent = 1;
        public static string pathTextNoteFile = string.Empty;
        public static ElevationWatcherUpdaterKeynote _updater = null;
        public static RevitCommandEndedMonitor comandMoniter;
        public static int countRemoveEvent = 0;
        public static void ShowKeynoteManager()
        {
            KeynoteManagerHandler handlerKeynote = new KeynoteManagerHandler();
            ExternalEvent eventKeynote = ExternalEvent.Create(handlerKeynote);
            KeynoteReloadHandler handlerReloadKeynote = new KeynoteReloadHandler();
            ExternalEvent eventKeynoteReload = ExternalEvent.Create(handlerReloadKeynote);
            CancelHandler handlerCancelKeynote = new CancelHandler();
            ExternalEvent eventCancelKetnote = ExternalEvent.Create(handlerCancelKeynote);
            EditKeynoteHandler handlerEditKeynote = new EditKeynoteHandler();
            ExternalEvent eventEditKeynote = ExternalEvent.Create(handlerEditKeynote);
            myFormKeynoteManager = new frmKeynoteManager(eventKeynote, handlerKeynote,eventKeynoteReload,handlerReloadKeynote,
                 eventCancelKetnote, handlerCancelKeynote,eventEditKeynote,handlerEditKeynote);
            myFormKeynoteManager.Show();
        }
        public static void ShowAddKeynote()
        {
            myFormAddKeynote = new frmAddKeyNote();
            myFormAddKeynote.Owner = myFormKeynoteManager;
            myFormAddKeynote.Show();
        }

    }
}
