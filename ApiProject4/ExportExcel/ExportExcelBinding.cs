using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiProject4.Helper;
using System.Windows.Forms;

namespace ApiProject4.ExportExcel
{
    [Transaction(TransactionMode.Manual)]
    public class ExportExcelBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //if (CheckAccess.CheckLicense() == true)
            //{
                AppPenalExportExcel.ShowFormExportExcel();
                Infomation.ScheduleInfor(doc);
            //}
            return Result.Succeeded;
        }
    }
    public static class Infomation
    {
        public static void ScheduleInfor(Document doc)
        {
            var scheules = new FilteredElementCollector(doc).OfClass(typeof(ViewSchedule)).Cast<ViewSchedule>().ToList();
            foreach (ViewSchedule view in scheules.OrderBy(x => x.Name))
            {
                var row = new string[] { view.Name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPenalExportExcel.myFormExportExcel.listViewSchedule.Items.Add(lvi);
            }
            AppPenalExportExcel.myFormExportExcel.textBoxFolerOutput.Text= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
        }

    }
}
