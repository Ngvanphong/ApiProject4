﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ApiProject4.Helper;

namespace ApiProject4.NewSheets
{
    public class NewSheetsHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var listIds = app.ActiveUIDocument.Selection.GetElementIds();
            ViewSheet sheetChoice = null;
            foreach (ElementId id in listIds)
            {
                ViewSheet sheet = doc.GetElement(id) as ViewSheet;
                if (sheet != null)
                {
                    sheetChoice = sheet;
                    break;
                }
            }
            if (sheetChoice == null)
            {
                MessageBox.Show("You must choose a sheet");
                return;
            }
            string nameSheet = AppPenalNewSheets.myFormNewShees.textBoxSheetName.Text;
            string numberStart = AppPenalNewSheets.myFormNewShees.textBoxNumberStart.Text;
            int count = int.Parse(AppPenalNewSheets.myFormNewShees.textBoxQuantitySheet.Text);
            bool begin = true;
            for (int i = 1; i <= count; i++)
            {
                CreateSheets(doc, sheetChoice, nameSheet, numberStart, ref begin);
            }
        }

        public void CreateSheets(Document doc, ViewSheet sheet, string nameSheet, string numberStart, ref bool begin)
        {
            FamilyInstance titleblock = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance))
                    .OfCategory(BuiltInCategory.OST_TitleBlocks).Cast<FamilyInstance>().First(q => q.OwnerViewId == sheet.Id);
            string newSheetNumber = string.Empty;
            if (numberStart == null || numberStart == "" || numberStart == string.Empty)
            {
                newSheetNumber = sheet.SheetNumber;
            }
            else
            {
                newSheetNumber = numberStart;
            }
            ViewSheet newSheet = null;
            using (Transaction t = new Transaction(doc, "CreateSheetNew"))
            {
                t.Start();
                newSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                newSheet.Name = nameSheet;
                if (AppPenalNewSheets.myFormNewShees.radioCopyParameterYes.Checked)
                {
                    ParameterSet parametersSheet = sheet.Parameters;                   
                    foreach(Parameter para in parametersSheet)
                    {
                        if(para.Id.IntegerValue != (int)BuiltInParameter.SHEET_NUMBER && para.Id.IntegerValue != (int)BuiltInParameter.SHEET_NAME
                            &&para.Id.IntegerValue!=(int)BuiltInParameter.VIEWER_SHEET_NUMBER)
                        {
                            try
                            {
                                Parameter parasheetNew = newSheet.GetParameters(para.Definition.Name).First();
                                switch (para.StorageType)
                                {
                                    case StorageType.Double:
                                        parasheetNew.Set(para.AsDouble());
                                        break;
                                    case StorageType.Integer:
                                        parasheetNew.Set(para.AsInteger());
                                        break;
                                    case StorageType.String:
                                        parasheetNew.Set(para.AsString());
                                        break;
                                    case StorageType.ElementId:
                                        parasheetNew.Set(para.AsElementId());
                                        break;
                                    case StorageType.None:
                                        break;
                                }
                            }
                            catch { continue; }
                        }                                         
                    }
                }                              
                if (begin == true)
                {
                    if (newSheetNumber != numberStart)
                    {
                        newSheet.SheetNumber = CreateNumberSheet(newSheetNumber);
                        begin = false;
                    }
                    else
                    {
                        newSheet.SheetNumber = newSheetNumber;
                        begin = false;
                    }
                }
                t.Commit();
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
