using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI.Selection;
using ApiProject4.Helper;
using System.Windows.Forms;
using System.Data;

namespace ApiProject4.ColorElement
{
    public class AutoApplyColorHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            if (AppPenalColorElement.CancelAutoHandler == true)
            {
                AppPenalColorElement._updater = new ElevationWatcherUpdater(app.ActiveAddInId);
                UpdaterRegistry.RegisterUpdater(AppPenalColorElement._updater);
                var listCategory = new List<BuiltInCategory>()
                    {
                        BuiltInCategory.OST_FloorsStructure,
                        BuiltInCategory.OST_RoofsStructure,
                        BuiltInCategory.OST_StructuralFraming,
                        BuiltInCategory.OST_StructuralColumns,
                        BuiltInCategory.OST_DuctCurves,
                        BuiltInCategory.OST_DuctSystem,
                        BuiltInCategory.OST_PipeCurves,
                        BuiltInCategory.OST_Wire,
                        BuiltInCategory.OST_WallsStructure,
                        BuiltInCategory.OST_Walls,
                        BuiltInCategory.OST_StructuralFoundation,
                        BuiltInCategory.OST_Stairs,
                        BuiltInCategory.OST_Doors,
                        BuiltInCategory.OST_Windows,
                        BuiltInCategory.OST_Rebar,
                    };
                var f = new ElementMulticategoryFilter(listCategory);
                UpdaterRegistry.AddTrigger(AppPenalColorElement._updater.GetUpdaterId(), f, Element.GetChangeTypeElementAddition());
                UpdaterRegistry.AddTrigger(AppPenalColorElement._updater.GetUpdaterId(), f, Element.GetChangeTypeAny());              
            }
            else if (AppPenalColorElement.CancelAutoHandler == false)
            {
                try
                {
                    UpdaterRegistry.UnregisterUpdater(AppPenalColorElement._updater.GetUpdaterId());
                    AppPenalColorElement._updater = null;
                }
                catch { AppPenalColorElement._updater = null; }
            }
        }
        public string GetName()
        {
            return "AutoApplyColorHandler";
        }
    }
    public class ElevationWatcherUpdater : IUpdater
    {
        static AddInId _appId;
        static UpdaterId _updaterId;
        public ElevationWatcherUpdater(AddInId id)
        {
            _appId = id;
            _updaterId = new UpdaterId(_appId, new Guid("8a5b141a-cd9e-4c12-9f99-168c3ddb1de2"));
        }

        public static bool breakEvent = false;
        public void Execute(UpdaterData data)
        {
            Document doc = data.GetDocument();
            Autodesk.Revit.ApplicationServices.Application app = doc.Application;
            var listElementIdAdd = data.GetAddedElementIds().ToList();
            var listElementModifile = data.GetModifiedElementIds().ToList();
            if (listElementIdAdd.Count == 1)
            {
                bool isModified = false;
                SetColorAuto(doc, listElementIdAdd, out isModified);
                if (isModified == true)
                {
                    breakEvent = true;
                }
                else
                {
                    breakEvent = false;
                }
            }
            else if (listElementModifile.Count == 1 && breakEvent == false)
            {
                bool isModified = false;
                SetColorAuto(doc, listElementModifile, out isModified);
                if (isModified == true)
                {
                    breakEvent = true;
                }
                else
                {
                    breakEvent = false;
                }
            }
            else if (breakEvent == true)
            {
                breakEvent = false;
            }
        }

        public string GetAdditionalInformation()
        {
            return "ngvanphong2012@gmail.com";
        }

        public UpdaterId GetUpdaterId()
        {
            return _updaterId;
        }

        public string GetUpdaterName()
        {
            return "ColorUpdater";
        }

        public ChangePriority GetChangePriority()
        {
            return ChangePriority.Structure;
        }

        void SetColorAuto(Document doc, List<ElementId> elementIds, out bool isModified)
        {
            isModified = false;
            List<System.Drawing.Color> colors = new ColorSystem().ColorUser;
            string nameParameter = AppPenalColorElement.myFormColorElement.listBoxParameter.SelectedItem.ToString();
            foreach (ElementId id in elementIds)
            {
                Element el = doc.GetElement(id);
                foreach (Parameter parae in el.Parameters)
                {
                    if (parae.Definition.Name == nameParameter)
                    {
                        string value = ParameterRevit.ParameterToString(parae);
                        int index = 0;
                        if (!AppPenalColorElement.ListValueColor.Exists(x => x.Value == value))
                        {
                            index = AppPenalColorElement.ListValueColor.Count;
                            ValueColor valueColor = new ValueColor();
                            valueColor.Value = value;
                            System.Drawing.Color colorWin = colors[index];
                            valueColor.ColorSystem = colorWin;
                            valueColor.Color = new Autodesk.Revit.DB.Color(colorWin.R, colorWin.G, colorWin.B);
                            AppPenalColorElement.ListValueColor.Add(valueColor);
                            var bindingSource = (BindingSource)AppPenalColorElement.myFormColorElement.dataGridViewValueParameter.DataSource;
                            bindingSource.Add(new { valueColor.Value });
                            AppPenalColorElement.myFormColorElement.dataGridViewValueParameter.DataSource = bindingSource;
                            AppPenalColorElement.myFormColorElement.dataGridViewValueParameter.Rows[index].DefaultCellStyle.BackColor = colorWin;
                        }
                        else
                        {
                            for (int i = 0; i < AppPenalColorElement.ListValueColor.Count; i++)
                            {
                                if (AppPenalColorElement.ListValueColor[i].Value == value)
                                {
                                    index = i;
                                    break;
                                }
                            }
                        }
                        Autodesk.Revit.DB.Color color = AppPenalColorElement.ListValueColor[index].Color;
                        SetColorElement.SetColor(color, doc, el);
                        isModified = true;
                    }
                }
            }
        }
    }
}





