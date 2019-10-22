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
using System.Text.RegularExpressions;

namespace ApiProject4.ShareParameter
{
    public partial class frmShareParameter : Form
    {
        private ShareParameterHandler _handlerShareParameter;
        private ExternalEvent _eventShareParameter;
        private AddParameterHandler _handlerAddParameter;
        private ExternalEvent _eventAddParameter;
        public frmShareParameter(ExternalEvent eventShareParameter,
            ShareParameterHandler handlerShareParameter, ExternalEvent eventAddParameter, AddParameterHandler handlerAddParameter)
        {
            InitializeComponent();
            _eventShareParameter = eventShareParameter;
            _handlerShareParameter = handlerShareParameter;
            _handlerAddParameter = handlerAddParameter;
            _eventAddParameter = eventAddParameter;
        }

        private void btnNewFileParamter_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Txt|*.txt";
            save.Title = "Save an Txt File";
            save.ShowDialog();
            if (save.FileName != "")
            {
               
                using (StreamWriter sw = File.CreateText(save.FileName))
                {
                    sw.WriteLine(@"# This is a Revit shared parameter file.");
                    sw.WriteLine(@"# Do not edit manually.");
                    sw.WriteLine(@"*META	VERSION	MINVERSION");
                    sw.WriteLine(@"*META	2	1");
                    sw.WriteLine(@"*GROUP	ID	NAME");
                    sw.WriteLine(@"*PARAM	GUID	NAME	DATATYPE	DATACATEGORY	GROUP	VISIBLE	DESCRIPTION	USERMODIFIABLE");
                }
                AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text = save.FileName;        
            }

        }

        private void btnFindMasterFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Txt|*.txt";
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text = file.FileName;
                var listGroup= ExtensionMethod.LoadParameterByTxt(file.FileName);
                AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes.Clear();
                ExtensionMethod.LoadTreeView(AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter, listGroup);
            }

        }

        private void btnFindSourceParameterFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Txt|*.txt";
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                AppPenalShareParameter.myFormShareParameter.txtPathSourceSharedPamameter.Text = file.FileName;
                var listGroup = ExtensionMethod.LoadParameterByTxt(file.FileName);
                AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes.Clear();
                ExtensionMethod.LoadTreeView(AppPenalShareParameter.myFormShareParameter.treeViewSourceParameter, listGroup);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            AppPenalShareParameter.ShowFormAddGroup();
        }

        private void btnRenameGroup_Click(object sender, EventArgs e)
        {
            AppPenalShareParameter.ShowFormRenameGroup();
            var select = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Text;
            OldNewGroup item = new OldNewGroup();
            item.OldName = select;
            BindingSource bindingSource = new BindingSource();
            BindingList<OldNewGroup> oldNewBinding = new BindingList<OldNewGroup>();
            oldNewBinding.Add(item);
            bindingSource.DataSource = oldNewBinding;     
            AppPenalShareParameter.myFormRenameGroup.dataGridViewRenameGroup.DataSource = bindingSource;
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {

        }

        private void btnModifyParamter_Click(object sender, EventArgs e)
        {

        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            AppPenalShareParameter.ShowFormAddParameter();
            _eventAddParameter.Raise();
        }
    }
}
