using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ApiProject4.NewSheets
{
    public class NewSheetsHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var listIds = app.ActiveUIDocument.Selection.GetElementIds();
            ViewSheet sheetChoice = null;
            foreach(ElementId id in listIds)
            {
                ViewSheet sheet = doc.GetElement(id) as ViewSheet;
                if (sheet != null)
                {
                    sheetChoice = sheet;
                    break;
                }
            }
            if(sheetChoice==null)
            {
                MessageBox.Show("You must choose a sheet");
                return;
            }
            string nameSheet = AppPenalNewSheets.myFormNewShees.textBoxSheetName.Text;
            string numberStart = AppPenalNewSheets.myFormNewShees.textBoxNumberStart.Text;
            string count = AppPenalNewSheets.myFormNewShees.textBoxQuantitySheet.Text;
            bool addLegend = AppPenalNewSheets.myFormNewShees.checkBoxAddLegeneds.Checked;

        }

        public void CreateSheets(Document doc, ViewSheet sheet, string nameSheet, string numberStart, bool addLenged, ref bool begin)
        {
            FamilyInstance titleblock = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance))
                    .OfCategory(BuiltInCategory.OST_TitleBlocks).Cast<FamilyInstance>().First(q => q.OwnerViewId == sheet.Id);
            string newSheetNumber = string.Empty;
            if (numberStart == null || numberStart == "" || numberStart == string.Empty)
            {
                newSheetNumber = sheet.SheetNumber;
            }
            ViewSheet newSheet = null;
            using (Transaction t = new Transaction(doc, "CreateSheetNew"))
            {
                t.Start();
                newSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                if (begin == true)
                {
                   
                    if (newSheetNumber==numberStart)
                    {
                        newSheet.SheetNumber = CreateNumberSheet(newSheetNumber);
                    }else
                    {
                        newSheet.SheetNumber = numberStart;
                    }
                }
                t.Commit();
            }
            var viewPortIds = sheet.GetAllViewports();
            foreach (var id in viewPortIds)
            {
                Viewport viewPort = doc.GetElement(id) as Viewport;
                var ownId = viewPort.OwnerViewId;
                Autodesk.Revit.DB.View view = doc.GetElement(ownId) as Autodesk.Revit.DB.View;
                if (view.ViewType == ViewType.Legend)
                {
                    if (addLenged == true)
                    {
                        
                    }
                }else
                {

                }
               
            }

           

        }



        public string CreateNumberSheet(string sheetNumber)
        {
            string sheetNumberResult = null;
            int lengthNumber = sheetNumber.Length;
            string start = Regex.Replace(sheetNumber, @"[\d-]", string.Empty);
            int end = int.Parse(Regex.Match(sheetNumber, @"\d+").Value);
            end = end + 1;
            int countEnd = end.ToString().Length;
            sheetNumberResult = sheetNumber.Remove(lengthNumber - countEnd) + end.ToString();
            return sheetNumberResult;
        }


        public string GetName()
        {
            return "NewSheetsHandlers";
        }
    }
}
