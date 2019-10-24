using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;

namespace ApiProject4.ShareParameter
{
    public class AddParameterHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var listNameParameterTypes = GetTypeParameter.GetAllType();
            AppPenalShareParameter.myFormAddShareParameter.dropParameterType.Items.Clear();
            AppPenalShareParameter.myFormAddShareParameter.dropParameterType.Items.AddRange(listNameParameterTypes);
            AppPenalShareParameter.myFormAddShareParameter.dropParameterGroup.Items.Clear();
            var listItemGroup = AppPenalShareParameter.myFormShareParameter.treeViewMasterParameter.Nodes;
            foreach(TreeNode node in listItemGroup)
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
        public static string[] GetAllType()
        {
            var listNameParameterTypes = Enum.GetNames(typeof(ParameterType));
            for (int i = 0; i < listNameParameterTypes.Length; i++)
            {
                if (listNameParameterTypes[i] == "YesNo")
                {
                    listNameParameterTypes[i] = "YESNO";
                }
                else if (listNameParameterTypes[i] == "DisplacementDeflection")
                {
                    listNameParameterTypes[i] = "DISPLACEMENT/DEFLECTION";
                }
                else if (listNameParameterTypes[i] == "MultilineText")
                {
                    listNameParameterTypes[i] = "MULTILINETEXT";
                }
                else if (listNameParameterTypes[i] == "NumberOfPoles")
                {
                    listNameParameterTypes[i] = "NOOFPOLES";
                }
                else if (listNameParameterTypes[i] == "Invalid")
                {
                    listNameParameterTypes[i] = string.Empty;
                }
                else if (listNameParameterTypes[i] == "LoadClassification")
                {
                    listNameParameterTypes[i] = "LOADCLASSIFICATION";
                }
                else if (listNameParameterTypes[i] == "FamilyType")
                {
                    listNameParameterTypes[i] = "string.Empty";
                }
               

            }
            return listNameParameterTypes;
        }
    }
}
