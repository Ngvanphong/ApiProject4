using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ApiProject4.ShareParameter
{
    public static class ExtensionMethod
    {
        public static List<GroupParameters> LoadParameterByTxt(string path)
        {
            List<GroupParameters> listGroupParameter = new List<GroupParameters>();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.StartsWith("GROUP") == true)
                {
                    GroupParameters groupParameter = new GroupParameters();
                    string[] textGroup = Regex.Split(line, @"\t");
                    groupParameter.Group = textGroup[2];
                    groupParameter.Id = int.Parse(textGroup[1]);
                    foreach (var linePara in lines)
                    {
                        if (linePara.StartsWith("PARAM") == true)
                        {
                            string[] textPara = Regex.Split(linePara, @"\t");
                            if(textPara[5]== textGroup[1])
                            {
                                groupParameter.NameParameter.Add(textPara[2]);
                                groupParameter.IdParameter.Add(Guid.Parse(textPara[1]));
                            }
                        }
                    }
                    listGroupParameter.Add(groupParameter);
                }
            }
            return listGroupParameter;
        }

        public static void LoadTreeView(TreeView treeView, List<GroupParameters> listGroupParameter)
        {
            foreach(GroupParameters group in listGroupParameter)
            {
                TreeNode node = treeView.Nodes.Add(group.Group);
                foreach(var para in group.NameParameter)
                {
                    node.Nodes.Add(para);
                }    
            }
        }

        
    }
}
