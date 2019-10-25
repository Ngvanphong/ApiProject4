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
                AppPenalShareParameter.myFormShareParameter.treeViewSourceParameter.Nodes.Clear();
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
            AppPenalShareParameter.ShowDeleteGroup();
            var nodeTree = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            AppPenalShareParameter.myFormDeleteGroup.dropGroupChooesDelete.Items.Add(string.Empty);
            foreach (TreeNode group in nodeTree)
            {
                if(group.Text!= AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Text)
                {
                    AppPenalShareParameter.myFormDeleteGroup.dropGroupChooesDelete.Items.Add(group.Text);
                }  
            }
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
            if (AppPenalShareParameter.myFormModifyParameter.dropTypeParaModify.SelectedItem.ToString()== "FAMILYTYPE")
            {
                AppPenalShareParameter.myFormModifyParameter.dropTypeParaModify.Enabled = false;
            }else
            {
                AppPenalShareParameter.myFormModifyParameter.dropTypeParaModify.Enabled = true;
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

        private void btnDeleteParameter_Click(object sender, EventArgs e)
        {
            string warning = "WARNING: Are you sure to delete selected share parameter? Any families, tags, and schedules that include a deleted parameter will continue to function, but it will be imposisble to use the parameter with anything new.";
            DialogResult result = MessageBox.Show(warning, "Delete Parameter", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            var paraSelect = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Text;
            var path = AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text;
            var lines = System.IO.File.ReadAllLines(path);
            int rowEnd = lines.Length;
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int j = 0; j < rowEnd; j++)
                {
                    if (lines[j].StartsWith("PARAM"))
                    {
                        string nameParaDelete = Regex.Split(lines[j], @"\t")[2];
                        if (nameParaDelete != paraSelect)
                        {
                            sw.WriteLine(lines[j]);
                        }
                    }else
                    {
                        sw.WriteLine(lines[j]);
                    }
                }
            }
            AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Remove();
        }

        private void frmShareParameter_Load(object sender, EventArgs e)
        {
            this.btnDeleteParameter.Enabled = false;
            this.btnModifyParamter.Enabled = false;
            this.btnRenameGroup.Enabled = false;
            this.btnDeleteGroup.Enabled = false;
        }

        private void treeViewMasterParameter_AfterCheck(object sender, TreeViewEventArgs e)
        {
           
        }

        private void treeViewMasterParameter_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectGroup = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            bool isCheckGroup = false;
            bool isCheckPara = false;
            foreach (TreeNode tree in selectGroup)
            {
                if (tree.IsSelected)
                {
                    isCheckGroup = true;
                    break;
                }
                else
                {
                    foreach(TreeNode treeP in tree.Nodes)
                    {
                        if (treeP.IsSelected)
                        {
                            isCheckPara = true;
                            break;
                        }
                    }
                    if (isCheckPara == true) break;
                }    
            }
            if (isCheckGroup)
            {
                AppPenalShareParameter.myFormShareParameter.btnDeleteGroup.Enabled = true;
                AppPenalShareParameter.myFormShareParameter.btnRenameGroup.Enabled = true;
            }
            else
            {
                AppPenalShareParameter.myFormShareParameter.btnDeleteGroup.Enabled = false;
                AppPenalShareParameter.myFormShareParameter.btnRenameGroup.Enabled = false;              
            }
            if (isCheckPara)
            {
                AppPenalShareParameter.myFormShareParameter.btnDeleteParameter.Enabled = true;
                AppPenalShareParameter.myFormShareParameter.btnModifyParamter.Enabled = true;
            }else
            {
                AppPenalShareParameter.myFormShareParameter.btnDeleteParameter.Enabled = false;
                AppPenalShareParameter.myFormShareParameter.btnModifyParamter.Enabled = false;
            }

        }

        private void dropFilterParameterSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filterName = string.Empty;
            FilterParameter filterClass = new FilterParameter();
            try
            {
                filterName = AppPenalShareParameter.myFormShareParameter.dropFilterParameterSource.SelectedItem.ToString();
            }
            catch { };
            if (filterName == filterClass.Unique)
            {
                FilterUnique();
            }else if (filterName == filterClass.Duplicate)
            {
                FilterDuplicate();
            }else if (filterName == filterClass.None)
            {
                NoneFilter();
            }

        }

        private void FilterUnique()
        {
            var treeSource = AppPenalShareParameter.myFormShareParameter.treeViewSourceParameter.Nodes;
            var treeMaster = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            List<TreeNode> childSource = new List<TreeNode>();
            List<TreeNode> childMaster = new List<TreeNode>();
            foreach(TreeNode nodeSource in treeSource)
            {
                nodeSource.Checked = false;
                foreach(TreeNode nodePa in nodeSource.Nodes)
                {
                    childSource.Add(nodePa);
                }
            }
            foreach (TreeNode nodeMaster in treeMaster)
            {
                foreach (TreeNode nodePa in nodeMaster.Nodes)
                {
                    childMaster.Add(nodePa);
                }
                nodeMaster.ExpandAll();
            }
            List<TreeNode> listOther = childSource.Where(x => childMaster.Exists(y => y.Text == x.Text)==false).ToList();
            List<TreeNode> listSample = childSource.Where(x => childMaster.Exists(y => y.Text == x.Text) == true).ToList();
            foreach (TreeNode node in listOther)
            {
                if (node.Parent.IsExpanded == false)
                {
                    node.Parent.Expand();
                }
                node.BackColor = Color.Aquamarine;
                node.Checked = true;
            }
            foreach(TreeNode nodeHind in listSample)
            {
                nodeHind.Checked = false;
                nodeHind.BackColor = Color.White;
            }
        }
        
        private void FilterDuplicate()
        {
            var treeSource = AppPenalShareParameter.myFormShareParameter.treeViewSourceParameter.Nodes;
            var treeMaster = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            List<TreeNode> childSource = new List<TreeNode>();
            List<TreeNode> childMaster = new List<TreeNode>();
            foreach (TreeNode nodeSource in treeSource)
            {
                nodeSource.Checked = false;
                foreach (TreeNode nodePa in nodeSource.Nodes)
                {
                    childSource.Add(nodePa);
                }
            }
            foreach (TreeNode nodeMaster in treeMaster)
            {
                foreach (TreeNode nodePa in nodeMaster.Nodes)
                {
                    childMaster.Add(nodePa);
                }
                nodeMaster.ExpandAll();
            }
            List<TreeNode> listOther = childSource.Where(x => childMaster.Exists(y => y.Text == x.Text) == false).ToList();
            List<TreeNode> listSample = childSource.Where(x => childMaster.Exists(y => y.Text == x.Text) == true).ToList();
            foreach (TreeNode node in listSample)
            {
                if (node.Parent.IsExpanded == false)
                {
                    node.Parent.Expand();
                }
                node.BackColor = Color.Yellow;
                node.Checked = false;
            }
            foreach (TreeNode nodeHind in listOther)
            {
                nodeHind.Checked = false;
                nodeHind.BackColor = Color.White;
            }
        }

        private void NoneFilter()
        {
            var treeSource = AppPenalShareParameter.myFormShareParameter.treeViewSourceParameter.Nodes; 
            foreach (TreeNode nodeSource in treeSource)
            {
                nodeSource.Checked = false;
                foreach (TreeNode nodePa in nodeSource.Nodes)
                {
                    nodePa.Checked = false;
                    nodePa.BackColor = Color.White;
                }
            }
        }

        private void treeViewSourceParameter_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }

        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void btnAssignSourceToMaster_Click(object sender, EventArgs e)
        {
            AppPenalShareParameter.ShowMergeParameter();
            GetInforForMergroup();
        }

        private void GetInforForMergroup()
        {
            var treeMaster = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            AppPenalShareParameter.myFormMergeParameter.dropGroupMerge.Items.Clear();
            AppPenalShareParameter.myFormMergeParameter.dropGroupMerge.Items.Add(string.Empty);
            foreach (TreeNode group in treeMaster)
            {
                AppPenalShareParameter.myFormMergeParameter.dropGroupMerge.Items.Add(group.Text);
            }
        }
    }

   
}
