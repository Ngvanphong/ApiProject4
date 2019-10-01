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

namespace ApiProject4.PrintSort
{
    public partial class frmPrintSort : Form
    {
        private PrintSortHandler _handlerPrint;
        private ExternalEvent _eventPrint;
        private PrintActionHandler _handlerPrintAction;
        private ExternalEvent _eventPrintAction;
        public frmPrintSort(ExternalEvent eventPrint, PrintSortHandler handlerPrint, ExternalEvent eventPrintAction, PrintActionHandler handlerPrintAction)
        {
            InitializeComponent();
            _eventPrint = eventPrint;
            _handlerPrint = handlerPrint;
            _eventPrintAction = eventPrintAction;
            _handlerPrintAction = handlerPrintAction;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBoxSetPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppPenalPrintSort.myFormPrintSort.textBoxNamePrinterSet.Text = 
                AppPenalPrintSort.myFormPrintSort.listBoxSetPrinter.GetItemText(AppPenalPrintSort.myFormPrintSort.listBoxSetPrinter.SelectedItem);
        }

        private void frmPrintSort_Load(object sender, EventArgs e)
        {

        }

        private void btnSetPrint_Click(object sender, EventArgs e)
        {
            _eventPrint.Raise();
        }

        private void btnPrinterAction_Click(object sender, EventArgs e)
        {
            _eventPrintAction.Raise();
        }
    }
}
