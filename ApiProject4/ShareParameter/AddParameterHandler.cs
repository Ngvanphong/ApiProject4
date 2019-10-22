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
            var listNameParameterTypes = Enum.GetNames(typeof(ParameterType));
            AppPenalShareParameter.myFormAddShareParameter.dropParameterType.Items.Clear();
            AppPenalShareParameter.myFormAddShareParameter.dropParameterType.Items.AddRange(listNameParameterTypes);
            var discipline= Enum.GetNames(typeof(ViewDiscipline));
            AppPenalShareParameter.myFormAddShareParameter.dropDiscipline.Items.Clear();
            AppPenalShareParameter.myFormAddShareParameter.dropDiscipline.Items.AddRange(discipline);
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
}
