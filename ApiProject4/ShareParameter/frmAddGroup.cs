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
    public partial class frmAddGroup : Form
    {
        public frmAddGroup()
        {
            InitializeComponent();
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            string path = AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text;
            string[] lines = System.IO.File.ReadAllLines(path);
            int rowEnd = 0;
            int idGroup = 0;
            foreach (string line in lines)
            {
                if (line.StartsWith(@"*PARAM") == false)
                {
                    rowEnd += 1;
                }
                else
                {
                    break;
                }
            }
            foreach (string group in lines)
            {
                if (group.StartsWith("GROUP") == true)
                {
                    string id = Regex.Split(group, @"\t")[1];
                    if (idGroup < int.Parse(id))
                    {
                        idGroup = int.Parse(id);
                    }
                }
            }

            List<ListViewItem> listNameGruop = new List<ListViewItem>();
            var nRow = AppPenalShareParameter.myFormAddgroup.dataGridViewAddGroup.RowCount;
            List<string> listNameAdd = new List<string>();
            if (nRow > 1)
            {
                for (int k = 0; k < nRow - 1; k++)
                {
                    string name = AppPenalShareParameter.myFormAddgroup.dataGridViewAddGroup.Rows[k].Cells[0].Value.ToString();
                    listNameAdd.Add(name);
                }  
            }
            bool exist = CheckExistAddGroup(listNameAdd);
            if (exist == true)
            {
                MessageBox.Show("Error: Name of group is existed");
                return;
            }
            int idInput = idGroup + 1;
            if (nRow > 1)
            {
                string lineAdd = string.Empty;
                for (int i = 0; i < nRow - 1; i++)
                {
                    string name = AppPenalShareParameter.myFormAddgroup.dataGridViewAddGroup.Rows[i].Cells[0].Value.ToString();
                    AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes.Add(name);
                    lineAdd = lineAdd + "GROUP\t" + idInput + "\t" + name;
                    if (i < nRow - 2)
                    {
                        lineAdd = lineAdd + "\n";
                    }
                    idInput = idInput + 1;
                }
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int j = 0; j < rowEnd; j++)
                        sw.WriteLine(lines[j]);
                    sw.WriteLine(lineAdd);
                    for (int j = rowEnd; j < lines.Length; j++)
                        sw.WriteLine(lines[j]);
                }

            } 
            AppPenalShareParameter.myFormAddgroup.Close();
        }
        private bool CheckExistAddGroup(List<string> listName)
        {
            bool result = false;
            var listOtherName = listName.Distinct().ToList();
            var itemGroups = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            foreach(TreeNode group in itemGroups)
            {
                if (listOtherName.Exists(x => x == group.Text))
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }

        private void frmAddGroup_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void frmAddGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }
    }
}
