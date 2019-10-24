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
using System.Xml.Linq;
using System.Xml;
using Autodesk.Revit.DB;

namespace ApiProject4.ColorElement
{
    public partial class frmColorElement : System.Windows.Forms.Form
    {
        private ColorElementHandler _handlerColor;
        private ExternalEvent _eventColor;
        private ParameterLoadHandler _handlerParameterLoad;
        private ExternalEvent _eventParameter;
        private AutoApplyColorHandler _handlerAutoApplyColor;
        private ExternalEvent _eventAutoApplyColor;
        private ValueParamrterHandler _handlerValueParameter;
        private ExternalEvent _eventValueParameter;
        private UpdateAllHandler _handlerUpdate;
        private ExternalEvent _eventUpdalte;
        public frmColorElement(ExternalEvent eventColor, ColorElementHandler handlerColor,
            ExternalEvent eventParameter, ParameterLoadHandler handlerParameterLoad,
            ExternalEvent eventAutoApplyColor, AutoApplyColorHandler handlerAutoApplyColor,
            ExternalEvent eventValueParameter, ValueParamrterHandler handlerValueParameter,
            ExternalEvent eventUpdalte, UpdateAllHandler handlerUpdate)
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
            _eventUpdalte = eventUpdalte;
            _handlerUpdate = handlerUpdate;

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
            if (AppPenalColorElement.CancelAutoHandler == false)
            {
                AppPenalColorElement.CancelAutoHandler = true;
            }
            else
            {
                AppPenalColorElement.CancelAutoHandler = false;
            }
            _eventAutoApplyColor.Raise();
        }

        private void btnCloseAppColor_Click(object sender, EventArgs e)
        {
            if (AppPenalColorElement.CancelAutoHandler == true)
            {
                AppPenalColorElement.CancelAutoHandler = false;
                _eventAutoApplyColor.Raise();
            }
            AppPenalColorElement.myFormColorElement.Close();
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
            _eventUpdalte.Raise();
        }

        private void dataGridViewValueParameter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color color = dlg.Color;
                AppPenalColorElement.myFormColorElement.dataGridViewValueParameter.Rows[row].DefaultCellStyle.BackColor = color;
                for (int i = 0; i < AppPenalColorElement.ListValueColor.Count; i++)
                {
                    if (row == i)
                    {
                        AppPenalColorElement.ListValueColor[i].ColorSystem = color;
                        AppPenalColorElement.ListValueColor[i].Color = new Autodesk.Revit.DB.Color(color.R, color.G, color.B);
                    }
                }
            }
        }

        private void buttonSchamaSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Xml|*.xml";
            save.Title = "Save an Xml File";
            save.ShowDialog();
            if (save.FileName != "")
            {
                XmlTextWriter writer = new XmlTextWriter(save.FileName, System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("Table");
                foreach (var item in AppPenalColorElement.ListValueColor)
                {
                    writer.WriteStartElement("ValueColor");
                    writer.WriteStartElement("Value");
                    writer.WriteString(item.Value);
                    writer.WriteEndElement();
                    writer.WriteStartElement("Color");
                    writer.WriteString(item.ColorSystem.ToArgb().ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        private void btnLoadSchema_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Xml|*.xml";
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                string fullPath = file.FileName;
                var xmlDoc = XDocument.Load(fullPath);
                var xmlElement = xmlDoc.Element("Table").Elements("ValueColor");
                List<System.Drawing.Color> colors = new ColorSystem().ColorUser;
                foreach (var row in xmlElement)
                {
                   string value = row.Element("Value").Value;
                   var color= row.Element("Color").Value;
                    for (int i = 0; i < AppPenalColorElement.ListValueColor.Count; i++)
                    {
                        if(value== AppPenalColorElement.ListValueColor[i].Value&&color!= AppPenalColorElement.ListValueColor[i].ColorSystem.ToArgb().ToString())
                        {
                            var colorSys = System.Drawing.Color.FromArgb(Int32.Parse(color));
                            AppPenalColorElement.ListValueColor[i].ColorSystem = colorSys;
                            AppPenalColorElement.myFormColorElement.dataGridViewValueParameter.Rows[i].DefaultCellStyle.BackColor = colorSys;
                            AppPenalColorElement.ListValueColor[i].Color = new Autodesk.Revit.DB.Color(colorSys.R, colorSys.G, colorSys.B);
                        }
                    }
                }  
            }
        }
    }
}
