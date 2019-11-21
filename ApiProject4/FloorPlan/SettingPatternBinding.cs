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
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ApiProject4.FloorPlan
{
    [Transaction(TransactionMode.Manual)]
    public class SettingPatternBinding : IExternalCommand
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
            try
            {
                List<ParameterFilterElement> coll = new FilteredElementCollector(doc).OfClass(typeof(ParameterFilterElement)).Cast<ParameterFilterElement>().ToList();
                List<String> listNameFilter = function.getAllFilterAddin();
                foreach(var item in coll)
                {
                    if (listNameFilter.Exists(x => x == item.Name))
                    {
                        using(Transaction t3= new Transaction(doc, "DeletePattern"))
                        {
                            t3.Start();
                            doc.Delete(item.Id);
                            t3.Commit();
                        } 
                    }
                }
            }
            catch { }

            var listSelectIds = uiApp.ActiveUIDocument.Selection.GetElementIds();
            List<Element> listFloorSelect = new List<Element>();
            foreach (ElementId id in listSelectIds)
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
            List<FilterFloor> listFilter = function.GetAllFloorPatten(listFloorSelect);
            Autodesk.Revit.DB.View viewActive = doc.ActiveView;
            foreach (var filter in listFilter)
            {
                List<FilterRule> filterRules = new List<FilterRule>();
                using (Transaction t = new Transaction(doc, "Add view filter"))
                {
                    t.Start();
                    ParameterFilterElement parameterFilterElement = ParameterFilterElement.Create(doc, filter.NameType + " " + filter.OffsetLevel * 0.3048 * 1000+" Addin", categories);
                    ElementId offsetParamId = new ElementId(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM);
                    filterRules.Add(ParameterFilterRuleFactory.CreateEqualsRule(offsetParamId, filter.OffsetLevel, 0.001));
                    ElementId nameFloorParamId = new ElementId(BuiltInParameter.ALL_MODEL_TYPE_NAME);
                    filterRules.Add(ParameterFilterRuleFactory.CreateEqualsRule(nameFloorParamId, filter.NameType, false));

                    List<ElementFilter> elemFilters = new List<ElementFilter>();
                    foreach (FilterRule filterRule in filterRules)
                    {
                        ElementParameterFilter elemParamFilter = new ElementParameterFilter(filterRule);
                        elemFilters.Add(elemParamFilter);
                    }
                    LogicalAndFilter elemFilter = new LogicalAndFilter(elemFilters);
                    parameterFilterElement.SetElementFilter(elemFilter);
                    viewActive.AddFilter(parameterFilterElement.Id);
                    viewActive.SetFilterVisibility(parameterFilterElement.Id, true);
                    OverrideGraphicSettings overrideSettings = viewActive.GetFilterOverrides(parameterFilterElement.Id);
                    overrideSettings.SetSurfaceForegroundPatternId(filter.Patten.Id);
                    overrideSettings.SetSurfaceForegroundPatternColor(filter.ColorPatten);
                    viewActive.SetFilterOverrides(parameterFilterElement.Id, overrideSettings);
                    t.Commit();
                }
            }
            function.WriteXmlFloor(listFilter);

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
                    foreach (var patern in fillPatternElements)
                    {
                        if (!listResult.Exists(x => x.Patten.Name == patern.Name))
                        {
                            FillPattern pattenDraf = patern.GetFillPattern();
                            if (patern.Name != "<Solid fill>"&& pattenDraf.Target==FillPatternTarget.Drafting)
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
                    filter.ColorPatten = new Autodesk.Revit.DB.Color(colorS.R, colorS.G, colorS.B);
                    filter.ColorSysterm = colorS;
                    index += 1;
                    listResult.Add(filter);
                }
            }
            return listResult;
        }

        public void WriteXmlFloor(List<FilterFloor> listFloorSetting)
        {
            string name = _doc.Title + "floorPattern.xml";
            string fullPath = Path.GetFullPath(name);
            XmlTextWriter writer = new XmlTextWriter(name, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");
            foreach(var filter in listFloorSetting)
            {
                CreateNodeText(filter, writer);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        private void CreateNodeText(FilterFloor element, XmlTextWriter writer)
        {
            writer.WriteStartElement("PatternFloor");
            writer.WriteStartElement("NameType");
            writer.WriteString(element.NameType.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("OffsetLevel");
            writer.WriteString((element.OffsetLevel * 0.3048 * 1000).ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Patten");
            writer.WriteString(element.Patten.Name.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("ColorSystem");
            writer.WriteString(element.ColorSysterm.ToArgb().ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public List<string> getAllFilterAddin()
        {
            List<string> listNamefilter = new List<string>();
            string name = _doc.Title + "floorPattern.xml";
            try
            {
                string fullPath = Path.GetFullPath(name);
                var xmlDoc = XDocument.Load(fullPath);
                var xmlElement = xmlDoc.Element("Table").Elements("PatternFloor");
                foreach (var item in xmlElement)
                {
                    string value = item.Element("NameType").Value+ " " + item.Element("OffsetLevel").Value + " Addin";
                    listNamefilter.Add(value);
                }
            }
            catch { }
            return listNamefilter;
        }
        public List<string> getListSpecialXml(string nameChoose)
        {
            List<string> listValue = new List<string>();
            string name = _doc.Title + "floorPattern.xml";
          
                string fullPath = Path.GetFullPath(name);
                var xmlDoc = XDocument.Load(fullPath);
                var xmlElement = xmlDoc.Element("Table").Elements("PatternFloor");
                foreach (var item in xmlElement)
                {
                string value = item.Element(nameChoose).Value;
                listValue.Add(value);       
                }
            return listValue;
        }

    }


    public class FilterFloor
    {
        public string NameType { get; set; }

        public double OffsetLevel { get; set; }

        public FillPatternElement Patten { get; set; }

        public Autodesk.Revit.DB.Color ColorPatten { set; get; }

        public System.Drawing.Color ColorSysterm { set; get; }


    }
}
