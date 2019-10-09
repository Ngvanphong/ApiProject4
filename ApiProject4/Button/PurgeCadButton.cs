using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using System.Drawing;
using System.Windows.Media;
using System.Reflection;

namespace ApiProject4.Button
{
   public class PurgeCadButton
    {
        public void PurgeCad(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn";
            const string ribbonPanel = "Element";
            try
            {
                application.CreateRibbonTab(ribbonTag);
            }
            catch (Exception ex) { }
            RibbonPanel panel = null;
            List<RibbonPanel> panels = application.GetRibbonPanels(ribbonTag);
            foreach (RibbonPanel pl in panels)
            {
                if (pl.Name == ribbonPanel)
                {
                    panel = pl;
                    break;
                }
            }
            if (panel == null)
            {
                panel = application.CreateRibbonPanel(ribbonTag, ribbonPanel);
            }
            Image img = ApiProject4.Properties.Resources.icons8_trash_can_16;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("PurgeCad", "PurgeCad",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.PurgeCad.PurgeCadBinding")
            {
                ToolTip = "Purge cad import",
                LongDescription = "Purge cad import",
                Image = imgSrc,
                LargeImage = imgSrc,
            };
            Image img2 = ApiProject4.Properties.Resources.icons8_box_16;
            ImageSource imgSrc2 = Helper.Extension.GetImageSource(img2);
            PushButtonData btnData2 = new PushButtonData("ScopeBox", "ScopeBox",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.ScopeBox.ScopeBoxBinding")
            {
                ToolTip = "Assign scope box for view",
                LongDescription = "Assign scope box for view",
                Image = imgSrc2,
                LargeImage = imgSrc2,
            };
            Image img3 = ApiProject4.Properties.Resources.icons8_print_16;
            ImageSource imgSrc3 = Helper.Extension.GetImageSource(img3);
            PushButtonData btnData3 = new PushButtonData("PrintSort", "PrintSort",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.PrintSort.PrintSortBinding")
            {
                ToolTip = "Set print sort for sheets",
                LongDescription = "Set print sort for sheets",
                Image = imgSrc3,
                LargeImage = imgSrc3,
            };
       
            List<RibbonItem> projectButtons = new List<RibbonItem>();
            projectButtons.AddRange(panel.AddStackedItems(btnData, btnData2,btnData3));
        }
    }
}
