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
        public frmExportExcel(ExternalEvent eventExport, ExportExcelHandler handlerExport)
        {
            InitializeComponent();
            _eventExport = eventExport;
            _handlerExport = handlerExport;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

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
    }
}
