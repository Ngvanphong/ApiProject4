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
    public partial class frmRenameGroup : Form
    {
        public frmRenameGroup()
        {
            InitializeComponent();
        }

        private void btnRenameGroup_Click(object sender, EventArgs e)
        {
            string oldName = AppPenalShareParameter.myFormRenameGroup.dataGridViewRenameGroup.Rows[0].Cells[0].Value.ToString();
            string newName = AppPenalShareParameter.myFormRenameGroup.dataGridViewRenameGroup.Rows[0].Cells[1].Value.ToString();
            string path = AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text;
            if (CheckExistRenameGroup(newName) == true)
            {
                MessageBox.Show("Error: Name of group is existed");
                return;
            }
            ChangeName(path, oldName, newName);
            TreeNode nodeSelect = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.SelectedNode;
            nodeSelect.Text = newName;
            AppPenalShareParameter.myFormRenameGroup.Hide();
        }
        private void ChangeName(string path, string oldName, string newName)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            int rowEnd = 0;
            int idGroup = 0;
            foreach (string line in lines)
            {
                if (line.StartsWith("GROUP") == true)
                {
                    string groupName = Regex.Split(line, @"\t")[2];
                    if (groupName == oldName)
                    {
                        break;
                    }else
                    {
                        rowEnd += 1;
                    }
                }else
                {
                    rowEnd += 1;
                }      
            }
            foreach (string line in lines)
            {
                if (line.StartsWith("GROUP") == true)
                {
                    string groupName = Regex.Split(line, @"\t")[2];
                    if (groupName == oldName && newName != string.Empty && newName != "")
                    {
                        idGroup = int.Parse(Regex.Split(line, @"\t")[1]);
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            string lineAdd = "GROUP\t" + idGroup + "\t" + newName;
                            for (int j = 0; j < rowEnd; j++)
                                sw.WriteLine(lines[j]);
                            sw.WriteLine(lineAdd);
                            for (int j = rowEnd+1; j < lines.Length; j++)
                                sw.WriteLine(lines[j]);
                        }
                    }
                }
            }
        }

        private bool CheckExistRenameGroup(string newName)
        {
            bool result = false;
            var itemGroups = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            foreach (TreeNode group in itemGroups)
            {
                if (group.Text == newName)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
