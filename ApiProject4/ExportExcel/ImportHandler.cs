using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using System.IO;
using OfficeOpenXml;
using System.Windows.Forms;
using ApiProject4.Helper;

namespace ApiProject4.ExportExcel
{
    public class ImportHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            ImportTale(doc);
        }

        public string GetName()
        {
            return "ImportExcel";
        }

        public void ImportTale(Document doc)
        {
            string fullPath = AppPenalExportExcel.myFormExportExcel.textBoxInputFile.Text;
            FileInfo file = new FileInfo(fullPath);
            using (var package = new ExcelPackage(file))
            {
                var listItem = AppPenalExportExcel.myFormExportExcel.listViewInputFile.CheckedItems;
                var worksheets = package.Workbook.Worksheets;
                ExcelWorksheet worksheetSelect = null;
                ViewSchedule viewSchedule = null;
                foreach (ListViewItem item in listItem)
                {
                    foreach (ExcelWorksheet worksheet in worksheets)
                    {
                        if (item.Text == worksheet.Name)
                        {
                            worksheetSelect = worksheet;
                        }
                    }
                }
                var listSchedule = new FilteredElementCollector(doc).OfClass(typeof(ViewSchedule)).Cast<ViewSchedule>().ToList();
                foreach (ViewSchedule schedule in listSchedule)
                {
                    if (schedule.Name == worksheetSelect.Name)
                    {
                        viewSchedule = schedule;
                        break;
                    }
                }
                TableData table = viewSchedule.GetTableData();
                TableSectionData section = table.GetSectionData(SectionType.Body);
                int nRows = section.NumberOfRows;
                int nColumns = section.NumberOfColumns;
                if (CheckSampleTable(section, worksheetSelect) == false)
                {
                    MessageBox.Show("Error: You must export again");                  
                    return;
                }
                for (int g = 1; g <= nRows; g++)
                {
                    for (int c = 0; c < nColumns; c++)
                    {
                        try
                        {
                            string value = worksheetSelect.Cells[g + 1, c + 1].Value.ToString();
                            var value2 = viewSchedule.GetCellText(SectionType.Body, g, c).ToString();
                            if (value != value2)
                            {
                                var defindField = viewSchedule.Definition;
                                string heading = defindField.GetField(c).GetName();
                                Element element = getElement(doc, section, viewSchedule, g);
                                using (Transaction t2 = new Transaction(doc, "UpdateTable"))
                                {
                                    t2.Start();
                                    try
                                    { 
                                        Parameter para= element.LookupParameter(heading); 
                                        if (para == null)
                                        {
                                            para =  element.GetParameters(heading).First();
                                        }                                       
                                        ParameterRevit.SetValueParaMulti(para, value);
                                        t2.Commit();
                                    }
                                    catch { t2.Commit(); }                                    
                                }
                            }
                        }
                        catch { continue; }
                    }
                }            
                MessageBox.Show("The updating is finished");
            }
        }

        private bool CheckSampleTable(TableSectionData section, ExcelWorksheet worksheet)
        {
            int nColumns = section.NumberOfColumns;
            int wColumns = 0;
            List<string> excelTitel = new List<string>();
            for (int i = 1; i < 50; i++)
            {
                try
                {
                    string text = string.Empty;
                    text = worksheet.Cells[1, i].Value.ToString();
                    if (text != string.Empty && text != "")
                    {
                        wColumns += 1;
                        excelTitel.Add(text.ToString());
                    }
                }
                catch { continue; }

            }

            if (nColumns != wColumns)
            {
                return false;
            }
            List<string> revitTitle = new List<string>();
            for (int j = 0; j < nColumns; j++)
            {
                string ti = section.GetCellText(0, j).ToString();
                revitTitle.Add(ti);
            }
            excelTitel = excelTitel.OrderBy(x => x).ToList();
            revitTitle = revitTitle.OrderBy(x => x).ToList();
            for (int k = 0; k < nColumns; k++)
            {
                if (excelTitel[k] != revitTitle[k])
                {
                    return false;
                }
            }
            return true;

        }

        private Element getElement(Document doc, TableSectionData section, ViewSchedule view, int row)
        {
            Element element = null;
            List<ElementId> elems = new FilteredElementCollector(doc, view.Id).ToElementIds().ToList();
            List<ElementId> Remaining = null;
            using (Transaction t = new Transaction(doc, "dummy"))
            {
                t.Start();
                using (SubTransaction st = new SubTransaction(doc))
                {
                    st.Start();
                    section.RemoveRow(row);
                    st.Commit();
                }
                Remaining = new FilteredElementCollector(doc, view.Id).ToElementIds().ToList();
                t.RollBack();
            }
            foreach (ElementId id in elems)
            {
                if (!Remaining.Exists(x => x == id))
                {
                    element = doc.GetElement(id);
                    break;
                }
            }
            return element;
        }
    }
}
