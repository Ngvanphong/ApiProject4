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
            int idInput = idGroup + 1;
            if (nRow > 1)
            {
                string lineAdd = string.Empty;
                for (int i = 0; i < nRow - 1; i++)
                {
                    string name = AppPenalShareParameter.myFormAddgroup.dataGridViewAddGroup.Rows[i].Cells[0].Value.ToString();
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
        }
    }
}
