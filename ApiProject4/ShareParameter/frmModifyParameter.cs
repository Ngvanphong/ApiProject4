using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace ApiProject4.ShareParameter
{
    public partial class frmModifyParameter : Form
    {
        public frmModifyParameter()
        {
            InitializeComponent();
        }

        private void btnModifyParameter_Click(object sender, EventArgs e)
        {
            string path = AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text;
            string nameNew = AppPenalShareParameter.myFormModifyParameter.txtNameParaModify.Text;
            string groupNew = AppPenalShareParameter.myFormModifyParameter.dropGroupParaModify.SelectedItem.ToString();
            string typeNew = AppPenalShareParameter.myFormModifyParameter.dropTypeParaModify.SelectedItem.ToString();
            if (string.IsNullOrEmpty(typeNew)||typeNew=="")
            {
                MessageBox.Show("Error: You must choose type of parameter");
                return;
            }
            string visible = "1";
            string idGroup = string.Empty;
            if (AppPenalShareParameter.myFormModifyParameter.checkBoxVisibleParameter.Checked == false)
            {
                visible = "0";
            }
            string oldPara = AppPenalShareParameter.nameParameterModify;
            var lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.StartsWith("GROUP"))
                {
                    string nameG = Regex.Split(line, @"\t")[2];
                    if (nameG == groupNew)
                    {
                        idGroup = Regex.Split(line, @"\t")[1];
                    }
                }
            }
            string dataTypeUpper = typeNew.ToUpper();
            string dataInput = string.Empty;
            string disciplineText = string.Empty;
            if (dataTypeUpper.StartsWith(DisciplineConstant.HVAC))
            {
                disciplineText = DisciplineConstant.HVAC;
            }
            switch (disciplineText)
            {
                case DisciplineConstant.HVAC:
                    string inputEndText = Regex.Split(typeNew, DisciplineConstant.HVAC)[1];
                    string nameParaCut = Regex.Replace(inputEndText, "([a-z])([A-Z])", "$1_$2").TrimStart().ToUpper();
                    dataInput = DisciplineConstant.HVAC + "_" + nameParaCut;
                    break;
                default:
                    string nameParaCut4 = Regex.Replace(typeNew, "([a-z])([A-Z])", "$1_$2").TrimStart().ToUpper();
                    dataInput = nameParaCut4;
                    break;
            }
            string newLine = string.Empty;
            int rowEnd = lines.Length;
            bool checkNameExist = checkExistModifedName(oldPara, nameNew);
            if (checkNameExist == true)
            {
                MessageBox.Show("Error: Name of parameter is existed.");
                return;
            }
            string warning = "WARNING: You cannot restore changed parameter by reverting to the original settings. The changed will be incompatible with old uses of the parameter, and Revit will treat them as two separate for the purposes of scheduling and tagging";
            DialogResult result = MessageBox.Show(warning, "Modify Parameter", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            int indexModify = 0;
            for (int j = 0; j < lines.Length; j++)
            {
                string line = lines[j];
                if (line.StartsWith("PARAM"))
                {
                    string paraFileOld = Regex.Split(line, @"\t")[2];
                    if (paraFileOld == oldPara)
                    {
                        indexModify = j;
                        string id = Regex.Split(line, @"\t")[1];
                        string category = Regex.Split(line, @"\t")[4];
                        string description= Regex.Split(line, @"\t")[7];
                        string userModify= Regex.Split(line, @"\t")[8];
                        newLine = "PARAM\t" + id + "\t" + nameNew + "\t" + dataInput + "\t" + category + "\t" + idGroup + "\t" + visible + "\t" + description + "\t" + userModify;
                    }
                }
            }
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int j = 0; j < rowEnd; j++)
                {
                    if (j == indexModify)
                    {
                        sw.WriteLine(newLine);
                    }
                    else
                    {
                        sw.WriteLine(lines[j]);
                    }
                }
            }
            string nodeTreeOld = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Text;
            string groupTreeOld = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Parent.Text;
            if (nodeTreeOld != nameNew && groupNew == groupTreeOld)
            {
                AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Text = nameNew;
            }
            else if (groupNew != groupTreeOld)
            {
                AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Remove();
                var nodeGs = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
                foreach (TreeNode treeG in nodeGs)
                {
                    if (treeG.Text == groupNew)
                    {
                        treeG.Nodes.Add(nameNew);
                    }
                }
            }
            AppPenalShareParameter.myFormModifyParameter.Close();
        }

        private void frmModifyParameter_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void frmModifyParameter_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }
        private bool checkExistModifedName(string oldName, string newName)
        {
            bool result = false;
            var nodeGs = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            foreach (TreeNode nodeG in nodeGs)
            {
                foreach (TreeNode nodeP in nodeG.Nodes)
                {
                    if (nodeP.Text != oldName)
                    {
                        if (nodeP.Text == newName)
                        {
                            result = true;
                            return result;
                        }
                    }
                }
            }
            return result;
        }
    }
}
