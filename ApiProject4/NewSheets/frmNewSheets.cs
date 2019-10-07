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
namespace ApiProject4.NewSheets
{
    public partial class frmNewSheets : Form
    {
        private NewSheetsHandler _handlerNewSheets;
        private ExternalEvent _eventNewSheets;
        public frmNewSheets(ExternalEvent eventNewSheets, NewSheetsHandler handlerNewSheets)
        {
            InitializeComponent();
            _handlerNewSheets = handlerNewSheets;
            _eventNewSheets = eventNewSheets;
        }

        private void btnSheetNews_Click(object sender, EventArgs e)
        {
            _eventNewSheets.Raise();
        }
    }
}
