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
    public class FloorPlanBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            BindingFunction function = new BindingFunction(uiApp);
            Autodesk.Revit.DB.View viewActive = doc.ActiveView;
            try
            {
                List<ParameterFilterElement> listFilterPattern = new FilteredElementCollector(doc).OfClass(typeof(ParameterFilterElement)).Cast<ParameterFilterElement>().ToList();
                List<String> listNameFilter = function.getAllFilterAddin();
                var fillPatternElements = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement))
                .OfType<FillPatternElement>().OrderBy(fp => fp.Name).ToList();

                string name = doc.Title + "floorPattern.xml";
                string fullPath = Path.GetFullPath(name);
                var xmlDoc = XDocument.Load(fullPath);
                var xmlElement = xmlDoc.Element("Table").Elements("PatternFloor");
                foreach (var item in xmlElement)
                {
                    string nameFilter= item.Element("NameType").Value + " " + item.Element("OffsetLevel").Value + " Addin";
                    ParameterFilterElement filterPattern = listFilterPattern.Where(x => x.Name == nameFilter).First();
                    string namePatten = item.Element("Patten").Value;
                    FillPatternElement fillPattern = null;
                    foreach (var pat in fillPatternElements)
                    {
                        FillPattern patternDraf = pat.GetFillPattern();
                        if (patternDraf.Target == FillPatternTarget.Drafting)
                        {
                            if (namePatten == pat.Name)
                            {
                                fillPattern = pat;
                                break;
                            }
                        }            
                    }
                    string color= item.Element("ColorSystem").Value;
                    var colorSys = System.Drawing.Color.FromArgb(Int32.Parse(color));
                    Autodesk.Revit.DB.Color colorRevit = new Autodesk.Revit.DB.Color(colorSys.R, colorSys.G, colorSys.B);
                    using (Transaction t3 = new Transaction(doc, "AddFilterToView"))
                    {
                        t3.Start();
                        viewActive.AddFilter(filterPattern.Id);
                        viewActive.SetFilterVisibility(filterPattern.Id, true);
                        OverrideGraphicSettings overrideSettings = viewActive.GetFilterOverrides(filterPattern.Id);
                        overrideSettings.SetSurfaceForegroundPatternId(fillPattern.Id);
                        overrideSettings.SetSurfaceForegroundPatternColor(colorRevit);
                        viewActive.SetFilterOverrides(filterPattern.Id, overrideSettings);
                        t3.Commit();
                    }
                }
              
            }
            catch { }
            return Result.Succeeded;
        }
    }
  
}
