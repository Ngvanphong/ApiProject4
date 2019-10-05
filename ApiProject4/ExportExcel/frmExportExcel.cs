using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using System.IO;

namespace ApiProject4.ExportExcel
{
    public partial class frmExportExcel : Form
    {
        private ExternalEvent _eventExport;
        private ExportExcelHandler _handlerExport;
        private ExternalEvent _eventImport;
        private ImportHandler _handlerImport;
        private ExternalEvent _eventGet;
        private GetWorksheetHandler _handlerGet;
        public frmExportExcel(ExternalEvent eventExport, ExportExcelHandler handlerExport, ExternalEvent eventImport,
          ImportHandler handlerImpor, ExternalEvent eventGet, GetWorksheetHandler handlerGet)
        {
            InitializeComponent();
            _eventExport = eventExport;
            _handlerExport = handlerExport;
            _eventImport = eventImport;
            _handlerImport = handlerImpor;
            _eventGet = eventGet;
            _handlerGet = handlerGet;
        }

    
        private void btnFolderOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                AppPenalExportExcel.myFormExportExcel.textBoxFolerOutput.Text = "";
                AppPenalExportExcel.myFormExportExcel.textBoxFolerOutput.Text = folder.SelectedPath;
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            _eventExport.Raise();
        }

      
        private void btnInputPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                AppPenalExportExcel.myFormExportExcel.textBoxInputFile.Text = "";
                AppPenalExportExcel.myFormExportExcel.textBoxInputFile.Text =file.FileName;
                _eventGet.Raise();
            }
        }

        private void listViewInputFile_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var listItemChecked = AppPenalExportExcel.myFormExportExcel.listViewInputFile.CheckedItems;
            if (listItemChecked.Count > 1)
            {
                foreach (ListViewItem item in listItemChecked)
                {
                    if (item.Index != e.Item.Index)
                    {
                        item.Checked = false;
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            _eventImport.Raise();
        }

        private void frmExportExcel_Load(object sender, EventArgs e)
        {

        }
    }
}
