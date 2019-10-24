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
                    string nameG= Regex.Split(line, @"\t")[2];
                    if (nameG == groupNew)
                    {
                        idGroup= Regex.Split(line, @"\t")[1];
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
            int indexModify = 0;
            for(int j = 0; j < lines.Length; j++)
            {
                string line = lines[j];
                if (line.StartsWith("PARAM"))
                {
                    string paraFileOld = Regex.Split(line, @"\t")[2];
                    if (paraFileOld == oldPara)
                    {
                        indexModify = j;
                        string id = Regex.Split(line, @"\t")[1];
                        newLine = "PARAM\t" + id + "\t" + nameNew + "\t" + dataInput + "\t\t" + idGroup + "\t" + visible + "\t\t" + "1";   
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
        }
    }
}
