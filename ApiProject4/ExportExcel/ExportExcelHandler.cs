using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using ApiProject4.Helper;
using System.Data;
using OfficeOpenXml.Style;

namespace ApiProject4.ExportExcel
{
    public class ExportExcelHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            ScheduleExport(doc);
        }

        public string GetName()
        {
            return "ExportToExcel";
        }
        public void ScheduleExport(Document doc)
        {
            var listItems = AppPenalExportExcel.myFormExportExcel.listViewSchedule.CheckedItems;
            if (listItems.Count == 0)
            {
                return;
            }
            List<string> listNameSchedule = new List<string>();
            foreach (ListViewItem item in listItems)
            {
                listNameSchedule.Add(item.Text);
            }
            var listSchedule = new FilteredElementCollector(doc).OfClass(typeof(ViewSchedule)).Cast<ViewSchedule>().OrderBy(x => x.Name).ToList();
            List<ViewSchedule> listScheduleSelect = new List<ViewSchedule>();
            foreach (ViewSchedule view in listSchedule)
            {
                if (listNameSchedule.Exists(x => x == view.Name))
                {
                    listScheduleSelect.Add(view);
                }
            }
            if (AppPenalExportExcel.myFormExportExcel.radioButtonOneFile.Checked)
            {
                string name = AppPenalExportExcel.myFormExportExcel.textBoxFileName.Text;
                if (name == "" || name == null)
                {
                    MessageBox.Show("Error: You must input name");
                    return;
                }
                string fullPath = AppPenalExportExcel.myFormExportExcel.textBoxFolerOutput.Text + @"\" + name + ".xlsx";
                FileInfo file = new FileInfo(fullPath);
                if (file.Exists)
                {
                    file.Delete();
                    file = new FileInfo(fullPath);
                }
                using (ExcelPackage package = new ExcelPackage(file))
                {

                    foreach (var view in listScheduleSelect)
                    {
                        try
                        {
                            TableData table = view.GetTableData();
                            TableSectionData section = table.GetSectionData(SectionType.Body);
                            int nRows = section.NumberOfRows;
                            int nColumns = section.NumberOfColumns;
                            var datatable = new DataTable("tblData");
                            if (nRows > 1)
                            {
                                for (int i = 0; i < nRows; i++)
                                {
                                    for (int j = 0; j < nColumns; j++)
                                    {
                                        if (i == 0)
                                        {
                                            datatable.Columns.Add(view.GetCellText(SectionType.Body, i, j).ToString(), typeof(string));
                                        }
                                        else { break; }
                                    }
                                    if (i != 0)
                                    {
                                        var row = datatable.NewRow();
                                        for (int j = 0; j < nColumns; j++)
                                        {
                                            var value = view.GetCellText(SectionType.Body, i, j).ToString();
                                            row[j] = value;
                                        }
                                        datatable.Rows.Add(row);
                                    }

                                }
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(view.Name);
                                worksheet.Cells["A1"].LoadFromDataTable(datatable, true);
                            }
                        }
                        catch (Exception ex) { continue; }
                    }
                    foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            worksheet.Column(i + 1).AutoFit();
                        }
                    }
                    package.Save();
                }
            }
            else if (AppPenalExportExcel.myFormExportExcel.radioButtonManyFile.Checked)
            {
                foreach (var view in listScheduleSelect)
                {
                    string name = view.Name;
                    string fullPath = AppPenalExportExcel.myFormExportExcel.textBoxFolerOutput.Text + @"\" + name + ".xlsx";
                    FileInfo file = new FileInfo(fullPath);
                    if (file.Exists)
                    {
                        file.Delete();
                        file = new FileInfo(fullPath);
                    }
                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        try
                        {
                            TableData table = view.GetTableData();
                            TableSectionData section = table.GetSectionData(SectionType.Body);
                            int nRows = section.NumberOfRows;
                            int nColumns = section.NumberOfColumns;
                            var datatable = new DataTable("tblData");
                            if (nRows > 1)
                            {
                                for (int i = 0; i < nRows; i++)
                                {
                                    for (int j = 0; j < nColumns; j++)
                                    {
                                        if (i == 0)
                                        {
                                            datatable.Columns.Add(view.GetCellText(SectionType.Body, i, j).ToString(), typeof(string));
                                        }
                                        else { break; }
                                    }
                                    if (i != 0)
                                    {
                                        var row = datatable.NewRow();
                                        for (int j = 0; j < nColumns; j++)
                                        {
                                            var value = view.GetCellText(SectionType.Body, i, j).ToString();
                                            row[j] = value;
                                        }
                                        datatable.Rows.Add(row);
                                    }

                                }
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(view.Name);
                                worksheet.Cells["A1"].LoadFromDataTable(datatable, true);
                            }
                        }
                        catch (Exception ex) { continue; }

                        foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                        {
                            for (int i = 0; i < 50; i++)
                            {
                                worksheet.Column(i + 1).AutoFit();
                            }
                        }
                        package.Save();
                    }
                }
            }
            MessageBox.Show("The exporting is finished");
        }
    }


}
