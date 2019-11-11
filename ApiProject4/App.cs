#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiProject4.Button;
using Autodesk.Revit.UI.Events;
using ApiProject4.KeynoteManager;
#endregion

namespace ApiProject4
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            PurgeCadButton purgeCadClass = new PurgeCadButton();
            purgeCadClass.PurgeCad(a);
            //ScopeBoxButton scopeBoxclass = new ScopeBoxButton();
            //scopeBoxclass.ScopeBox(a);
            AlignLeftButton alignButtonClass = new AlignLeftButton();
            alignButtonClass.AlignLeft(a);
            AllignRightButton alignRightClass = new AllignRightButton();
            alignRightClass.AlignRight(a);
            ExportExcelButton exportExcel = new ExportExcelButton();
            exportExcel.CreateExportExcel(a);
            //PrinterSortButton printSort = new PrinterSortButton();
            //printSort.PrintSort(a);
            NewSheetsButton newSheetButton = new NewSheetsButton();
            newSheetButton.NewSheet(a);
            ColorElementButton colorElementButton = new ColorElementButton();
            colorElementButton.ColorElement(a);
            ShareParameterButton shareParaButton = new ShareParameterButton();
            shareParaButton.ShareParameter(a);
            KeynoteManagerButton keynoteButton = new KeynoteManagerButton();
            keynoteButton.KeynoteManager(a);
            AllignViewPortButton alignViewPort = new AllignViewPortButton();
            alignViewPort.CreateAlignView(a);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            for(int i = 0; i < AppPenalKeynoteManager.countRemoveEvent; i++)
            {
                a.DialogBoxShowing -= new EventHandler<DialogBoxShowingEventArgs>(OnRevitUiApplicationDialog);
            }
            return Result.Succeeded;
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
