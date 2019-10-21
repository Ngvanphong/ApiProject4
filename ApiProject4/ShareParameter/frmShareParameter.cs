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
        public frmShareParameter(ExternalEvent eventShareParameter, ShareParameterHandler handlerShareParameter)
        {
            InitializeComponent();
            _eventShareParameter = eventShareParameter;
            _handlerShareParameter = handlerShareParameter;
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
                AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes.Clear();
                ExtensionMethod.LoadTreeView(AppPenalShareParameter.myFormShareParameter.treeViewSourceParameter, listGroup);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            string path = AppPenalShareParameter.myFormShareParameter.txtMasterPathShareParameterFile.Text;
            string[] lines = System.IO.File.ReadAllLines(path);
            int rowEnd = 0;
            int idGroup = 0;
            string lineAdd = "GROUP\t3\tDoor3";
            foreach (string line in lines)
            {
                if (line.StartsWith(@"*PARAM") == false)
                {
                    rowEnd += 1;
                }else
                {
                    break;
                }
            }
            foreach(string group in lines)
            {
                if (group.StartsWith("GROUP") == true)
                {
                    string id = Regex.Split(group, @"\t")[1];
                    if(idGroup> int.Parse(id))
                    {
                        idGroup = int.Parse(id);
                    }
                }
            }
            //AddGroup
            AppPenalShareParameter.ShowFormAddGroup();

            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < rowEnd; i++)
                    sw.WriteLine(lines[i]);
                sw.WriteLine(lineAdd);
                for (int i = rowEnd; i < lines.Length; i++)
                    sw.WriteLine(lines[i]);
            }
        }
    }
}
