using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiProject4.ShareParameter
{
    public partial class frmDeleteGroup : Form
    {
        public frmDeleteGroup()
        {
            InitializeComponent();
        }

        private void frmDeleteGroup_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void frmDeleteGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void btnDeleteGoupOrMove_Click(object sender, EventArgs e)
        {
            string warning = "WARNING: Do you want to delete group?";
            DialogResult result = MessageBox.Show(warning, "Delete Group", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string groupMoveTo = string.Empty;
            try
            {
                groupMoveTo = AppPenalShareParameter.myFormDeleteGroup.dropGroupChooesDelete.SelectedItem.ToString();
            }
            catch { }

            string groupOld = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Text;
            string path = AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text;
            var lines = System.IO.File.ReadAllLines(path);
            int rowEnd = lines.Length;
            string idOldGroup = "0";
            string idNewGroup = "0";
            foreach (string line in lines)
            {
                if (line.StartsWith("GROUP"))
                {
                    string nameG = Regex.Split(line, @"\t")[2];
                    if (nameG == groupOld)
                    {
                        idOldGroup = Regex.Split(line, @"\t")[1];
                    }
                    else if (nameG == groupMoveTo)
                    {
                        idNewGroup = Regex.Split(line, @"\t")[1];
                    }
                }
            }

            if (!string.IsNullOrEmpty(groupMoveTo) && groupMoveTo != "")
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int j = 0; j < rowEnd; j++)
                    {
                        if (lines[j].StartsWith("PARAM"))
                        {
                            string idGroup = Regex.Split(lines[j], @"\t")[5];
                            if (idGroup == idOldGroup)
                            {
                                string id = Regex.Split(lines[j], @"\t")[1];
                                string name = Regex.Split(lines[j], @"\t")[2];
                                string dataType = Regex.Split(lines[j], @"\t")[3];
                                string visible = Regex.Split(lines[j], @"\t")[6];
                                string category = Regex.Split(lines[j], @"\t")[4];
                                string description = Regex.Split(lines[j], @"\t")[7];
                                string userModify= Regex.Split(lines[j], @"\t")[8];
                                string lineNew = "PARAM\t" + id + "\t" + name + "\t" + dataType + "\t" + category + "\t" + idNewGroup + "\t" + visible + "\t" + description + "\t" + userModify;
                                sw.WriteLine(lineNew);
                            }
                            else
                            {
                                sw.WriteLine(lines[j]);
                            }

                        }
                        else if (lines[j].StartsWith("GROUP"))
                        {
                            string nameG = Regex.Split(lines[j], @"\t")[2];
                            if (nameG != groupOld)
                            {
                                sw.WriteLine(lines[j]);
                            }
                        }
                        else
                        {
                            sw.WriteLine(lines[j]);
                        }
                    }
                }
                //Update tree;
                var nodeChoose = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode;
                var nodeParaChoose = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Nodes;
                var allTreeGr = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
                foreach (TreeNode node in allTreeGr)
                {
                    if (node.Text == groupMoveTo)
                    {
                        foreach (TreeNode nodePa in nodeParaChoose)
                        {
                            node.Nodes.Add(nodePa.Text);
                        }
                    }
                }
                AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Remove();
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int j = 0; j < rowEnd; j++)
                    {
                        if (lines[j].StartsWith("PARAM"))
                        {
                            string idGroup = Regex.Split(lines[j], @"\t")[5];
                            if (idGroup != idOldGroup)
                            {
                                sw.WriteLine(lines[j]);
                            }
                        }
                        else if (lines[j].StartsWith("GROUP"))
                        {
                            string nameG = Regex.Split(lines[j], @"\t")[2];
                            if (nameG != groupOld)
                            {
                                sw.WriteLine(lines[j]);
                            }
                        }
                        else
                        {
                            sw.WriteLine(lines[j]);
                        }
                    }
                }
                AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode.Remove();
            }
            AppPenalShareParameter.myFormDeleteGroup.Close();
        }
    }
}
