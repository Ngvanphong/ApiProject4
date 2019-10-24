using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using System.Text.RegularExpressions;
using System.IO;

namespace ApiProject4.ShareParameter
{
    public partial class frmAddSharedParameter : System.Windows.Forms.Form
    {

        public frmAddSharedParameter()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmAddSharedParameter_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void btnCreateParameter_Click(object sender, EventArgs e)
        {
            List<string> listName = new List<string>();
            var itemCount = AppPenalShareParameter.myFormAddShareParameter.dataGridViewCreateParameter.RowCount;
            if (itemCount > 1)
            {
                for (int i = 0; i < itemCount - 1; i++)
                {
                    string name = AppPenalShareParameter.myFormAddShareParameter.dataGridViewCreateParameter.Rows[i].Cells[0].Value.ToString();
                    listName.Add(name);
                }
                string parameterGroup = AppPenalShareParameter.myFormAddShareParameter.dropParameterGroup.SelectedItem.ToString();
                bool exist = CheckExistParameterName(listName, parameterGroup, AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter);
                if (exist == true)
                {
                    MessageBox.Show("Error: Name of parameter is existed");
                    return;
                }
                string parameterType = AppPenalShareParameter.myFormAddShareParameter.dropParameterType.SelectedItem.ToString();
                string path = AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text;
                if (string.IsNullOrEmpty(parameterGroup) || parameterGroup == "" || string.IsNullOrEmpty(parameterType) || parameterType == "")
                {
                    MessageBox.Show("You must input information");
                    return;
                }
                UpdateFileParameter(path, listName, parameterGroup, parameterType);
            }

        }
        private bool CheckExistParameterName(List<string> parameterName, string parameterGroup, TreeView treeView)
        {
            var allGroup = treeView.Nodes;
            bool result = false;
            int ortherParaname = parameterName.Distinct().Count();
            if (ortherParaname != parameterName.Count)
            {
                result = true;
                return result;
            }
            foreach (TreeNode node in allGroup)
            {
                var allParameter = node.Nodes;
                foreach (TreeNode nodePara in allParameter)
                {
                    if (parameterName.Exists(x => x == nodePara.Text))
                    {
                        result = true;
                        return result;
                    }
                }
            }
            return result;
        }

        private void UpdateFileParameter(string path, List<string> namePara, string groupName, string dataType)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            int rowEnd = lines.Length;
            string dataTypeUpper = dataType.ToUpper();
            string dataInput = string.Empty;
            string disciplineText = string.Empty;
            if (dataTypeUpper.StartsWith(DisciplineConstant.HVAC))
            {
                disciplineText = DisciplineConstant.HVAC;
            }
            switch (disciplineText)
            {
                case DisciplineConstant.HVAC:
                    string inputEndText = Regex.Split(dataType, DisciplineConstant.HVAC)[1];
                    string nameParaCut = Regex.Replace(inputEndText, "([a-z])([A-Z])", "$1_$2").TrimStart().ToUpper();
                    dataInput = DisciplineConstant.HVAC + "_" + nameParaCut;
                    break;
                default:
                    string nameParaCut4 = Regex.Replace(dataType, "([a-z])([A-Z])", "$1_$2").TrimStart().ToUpper();
                    dataInput = nameParaCut4;
                    break;
            }
            string idGroup = string.Empty;
            for (int l = 0; l < rowEnd; l++)
            {
                if (lines[l].StartsWith("GROUP") == true)
                {
                    string nameG = Regex.Split(lines[l], @"\t")[2];
                    if (nameG == groupName)
                    {
                        idGroup = Regex.Split(lines[l], @"\t")[1];
                    }
                }
            }

            using (StreamWriter sw = File.CreateText(path))
            {
                for (int j = 0; j < rowEnd; j++)
                {
                    sw.WriteLine(lines[j]);
                }
                foreach (var name in namePara)
                {
                    string id = Guid.NewGuid().ToString("D");
                    string textAdd = "PARAM\t" + id + "\t" + name + "\t" + dataInput + "\t\t" + idGroup + "\t1" + "\t\t" + "1";
                    sw.WriteLine(textAdd);
                }
            }

            var nodeGroups = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            foreach (TreeNode group in nodeGroups)
            {
                if (group.Text == groupName)
                {
                    foreach (var nameP in namePara)
                    {
                        group.Nodes.Add(nameP);
                    }
                }
            }
        }

        private void frmAddSharedParameter_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }
    }
}
