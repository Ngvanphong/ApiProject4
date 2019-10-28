using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ApiProject4.ShareParameter
{
    public class AddParameterHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var listNameDiscipline = GetTypeParameter.GetAllDiscipline(app);
            AppPenalShareParameter.myFormAddShareParameter.comboBoxDisciiplinePara.Items.Clear();
            AppPenalShareParameter.myFormAddShareParameter.comboBoxDisciiplinePara.Items.AddRange(listNameDiscipline);
            AppPenalShareParameter.myFormAddShareParameter.dropParameterGroup.Items.Clear();
            var listItemGroup = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            foreach (TreeNode node in listItemGroup)
            {
                AppPenalShareParameter.myFormAddShareParameter.dropParameterGroup.Items.Add(node.Text);
            }
        }
        public string GetName()
        {
            return "AddParameterHandlers";
        }
    }
    public static class GetTypeParameter
    {
        public static Dictionary<string, List<ParameterType>> GetAllTypeAndDiscipline(UIApplication app)
        {

            Dictionary<string, List<ParameterType>> disciplineToParameterTypes = new Dictionary<string, List<ParameterType>>();

            string oriFile = app.Application.SharedParametersFilename;
            string tempFile = Path.GetTempFileName() + ".txt";
            try
            {
                using (File.Create(tempFile)) { }
                app.Application.SharedParametersFilename = tempFile;
                Definitions tempDefinitions = app.Application.OpenSharedParameterFile().Groups.Create("TemporaryDefintionGroup").Definitions;
                foreach (ParameterType pt in Enum.GetValues(typeof(ParameterType)))
                {
                    if (pt != ParameterType.Invalid)
                    {
                        ExternalDefinitionCreationOptions option = new ExternalDefinitionCreationOptions(pt.ToString(), pt);
                        Definition def = tempDefinitions.Create(option);
                        UnitGroup ug = UnitUtils.GetUnitGroup(def.UnitType);
                        if (disciplineToParameterTypes.ContainsKey(ug.ToString()))
                        {
                            disciplineToParameterTypes[ug.ToString()].Add(pt);
                        }
                        else
                        {
                            disciplineToParameterTypes.Add(ug.ToString(), new List<ParameterType> { pt });
                        }
                    }
                }

                File.Delete(tempFile);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString(), "GroupParameterTypesOnDiscipline");
            }
            finally
            {
                app.Application.SharedParametersFilename = oriFile;
            }

            return disciplineToParameterTypes;
        }

        public static string[] GetAllType(Dictionary<string, List<ParameterType>> targetObj, string discipline)
        {
            string[] typeParas = null;
            List<string> typeParaNames = new List<string>();
            foreach (var disciplinePara in targetObj)
            {
                var key = disciplinePara.Key;
                if (key == discipline)
                {
                    foreach (var pt in disciplinePara.Value)
                    {
                        string label = pt.ToString();
                        try
                        {
                            label = LabelUtils.GetLabelFor(pt);
                            typeParaNames.Add(label);
                        }
                        catch { continue; }
                    }
                }
            }
            typeParas = typeParaNames.ToArray();
            return typeParas;
        }
        public static string[] GetAllDiscipline(UIApplication app)
        {
            string[] disciplineNames = null;
            List<string> listDisciplineNames = new List<string>();
            Dictionary<string, List<ParameterType>> targetObj = GetAllTypeAndDiscipline(app);
            foreach (var disciplinePara in targetObj)
            {
                listDisciplineNames.Add(disciplinePara.Key);
            }
            disciplineNames = listDisciplineNames.ToArray();
            return disciplineNames;
        }

        public static string GetParameteType(Dictionary<string, List<ParameterType>> targetObj, string discipline, string nameParameter)
        {
            var typeWirte = string.Empty;
            foreach (var disciplinePara in targetObj)
            {
                var key = disciplinePara.Key;
                if (key == discipline)
                {
                    foreach (var pt in disciplinePara.Value)
                    {
                        string label = pt.ToString();
                        string compare = string.Empty;
                        try
                        {
                            compare = LabelUtils.GetLabelFor(pt);
                        }
                        catch { continue; }
                        if (compare == nameParameter)
                        {
                            typeWirte = label;
                        }
                    }
                }
            }
            typeWirte = ExcepttNameTofile(typeWirte);
            return typeWirte;
        }

        public static string ExcepttNameTofile(string parameterType)
        {
            string typeWirte = parameterType;
            switch (typeWirte)
            {
                case "YesNo":
                    typeWirte = "YESNO";
                    break;
                case "DisplacementDeflection":
                    typeWirte = "DISPLACEMENT/DEFLECTION";
                    break;
                case "MultilineText":
                    typeWirte = "MULTILINETEXT";
                    break;
                case "NumberOfPoles":
                    typeWirte = "NOOFPOLES";
                    break;
                case "Invalid":
                    typeWirte = string.Empty;
                    break;
                case "LoadClassification":
                    typeWirte = "LOADCLASSIFICATION";
                    break;
                case "FamilyType":
                    typeWirte = "FAMILYTYPE";
                    break;
                case "ThermalExpansion":
                    typeWirte = "THERMAL_EXPANSION_COEFFICIENT";
                    break;
                case "ForcePerLength":
                    typeWirte = "POINT_SPRING_COEFFICIENT";
                    break;
                case "LinearForcePerLength":
                    typeWirte = "LINEAR_SPRING_COEFFICIENT";
                    break;
                case "AreaForcePerLength":
                    typeWirte = "AREA_SPRING_COEFFICIENT";
                    break;
                case "ForceLengthPerAngle":
                    typeWirte = "ROTATIONAL_POINT_SPRING_COEFFICIENT";
                    break;
                case "LinearForceLengthPerAngle":
                    typeWirte = "ROTATIONAL_LINEAR_SPRING_COEFFICIENT";
                    break;
            }
            return typeWirte;
        }
        public static string ExceptFileToName(string parameterFile)
        {
            string typeWirte = parameterFile;
            switch (typeWirte)
            {
                case "YESNO":
                    typeWirte = "YesNo";
                    break;
                case "DISPLACEMENT/DEFLECTION":
                    typeWirte = "DisplacementDeflection";
                    break;
                case "MULTILINETEXT":
                    typeWirte = "MultilineText";
                    break;
                case "NOOFPOLES":
                    typeWirte = "NumberOfPoles";
                    break;
                case "LOADCLASSIFICATION":
                    typeWirte = "LoadClassification";
                    break;
                case "FAMILYTYPE":
                    typeWirte = "FamilyType";
                    break;
                case "THERMAL_EXPANSION_COEFFICIENT":
                    typeWirte = "ThermalExpansion";
                    break;
                case "POINT_SPRING_COEFFICIENT":
                    typeWirte = "ForcePerLength";
                    break;
                case  "LINEAR_SPRING_COEFFICIENT":
                    typeWirte = "LinearForcePerLength";
                    break;
                case "AREA_SPRING_COEFFICIENT":
                    typeWirte = "AreaForcePerLength";
                    break;
                case "ROTATIONAL_POINT_SPRING_COEFFICIENT":
                    typeWirte = "ForceLengthPerAngle";
                    break;
                case "ROTATIONAL_LINEAR_SPRING_COEFFICIENT":
                    typeWirte = "LinearForceLengthPerAngle";
                    break;
            }
            return typeWirte;
        }

        public static string ConvertFileToNamPara(Dictionary<string, List<ParameterType>> targetObj,string filePara,out string nameDiscipline)
        {
            string result = string.Empty;
            string disciplineResult = string.Empty;
            filePara = ExceptFileToName(filePara).ToUpper();
            string typeOldUpper = Regex.Replace(filePara, "([A-Z])_([A-Z])", "$1$2").TrimStart();
            foreach(var item in targetObj)
            {
                var discipline = item.Key;
               foreach(var pt in item.Value)
                {
                    string lable = pt.ToString();
                    lable = lable.ToUpper();
                    if (lable == typeOldUpper)
                    {
                        try
                        {
                            string compare = LabelUtils.GetLabelFor(pt);
                            result = compare;
                            disciplineResult = discipline;
                        }
                        catch { }
                    }
                    
                }
            }
            nameDiscipline = disciplineResult;
            return result;
        }
    }
}
