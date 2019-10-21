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

namespace ApiProject4.ShareParameter
{
    public partial class frmShareParameter : Form
    {
        private ShareParameterHandler _handlerShareParameter;
        private ExternalEvent _eventShareParameter;
        public frmShareParameter(ExternalEvent eventShareParameter, ShareParameterHandler handlerShareParameter)
        {
            InitializeComponent();
            _eventShareParameter= eventShareParameter;
            _handlerShareParameter = handlerShareParameter;
        }

    }
}
