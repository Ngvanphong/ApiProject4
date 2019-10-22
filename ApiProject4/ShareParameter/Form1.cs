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

namespace ApiProject4.ShareParameter
{
    public partial class frmAddSharedParameter : Form
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

        }

        private void btnCreateParameter_Click(object sender, EventArgs e)
        {
            List<string> listName = new List<string>();
            var itemCount = AppPenalShareParameter.myFormAddShareParameter.dataGridViewCreateParameter.RowCount;
            if (itemCount > 1)
            {
                for(int i = 0; i < itemCount-1; i++)
                {
                    string name = AppPenalShareParameter.myFormAddShareParameter.dataGridViewCreateParameter.Rows[i].Cells[0].Value.ToString();
                    listName.Add(name);
                }
                string parameterGroup = AppPenalShareParameter.myFormAddShareParameter.dropParameterGroup.SelectedText;
                bool exist = CheckExistParameterName(listName, parameterGroup, AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter);
            }

        }
        private bool CheckExistParameterName(List<string> parameterName,string parameterGroup,TreeView treeView)
        {
            var allGroup = treeView.Nodes;
            bool result = false;
            int  ortherParaname = parameterName.Distinct().Count();
            if (ortherParaname != parameterName.Count)
            {
                result = true;
            }
            foreach(TreeNode node in allGroup)
            {
                if (node.Text == parameterGroup)
                {
                    var allParameter = node.Nodes;
                    foreach(TreeNode nodePara in allParameter)
                    {
                        if (parameterName.Exists(x=>x==nodePara.Text))
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
