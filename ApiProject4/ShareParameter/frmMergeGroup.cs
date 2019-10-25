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
    public partial class frmMergeGroup : Form
    {
        public frmMergeGroup()
        {
            InitializeComponent();
        }

        private void frmMergeGroup_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void frmMergeGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void btnMergeParameterBind_Click(object sender, EventArgs e)
        {
            MergeParameter();
        }

        private void MergeParameter()
        {
            List<GroupParameter> listParameterChecked = new List<GroupParameter>();
            List<GroupParameter> listParamterMaster = new List<GroupParameter>();
            List<GroupParameter> listParaMerger = new List<GroupParameter>();
            var nodeGroups = AppPenalShareParameter.myFormShareParameter.treeViewSourceParameter.Nodes;
            foreach (TreeNode group in nodeGroups)
            {
                foreach (TreeNode para in group.Nodes)
                {
                    if (para.Checked)
                    {
                        GroupParameter groupPaSource = new GroupParameter();
                        groupPaSource.GroupName = group.Text;
                        groupPaSource.ParameterName = para.Text;
                        listParameterChecked.Add(groupPaSource);
                    }
                }
            }

            var nodeGroupMaster = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            foreach (TreeNode groupMaster in nodeGroupMaster)
            {
                foreach (TreeNode paraMas in groupMaster.Nodes)
                {
                    GroupParameter groupPaSource = new GroupParameter();
                    groupPaSource.GroupName = groupMaster.Text;
                    groupPaSource.ParameterName = paraMas.Text;
                    listParamterMaster.Add(groupPaSource);
                }
            }
            listParaMerger = listParameterChecked.Where(x => listParamterMaster.Exists(y => y.ParameterName == x.ParameterName) == false).ToList();
            string groupSelect = string.Empty;
            try
            {
                groupSelect = AppPenalShareParameter.myFormMergeParameter.dropGroupMerge.SelectedItem.ToString();
            }
            catch{}
            if (string.IsNullOrEmpty(groupSelect) || groupSelect == "")
            {
                MergeParaFileBinding.MerSampleGroup(listParaMerger, listParamterMaster);
                AppPenalShareParameter.myFormMergeParameter.Close();
            }
            else
            {

            }

        }
    }
    public static class MergeParaFileBinding
    {
        public static void MerSampleGroup(List<GroupParameter> paraMerge, List<GroupParameter> paraMaster)
        {
            string path = AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text;
            var lines = System.IO.File.ReadAllLines(path);
            int rowEnd = lines.Length;
            string pathSource = AppPenalShareParameter.myFormShareParameter.txtPathSourceSharedPamameter.Text;
            var lineSources = System.IO.File.ReadAllLines(pathSource);
            string newLine = string.Empty;
            string newLineGroup = string.Empty;
            List<GroupIndentity> listGroupNew = new List<GroupIndentity>();
            int idGroup = findIdNewGroup(lines);
            for (int i = 0; i < paraMerge.Count(); i++)
            {
                string groupNow = paraMerge[i].GroupName;
                string paraNow = paraMerge[i].ParameterName;
                string lineSource = findLineInSource(lineSources, paraNow);
                string id = Regex.Split(lineSource, @"\t")[1];
                string category = Regex.Split(lineSource, @"\t")[4];
                string type = Regex.Split(lineSource, @"\t")[3];
                string visible= Regex.Split(lineSource, @"\t")[6];
                string idGroupOld= Regex.Split(lineSource, @"\t")[5];
                if (paraMaster.Exists(x => x.GroupName == groupNow) == false)
                {
                    if (listGroupNew.Exists(x => x.GroupName == groupNow) == false)
                    {
                        if (newLineGroup == string.Empty)
                        {
                            newLineGroup ="GROUP\t" + idGroup.ToString() + "\t" + groupNow;
                        }
                        else
                        {
                            newLineGroup = newLineGroup + "\n" + "GROUP\t" + idGroup.ToString() + "\t" + groupNow;
                        }
                        if (newLine == string.Empty)
                        {
                            newLine = "PARAM\t" + id + "\t" + paraNow + "\t" + type + "\t" + category + "\t" + idGroup + "\t" + visible + "\t\t" + "1";
                        }else
                        {
                            newLine = newLine + "\n" + "PARAM\t" + id + "\t" + paraNow + "\t" + type + "\t" + category + "\t" + idGroup + "\t" + visible + "\t\t" + "1";
                        }
                        
                        GroupIndentity groupIden = new GroupIndentity();
                        groupIden.GroupName = groupNow;
                        groupIden.GroupId = idGroup.ToString();
                        listGroupNew.Add(groupIden);
                        idGroup = idGroup + 1;
                    }
                    else
                    {
                        foreach(var groupNew in listGroupNew)
                        {
                            if (groupNew.GroupName == groupNow)
                            {
                                if (newLine == string.Empty)
                                {
                                    newLine = "PARAM\t" + id + "\t" + paraNow + "\t" + type + "\t" + category + "\t" + groupNew.GroupId + "\t" + visible + "\t\t" + "1";
                                }
                                else
                                {
                                    newLine = newLine + "\n" + "PARAM\t" + id + "\t" + paraNow + "\t" + type + "\t" + category + "\t" + groupNew.GroupId + "\t" + visible + "\t\t" + "1";
                                }
                                break;
                            }
                        }
                       
                    }  
                }
                else
                {
                    string idGroupOldMaster = findIdExistGroup(lines, groupNow);
                    if (newLine == string.Empty)
                    {
                        newLine = "PARAM\t" + id + "\t" + paraNow + "\t" + type + "\t" + category + "\t" + idGroupOldMaster + "\t" + visible + "\t\t" + "1";
                    }
                    else
                    {
                        newLine = newLine + "\n" + "PARAM\t" + id + "\t" + paraNow + "\t" + type + "\t" + category + "\t" + idGroupOldMaster + "\t" + visible + "\t\t" + "1";
                    }
                }
            }
           int endGroup = 0;
           for(int k = 0; k < lines.Length; k++)
            {
                if (lines[k].StartsWith("*PARAM")==false)
                {
                    endGroup += 1;

                }else
                {
                    break;
                }
            }

            using (StreamWriter sw = File.CreateText(path))
            {
                for (int j = 0; j < endGroup; j++)
                {
                    sw.WriteLine(lines[j]);
                }
                if (newLineGroup != string.Empty)
                {
                    sw.WriteLine(newLineGroup);
                }
                for (int j= endGroup;j < rowEnd; j++)
                {
                    sw.WriteLine(lines[j]);
                }
                if (newLine != string.Empty)
                {
                    sw.WriteLine(newLine);
                }
            }
        }

        public static void MergeNewGroup(List<GroupParameter> paraMerge, List<GroupParameter> paraMaster,string newGroup)
        {

        }

        private static int findIdNewGroup(string[]lines)
        {
            int result = 1;
            foreach (string group in lines)
            {
                if (group.StartsWith("GROUP") == true)
                {
                    string id = Regex.Split(group, @"\t")[1];
                    if (result< int.Parse(id))
                    {
                        result = int.Parse(id);
                    }
                }
            }
            return result+1;
        }

        public static string findIdExistGroup(string[] lines,string groupName)
        {
            string result = string.Empty;
            foreach (string group in lines)
            {
                if (group.StartsWith("GROUP") == true)
                {
                    string name = Regex.Split(group, @"\t")[2];
                    if (name==groupName)
                    {
                        result = Regex.Split(group, @"\t")[1];
                        return result;
                    }
                }
            }
            return result;
        }

        private static string findLineInSource(string[]lineSources,string paraName)
        {
            string result = string.Empty;
            foreach(string line in lineSources)
            {
                if (line.StartsWith("PARAM"))
                {
                    string namePara = Regex.Split(line, @"\t")[2];
                    if (namePara == paraName)
                    {
                        result = line;
                        return result;
                    }
                }    
               
            }
            return result;
        }
    }
    public class GroupParameter
    {
        public string GroupName { set; get; }

        public string ParameterName { set; get; }
    }

    public class GroupIndentity
    {
        public string  GroupName { get; set; }
        public string GroupId { set; get; }
    }
}
