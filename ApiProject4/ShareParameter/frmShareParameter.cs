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
            AppPenalShareParameter.ShowFormModify();
            UpdateFormModifyPara();
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            AppPenalShareParameter.ShowFormAddParameter();
            _eventAddParameter.Raise();
        }
        private void UpdateFormModifyPara()
        {
            string path = AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text;
            var lines = System.IO.File.ReadAllLines(path);
            var lineGroups = lines.Where(x => x.StartsWith("GROUP"));
            string groupNameOld = string.Empty;
            string namePara = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Text;
            AppPenalShareParameter.nameParameterModify = namePara;
            string typeOld = string.Empty;
            int visible = 0;
            foreach (string line in lines)
            {
                if (line.StartsWith("PARAM"))
                {
                    string nameOld= Regex.Split(line, @"\t")[2];
                    if (nameOld == namePara)
                    {
                        string groupId = Regex.Split(line, @"\t")[5];
                        typeOld = Regex.Split(line, @"\t")[3];
                        visible = int.Parse(Regex.Split(line, @"\t")[6]);
                        foreach (string groupLine in lineGroups)
                        {
                            if (Regex.Split(groupLine, @"\t")[1] == groupId)
                            {
                                groupNameOld = Regex.Split(groupLine, @"\t")[2];
                            }
                        }
                    } 
                }
            }
            AppPenalShareParameter.myFormModifyParameter.txtNameParaModify.Text = namePara;
            AppPenalShareParameter.myFormModifyParameter.dropTypeParaModify.Items.AddRange(GetTypeParameter.GetAllType());
            foreach(var item in AppPenalShareParameter.myFormModifyParameter.dropTypeParaModify.Items)
            {
                string typeOldUpper = Regex.Replace(typeOld, "([A-Z])_([A-Z])", "$1$2").TrimStart();
                if (item.ToString().ToUpper() == typeOldUpper)
                {
                    AppPenalShareParameter.myFormModifyParameter.dropTypeParaModify.SelectedItem = item.ToString();
                }
            }
            var countGroup = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes.Count;
            string[] listGroups = new string[countGroup];
            for(int i = 0; i < countGroup; i++)
            {
                listGroups[i] = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes[i].Text;
            }
            AppPenalShareParameter.myFormModifyParameter.dropGroupParaModify.Items.AddRange(listGroups);
            for(int i = 0; i < countGroup; i++)
            {
                string nameGr = AppPenalShareParameter.myFormModifyParameter.dropGroupParaModify.Items[i].ToString();
                if(nameGr== groupNameOld)
                {
                    AppPenalShareParameter.myFormModifyParameter.dropGroupParaModify.SelectedItem = nameGr;
                }
            }
            if (visible == 1)
            {
                AppPenalShareParameter.myFormModifyParameter.checkBoxVisibleParameter.Checked = true;
            }
            else
            {
                AppPenalShareParameter.myFormModifyParameter.checkBoxVisibleParameter.Checked = false;
            }


        }
    }
}
