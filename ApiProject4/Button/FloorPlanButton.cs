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
   public class FloorPlanButton
    {
        public void FloorPattenCreate(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn";
            const string ribbonPanel = "Element";
            try
            {
                application.CreateRibbonTab(ribbonTag);
            }
            catch { }
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
            Image img = ApiProject4.Properties.Resources.icons8_floor_plan_32;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("FloorPlan", "FloorPlan",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.FloorPlan.FloorPlanBinding")
            {
                ToolTip = "Create fill pattern for floor",
                LongDescription = "Create fill pattern for floor",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            Image img4 = ApiProject4.Properties.Resources.icons8_gear_32;
            ImageSource imgSrc4 = Helper.Extension.GetImageSource(img4);
            PushButtonData btnData4 = new PushButtonData("SettingPattern", "SettingPattern", Assembly.GetExecutingAssembly().Location, "ApiProject4.FloorPlan.SettingPatternBinding")
            {
                ToolTip = "Setting for filter floor",
                LongDescription = "Setting for filter floor",
                Image = imgSrc4,
                LargeImage = imgSrc4,
            };

            SplitButtonData splitData = new SplitButtonData("FilterFloor", "FilterFloor");
            SplitButton splitButton = panel.AddItem(splitData) as SplitButton;
            splitButton.IsSynchronizedWithCurrentItem = true;
            splitButton.AddPushButton(btnData);
            splitButton.AddPushButton(btnData4);
        }
    }
}
