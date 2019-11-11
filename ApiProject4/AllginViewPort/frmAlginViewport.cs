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
namespace ApiProject4.AllginViewPort
{
    public partial class frmAlginViewport : Form
    {
        private AlignViewportHandler _handlerViewport;
        private ExternalEvent _eventViewport;
        public frmAlginViewport(ExternalEvent eventViewport, AlignViewportHandler handlerViewport)
        {
            InitializeComponent();
            _eventViewport = eventViewport;
            _handlerViewport = handlerViewport;
        }

        private void btnAlignViewportBinding_Click(object sender, EventArgs e)
        {
            _eventViewport.Raise();
        }
    }
}
