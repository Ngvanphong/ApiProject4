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

            string warning = "WARNING: Do you want reset filter for floor addin.";
            DialogResult result = MessageBox.Show(warning, "FloorPlan", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return Result.Succeeded;
            }

            var fillPatternElements = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement))
               .OfType<FillPatternElement>().OrderBy(fp => fp.Name).ToList();
            FillPatternElement patternMax = fillPatternElements.Where(x => x.Name == "<Solid fill>").First();
            List<ElementId> categories = new List<ElementId>();
            categories.Add(new ElementId(BuiltInCategory.OST_Floors));
            BindingFunction function = new BindingFunction(uiApp);
            try
            {
                List<ParameterFilterElement> coll = new FilteredElementCollector(doc).OfClass(typeof(ParameterFilterElement)).Cast<ParameterFilterElement>().ToList();
                List<String> listNameFilter = function.getAllFilterAddin();
                foreach (var item in coll)
                {
                    if (listNameFilter.Exists(x => x == item.Name))
                    {
                        using (Transaction t3 = new Transaction(doc, "DeletePattern"))
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
            if (listFloorSelect.Count == 0)
            {
                MessageBox.Show("You must choose floor.");
                return Result.Succeeded;
            }
            List<FilterFloor> listFilter = function.GetAllFloorPatten(listFloorSelect);
            FilterFloor filterMax = function.GetMaxArea(listFloorSelect, listFilter);
            ColorWin colorWinC = new ColorWin();
            filterMax.ColorSysterm = colorWinC.ColorUser[30];
            filterMax.ColorPatten= new Autodesk.Revit.DB.Color(filterMax.ColorSysterm.R, filterMax.ColorSysterm.G, filterMax.ColorSysterm.B);
            filterMax.Patten = patternMax;
            Autodesk.Revit.DB.View viewActive = doc.ActiveView;
            foreach (var filter in listFilter)
            {
                List<FilterRule> filterRules = new List<FilterRule>();
                using (Transaction t = new Transaction(doc, "Add view filter"))
                {
                    t.Start();
                    ParameterFilterElement parameterFilterElement = ParameterFilterElement.Create(doc, filter.NameType + " " + filter.OffsetLevel * 0.3048 * 1000 + " Addin", categories);
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
            try
            {
                function.DrawingLegend(listFilter);
            }
            catch { }
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
                            if (patern.Name != "<Solid fill>" && pattenDraf.Target == FillPatternTarget.Drafting)
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
            foreach (var filter in listFloorSetting)
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
                    string value = item.Element("NameType").Value + " " + item.Element("OffsetLevel").Value + " Addin";
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

        public void DrawingLegend(List<FilterFloor> listFilters)
        {
            var viewLegend = new FilteredElementCollector(_doc).OfClass(typeof(Autodesk.Revit.DB.View))
                .Cast<Autodesk.Revit.DB.View>().Where(x => x.ViewType == ViewType.Legend && x.Name == Constant.NameViewLegend).First();
            TextNoteType typeText = null;
            try
            {
                typeText = new FilteredElementCollector(_doc)
                          .OfClass(typeof(TextNoteType)).Where(x => x.Name == Constant.TextTypeChose).First() as TextNoteType;
            }
            catch
            {
                MessageBox.Show("You must create type of text: " + Constant.TextTypeChose);
                return;
            }
            TextNoteOptions optionText = new TextNoteOptions();
            optionText.HorizontalAlignment = HorizontalTextAlignment.Center;
            optionText.TypeId = typeText.Id;
            if (viewLegend == null)
            {
                MessageBox.Show("Error: You must create: " + Constant.NameViewLegend + "before setting");
                return;
            }
            double y1 = 0;
            double distanceY = Constant.distanceY;
            int countY = listFilters.Count();
            double yEnd = (distanceY * countY);
            double x1 = 0;
            double distanceX = Constant.distanceX;
            double xEnd = distanceX * 3;
            double z = 0;
            for (int i = 0; i < 4; i++)
            {
                double x = distanceX * i;
                double yBegin = y1;
                XYZ p1 = new XYZ(x, yBegin, z);
                XYZ p2 = new XYZ(x, yEnd, z);
                using (Transaction t4 = new Transaction(_doc, "CreateLine1"))
                {
                    t4.Start();
                    Line L = Line.CreateBound(p1, p2);
                    _doc.Create.NewDetailCurve(viewLegend, L);
                    t4.Commit();
                }
            }
            for (int j = 0; j < countY + 1; j++)
            {
                double xBegin = x1;
                double y = distanceY * j;
                XYZ p1 = new XYZ(xBegin, y, z);
                XYZ p2 = new XYZ(xEnd, y, z);
                using (Transaction t5 = new Transaction(_doc, "CreateLine2"))
                {
                    t5.Start();
                    Line L = Line.CreateBound(p1, p2);
                    _doc.Create.NewDetailCurve(viewLegend, L);
                    t5.Commit();
                }
            }

            for (int k = 0; k < countY; k++)
            {
                double xp1 = distanceX * (1+Constant.rateX);
                double xp2 = distanceX * (1+(1-Constant.rateX));
                double xpY1 = distanceY * k + distanceY*Constant.rateY;
                double xpY2 = distanceY * k + distanceY*(1-Constant.rateY);
                XYZ[] points = new XYZ[5];
                points[0] = new XYZ(xp1, xpY1, z);
                points[1] = new XYZ(xp2, xpY1, z);
                points[2] = new XYZ(xp2, xpY2, z);
                points[3] = new XYZ(xp1, xpY2, z);
                points[4]= new XYZ(xp1, xpY1, z);
                FillPatternElement patternEle = listFilters[k].Patten;
                Autodesk.Revit.DB.Color colorPattern = listFilters[k].ColorPatten;
                string offsetLevel = (listFilters[k].OffsetLevel * 0.3048 * 1000).ToString();
                string nameFloor = listFilters[k].NameType;
                FilteredElementCollector fillRegionTypes = new FilteredElementCollector(_doc).OfClass(typeof(FilledRegionType));
                FilledRegionType type = fillRegionTypes.First() as FilledRegionType;
                string filterName = nameFloor + " " + offsetLevel + " Addin";
                FilledRegionType typeNew=null;
                
                using (Transaction t6 = new Transaction(_doc, "CreateTypeNew"))
                {
                    t6.Start();
                    try
                    {
                        typeNew = type.Duplicate(filterName) as FilledRegionType;
                    }
                    catch
                    {
                        typeNew = fillRegionTypes.Where(x => x.Name == filterName).First() as FilledRegionType;
                    }                    
                    typeNew.ForegroundPatternId = patternEle.Id;
                    typeNew.ForegroundPatternColor = colorPattern;
                    t6.Commit();
                }

                using (Transaction t5 = new Transaction(_doc, "CreatePatternS"))
                {
                        t5.Start();
                        List<CurveLoop> profileloops = new List<CurveLoop>();
                        CurveLoop profileloop = new CurveLoop();
                        for (int i = 0; i < 4; i++)
                        {
                            Line line = Line.CreateBound(points[i], points[i + 1]);
                            profileloop.Append(line); 
                        }
                        profileloops.Add(profileloop);
                        FilledRegion filledRegion = FilledRegion.Create(_doc, typeNew.Id, viewLegend.Id, profileloops);
                        t5.Commit(); 
                }

                double xpY6 = distanceY * k;
                using (Transaction t8= new Transaction(_doc, "CreateTextOffset"))
                {
                    t8.Start();

                    for (int i = 0; i < 4; i+=2)
                    {
                        XYZ pointText = new XYZ(distanceX*i+distanceX/2, xpY6+distanceY*(1-(2+0.5)*Constant.rateY), points[i].Z);
                        if (i == 0)
                        {
                            TextNote.Create(_doc, viewLegend.Id, pointText, 0.05, nameFloor, optionText);
                        }else
                        {
                            TextNote.Create(_doc, viewLegend.Id, pointText, 0.05, offsetLevel, optionText);
                        }                        
                    }
                    t8.Commit();
                }
                
            }
        }

        public FilterFloor GetMaxArea(List<Element> listElementSelect,List<FilterFloor> listAllFilter)
        {
            FilterFloor filterMax = null;
            double totalAreaMax = 0;
            foreach (var filter in listAllFilter)
            {
                double totalAreaElement = 0;
                foreach (Element el in listElementSelect)
                {
                    double offset = el.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble();
                    if (el.Name == filter.NameType && offset == filter.OffsetLevel)
                    {
                        totalAreaElement = totalAreaElement + el.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED).AsDouble();
                    }
                    
                }
                if (totalAreaElement > totalAreaMax)
                {
                    filterMax = filter;
                    totalAreaMax = totalAreaElement;
                }             
            }
            return filterMax;             
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
