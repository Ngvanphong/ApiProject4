using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiProject4.Helper;
using System.Windows.Forms;

namespace ApiProject4.ShareParameter
{
    [Transaction(TransactionMode.Manual)]
    public class ShareParameterBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPenalShareParameter.ShowFormShareParameter();
                GetInforDrop();
            }
            return Result.Succeeded;
        }

        private void GetInforDrop()
        {
            FilterParameter filter = new FilterParameter();
            SearchParameter search = new SearchParameter();
            string[] searchText = { search.ParameterName, search.GroupName };
            string[] filterText = { filter.None, filter.Unique, filter.Duplicate };
            AppPenalShareParameter.myFormShareParameter.dropSearchParameters.Items.AddRange(searchText);
            AppPenalShareParameter.myFormShareParameter.dropSearchParameters.SelectedIndex = 0;
            AppPenalShareParameter.myFormShareParameter.dropFilterParameterSource.Items.AddRange(filterText);
        }
    }
    public class FilterParameter
    {
        public string None { get { return "None"; } }

        public string Unique { get { return "Unique"; } }

        public string Duplicate { get { return "Duplicate"; } }

    }

    public class SearchParameter
    {
        public string ParameterName { get { return "Parameter Name"; } }

        public string GroupName { get { return "Group Name"; } }
    }

}
