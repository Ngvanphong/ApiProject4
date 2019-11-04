#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiProject4.Button;
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

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
