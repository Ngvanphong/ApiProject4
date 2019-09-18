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
   public class AlignLeftButton
    {
        public void AlignLeft(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn";
            const string ribbonPanel = "Align";
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

            PushButtonData btnData = new PushButtonData("Align left", "Align left",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.AlignElement.AlignLeftBinding")
            {
                ToolTip = "Allign left for element",
                LongDescription = "Allign left for element",
            };

            PushButtonData btnData2 = new PushButtonData("Align center", "Align center",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.AlignElement.AlignCenterBinding")
            {
                ToolTip = "Align center for element",
                LongDescription = "Align center for element",

            };

            PushButtonData btnData3 = new PushButtonData("Align right", "Align right",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.AlignElement.AlignRightBinding")
            {
                ToolTip = "Align right for element",
                LongDescription = "Align right for element",

            };

            List<RibbonItem> projectButtons = new List<RibbonItem>();
            projectButtons.AddRange(panel.AddStackedItems(btnData, btnData2,btnData3));

           // button.Enabled = true;
        }

    }
}
