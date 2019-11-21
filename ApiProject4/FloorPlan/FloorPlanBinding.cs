using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiProject4.Helper;
using System.Windows.Forms;

namespace ApiProject4.FloorPlan
{
    [Transaction(TransactionMode.Manual)]
    public class FloorPlanBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //if (CheckAccess.CheckLicense() == true)
            //{
                List<ElementId> categories = new List<ElementId>();
                categories.Add(new ElementId(BuiltInCategory.OST_Floors));
                BindingFunction function = new BindingFunction(uiApp);
                var listSelectIds = uiApp.ActiveUIDocument.Selection.GetElementIds();
                List<Element> listFloorSelect = new List<Element>();
                foreach(ElementId id in listSelectIds)
                {
                    try
                    {
                        Element ele = doc.GetElement(id);
                        if (ele.Category.Name == "Floors")
                        {
                            listFloorSelect.Add(ele);

                        }
                    }
                    catch { continue; }
                }
                List<FilterFloor> listFilter= function.GetAllFloorPatten(listFloorSelect);
                Autodesk.Revit.DB.View viewActive = doc.ActiveView;
                foreach (var filter in listFilter)
                {
                    List<FilterRule> filterRules = new List<FilterRule>();
                    using (Transaction t = new Transaction(doc, "Add view filter"))
                    {
                        t.Start();
                        ParameterFilterElement parameterFilterElement = ParameterFilterElement.Create(doc, filter.NameType+" "+filter.OffsetLevel * 0.3048 * 1000, categories);
                        ElementId offsetParamId = new ElementId(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM);
                        filterRules.Add(ParameterFilterRuleFactory.CreateEqualsRule(offsetParamId, filter.OffsetLevel, 0.001));
                        ElementId nameFloorParamId = new ElementId(BuiltInParameter.ALL_MODEL_TYPE_NAME);
                        filterRules.Add(ParameterFilterRuleFactory.CreateEqualsRule(nameFloorParamId, filter.NameType,false));

                        List<ElementFilter> elemFilters = new List<ElementFilter>();
                        foreach (FilterRule filterRule in filterRules)
                        {
                            ElementParameterFilter elemParamFilter = new ElementParameterFilter(filterRule);
                            elemFilters.Add(elemParamFilter);
                        }
                        LogicalAndFilter elemFilter = new LogicalAndFilter(elemFilters);
                       // parameterFilterElement.SetRules(filterRules);
                        parameterFilterElement.SetElementFilter(elemFilter);
                        viewActive.AddFilter(parameterFilterElement.Id);
                        viewActive.SetFilterVisibility(parameterFilterElement.Id, true);

                        doc.Regenerate();

                        OverrideGraphicSettings overrideSettings = viewActive.GetFilterOverrides(parameterFilterElement.Id);
                        overrideSettings.SetSurfaceForegroundPatternId( filter.Patten.Id);
                        overrideSettings.SetSurfaceForegroundPatternColor(filter.ColorPatten);
                        viewActive.SetFilterOverrides(parameterFilterElement.Id, overrideSettings);
                        t.Commit();
                    }
                }
               
            //}
            return Result.Succeeded;
        }
    }
   public class BindingFunction
    {
        UIApplication _uiAppp;
        Document _doc;
        public BindingFunction(UIApplication uiAppp)
        {
            _uiAppp = uiAppp;
            _doc = uiAppp.ActiveUIDocument.Document;
        }
        public List<FilterFloor> GetAllFloorPatten(List<Element> allElements)
        {
            List<FilterFloor> listResult = new List<FilterFloor>();
            var fillPatternElements = new FilteredElementCollector(_doc).OfClass(typeof(FillPatternElement))
                .OfType<FillPatternElement>().OrderBy(fp => fp.Name).ToList();
            ColorWin colorWin = new ColorWin();
            int index = 0;
            foreach (Element el in allElements)
            {
                var offset = el.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble();  
                if (!listResult.Exists(x => (x.NameType == el.Name) && offset == x.OffsetLevel))
                {
                    FilterFloor filter = new FilterFloor();
                    filter.NameType = el.Name;
                    filter.OffsetLevel = offset;
                    foreach(var patern in fillPatternElements)
                    {
                        if (!listResult.Exists(x => x.Patten.Name == patern.Name))
                        {
                            if(patern.Name!= "<Solid fill>")
                            {
                                filter.Patten = patern;
                                break;
                            } 
                        }
                    }
                    if (filter.Patten == null)
                    {
                        filter.Patten = fillPatternElements.First();
                    }
                    System.Drawing.Color colorS = colorWin.ColorUser[index];
                    filter.ColorPatten=  new Autodesk.Revit.DB.Color(colorS.R, colorS.G, colorS.B);
                    index += 1;
                    listResult.Add(filter);
                }
            }
            return listResult;
        }
    }
    public class FilterFloor
    {
        public string NameType { get; set; }

        public double OffsetLevel { get; set; }

        public FillPatternElement Patten { get; set; }

        public Autodesk.Revit.DB.Color ColorPatten { set; get; }
    }
}
