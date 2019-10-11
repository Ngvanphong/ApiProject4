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

namespace ApiProject4.ColorElement
{
    public partial class frmColorElement : Form
    {
        private ColorElementHandler _handlerColor;
        private ExternalEvent _eventColor;
        private ParameterLoadHandler _handlerParameterLoad;
        private ExternalEvent _eventParameter;
        private AutoApplyColorHandler _handlerAutoApplyColor;
        private ExternalEvent _eventAutoApplyColor;
        private ValueParamrterHandler _handlerValueParameter;
        private ExternalEvent _eventValueParameter;
        public frmColorElement(ExternalEvent eventColor, ColorElementHandler handlerColor,
            ExternalEvent eventParameter, ParameterLoadHandler handlerParameterLoad,
            ExternalEvent eventAutoApplyColor, AutoApplyColorHandler handlerAutoApplyColor,
            ExternalEvent eventValueParameter, ValueParamrterHandler handlerValueParameter)
        {
            InitializeComponent();
            _eventColor = eventColor;
            _handlerColor = handlerColor;
            _eventParameter = eventParameter;
            _handlerParameterLoad = handlerParameterLoad;
            _eventAutoApplyColor = eventAutoApplyColor;
            _handlerAutoApplyColor = handlerAutoApplyColor;
            _handlerValueParameter = handlerValueParameter;
            _eventValueParameter = eventValueParameter;

        }

        private void frmColorElement_Load(object sender, EventArgs e)
        {

        }

        private void btnApplyColor_Click(object sender, EventArgs e)
        {
            AppPenalColorElement.SetColor = true;
            _eventColor.Raise();
        }

        private void checkBoxAutoColor_CheckedChanged(object sender, EventArgs e)
        {
            _eventAutoApplyColor.Raise();
        }

        private void btnCloseAppColor_Click(object sender, EventArgs e)
        {
            AppPenalColorElement.CancelHandlerAuto = true;
            _eventAutoApplyColor.Raise();
        }

        private void btnClearSetColor_Click(object sender, EventArgs e)
        {
            AppPenalColorElement.SetColor = false;
            _eventColor.Raise();
        }

        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _eventParameter.Raise();
        }

        private void listBoxParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _eventValueParameter.Raise();
        }

        private void dataGridViewValueParameter_SelectionChanged(object sender, EventArgs e)
        {
            AppPenalColorElement.myFormColorElement.dataGridViewValueParameter.ClearSelection();
        }

        private void btnDefaultColor_Click(object sender, EventArgs e)
        {
            _eventValueParameter.Raise();
        }
    }
}
